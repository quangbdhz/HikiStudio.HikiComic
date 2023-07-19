using HikiComic.Application.Base;
using HikiComic.Application.Notifications;
using HikiComic.Application.UserContext;
using HikiComic.Application.UserRoleUpgradeRequests;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Notifications.NotificationsDataRequest;
using HikiComic.ViewModels.UserRoleUpgradeExchanges;
using HikiComic.ViewModels.UserRoleUpgradeExchanges.UserRoleUpgradeExchangeDataRequest;
using HikiComic.ViewModels.UserRoleUpgradeRequests.UserRoleUpgradeRequestDataRequest;
using Microsoft.EntityFrameworkCore;

namespace HikiComic.Application.UserRoleUpgradeExchanges
{
    public class UserRoleUpgradeExchangeService : BaseService<UserRoleUpgradeExchange>, IUserRoleUpgradeExchangeService
    {
        private readonly HikiComicDbContext _context;

        private readonly IUserContextService _userContextService;

        private readonly IUserRoleUpgradeRequestService _userRoleUpgradeRequestService;

        private readonly INotificationService _notificationService;

        public UserRoleUpgradeExchangeService(HikiComicDbContext context, IUserContextService userContextService, IUserRoleUpgradeRequestService userRoleUpgradeRequestService, INotificationService notificationService) 
            : base(context, userContextService)
        {
            _context = context;
            _userContextService = userContextService;
            _userRoleUpgradeRequestService = userRoleUpgradeRequestService;
            _notificationService = notificationService;
        }

        public async Task<ApiResult<UserRoleUpgradeExchangeViewModel>> CreateUserRoleUpgradeExchange(CreateUserRoleUpgradeExchangeRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<UserRoleUpgradeExchangeViewModel>();

            var isHighRole = _userContextService.CheckUserRoleAdminOrTeamMember();
            if (!isHighRole.IsSuccessed)
                return new ApiErrorResult<UserRoleUpgradeExchangeViewModel>() { Message = MessageConstants.AnErrorOccurred };

            var userRoleUpgradeRequest = await _context.UserRoleUpgradeRequests.FirstOrDefaultAsync(x => x.UserRoleUpgradeRequestId == request.UserRoleUpgradeRequestId);

            if (userRoleUpgradeRequest is null)
                return new ApiErrorResult<UserRoleUpgradeExchangeViewModel>() { Message = MessageConstants.ObjectNotFound(nameof(UserRoleUpgradeRequest)) };

            if(userRoleUpgradeRequest.IsDeleted)
                return new ApiErrorResult<UserRoleUpgradeExchangeViewModel>() { Message = MessageConstants.CurrentObjectDeleted(nameof(UserRoleUpgradeRequest)) };

            if (userRoleUpgradeRequest.ApprovalStatus == ApprovalStatusEnum.Approved)
                return new ApiSuccessResult<UserRoleUpgradeExchangeViewModel>() { Message = "The account has been successfully upgraded." };

            if(userRoleUpgradeRequest.ApprovalStatus == ApprovalStatusEnum.Sent)
            {
                var result = await _userRoleUpgradeRequestService.ChangeApprovalStatusUserRoleUpgradeRequest(new CreateUserRoleUpgradeRequestRequest()
                {
                    UserRoleUpgradeRequestId = userRoleUpgradeRequest.UserRoleUpgradeRequestId,
                    ApprovalStatus = ApprovalStatusEnum.InDiscussion
                });

                if (!result.IsSuccessed)
                    return new ApiErrorResult<UserRoleUpgradeExchangeViewModel>() { Message = result.Message };
            }

            var userRoleUpgradeExchange = new UserRoleUpgradeExchange()
            {
                UserRoleUpgradeRequestId = userRoleUpgradeRequest.UserRoleUpgradeRequestId,
                Message = request.Message,
                IsReaded = false,
                IsDeleted = false,
                CreatedBy = userResult.ResultObj,
                DateCreated = DateTime.Now,
                IsReader = !isHighRole.ResultObj
            };

            await _context.UserRoleUpgradeExchanges.AddAsync(userRoleUpgradeExchange);
            await _context.SaveChangesAsync();

            var createNotificationRequest = new CreateNotificationRequest()
            {
                AppUserId = null,
                CreatedBy = userResult.ResultObj,
                Actions = null,
                ComicId = null,
                ImageURL = null,
                IsRead = false,
                NotificationPriority = NotificationPriorityEnum.Medium,
                Title = "",
                Message = request.Message.Length > 20 ? request.Message.Substring(0, 19) + "..." : request.Message
            };

            var roles = await _context.UserRoles.Include(x => x.AppRole).Where(x => x.UserId == userResult.ResultObj).Select(x => x.AppRole.Priority).ToListAsync();

            if(roles.Any(x => x == RolePriorityEnum.Medium || x == RolePriorityEnum.High))
            {
                createNotificationRequest.AppUserId = userRoleUpgradeRequest.AppUserId;
                createNotificationRequest.Title = "A new message has been received regarding an account upgrade notification.";
            }

            var resultNotification = await _notificationService.CreateNotification(createNotificationRequest, NotificationTypeEnum.UserRoleUpgradeExchange);

            var userRoleUpgradeExchangeViewModel = new UserRoleUpgradeExchangeViewModel()
            {
                Message = userRoleUpgradeExchange.Message,
                URLAvatar = _userContextService.GetUserURLImageAvatar().ResultObj,
                DateCreated = userRoleUpgradeExchange.DateCreated
            };

            return new ApiSuccessResult<UserRoleUpgradeExchangeViewModel>() 
            {
                ResultObj = userRoleUpgradeExchangeViewModel,
                Message = MessageConstants.OperationSuccess(OperationTypeEnum.Create, nameof(UserRoleUpgradeExchange), 0) 
            };
        }

        private static string ConvertURLImage(string? url)
        {
            if (url is null)
                return SystemConstants.AppSettings.URLDomainMyHostDevelopment + SystemConstants.AppSettings.PathFolderUploadImageResponse + "default.jpg";

            if (url.Contains("https://") || url.Contains("http://"))
            {
                return url;
            }
            else
            {
                return SystemConstants.AppSettings.URLDomainMyHostDevelopment + SystemConstants.AppSettings.PathFolderUploadImageResponse + url;
            }
        }

        public async Task<IList<UserRoleUpgradeExchangeViewModel>> GetUserRoleUpgradeExchangeByUserRoleUpgradeRequestId(int userRoleUpgradeRequestId)
        {
            var query = from urur in _context.UserRoleUpgradeRequests
                        where urur.UserRoleUpgradeRequestId == userRoleUpgradeRequestId
                        join urge in _context.UserRoleUpgradeExchanges on urur.UserRoleUpgradeRequestId equals urge.UserRoleUpgradeRequestId
                        join u in _context.Users on urge.CreatedBy equals u.Id  
                        select new { urge, urur, u };

            var data = await query.Select(x => new UserRoleUpgradeExchangeViewModel()
            {
                UserRoleUpgradeRequestId = x.urur.UserRoleUpgradeRequestId,
                UserRoleUpgradeExchangeId = x.urge.UserRoleUpgradeExchangeId,
                Message = x.urge.Message,
                URLAvatar = ConvertURLImage(x.u.UserImageURL),
                DateCreated = x.urge.DateCreated,
                IsReaded = x.urge.IsReaded,
                IsReader = x.urge.IsReader
            }).ToListAsync();

            return data;
        }

        #region override method of BaseService
        protected override Task<UserRoleUpgradeExchange?> CreateObjectProperties(object request)
        {
            throw new NotImplementedException();
        }

        protected override int GetObjectId(UserRoleUpgradeExchange entity)
        {
            return entity.UserRoleUpgradeExchangeId;
        }

        protected override Task<string> GetObjectName(object request)
        {
            throw new NotImplementedException();
        }

        protected override Task<string> GetObjectName(UserRoleUpgradeExchange entity)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateObjectProperties(UserRoleUpgradeExchange existingObject, object request)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

using HikiComic.Application.Accounts;
using HikiComic.Application.Base;
using HikiComic.Application.Common;
using HikiComic.Application.Notifications;
using HikiComic.Application.SendMails;
using HikiComic.Application.UserContext;
using HikiComic.Application.UserRoles;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Notifications.NotificationsDataRequest;
using HikiComic.ViewModels.UserRoleUpgradeRequests;
using HikiComic.ViewModels.UserRoleUpgradeRequests.UserRoleUpgradeRequestDataRequest;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HikiComic.Application.UserRoleUpgradeRequests
{
    public class UserRoleUpgradeRequestService : BaseService<UserRoleUpgradeRequest>, IUserRoleUpgradeRequestService
    {
        private readonly HikiComicDbContext _context;

        private readonly DbContextOptions _options;

        private readonly IUserContextService _userContextService;

        private readonly IUserRoleService _userRoleService;

        private readonly ISendMailService _sendMailService;

        private readonly ICommonService _commonService;

        private readonly IAccountService _accountService;

        private readonly INotificationService _notificationService;

        public UserRoleUpgradeRequestService(HikiComicDbContext context, DbContextOptions options, IUserContextService userContextService,
        IUserRoleService userRoleService, ISendMailService sendMailService, ICommonService commonService, IAccountService accountService,INotificationService notificationService)
            : base(context, userContextService)
        {
            _context = context;
            _options = options;
            _commonService = commonService;
            _userContextService = userContextService;
            _userRoleService = userRoleService;
            _sendMailService = sendMailService;
            _accountService = accountService;
            _notificationService = notificationService;
        }

        public async Task<PagingResult<UserRoleUpgradeRequestViewModel>> GetPagingManagement(PagingRequest request)
        {
            var userRoleUpgradeRequestViewModels = await _context.UserRoleUpgradeRequests.Include(x => x.AppUser).Select(x => new UserRoleUpgradeRequestViewModel()
            {
                UserRoleUpgradeRequestId = x.UserRoleUpgradeRequestId,
                AppUserId = x.AppUserId,
                UserName = x.AppUser.UserName,
                Email = x.AppUser.Email,
                PhoneNumber = x.AppUser.PhoneNumber,
                LastName = x.AppUser.LastName,
                FirstName = x.AppUser.FirstName,
                ApprovalStatus = x.ApprovalStatus,
                IsDeleted = x.IsDeleted,
                DateCreated = x.DateCreated
            }).ToListAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                userRoleUpgradeRequestViewModels = await _context.UserRoleUpgradeRequests.Include(x => x.AppUser).Select(x => new UserRoleUpgradeRequestViewModel()
                {
                    UserRoleUpgradeRequestId = x.UserRoleUpgradeRequestId,
                    AppUserId = x.AppUserId,
                    UserName = x.AppUser.UserName,
                    Email = x.AppUser.Email,
                    PhoneNumber = x.AppUser.PhoneNumber,
                    LastName = x.AppUser.LastName,
                    FirstName = x.AppUser.FirstName,
                    ApprovalStatus = x.ApprovalStatus,
                    IsDeleted = x.IsDeleted,
                    DateCreated = x.DateCreated
                }).OrderBy(request.SortColumn + " " + request.SortColumnDirection).ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                userRoleUpgradeRequestViewModels = userRoleUpgradeRequestViewModels
                    .Where(x => x.Email.ToLower().Contains(request.SearchValue.ToLower()) ||
                                x.UserName.ToLower().Contains(request.SearchValue.ToLower()) ||
                                (x.PhoneNumber ?? "").ToLower().Contains(request.SearchValue.ToLower()) ||
                                (x.LastName ?? "").ToLower().Contains(request.SearchValue.ToLower()) ||
                                (x.FirstName ?? "").ToLower().Contains(request.SearchValue.ToLower()))
                    .ToList();
            }

            request.RecordsTotal = userRoleUpgradeRequestViewModels.Count();
            var data = userRoleUpgradeRequestViewModels.Skip(request.Skip).Take(request.PageSize).ToList();


            var jsonData = new { draw = request.Draw, recordsFiltered = request.RecordsTotal, recordsTotal = request.RecordsTotal, data = data };

            var result = new PagingResult<UserRoleUpgradeRequestViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = data
            };

            return result;
        }

        public async Task<ApiResult<UserRoleUpgradeRequestViewModel>> GetUserRoleUpgradeRequestByUserRoleUpgradeRequestId(int userRoleUpgradeRequestId)
        {
            var userRoleUpgradeRequestViewModel = await _context.UserRoleUpgradeRequests.Include(x => x.AppUser).Select(x => new UserRoleUpgradeRequestViewModel()
            {
                UserRoleUpgradeRequestId = x.UserRoleUpgradeRequestId,
                AppUserId = x.AppUserId,
                UserName = x.AppUser.UserName,
                Email = x.AppUser.Email,
                PhoneNumber = x.AppUser.PhoneNumber,
                LastName = x.AppUser.LastName,
                FirstName = x.AppUser.FirstName,
                ApprovalStatus = x.ApprovalStatus,
                IsDeleted = x.IsDeleted,
                DateCreated = x.DateCreated
            }).FirstOrDefaultAsync(x => x.UserRoleUpgradeRequestId == userRoleUpgradeRequestId);

            if (userRoleUpgradeRequestViewModel is null)
                return new ApiErrorResult<UserRoleUpgradeRequestViewModel>() { Message = MessageConstants.ObjectNotFound("Creator") };

            return new ApiSuccessResult<UserRoleUpgradeRequestViewModel>() { ResultObj = userRoleUpgradeRequestViewModel };
        }

        public async Task<ApiResult<bool>> ChangeApprovalStatusUserRoleUpgradeRequest(CreateUserRoleUpgradeRequestRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var userRoleUpgradeRequest = await _context.UserRoleUpgradeRequests.FirstOrDefaultAsync(x => x.UserRoleUpgradeRequestId == request.UserRoleUpgradeRequestId);

            if (userRoleUpgradeRequest is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound(nameof(UserRoleUpgradeRequest)) };

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userRoleUpgradeRequest.AppUserId);
            if (user is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound(nameof(AppUser)) };

            string userEmailTemp = String.Empty;
            string userPasswordTemp = String.Empty;
            string html = String.Empty;
            if (request.ApprovalStatus == ApprovalStatusEnum.Approved)
            {
                var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == SystemConstants.AppSettings.CreatorRole);
                if (role is null)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Role") };

                var roleIds = new List<Guid>();
                roleIds.Add(role.Id);

                var result = await _userRoleService.CreateUserRoles(roleIds, userRoleUpgradeRequest.AppUserId);
                if (!result.IsSuccessed)
                    return new ApiErrorResult<bool>() { Message = result.Message };

                if (user.IsCreateAppUserWithThirdParty)
                {
                    if (user.AppUserTypeId == (int)LoginWithThirdPartyEnum.Facebook || user.AppUserTypeId == (int)LoginWithThirdPartyEnum.Google)
                    {
                        userEmailTemp = user.Email;
                        userPasswordTemp = _commonService.GeneratePassword(12, includeLowercase: true, includeUppercase: true, includeNumeric: true, includeSpecial: true);

                        var resultResetPassword = await _accountService.ResetPassword(new ViewModels.Accounts.AccountDataRequest.ResetPasswordRequest()
                        {
                            Email = userEmailTemp,
                            NewPassword = userPasswordTemp,
                            ConfirmPassword = userPasswordTemp,
                        }, true, true);

                        if (!resultResetPassword.IsSuccessed)
                            return new ApiErrorResult<bool>() { Message = resultResetPassword.Message };

                        html = $"<div style=\"text-align: left; margin: 0; padding: 0;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui; font-weight: bold;\">Login information</span>\r\n                            <p style=\"font-size: 14px; font-family: system-ui; margin: 3px; margin-left: 35px;\">Email: <strong>{userEmailTemp}</strong></p>\r\n                            <p style=\"font-size: 14px; font-family: system-ui; margin: 3px; margin-left: 35px;\">Password: <strong>{userPasswordTemp}</strong></p>\r\n                        </div>";
                    }
                }
            }

            userRoleUpgradeRequest.ApprovalStatus = request.ApprovalStatus;
            userRoleUpgradeRequest.UpdatedBy = userResult.ResultObj;
            userRoleUpgradeRequest.DateUpdated = DateTime.Now;
            await _context.SaveChangesAsync();

            if (request.ApprovalStatus == ApprovalStatusEnum.Approved)
            {
                if(String.IsNullOrEmpty(html))
                    html = $"<div style=\"text-align: left; margin: 0; padding: 0;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui; font-weight: bold;\">Login information</span>\r\n                            <p style=\"font-size: 14px; font-family: system-ui; text-align: center; margin: 3px;\">Use the same information as the reader role</p>\r\n                        </div>";

                var send = await _sendMailService.SendMailOTP(user.Email, MailTypeEnum.EmailCongratulations, SystemConstants.AppSettings.URLDomainMyHostDevelopment, htmlBonus: html);

                var createNotificationRequest = new CreateNotificationRequest()
                {
                    AppUserId = user.Id,
                    ComicId = null,
                    ChapterId = null,
                    Actions = "",
                    ImageURL = SystemConstants.AppSettings.AvatarImageURLSystem,
                    IsRead = false,
                    Title = $"Upgrade request to creator has approved.",
                    Message = $"Upgrade request to creator has approved. Please check your email for instructions.",
                };

                var resultCreateNotification = await _notificationService.CreateNotification(createNotificationRequest, NotificationTypeEnum.ReplyComment);

                return new ApiSuccessResult<bool>() { Message = MessageConstants.UserApprovalSuccess };
            }
            else if (request.ApprovalStatus == ApprovalStatusEnum.Rejected)
            {
                var createNotificationRequest = new CreateNotificationRequest()
                {
                    AppUserId = user.Id,
                    ComicId = null,
                    ChapterId = null,
                    Actions = "",
                    ImageURL = SystemConstants.AppSettings.AvatarImageURLSystem,
                    IsRead = false,
                    Title = $"Upgrade request to creator has rejected.",
                    Message = $"Upgrade request to creator has rejected.",
                };

                var resultCreateNotification = await _notificationService.CreateNotification(createNotificationRequest, NotificationTypeEnum.ReplyComment);

                return new ApiSuccessResult<bool>() { Message = MessageConstants.UserRejectSuccess };
            }

            return new ApiSuccessResult<bool>() { Message = "The account has been successfully upgraded." };
        }

        #region override method of BaseService
        protected override async Task<UserRoleUpgradeRequest?> CreateObjectProperties(object request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return null;

            var roleCreator = await _context.Roles.FirstOrDefaultAsync(x => x.Name.ToLower() == SystemConstants.AppSettings.CreatorRole);
            if (roleCreator is null)
                return null;

            var roleReader = await _context.Roles.FirstOrDefaultAsync(x => x.Name.ToLower() == SystemConstants.AppSettings.ReaderRole);
            if (roleReader is null)
                return null;

            var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.RoleId == roleCreator.Id && x.UserId == userResult.ResultObj);
            if (userRole != null)
                return null;

            return new UserRoleUpgradeRequest()
            {
                AppUserId = userResult.ResultObj,
                CurrentRoleId = roleReader.Id,
                DesiredRoleId = roleCreator.Id,
                ApprovalStatus = ApprovalStatusEnum.Sent
            };
        }

        protected override int GetObjectId(UserRoleUpgradeRequest entity)
        {
            return entity.UserRoleUpgradeRequestId;
        }

        protected override async Task<string> GetObjectName(object request)
        {
            using (var _secondContext = new HikiComicDbContext(_options))
            {
                var roleIdCreator = await _secondContext.Roles.FirstOrDefaultAsync(x => x.Name.ToLower() == SystemConstants.AppSettings.CreatorRole);
                if (roleIdCreator is null)
                    return "";

                var roleIdReader = await _secondContext.Roles.FirstOrDefaultAsync(x => x.Name.ToLower() == SystemConstants.AppSettings.ReaderRole);
                if (roleIdReader is null)
                    return "";

                var userResult = _userContextService.GetUserIdFromToken();
                if (!userResult.IsSuccessed)
                    return "";

                var userRoleUpgradeRequest = await _secondContext.UserRoleUpgradeRequests.FirstOrDefaultAsync(x => x.AppUserId == userResult.ResultObj && x.CurrentRoleId == roleIdReader.Id && x.DesiredRoleId == roleIdCreator.Id);

                return userResult.ResultObj.ToString() + roleIdReader.Id.ToString() + roleIdCreator.Id.ToString();
            }
        }


        protected override Task<string> GetObjectName(UserRoleUpgradeRequest entity)
        {
            return Task.FromResult(entity.AppUserId.ToString() + entity.CurrentRoleId.ToString() + entity.DesiredRoleId.ToString());
        }

        protected override void UpdateObjectProperties(UserRoleUpgradeRequest existingObject, object request)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

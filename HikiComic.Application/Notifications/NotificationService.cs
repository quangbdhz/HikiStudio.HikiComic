using HikiComic.Application.Firebases;
using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Notifications;
using HikiComic.ViewModels.Notifications.FirebaseCloudMessaging;
using HikiComic.ViewModels.Notifications.NotificationsDataRequest;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Text;


namespace HikiComic.Application.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly HikiComicDbContext _context;

        private readonly IUserContextService _userContextService;

        private readonly IFirebaseCloudMessagingService _firebaseCloudMessagingService;

        public NotificationService(HikiComicDbContext context, IUserContextService userContextService, IFirebaseCloudMessagingService firebaseCloudMessagingService)
        {
            _context = context;
            _userContextService = userContextService;
            _firebaseCloudMessagingService = firebaseCloudMessagingService;
        }

        protected async Task<ApiResult<bool>> SendFCMNotifications(List<FCMNotificationRequest> userDevices)
        {
            foreach (var item in userDevices)
            {
                await _firebaseCloudMessagingService.SendFCMNotification(item);
            }

            return new ApiSuccessResult<bool>();
        }

        /// <summary>
        /// Roles: adimin, client
        /// Feature: create notification
        /// Condition: verified input [AppUserId, CreateAt (Creator Id)]
        /// </summary>
        /// <param name="request"></param>
        /// <param name="notificationType"></param>
        /// <param name="userId">
        /// case 1: -> Adimin -> userId = userIdAdmin -> notification all server 
        /// case 2: -> Users -> userId = userIdClient -> reply comment
        /// </param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> CreateNotification(CreateNotificationRequest request, NotificationTypeEnum notificationType)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            if (notificationType == NotificationTypeEnum.System)
            {
                var notification = new Data.Entities.Notification()
                {
                    AppUserId = null,
                    ComicId = null,
                    IsRead = false,
                    Title = request.Title,
                    Message = request.Message,
                    Actions = request.Actions ?? "",
                    ImageURL = request.ImageURL ?? "",
                    NotificationType = NotificationTypeEnum.System,
                    NotificationPriority = (int)request.NotificationPriority > 5 ? NotificationPriorityEnum.High : request.NotificationPriority,
                    CreatedBy = userResult.ResultObj,
                    DateCreated = DateTime.Now
                };

                await _context.Notifications.AddAsync(notification);
                await _context.SaveChangesAsync();

                //using service -> push notification to all users
                var query = from u in _context.Users
                            where !u.IsDeleted && !u.LockoutEnabled
                            join ud in _context.AppUserDevices on u.Id equals ud.AppUserId
                            select ud;

                var fCMNotifications = await query.Select(x => new FCMNotificationRequest()
                {
                    FCMDeviceToken = x.FCMDeviceToken,
                    IsAndroiodDevice = true,
                    Title = request.Title,
                    Body = request.Message
                }).ToListAsync();

                await SendFCMNotifications(fCMNotifications);

                return new ApiSuccessResult<bool>() { Message = MessageConstants.CreateSuccess("Notification System") };
            }
            else if (notificationType == NotificationTypeEnum.ReplyComment)
            {
                var notification = new Data.Entities.Notification()
                {
                    AppUserId = request.AppUserId,
                    ComicId = request.ComicId,
                    IsRead = false,
                    Title = request.Title,
                    Message = request.Message,
                    Actions = request.Actions ?? "",
                    ImageURL = request.ImageURL ?? "",
                    NotificationType = NotificationTypeEnum.ReplyComment,
                    NotificationPriority = NotificationPriorityEnum.Medium,
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                    CreatedBy = userResult.ResultObj
                };

                //using service -> push notification to us

                await _context.Notifications.AddAsync(notification);
                await _context.SaveChangesAsync();

                var fCMNotifications = await _context.AppUserDevices.Where(x => !x.IsDeleted && x.AppUserId == request.AppUserId).Select(x => new FCMNotificationRequest()
                {
                    FCMDeviceToken = x.FCMDeviceToken,
                    IsAndroiodDevice = true,
                    Title = request.Title,
                    Body = request.Message
                }).ToListAsync();

                await SendFCMNotifications(fCMNotifications);

                return new ApiSuccessResult<bool>() { Message = MessageConstants.CreateSuccess("Notification System") };
            }
            else if (notificationType == NotificationTypeEnum.UserRoleUpgradeExchange)
            {
                var notification = new Data.Entities.Notification()
                {
                    AppUserId = request.AppUserId,
                    ComicId = request.ComicId,
                    IsRead = false,
                    Title = request.Title,
                    Message = request.Message,
                    Actions = request.Actions ?? "",
                    ImageURL = request.ImageURL ?? "",
                    NotificationType = NotificationTypeEnum.UserRoleUpgradeExchange,
                    NotificationPriority = NotificationPriorityEnum.Medium,
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                    CreatedBy = userResult.ResultObj
                };

                await _context.Notifications.AddAsync(notification);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>() { Message = MessageConstants.CreateSuccess("Notification System") };
            }
            else if (notificationType == NotificationTypeEnum.RequestApproval)
            {
                var notification = new Notification()
                {
                    AppUserId = null,
                    ComicId = request.ComicId,
                    ChapterId = request.ChapterId,
                    IsRead = false,
                    Title = request.Title,
                    Message = request.Message,
                    Actions = request.Actions ?? "",
                    ImageURL = request.ImageURL ?? "",
                    NotificationType = NotificationTypeEnum.RequestApproval,
                    NotificationPriority = NotificationPriorityEnum.Medium,
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                    CreatedBy = userResult.ResultObj
                };

                await _context.Notifications.AddAsync(notification);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>() { Message = MessageConstants.CreateSuccess("Request Approval") };
            }
            else if (notificationType == NotificationTypeEnum.ResponseApproval)
            {
                var notification = new Notification()
                {
                    AppUserId = request.AppUserId,
                    ComicId = request.ComicId,
                    ChapterId = request.ChapterId,
                    IsRead = false,
                    Title = request.Title,
                    Message = request.Message,
                    Actions = request.Actions ?? "",
                    ImageURL = request.ImageURL ?? "",
                    NotificationType = NotificationTypeEnum.ResponseApproval,
                    NotificationPriority = NotificationPriorityEnum.Medium,
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                    CreatedBy = userResult.ResultObj
                };

                await _context.Notifications.AddAsync(notification);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>() { Message = MessageConstants.CreateSuccess("Response Approval") };
            }
            else
            {
                return new ApiErrorResult<bool>() { Message = MessageConstants.InvalidNotificationMethod };
            }
        }

        /// <summary>
        /// Roles: admin
        /// Feature: create notifcations -> this feature comes with create chapter 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="notificationType"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> CreateNotifications(CreateNotificationRequest request, NotificationTypeEnum notificationType)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            if (notificationType == NotificationTypeEnum.NewComic)
            {
                return new ApiSuccessResult<bool>() { Message = MessageConstants.NotImplemented(nameof(CreateNotifications), "notificationType == NotificationTypeEnum.NewComic") };
            }
            else if (notificationType == NotificationTypeEnum.NewChapter)
            {
                if (request.ComicId is null)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(CreateNotification), "comicId is null") };

                var query = from c in _context.Comics
                            join ucf in _context.UserComicFollowings on c.ComicId equals ucf.ComicId
                            join u in _context.Users on ucf.AppUserId equals u.Id
                            join ud in _context.AppUserDevices on u.Id equals ud.AppUserId
                            where c.ComicId == request.ComicId && u.IsDeleted == false && c.IsDeleted == false && ud.IsDeleted == false
                            select new { c, u, ucf, ud };

                var notifications = await query.Select(x => new Notification()
                {
                    AppUserId = x.u.Id,
                    ComicId = request.ComicId,
                    IsRead = false,
                    Title = request.Title,
                    Message = request.Message,
                    Actions = request.Actions ?? "",
                    ImageURL = x.c.ComicCoverImageURL,
                    NotificationType = NotificationTypeEnum.NewChapter,
                    NotificationPriority = NotificationPriorityEnum.Low,
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                    CreatedBy = userResult.ResultObj
                }).Distinct().ToListAsync();

                /// -> insert error with BulkInsertAsync
                /// -> System.InvalidOperationException: Cannot access destination table '[dbo].[Notifications]'.
                //_context.BulkInsert(notifications, options => options.SetOutputIdentity = false);

                await _context.Notifications.AddRangeAsync(notifications);
                await _context.SaveChangesAsync();

                //handle FCM send noitification to client
                var fCMNotifications = await query.Select(x => new FCMNotificationRequest()
                {
                    FCMDeviceToken = x.ud.FCMDeviceToken,
                    IsAndroiodDevice = true,
                    Title = request.Title,
                    Body = request.Message
                }).ToListAsync();

                await SendFCMNotifications(fCMNotifications);

                return new ApiSuccessResult<bool>() { Message = MessageConstants.CreateSuccess("Notification NewChapter") };
            }
            else
            {
                return new ApiErrorResult<bool>() { Message = MessageConstants.InvalidNotificationMethod };
            }
        }

        /// <summary>
        /// Roles: admin
        /// Feature: delete notification with NotificationType = System
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> DeleteNotification(int notificationId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.NotificationId == notificationId);

            if (notification is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Notification") };

            if (notification.NotificationType != NotificationTypeEnum.System)
                return new ApiErrorResult<bool>() { Message = MessageConstants.UnableToDeleteNotification };

            if (notification.IsDeleted)
                return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess(nameof(Data.Entities.Notification)) };

            notification.IsDeleted = true;
            notification.DateUpdated = DateTime.Now;
            notification.UpdatedBy = userResult.ResultObj;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess(nameof(Data.Entities.Notification)) };
        }

        /// <summary>
        /// Roles: admin
        /// Feature: multiple delete with NotificationType = System
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> DeleteNotifications(DeleteNotificationRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var notificationIds = request.NotificationIds.Where(id => id > 0).ToList();

            var existingNotifications = await _context.Notifications
                .Where(x => notificationIds.Contains(x.NotificationId) && x.NotificationType == NotificationTypeEnum.System)
                .ToListAsync();

            var errorMessageBuilder = new StringBuilder();

            foreach (var notification in existingNotifications)
            {
                if (notification.IsDeleted == true)
                {
                    errorMessageBuilder.AppendLine("Notification with Id: " + notification.NotificationId + " deleted.");
                }
                else
                {
                    notification.IsDeleted = true;
                    notification.DateUpdated = DateTime.Now;
                    notification.UpdatedBy = userResult.ResultObj;
                }
            }

            if (errorMessageBuilder.Length > 0)
            {
                var errorMessage = errorMessageBuilder.ToString().Trim();
                return new ApiErrorResult<bool>(errorMessage);
            }
            else
            {
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess(nameof(Data.Entities.Notification)) };
            }
        }

        /// <summary>
        /// Feature: Retrieves a paged list of notifications for a specific user.
        /// </summary>
        /// <param name="request">The paging request object.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains an API result with a paged list of notification view models.</returns>
        public async Task<ApiResult<ViewModels.Common.PagedResult<NotificationViewModel>>> GetPagingNotificationsByUserId(PagingRequestBase request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<ViewModels.Common.PagedResult<NotificationViewModel>>();

            var query = from n in _context.Notifications
                        where n.IsDeleted == false &&
                        ((n.NotificationType != NotificationTypeEnum.System && n.AppUserId == userResult.ResultObj) || (n.NotificationType == NotificationTypeEnum.System))
                        join u in _context.Users on n.AppUserId equals u.Id into userJoin
                        from u in userJoin.DefaultIfEmpty()
                        join c in _context.Comics on n.ComicId equals c.ComicId into comicJoin
                        from c in comicJoin.DefaultIfEmpty()
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId into comicDetailsJoin
                        from cd in comicDetailsJoin.DefaultIfEmpty()
                        orderby n.DateCreated descending
                        select new { n, u, c, cd };

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Select(x => new NotificationViewModel()
            {
                NotificationId = x.n.NotificationId,
                NotificationType = x.n.NotificationType.ToString(),
                NotificationPriority = x.n.NotificationPriority.ToString(),
                DateCreated = x.n.DateCreated,
                ComicId = x.c != null ? x.c.ComicId : null,
                ComicName = x.c != null ? x.c.ComicName : null,
                Title = x.n.Title,
                Message = x.n.Message,
                Actions = x.n.Actions,
                ImageURL = x.n.ImageURL != null && x.n.ImageURL.Contains("http") ? x.n.ImageURL : SystemConstants.AppSettings.URLDomainMyHostProduct + "uploads/user-avatar/" + x.n.ImageURL,
                AppUserId = x.n.AppUserId,
                CreatedBy = x.n.CreatedBy,
                UpdatedBy = x.n.UpdatedBy
            }).ToListAsync();

            var pagedResult = new ViewModels.Common.PagedResult<NotificationViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };

            return new ApiSuccessResult<ViewModels.Common.PagedResult<NotificationViewModel>>() { ResultObj = pagedResult, Message = MessageConstants.GetObjectSuccess(nameof(NotificationViewModel)) };
        }

        /// <summary>
        /// Feature: Marks a notification as read.
        /// </summary>
        /// <param name="notificationId">The ID of the notification to mark as read.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains an API result indicating whether the operation was successful.</returns>
        public async Task<ApiResult<bool>> UserIsReadNotification(int notificationId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.NotificationId == notificationId && !x.IsDeleted);

            if (notification is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound(nameof(Data.Entities.Notification)) };

            if (notification.NotificationType == NotificationTypeEnum.System)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AccessDenied };

            if (notification.AppUserId != userResult.ResultObj)
                return new ApiErrorResult<bool>() { Message = MessageConstants.UnableToReadNotification };

            notification.IsRead = true;
            notification.DateUpdated = DateTime.Now;
            notification.UpdatedBy = userResult.ResultObj;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.OperationSuccess(OperationTypeEnum.Update, nameof(Data.Entities.Notification), notificationId) };
        }

        /// <summary>
        /// Roles: admin
        /// Feature: Updates a notification with the specified ID.
        /// </summary>
        /// <param name="request">The request object containing the updated notification data.</param>
        /// <param name="notificationId">The ID of the notification to update.</param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> UpdateNotification(UpdateNotificationRequest request, int notificationId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.NotificationId == notificationId && x.NotificationType == NotificationTypeEnum.System);

            if (notification is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound(nameof(Data.Entities.Notification)) };

            notification.NotificationPriority = request.NotificationPriority;
            notification.Title = request.Title;
            notification.Message = request.Message;
            notification.UpdatedBy = userResult.ResultObj;
            notification.DateUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.OperationSuccess(OperationTypeEnum.Update, nameof(Data.Entities.Notification), notificationId) };
        }

        /// <summary>
        /// Feature: Marks all notifications for the current user as read.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains an API result indicating whether the operation was successful.</returns>
        public async Task<ApiResult<bool>> UserMarkAllNotificationsAsRead()
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var notifications = await _context.Notifications
                .Where(x => x.AppUserId == userResult.ResultObj && !x.IsDeleted && !x.IsRead && x.NotificationType != NotificationTypeEnum.System)
                .ToListAsync();

            notifications.ForEach(n => n.IsRead = true);

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.MarkAllNotificationsAsRead };
        }

        /// <summary>
        /// Feature: Deletes all notifications for the current user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains an API result indicating whether the operation was successful.</returns>
        public async Task<ApiResult<bool>> UserDeleteAllNotifications()
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var notifications = await _context.Notifications
                .Where(x => x.AppUserId == userResult.ResultObj && !x.IsDeleted && x.NotificationType != NotificationTypeEnum.System)
                .ToListAsync();

            notifications.ForEach(n => n.IsDeleted = true);

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.UserDeleteAllNotifications };
        }

        /// <summary>
        /// Feature: Restores a deleted system notification.
        /// </summary>
        /// <param name="notificationId">The ID of the notification to restore.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains an API result indicating whether the operation was successful.</returns>
        public async Task<ApiResult<bool>> RestoreNotification(int notificationId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.NotificationId == notificationId);

            if (notification is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound(nameof(Data.Entities.Notification)) };

            if (notification.CreatedBy != userResult.ResultObj)
                return new ApiErrorResult<bool>() { Message = MessageConstants.UnableToReadNotification };

            notification.IsDeleted = false;
            notification.DateUpdated = DateTime.Now;
            notification.UpdatedBy = userResult.ResultObj;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.OperationSuccess(OperationTypeEnum.Update, nameof(Data.Entities.Notification), notificationId) };
        }

        /// <summary>
        /// Retrieves a paged list of system notifications based on the provided paging request.
        /// </summary>
        /// <param name="request">The paging request containing the sort column, sort direction, search value, and paging information.</param>
        /// <returns>A PagingResult object containing the paged list of NotificationViewModel objects.</returns>
        public async Task<PagingResult<NotificationViewModel>> GetPagingManagement(PagingRequest request)
        {
            var notificationViewModels = await _context.Notifications.Where(x => x.NotificationType == NotificationTypeEnum.System).Select(x => new NotificationViewModel()
            {
                NotificationId = x.NotificationId,
                IsRead = x.IsRead,
                IsDeleted = x.IsDeleted,
                Title = x.Title,
                Message = x.Message,
                DateCreated = x.DateCreated,
                CreatedBy = x.CreatedBy,
                DateUpdated = x.DateUpdated,
                UpdatedBy = x.UpdatedBy,
                NotificationPriority = x.NotificationPriority.ToString(),
                NotificationType = x.NotificationType.ToString(),
                NotificationPriorityId = 11111
            }).ToListAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                notificationViewModels = await _context.Notifications.Where(x => x.NotificationType == NotificationTypeEnum.System).Select(x => new NotificationViewModel()
                {
                    NotificationId = x.NotificationId,
                    IsRead = x.IsRead,
                    IsDeleted = x.IsDeleted,
                    Title = x.Title,
                    Message = x.Message,
                    DateCreated = x.DateCreated,
                    CreatedBy = x.CreatedBy,
                    DateUpdated = x.DateUpdated,
                    UpdatedBy = x.UpdatedBy,
                    NotificationPriority = x.NotificationPriority.ToString(),
                    NotificationType = x.NotificationType.ToString(),
                    NotificationPriorityId = (int)x.NotificationPriority
                }).OrderBy(request.SortColumn + " " + request.SortColumnDirection).ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                notificationViewModels = notificationViewModels.Where(x => x.Title.ToLower().Contains(request.SearchValue.ToLower()) ||
                                                                            x.Message.ToLower().Contains(request.SearchValue.ToLower())).ToList();
            }

            request.RecordsTotal = notificationViewModels.Count();
            var data = notificationViewModels.Skip(request.Skip).Take(request.PageSize).ToList();

            var jsonData = new { draw = request.Draw, recordsFiltered = request.RecordsTotal, recordsTotal = request.RecordsTotal, data = data };

            var result = new PagingResult<NotificationViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = data
            };

            return result;
        }

        /// <summary>
        /// Retrieves a notification based on the notification ID.
        /// </summary>
        /// <param name="notificationId">The ID of the notification.</param>
        /// <returns>An ApiResult object containing the NotificationViewModel.</returns>
        public async Task<ApiResult<NotificationViewModel>> GetNotificationByNotificationId(int notificationId)
        {
            var query = from n in _context.Notifications
                        where n.NotificationType == NotificationTypeEnum.System && n.NotificationId == notificationId
                        join cb in _context.Users on n.CreatedBy equals cb.Id into createdByGroup
                        from cb in createdByGroup.DefaultIfEmpty()
                        join ub in _context.Users on n.UpdatedBy equals ub.Id into updatedByGroup
                        from ub in updatedByGroup.DefaultIfEmpty()
                        select new { n, cb, ub };

            var notificationViewModel = await query.Select(x => new NotificationViewModel()
            {
                NotificationId = x.n.NotificationId,
                Actions = x.n.Actions,
                AppUserId = x.n.AppUserId,
                ComicId = x.n.ComicId,
                CreatedBy = x.n.CreatedBy,
                UpdatedBy = x.n.UpdatedBy,
                DateCreated = x.n.DateCreated,
                DateUpdated = x.n.DateUpdated,
                Title = x.n.Title,
                Message = x.n.Message,
                IsDeleted = x.n.IsDeleted,
                NotificationPriorityId = x.n.NotificationId,
                UserNameUpdatedBy = x.ub.UserName,
                UserNameCreatedBy = x.cb.UserName,
            }).FirstOrDefaultAsync();

            if (notificationViewModel is null)
                return new ApiErrorResult<NotificationViewModel>() { Message = MessageConstants.ObjectNotFound(nameof(Data.Entities.Notification)) };

            return new ApiSuccessResult<NotificationViewModel>() { ResultObj = notificationViewModel, Message = MessageConstants.GetObjectSuccess(nameof(Data.Entities.Notification)) };
        }

        public async Task<ViewModels.Common.PagedResult<NotificationViewModel>> GetPagingNofiticationForAdminAndTeamMembers(PagingRequestBase request)
        {
            var isAdminOrTeamMember = _userContextService.CheckUserRoleAdminOrTeamMember();
            if (!isAdminOrTeamMember.ResultObj)
                return new ViewModels.Common.PagedResult<NotificationViewModel>();

            var query = from n in _context.Notifications
                        where n.NotificationType == NotificationTypeEnum.RequestApproval && !n.IsDeleted && !n.IsRead
                        select n;

            int totalRow = await query.CountAsync();

            var data = await query.OrderByDescending(x => x.DateCreated).Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
              .Select(x => new NotificationViewModel()
              {
                  NotificationId = x.NotificationId,
                  NotificationType = x.NotificationType.ToString(),
                  NotificationPriority = x.NotificationPriority.ToString(),
                  ComicId = x.ComicId,
                  ChapterId = x.ChapterId,
                  DateCreated = x.DateCreated,
                  Title = x.Title,
                  Message = x.Message,
                  Actions = x.Actions,
                  ImageURL = x.ImageURL != null && x.ImageURL.Contains("http") ? x.ImageURL : SystemConstants.AppSettings.URLDomainMyHostProduct + "uploads/user-avatar/" + x.ImageURL,
                  AppUserId = x.AppUserId,
                  CreatedBy = x.CreatedBy,
                  UpdatedBy = x.UpdatedBy
              }).ToListAsync();

            var pagedResult = new ViewModels.Common.PagedResult<NotificationViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };

            return pagedResult;
        }

        public async Task<ViewModels.Common.PagedResult<NotificationViewModel>> GetPagingNofiticationForCreator(PagingRequestBase request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return new ViewModels.Common.PagedResult<NotificationViewModel>();

            var query = from n in _context.Notifications
                        where n.NotificationType == NotificationTypeEnum.ResponseApproval && n.AppUserId == userResult.ResultObj && !n.IsDeleted && !n.IsRead
                        select n;

            int totalRow = await query.CountAsync();

            var data = await query.OrderByDescending(x => x.DateCreated).Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
              .Select(x => new NotificationViewModel()
              {
                  NotificationId = x.NotificationId,
                  NotificationType = x.NotificationType.ToString(),
                  NotificationPriority = x.NotificationPriority.ToString(),
                  DateCreated = x.DateCreated,
                  ComicId = x.ComicId,
                  ChapterId = x.ChapterId,
                  Title = x.Title,
                  Message = x.Message,
                  Actions = x.Actions,
                  ImageURL = x.ImageURL != null && x.ImageURL.Contains("http") ? x.ImageURL : SystemConstants.AppSettings.URLDomainMyHostProduct + "uploads/user-avatar/" + x.ImageURL,
                  AppUserId = x.AppUserId,
                  CreatedBy = x.CreatedBy,
                  UpdatedBy = x.UpdatedBy
              }).ToListAsync();

            var pagedResult = new ViewModels.Common.PagedResult<NotificationViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };

            return pagedResult;
        }
    }
}

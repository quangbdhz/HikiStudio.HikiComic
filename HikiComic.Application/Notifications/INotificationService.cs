using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Notifications;
using HikiComic.ViewModels.Notifications.NotificationsDataRequest;

namespace HikiComic.Application.Notifications
{
    public interface INotificationService
    {
        #region for user
        public Task<ApiResult<PagedResult<NotificationViewModel>>> GetPagingNotificationsByUserId(PagingRequestBase request);

        public Task<ApiResult<bool>> UserIsReadNotification(int notificationId);

        public Task<ApiResult<bool>> UserMarkAllNotificationsAsRead();

        public Task<ApiResult<bool>> UserDeleteAllNotifications();
        #endregion


        #region for admin & user
        public Task<ApiResult<bool>> CreateNotification(CreateNotificationRequest request, NotificationTypeEnum notificationType);
        #endregion

        #region for creator
        public Task<PagedResult<NotificationViewModel>> GetPagingNofiticationForCreator(PagingRequestBase request);

        #endregion

        #region for admin
        public Task<PagedResult<NotificationViewModel>> GetPagingNofiticationForAdminAndTeamMembers(PagingRequestBase request);

        public Task<PagingResult<NotificationViewModel>> GetPagingManagement(PagingRequest request);

        public Task<ApiResult<NotificationViewModel>> GetNotificationByNotificationId(int notificationId);

        public Task<ApiResult<bool>> UpdateNotification(UpdateNotificationRequest request, int notificationId);

        public Task<ApiResult<bool>> DeleteNotification(int notificationId);

        public Task<ApiResult<bool>> CreateNotifications(CreateNotificationRequest request, NotificationTypeEnum notificationType);

        public Task<ApiResult<bool>> DeleteNotifications(DeleteNotificationRequest request);

        public Task<ApiResult<bool>> RestoreNotification(int notificationId);
        #endregion
    }
}

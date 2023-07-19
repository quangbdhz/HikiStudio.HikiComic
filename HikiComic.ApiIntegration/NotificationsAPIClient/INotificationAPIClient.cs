using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Notifications;
using HikiComic.ViewModels.Notifications.NotificationsDataRequest;

namespace HikiComic.ApiIntegration.NotificationsAPIClient
{
    public interface INotificationAPIClient
    {
        public Task<PagingResult<NotificationViewModel>> GetPagingManagement(PagingRequest request);

        public Task<PagedResult<NotificationViewModel>> GetPagingNofiticationForCreator(PagingRequestBase request);

        public Task<PagedResult<NotificationViewModel>> GetPagingNofiticationForAdminAndTeamMembers(PagingRequestBase request);


        public Task<ApiResult<NotificationViewModel>> GetNotificationByNotificationId(int notificationId);

        public Task<ApiResult<bool>> UpdateNotification(UpdateNotificationRequest request, int notificationId);

        public Task<ApiResult<bool>> DeleteNotification(int notificationId);

        public Task<ApiResult<bool>> CreateNotification(CreateNotificationRequest request);

        public Task<ApiResult<bool>> DeleteNotifications(DeleteNotificationRequest request);

        public Task<ApiResult<bool>> RestoreNotification(int notificationId);
    }
}

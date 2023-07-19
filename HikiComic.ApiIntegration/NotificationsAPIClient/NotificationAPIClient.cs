using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Artists;
using HikiComic.ViewModels.Artists.ArtistDataRequest;
using HikiComic.ViewModels.Comics;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Notifications;
using HikiComic.ViewModels.Notifications.NotificationsDataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.NotificationsAPIClient
{
    public class NotificationAPIClient : BaseAPI, INotificationAPIClient
    {
        public NotificationAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) 
            : base(httpClientFactory, httpContextAccessor, configuration)
        {

        }

        public async Task<ApiResult<bool>> CreateNotification(CreateNotificationRequest request)
        {
            return await PostAsync<ApiResult<bool>, CreateNotificationRequest>(request, "/api/notifications/create-notification-system");
        }

        public async Task<ApiResult<bool>> DeleteNotification(int notificationId)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/notifications/delete/{notificationId}");
        }

        public async Task<ApiResult<bool>> DeleteNotifications(DeleteNotificationRequest request)
        {
            return await PostAsync<ApiResult<bool>, DeleteNotificationRequest>(request, $"/api/notifications/delete-multiple");
        }

        public async Task<ApiResult<NotificationViewModel>> GetNotificationByNotificationId(int notificationId)
        {
            return await GetAsync<ApiResult<NotificationViewModel>>($"/api/notifications/get-notification-by-notification-id/{notificationId}");
        }

        public async Task<PagingResult<NotificationViewModel>> GetPagingManagement(PagingRequest request)
        {
            return await PostAsync<PagingResult<NotificationViewModel>, PagingRequest>(request, $"/api/notifications/paging-management");
        }

        public async Task<PagedResult<NotificationViewModel>> GetPagingNofiticationForAdminAndTeamMembers(PagingRequestBase request)
        {
            return await GetAsync<PagedResult<NotificationViewModel>>($"/api/notifications/paging-notification-for-admin-and-team-members?pageindex={request.PageIndex}" +
                $"&pagesize={request.PageSize}");
        }

        public async Task<PagedResult<NotificationViewModel>> GetPagingNofiticationForCreator(PagingRequestBase request)
        {
            return await GetAsync<PagedResult<NotificationViewModel>>($"/api/notifications/paging-notification-for-creator?pageindex={request.PageIndex}" +
                $"&pagesize={request.PageSize}");
        }

        public async Task<ApiResult<bool>> RestoreNotification(int notificationId)
        {
            return await PostAsync<ApiResult<bool>, int>(notificationId, $"/api/notifications/restore");
        }

        public async Task<ApiResult<bool>> UpdateNotification(UpdateNotificationRequest request, int notificationId)
        {
            return await PutAsync<ApiResult<bool>, UpdateNotificationRequest>(request, $"/api/notifications/update/{notificationId}");
        }
    }
}

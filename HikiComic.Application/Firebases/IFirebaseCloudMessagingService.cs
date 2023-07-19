using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Notifications.FirebaseCloudMessaging;

namespace HikiComic.Application.Firebases
{
    public interface IFirebaseCloudMessagingService
    {
        public Task<ApiResult<bool>> SendFCMNotification(FCMNotificationRequest request);
    }
}

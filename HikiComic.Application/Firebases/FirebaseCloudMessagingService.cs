using CorePush.Google;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Notifications.FirebaseCloudMessaging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using static HikiComic.ViewModels.Notifications.FirebaseCloudMessaging.FCMGoogleNotificationRequest;

namespace HikiComic.Application.Firebases
{
    public class FirebaseCloudMessagingService : IFirebaseCloudMessagingService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly FCMNotificationSetting _fCMNotificationSetting;

        public FirebaseCloudMessagingService(IOptions<FCMNotificationSetting> settings, IHttpClientFactory httpClientFactory)
        {
            _fCMNotificationSetting = settings.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<bool>> SendFCMNotification(FCMNotificationRequest request)
        {
            try
            {
                if (request.IsAndroiodDevice)
                {
                    FcmSettings settings = new FcmSettings()
                    {
                        SenderId = _fCMNotificationSetting.SenderId,
                        ServerKey = _fCMNotificationSetting.ServerKey
                    };

                    var httpClient = _httpClientFactory.CreateClient();

                    string authorizationKey = string.Format("keyy={0}", settings.ServerKey);
                    string deviceToken = request.FCMDeviceToken;

                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorizationKey);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    DataPayload dataPayload = new DataPayload();
                    dataPayload.Title = request.Title;
                    dataPayload.Body = request.Body;

                    FCMGoogleNotificationRequest notification = new FCMGoogleNotificationRequest();
                    notification.Data = dataPayload;
                    notification.Notification = dataPayload;

                    var fcm = new FcmSender(settings, httpClient);
                    var fcmSendResponse = await fcm.SendAsync(deviceToken, notification);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Status Send: " + fcmSendResponse.IsSuccess() + " | TokenDevice: " + request.FCMDeviceToken);
                    Console.ResetColor();

                    if (!fcmSendResponse.IsSuccess())
                        return new ApiErrorResult<bool>() { Message = "The notification was not sent successfully." };

                    return new ApiSuccessResult<bool>() { Message = "Notification sent not successfully." };
                }
                else
                {
                    /* Code here for APN Sender (iOS Device) */
                    //var apn = new ApnSender(apnSettings, httpClient);
                    //await apn.SendAsync(notification, deviceToken);
                }

                return new ApiErrorResult<bool>() { Message = "Unprocessed sending notifications to IOS." };
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>() { Message = ex.Message };
            }
        }
    }
}

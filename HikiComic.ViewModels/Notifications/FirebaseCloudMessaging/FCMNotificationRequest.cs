namespace HikiComic.ViewModels.Notifications.FirebaseCloudMessaging
{
    public class FCMNotificationRequest
    {
        public string FCMDeviceToken { get; set; }

        public bool IsAndroiodDevice { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}

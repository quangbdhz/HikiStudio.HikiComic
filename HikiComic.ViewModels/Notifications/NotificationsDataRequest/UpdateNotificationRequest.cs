using HikiComic.Utilities.Enums;

namespace HikiComic.ViewModels.Notifications.NotificationsDataRequest
{
    public class UpdateNotificationRequest
    {
        public string Title { get; set; } = null!;

        public string Message { get; set; } = null!;

        public NotificationPriorityEnum NotificationPriority { get; set; }
    }
}

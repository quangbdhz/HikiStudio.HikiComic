using HikiComic.Utilities.Enums;

namespace HikiComic.ViewModels.Notifications.NotificationsDataRequest
{
    public class CreateNotificationRequest
    {
        public Guid? AppUserId { get; set; }

        public int? ComicId { get; set; }

        public int? ChapterId { get; set; }

        public string Title { get; set; } = null!;

        public string Message { get; set; } = null!;

        public bool IsRead { get; set; }

        public string? Actions { get; set; } = null!;

        public string? ImageURL { get; set; } = null!;

        public NotificationPriorityEnum NotificationPriority { get; set; }

        public Guid? CreatedBy { get; set; }
    }
}

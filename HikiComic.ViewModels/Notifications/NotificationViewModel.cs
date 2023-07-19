using HikiComic.ViewModels.Base;

namespace HikiComic.ViewModels.Notifications
{
    public class NotificationViewModel : BaseViewModel<Guid?>
    {
        public int NotificationId { get; set; }

        public Guid? AppUserId { get; set; }

        public int? ComicId { get; set; }

        public int? ChapterId { get; set; }

        public string? ComicName { get; set; }

        public string Title { get; set; } = null!;

        public string NotificationType { get; set; }

        public string Message { get; set; } = null!;

        public bool IsRead { get; set; }

        public string Actions { get; set; } = null!;

        public string ImageURL { get; set; } = null!;

        public string NotificationPriority { get; set; }

        public int NotificationPriorityId { get; set; }

    }
}

using HikiComic.Data.Entities.Base.Entities;
using HikiComic.Utilities.Enums;

namespace HikiComic.Data.Entities
{
    public class Notification : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int NotificationId { get; set; }

        public Guid? AppUserId { get; set; }

        public int? ComicId { get; set; }

        public int? ChapterId { get; set; }

        public string Title { get; set; } = null!;

        public NotificationTypeEnum NotificationType { get; set; }

        public string Message { get; set; } = null!;

        public bool IsRead { get; set; }

        public string Actions { get; set; } = null!;

        public string ImageURL { get; set; } = null!;

        public NotificationPriorityEnum NotificationPriority { get; set; }



        public AppUser? AppUser { get; set; }

        public Comic? Comic { get; set; }

        public Chapter? Chapter { get; set; }
    }
}

using HikiComic.Data.Entities.Base.Entities;
using HikiComic.Utilities.Enums;

namespace HikiComic.Data.Entities
{
    public class Chapter : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int ChapterId { get; set; }

        public int ComicDetailId { get; set; }


        public string ChapterName { get; set; } = null!;

        public int SerialChapterOfComic { get; set; }

        public int ViewCount { get; set; }


        public string ComicSEOAlias { get; set; } = null!;

        public string ChapterSEOAlias { get; set; } = null!;


        public ApprovalStatusEnum ApprovalStatus { get; set; }

        public Guid? UserIdApproved { get; set; }

        public DateTime? DateApproved { get; set; }


        public ComicDetail ComicDetail { get; set; } = null!;


        public List<UserComicReadingHistory> UserComicReadingHistories { get; set; }

        public List<ChapterImageURL> ChapterImageURLs { get; set; }

        public List<UserComicPurchase> UserComicPurchases { get; set; }

        public List<Notification> Notifications { get; set; }
    }
}

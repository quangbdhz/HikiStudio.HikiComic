using HikiComic.Data.Entities.Base.Entities;
using HikiComic.Utilities.Enums;

namespace HikiComic.Data.Entities
{
    public class Comic : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int ComicId { get; set; }


        public string ComicName { get; set; } = null!;

        public string? Alternative { get; set; }

        public string ComicCoverImageURL { get; set; } = null!;


        public int ViewCount { get; set; }

        public int CountLike { get; set; }

        public int CountFollow { get; set; }

        public int CountRating { get; set; }

        public double Rating { get; set; }


        public int? NewChapterId { get; set; }


        public ApprovalStatusEnum ApprovalStatus { get; set; }

        public Guid? UserIdApproved { get; set; }

        public DateTime? DateApproved { get; set; }


        public ComicDetail ComicDetail { get; set; } = null!;

        public List<UserComicReadingHistory> UserComicReadingHistories { get; set; }

        public List<UserComicFollowing> UserComicFollowings { get; set; }

        public List<Comment> Comments { get; set; }

        public List<UserComicLike> UserComicLikes { get; set; }

        public List<UserComicRating> UserComicRatings { get; set; }

        public List<UserComicPurchase> UserComicPurchases { get; set; }

        public List<Notification> Notifications { get; set; }
    }
}

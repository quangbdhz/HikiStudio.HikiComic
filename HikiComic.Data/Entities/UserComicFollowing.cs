namespace HikiComic.Data.Entities
{
    public class UserComicFollowing
    {
        public int UserComicFollowingId { get; set; }

        public Guid AppUserId { get; set; }

        public int ComicId { get; set; }


        public DateTime DateFollow { get; set; }


        public AppUser? AppUser { get; set; }

        public Comic? Comic { get; set; }
    }
}

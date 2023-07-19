namespace HikiComic.Data.Entities
{
    public class UserComicLike
    {
        public int UserComicLikeId { get; set; }

        public Guid AppUserId { get; set; }

        public int ComicId { get; set; }


        public bool Liked { get; set; }

        public DateTime DateLiked { get; set; }


        public AppUser AppUser { get; set; }

        public Comic Comic { get; set; }
    }
}

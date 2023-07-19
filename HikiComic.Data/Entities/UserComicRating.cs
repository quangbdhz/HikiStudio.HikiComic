namespace HikiComic.Data.Entities
{
    public class UserComicRating
    {
        public int UserComicRatingId { get; set; }

        public Guid AppUserId { get; set; }

        public int ComicId { get; set; }


        public double Rating { get; set; }

        public DateTime DateRating { get; set; }


        public AppUser AppUser { get; set; }

        public Comic Comic { get; set; }

    }
}

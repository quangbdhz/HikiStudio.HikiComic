namespace HikiComic.Data.Entities
{
    public class UserComicReadingHistory
    {
        public int UserComicReadingHistoryId { get; set; }

        public Guid AppUserId { get; set; }

        public int ComicId { get; set; }

        public int ChapterId { get; set; }


        public DateTime DateRead { get; set; }


        public AppUser AppUser { get; set; }

        public Comic Comic { get; set; }

        public Chapter Chapter { get; set; }
    }
}

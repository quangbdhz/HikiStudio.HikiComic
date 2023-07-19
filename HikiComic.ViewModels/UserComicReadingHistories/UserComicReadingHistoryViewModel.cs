namespace HikiComic.ViewModels.UserComicReadingHistories
{
    public class UserComicReadingHistoryViewModel
    {
        public int UserComicReadingHistoryId { get; set; }

        public int ComicId { get; set; }

        public string ComicName { get; set; } = null!;

        public int ViewCount { get; set; }

        public string ComicCoverImageURL { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string ComicSEOAlias { get; set; } = null!;

        public string ChapterSEOAlias { get; set; } = null!;

        public double Rating { get; set; }

        public string ChapterName { get; set; } = null!;

        public DateTime DateRead { get; set; }
    }
}

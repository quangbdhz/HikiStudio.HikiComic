namespace HikiComic.ViewModels.UserComicReadingHistories
{
    public class ComicReadingHistoryViewModel
    {
        public int ComicId { get; set; }

        public int ChapterId { get; set; }

        public Guid UserId { get; set; }
    }
}

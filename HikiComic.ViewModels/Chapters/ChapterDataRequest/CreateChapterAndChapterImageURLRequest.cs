namespace HikiComic.ViewModels.Chapters.ChapterDataRequest
{
    public class CreateChapterAndChapterImageURLRequest
    {
        public string ChapterName { get; set; } = null!;

        public string? StringChapterImageURLs { get; set; }

        public int? SerialChapterOfComic { get; set; }

        public DateTime? DateCreated { get; set; }

        public List<string>? ChapterImageURLs { get; set; }
    }
}

namespace HikiComic.ViewModels.Chapters.ChapterDataRequest
{
    public class UpdateChapterRequest
    {
        public string ChapterName { get; set; } = null!;

        public string? StringChapterImageURLs { get; set; }

        public List<string>? ChapterImageURLs { get; set; }
    }
}

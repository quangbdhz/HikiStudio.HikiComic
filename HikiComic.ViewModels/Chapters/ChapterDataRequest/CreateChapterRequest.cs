namespace HikiComic.ViewModels.Chapters.ChapterDataRequest
{
    public class CreateChapterRequest
    {

        public int ComicDetailId { get; set; }

        public string ChapterName { get; set; } = null!;

        public int SerialChapterOfComic { get; set; }
    }
}

namespace HikiComic.ViewModels.ChapterImageURLs.ChapterImageURLDataRequest
{
    public class CreateChapterImageURLRequest
    {
        public int ChapterId { get; set; }

        public string ImageURL { get; set; } = null!;

        public int SerialImageURLOfChapter { get; set; }


    }
}

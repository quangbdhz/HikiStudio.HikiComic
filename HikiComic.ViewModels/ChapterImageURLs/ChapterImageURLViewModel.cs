using HikiComic.ViewModels.Base;
using HikiComic.ViewModels.Chapters;

namespace HikiComic.ViewModels.ChapterImageURLs
{
    public class ChapterImageURLViewModel : BaseViewModel<Guid>
    {
        public int ComicId { get; set; }

        public int ChapterId { get; set; }


        public bool IsFollow { get; set; }


        public string ComicName { get; set; } = null!;

        public string ChapterName { get; set; } = null!;


        public IList<string> ChapterImageURLs { get; set; }


        public string ComicSEOAlias { get; set; } = null!;


        public string? NextChapterSEOAlias { get; set; }

        public string? PreviousChapterSEOAlias { get; set; }


        public IList<ChapterViewModel> Chapters { get; set; }
    }
}

using HikiComic.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace HikiComic.ViewModels.Chapters
{
    public class ChapterDetailViewModel : BaseViewModel<Guid>
    {
        public int ChapterId { get; set; }

        public int ComicDetailId { get; set; }

        public string ChapterName { get; set; } = null!;

        public int SerialChapterOfComic { get; set; }

        public int ViewCount { get; set; }

        public string ComicSEOAlias { get; set; } = null!;

        public string ChapterSEOAlias { get; set; } = null!;

        public List<string> ChapterImageURLs { get; set; }

        public string? StringChapterImageURLs { get; set; }
    }
}

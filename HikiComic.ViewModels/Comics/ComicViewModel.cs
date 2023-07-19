using HikiComic.ViewModels.Base;
using HikiComic.ViewModels.Chapters;
using System.ComponentModel.DataAnnotations;

namespace HikiComic.ViewModels.Comics
{
    public class ComicViewModel : BaseViewModel<Guid>
    {
        public int ComicId { get; set; }

        public string ComicName { get; set; } = null!;

        public string? Alternative { get; set; }


        public int ViewCount { get; set; }

        public string ComicCoverImageURL { get; set; } = null!;


        public int? NewChapterId { get; set; }

        public string ComicSEOAlias { get; set; } = null!;

        public double Rating { get; set; }

        public string Status { get; set; }

        public int? ReadChapterId { get; set; }

        
        public List<ChapterViewModel> Chapters { get; set; } = new List<ChapterViewModel>();
    }
}

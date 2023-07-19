using HikiComic.ViewModels.Artists;
using HikiComic.ViewModels.Authors;
using HikiComic.ViewModels.Base;
using HikiComic.ViewModels.Genres;
using System.ComponentModel.DataAnnotations;

namespace HikiComic.ViewModels.ComicDetails
{
    public class ComicDetailViewModel : BaseViewModel<Guid>
    {
        public int ComicDetailId { get; set; }

        public int ComicId { get; set; }


        public string ComicName { get; set; } = null!;

        public string? Alternative { get; set; }


        public int ViewCount { get; set; }

        public string ComicCoverImageURL { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public int? NewChapterId { get; set; }


        public double Rating { get; set; }

        public int CountRating { get; set; }

        public int CountFollow { get; set; }


        public string? ComicSEOSummary { get; set; }

        public string? ComicSEOTitle { get; set; }

        public string ComicSEOAlias { get; set; } = null!;


        public string Status { get; set; } = null!;

        public bool IsFollow { get; set; }

        public string CreatorName { get; set; }

        public List<ArtistViewModel> Artists { get; set; } = new List<ArtistViewModel>();

        public List<AuthorViewModel> Authors { get; set; } = new List<AuthorViewModel>();

        public List<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
    }
}

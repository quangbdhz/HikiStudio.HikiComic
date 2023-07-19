using HikiComic.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace HikiComic.ViewModels.Genres
{
    public class GenreViewModel : BaseViewModel<Guid>
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; } = null!;

        public int? GenreParentId { get; set; }

        public bool IsShowHome { get; set; }

        public string? Summary { get; set; }

        public string? GenreSEOSummary { get; set; }

        public string? GenreSEOTitle { get; set; }

        public string? GenreSEOAlias { get; set; }

        public string? GenreImageURL { get; set; }

    }
}

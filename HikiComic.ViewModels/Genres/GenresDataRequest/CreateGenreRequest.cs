namespace HikiComic.ViewModels.Genres.GenresDataRequest
{
    public class CreateGenreRequest
    {
        public int? GenreParentId { get; set; }

        public string GenreName { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public string? GenreSEOSummary { get; set; }

        public string? GenreSEOTitle { get; set; }

        public bool IsShowHome { get; set; }

        public string GenreImageURL { get; set; } = null!;
    }
}

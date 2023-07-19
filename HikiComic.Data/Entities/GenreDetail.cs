using HikiComic.Data.Entities.Base.Entities;

namespace HikiComic.Data.Entities
{
    public class GenreDetail : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int GenreDetailId { get; set; }

        public int GenreId { get; set; }


        public string GenreName { get; set; } = null!;

        public string Summary { get; set; } = null!;


        public string? GenreSEOSummary { get; set; }

        public string? GenreSEOTitle { get; set; }

        public string GenreSEOAlias { get; set; } = null!;


        public Genre Genre { get; set; }
    }
}

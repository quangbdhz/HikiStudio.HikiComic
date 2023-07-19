using HikiComic.Data.Entities.Base.Entities;

namespace HikiComic.Data.Entities
{
    public class Artist : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int ArtistId { get; set; }


        public string ArtistName { get; set; } = null!;

        public string? Alternative { get; set; }

        public string Summary { get; set; } = null!;


        public string? ArtistSEOSummary { get; set; }

        public string? ArtistSEOTitle { get; set; }

        public string ArtistSEOAlias { get; set; } = null!;


        public List<ArtistInComicDetail> ArtistInComicDetails { get; set; }
    }
}

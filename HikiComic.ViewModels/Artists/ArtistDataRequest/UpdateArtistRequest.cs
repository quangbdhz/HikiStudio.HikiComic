namespace HikiComic.ViewModels.Artists.ArtistDataRequest
{
    public class UpdateArtistRequest
    {
        public string ArtistName { get; set; } = null!;

        public string? Alternative { get; set; }

        public string Summary { get; set; } = null!;

        public string? ArtistSEOSummary { get; set; }

        public string? ArtistSEOTitle { get; set; }
    }
}

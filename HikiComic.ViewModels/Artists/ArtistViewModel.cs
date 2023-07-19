using HikiComic.ViewModels.Base;

namespace HikiComic.ViewModels.Artists
{
    public class ArtistViewModel : BaseViewModel<Guid>
    {
        public int ArtistId { get; set; }


        public string ArtistName { get; set; } = null!;

        public string? Alternative { get; set; }

        public string Summary { get; set; } = null!;


        public string? ArtistSEOSummary { get; set; }

        public string? ArtistSEOTitle { get; set; }

        public string ArtistSEOAlias { get; set; } = null!;
    }
}

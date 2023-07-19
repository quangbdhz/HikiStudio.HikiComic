namespace HikiComic.ViewModels.Comics.ComicDataRequest
{
    public class UpdateComicRequest
    {
        public string ComicName { get; set; } = null!;

        public string? Alternative { get; set; }

        public string ComicCoverImageURL { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public string? ComicSEOSummary { get; set; }

        public string? ComicSEOTitle { get; set; }

        public int StatusId { get; set; }

        public List<int>? Artists { get; set; } = new List<int>();

        public List<int>? Authors { get; set; } = new List<int>();

        public List<int>? Genres { get; set; } = new List<int>();

    }
}

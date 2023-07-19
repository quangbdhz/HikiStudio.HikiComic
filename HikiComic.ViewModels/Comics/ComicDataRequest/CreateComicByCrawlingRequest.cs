namespace HikiComic.ViewModels.Comics.ComicDataRequest
{
    public class CreateComicByCrawlingRequest
    {
        public string ComicName { get; set; } = null!;

        public string? Alternative { get; set; }

        public string ComicCoverImageURL { get; set; } = null!;

        public string ComicDetailCoverImageURL { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public List<string>? Artists { get; set; } = new List<string>();

        public List<string>? Authors { get; set; } = new List<string>();

        public List<string>? Genres { get; set; } = new List<string>();
    }
}

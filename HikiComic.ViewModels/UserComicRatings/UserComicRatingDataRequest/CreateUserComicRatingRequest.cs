namespace HikiComic.ViewModels.UserComicRatings.UserComicRatingDataRequest
{
    public class CreateUserComicRatingRequest
    {
        public int? ComicId { get; set; }

        public string? ComicSEOAlias { get; set; }

        public double Rating { get; set; }
    }
}

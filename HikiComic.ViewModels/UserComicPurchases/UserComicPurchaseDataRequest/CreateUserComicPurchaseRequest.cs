namespace HikiComic.ViewModels.UserComicPurchases.UserComicPurchaseDataRequest
{
    public class CreateUserComicPurchaseRequest
    {
        public string ComicSEOAlias { get; set; }

        public string ChapterSEOAlias { get; set; }

        public string? MoreInfo { get; set; }
    }
}

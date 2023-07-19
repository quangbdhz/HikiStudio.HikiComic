namespace HikiComic.ViewModels.UserComicPurchases
{
    public class UserComicPurchaseViewModel
    {
        public int UserComicPurchaseId { get; set; }

        public int UserCoinUsageHistoryId { get; set; }

        public double UsageAmount { get; set; }

        public int ComicId { get; set; }

        public string ComicSEOAlias { get; set; }

        public string ComicName { get; set; }

        public string ChapterSEOAlias { get; set; }

        public int ChapterId { get; set; }

        public string ChapterName { get; set; }

        public string? MoreInfo { get; set; }
    }
}

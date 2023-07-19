using HikiComic.Data.Entities.Base.Entities;

namespace HikiComic.Data.Entities
{
    public class UserComicPurchase : EntitySoftDelete
    {
        public int UserComicPurchaseId { get; set; }

        public int UserCoinUsageHistoryId { get; set; }

        public int ComicId { get; set; }

        public int ChapterId { get; set; }

        public string? MoreInfo { get; set; }


        public UserCoinUsageHistory UserCoinUsageHistory { get; set; }

        public Comic Comic { get; set; }

        public Chapter Chapter { get; set; }
    }
}

using HikiComic.Data.Entities.Base.Entities;
using HikiComic.Utilities.Enums;

namespace HikiComic.Data.Entities
{
    public class UserCoinUsageHistory : EntitySoftDeletableWithCreatedDate
    {
        public int UserCoinUsageHistoryId { get; set; }

        public int AccountId { get; set; }


        public double UsageAmount { get; set; }

        public UsageMethodEnum UsageMethodId { get; set; }

        public UsageStatusEnum UsageStatusId { get; set; }


        public Account Account { get; set; }

        public UserComicPurchase UserComicPurchase { get; set; }
    }
}

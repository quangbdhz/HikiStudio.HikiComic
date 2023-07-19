namespace HikiComic.ViewModels.UserCoinUsageHistories
{
    public class UserCoinUsageHistoryViewModel
    {
        public int UserCoinUsageHistoryId { get; set; }

        public int AccountId { get; set; }

        public string? AccountName { get; set; }

        public double UsageAmount { get; set; }

        public string UsageMethodName { get; set; }

        public string UsageStatusName { get; set; }

        public DateTime DateCreated { get; set; }
    }
}

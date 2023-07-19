using HikiComic.Utilities.Enums;

namespace HikiComic.ViewModels.UserCoinDepositHistories.UserCoinDepositHistoryDataRequest
{
    public class CreateUserCoinDepositHistoryRequest
    {
        public string Currency { get; set; }

        public double OriginalAmount { get; set; }

        public DepositMethodEnum DepositMethod { get; set; }

        public string TransactionId { get; set; }

        public DepositStatusEnum DepositStatus { get; set; }

        public DateTime DepositCreateTime { get; set; }

        public DateTime DepositUpdateTime { get; set; }

        public string? Remarks { get; set; }
    }
}

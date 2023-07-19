using HikiComic.Utilities.Enums;

namespace HikiComic.ViewModels.UserCoinDepositHistories
{
    public class UserCoinDepositHistoryViewModel
    {
        public int UserCoinDepositHistoryId { get; set; }

        public string TransactionId { get; set; }

        public int AccountId { get; set; }


        public string? AccountName { get; set; }


        public int Coins { get; set; }

        public double OriginalAmount { get; set; }

        public string OriginalCurrency { get; set; }

        public double DepositAmount { get; set; }

        public string ConvertCurrency { get; set; }

        public string ExchangeRate { get; set; }


        public DepositMethodEnum DepositMethodId { get; set; }

        public DepositStatusEnum DepositStatusId { get; set; }


        public string DepositMethodName { get; set; }

        public string DepositStatusName { get; set; }


        public DateTime DepositCreateTime { get; set; }

        public DateTime? DepositUpdateTime { get; set; }


        public string? Remarks { get; set; }

        public DateTime DateCreated { get; set; }
    }
}

using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.UserComicPurchases.UserComicPurchaseDataRequest;

namespace HikiComic.ViewModels.UserCoinUsageHistories.UserCoinUsageHistoryDataRequest
{
    public class CreateUserCoinUsageHistoryRequest
    {
        public UsageMethodEnum UsageMethod { get; set; }

        public UsageStatusEnum UsageStatus { get; set; }

        public CreateUserComicPurchaseRequest? CreateUserComicPurchaseRequest { get; set; } 
    }
}

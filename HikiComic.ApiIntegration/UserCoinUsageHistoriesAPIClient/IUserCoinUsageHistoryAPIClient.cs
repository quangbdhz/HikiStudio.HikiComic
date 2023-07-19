using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserCoinUsageHistories;

namespace HikiComic.ApiIntegration.UserCoinUsageHistoriesAPIClient
{
    public interface IUserCoinUsageHistoryAPIClient
    {
        Task<PagingResult<UserCoinUsageHistoryViewModel>> GetUserCoinUsageHistoriesPagingManagement(PagingRequest request, Guid userId);

        Task<ApiResult<List<UserCoinUsageHistoryViewModel>>> GetUserCoinUsageHistories(Guid userId);

        Task<ApiResult<UserCoinUsageHistoryViewModel>> GetUserCoinUsageHistoryWithUserCoinUsageHistoryId(int userCoinUsageHistoryId);
    }
}

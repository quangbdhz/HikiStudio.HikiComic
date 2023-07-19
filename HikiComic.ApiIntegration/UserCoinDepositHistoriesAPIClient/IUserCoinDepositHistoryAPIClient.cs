using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserCoinDepositHistories;
using HikiComic.ViewModels.UserCoinDepositHistories.UserCoinDepositHistoryDataRequest;

namespace HikiComic.ApiIntegration.UserCoinDepositHistoriesAPIClient
{
    public interface IUserCoinDepositHistoryAPIClient
    {
        Task<PagingResult<UserCoinDepositHistoryViewModel>> GetUserCoinDepositHistoriesPagingManagement(PagingRequest request, Guid userId);

        Task<ApiResult<UserCoinDepositHistoryViewModel>> GetUserCoinDepositHistoryWithUserCoinDepositHistoryId(int userCoinDepositHistoryId);

        Task<ApiResult<bool>> CheckAndChangeDepositStatus(ChangeDepositStatusRequest request);
    }
}

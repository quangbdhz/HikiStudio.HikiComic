using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserCoinUsageHistories;
using HikiComic.ViewModels.UserCoinUsageHistories.UserCoinUsageHistoryDataRequest;

namespace HikiComic.Application.UserCoinUsageHistories
{
    public interface IUserCoinUsageHistoryService
    {
        Task<ApiResult<List<UserCoinUsageHistoryViewModel>>> GetUserCoinUsageHistories(Guid userId);

        Task<PagingResult<UserCoinUsageHistoryViewModel>> GetUserCoinUsageHistoriesPagingManagement(PagingRequest request, Guid userId);

        Task<ApiResult<UserCoinUsageHistoryViewModel>> GetUserCoinUsageHistoryWithUserCoinUsageHistoryId(int userCoinUsageHistoryId);

        Task<ApiResult<bool>> CreateUserCoinUsageHistory(CreateUserCoinUsageHistoryRequest request, Guid userId);

        Task<ApiResult<bool>> DeleteUserCoinUsageHistory(int userCoinUsageHistoryId, Guid userId);

        Task<ApiResult<bool>> DeleteAllUserCoinUsageHistories(Guid userId);
    }
}

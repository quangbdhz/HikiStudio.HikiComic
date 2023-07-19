using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserCoinDepositHistories;
using HikiComic.ViewModels.UserCoinDepositHistories.UserCoinDepositHistoryDataRequest;

namespace HikiComic.Application.UserCoinDepositHistories
{
    public interface IUserCoinDepositHistoryService
    {
        Task<PagingResult<UserCoinDepositHistoryViewModel>> GetUserCoinDepositHistoriesPagingManagement(PagingRequest request, Guid userId);

        Task<ApiResult<List<UserCoinDepositHistoryViewModel>>> GetUserCoinDepositHistories(Guid userId);

        Task<ApiResult<UserCoinDepositHistoryViewModel>> GetUserCoinDepositHistoryWithUserCoinDepositHistoryId(int userCoinDepositHistoryId);
        
        Task<ApiResult<bool>> CheckAndChangeDepositStatus(ChangeDepositStatusRequest request);

        Task<ApiResult<bool>> CreateUserCoinDepositHistory(CreateUserCoinDepositHistoryRequest request, Guid userId);

        Task<ApiResult<bool>> DeleteUserCoinDepositHistory(int userCoinDepositHistoryId, Guid userId);

        Task<ApiResult<bool>> DeleteAllUserCoinDepositHistories(Guid userId);
    }
}

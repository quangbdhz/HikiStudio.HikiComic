using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserCoinDepositHistories;
using HikiComic.ViewModels.UserCoinDepositHistories.UserCoinDepositHistoryDataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.UserCoinDepositHistoriesAPIClient
{
    public class UserCoinDepositHistoryAPIClient : BaseAPI, IUserCoinDepositHistoryAPIClient
    {
        public UserCoinDepositHistoryAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) 
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<bool>> CheckAndChangeDepositStatus(ChangeDepositStatusRequest request)
        {
            return await PostAsync<ApiResult<bool>, ChangeDepositStatusRequest>(request, "/api/user-coin-deposit-histories/check-and-change-deposit-status");
        }

        public async Task<PagingResult<UserCoinDepositHistoryViewModel>> GetUserCoinDepositHistoriesPagingManagement(PagingRequest request, Guid userId)
        {
            return await PostAsync<PagingResult<UserCoinDepositHistoryViewModel>, PagingRequest>(request, $"/api/user-coin-deposit-histories/get-user-coin-deposit-histories-with-user-id-paging-management/{userId}");
        }

        public async Task<ApiResult<UserCoinDepositHistoryViewModel>> GetUserCoinDepositHistoryWithUserCoinDepositHistoryId(int userCoinDepositHistoryId)
        {
            return await GetAsync<ApiResult<UserCoinDepositHistoryViewModel>>($"/api/user-coin-deposit-histories/get-user-coin-deposit-history-with-user-coin-deposit-history-id/{userCoinDepositHistoryId}");
        }
    }
}

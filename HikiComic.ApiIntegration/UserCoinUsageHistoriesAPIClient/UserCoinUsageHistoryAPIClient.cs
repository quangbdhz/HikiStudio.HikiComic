using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserCoinUsageHistories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.UserCoinUsageHistoriesAPIClient
{
    public class UserCoinUsageHistoryAPIClient : BaseAPI, IUserCoinUsageHistoryAPIClient
    {
        public UserCoinUsageHistoryAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) 
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<PagingResult<UserCoinUsageHistoryViewModel>> GetUserCoinUsageHistoriesPagingManagement(PagingRequest request, Guid userId)
        {
            return await PostAsync<PagingResult<UserCoinUsageHistoryViewModel>, PagingRequest>(request, $"/api/user-coin-usage-histories/get-user-coin-usage-histories-with-user-id-paging-management/{userId}");
        }

        public async Task<ApiResult<List<UserCoinUsageHistoryViewModel>>> GetUserCoinUsageHistories(Guid userId)
        {
            return await GetAsync<ApiResult<List<UserCoinUsageHistoryViewModel>>>($"/api/user-coin-usage-histories/get-user-coin-usage-histories-with-user-id/{userId}");
        }

        public async Task<ApiResult<UserCoinUsageHistoryViewModel>> GetUserCoinUsageHistoryWithUserCoinUsageHistoryId(int userCoinUsageHistoryId)
        {
            return await GetAsync<ApiResult<UserCoinUsageHistoryViewModel>>($"/api/user-coin-usage-histories/get-user-coin-usage-history-with-user-coin-usage-history-id/{userCoinUsageHistoryId}");
        }
    }
}

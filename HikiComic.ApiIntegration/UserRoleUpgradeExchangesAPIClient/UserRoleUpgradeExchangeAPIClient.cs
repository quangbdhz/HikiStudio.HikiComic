using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserRoleUpgradeExchanges;
using HikiComic.ViewModels.UserRoleUpgradeExchanges.UserRoleUpgradeExchangeDataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.UserRoleUpgradeExchangesAPIClient
{
    public class UserRoleUpgradeExchangeAPIClient : BaseAPI, IUserRoleUpgradeExchangeAPIClient
    {
        public UserRoleUpgradeExchangeAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<UserRoleUpgradeExchangeViewModel>> CreateUserRoleUpgradeExchange(CreateUserRoleUpgradeExchangeRequest request)
        {
            return await PostAsync<ApiResult<UserRoleUpgradeExchangeViewModel>, CreateUserRoleUpgradeExchangeRequest>(request, "/api/user-role-upgrade-exchanges/create");
        }

        public async Task<ApiResult<bool>> DeleteUserRoleUpgradeExchange(int userRoleUpgradeExchangeId)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/user-role-upgrade-exchanges/delete/{userRoleUpgradeExchangeId}");
        }

        public async Task<ApiResult<bool>> DeleteUserRoleUpgradeExchanges(DeleteUserRoleUpgradeExchangesRequest request)
        {
            return await PostAsync<ApiResult<bool>, DeleteUserRoleUpgradeExchangesRequest>(request, $"/api/user-role-upgrade-exchanges/delete-multiple");
        }

        public async Task<IList<UserRoleUpgradeExchangeViewModel>> GetUserRoleUpgradeExchangeByUserRoleUpgradeRequestId(int userRoleUpgradeRequestId)
        {
            return await GetAsync<IList<UserRoleUpgradeExchangeViewModel>>($"/api/user-role-upgrade-exchanges/get-exchanges/{userRoleUpgradeRequestId}");
        }

        public async Task<ApiResult<bool>> RestoreDeletedUserRoleUpgradeExchange(int userRoleUpgradeExchangeId)
        {
            return await PostAsync<ApiResult<bool>, int>(userRoleUpgradeExchangeId, $"/api/user-role-upgrade-requests/restore");
        }
    }
}

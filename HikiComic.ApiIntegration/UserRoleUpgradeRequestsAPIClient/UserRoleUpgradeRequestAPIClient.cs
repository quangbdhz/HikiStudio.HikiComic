using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserRoleUpgradeRequests;
using HikiComic.ViewModels.UserRoleUpgradeRequests.UserRoleUpgradeRequestDataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.UserRoleUpgradeRequestsAPIClient
{
    public class UserRoleUpgradeRequestAPIClient : BaseAPI, IUserRoleUpgradeRequestAPIClient
    {
        public UserRoleUpgradeRequestAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<bool>> ChangeApprovalStatusUserRoleUpgradeRequest(CreateUserRoleUpgradeRequestRequest request)
        {
            return await PostAsync<ApiResult<bool>, CreateUserRoleUpgradeRequestRequest>(request, "/api/user-role-upgrade-requests/change-approval-status");
        }

        public async Task<ApiResult<int>> CreateRoleUpgradeRequest()
        {
            return await PostAsync<ApiResult<int>, string>("", "/api/user-role-upgrade-requests/create-creator");
        }

        public async Task<ApiResult<bool>> DeleteUserRoleUpgradeRequest(int userRoleUpgradeRequestId)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/user-role-upgrade-requests/delete/{userRoleUpgradeRequestId}");
        }

        public async Task<ApiResult<bool>> DeleteUserRoleUpgradeRequests(DeleteUserRoleUpgradeRequestsRequest request)
        {
            return await PostAsync<ApiResult<bool>, DeleteUserRoleUpgradeRequestsRequest>(request, $"/api/user-role-upgrade-requests/delete-multiple");
        }

        public async Task<PagingResult<UserRoleUpgradeRequestViewModel>> GetPagingManagement(PagingRequest request)
        {
            return await PostAsync<PagingResult<UserRoleUpgradeRequestViewModel>, PagingRequest>(request, $"/api/user-role-upgrade-requests/paging-management");
        }

        public async Task<ApiResult<UserRoleUpgradeRequestViewModel>> GetUserRoleUpgradeRequestByUserRoleUpgradeRequestId(int userRoleUpgradeRequestId)
        {
            return await GetAsync<ApiResult<UserRoleUpgradeRequestViewModel>>($"/api/user-role-upgrade-requests/get-user-role-upgrade-request-by-user-role-upgrade-request-id/{userRoleUpgradeRequestId}");
        }

        public async Task<ApiResult<bool>> RestoreDeletedUserRoleUpgradeRequest(int userRoleUpgradeRequestId)
        {
            return await PostAsync<ApiResult<bool>, int>(userRoleUpgradeRequestId, $"/api/user-role-upgrade-requests/restore");
        }
    }
}

using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserRoleUpgradeRequests;
using HikiComic.ViewModels.UserRoleUpgradeRequests.UserRoleUpgradeRequestDataRequest;

namespace HikiComic.ApiIntegration.UserRoleUpgradeRequestsAPIClient
{
    public interface IUserRoleUpgradeRequestAPIClient
    {
        public Task<PagingResult<UserRoleUpgradeRequestViewModel>> GetPagingManagement(PagingRequest request);

        public Task<ApiResult<UserRoleUpgradeRequestViewModel>> GetUserRoleUpgradeRequestByUserRoleUpgradeRequestId(int userRoleUpgradeRequestId);

        public Task<ApiResult<bool>> ChangeApprovalStatusUserRoleUpgradeRequest(CreateUserRoleUpgradeRequestRequest request);

        public Task<ApiResult<int>> CreateRoleUpgradeRequest();

        public Task<ApiResult<bool>> DeleteUserRoleUpgradeRequest(int userRoleUpgradeRequestId);

        public Task<ApiResult<bool>> DeleteUserRoleUpgradeRequests(DeleteUserRoleUpgradeRequestsRequest request);

        public Task<ApiResult<bool>> RestoreDeletedUserRoleUpgradeRequest(int userRoleUpgradeRequestId);
    }
}

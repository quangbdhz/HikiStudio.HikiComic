using HikiComic.Application.Base;
using HikiComic.Data.Entities;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserRoleUpgradeRequests;
using HikiComic.ViewModels.UserRoleUpgradeRequests.UserRoleUpgradeRequestDataRequest;

namespace HikiComic.Application.UserRoleUpgradeRequests
{
    public interface IUserRoleUpgradeRequestService : IBaseService<UserRoleUpgradeRequest>
    {
        public Task<PagingResult<UserRoleUpgradeRequestViewModel>> GetPagingManagement(PagingRequest request);

        public Task<ApiResult<UserRoleUpgradeRequestViewModel>> GetUserRoleUpgradeRequestByUserRoleUpgradeRequestId(int userRoleUpgradeRequestId);

        public Task<ApiResult<bool>> ChangeApprovalStatusUserRoleUpgradeRequest(CreateUserRoleUpgradeRequestRequest request);
    }
}

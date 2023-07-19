using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Roles.RoleDataRequest;
using HikiComic.ViewModels.Roles;

namespace HikiComic.ApiIntegration.RolesAPIClient
{
    public interface IRoleAPIClient
    {
        public Task<ApiResult<RoleViewModel>> GetRoleByRoleId(Guid roleId);

        public Task<ApiResult<List<RoleViewModel>>> GetAllRoles();

        public Task<PagingResult<RoleViewModel>> GetPagingManagement(PagingRequest request);

        public Task<ApiResult<bool>> CreateRole(CreateRoleRequest request);

        public Task<ApiResult<bool>> UpdateRole(UpdateRoleRequest request, Guid roleId);

        public Task<ApiResult<bool>> DeleteRoles(DeleteRolesRequest request);

        public Task<ApiResult<bool>> RestoreDeletedRole(Guid roleId);
    }
}

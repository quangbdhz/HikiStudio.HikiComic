using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Roles;
using HikiComic.ViewModels.Roles.RoleDataRequest;

namespace HikiComic.Application.Roles
{
    public interface IRoleService
    {
        public Task<ApiResult<RoleViewModel>> GetRoleByRoleId(Guid roleId);

        public Task<ApiResult<List<RoleViewModel>>> GetAllRoles(bool isPriorityMediumToHigh = true);

        public Task<PagingResult<RoleViewModel>> GetPagingManagement(PagingRequest request);

        public Task<ApiResult<bool>> CreateRole(CreateRoleRequest request);

        public Task<ApiResult<bool>> UpdateRole(UpdateRoleRequest request, Guid roleId);

        public Task<ApiResult<bool>> DeleteRoles(DeleteRolesRequest request);

        public Task<ApiResult<bool>> RestoreRole(Guid roleId);
    }
}

using HikiComic.ViewModels.Artists;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Roles;
using HikiComic.ViewModels.Roles.RoleDataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.RolesAPIClient
{
    public class RoleAPIClient : BaseAPI, IRoleAPIClient
    {
        public RoleAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<bool>> CreateRole(CreateRoleRequest request)
        {
            return await PostAsync<ApiResult<bool>, CreateRoleRequest>(request, "/api/roles/create");
        }

        public async Task<ApiResult<bool>> DeleteRoles(DeleteRolesRequest request)
        {
            return await PostAsync<ApiResult<bool>, DeleteRolesRequest>(request, $"/api/roles/delete-multiple");
        }

        public async Task<ApiResult<List<RoleViewModel>>> GetAllRoles()
        {
            return await GetAsync<ApiResult<List<RoleViewModel>>>($"/api/roles/get-all");
        }

        public async Task<PagingResult<RoleViewModel>> GetPagingManagement(PagingRequest request)
        {
            return await PostAsync<PagingResult<RoleViewModel>, PagingRequest>(request, $"/api/roles/paging-management");
        }

        public async Task<ApiResult<RoleViewModel>> GetRoleByRoleId(Guid roleId)
        {
            return await GetAsync<ApiResult<RoleViewModel>>($"/api/roles/get-role-by-role-id/{roleId}");
        }

        public async Task<ApiResult<bool>> RestoreDeletedRole(Guid roleId)
        {
            return await PostAsync<ApiResult<bool>, Guid>(roleId, $"/api/roles/restore");
        }

        public async Task<ApiResult<bool>> UpdateRole(UpdateRoleRequest request, Guid roleId)
        {
            return await PutAsync<ApiResult<bool>, UpdateRoleRequest>(request, $"/api/roles/update/{roleId}");
        }
    }
}

using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.ApiIntegration.RolesAPIClient;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Roles.RoleDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
    [Route("roles")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminPolicy)]
    public class RolesController : BaseController
    {
        private readonly IRoleAPIClient _roleAPIClient;

        private readonly INotificationAPIClient _notificationAPIClient;

        public RolesController(IRoleAPIClient roleAPIClient, INotificationAPIClient notificationAPIClient)
        {
            _roleAPIClient = roleAPIClient;
            _notificationAPIClient = notificationAPIClient;
        }

        private async Task InitNotifications()
        {
            var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForAdminAndTeamMembers(new ViewModels.Common.PagingRequestBase() { PageIndex = 1, PageSize = 7});
            ViewData["Notifications"] = notificationsResult.Items;
        }

        public async Task<IActionResult> Index()
        {
            await InitNotifications();

            return View();
        }

        [HttpPost("get-roles")]
        public async Task<IActionResult> Roles()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var orderBy = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumn = Request.Form[$"columns[{orderBy}][name]"].FirstOrDefault()?.Replace(" ", "");
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var pagingRequest = new PagingRequest()
                {
                    Draw = draw,
                    Start = start,
                    Length = length,
                    SortColumn = sortColumn,
                    SortColumnDirection = sortColumnDirection,
                    SearchValue = searchValue,
                    PageSize = pageSize,
                    Skip = skip,
                    RecordsTotal = recordsTotal
                };

                var data = await _roleAPIClient.GetPagingManagement(pagingRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-role-by-role-id/{roleId}")]
        public async Task<IActionResult> GetRoleByRoleId(Guid roleId)
        {
            var result = await _roleAPIClient.GetRoleByRoleId(roleId);
            return Ok(result);
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>(MessageConstants.ModelStateIsNotValid("Create Role")));

            var result = await _roleAPIClient.CreateRole(request);

            return Ok(result);
        }

        [HttpPut("update-role/{roleId}")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleRequest request, Guid roleId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Update Role")));

            var result = await _roleAPIClient.UpdateRole(request, roleId);

            return Ok(result);
        }

        [HttpDelete("delete-roles")]
        public async Task<IActionResult> DeleteRoles([FromBody] DeleteRolesRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Roles")));

            var result = await _roleAPIClient.DeleteRoles(request);

            return Ok(result);
        }

        [HttpPost("restore-role")]
        public async Task<IActionResult> RestoreDeletedrole([FromBody] Guid roleId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Restore Role")));

            var result = await _roleAPIClient.RestoreDeletedRole(roleId);
            return Ok(result);
        }
    }
}

using HikiComic.Application.Roles;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Roles.RoleDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/roles")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("get-role-by-role-id/{roleId}")]
        public async Task<IActionResult> GetRoleByRoleId(Guid roleId)
        {
            var result = await _roleService.GetRoleByRoleId(roleId);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _roleService.GetAllRoles();

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("paging-management")]
        public async Task<IActionResult> GetPagingManagement([FromBody] PagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _roleService.GetPagingManagement(request);

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(CreateRoleRequest)) });

            var result = await _roleService.CreateRole(request);

            return Ok(result);
        }

        [HttpPut("update/{roleId}")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleRequest request, Guid roleId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(UpdateRoleRequest)) });

            var result = await _roleService.UpdateRole(request, roleId);

            return Ok(result);
        }

        [HttpPost("delete-multiple")]
        public async Task<IActionResult> DeleteArtists([FromBody] DeleteRolesRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete roles")));

            return Ok(await _roleService.DeleteRoles(request));
        }

        [HttpPost("restore")]
        public async Task<IActionResult> RestoreDeletedArtist([FromBody] Guid roleId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid("Role Id") });

            var result = await _roleService.RestoreRole(roleId);
            return Ok(result);
        }
    }
}

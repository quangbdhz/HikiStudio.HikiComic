using HikiComic.Application.UserRoleUpgradeExchanges;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserRoleUpgradeExchanges.UserRoleUpgradeExchangeDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/user-role-upgrade-exchanges")]
    [Authorize]
    [ApiController]
    public class UserRoleUpgradeExchangeController : ControllerBase
    {
        private readonly IUserRoleUpgradeExchangeService _userRoleUpgradeExchangeService;

        public UserRoleUpgradeExchangeController(IUserRoleUpgradeExchangeService userRoleUpgradeExchangeService)
        {
            _userRoleUpgradeExchangeService = userRoleUpgradeExchangeService;
        }

        [HttpGet("get-exchanges/{userRoleUpgradeRequestId}")]
        public async Task<IActionResult> GetUserRoleUpgradeExchangeByUserRoleUpgradeRequestId(int userRoleUpgradeRequestId)
        {
            var result = await _userRoleUpgradeExchangeService.GetUserRoleUpgradeExchangeByUserRoleUpgradeRequestId(userRoleUpgradeRequestId);

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserRoleUpgradeExchange(CreateUserRoleUpgradeExchangeRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(CreateUserRoleUpgradeExchangeRequest)) });

            var result = await _userRoleUpgradeExchangeService.CreateUserRoleUpgradeExchange(request);

            return Ok(result);
        }

        [HttpDelete("delete/{userRoleUpgradeExchangeId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> DeleteUserRoleUpgradeRequest(int userRoleUpgradeExchangeId)
        {
            var result = await _userRoleUpgradeExchangeService.DeleteObject(userRoleUpgradeExchangeId);

            return Ok(result);
        }

        [HttpPost("delete-multiple")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> DeleteUserRoleUpgradeRequests([FromBody] DeleteUserRoleUpgradeExchangesRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid(nameof(DeleteUserRoleUpgradeExchangesRequest))));

            return Ok(await _userRoleUpgradeExchangeService.DeleteObjects(request.UserRoleUpgradeExchangeIds));
        }

        [HttpPost("restore")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> RestoreDeletedUserRoleUpgradeRequest([FromBody] int userRoleUpgradeExchangeId)
        {
            var result = await _userRoleUpgradeExchangeService.RestoreDeletedObject(userRoleUpgradeExchangeId);

            return Ok(result);
        }
    }
}

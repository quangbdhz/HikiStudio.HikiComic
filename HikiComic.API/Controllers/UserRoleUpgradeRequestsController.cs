using HikiComic.Application.UserRoleUpgradeRequests;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserRoleUpgradeRequests.UserRoleUpgradeRequestDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/user-role-upgrade-requests")]
    [Authorize]
    [ApiController]
    public class UserRoleUpgradeRequestsController : ControllerBase
    {
        private readonly IUserRoleUpgradeRequestService _userRoleUpgradeRequestService;

        public UserRoleUpgradeRequestsController(IUserRoleUpgradeRequestService userRoleUpgradeRequestService)
        {
            _userRoleUpgradeRequestService = userRoleUpgradeRequestService;
        }

        [HttpPost("paging-management")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetPagingManagement([FromBody] PagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userRoleUpgradeRequestService.GetPagingManagement(request);

            return Ok(result);
        }

        [HttpGet("get-user-role-upgrade-request-by-user-role-upgrade-request-id/{userRoleUpgradeRequestId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetUserRoleUpgradeRequestByUserRoleUpgradeRequestId(int userRoleUpgradeRequestId)
        {
            var result = await _userRoleUpgradeRequestService.GetUserRoleUpgradeRequestByUserRoleUpgradeRequestId(userRoleUpgradeRequestId);

            return Ok(result);
        }

        [HttpPost("change-approval-status")]
        public async Task<IActionResult> ChangeApprovalStatusUserRoleUpgradeRequest(CreateUserRoleUpgradeRequestRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(CreateUserRoleUpgradeRequestRequest)) });

            var result = await _userRoleUpgradeRequestService.ChangeApprovalStatusUserRoleUpgradeRequest(request);

            return Ok(result);
        }

        [HttpPost("create-creator")]
        [Authorize(Policy = SystemConstants.AppSettings.ReaderPolicy)]
        public async Task<IActionResult> CreateUserRoleUpgradeRequest([FromBody] string name)
        {
            var result = await _userRoleUpgradeRequestService.CreateObject("");

            if (result.IsSuccessed)
            {
                result.Message = "Your request has been sent successfully, please wait for review.";
            }

            return Ok(result);
        }

        [HttpDelete("delete/{userRoleUpgradeRequestId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> DeleteUserRoleUpgradeRequest(int userRoleUpgradeRequestId)
        {
            var result = await _userRoleUpgradeRequestService.DeleteObject(userRoleUpgradeRequestId);

            return Ok(result);
        }

        [HttpPost("delete-multiple")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> DeleteUserRoleUpgradeRequests([FromBody] DeleteUserRoleUpgradeRequestsRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete UserRoleUpgradeRequests")));

            return Ok(await _userRoleUpgradeRequestService.DeleteObjects(request.UserRoleUpgradeRequestIds));
        }

        [HttpPost("restore")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> RestoreDeletedUserRoleUpgradeRequest([FromBody] int userRoleUpgradeRequestId)
        {
            var result = await _userRoleUpgradeRequestService.RestoreDeletedObject(userRoleUpgradeRequestId);

            return Ok(result);
        }
    }
}

using HikiComic.Application.Common;
using HikiComic.Application.Users;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users;
using HikiComic.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ICommonService commonService)
        {
            _userService = userService;
        }

        [HttpGet("get-user-by-user-id")]
        [Authorize]
        public async Task<IActionResult> GetUserByUserId()
        {
            var user = new ApiResult<UserViewModel>();

            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!String.IsNullOrEmpty(getClaimUserId))
            {
                Guid userId = new Guid(getClaimUserId);
                user = await _userService.GetUserByUserId(userId);

                return Ok(user);
            }

            return BadRequest(new ApiErrorResult<UserViewModel>() { Message = "User does not login." });
        }

        [HttpGet("get-user-by-user-id/{userId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetUserByUserId(Guid userId)
        {
            var user = await _userService.GetUserByUserId(userId);

            return Ok(user);
        }

        [HttpGet("get-user-by-user-email/{email}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetUserByUserEmail(string email)
        {
            var user = await _userService.GetUserByUserEmail(email);
            return Ok(user);
        }

        [HttpPost("paging-management")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetPagingManagement([FromBody] PagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = await _userService.GetPagingManagement(request, false);

            return Ok(users);
        }


        [HttpPost("admin-paging-management")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminPolicy)]
        public async Task<IActionResult> AdminGetPagingManagement([FromBody] PagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = await _userService.GetPagingManagement(request, true);

            return Ok(users);
        }


        #region admin create user and assign role -> send mail confirmation (token) -> verify token mail confirmation
        [HttpPost("create-user-and-assign-role")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminPolicy)]
        public async Task<IActionResult> CreateUserAndAssignRole(CreateUserAndAssignRoleRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(CreateUserAndAssignRoleRequest)) });

            var result = await _userService.CreateUserAndAssignRole(request);

            return Ok(result);
        }

        [HttpPost("resend-mail-email-confirmation")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminPolicy)]
        public async Task<IActionResult> ResendMailConfirmation([FromBody] string email)
        {
            if (String.IsNullOrEmpty(email))
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Email") });

            var result = await _userService.ResendMailConfirmation(email);

            return Ok(result);
        }
        

        [HttpPost("verify-token-email-confirmation")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyTokenEmailConfimation([FromBody] string token)
        {
            if (String.IsNullOrEmpty(token))
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid("token") });

            var result = await _userService.VerifyTokenEmailConfirmation(token);

            return Ok(result);
        }

        [HttpPost("user-mail-confirmations-and-change-password")]
        [AllowAnonymous]
        public  async Task<IActionResult> UserEmailConfirmationAndChangePassword(VerifyTokenEmailAndChangePasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Token") });

            var result = await _userService.UserEmailConfirmationAndChangePassword(request);

            return Ok(result);
        }
        #endregion

        [HttpPut("update")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!String.IsNullOrEmpty(getClaimUserId))
            {
                Guid userId = new Guid(getClaimUserId);
                var result = await _userService.UpdateUser(userId, request); ;

                return Ok(result);
            }

            return BadRequest(new ApiErrorResult<UserViewModel>() { Message = "User does not login." });

        }

        [HttpPut("update/{userId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> Update(Guid userId, [FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.UpdateUser(userId, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("delete/{userId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var result = await _userService.DeleteUser(userId);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("delete-multiple")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> DeleteUsers([FromBody] DeleteUsersRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Users")));

            return Ok(await _userService.DeleteUsers(request));
        }

        [HttpPost("restore")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> RestoreDeletedUser([FromBody] Guid userId)
        {
            if (userId == Guid.Empty)
                return Ok(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid("UserId") });

            var result = await _userService.RestoreDeletedUser(userId);

            return Ok(result);
        }

        [HttpPost("lockout-enabled")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> LockoutEnabledUser([FromBody] Guid userId)
        {
            if (userId == Guid.Empty)
                return Ok(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid("UserId") });

            var result = await _userService.LockoutEnabledUser(userId);

            return Ok(result);
        }
    }
}

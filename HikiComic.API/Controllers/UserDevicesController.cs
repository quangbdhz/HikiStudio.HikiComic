using HikiComic.Application.UserDevices;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserDevices.UserDeviceDataRequest;
using HikiComic.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{
    [Route("api/user-devices")]
    [Authorize]
    [ApiController]
    public class UserDevicesController : ControllerBase
    {
        private readonly IUserDeviceService _userDeviceService;

        public UserDevicesController(IUserDeviceService userDeviceService)
        {
            _userDeviceService = userDeviceService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!String.IsNullOrEmpty(getClaimUserId))
            {
                Guid userId = new Guid(getClaimUserId);
                var result = await _userDeviceService.GetAll(userId);

                return Ok(result);
            }

            return BadRequest(new ApiErrorResult<UserViewModel>() { Message = "User does not login." });
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserDevice(CreateUserDeviceRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!String.IsNullOrEmpty(getClaimUserId))
            {
                Guid userId = new Guid(getClaimUserId);
                var result = await _userDeviceService.CreateUserDevice(request, userId); ;

                return Ok(result);
            }

            return BadRequest(new ApiErrorResult<UserViewModel>() { Message = "User does not login." });
        }

        [HttpDelete("delete/{artistId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> DeleteUserDevice(int userDeviceId)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!String.IsNullOrEmpty(getClaimUserId))
            {
                Guid userId = new Guid(getClaimUserId);
                var result = await _userDeviceService.DeleteUserDevice(userDeviceId, userId);

                return Ok(result);
            }

            return BadRequest(new ApiErrorResult<UserViewModel>() { Message = "User does not login." });
        }
    }
}

using HikiComic.Application.UserCoinUsageHistories;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserCoinUsageHistories;
using HikiComic.ViewModels.UserCoinUsageHistories.UserCoinUsageHistoryDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{
    [Route("api/user-coin-usage-histories")]
    [Authorize]
    [ApiController]
    public class UserCoinUsageHistoriesController : ControllerBase
    {
        private readonly IUserCoinUsageHistoryService _userCoinUsageHistoryService;

        public UserCoinUsageHistoriesController(IUserCoinUsageHistoryService userCoinUsageHistoryService)
        {
            _userCoinUsageHistoryService = userCoinUsageHistoryService;
        }

        [HttpPost("get-user-coin-usage-histories-with-user-id-paging-management/{userId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetPagingManagement([FromBody] PagingRequest request, Guid userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (userId == Guid.Empty)
                return BadRequest(MessageConstants.InvalidGuidFormat);

            var userCOINUsageHistories = await _userCoinUsageHistoryService.GetUserCoinUsageHistoriesPagingManagement(request, userId);

            return Ok(userCOINUsageHistories);
        }

        [HttpGet("get-user-coin-usage-histories-with-user-id/{userId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetUserCoinUsageHistoriesWithUserId(string userId) 
        {
            if (!Guid.TryParseExact(userId, "D", out Guid guidUserId))
                return BadRequest(new ApiErrorResult<List<UserCoinUsageHistoryViewModel>>() { Message = MessageConstants.InvalidGuidFormat });

            if (guidUserId == Guid.Empty)
                return BadRequest(new ApiErrorResult<List<UserCoinUsageHistoryViewModel>>() { Message = MessageConstants.InvalidGuidFormat });

            var result = await _userCoinUsageHistoryService.GetUserCoinUsageHistories(guidUserId);

            return Ok(result);
        }

        [HttpGet("get-user-coin-usage-histories")]
        public async Task<IActionResult> GetUserCoinUsageHistories()
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var result = await _userCoinUsageHistoryService.GetUserCoinUsageHistories(userId);

            return Ok(result);
        }

        [HttpGet("get-user-coin-usage-history-with-user-coin-usage-history-id/{userCoinUsageHistoryId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetUserCoinUsageHistoryWithUserCoinUsageHistoryId(int userCoinUsageHistoryId)
        {
            var result = await _userCoinUsageHistoryService.GetUserCoinUsageHistoryWithUserCoinUsageHistoryId(userCoinUsageHistoryId);

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserCoinUsageHistory(CreateUserCoinUsageHistoryRequest request)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var result = await _userCoinUsageHistoryService.CreateUserCoinUsageHistory(request, userId);

            return Ok(result);
        }

        [HttpDelete("delete/{userCoinUsageHistoryId}")]
        public async Task<IActionResult> DeleteUserCoinDepositHistory(int userCoinUsageHistoryId)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var result = await _userCoinUsageHistoryService.DeleteUserCoinUsageHistory(userCoinUsageHistoryId, userId);

            return Ok(result);
        }

        [HttpDelete("delete-all")]
        public async Task<IActionResult> DeleteAllUserCoinUsageHistories()
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var result = await _userCoinUsageHistoryService.DeleteAllUserCoinUsageHistories(userId);

            return Ok(result);
        }
    }
}

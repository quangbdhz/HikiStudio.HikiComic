using HikiComic.Application.UserCoinDepositHistories;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserCoinDepositHistories.UserCoinDepositHistoryDataRequest;
using HikiComic.ViewModels.UserCoinUsageHistories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{
    [Route("api/user-coin-deposit-histories")]
    [ApiController]
    [Authorize]
    public class UserCoinDepositHistoriesController : ControllerBase
    {

        private readonly IUserCoinDepositHistoryService _userCoinDepositHistoryService;

        public UserCoinDepositHistoriesController(IUserCoinDepositHistoryService userCoinDepositHistoryService)
        {
            _userCoinDepositHistoryService = userCoinDepositHistoryService;
        }

        [HttpPost("get-user-coin-deposit-histories-with-user-id-paging-management/{userId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetPagingManagement([FromBody] PagingRequest request, Guid userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (userId == Guid.Empty)
                return BadRequest(MessageConstants.InvalidGuidFormat);

            var userCOINDepositHistories = await _userCoinDepositHistoryService.GetUserCoinDepositHistoriesPagingManagement(request, userId);

            return Ok(userCOINDepositHistories);
        }


        [HttpGet("get-user-coin-deposit-histories-with-user-id/{userId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetUserCoinDepositHistoriesWithUserId(string userId)
        {
            if (!Guid.TryParseExact(userId, "D", out Guid guidUserId))
                return BadRequest(new ApiErrorResult<List<UserCoinUsageHistoryViewModel>>() { Message = MessageConstants.InvalidGuidFormat });

            if (guidUserId == Guid.Empty)
                return BadRequest(new ApiErrorResult<List<UserCoinUsageHistoryViewModel>>() { Message = MessageConstants.InvalidGuidFormat });

            var result = await _userCoinDepositHistoryService.GetUserCoinDepositHistories(guidUserId);

            return Ok(result);
        }

        [HttpGet("get-user-coin-deposit-histories")]
        public async Task<IActionResult> GetUserCoinDepositHistories()
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var result = await _userCoinDepositHistoryService.GetUserCoinDepositHistories(userId);

            return Ok(result);
        }

        [HttpGet("get-user-coin-deposit-history-with-user-coin-deposit-history-id/{userCoinDepositHistoryId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetUserCoinDepositHistoryWithUserCoinDepositHistoryId(int userCoinDepositHistoryId)
        {
            var result = await _userCoinDepositHistoryService.GetUserCoinDepositHistoryWithUserCoinDepositHistoryId(userCoinDepositHistoryId);

            return Ok(result);
        }

        [HttpPost("check-and-change-deposit-status")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> CheckAndChangeDepositStatus(ChangeDepositStatusRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid("ChangeDepositStatus") });

            var result = await _userCoinDepositHistoryService.CheckAndChangeDepositStatus(request);

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserCoinDepositHistory(CreateUserCoinDepositHistoryRequest request)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var result = await _userCoinDepositHistoryService.CreateUserCoinDepositHistory(request, userId);

            return Ok(result);
        }

        [HttpDelete("delete/{userCoinDepositHistoryId}")]
        public async Task<IActionResult> DeleteUserCoinDepositHistory(int userCoinDepositHistoryId)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var result = await _userCoinDepositHistoryService.DeleteUserCoinDepositHistory(userCoinDepositHistoryId, userId);

            return Ok(result);
        }

        [HttpDelete("delete-all")]
        public async Task<IActionResult> DeleteAllUserCoinDepositHistories()
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var result = await _userCoinDepositHistoryService.DeleteAllUserCoinDepositHistories(userId);

            return Ok(result);
        }
    }
}

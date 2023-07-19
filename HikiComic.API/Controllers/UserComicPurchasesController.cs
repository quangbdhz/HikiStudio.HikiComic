using HikiComic.Application.UserComicPurchases;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserComicPurchases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{
    [Route("api/user-comic-purchases")]
    [Authorize]
    [ApiController]
    public class UserComicPurchasesController : ControllerBase
    {
        private readonly IUserComicPurchaseService _userComicPurchaseService;

        public UserComicPurchasesController(IUserComicPurchaseService userComicPurchaseService)
        {
            _userComicPurchaseService = userComicPurchaseService;
        }

        [HttpGet("get-user-comic-puchases-with-user-id/{userId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetUserComicPurchasesWithUserId(string userId)
        {
            if (!Guid.TryParseExact(userId, "D", out Guid guidUserId))
                return BadRequest(new ApiErrorResult<List<UserComicPurchaseViewModel>>() { Message = MessageConstants.InvalidGuidFormat });

            if (guidUserId == Guid.Empty)
                return BadRequest(new ApiErrorResult<List<UserComicPurchaseViewModel>>() { Message = MessageConstants.InvalidGuidFormat });

            var result = await _userComicPurchaseService.GetUserComicPurchases(guidUserId);

            return Ok(result);
        }

        [HttpGet("get-user-comic-puchases")]
        public async Task<IActionResult> GetUserComicPurchases()
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var result = await _userComicPurchaseService.GetUserComicPurchases(userId);

            return Ok(result);
        }
    }
}

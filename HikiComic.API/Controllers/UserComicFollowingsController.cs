using HikiComic.Application.UserComicFollowings;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserComicFollowings.UserComicFollowingDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{
    [Route("api/user-comic-followings")]
    [ApiController]
    [Authorize]
    public class UserComicFollowingsController : ControllerBase
    {
        private IUserComicFollowingService _userComicFollowingService;

        public UserComicFollowingsController(IUserComicFollowingService userComicFollowingService)
        {
            _userComicFollowingService = userComicFollowingService;
        }

        [HttpPost("following")]
        public async Task<IActionResult> CreateOrDeleteUserComicFollowing(InfoUserComicFollowingRequest request)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var result = await _userComicFollowingService.CreateOrDeleteUserComicFollowing(request, userId);

            return Ok(result);
        }

        [HttpPost("get-user-followed-comic")]
        public async Task<IActionResult> GetUserFollowedComics(PagingRequestBase request)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var result = await _userComicFollowingService.GetUserFollowedComics(request, userId);

            return Ok(result);
        }
    }
}

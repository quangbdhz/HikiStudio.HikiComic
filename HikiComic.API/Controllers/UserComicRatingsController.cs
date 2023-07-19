using HikiComic.Application.UserComicRatings;
using HikiComic.ViewModels.UserComicRatings.UserComicRatingDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{
    [Route("api/user-comic-ratings")]
    [ApiController]
    [Authorize]
    public class UserComicRatingsController : ControllerBase
    {
        private readonly IUserComicRatingService _userComicRatingService;

        public UserComicRatingsController(IUserComicRatingService userComicRatingService)
        {
            _userComicRatingService = userComicRatingService;
        }


        [HttpPost("create-rating")]
        public async Task<IActionResult> Rating(CreateUserComicRatingRequest request)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var result = await _userComicRatingService.CreateUserComicRating(request, userId);

            return Ok(result);
        }

    }
}

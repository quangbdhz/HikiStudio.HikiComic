using HikiComic.Application.UserComicReadingHistories;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserComicReadingHistories.UserComicReadingHistoryDataRequest;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{
    [Route("api/user-comic-reading-histories")]
    [ApiController]
    public class UserComicReadingHistoriesController : ControllerBase
    {
        private readonly IUserComicReadingHistoryService _userComicReadingHistoryService;

        public UserComicReadingHistoriesController(IUserComicReadingHistoryService userComicReadingHistoryService)
        {
            _userComicReadingHistoryService = userComicReadingHistoryService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Paging([FromQuery] PagingRequestBase request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(PagingRequestBase)) });

            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.UserIsNotLogin });

            Guid userId = new Guid(getClaimUserId);

            var result = await _userComicReadingHistoryService.PagingHistoryReadComicOfUser(request, userId);

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Index([FromBody] CreateUserComicReadingHistoryRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(CreateUserComicReadingHistoryRequest)) });

            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.UserIsNotLogin });

            Guid userId = new Guid(getClaimUserId);

            var result = await _userComicReadingHistoryService.CreateHistoryReadComicOfUser(request, userId);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

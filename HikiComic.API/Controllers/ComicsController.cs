using HikiComic.Application.Comics;
using HikiComic.Application.UserContext;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Comics.ComicDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twilio.Rest.Api.V2010.Account;

namespace HikiComic.API.Controllers
{
    [Route("api/comics")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly IComicService _comicService;

        private readonly IUserContextService _userContextService;

        public ComicsController(IComicService comicService, IUserContextService userContextService)
        {
            _comicService = comicService;
            _userContextService = userContextService;
        }

        [HttpGet("get-recommended-comics/{numberOfElement}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRecommendedComic(int numberOfElement)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
            {
                var comics = await _comicService.GetComicByRankingComics(numberOfElement);
                return Ok(comics);
            }
            else
            {
                var result = await _comicService.GetRecommendedComic(userResult.ResultObj, numberOfElement);

                //var result = await _comicService.GetRecommendedComic(new Guid("6B8AE93C-308F-4E09-4F4F-08DB80A0A6BC"), numberOfElement);
                return Ok(result);
            }
        }

        [HttpGet("get-comic-by-genre-paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetComicByGenrePaging([FromQuery] ComicByGenrePagingRequest request)
        {
            var comics = await _comicService.GetComicByGenrePaging(request);
            return Ok(comics);
        }

        [HttpGet("get-comic-by-author-paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetComicByAuthorPaging([FromQuery] ComicByAuthorPagingRequest request)
        {
            var comics = await _comicService.GetComicByAuthorPaging(request);
            return Ok(comics);
        }

        [HttpGet("get-comic-by-artist-paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetComicByArtistPaging([FromQuery] ComicByArtistPagingRequest request)
        {
            var comics = await _comicService.GetComicByArtistPaging(request);
            return Ok(comics);
        }

        [HttpGet("get-comic-by-status-paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetComicByStatusPaging([FromQuery] ComicByStatusPagingRequest request)
        {
            var comics = await _comicService.GetComicByStatusPaging(request);
            return Ok(comics);
        }

        [HttpGet("get-comic-by-creator-paging")]
        [Authorize]
        public async Task<IActionResult> GetComicByCreatorPaging([FromQuery] ComicByCreatorPagingRequest request)
        {
            var comics = await _comicService.GetComicByCreatorPaging(request);
            return Ok(comics);
        }

        [HttpGet("get-comic-by-new-comics")]
        [AllowAnonymous]
        public async Task<IActionResult> GeComicByNewComics([FromQuery] PagingRequestBase request)
        {
            var comics = await _comicService.GeComicByNewComics(request);
            return Ok(comics);
        }

        [HttpGet("get-comic-by-ranking-comics/{numberOfElement}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetComicByRankingComics(int numberOfElement)
        {
            var comics = await _comicService.GetComicByRankingComics(numberOfElement);
            return Ok(comics);
        }

        [HttpPost("paging-management")]
        [Authorize]
        public async Task<IActionResult> GetPagingManagement([FromBody] PagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comics = await _comicService.GetPagingManagement(request);
            return Ok(comics);
        }

        //[HttpGet("paging-user-follow")]
        //public async Task<IActionResult> GetPagingUserFollow([FromQuery] PagingRequestBase request)
        //{
        //    var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    if (String.IsNullOrEmpty(getClaimUserId))
        //        return BadRequest();

        //    Guid userId = new Guid(getClaimUserId);

        //    var result = await _comicService.GetPagingUserFollow(userId, request);
        //    return Ok(result);
        //}

        [HttpPatch("add-view-count/{comicId}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddViewCount(int comicId)
        {
            var result = await _comicService.AddViewCount(comicId);

            if (result == 0)
                return Ok(new ApiErrorResult<bool>("Error"));

            return Ok(new ApiSuccessResult<bool>());

        }

        //[HttpPost("rating/{comicId}/{rating}")]
        //public async Task<ApiResult<bool>> AddRatingComic(int comicId, double rating)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return new ApiErrorResult<bool>("IsValid");
        //    }

        //    return await _comicService.AddRating(comicId, rating);
        //}

        [HttpPost("create")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> CreateComic([FromBody] CreateComicRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>() { Message = MessageConstants.ModelStateIsNotValid("Create Comic") });

            var result = await _comicService.CreateComic(request);

            return Ok(result);
        }

        [HttpPost("create-comic-by-crawling")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> CreateComicByCrawling([FromBody] CreateComicByCrawlingRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>() { Message = MessageConstants.ModelStateIsNotValid("Create Comic By Crawling") });

            var result = await _comicService.CreateComicByCrawling(request);

            return Ok(result);
        }

        [HttpPut("update/{comicId}")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> UpdateComic([FromBody] UpdateComicRequest request, int comicId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid("Update Comic") });

            var comics = await _comicService.UpdateComic(request, comicId);
            return Ok(comics);
        }

        [HttpDelete("delete/{comicId}")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> DeleteComic(int comicId)
        {
            var result = await _comicService.DeleteComic(comicId);

            return Ok(result);
        }

        [HttpPost("delete-multiple")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> DeleteComics([FromBody] DeleteComicRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Comics")));

            return Ok(await _comicService.DeleteComics(request));
        }


        [HttpPost("restore")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> RestoreDeletedComic([FromBody] int comicId)
        {
            var result = await _comicService.RestoreDeletedComic(comicId);
            return Ok(result);
        }

        [HttpPost("approve-comic")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> ApproveComic([FromBody] int comicId)
        {
            var result = await _comicService.ApproveComic(comicId);
            return Ok(result);
        }

        [HttpPost("reject-comic/{comicId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> RejectComic(int comicId, [FromBody] string feedback)
        {
            var result = await _comicService.RejectComic(comicId, feedback);
            return Ok(result);
        }
    }
}

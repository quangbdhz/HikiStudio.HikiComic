using HikiComic.Application.ComicDetails;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.ComicDetails.ComicDetailDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{
    [Route("api/comic-details")]
    [ApiController]
    public class ComicDetailsController : ControllerBase
    {
        private readonly IComicDetailService _comicDetailService;

        public ComicDetailsController(IComicDetailService comicDetailService)
        {
            _comicDetailService = comicDetailService;
        }

        [HttpGet("get-comic-detail-by-comic-id/{comicId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetComicDetailByComicId(int comicId)
        {
            return Ok(await _comicDetailService.GetComicDetailByComicId(comicId));
        }

        [HttpGet("get-comic-detail-by-comic-id-with-user/{comicId}")]
        public async Task<IActionResult> GetByIdWithUser(int comicId)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            return Ok(await _comicDetailService.GetComicDetailByComicId(userId, comicId));
        }

        [HttpGet("get-comic-detail-by-comic-seo-alias/{comicSEOAlias}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetComicDetailByComicSEOAlias(string comicSEOAlias)
        {
            return Ok(await _comicDetailService.GetComicDetailByComicSEOAlias(comicSEOAlias, false));
        }

        [HttpGet("get-comic-detail-by-comic-seo-alias-with-admin/{comicSEOAlias}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetComicDetailByComicSEOAliasWithAdmin(string comicSEOAlias)
        {
            return Ok(await _comicDetailService.GetComicDetailByComicSEOAlias(comicSEOAlias, true));
        }

        [HttpGet("get-comic-detail-by-comic-seo-alias-with-user/{comicSEOAlias}")]
        public async Task<IActionResult> GetBySeoAliasWithUser(string comicSEOAlias)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            return Ok(await _comicDetailService.GetComicDetailByComicSEOAliasWithUser(userId, comicSEOAlias));
        }

        [HttpGet("update-status-user-follow-comic/{comicId}")]
        public async Task<IActionResult> UpdateStatusUserFollowComic(int comicId)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var ComicDetail = await _comicDetailService.UpdateStatusUserFollowComic(userId, comicId);
            return Ok(ComicDetail);
        }

        //[HttpPost("update-summary-comic-detail")]
        //[AllowAnonymous]
        ////[Authorize(Roles = "admin")]
        //public async Task<IActionResult> UpdateDescriptionComicDetail(UpdateSummaryComicDetailRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Update Summary Comic Detail")));

        //    var result = await _comicDetailService.UpdateSummaryComicDetail(request);

        //    return Ok(result);
        //}
    }
}

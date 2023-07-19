using HikiComic.Application.ChapterImageURLs;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.ChapterImageURLs;
using HikiComic.ViewModels.ChapterImageURLs.ChapterImageURLDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{
    [Route("api/chapter-image-urls")]
    [Authorize]
    [ApiController]
    public class ChapterImageURLsController : ControllerBase
    {
        private readonly IChapterImageURLService _chapterImageURLService;

        private readonly ILogger<ChapterImageURLsController> _logger;

        public ChapterImageURLsController(IChapterImageURLService chapterImageURLService, ILogger<ChapterImageURLsController> logger)
        {
            _chapterImageURLService = chapterImageURLService;
            _logger = logger;
        }

        [HttpGet("get-chapter-by-chapter-id/{chapterId}")]
        public async Task<IActionResult> GetChapterByChapterId(int chapterId)
        {
            var chapterImageUrls = new ApiResult<ChapterImageURLViewModel>();
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
            {
                chapterImageUrls = await _chapterImageURLService.GetChapterByChapterId(chapterId, null);
            }
            else
            {
                Guid userId = new Guid(getClaimUserId);
                chapterImageUrls = await _chapterImageURLService.GetChapterByChapterId(chapterId, userId);
            }

            return Ok(chapterImageUrls);
        }

        [HttpGet("get-chapter-by-chapter-comic-seo-alias/{comicSEOAlias}/{chapterSEOAlias}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetChapterByChapterComicSEOAlias(string comicSEOAlias, string chapterSEOAlias)
        {
            var chapterImageUrls = new ApiResult<ChapterImageURLViewModel>();
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
            {
                chapterImageUrls = await _chapterImageURLService.GetChapterByChapterComicSEOAlias(comicSEOAlias, chapterSEOAlias, null);
            }
            else
            {
                Guid userId = new Guid(getClaimUserId);
                chapterImageUrls = await _chapterImageURLService.GetChapterByChapterComicSEOAlias(comicSEOAlias, chapterSEOAlias, userId);
            }

            return Ok(chapterImageUrls);
        }

        [HttpGet("get-free-chapter-by-chapter-comic-seo-alias/{comicSEOAlias}/{chapterSEOAlias}")]
        public async Task<IActionResult> GetFreeChapterByChapterComicSEOAlias(string comicSEOAlias, string chapterSEOAlias)
        {
            var chapterImageUrls = new ApiResult<ChapterImageURLViewModel>();
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
            {
                chapterImageUrls = await _chapterImageURLService.GetFreeChapterByChapterComicSEOAlias(comicSEOAlias, chapterSEOAlias, null);
            }
            else
            {
                Guid userId = new Guid(getClaimUserId);
                chapterImageUrls = await _chapterImageURLService.GetFreeChapterByChapterComicSEOAlias(comicSEOAlias, chapterSEOAlias, userId);
            }

            return Ok(chapterImageUrls);
        }

        [HttpPost("create")]
        [AllowAnonymous]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateChapterImageURL([FromBody] CreateChapterImageURLRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<string>() { Message = MessageConstants.ModelStateIsNotValid("Create Chapter Image URL") });

            var result = await _chapterImageURLService.CreateChapterImageURL(request);

            return Ok(result);
        }
    }
}

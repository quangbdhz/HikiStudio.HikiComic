using HikiComic.Application.Chapters;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Chapters.ChapterDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{
    [Route("api/chapters")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly IChapterService _chapterService;

        public ChaptersController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [HttpPost("paging-management/{comicSEOAlias}")]
        [Authorize]
        public async Task<IActionResult> GetPagingManagement([FromBody] PagingRequest request, string comicSEOAlias)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var chapters = await _chapterService.GetPagingManagement(request, comicSEOAlias);

            return Ok(chapters);
        }

        [HttpGet("get-chapters-by-comic-detail-id/{comicDetailId}")]
        public async Task<IActionResult> GetByComicDetailId(int comicDetailId)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
            {
                var result = await _chapterService.GetChapterByComicDetailId(comicDetailId);

                return Ok(result);
            }
            else
            {
                Guid userId = new Guid(getClaimUserId);
                var result = await _chapterService.GetChapterByComicDetailId(comicDetailId, userId);
                return Ok(result);
            }
        }

        [HttpGet("get-chapters-by-comic-seo-alias/{comicSEOAlias}")]
        public async Task<IActionResult> GetBySeoAlias(string comicSEOAlias)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
            {
                var result = await _chapterService.GetChapterByComicSEOAlias(comicSEOAlias);

                return Ok(result);
            }
            else
            {
                Guid userId = new Guid(getClaimUserId);
                var result = await _chapterService.GetChapterByComicSEOAlias(comicSEOAlias, userId);
                return Ok(result);
            }
        }

        [HttpGet("chapter-detail/{comicSEOAlias}/{chapterSEOAlias}")]
        public async Task<IActionResult> GetChapterDetail(string comicSEOAlias, string chapterSEOAlias)
        {
            var result = await _chapterService.GetChapterDetail(comicSEOAlias, chapterSEOAlias);

            return Ok(result);
        }

        [HttpPatch("add-view-count/{chapterSEOAlias}")]
        public async Task<IActionResult> AddViewCount(string comicSEOAlias, string chapterSEOAlias)
        {
            var chapter = await _chapterService.AddViewCount(comicSEOAlias, chapterSEOAlias);

            if (chapter is null)
                return NotFound();

            return Ok(chapter);
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateChapter([FromBody] CreateChapterRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>() { ResultObj = -1, Message = MessageConstants.ModelStateIsNotValid("Chapter ") });

            var result = await _chapterService.CreateChapter(request);

            return Ok(result);
        }

        [HttpPost("create-chapter-and-chapter-image-url-with-comic-detail-id/{comicDetailId}")]
        [Authorize]
        public async Task<IActionResult> CreateChapterAndChapterImageURLWithComicSEOAlias([FromBody] CreateChapterAndChapterImageURLRequest request, int comicDetailId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _chapterService.CreateChapterAndChapterImageURLWithComicId(request, comicDetailId);

            return Ok(result);
        }

        [HttpPost("create-chapter-and-chapter-image-url-with-comic-seo-alias/{comicSEOAlias}")]
        [Authorize]
        public async Task<IActionResult> CreateChapterAndChapterImageURLWithComicSEOAlias([FromBody] CreateChapterAndChapterImageURLRequest request, string comicSEOAlias)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _chapterService.CreateChapterAndChapterImageURLWithComicSEOAlias(request, comicSEOAlias);

            return Ok(result);
        }


        [HttpPut("update/{chapterId}")]
        [Authorize]
        public async Task<IActionResult> UpdateNamechapter([FromBody] UpdateChapterRequest request, int chapterId)
        {
            var result = await _chapterService.UpdateChapter(request, chapterId);

            return Ok(result);
        }

        [HttpDelete("delete/{chapterId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> Delete(int chapterId)
        {
            var result = await _chapterService.DeleteChapter(chapterId);

            return Ok(result);
        }

        [HttpPost("delete-multiple")]
        [Authorize]
        public async Task<IActionResult> DeleteChapters([FromBody] DeleteChapterRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Chapters")));

            return Ok(await _chapterService.DeleteChapters(request));
        }

        [HttpPost("restore")]
        [Authorize]
        public async Task<IActionResult> RestoreDeletedchapter([FromBody] int chapterId)
        {
            var result = await _chapterService.RestoreDeletedChapter(chapterId);

            return Ok(result);
        }

        [HttpGet("check-user-permission-for-comic/{comicSEOAlias}")]
        public async Task<IActionResult> CheckUserPermissionForComic(string comicSEOAlias)
        {
            var result = await _chapterService.CheckUserPermissionForComic(comicSEOAlias);

            return Ok(result);
        }

        [HttpPost("approve-chapter")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> ApproveChapter([FromBody] int chapterId)
        {
            var result = await _chapterService.ApproveChapter(chapterId);
            return Ok(result);
        }

        [HttpPost("reject-chapter/{chapterId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> RejectChapter(int chapterId, [FromBody] string feedback)
        {
            var result = await _chapterService.RejectChapter(chapterId, feedback);
            return Ok(result);
        }
    }
}

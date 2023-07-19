using HikiComic.Application.AuthorInComicDetails;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.AuthorInComicDetails.AuthorInComicDetailRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/author-in-comic-details")]
    [ApiController]
    [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
    public class AuthorInComicDetailsController : ControllerBase
    {

        private readonly IAuthorInComicDetailService _authorInComicDetailService;

        public AuthorInComicDetailsController(IAuthorInComicDetailService authorInComicDetailService)
        {
            _authorInComicDetailService = authorInComicDetailService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAuthorInComicDetail(CreateAuthorInComicDetailRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("AuthorInComicDetail")));

            var result = await _authorInComicDetailService.CreateAuthorInComicDetail(request);

            return Ok(result);
        }

        [HttpDelete("delete/{authorId}/{comicDetailId}")]
        public async Task<IActionResult> DeleteAuthorInComicDetail(int authorId, int comicDetailId)
        {
            var result = await _authorInComicDetailService.DeleteAuthorInComicDetail(authorId, comicDetailId);

            return Ok(result);
        }
    }
}

using HikiComic.Application.GenreInComicDetails;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.GenreInComicDetails.GenreInComicDetailDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/genre-in-comic-details")]
    [ApiController]
    public class GenreInComicDetailsController : ControllerBase
    {
        private readonly IGenreInComicDetailService _genreInComicDetailService;

        public GenreInComicDetailsController(IGenreInComicDetailService genreInComicDetailService)
        {
            _genreInComicDetailService = genreInComicDetailService;
        }

        [HttpPost("create")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> CreateGenreInComicDetail(CreateGenreInComicDetailRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Create Genre In Comic Detail") });

            var result = await _genreInComicDetailService.CreateGenreInComicDetail(request);

            return Ok(result);
        }

        [HttpDelete("delete/{genreId}/{comicDetailId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> DeleteGenreInComicDetail(int genreId, int comicDetailId)
        {
            var result = await _genreInComicDetailService.DeleteGenreInComicDetail(genreId, comicDetailId);

            return Ok(result);
        }
    }
}

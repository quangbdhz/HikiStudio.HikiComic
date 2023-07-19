using HikiComic.Application.Genres;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.GenreDetails.GenreDetailDataRequest;
using HikiComic.ViewModels.Genres.GenresDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _genreService.GetAll();
            return Ok(genres);
        }

        [HttpPost("paging-management")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetPagingManagement([FromBody] PagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var genres = await _genreService.GetPagingManagement(request);

            return Ok(genres);
        }

        [HttpGet("get-genre-by-genre-id/{genreId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int genreId)
        {
            var genre = await _genreService.GetGenreByGenreId(genreId);

            if (genre is null)
                return NotFound();

            return Ok(genre);
        }

        [HttpGet("get-genre-by-genre-seo-alias/{genreSEOAlias}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGenreByGenreSEOAlias(string genreSEOAlias)
        {
            var genre = await _genreService.GetGenreByGenreSEOAlias(genreSEOAlias);

            if (genre is null)
                return NotFound();

            return Ok(genre);
        }

        [HttpGet("get-genre-by-genre-seo-alias-to-do-update/{genreSEOAlias}")]
        public async Task<IActionResult> GetGenreByGenreSEOAliasToDoUpdate(string genreSEOAlias)
        {
            var genre = await _genreService.GetGenreByGenreSEOAliasToDoUpdate(genreSEOAlias);

            if (!genre.IsSuccessed)
                return BadRequest(genre);

            return Ok(genre);
        }

        [HttpGet("is-show-home")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGenreShowHome()
        {
            var genres = await _genreService.GetGenreShowHome();
            return Ok(genres);
        }

        [HttpPost("create")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> CreateCategrory([FromBody] CreateGenreRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>() { Message = MessageConstants.ModelStateIsNotValid("Create Genre") });

            var result = await _genreService.CreateGenre(request);

            return Ok(result);
        }

        [HttpPut("update/{genreId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreRequest request, int genreId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid("Update Genre") });

            var result = await _genreService.UpdateGenre(request, genreId);

            return Ok(result);
        }

        //[HttpPost("update-summary")]
        //[AllowAnonymous]
        ////[Authorize(Roles = "admin")]
        //public async Task<IActionResult> UpdateDescriptionGenreDetail(UpdateSummaryGenreDetailRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Update Description Genre Detail")));

        //    var result = await _genreService.UpdateSummaryGenreDetail(request);

        //    return Ok(result);
        //}

        [HttpDelete("delete/{genreId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> DeleteGenre(int genreId)
        {
            var result = await _genreService.DeleteObject(genreId);

            return Ok(result);
        }

        [HttpPost("delete-multiple")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> DeleteGenres([FromBody] DeleteGenreRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Genres")));

            return Ok(await _genreService.DeleteObjects(request.GenreIds));
        }

        [HttpPost("restore")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> RestoreDeletedGenre([FromBody] int genreId)
        {
            var result = await _genreService.RestoreDeletedObject(genreId);

            return Ok(result);
        }
    }
}

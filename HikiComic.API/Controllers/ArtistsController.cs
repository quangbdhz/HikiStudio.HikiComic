using HikiComic.Application.Artists;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Artists.ArtistDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/artists")]
    [ApiController]
    [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var artists = await _artistService.GetAll();

            return Ok(artists);
        }

        [HttpPost("paging-management")]
        public async Task<IActionResult> GetPagingManagement([FromBody] PagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var artists = await _artistService.GetPagingManagement(request);

            return Ok(artists);
        }

        [HttpGet("get-artist-by-artist-id/{artistId}")]
        public async Task<IActionResult> GetArtistByArtistId(int artistId)
        {
            var result = await _artistService.GetArtistByArtistId(artistId);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-artist-by-artist-seo-alias/{artistSEOAlias}")]
        public async Task<IActionResult> GetArtistByArtistSEOAlias(string artistSEOAlias)
        {
            var result = await _artistService.GetArtistByArtistSEOAlias(artistSEOAlias);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateArtist(CreateArtistRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>(MessageConstants.ModelStateIsNotValid("Create Artist")));

            var result = await _artistService.CreateObject(request);

            return Ok(result);
        }

        [HttpPut("update/{artistId}")]
        public async Task<IActionResult> UpdateArtist(int artistId, UpdateArtistRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Update Artist")));

            var result = await _artistService.UpdateObject(artistId, request);

            return Ok(result);
        }

        [HttpDelete("delete/{artistId}")]
        public async Task<IActionResult> DeleteArtist(int artistId)
        {
            var result = await _artistService.DeleteObject(artistId);

            return Ok(result);
        }

        [HttpPost("delete-multiple")]
        public async Task<IActionResult> DeleteArtists([FromBody] DeleteArtistsRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete artists")));

            return Ok(await _artistService.DeleteObjects(request.ArtistIds));
        }

        [HttpPost("restore")]
        public async Task<IActionResult> RestoreDeletedArtist([FromBody] int artistId)
        {
            var result = await _artistService.RestoreDeletedObject(artistId);

            return Ok(result);
        }
    }
}

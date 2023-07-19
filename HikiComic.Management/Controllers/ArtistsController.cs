using HikiComic.ApiIntegration.ArtistsAPIClient;
using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Artists.ArtistDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
    [Route("artists")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
    public class ArtistsController : BaseController
    {
        private readonly IArtistAPIClient _artistAPIClient;

        private readonly INotificationAPIClient _notificationAPIClient;

        public ArtistsController(IArtistAPIClient artistAPIClient, INotificationAPIClient notificationAPIClient)
        {
            _artistAPIClient = artistAPIClient;
            _notificationAPIClient = notificationAPIClient;
        }

        private async Task InitNotifications()
        {
            var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForAdminAndTeamMembers(new ViewModels.Common.PagingRequestBase() { PageIndex = 1, PageSize = 7});
            ViewData["Notifications"] = notificationsResult.Items;
        }

        public async Task<IActionResult> Index()
        {
            await InitNotifications();

            return View();
        }

        [HttpPost("get-artists")]
        public async Task<IActionResult> Artists()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var orderBy = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumn = Request.Form[$"columns[{orderBy}][name]"].FirstOrDefault()?.Replace(" ", "");
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var pagingRequest = new PagingRequest()
                {
                    Draw = draw,
                    Start = start,
                    Length = length,
                    SortColumn = sortColumn,
                    SortColumnDirection = sortColumnDirection,
                    SearchValue = searchValue,
                    PageSize = pageSize,
                    Skip = skip,
                    RecordsTotal = recordsTotal
                };

                var data = await _artistAPIClient.GetPagingManagement(pagingRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-artist-by-artist-id/{artistId}")]
        public async Task<IActionResult> GetArtistByArtistId(int artistId)
        {
            var result = await _artistAPIClient.GetArtistByArtistId(artistId);
            return Ok(result);
        }

        [HttpPost("create-artist")]
        public async Task<IActionResult> CreateArtist([FromBody] CreateArtistRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>(MessageConstants.ModelStateIsNotValid("Create Artist")));

            var result = await _artistAPIClient.CreateArtist(request);

            return Ok(result);
        }

        [HttpPut("update-artist/{artistId}")]
        public async Task<IActionResult> UpdateArtist([FromBody] UpdateArtistRequest request, int artistId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Update Artist")));

            var result = await _artistAPIClient.UpdateArtist(artistId, request);

            return Ok(result);
        }

        [HttpDelete("delete-artists")]
        public async Task<IActionResult> DeleteArtists([FromBody] DeleteArtistsRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Artists")));

            var result = await _artistAPIClient.DeleteArtists(request);

            return Ok(result);
        }

        [HttpPost("restore-artist")]
        public async Task<IActionResult> RestoreDeletedArtist([FromBody] int artistId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Restore Artist")));

            var result = await _artistAPIClient.RestoreDeletedArtist(artistId);
            return Ok(result);
        }

    }
}

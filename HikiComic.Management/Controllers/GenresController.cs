using HikiComic.ApiIntegration.GenresAPIClient;
using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Genres.GenresDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
    [Route("genres")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
    public class GenresController : BaseController
    {
        private readonly IGenreAPIClient _genreAPIClient;

        private readonly INotificationAPIClient _notificationAPIClient;

        public GenresController(IGenreAPIClient genreAPIClient, INotificationAPIClient notificationAPIClient)
        {
            _genreAPIClient = genreAPIClient;
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

        [HttpPost("get-genres")]
        public async Task<IActionResult> Genres()
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

                var data = await _genreAPIClient.GetPagingManagement(pagingRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-genre-by-genre-id/{genreId}")]
        public async Task<IActionResult> GetGenreByGenreId(int genreId)
        {
            var result = await _genreAPIClient.GetGenreByGenreId(genreId);
            return Ok(result);
        }

        [HttpPost("create-genre")]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>(MessageConstants.ModelStateIsNotValid("Create Genre")));

            var result = await _genreAPIClient.CreateGenre(request);

            return Ok(result);
        }

        [HttpPut("update-genre/{genreId}")]
        public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreRequest request, int genreId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Update Genre")));

            var result = await _genreAPIClient.UpdateGenre(genreId, request);

            return Ok(result);
        }

        [HttpDelete("delete-genres")]
        public async Task<IActionResult> DeleteCategories([FromBody] DeleteGenreRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Genres")));

            var result = await _genreAPIClient.DeleteGenre(request);

            return Ok(result);
        }

        [HttpPost("restore-genre")]
        public async Task<IActionResult> RestoreGenre([FromBody] int genreId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Restore Genre")));

            if (genreId < 1)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Genre")));

            var result = await _genreAPIClient.RestoreDeletedGenre(genreId);
            return Ok(result);
        }
    }
}

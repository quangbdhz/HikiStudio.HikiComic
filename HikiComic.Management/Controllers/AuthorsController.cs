using HikiComic.ApiIntegration.AuthorsAPIClient;
using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Authors.AuthorDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
    [Route("authors")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
    public class AuthorsController : BaseController
    {
        private readonly IAuthorAPIClient _authorAPIClient;

        private readonly INotificationAPIClient _notificationAPIClient;

        public AuthorsController(IAuthorAPIClient authorAPIClient, INotificationAPIClient notificationAPIClient)
        {
            _authorAPIClient = authorAPIClient;
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

        [HttpPost("get-authors")]
        public async Task<IActionResult> Authors()
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

                var data = await _authorAPIClient.GetPagingManagement(pagingRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-author-by-author-id/{authorId}")]
        public async Task<IActionResult> GetAuthorByAuthorId(int authorId)
        {
            var result = await _authorAPIClient.GetAuthorByAuthorId(authorId);
            return Ok(result);
        }

        [HttpPost("create-author")]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>(MessageConstants.ModelStateIsNotValid("Create Author")));

            var result = await _authorAPIClient.CreateAuthor(request);

            return Ok(result);
        }

        [HttpPut("update-author/{authorId}")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorRequest request, int authorId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Update Author")));

            var result = await _authorAPIClient.UpdateAuthor(authorId, request);

            return Ok(result);
        }

        [HttpDelete("delete-authors")]
        public async Task<IActionResult> DeleteAuthors([FromBody] DeleteAuthorsRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Authors")));

            var result = await _authorAPIClient.DeleteAuthors(request);

            return Ok(result);
        }

        [HttpPost("restore-author")]
        public async Task<IActionResult> RestoreAuthor([FromBody] int authorId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Restore Author")));

            var result = await _authorAPIClient.RestoreDeletedAuthor(authorId);
            return Ok(result);
        }
    }
}

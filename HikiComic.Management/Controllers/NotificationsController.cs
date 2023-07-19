using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Notifications.NotificationsDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
    [Route("notifications")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
    public class NotificationsController : BaseController
    {
        private readonly INotificationAPIClient _notificationAPIClient;

        public NotificationsController(INotificationAPIClient notificationAPIClient)
        {
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

        [HttpPost("get-notifications")]
        public async Task<IActionResult> Notifications()
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

                var data = await _notificationAPIClient.GetPagingManagement(pagingRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-notification-by-notification-id/{notificationId}")]
        public async Task<IActionResult> GetNotificationByNotificationId(int notificationId)
        {
            var result = await _notificationAPIClient.GetNotificationByNotificationId(notificationId);
            return Ok(result);
        }

        [HttpPost("create-notification")]
        public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>(MessageConstants.ModelStateIsNotValid("Create Notification")));

            var result = await _notificationAPIClient.CreateNotification(request);

            return Ok(result);
        }

        [HttpPut("update-notification/{notificationId}")]
        public async Task<IActionResult> UpdateNotification([FromBody] UpdateNotificationRequest request, int notificationId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Update Notification")));

            var result = await _notificationAPIClient.UpdateNotification(request, notificationId);

            return Ok(result);
        }

        [HttpDelete("delete-notifications")]
        public async Task<IActionResult> DeleteArtists([FromBody] DeleteNotificationRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Notifications")));

            var result = await _notificationAPIClient.DeleteNotifications(request);

            return Ok(result);
        }

        [HttpPost("restore-notification")]
        public async Task<IActionResult> RestoreNotification([FromBody] int notificationId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Restore Author")));

            var result = await _notificationAPIClient.RestoreNotification(notificationId);
            return Ok(result);
        }
    }
}

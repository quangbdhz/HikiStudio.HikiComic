using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.ApiIntegration.UserRoleUpgradeExchangesAPIClient;
using HikiComic.ApiIntegration.UserRoleUpgradeRequestsAPIClient;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserRoleUpgradeExchanges.UserRoleUpgradeExchangeDataRequest;
using HikiComic.ViewModels.UserRoleUpgradeRequests.UserRoleUpgradeRequestDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
    [Route("creator-requests")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
    public class CreatorRequestsController : BaseController
    {
        private readonly IUserRoleUpgradeRequestAPIClient _userRoleUpgradeRequestAPIClient;

        private readonly IUserRoleUpgradeExchangeAPIClient _userRoleUpgradeExchangeAPIClient;

        private readonly INotificationAPIClient _notificationAPIClient;

        public CreatorRequestsController(IUserRoleUpgradeRequestAPIClient userRoleUpgradeRequestAPIClient, IUserRoleUpgradeExchangeAPIClient userRoleUpgradeExchangeAPIClient, INotificationAPIClient notificationAPIClient)
        {
            _userRoleUpgradeRequestAPIClient = userRoleUpgradeRequestAPIClient;
            _userRoleUpgradeExchangeAPIClient = userRoleUpgradeExchangeAPIClient;
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

        [HttpPost("get-creators")]
        public async Task<IActionResult> CreatorRequests()
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

                var data = await _userRoleUpgradeRequestAPIClient.GetPagingManagement(pagingRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-user-role-upgrade-request-by-user-role-upgrade-request-id/{userRoleUpgradeRequestId}")]
        public async Task<IActionResult> GetUserRoleUpgradeRequestByUserRoleUpgradeRequestId(int userRoleUpgradeRequestId)
        {
            var result = await _userRoleUpgradeRequestAPIClient.GetUserRoleUpgradeRequestByUserRoleUpgradeRequestId(userRoleUpgradeRequestId);
            return Ok(result);
        }

        [HttpGet("get-exchanges/{userRoleUpgradeRequestId}")]
        public async Task<IActionResult> GetUserRoleUpgradeExchangeByUserRoleUpgradeRequestId(int userRoleUpgradeRequestId)
        {
            var result = await _userRoleUpgradeExchangeAPIClient.GetUserRoleUpgradeExchangeByUserRoleUpgradeRequestId(userRoleUpgradeRequestId);

            return Ok(result);
        }

        [HttpPost("create-exchange")]
        public async Task<IActionResult> CreateExchange([FromBody] CreateUserRoleUpgradeExchangeRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(CreateUserRoleUpgradeExchangeRequest)) });

            var result = await _userRoleUpgradeExchangeAPIClient.CreateUserRoleUpgradeExchange(request);

            return Ok(result);
        }

        [HttpPost("change-status")]
        public async Task<IActionResult> ChangeStatus([FromBody] CreateUserRoleUpgradeRequestRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(CreateUserRoleUpgradeRequestRequest)) });

            var result = await _userRoleUpgradeRequestAPIClient.ChangeApprovalStatusUserRoleUpgradeRequest(request);

            return Ok(result);
        }
    }
}

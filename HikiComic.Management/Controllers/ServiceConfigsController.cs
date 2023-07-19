using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.ApiIntegration.ServiceConfigsAPIClient;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ServiceConfigs.ServiceConfigDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
    [Route("service-configs")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminPolicy)]
    public class ServiceConfigsController : BaseController
    {
        private readonly IServiceConfigAPIClient _serviceConfigAPIClient;

        private readonly INotificationAPIClient _notificationAPIClient;

        public ServiceConfigsController(IServiceConfigAPIClient serviceConfigAPIClient, INotificationAPIClient notificationAPIClient)
        {
            _serviceConfigAPIClient = serviceConfigAPIClient;
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

        [HttpPost("get-service-configs")]
        public async Task<IActionResult> ServiceConfigs()
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

                var data = await _serviceConfigAPIClient.GetPagingManagement(pagingRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("get-service-config-by-service-config-id/{serviceConfigId}")]
        public async Task<IActionResult> GetServiceConfigByServiceConfigId(int serviceConfigId)
        {
            var result = await _serviceConfigAPIClient.GetServiceConfigByServiceConfigId(serviceConfigId);
            return Ok(result);
        }

        [HttpPut("update-service-config/{serviceConfigId}")]
        public async Task<IActionResult> UpdateServiceConfig([FromBody] UpdateServiceConfigRequest request, int serviceConfigId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Update ServiceConfig")));

            var result = await _serviceConfigAPIClient.UpdateServiceConfig(serviceConfigId, request);

            return Ok(result);
        }
    }
}

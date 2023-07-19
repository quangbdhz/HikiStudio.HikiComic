using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.ApiIntegration.ServicePriceConfigsAPIClient;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ServicePriceConfigs.ServicePriceConfigDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
    [Route("service-price-configs")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminPolicy)]
    public class ServicePriceConfigsController : BaseController
    {
        private readonly IServicePriceConfigAPIClient _servicePriceConfigAPIClient;

        private readonly INotificationAPIClient _notificationAPIClient;

        public ServicePriceConfigsController(IServicePriceConfigAPIClient servicePriceConfigAPIClient, INotificationAPIClient notificationAPIClient)
        {
            _servicePriceConfigAPIClient = servicePriceConfigAPIClient;
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

        [HttpPost("get-service-price-configs")]
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

                var data = await _servicePriceConfigAPIClient.GetPagingManagement(pagingRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get-service-price-config-by-service-price-config-id/{servicePriceConfigId}")]
        public async Task<IActionResult> GetServicePriceConfigByServicePriceConfigId(int servicePriceConfigId)
        {
            var result = await _servicePriceConfigAPIClient.GetServicePriceConfigByServicePriceConfigId(servicePriceConfigId);
            return Ok(result);
        }

        [HttpPut("update-service-price-config/{servicePriceConfigId}")]
        public async Task<IActionResult> UpdateServicePriceConfig([FromBody] UpdateServicePriceConfigRequest request, int servicePriceConfigId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Update ServicePriceConfig")));

            var result = await _servicePriceConfigAPIClient.UpdateServicePriceConfig(servicePriceConfigId, request);

            return Ok(result);
        }
    }
}

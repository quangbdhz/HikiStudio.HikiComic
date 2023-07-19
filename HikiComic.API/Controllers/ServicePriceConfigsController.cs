using HikiComic.Application.ServicePrices;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ServicePriceConfigs.ServicePriceConfigDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/service-price-configs")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminPolicy)]
    [ApiController]
    public class ServicePriceConfigsController : ControllerBase
    {
        private readonly IServicePriceService _servicePriceService;

        public ServicePriceConfigsController(IServicePriceService servicePriceService)
        {
            _servicePriceService = servicePriceService;
        }

        [HttpGet("get-usage-coins-read-comic")]
        [AllowAnonymous]
        public async Task<IActionResult> UsageCoinsReadComic()
        {
            var result = await _servicePriceService.UsageCoinsReadComic();

            return Ok(result);
        }

        [HttpPost("paging-management")]
        public async Task<IActionResult> GetPagingManagement([FromBody] PagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var artists = await _servicePriceService.GetPagingManagement(request);

            return Ok(artists);
        }

        [HttpGet("get-service-price-config-by-service-price-config-id/{servicePriceConfigId}")]
        public async Task<IActionResult> GetServiceConfigByServiceConfigId(int servicePriceConfigId)
        {
            var result = await _servicePriceService.GetServicePriceConfigByServicePriceConfigId(servicePriceConfigId);

            return Ok(result);
        }

        [HttpPut("update/{servicePriceConfigId}")]
        public async Task<IActionResult> Update(int servicePriceConfigId, UpdateServicePriceConfigRequest request)
        {
            var result = await _servicePriceService.UpdateServicePriceConfig(servicePriceConfigId, request);

            return Ok(result);
        }
    }
}

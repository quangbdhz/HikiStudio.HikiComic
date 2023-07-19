using HikiComic.Application.ServiceConfigs;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ServiceConfigs.ServiceConfigDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace HikiComic.API.Controllers
{
    [Route("api/service-configs")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
    [ApiController]
    public class ServiceConfigsController : ControllerBase
    {
        private readonly IServiceConfigService _serviceConfigService;

        public ServiceConfigsController(IServiceConfigService serviceConfigService)
        {
            _serviceConfigService = serviceConfigService;
        }

        [HttpPost("paging-management")]
        public async Task<IActionResult> GetPagingManagement([FromBody] PagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var artists = await _serviceConfigService.GetPagingManagement(request);

            return Ok(artists);
        }

        [HttpGet("get-service-config-by-service-config-id/{serviceConfigId}")]
        public async Task<IActionResult> GetServiceConfigByServiceConfigId(int serviceConfigId)
        {
            var result = await _serviceConfigService.GetServiceConfigByServiceConfigId(serviceConfigId);

            return Ok(result);
        }

        [HttpPut("update/{serviceConfigId}")]
        public async Task<IActionResult> Update(int serviceConfigId, UpdateServiceConfigRequest request)
        {
            var result = await _serviceConfigService.UpdateServiceConfig(serviceConfigId, request);

            return Ok(result);
        }
    }
}

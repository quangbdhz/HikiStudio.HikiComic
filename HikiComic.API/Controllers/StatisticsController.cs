using HikiComic.Application.Statistics;
using HikiComic.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{

    [Route("api/statistics")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet("dashboard")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> Dashboard()
        {
            var result = await _statisticsService.StatisticalForDashboard();

            return Ok(result);
        }

        [HttpGet("register-user-by-year/{year}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> StatisticalRegisterUserByYear(int year)
        {
            var result = await _statisticsService.StatisticalRegisterUserByYear(year);

            return Ok(result);
        }

        [HttpGet("create-comic-by-year/{year}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> StatisticalCreateComicByYear(int year)
        {
            var result = await _statisticsService.StatisticalCreateComicByYear(year);

            return Ok(result);
        }

        [HttpGet("dob-user-by-age")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> StatisticsDOBUserByAge()
        {
            var result = await _statisticsService.StatisticsDOBUserByAge();

            return Ok(result);
        }

        [HttpGet("by-day")]
        [Authorize]
        public IActionResult StatisticsReadComicByDay()
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest();

            Guid userId = new Guid(getClaimUserId);

            var result = _statisticsService.StatisticsReadComicByDay(userId);

            return Ok(result);
        }
    }
}

using HikiComic.Application.StatisticsReportForAdmins;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/statistics-report-for-admins")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
    [ApiController]
    public class StatisticsReportForAdminsController : ControllerBase
    {
        private readonly IStatisticsReportForAdminService _statisticsReportForAdminService;

        public StatisticsReportForAdminsController(IStatisticsReportForAdminService statisticsReportForAdminService)
        {
            _statisticsReportForAdminService = statisticsReportForAdminService;
        }

        [HttpGet("top-creator-comic-most-coin/{statisticsEnum}/{numberOfCreators}")]
        public async Task<IActionResult> AdminTopCreatorComicMostCoin(StatisticsEnum statisticsEnum, int numberOfCreators = 10)
        {
            var result = await _statisticsReportForAdminService.AdminTopCreatorComicMostCoin(numberOfCreators, statisticsEnum);

            return Ok(result);
        }

        [HttpGet("top-creator-comic-most-viewed/{numberOfCreators}")]
        public async Task<IActionResult> AdminTopCreatorComicMostViewed(int numberOfCreators = 10)
        {
            var result = await _statisticsReportForAdminService.AdminTopCreatorComicMostViewed(numberOfCreators);

            return Ok(result);
        }

        [HttpGet("top-reader-deposit-coin/{statisticsEnum}/{numberOfReaders}")]
        public async Task<IActionResult> AdminTopReaderDepositCoin(StatisticsEnum statisticsEnum, int numberOfReaders = 10)
        {
            var result = await _statisticsReportForAdminService.AdminTopReaderDepositCoin(numberOfReaders, statisticsEnum);

            return Ok(result);
        }

        [HttpGet("top-reader-usage-coin/{statisticsEnum}/{numberOfReaders}")]
        public async Task<IActionResult> AdminTopReaderUsageCoin(StatisticsEnum statisticsEnum, int numberOfReaders = 10)
        {
            var result = await _statisticsReportForAdminService.AdminTopReaderUsageCoin(numberOfReaders, statisticsEnum);

            return Ok(result);
        }

        [HttpGet("card")]
        public async Task<IActionResult> AdminCard()
        {
            var result = await _statisticsReportForAdminService.AdminCard();

            return Ok(result);
        }

        [HttpGet("dob-user-group-age")]
        public async Task<IActionResult> AdminDOBUserByAge()
        {
            var result = await _statisticsReportForAdminService.AdminDOBUserByAge();

            return Ok(result);
        }

        [HttpGet("genders")]
        [AllowAnonymous]
        public async Task<IActionResult> AdminGroupGenders()
        {
            var result = await _statisticsReportForAdminService.AdminGroupGenders();

            return Ok(result);
        }

        [HttpGet("error-genders")]
        public async Task<IActionResult> AdminGenders()
        {
            var result = await _statisticsReportForAdminService.AdminGenders();

            return Ok(result);
        }

        [HttpGet("created-comic-by-year/{year}")]
        public async Task<IActionResult> AdminCreatedComicByYear(int year)
        {
            var result = await _statisticsReportForAdminService.AdminCreatedComicByYear(year);

            return Ok(result);
        }

        [HttpGet("register-user-by-year/{year}")]
        public async Task<IActionResult> AdminRegisterUserByYear(int year)
        {
            var result = await _statisticsReportForAdminService.AdminRegisterUserByYear(year);

            return Ok(result);
        }
    }
}

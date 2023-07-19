using HikiComic.Application.StatisticsReportForCreators;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.API.Controllers
{
    [Route("api/statistics-report-for-creators")]
    [Authorize(Policy = SystemConstants.AppSettings.CreatorPolicy)]
    [ApiController]
    public class StatisticsReportForCreatorsController : ControllerBase
    {
        private readonly IStatisticsReportForCreatorService _statisticsReportForCreatorService;

        public StatisticsReportForCreatorsController(IStatisticsReportForCreatorService statisticsReportForCreatorService)
        {
            _statisticsReportForCreatorService = statisticsReportForCreatorService;
        }

        [HttpGet("created-comics")]
        public async Task<IActionResult> CreatorCreatedComics()
        {
            var result = await _statisticsReportForCreatorService.CreatorCreatedComics();

            return Ok(result);
        }

        [HttpGet("top-comic-most-viewed/{numberOfComics}")]
        public async Task<IActionResult> CreatorTopComicMostViewed(int numberOfComics)
        {
            var result = await _statisticsReportForCreatorService.CreatorTopComicMostViewed(numberOfComics);

            return Ok(result);
        }


        [HttpGet("top-comic-most-followed/{numberOfComics}")]
        public async Task<IActionResult> CreatorTopComicMostFollowed(int numberOfComics)
        {
            var result = await _statisticsReportForCreatorService.CreatorTopComicMostFollowed(numberOfComics);

            return Ok(result);
        }

        [HttpGet("top-most-bought-comics/{numberOfComics}")]
        public async Task<IActionResult> CreatorTopMostBoughtComics(int numberOfComics)
        {
            var result = await _statisticsReportForCreatorService.CreatorTopMostBoughtComics(numberOfComics);

            return Ok(result);
        }

        [HttpGet("top-user-buy-comics/{numberOfComics}")]
        public async Task<IActionResult> CreatorTopUserByComics(int numberOfComics)
        {
            var result = await _statisticsReportForCreatorService.CreatorTopUserByComics(numberOfComics);

            return Ok(result);
        }

        [HttpGet("card")]
        public async Task<IActionResult> CreatorCard()
        {
            var result = await _statisticsReportForCreatorService.CreatorCard();

            return Ok(result);
        }

        [HttpGet("revenue/{statistics}")]
        public async Task<IActionResult> CreatorRevenueByOption(StatisticsEnum statistics)
        {
            var result = await _statisticsReportForCreatorService.CreatorRevenueByOption(statistics);

            return Ok(result);
        }
    }
}

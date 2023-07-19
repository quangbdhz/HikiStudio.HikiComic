using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.ApiIntegration.StatisticsAPIClient;
using HikiComic.ApiIntegration.StatisticsReportForAdminsAPIClient;
using HikiComic.ApiIntegration.StatisticsReportForCreatorsAPIClient;
using HikiComic.Management.Models;
using HikiComic.Management.Services;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.StatisticsReportForAdmins;
using HikiComic.ViewModels.StatisticsReportForCreators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HikiComic.Management.Controllers
{
    [Route("")]
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStatisticsAPIClient _statisticsAPIClient;

        private readonly IPolicyAuthorize _policyAuthorize;

        private readonly IStatisticsReportForCreatorAPIClient _statisticsReportForCreatorAPIClient;

        private readonly IStatisticsReportForAdminAPIClient _statisticsReportForAdminAPIClient;

        private readonly INotificationAPIClient _notificationAPIClient;

        public HomeController(ILogger<HomeController> logger, IStatisticsAPIClient statisticsAPIClient, IPolicyAuthorize policyAuthorize, INotificationAPIClient notificationAPIClient,
            IStatisticsReportForCreatorAPIClient statisticsReportForCreatorAPIClient, IStatisticsReportForAdminAPIClient statisticsReportForAdminAPIClient)
        {
            _logger = logger;
            _statisticsAPIClient = statisticsAPIClient;
            _policyAuthorize = policyAuthorize;
            _statisticsReportForCreatorAPIClient = statisticsReportForCreatorAPIClient;
            _statisticsReportForAdminAPIClient = statisticsReportForAdminAPIClient;
            _notificationAPIClient = notificationAPIClient;
        }

        private async Task InitNotifications()
        {
            var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForAdminAndTeamMembers(new ViewModels.Common.PagingRequestBase() { PageIndex = 1, PageSize = 7});
            ViewData["Notifications"] = notificationsResult.Items;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var policy = _policyAuthorize.GetPolicyOfUser(true);

            switch (policy)
            {
                case PolicyEnum.AdminPolicy:
                    return RedirectToAction("HomeAdmin", "Home");
                case PolicyEnum.TeamMembersPolicy:
                    return RedirectToAction("HomeTeamMember", "Home");
                case PolicyEnum.CreatorPolicy:
                    return RedirectToAction("HomeCreator", "Home");
                default:
                    return RedirectToAction("Login", "Auth");
            }
        }

        #region for creator
        [HttpGet("home-creator")]
        [Authorize(Policy = SystemConstants.AppSettings.CreatorPolicy)]
        public async Task<IActionResult> HomeCreator()
        {
            var cardResult = await _statisticsReportForCreatorAPIClient.CreatorCard();
            if (cardResult is null || !cardResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var followedResult = await _statisticsReportForCreatorAPIClient.CreatorTopComicMostFollowed(5);
            if (followedResult is null || !followedResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var viewedResult = await _statisticsReportForCreatorAPIClient.CreatorTopComicMostViewed(5);
            if (viewedResult is null || !viewedResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var topUsersResult = await _statisticsReportForCreatorAPIClient.CreatorTopUserByComics(5);
            if (topUsersResult is null || !topUsersResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForCreator(new ViewModels.Common.PagingRequestBase() { PageIndex = 1, PageSize = 7});
            ViewData["Notifications"] = notificationsResult.Items;

            var creatorStatisticsReport = new CreatorStatisticsReportViewModel();
            creatorStatisticsReport.Card = cardResult.ResultObj;
            creatorStatisticsReport.ComicMostFollowed = followedResult.ResultObj;
            creatorStatisticsReport.ComicMostViewed = viewedResult.ResultObj;
            creatorStatisticsReport.TopUserBuyComics = topUsersResult.ResultObj;

            return View(creatorStatisticsReport);
        }

        [HttpGet("revenue/{statistics}")]
        public async Task<IActionResult> CreatorRevenueByOption(StatisticsEnum statistics)
        {
            var result = await _statisticsReportForCreatorAPIClient.CreatorRevenueByOption(statistics);

            return Ok(result);
        }

        [HttpGet("created-comics")]
        public async Task<IActionResult> CreatorCreatedComics()
        {
            var result = await _statisticsReportForCreatorAPIClient.CreatorCreatedComics();

            return Ok(result);
        }

        [HttpGet("top-comic-most-viewed/{numberOfComics}")]
        public async Task<IActionResult> CreatorTopComicMostViewed(int numberOfComics)
        {
            var result = await _statisticsReportForCreatorAPIClient.CreatorTopComicMostViewed(numberOfComics);

            return Ok(result);
        }


        [HttpGet("top-comic-most-followed/{numberOfComics}")]
        public async Task<IActionResult> CreatorTopComicMostFollowed(int numberOfComics)
        {
            var result = await _statisticsReportForCreatorAPIClient.CreatorTopComicMostFollowed(numberOfComics);

            return Ok(result);
        }

        [HttpGet("top-most-bought-comics/{numberOfComics}")]
        public async Task<IActionResult> CreatorTopMostBoughtComics(int numberOfComics)
        {
            var result = await _statisticsReportForCreatorAPIClient.CreatorTopMostBoughtComics(numberOfComics);

            return Ok(result);
        }

        [HttpGet("top-user-buy-comics/{numberOfComics}")]
        public async Task<IActionResult> CreatorTopUserByComics(int numberOfComics)
        {
            var result = await _statisticsReportForCreatorAPIClient.CreatorTopUserByComics(numberOfComics);

            return Ok(result);
        }
        #endregion

        #region for admin and teammembers
        [HttpGet("home-team-memeber")]
        [Authorize(Policy = SystemConstants.AppSettings.TeamMembersPolicy)]
        public async Task<IActionResult> HomeTeamMember()
        {
            await InitNotifications();

            var cardResult = await _statisticsReportForAdminAPIClient.AdminCard();
            if (cardResult is null || !cardResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            //deposit coin
            var topReaderDepositCoinByDayResult = await _statisticsReportForAdminAPIClient.AdminTopReaderDepositCoin(10, StatisticsEnum.Day);
            if (topReaderDepositCoinByDayResult is null || !topReaderDepositCoinByDayResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var topReaderDepositCoinByMonthResult = await _statisticsReportForAdminAPIClient.AdminTopReaderDepositCoin(10, StatisticsEnum.Month);
            if (topReaderDepositCoinByMonthResult is null || !topReaderDepositCoinByMonthResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var topReaderDepositCoinByYearResult = await _statisticsReportForAdminAPIClient.AdminTopReaderDepositCoin(10, StatisticsEnum.Year);
            if (topReaderDepositCoinByYearResult is null || !topReaderDepositCoinByYearResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            //usage coin
            var topReaderUsageCoinByDayResult = await _statisticsReportForAdminAPIClient.AdminTopReaderUsageCoin(10, StatisticsEnum.Day);
            if (topReaderUsageCoinByDayResult is null || !topReaderUsageCoinByDayResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var topReaderUsageCoinByMonthResult = await _statisticsReportForAdminAPIClient.AdminTopReaderUsageCoin(10, StatisticsEnum.Month);
            if (topReaderUsageCoinByMonthResult is null || !topReaderUsageCoinByMonthResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var topReaderUsageCoinByYearResult = await _statisticsReportForAdminAPIClient.AdminTopReaderUsageCoin(10, StatisticsEnum.Year);
            if (topReaderUsageCoinByYearResult is null || !topReaderUsageCoinByYearResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");


            //creator most viewed
            var topCreatorComicMostViewedResult = await _statisticsReportForAdminAPIClient.AdminTopCreatorComicMostViewed(10);
            if (topCreatorComicMostViewedResult is null || !topCreatorComicMostViewedResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            //creator most coin
            var topCreatorComicMostCoinByDayResult = await _statisticsReportForAdminAPIClient.AdminTopCreatorComicMostCoin(10, StatisticsEnum.Day);
            if (topCreatorComicMostCoinByDayResult is null || !topCreatorComicMostCoinByDayResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var topCreatorComicMostCoinByMonthResult = await _statisticsReportForAdminAPIClient.AdminTopCreatorComicMostCoin(10, StatisticsEnum.Month);
            if (topCreatorComicMostCoinByMonthResult is null || !topCreatorComicMostCoinByMonthResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var topCreatorComicMostCoinByYearResult = await _statisticsReportForAdminAPIClient.AdminTopCreatorComicMostCoin(10, StatisticsEnum.Year);
            if (topCreatorComicMostCoinByYearResult is null || !topCreatorComicMostCoinByYearResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var adminStatisticsReport = new AdminStatisticsReportViewModel();
            adminStatisticsReport.Card = cardResult.ResultObj;

            adminStatisticsReport.TopReaderDepositCoinByDay = topReaderDepositCoinByDayResult.ResultObj;
            adminStatisticsReport.TopReaderDepositCoinByMonth = topReaderDepositCoinByMonthResult.ResultObj;
            adminStatisticsReport.TopReaderDepositCoinByYear = topReaderDepositCoinByYearResult.ResultObj;

            adminStatisticsReport.TopReaderUsageCoinByDay = topReaderUsageCoinByDayResult.ResultObj;
            adminStatisticsReport.TopReaderUsageCoinByMonth = topReaderUsageCoinByMonthResult.ResultObj;
            adminStatisticsReport.TopReaderUsageCoinByYear = topReaderUsageCoinByYearResult.ResultObj;

            adminStatisticsReport.TopCreatorComicMostViewed = topCreatorComicMostViewedResult.ResultObj;

            adminStatisticsReport.TopCreatorComicMostCoinByDay = topCreatorComicMostCoinByDayResult.ResultObj;
            adminStatisticsReport.TopCreatorComicMostCoinByMonth = topCreatorComicMostCoinByMonthResult.ResultObj;
            adminStatisticsReport.TopCreatorComicMostCoinByYear = topCreatorComicMostCoinByYearResult.ResultObj;

            return View(adminStatisticsReport);
        }

        [HttpGet("home-admin")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminPolicy)]
        public async Task<IActionResult> HomeAdmin()
        {
            await InitNotifications();

            var cardResult = await _statisticsReportForAdminAPIClient.AdminCard();
            if (cardResult is null || !cardResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            //deposit coin
            var topReaderDepositCoinByDayResult = await _statisticsReportForAdminAPIClient.AdminTopReaderDepositCoin(10, StatisticsEnum.Day);
            if (topReaderDepositCoinByDayResult is null || !topReaderDepositCoinByDayResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var topReaderDepositCoinByMonthResult = await _statisticsReportForAdminAPIClient.AdminTopReaderDepositCoin(10, StatisticsEnum.Month);
            if (topReaderDepositCoinByMonthResult is null || !topReaderDepositCoinByMonthResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var topReaderDepositCoinByYearResult = await _statisticsReportForAdminAPIClient.AdminTopReaderDepositCoin(10, StatisticsEnum.Year);
            if (topReaderDepositCoinByYearResult is null || !topReaderDepositCoinByYearResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");


            //usage coin
            var topReaderUsageCoinByDayResult = await _statisticsReportForAdminAPIClient.AdminTopReaderUsageCoin(10, StatisticsEnum.Day);
            if (topReaderUsageCoinByDayResult is null || !topReaderUsageCoinByDayResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var topReaderUsageCoinByMonthResult = await _statisticsReportForAdminAPIClient.AdminTopReaderUsageCoin(10, StatisticsEnum.Month);
            if (topReaderUsageCoinByMonthResult is null || !topReaderUsageCoinByMonthResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var topReaderUsageCoinByYearResult = await _statisticsReportForAdminAPIClient.AdminTopReaderUsageCoin(10, StatisticsEnum.Year);
            if (topReaderUsageCoinByYearResult is null || !topReaderUsageCoinByYearResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");


            //creator most viewed
            var topCreatorComicMostViewedResult = await _statisticsReportForAdminAPIClient.AdminTopCreatorComicMostViewed(10);
            if (topCreatorComicMostViewedResult is null || !topCreatorComicMostViewedResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            //creator most coin
            var topCreatorComicMostCoinByDayResult = await _statisticsReportForAdminAPIClient.AdminTopCreatorComicMostCoin(10, StatisticsEnum.Day);
            if (topCreatorComicMostCoinByDayResult is null || !topCreatorComicMostCoinByDayResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var topCreatorComicMostCoinByMonthResult = await _statisticsReportForAdminAPIClient.AdminTopCreatorComicMostCoin(10, StatisticsEnum.Month);
            if (topCreatorComicMostCoinByMonthResult is null || !topCreatorComicMostCoinByMonthResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var topCreatorComicMostCoinByYearResult = await _statisticsReportForAdminAPIClient.AdminTopCreatorComicMostCoin(10, StatisticsEnum.Year);
            if (topCreatorComicMostCoinByYearResult is null || !topCreatorComicMostCoinByYearResult.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            var adminStatisticsReport = new AdminStatisticsReportViewModel();
            adminStatisticsReport.Card = cardResult.ResultObj;

            adminStatisticsReport.TopReaderDepositCoinByDay = topReaderDepositCoinByDayResult.ResultObj;
            adminStatisticsReport.TopReaderDepositCoinByMonth = topReaderDepositCoinByMonthResult.ResultObj;
            adminStatisticsReport.TopReaderDepositCoinByYear = topReaderDepositCoinByYearResult.ResultObj;

            adminStatisticsReport.TopReaderUsageCoinByDay = topReaderUsageCoinByDayResult.ResultObj;
            adminStatisticsReport.TopReaderUsageCoinByMonth = topReaderUsageCoinByMonthResult.ResultObj;
            adminStatisticsReport.TopReaderUsageCoinByYear = topReaderUsageCoinByYearResult.ResultObj;

            adminStatisticsReport.TopCreatorComicMostViewed = topCreatorComicMostViewedResult.ResultObj;

            adminStatisticsReport.TopCreatorComicMostCoinByDay = topCreatorComicMostCoinByDayResult.ResultObj;
            adminStatisticsReport.TopCreatorComicMostCoinByMonth = topCreatorComicMostCoinByMonthResult.ResultObj;
            adminStatisticsReport.TopCreatorComicMostCoinByYear = topCreatorComicMostCoinByYearResult.ResultObj;

            return View(adminStatisticsReport);
        }

        [HttpGet("top-creator-comic-most-coin/{statisticsEnum}/{numberOfCreators}")]
        public async Task<IActionResult> AdminTopCreatorComicMostCoin(StatisticsEnum statisticsEnum, int numberOfCreators = 10)
        {
            var result = await _statisticsReportForAdminAPIClient.AdminTopCreatorComicMostCoin(numberOfCreators, statisticsEnum);

            return Ok(result);
        }

        [HttpGet("top-creator-comic-most-viewed/{numberOfCreators}")]
        public async Task<IActionResult> AdminTopCreatorComicMostViewed(int numberOfCreators = 10)
        {
            var result = await _statisticsReportForAdminAPIClient.AdminTopCreatorComicMostViewed(numberOfCreators);

            return Ok(result);
        }

        [HttpGet("top-reader-deposit-coin/{statisticsEnum}/{numberOfReaders}")]
        public async Task<IActionResult> AdminTopReaderDepositCoin(StatisticsEnum statisticsEnum, int numberOfReaders = 10)
        {
            var result = await _statisticsReportForAdminAPIClient.AdminTopReaderDepositCoin(numberOfReaders, statisticsEnum);

            return Ok(result);
        }

        [HttpGet("top-reader-usage-coin/{statisticsEnum}/{numberOfReaders}")]
        public async Task<IActionResult> AdminTopReaderUsageCoin(StatisticsEnum statisticsEnum, int numberOfReaders = 10)
        {
            var result = await _statisticsReportForAdminAPIClient.AdminTopReaderUsageCoin(numberOfReaders, statisticsEnum);

            return Ok(result);
        }

        [HttpGet("admin-card")]
        public async Task<IActionResult> AdminCard()
        {
            var result = await _statisticsReportForAdminAPIClient.AdminCard();

            return Ok(result);
        }

        [HttpGet("dob-user-group-age")]
        public async Task<IActionResult> AdminDOBUserByAge()
        {
            var result = await _statisticsReportForAdminAPIClient.AdminDOBUserByAge();

            return Ok(result);
        }

        [HttpGet("group-genders")]
        public async Task<IActionResult> AdminGenders()
        {
            var result = await _statisticsReportForAdminAPIClient.AdminGenders();

            return Ok(result);
        }

        [HttpGet("created-comic-by-year/{year}")]
        public async Task<IActionResult> AdminCreatedComicByYear(int year)
        {
            var result = await _statisticsReportForAdminAPIClient.AdminCreatedComicByYear(year);

            return Ok(result);
        }

        [HttpGet("register-user-by-year/{year}")]
        public async Task<IActionResult> AdminRegisterUserByYear(int year)
        {
            var result = await _statisticsReportForAdminAPIClient.AdminRegisterUserByYear(year);

            return Ok(result);
        }
        #endregion

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.StatisticsReportForAdmins;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.StatisticsReportForAdminsAPIClient
{
    public class StatisticsReportForAdminAPIClient : BaseAPI, IStatisticsReportForAdminAPIClient
    {
        public StatisticsReportForAdminAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<AdminCardViewModel>> AdminCard()
        {
            return await GetAsync<ApiResult<AdminCardViewModel>>($"/api/statistics-report-for-admins/card");
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> AdminCreatedComicByYear(int year)
        {
            return await GetAsync<ApiResult<StatisticsReportBase<int>>>($"/api/statistics-report-for-admins/created-comic-by-year/{year}");
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> AdminDOBUserByAge()
        {
            return await GetAsync<ApiResult<StatisticsReportBase<int>>>($"/api/statistics-report-for-admins/dob-user-group-age");
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> AdminGenders()
        {
            return await GetAsync<ApiResult<StatisticsReportBase<int>>>($"/api/statistics-report-for-admins/genders");
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> AdminRegisterUserByYear(int year)
        {
            return await GetAsync<ApiResult<StatisticsReportBase<int>>>($"/api/statistics-report-for-admins/register-user-by-year/{year}");
        }

        public async Task<ApiResult<List<TopUserViewModel<double>>>> AdminTopCreatorComicMostCoin(int numberOfCreators, StatisticsEnum statisticsEnum)
        {
            return await GetAsync<ApiResult<List<TopUserViewModel<double>>>>($"/api/statistics-report-for-admins/top-creator-comic-most-coin/{statisticsEnum}/{numberOfCreators}");
        }

        public async Task<ApiResult<List<TopUserViewModel<double>>>> AdminTopCreatorComicMostViewed(int numberOfCreators)
        {
            return await GetAsync<ApiResult<List<TopUserViewModel<double>>>>($"/api/statistics-report-for-admins/top-creator-comic-most-viewed/{numberOfCreators}");
        }

        public async Task<ApiResult<List<TopUserCoinViewModel<double>>>> AdminTopReaderDepositCoin(int numberOfReaders, StatisticsEnum statisticsEnum)
        {
            return await GetAsync<ApiResult<List<TopUserCoinViewModel<double>>>>($"/api/statistics-report-for-admins/top-reader-deposit-coin/{statisticsEnum}/{numberOfReaders}");
        }

        public async Task<ApiResult<List<TopUserCoinViewModel<double>>>> AdminTopReaderUsageCoin(int numberOfReaders, StatisticsEnum statisticsEnum)
        {
            return await GetAsync<ApiResult<List<TopUserCoinViewModel<double>>>>($"/api/statistics-report-for-admins/top-reader-usage-coin/{statisticsEnum}/{numberOfReaders}");
        }
    }
}

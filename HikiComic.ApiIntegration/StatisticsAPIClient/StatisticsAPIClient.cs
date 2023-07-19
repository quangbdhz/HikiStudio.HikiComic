using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Statistics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.StatisticsAPIClient
{
    public class StatisticsAPIClient : BaseAPI, IStatisticsAPIClient
    {
        public StatisticsAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) 
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<StatisticalCreateComicByMonthViewModel>> StatisticalCreateComicByYear(int year)
        {
            return await GetAsync<ApiResult<StatisticalCreateComicByMonthViewModel>>($"/api/statistics/create-comic-by-year/{year}");
        }

        public async Task<ApiResult<StatisticsDashboardViewModel>> StatisticalForDashboard()
        {
            return await GetAsync<ApiResult<StatisticsDashboardViewModel>>("/api/statistics/dashboard");
        }

        public async Task<ApiResult<StatisticalRegisterUserByMonthViewModel>> StatisticalRegisterUserByYear(int year)
        {
            return await GetAsync<ApiResult<StatisticalRegisterUserByMonthViewModel>>($"/api/statistics/register-user-by-year/{year}");
        }

        public async Task<ApiResult<StatisticsDOBUserByAgeViewModel>> StatisticsDOBUserByAge()
        {
            return await GetAsync<ApiResult<StatisticsDOBUserByAgeViewModel>>("/api/statistics/dob-user-by-age");
        }

        public async Task<ApiResult<StatisticsReadComicByDayViewModel>> StatisticsReadComicByDay()
        {
            return await GetAsync<ApiResult<StatisticsReadComicByDayViewModel>>("/api/statistics/by-day");
        }
    }
}

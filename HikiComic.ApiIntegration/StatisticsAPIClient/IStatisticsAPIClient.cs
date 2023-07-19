using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Statistics;

namespace HikiComic.ApiIntegration.StatisticsAPIClient
{
    public interface IStatisticsAPIClient
    {
        Task<ApiResult<StatisticsReadComicByDayViewModel>> StatisticsReadComicByDay();

        Task<ApiResult<StatisticsDashboardViewModel>> StatisticalForDashboard();

        Task<ApiResult<StatisticsDOBUserByAgeViewModel>> StatisticsDOBUserByAge();

        Task<ApiResult<StatisticalCreateComicByMonthViewModel>> StatisticalCreateComicByYear(int year);

        Task<ApiResult<StatisticalRegisterUserByMonthViewModel>> StatisticalRegisterUserByYear(int year);

    }
}

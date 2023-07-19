using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Statistics;

namespace HikiComic.Application.Statistics
{
    public interface IStatisticsService
    {
        ApiResult<StatisticsReadComicByDayViewModel> StatisticsReadComicByDay(Guid userId);

        Task<ApiResult<StatisticsDashboardViewModel>> StatisticalForDashboard();

        Task<ApiResult<StatisticsDOBUserByAgeViewModel>> StatisticsDOBUserByAge();

        Task<ApiResult<StatisticalCreateComicByMonthViewModel>> StatisticalCreateComicByYear(int year);

        Task<ApiResult<StatisticalRegisterUserByMonthViewModel>> StatisticalRegisterUserByYear(int year);
    }
}

using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.StatisticsReportForAdmins;

namespace HikiComic.ApiIntegration.StatisticsReportForAdminsAPIClient
{
    public interface IStatisticsReportForAdminAPIClient
    {
        public Task<ApiResult<AdminCardViewModel>> AdminCard();

        public Task<ApiResult<List<TopUserViewModel<double>>>> AdminTopCreatorComicMostViewed(int numberOfCreators);

        public Task<ApiResult<List<TopUserViewModel<double>>>> AdminTopCreatorComicMostCoin(int numberOfCreators, StatisticsEnum statisticsEnum);

        public Task<ApiResult<List<TopUserCoinViewModel<double>>>> AdminTopReaderDepositCoin(int numberOfReaders, StatisticsEnum statisticsEnum);

        public Task<ApiResult<List<TopUserCoinViewModel<double>>>> AdminTopReaderUsageCoin(int numberOfReaders, StatisticsEnum statisticsEnum);

        public Task<ApiResult<StatisticsReportBase<int>>> AdminDOBUserByAge();

        public Task<ApiResult<StatisticsReportBase<int>>> AdminGenders();

        public Task<ApiResult<StatisticsReportBase<int>>> AdminCreatedComicByYear(int year);

        public Task<ApiResult<StatisticsReportBase<int>>> AdminRegisterUserByYear(int year);
    }
}

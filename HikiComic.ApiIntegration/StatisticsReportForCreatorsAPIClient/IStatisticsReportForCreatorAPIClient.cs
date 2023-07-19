using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.StatisticsReportForCreators;

namespace HikiComic.ApiIntegration.StatisticsReportForCreatorsAPIClient
{
    public interface IStatisticsReportForCreatorAPIClient
    {
        public Task<ApiResult<CreatorCardViewModel>> CreatorCard();

        public Task<ApiResult<StatisticsReportBase<int>>> CreatorCreatedComics();

        public Task<ApiResult<StatisticsReportBase<int>>> CreatorTopComicMostViewed(int numberOfComics);

        public Task<ApiResult<StatisticsReportBase<int>>> CreatorTopComicMostFollowed(int numberOfComics);

        public Task<ApiResult<StatisticsReportBase<int>>> CreatorTopMostBoughtComics(int numberOfComics);

        public Task<ApiResult<TopUserByComicViewModel<double>>> CreatorTopUserByComics(int numberOfComics);

        public Task<ApiResult<StatisticsReportBase<double>>> CreatorRevenueByOption(StatisticsEnum statistics);
    }
}

using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.StatisticsReportForCreators;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.StatisticsReportForCreatorsAPIClient
{
    public class StatisticsReportForCreatorAPIClient : BaseAPI, IStatisticsReportForCreatorAPIClient
    {
        public StatisticsReportForCreatorAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) 
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<CreatorCardViewModel>> CreatorCard()
        {
            return await GetAsync<ApiResult<CreatorCardViewModel>>("/api/statistics-report-for-creators/card");
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> CreatorCreatedComics()
        {
            return await GetAsync<ApiResult<StatisticsReportBase<int>>>("/api/statistics-report-for-creators/created-comics");
        }

        public async Task<ApiResult<StatisticsReportBase<double>>> CreatorRevenueByOption(StatisticsEnum statistics)
        {
            return await GetAsync<ApiResult<StatisticsReportBase<double>>>($"/api/statistics-report-for-creators/revenue/{statistics}");
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> CreatorTopComicMostFollowed(int numberOfComics)
        {
            return await GetAsync<ApiResult<StatisticsReportBase<int>>>($"/api/statistics-report-for-creators/top-comic-most-followed/{numberOfComics}");
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> CreatorTopComicMostViewed(int numberOfComics)
        {
            return await GetAsync<ApiResult<StatisticsReportBase<int>>>($"/api/statistics-report-for-creators/top-comic-most-viewed/{numberOfComics}");
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> CreatorTopMostBoughtComics(int numberOfComics)
        {
            return await GetAsync<ApiResult<StatisticsReportBase<int>>>($"/api/statistics-report-for-creators/top-most-bought-comics/{numberOfComics}");
        }

        public async Task<ApiResult<TopUserByComicViewModel<double>>> CreatorTopUserByComics(int numberOfComics)
        {
            return await GetAsync<ApiResult<TopUserByComicViewModel<double>>>($"/api/statistics-report-for-creators/top-user-buy-comics/{numberOfComics}");
        }
    }
}

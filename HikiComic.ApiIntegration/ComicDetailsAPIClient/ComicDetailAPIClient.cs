using HikiComic.ViewModels.ComicDetails;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.ComicDetailsAPIClient
{
    public class ComicDetailAPIClient : BaseAPI, IComicDetailAPIClient
    {
        public ComicDetailAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<ComicDetailViewModel>> GetComicDetailByComicSEOAliasWithAdmin(string comicSEOAlias)
        {
            return await GetAsync<ApiResult<ComicDetailViewModel>>("/api/comic-details/get-comic-detail-by-comic-seo-alias-with-admin/" + comicSEOAlias);
        }

        public async Task<ApiResult<ComicDetailViewModel>> GetComicDetailByComicSEOAliasWithUser(string comicSEOAlias)
        {
            return await GetAsync<ApiResult<ComicDetailViewModel>>("/api/comic-details/get-comic-detail-by-comic-seo-alias-with-user/" + comicSEOAlias);
        }
    }
}

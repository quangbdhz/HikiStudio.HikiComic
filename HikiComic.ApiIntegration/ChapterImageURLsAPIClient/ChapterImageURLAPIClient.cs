using HikiComic.ViewModels.ChapterImageURLs;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.ChapterImageURLsAPIClient
{
    public class ChapterImageURLAPIClient : BaseAPI, IChapterImageURLAPIClient
    {
        public ChapterImageURLAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<ChapterImageURLViewModel>> GetChapterImageURLs(string comicSEOAlias, string chapterSEOAlias)
        {
            return await GetAsync<ApiResult<ChapterImageURLViewModel>>("/api/chapter-image-urls/get-chapter-by-chapter-comic-seo-alias/" + comicSEOAlias + "/" + chapterSEOAlias);
        }
    }
}

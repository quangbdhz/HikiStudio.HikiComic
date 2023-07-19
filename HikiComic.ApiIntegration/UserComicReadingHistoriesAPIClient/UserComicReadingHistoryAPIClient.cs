using HikiComic.ViewModels.Comics;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.UserComicReadingHistoriesAPIClient
{
    public class UserComicReadingHistoryAPIClient : BaseAPI, IUserComicReadingHistoryAPIClient
    {
        public UserComicReadingHistoryAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<PagedResult<ComicViewModel>> GetPagingHistoryReadComicOfUsers(PagingRequestBase request)
        {
            return await GetAsync<PagedResult<ComicViewModel>>($"/api/user-comic-reading-histories/paging?pageindex={request.PageIndex}" +
                $"&pagesize={request.PageSize}");
        }
    }
}

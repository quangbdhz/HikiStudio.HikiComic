using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserComicPurchases;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.UserComicPurchasesAPIClient
{
    public class UserComicPurchaseAPIClient : BaseAPI, IUserComicPurchaseAPIClient
    {
        public UserComicPurchaseAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) 
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<List<UserComicPurchaseViewModel>>> GetUserComicPurchases(Guid userId)
        {
            return await GetAsync<ApiResult<List<UserComicPurchaseViewModel>>>($"/api/user-comic-purchases/get-user-comic-puchases-with-user-id/{userId}");
        }
    }
}

using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Genders;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.GendersAPIClient
{
    public class GenderAPIClient : BaseAPI, IGenderAPIClient
    {
        public GenderAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) 
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<IList<GenderViewModel>>> GetAll()
        {
            return await GetAsync<ApiResult<IList<GenderViewModel>>>("/api/genders/get-all");
        }
    }
}

using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ServiceConfigs;
using HikiComic.ViewModels.ServiceConfigs.ServiceConfigDataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.ServiceConfigsAPIClient
{
    public class ServiceConfigAPIClient : BaseAPI, IServiceConfigAPIClient
    {
        public ServiceConfigAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<PagingResult<ServiceConfigViewModel>> GetPagingManagement(PagingRequest request)
        {
            return await PostAsync<PagingResult<ServiceConfigViewModel>, PagingRequest>(request, $"/api/service-configs/paging-management");
        }

        public async Task<ApiResult<ServiceConfigViewModel>> GetServiceConfigByServiceConfigId(int serviceConfigId)
        {
            return await GetAsync<ApiResult<ServiceConfigViewModel>>($"/api/service-configs/get-service-config-by-service-config-id/{serviceConfigId}");
        }

        public async Task<ApiResult<bool>> UpdateServiceConfig(int serviceConfigId, UpdateServiceConfigRequest request)
        {
            return await PutAsync<ApiResult<bool>, UpdateServiceConfigRequest>(request, $"/api/service-configs/update/{serviceConfigId}");
        }
    }
}

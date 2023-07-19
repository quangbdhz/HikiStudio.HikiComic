using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ServicePriceConfigs;
using HikiComic.ViewModels.ServicePriceConfigs.ServicePriceConfigDataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.ServicePriceConfigsAPIClient
{
    public class ServicePriceConfigAPIClient : BaseAPI, IServicePriceConfigAPIClient
    {
        public ServicePriceConfigAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<PagingResult<ServicePriceConfigViewModel>> GetPagingManagement(PagingRequest request)
        {
            return await PostAsync<PagingResult<ServicePriceConfigViewModel>, PagingRequest>(request, $"/api/service-price-configs/paging-management");
        }

        public async Task<ApiResult<ServicePriceConfigViewModel>> GetServicePriceConfigByServicePriceConfigId(int servicePriceConfigId)
        {
            return await GetAsync<ApiResult<ServicePriceConfigViewModel>>($"/api/service-price-configs/get-service-price-config-by-service-price-config-id/{servicePriceConfigId}");
        }

        public async Task<ApiResult<bool>> UpdateServicePriceConfig(int servicePriceConfigId, UpdateServicePriceConfigRequest request)
        {
            return await PutAsync<ApiResult<bool>, UpdateServicePriceConfigRequest>(request, $"/api/service-price-configs/update/{servicePriceConfigId}");
        }
    }
}

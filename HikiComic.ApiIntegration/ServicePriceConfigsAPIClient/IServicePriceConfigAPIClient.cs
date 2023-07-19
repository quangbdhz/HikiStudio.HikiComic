using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ServicePriceConfigs.ServicePriceConfigDataRequest;
using HikiComic.ViewModels.ServicePriceConfigs;

namespace HikiComic.ApiIntegration.ServicePriceConfigsAPIClient
{
    public interface IServicePriceConfigAPIClient
    {
        public Task<PagingResult<ServicePriceConfigViewModel>> GetPagingManagement(PagingRequest request);

        public Task<ApiResult<ServicePriceConfigViewModel>> GetServicePriceConfigByServicePriceConfigId(int servicePriceConfigId);

        public Task<ApiResult<bool>> UpdateServicePriceConfig(int servicePriceConfigId, UpdateServicePriceConfigRequest request);
    }
}

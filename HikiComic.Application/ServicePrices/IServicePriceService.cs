using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ServicePriceConfigs;
using HikiComic.ViewModels.ServicePriceConfigs.ServicePriceConfigDataRequest;

namespace HikiComic.Application.ServicePrices
{
    public interface IServicePriceService
    {
        public Task<ApiResult<double>> UsageCoinsReadComic();

        public Task<PagingResult<ServicePriceConfigViewModel>> GetPagingManagement(PagingRequest request);

        public Task<ApiResult<ServicePriceConfigViewModel>> GetServicePriceConfigByServicePriceConfigId(int servicePriceConfigId);

        public Task<ApiResult<bool>> UpdateServicePriceConfig(int servicePriceConfigId, UpdateServicePriceConfigRequest request);
    }
}

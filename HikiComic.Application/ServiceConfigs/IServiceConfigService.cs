using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ServiceConfigs;
using HikiComic.ViewModels.ServiceConfigs.ServiceConfigDataRequest;

namespace HikiComic.Application.ServiceConfigs
{
    public interface IServiceConfigService
    {
        Task<PagingResult<ServiceConfigViewModel>> GetPagingManagement(PagingRequest request);

        Task<ApiResult<ServiceConfigViewModel>> GetServiceConfigByServiceConfigId(int serviceConfigId);

        Task<ApiResult<bool>> UpdateServiceConfig(int serviceConfigId, UpdateServiceConfigRequest request);
    }
}

using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ExchangeRate;

namespace HikiComic.Application.ExchangeRate
{
    public interface IExchangeRateService
    {
        public Task<ApiResult<double>> GetExchangeRateByCurrency(string currency);

        public Task<ApiResult<ExchangeRateViewModel>> ExchangeRate(ExchangeRateRequest request);

        public Task<ApiResult<ExchangeRateResponse>> GetExchangeRateAPI();
    }
}

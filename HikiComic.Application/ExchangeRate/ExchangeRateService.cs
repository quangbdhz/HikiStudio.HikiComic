using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ExchangeRate;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HikiComic.Application.ExchangeRate
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IConfiguration _configuration;

        private readonly IMemoryCache _cache;

        public ExchangeRateService(IHttpClientFactory httpClientFactory, IConfiguration configuration, IMemoryCache cache)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _cache = cache;
        }

        public async Task<ApiResult<ExchangeRateViewModel>> ExchangeRate(ExchangeRateRequest request)
        {
            try
            {

                if (!_cache.TryGetValue(SystemConstants.AppSettings.KeyExchangeRate, out ExchangeRateResponse exchangeRate))
                {
                    var result = await GetExchangeRateAPI();

                    if (!result.IsSuccessed)
                        return new ApiErrorResult<ExchangeRateViewModel>();

                    var cacheOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
                    };

                    _cache.Set(SystemConstants.AppSettings.KeyExchangeRate, result.ResultObj, cacheOptions);
                    exchangeRate = result.ResultObj;
                }

                if (exchangeRate.ConversionRates.ContainsKey(request.CurrencyCode) && exchangeRate.ConversionRates.ContainsKey(request.CurrencyCodeDefault))
                {
                    var amount = (request.Amount / exchangeRate.ConversionRates[request.CurrencyCode]) * exchangeRate.ConversionRates[request.CurrencyCodeDefault];

                    return new ApiSuccessResult<ExchangeRateViewModel>() { ResultObj = new ExchangeRateViewModel() 
                    {
                        AmountConverted = Math.Floor(amount),
                        ExchangeRateCurrency = exchangeRate.ConversionRates[request.CurrencyCode],
                        ExchangeRateCurrencyDefault = exchangeRate.ConversionRates[request.CurrencyCodeDefault]
                    } };
                }

                return new ApiErrorResult<ExchangeRateViewModel>() { Message = MessageConstants.AnErrorOccurred };
            }
            catch(Exception ex)
            {
                return new ApiErrorResult<ExchangeRateViewModel>() { Message = ex.Message };
            }
        }

        public async Task<ApiResult<ExchangeRateResponse>> GetExchangeRateAPI()
        {
            var client = _httpClientFactory.CreateClient();
            var url = _configuration["ExchangerateAPI:URL"];

            if (url is null)
                return new ApiErrorResult<ExchangeRateResponse>() { };

            try
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    if (jsonResponse is null)
                        return new ApiResult<ExchangeRateResponse>() { Message = MessageConstants.ObjectNotFound(nameof(ExchangeRate)) };

                    var exchangeRateResponse = JsonConvert.DeserializeObject<ExchangeRateResponse>(jsonResponse);

                    return new ApiSuccessResult<ExchangeRateResponse>() { ResultObj = exchangeRateResponse ?? new ExchangeRateResponse() };
                }
                else
                    return new ApiErrorResult<ExchangeRateResponse>() { Message = MessageConstants.AnErrorOccurred };
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<ExchangeRateResponse>() { Message = ex.Message };
            }
        }

        public async Task<ApiResult<double>> GetExchangeRateByCurrency(string currency)
        {
            try
            {

                if (!_cache.TryGetValue(SystemConstants.AppSettings.KeyExchangeRate, out ExchangeRateResponse exchangeRate))
                {
                    var result = await GetExchangeRateAPI();

                    if (!result.IsSuccessed)
                        return new ApiErrorResult<double>();

                    var cacheOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
                    };

                    _cache.Set(SystemConstants.AppSettings.KeyExchangeRate, result.ResultObj, cacheOptions);
                    exchangeRate = result.ResultObj;
                }

                if (exchangeRate.ConversionRates.ContainsKey(currency))
                {
                    var rate = exchangeRate.ConversionRates[currency];

                    return new ApiSuccessResult<double>(){ResultObj = rate };
                }

                return new ApiErrorResult<double>() { Message = MessageConstants.AnErrorOccurred };
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<double>() { Message = ex.Message };
            }
        }
    }
}

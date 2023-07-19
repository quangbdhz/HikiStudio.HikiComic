using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ServicePriceConfigs;
using HikiComic.ViewModels.ServicePriceConfigs.ServicePriceConfigDataRequest;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HikiComic.Application.ServicePrices
{
    public class ServicePriceService : IServicePriceService
    {
        private readonly HikiComicDbContext _context;

        private readonly IUserContextService _userContextService;

        public ServicePriceService(HikiComicDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task<ApiResult<double>> UsageCoinsReadComic()
        {
            var coinReadComic = await _context.ServicePrices.FirstOrDefaultAsync(x => x.ServicePriceId == (int)ServicePriceEnum.ReadComics);
            if (coinReadComic is null)
                return new ApiErrorResult<double>() { ResultObj = 1000000000, Message = MessageConstants.ObjectNotFound("Read Comics") };

            return new ApiSuccessResult<double>() { ResultObj = coinReadComic.Price };
        }

        private static string ShowLess(string? data)
        {
            if (String.IsNullOrEmpty(data))
                return "";

            if (data.Length > 50)
                return data.Substring(0, 49).TrimEnd() + "...";

            return data;
        }

        public async Task<PagingResult<ServicePriceConfigViewModel>> GetPagingManagement(PagingRequest request)
        {
            var servicePriceConfigs = await _context.ServicePrices.Select(x => new ServicePriceConfigViewModel()
            {
                ServicePriceId = x.ServicePriceId,
                ServicePriceName = x.ServicePriceName,
                Price = x.Price,
                Description = ShowLess(x.Description)
            }).ToListAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                servicePriceConfigs = await _context.ServicePrices.Select(x => new ServicePriceConfigViewModel()
                {
                    ServicePriceId = x.ServicePriceId,
                    ServicePriceName = x.ServicePriceName,
                    Price = x.Price,
                    Description = ShowLess(x.Description)
                }).OrderBy(request.SortColumn + " " + request.SortColumnDirection).ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                servicePriceConfigs = servicePriceConfigs.Where(x => x.ServicePriceName.ToLower().Contains(request.SearchValue.ToLower())).ToList();
            }

            request.RecordsTotal = servicePriceConfigs.Count();
            var data = servicePriceConfigs.Skip(request.Skip).Take(request.PageSize).ToList();

            var jsonData = new { draw = request.Draw, recordsFiltered = request.RecordsTotal, recordsTotal = request.RecordsTotal, data = data };

            var result = new PagingResult<ServicePriceConfigViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = data
            };

            return result;
        }

        public async Task<ApiResult<ServicePriceConfigViewModel>> GetServicePriceConfigByServicePriceConfigId(int servicePriceConfigId)
        {
            var serviceConfig = await _context.ServicePrices.FirstOrDefaultAsync(x => x.ServicePriceId == servicePriceConfigId);
            if (serviceConfig is null)
                return new ApiErrorResult<ServicePriceConfigViewModel>() { Message = MessageConstants.ObjectNotFound("ServicePrice") };

            var servicePriceConfigViewModel = new ServicePriceConfigViewModel()
            {
                ServicePriceId = serviceConfig.ServicePriceId,
                ServicePriceName = serviceConfig.ServicePriceName,
                Price = serviceConfig.Price,
                Description = serviceConfig.Description
            };

            return new ApiSuccessResult<ServicePriceConfigViewModel>() { Message = MessageConstants.GetObjectSuccess("ServicePrice"), ResultObj = servicePriceConfigViewModel };
        }

        public async Task<ApiResult<bool>> UpdateServicePriceConfig(int servicePriceConfigId, UpdateServicePriceConfigRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var serviceConfig = await _context.ServicePrices.FirstOrDefaultAsync(x => x.ServicePriceId == servicePriceConfigId);
            if (serviceConfig is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("ServicePrice") };

            serviceConfig.Price = request.Price;
            serviceConfig.Description = request.Description;
            serviceConfig.DateUpdated = DateTime.Now;
            serviceConfig.UpdatedBy = userResult.ResultObj;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.UpdateSuccess("ServicePrice") };
        }
    }
}

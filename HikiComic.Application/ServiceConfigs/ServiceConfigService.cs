using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ServiceConfigs;
using HikiComic.ViewModels.ServiceConfigs.ServiceConfigDataRequest;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HikiComic.Application.ServiceConfigs
{
    public class ServiceConfigService : IServiceConfigService
    {
        private readonly HikiComicDbContext _context;

        private readonly IUserContextService _userContextService;

        public ServiceConfigService(HikiComicDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task<PagingResult<ServiceConfigViewModel>> GetPagingManagement(PagingRequest request)
        {
            var serviceConfigs = await _context.ServiceConfigs.Select(x => new ServiceConfigViewModel()
            {
                ServiceConfigId = x.ServiceConfigId,
                ServiceConfigName = x.ServiceConfigName,
                Value = x.Value,
                StringValue = x.StringValue,
                Description = x.Description,
                Note = x.Note
            }).ToListAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                serviceConfigs = await _context.ServiceConfigs.Select(x => new ServiceConfigViewModel()
                {
                    ServiceConfigId = x.ServiceConfigId,
                    ServiceConfigName = x.ServiceConfigName,
                    Value = x.Value,
                    StringValue = x.StringValue,
                    Description = ShowLess(x.Description),
                    Note = ShowLess(x.Note)
                }).OrderBy(request.SortColumn + " " + request.SortColumnDirection).ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                serviceConfigs = serviceConfigs.Where(x => x.ServiceConfigName.ToLower().Contains(request.SearchValue.ToLower())).ToList();
            }

            request.RecordsTotal = serviceConfigs.Count();
            var data = serviceConfigs.Skip(request.Skip).Take(request.PageSize).ToList();

            var jsonData = new { draw = request.Draw, recordsFiltered = request.RecordsTotal, recordsTotal = request.RecordsTotal, data = data };

            var result = new PagingResult<ServiceConfigViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = data
            };

            return result;
        }

        private static string ShowLess(string? data)
        {
            if (String.IsNullOrEmpty(data))
                return "";

            if (data.Length > 50)
                return data.Substring(0, 49).TrimEnd() + "...";

            return data;
        }

        public async Task<ApiResult<ServiceConfigViewModel>> GetServiceConfigByServiceConfigId(int serviceConfigId)
        {
            var serviceConfig = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == serviceConfigId);

            if (serviceConfig is null)
                return new ApiErrorResult<ServiceConfigViewModel>() { Message = MessageConstants.ObjectNotFound("ServiceConfig") };

            var serviceConfigViewModel = new ServiceConfigViewModel()
            {
                ServiceConfigId = serviceConfig.ServiceConfigId,
                ServiceConfigName = serviceConfig.ServiceConfigName,
                Value = serviceConfig.Value,
                StringValue = serviceConfig.StringValue,
                Description = serviceConfig.Description,
                Note = serviceConfig.Note
            };

            return new ApiSuccessResult<ServiceConfigViewModel>() { Message = MessageConstants.GetObjectSuccess("ServiceConfig"), ResultObj = serviceConfigViewModel };
        }

        public async Task<ApiResult<bool>> UpdateServiceConfig(int serviceConfigId, UpdateServiceConfigRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var serviceConfig = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == serviceConfigId);

            if (serviceConfig is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("ServiceConfig") };

            serviceConfig.Value = request.Value;
            serviceConfig.Note = request.Note;
            serviceConfig.Description = request.Description;
            serviceConfig.DateUpdated = DateTime.Now;
            serviceConfig.UpdatedBy = userResult.ResultObj;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.UpdateSuccess("ServiceConfig") };
        }
    }
}

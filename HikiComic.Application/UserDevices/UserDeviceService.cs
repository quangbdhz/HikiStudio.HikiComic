using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserDevices;
using HikiComic.ViewModels.UserDevices.UserDeviceDataRequest;
using Microsoft.EntityFrameworkCore;

namespace HikiComic.Application.UserDevices
{
    public class UserDeviceService : IUserDeviceService
    {

        private readonly HikiComicDbContext _context;

        private readonly IUserContextService _userContextService;

        public UserDeviceService(HikiComicDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task<ApiResult<List<UserDeviceViewModel>>> GetAll(Guid userId)
        {
            var userDevices = await _context.AppUserDevices.Where(x => !x.IsDeleted && x.AppUserId == userId).Select(x => new UserDeviceViewModel()
            {
                AppUserDeviceId = x.AppUserDeviceId,
                FCMDeviceToken = x.FCMDeviceToken,
                AppUserId = x.AppUserId,
                DeviceId = x.DeviceId,
                DeviceType = x.DeviceType,
                DeviceName = x.DeviceName,
                DeviceOS = x.DeviceOS,
                DateCreated = x.DateCreated,
                IsDeleted = true
            }).ToListAsync();

            return new ApiSuccessResult<List<UserDeviceViewModel>>() { Message = MessageConstants.GetObjectSuccess("UserDevices"), ResultObj = userDevices };
        }

        public async Task<ApiResult<bool>> CreateUserDevice(CreateUserDeviceRequest request, Guid userId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("User") };

            var checkFCMTokenAlreadyExists = await _context.AppUserDevices.FirstOrDefaultAsync(x => x.FCMDeviceToken == request.FCMDeviceToken && x.AppUserId == userId);
            if (checkFCMTokenAlreadyExists != null)
                return new ApiSuccessResult<bool>() { Message = MessageConstants.ObjectAlreadyExists(nameof(AppUserDevice)) };

            var userDevice = new AppUserDevice()
            {
                AppUserId = userId,
                DeviceId = request.DeviceId,
                FCMDeviceToken = request.FCMDeviceToken,
                DeviceName = request.DeviceName,
                DeviceOS = request.DeviceOS,
                DeviceType = request.DeviceType,
                DateCreated = DateTime.Now,
                IsDeleted = false,
                CreatedBy = userResult.ResultObj
            };

            await _context.AppUserDevices.AddAsync(userDevice);
            await _context.SaveChangesAsync();

            return new ApiResult<bool>() { Message = MessageConstants.CreateSuccess("UserDevice") };
        }

        public async Task<ApiResult<bool>> DeleteUserDevice(int userDeviceId, Guid userId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("User") };

            var userDevice = await _context.AppUserDevices.FirstOrDefaultAsync(x => x.AppUserDeviceId == userDeviceId && x.AppUserId == userId);

            if (userDevice is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("UserDivice") };

            userDevice.IsDeleted = true;
            userDevice.DateUpdated = DateTime.Now;
            userDevice.UpdatedBy = userResult.ResultObj;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess("UserDivice") };
        }

    }
}

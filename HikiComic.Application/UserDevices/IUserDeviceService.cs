using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserDevices;
using HikiComic.ViewModels.UserDevices.UserDeviceDataRequest;

namespace HikiComic.Application.UserDevices
{
    public interface IUserDeviceService
    {
        Task<ApiResult<List<UserDeviceViewModel>>> GetAll(Guid userId);

        public Task<ApiResult<bool>> CreateUserDevice(CreateUserDeviceRequest request, Guid userId);

        public Task<ApiResult<bool>> DeleteUserDevice(int userDeviceId, Guid userId);
    }
}

using HikiComic.ViewModels.Common;

namespace HikiComic.Application.UploadImageCloudinaries
{
    public interface IUploadImageCloudinaryService
    {
        Task<ApiResult<string>> UploadImageCloudinary(Guid userId, byte[] imageData);
    }
}

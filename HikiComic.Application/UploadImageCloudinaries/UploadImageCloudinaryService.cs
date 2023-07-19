using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using HikiComic.Data.EF;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HikiComic.Application.UploadImageCloudinaries
{
    public class UploadImageCloudinaryService : IUploadImageCloudinaryService
    {
        private readonly HikiComicDbContext _context;

        public const string CLOUD_NAME = "https-deptraitd-blogspot-com";

        public const string API_KEY = "935515642992792";

        public const string API_SECRET = "vvVbRs4IqOvQfKNlsPJbyJ3pCCs";


        private readonly Account account;

        private readonly Cloudinary cloudinary;

        public UploadImageCloudinaryService(HikiComicDbContext context)
        {
            _context = context;
            account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);
        }

        public async Task<ApiResult<string>> UploadImageCloudinary(Guid userId, byte[] imageData)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user is null)
                return new ApiErrorResult<string>() { Message = MessageConstants.ObjectNotFound("User") };

            if (user.LockoutEnabled)
                return new ApiErrorResult<string>() { Message = MessageConstants.AccountLocked };

            if (user.IsDeleted)
                return new ApiErrorResult<string>() { Message = MessageConstants.AccountDeleted };

            try
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription("image", new MemoryStream(imageData)),
                    Folder = "HikiComic/AvatarOfUsers"
                };

                var uploadResult = await cloudinary.UploadAsync(uploadParams);

                if (uploadResult.StatusCode == HttpStatusCode.OK)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    user.UserImageURL = uploadResult.SecureUri.ToString();
#pragma warning restore CS0618 // Type or member is obsolete

                    await _context.SaveChangesAsync();

                    return new ApiSuccessResult<string>()
                    {
                        ResultObj = user.UserImageURL,
                        Message = "Great news! Your image was uploaded successfully."
                    };
                }
                else
                {
                    return new ApiErrorResult<string>()
                    {
                        Message = "Sorry, we were unable to upload your image. Please try again later or choose a different image."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<string>()
                {
                    Message = "An error occurred during the image upload: " + ex.Message
                };
            }
        }


    }
}

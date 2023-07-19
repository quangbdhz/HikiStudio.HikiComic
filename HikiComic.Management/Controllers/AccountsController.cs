using HikiComic.ApiIntegration.AccountsAPIClient;
using HikiComic.ApiIntegration.GendersAPIClient;
using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.ApiIntegration.UsersAPIClient;
using HikiComic.Management.Extensions;
using HikiComic.Management.Services;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users;
using HikiComic.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
    [Route("account-settings")]
    [Authorize]
    public class AccountsController : BaseController
    {
        private readonly IUserAPIClient _userAPIClient;

        private readonly IAccountAPIClient _accountAPIClient;

        private readonly IGenderAPIClient _genderAPIClient;

        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly INotificationAPIClient _notificationAPIClient;

        private readonly IPolicyAuthorize _policyAuthorize;

        public AccountsController(IUserAPIClient userAPIClient, IAccountAPIClient accountAPIClient, IPolicyAuthorize policyAuthorize,
            IGenderAPIClient genderAPIClient, IWebHostEnvironment webHostEnvironment, INotificationAPIClient notificationAPIClient)
        {
            _userAPIClient = userAPIClient;
            _accountAPIClient = accountAPIClient;
            _genderAPIClient = genderAPIClient;
            _webHostEnvironment = webHostEnvironment;
            _notificationAPIClient = notificationAPIClient;
            _policyAuthorize = policyAuthorize;
        }

        private async Task InitNotifications()
        {
            var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForAdminAndTeamMembers(new ViewModels.Common.PagingRequestBase() { PageIndex = 1, PageSize = 7});
            ViewData["Notifications"] = notificationsResult.Items;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = HttpContext.Session.Get<UserSession>("CurrentUser");

            if (currentUser == null || currentUser.UserId == Guid.Empty.ToString())
                return RedirectToAction("Login", "Auth");

            var user = await _userAPIClient.GetUserByUserId();

            if (!user.IsSuccessed)
                return RedirectToAction("Login", "Auth");

            if (String.IsNullOrEmpty(user.ResultObj.UserImageURL))
                user.ResultObj.UserImageURL = System.Configuration.ConfigurationManager.AppSettings["PathFolderUploadImageResponse"] + "default.jpg";
            else
            {
                //Check the image exists or not
                var imageUrl = _webHostEnvironment.WebRootPath + System.Configuration.ConfigurationManager.AppSettings["PathFolderUploadImage"] + user.ResultObj.UserImageURL;
                if (!System.IO.File.Exists(imageUrl))
                    user.ResultObj.UserImageURL = System.Configuration.ConfigurationManager.AppSettings["PathFolderUploadImageResponse"] + "default.jpg";
                else
                    user.ResultObj.UserImageURL = System.Configuration.ConfigurationManager.AppSettings["PathFolderUploadImageResponse"] + user.ResultObj.UserImageURL;
            }

            var genders = await _genderAPIClient.GetAll();
            ViewData["genders"] = genders.ResultObj;

            var policy = _policyAuthorize.GetPolicyOfUser();
            if (policy != PolicyEnum.CreatorPolicy)
            {
                await InitNotifications();
            }
            else
            {
                var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForCreator(new ViewModels.Common.PagingRequestBase() { PageIndex = 1, PageSize = 7 });
                ViewData["Notifications"] = notificationsResult.Items;
            }

            return View(user.ResultObj);
        }

        [HttpPost("change-personal-info")]
        public async Task<IActionResult> ChangePersonalInfo([FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<UserViewModel>() { Message = MessageConstants.ModelStateIsNotValid("Update Personal Info") });

            var result = await _userAPIClient.UpdateUser(request);

            return Ok(result);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordUserRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid("Change Password") });

            var result = await _accountAPIClient.ChangePassword(request);

            return Ok(result);
        }

        [HttpPost("change-avatar")]
        public async Task<IActionResult> ChangeAvatar()
        {
            List<string> imageFileExtension = new List<string>() { ".jpg", ".png", ".bmp", ".jpeg" };

            double maximumImageSize = 10;
            double imageSize = 0;

            string? pathFolderUploadImage = System.Configuration.ConfigurationManager.AppSettings["PathFolderUploadImage"];

            if (String.IsNullOrEmpty(pathFolderUploadImage))
                return BadRequest(new ApiErrorResult<string>() { Message = "Image upload folder does not exist." });
                
            string filename = "";
            string fileExtension = "";

            var files = Request.Form.Files;
            int countFile = files.Count;

            if (countFile > 1)
                return BadRequest(new ApiErrorResult<string>("Upload multiple files error."));

            if (countFile < 1)
                return BadRequest(new ApiErrorResult<string>("No files have been uploaded."));

            foreach (var file in files)
            {
                fileExtension = Path.GetExtension(file.FileName);

                imageSize = (file.Length / 1048576.0);

                if (imageSize > maximumImageSize)
                    return BadRequest(new ApiErrorResult<string>("The image file size should be from 1KB to 10 MB and should be the following type file: .png, .jpg, .bmp, .jpeg, maybe transparent background."));

                if (!imageFileExtension.Contains(fileExtension.ToLower()))
                    return BadRequest(new ApiErrorResult<string>("The image file size should be from 1KB to 10 MB and should be the following type file: .png, .jpg, .bmp, .jpeg, maybe transparent background."));

                filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N").Substring(0, 26) + fileExtension;

                using (FileStream output = System.IO.File.Create(GetPathAndFilename(filename, pathFolderUploadImage)))
                    await file.CopyToAsync(output);

                //Call serive: change account avatar
                var changeAvatarUserRequest = new ChangeAvatarUserRequest() { UrlImage = filename };
                var result = await _accountAPIClient.ChangeAvatar(changeAvatarUserRequest);

                if (!result.IsSuccessed)
                    return Ok(result);
            }

            var currentUser = HttpContext.Session.Get<UserSession>("CurrentUser");

            if (currentUser != null)
            {
                currentUser.URLImageUser = System.Configuration.ConfigurationManager.AppSettings["PathFolderUploadImageResponse"] + filename;

                HttpContext.Session.Set<UserSession>("CurrentUser", currentUser);
            }

            return Ok(new ApiSuccessResult<string>() 
            { 
                ResultObj = System.Configuration.ConfigurationManager.AppSettings["PathFolderUploadImageResponse"] + filename, 
                Message = "The update was successful!" 
            });
        }

        private string GetPathAndFilename(string fileName, string pathFolderUploadImage)
        {
            return _webHostEnvironment.WebRootPath + pathFolderUploadImage + fileName;
        }
    }
}

using HikiComic.Application.Accounts;
using HikiComic.Application.UploadImageCloudinaries;
using HikiComic.Application.UserContext;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Accounts;
using HikiComic.ViewModels.Accounts.AccountDataRequest;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users;
using HikiComic.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{
    [Route("api/accounts")]
    [Authorize]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        private readonly IUserContextService _userContextService;

        private readonly IUploadImageCloudinaryService _uploadImageCloudinaryService;

        public AccountsController(IAccountService accountService, IUploadImageCloudinaryService uploadImageCloudinaryService, IUserContextService userContextService)
        {
            _accountService = accountService;
            _uploadImageCloudinaryService = uploadImageCloudinaryService;
            _userContextService = userContextService;
        }

        [HttpGet("my-account-information")]
        public async Task<IActionResult> GetAccountByUserId()
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return BadRequest(userResult.MapToResult<AccountViewModel>());

            var result = await _accountService.GetAccount();

            return Ok(result);
        }

        [HttpGet("get-account-by-user-id/{userId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> GetAccountByUserId(Guid userId)
        {
            if (userId == Guid.Empty)
                return BadRequest(new ApiErrorResult<AccountViewModel>() { Message = MessageConstants.InvalidGuidFormat });

            var result = await _accountService.GetAccountByUserId(userId);

            return Ok(result);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePasswordUser([FromBody] ChangePasswordUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(ChangePasswordUserRequest))});

            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return BadRequest(userResult.MapToResult<bool>());

            var result = await _accountService.ChangePassword(userResult.ResultObj, request);

            return Ok(result);
        }

        [HttpPost("change-avatar")]
        public async Task<IActionResult> ChangeAvatarUser([FromBody] ChangeAvatarUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(ChangeAvatarUserRequest))});

            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return BadRequest(userResult.MapToResult<bool>());

            var result = await _accountService.ChangeAvatar(userResult.ResultObj, request);

            return Ok(result);
        }

        [HttpPost("user-change-avatar")]
        public async Task<IActionResult> UploadImage()
        {
            if (Request.Form.Files.Count == 0)
                return Ok(new ApiErrorResult<string>() { Message = "No files were uploaded." });

            var file = Request.Form.Files[0];
            if (file.Length == 0)
                return Ok(new ApiErrorResult<string>() { Message = "The uploaded file is empty." });

            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return BadRequest(userResult.MapToResult<string>());

            byte[] imageData;
            var stream = file.OpenReadStream();
            var memoryStream = new MemoryStream();

            try
            {
                stream.CopyToAsync(memoryStream).Wait();
                imageData = memoryStream.ToArray();
            }
            finally
            {
                stream.Close();
                memoryStream.Close();
                memoryStream.Dispose();
            }

            var result = await _uploadImageCloudinaryService.UploadImageCloudinary(userResult.ResultObj, imageData);

            return Ok(result);

            //-- Test upload image with URL

            //var imageUrl = "https://i.pinimg.com/originals/1b/cc/0f/1bcc0f161135fd08411b2a6d8caa99e7.jpg";
            //byte[] imageData;
            //using (var client = new WebClient())
            //using (var stream = client.OpenRead(imageUrl))
            //using (var memoryStream = new MemoryStream())
            //{
            //    await stream.CopyToAsync(memoryStream);
            //    imageData = memoryStream.ToArray();
            //}
            //var result = _uploadImageCloudinaryService.UploadImageCloudinary(userId, imageData);
            //return Ok(result);
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _accountService.ResetPassword(request);

            return Ok(result);
        }

        [HttpPost("change-nickname")]
        public async Task<IActionResult> ChangeNickname(string nickname)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return BadRequest(userResult.MapToResult<bool>());

            var result = await _accountService.ChangeNickname(userResult.ResultObj, nickname);

            return Ok(result);
        }

        [HttpPost("send-sms-verification-phone-number")]
        public async Task<IActionResult> SendSMSVerificationPhoneNumber(OTPTypeEnum oTPType)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return BadRequest(userResult.MapToResult<bool>());

            var result = await _accountService.SendSMSVerificationPhoneNumber(userResult.ResultObj, oTPType);

            return Ok(result);
        }

        [HttpPost("create-phone-number")]
        public async Task<IActionResult> CreatePhoneNumber(CreatePhoneNumberRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return BadRequest(userResult.MapToResult<bool>());

            var result = await _accountService.CreatePhoneNumber(request, userResult.ResultObj);

            return Ok(result);
        }

        [HttpPost("verified-phone-number")]
        public async Task<IActionResult> VerificationPhoneNumber(OTPSMSVerificationRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return BadRequest(userResult.MapToResult<bool>());

            var result = await _accountService.VerificationPhoneNumber(request, userResult.ResultObj);

            return Ok(result);
        }

        [HttpPost("verified-phone-number-to-delete")]
        public async Task<IActionResult> VerificationPhoneNumberToDelete(OTPSMSVerificationRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return BadRequest(userResult.MapToResult<bool>());

            var result = await _accountService.VerificationPhoneNumberToDelete(request, userResult.ResultObj);

            return Ok(result);
        }

        [HttpPost("delete-phone-number")]
        public async Task<IActionResult> DeletePhoneNumber()
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return BadRequest(userResult.MapToResult<bool>());

            var result = await _accountService.DeletePhoneNumber(userResult.ResultObj);

            return Ok(result);
        }
    }
}

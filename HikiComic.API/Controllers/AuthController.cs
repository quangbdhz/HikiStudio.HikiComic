using HikiComic.Application.Auth;
using HikiComic.Application.ExchangeRate;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Auth.AuthDataRequest;
using HikiComic.ViewModels.Auth.Token;
using HikiComic.ViewModels.Auth.Token.TokenDataRequest;
using HikiComic.ViewModels.Auth.VerifyDataRequest;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ExchangeRate;
using HikiComic.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;

namespace HikiComic.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        private readonly IExchangeRateService _exchangeRateService;

        public AuthController(IAuthService authService, IExchangeRateService exchangeRateService)
        {
            _authService = authService;
            _exchangeRateService = exchangeRateService;
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test(ExchangeRateRequest request)
        {
            var result = await _exchangeRateService.ExchangeRate(request);

            return Ok(result);
        }

        [NonAction]
        private async Task<ApiResult<bool>> SetRefreshToken(RefreshTokenViewModel newRefreshTokenViewModel, Guid userId)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshTokenViewModel.Expires
            };

            Response.Cookies.Append("RefreshToken", newRefreshTokenViewModel.RefreshToken, cookieOptions);

            var result = await _authService.SetRefreshToken(userId, newRefreshTokenViewModel);

            return result;
        }

        [HttpPost("login-with-third-party")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithThirdParty([FromBody] LoginWithThirdPartyRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<Guid>() { Message = MessageConstants.ModelStateIsNotValid(nameof(LoginWithThirdPartyRequest))});

            var result = await _authService.LoginWithThirdParty(request.AccessToken, (LoginWithThirdPartyEnum) request.LoginWithThirdPartyId);

            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.Login(request);

            if (!result.IsSuccessed)
                return Ok(result);

            RefreshTokenViewModel refreshTokenViewModel = _authService.GenerateRefreshTokenViewModel();

            var refreshToken = await SetRefreshToken(refreshTokenViewModel, result.ResultObj);

            if (!refreshToken.IsSuccessed)
            {
                result.Message = refreshToken.Message;
                return Ok(result);
            }

            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] UserRefreshTokenRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<Guid>() { Message = MessageConstants.ModelStateIsNotValid("User Refresh Token") });

            var resultValidateToken = _authService.ValidateToken(request.AccessToken);

            if (!resultValidateToken.IsSuccessed)
                return Ok(resultValidateToken);

            var result = await _authService.RefreshToken(resultValidateToken.ResultObj, WebUtility.UrlDecode(request.RefreshToken));

            if (!result.IsSuccessed)
                return Ok(result);

            RefreshTokenViewModel refreshTokenViewModel = _authService.GenerateRefreshTokenViewModel();

            var refreshToken = await SetRefreshToken(refreshTokenViewModel, result.ResultObj);

            if (!refreshToken.IsSuccessed)
            {
                result.Message = refreshToken.Message;
                return Ok(result);
            }

            return Ok(result);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.Register(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("user-verify-email")]
        [AllowAnonymous]
        public async Task<IActionResult> UserVerifyEmail(VerifyEmailRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.UserVerifyEmail(request);

            return Ok(result);
        }

        [HttpPost("re-send-email-verification")]
        public async Task<IActionResult> ResendEmailVerification(UserInfoResendEmailVerificationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.ResendEmailVerification(request);

            return Ok(result);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.ForgotPassword(email);

            return Ok(result);
        }

        [HttpPost("user-verify-forgot-password")]
        public async Task<IActionResult> UserVerifyForgotPassword(UserVerifyForgotPasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.UserVerifyForgotPassword(request);

            return Ok(result);
        }


    }
}

using HikiComic.ApiIntegration.UsersAPIClient;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HikiComic.ViewModels.Users;
using HikiComic.Management.Extensions;
using System.Data;
using HikiComic.ViewModels.Common;
using HikiComic.ApiIntegration.AuthAPIClient;
using Microsoft.AspNetCore.Authorization;
using HikiComic.Utilities.Enums;

namespace HikiComic.Management.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserAPIClient _userAPIClient;
        private readonly IAuthAPIClient _authAPIClient;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserAPIClient userAPIClient, IAuthAPIClient authAPIClient, ILogger<AuthController> logger, IConfiguration configuration)
        {
            _userAPIClient = userAPIClient;
            _authAPIClient = authAPIClient;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			HttpContext.Session.Remove("CurrentUser");
			Response.Cookies.Delete("TOKEN", new CookieOptions { HttpOnly = true, Secure = true, SameSite = SameSiteMode.Lax });
			Response.Cookies.Delete("RefreshToken", new CookieOptions { HttpOnly = true, Secure = true });

			return View();
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"] ?? ""));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }

        private UserSession VerifyToken(ClaimsPrincipal claimsPrincipal)
        {
            var urlImageAvatar = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Uri)?.Value;

            var userSession = new UserSession()
            {
                UserName = claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.Name).Value,
                Email = claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.Email).Value,
                UserId = claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value,
                Roles = claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.Role).Value,
                URLImageUser = urlImageAvatar != null && urlImageAvatar.Contains("https://")
                    ? urlImageAvatar
                    : System.Configuration.ConfigurationManager.AppSettings["PathFolderUploadImageResponse"] + urlImageAvatar
            };

            return userSession;
        }

        [HttpPost]
        [Route("login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var result = await _authAPIClient.Login(request);

                if (!result.IsSuccessed)
                    return Ok(result);

                var userPrincipal = this.ValidateToken(result.Message);

                var userSession = VerifyToken(userPrincipal);

                if (userSession.Roles.Contains("admin") || userSession.Roles.Contains("teamMembers") || userSession.Roles.Contains("creator"))
                {
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(24),
                        IsPersistent = request.RememberMe
                    };

                    HttpContext.Session.SetString(SystemConstants.AppSettings.Token, result.Message);

                    Response.Cookies.Append("TOKEN", result.Message, new CookieOptions { HttpOnly = true, Secure = true, SameSite = SameSiteMode.Lax });
                    HttpContext.Session.Set<UserSession>("CurrentUser", userSession);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authProperties);

                    return Ok(result);
                }
                else
                {
                    return Ok(new ApiErrorResult<string>() { Message = "Access Denied, You Don’t Have Permission To Access on This Server" });
                }                
            }
            catch(Exception ex)
            {
                return BadRequest(new ApiErrorResult<string>() { Message = ex.Message });
            }
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Remove("CurrentUser");
            Response.Cookies.Delete("TOKEN", new CookieOptions { HttpOnly = true, Secure = true, SameSite = SameSiteMode.Lax});
			Response.Cookies.Delete("RefreshToken", new CookieOptions { HttpOnly = true, Secure = true });
			return RedirectToAction("Login", "Auth");
        }

        [HttpGet("verify-email")]
        public async Task<IActionResult> VerityEmailAndChangePassword([FromQuery] string token)
        {
            if (String.IsNullOrEmpty(token))
                return RedirectToAction("Index", "Auth");

            token = token.Replace(" ", "+").Replace("\t", "+");

            var result = await _userAPIClient.VerifyTokenEmailConfirmation(token);

            if(result.StatusCode == StatusCodeEnum.EmailVerified)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View(result);
        }

        [HttpPost("user-mail-confirmations")]
        [AllowAnonymous]
        public async Task<IActionResult> UserEmailConfirmations([FromBody] VerifyTokenEmailAndChangePasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(VerifyTokenEmailAndChangePasswordRequest))});

            var result = await _userAPIClient.UserEmailConfirmationAndChangePassword(request);

            return Ok(result);
        }
    }
}

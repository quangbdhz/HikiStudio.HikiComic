using HikiComic.Application.Common;
using HikiComic.Application.SendMails;
using HikiComic.Application.UploadImageCloudinaries;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Auth.LoginWithThirdParty;
using HikiComic.ViewModels.Auth.Token;
using HikiComic.ViewModels.Auth.VerifyDataRequest;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HikiComic.Application.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        private readonly RoleManager<AppRole> _roleManager;

        private readonly IConfiguration _configuration;

        private readonly HikiComicDbContext _context;

        private readonly ISendMailService _sendMailService;

        private readonly ICommonService _commonService;

        private readonly IUploadImageCloudinaryService _uploadImageCloudinaryService;

        public AuthService(HikiComicDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpClientFactory httpClientFactory,
                            RoleManager<AppRole> roleManager, IConfiguration configuration, ISendMailService sendMailService, ICommonService commonService,
                            IUploadImageCloudinaryService uploadImageCloudinaryService)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _sendMailService = sendMailService;
            _commonService = commonService;
            _uploadImageCloudinaryService = uploadImageCloudinaryService;
        }

        public ApiResult<Guid> ValidateToken(string token)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"] ?? ""));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out validatedToken);

            string? stringUserId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(stringUserId))
                return new ApiErrorResult<Guid>() { Message = MessageConstants.ObjectNotFound("Token") };

            Guid userId = new Guid(stringUserId);

            if (userId == Guid.Empty)
                return new ApiErrorResult<Guid>() { Message = MessageConstants.ObjectNotFound("Token") };

            return new ApiSuccessResult<Guid>() { ResultObj = userId, Message = MessageConstants.GetObjectSuccess("UserId") };
        }

        public RefreshTokenViewModel GenerateRefreshTokenViewModel()
        {
            var refreshTokenViewModel = new RefreshTokenViewModel
            {
                RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshTokenViewModel;
        }

        public async Task<ApiResult<bool>> SetRefreshToken(Guid userId, RefreshTokenViewModel refreshTokenViewModel)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("User") };

            user.RefreshToken = refreshTokenViewModel.RefreshToken;
            user.TokenCreated = refreshTokenViewModel.Created;
            user.TokenExpires = refreshTokenViewModel.Expires;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.UpdateSuccess("User Token") };
        }

        public async Task<string> CreateToken(AppUser user)
        {
            if (String.IsNullOrEmpty(user.UserImageURL))
                user.UserImageURL = SystemConstants.AppSettings.UserImageURLDefault;

            string userImageURL = user.UserImageURL != null && user.UserImageURL.Contains("http") ? user.UserImageURL : SystemConstants.AppSettings.URLDomainMyHostProduct + "uploads/user-avatar/" + user.UserImageURL;

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Uri, userImageURL),
                //new Claim(ClaimTypes.Role, string.Join(",",roles)),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"] ?? ""));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
                _configuration["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(10),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ApiResult<Guid>> RefreshToken(Guid userId, string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
                return new ApiErrorResult<Guid>() { Message = MessageConstants.ModelStateIsNotValid("Refresh Token") };

            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user.RefreshToken != refreshToken)
                return new ApiErrorResult<Guid>() { Message = MessageConstants.InvalidRefreshToken };

            if (user.TokenExpires < DateTime.Now)
                return new ApiErrorResult<Guid>() { Message = MessageConstants.TokenExpired };

            string token = await CreateToken(user);

            return new ApiSuccessResult<Guid>() { ResultObj = user.Id, Message = token };
        }

        public async Task<ApiResult<Guid>> Login(UserLoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (user is null)
                return new ApiErrorResult<Guid>(MessageConstants.ObjectNotFound("User"));

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
                return new ApiErrorResult<Guid>() { Message = MessageConstants.IncorrectPassword };

            if (!user.EmailConfirmed)
                return new ApiErrorResult<Guid>() { Message = MessageConstants.EmailUnverified, StatusCode = StatusCodeEnum.EmailNotVerified };

            if (user.LockoutEnabled)
                return new ApiErrorResult<Guid>() { Message = MessageConstants.AccountLocked };

            if (user.IsDeleted)
                return new ApiErrorResult<Guid>() { Message = MessageConstants.AccountDeleted };

            string token = await CreateToken(user);

            return new ApiSuccessResult<Guid>() { Message = token, ResultObj = user.Id };
        }

        #region login with third party
        private async Task<ApiResult<Guid>> UserLoginWithThirdParty(AppUser user, LoginWithThirdPartyEnum loginWithThirdPartyEnum)
        {
            //login -> return jwt token
            if (!user.IsCreateAppUserWithThirdParty)
                return new ApiErrorResult<Guid>() { Message = MessageConstants.LoginWithThirdPartyError };

            if (user.AppUserTypeId != (int)loginWithThirdPartyEnum)
                return new ApiErrorResult<Guid>() { Message = MessageConstants.LoginWithThirdPartyError };

            if (!user.EmailConfirmed)
                return new ApiErrorResult<Guid>() { Message = MessageConstants.EmailUnverified, StatusCode = StatusCodeEnum.EmailNotVerified };

            if (user.LockoutEnabled)
                return new ApiErrorResult<Guid>() { Message = MessageConstants.AccountLocked };

            if (user.IsDeleted)
                return new ApiErrorResult<Guid>() { Message = MessageConstants.AccountDeleted };

            string token = await CreateToken(user);

            return new ApiSuccessResult<Guid>() { Message = token, ResultObj = user.Id };
        }

        private async Task<ApiResult<Guid>> VerifyUserLogin(UserInfoGoogle userInfoGoogle, UserInfoFacebook userInfoFacebook, LoginWithThirdPartyEnum loginWithThirdPartyEnum)
        {
            //login with google
            if (loginWithThirdPartyEnum == LoginWithThirdPartyEnum.Google)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userInfoGoogle.Email);

                //create user
                if (user is null)
                {
                    //init variable
                    Guid newUserId = Guid.Empty;

                    //create AppUser & Account
                    using (var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            var newUser = new AppUser()
                            {
                                DOB = null,
                                Email = userInfoGoogle.Email,
                                FirstName = userInfoGoogle.GivenName,
                                LastName = userInfoGoogle.FamilyName,
                                UserName = userInfoGoogle.Email,
                                EmailConfirmed = true,
                                GenderId = null,
                                PhoneNumber = null,
                                UserImageURL = SystemConstants.AppSettings.UserImageURLDefault,
                                DateCreated = DateTime.Now,
                                IsCreateAppUserWithThirdParty = true,
                                AppUserTypeId = (int)loginWithThirdPartyEnum
                            };

                            var resultCreateAppUser = await _userManager.CreateAsync(newUser, userInfoGoogle.Sub);

                            if (resultCreateAppUser.Succeeded)
                            {
                                var customerRoleId = new Guid("2F0C7B75-8934-4101-BEF2-C850E42D21DE");
                                var userRole = new AppUserRole() { RoleId = customerRoleId, UserId = newUser.Id, AppUserRoleId = Guid.NewGuid() };
                                await _context.UserRoles.AddAsync(userRole);

                                var account = new Account()
                                {
                                    AppUserId = newUser.Id,
                                    CoinsDeposited = 0,
                                    CoinsLeft = 0,
                                    CoinsSpent = 0,
                                    CoinsReceived = 0,
                                    Experienced = 0,
                                    DateModified = DateTime.Now,
                                    MoreInfo = null,
                                    Nickname = null
                                };

                                await _context.Accounts.AddAsync(account);
                                await _context.SaveChangesAsync();

                                newUserId = newUser.Id;

                                await transaction.CommitAsync();
                            }
                            else
                            {
                                await transaction.RollbackAsync();
                                return new ApiErrorResult<Guid>() { Message = MessageConstants.FeatureAnErrorOccurred(nameof(VerifyUserLogin)) };
                            }
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            return new ApiErrorResult<Guid>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(VerifyUserLogin), ex.Message) };
                        }
                    }

                    //upload avatar
                    if (newUserId != Guid.Empty)
                    {
                        var imageUrl = userInfoGoogle.Picture;
                        byte[] imageData;

                        var httpClient = _httpClientFactory.CreateClient();
                        var stream = await httpClient.GetStreamAsync(imageUrl);
                        var memoryStream = new MemoryStream();

                        try
                        {
                            await stream.CopyToAsync(memoryStream);
                            imageData = memoryStream.ToArray();
                        }
                        finally
                        {
                            memoryStream.Dispose();
                            stream.Dispose();
                            httpClient.Dispose();
                        }


                        var resultUploadImage = await _uploadImageCloudinaryService.UploadImageCloudinary(newUserId, imageData);

                        if (!resultUploadImage.IsSuccessed)
                        {
                            return new ApiErrorResult<Guid>() { Message = resultUploadImage.Message };
                        }
                        else
                        {
                            user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userInfoGoogle.Email);

                            if (user is null)
                            {
                                return new ApiErrorResult<Guid>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(VerifyUserLogin), MessageConstants.ObjectNotFound("User")) };
                            }
                            else
                            {
                                return await UserLoginWithThirdParty(user, loginWithThirdPartyEnum);
                            }
                        }
                    }
                    else
                    {
                        return new ApiErrorResult<Guid>() { Message = MessageConstants.AnErrorOccurred };
                    }
                }
                else
                {
                    return await UserLoginWithThirdParty(user, loginWithThirdPartyEnum);
                }
            }
            //login with facebook
            else if (loginWithThirdPartyEnum == LoginWithThirdPartyEnum.Facebook)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == (userInfoFacebook.Id + "@facebook.com"));

                if (user is null)
                {
                    Guid newUserId = Guid.Empty;

                    using (var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            var newUser = new AppUser()
                            {
                                DOB = null,
                                Email = userInfoFacebook.Id + "@facebook.com",
                                FirstName = userInfoFacebook.FirstName,
                                LastName = userInfoFacebook.LastName,
                                UserName = userInfoFacebook.Id + "@facebook.com",
                                EmailConfirmed = true,
                                GenderId = null,
                                PhoneNumber = null,
                                UserImageURL = "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1685632211/HikiComic/AvatarOfUsers/0c4b1545427a1071d98eace015fcb355_xqt4ka.jpg",
                                DateCreated = DateTime.Now,
                                IsCreateAppUserWithThirdParty = true,
                                AppUserTypeId = (int)loginWithThirdPartyEnum
                            };

                            var resultCreateAppUser = await _userManager.CreateAsync(newUser, userInfoFacebook.Id);

                            if (resultCreateAppUser.Succeeded)
                            {
                                var customerRoleId = new Guid("2F0C7B75-8934-4101-BEF2-C850E42D21DE");
                                var userRole = new AppUserRole() { RoleId = customerRoleId, UserId = newUser.Id, AppUserRoleId = Guid.NewGuid() };
                                await _context.UserRoles.AddAsync(userRole);

                                var account = new Account()
                                {
                                    AppUserId = newUser.Id,
                                    CoinsDeposited = 0,
                                    CoinsLeft = 0,
                                    CoinsSpent = 0,
                                    CoinsReceived = 0,
                                    Experienced = 0,
                                    DateModified = DateTime.Now,
                                    MoreInfo = null,
                                    Nickname = null
                                };

                                await _context.Accounts.AddAsync(account);
                                await _context.SaveChangesAsync();

                                newUserId = newUser.Id;

                                await transaction.CommitAsync();

                                user = await _context.Users.FirstOrDefaultAsync(x => x.Email == (userInfoFacebook.Id + "@facebook.com"));

                                if (user is null)
                                    return new ApiErrorResult<Guid>() { Message = MessageConstants.AnErrorOccurred };

                                return await UserLoginWithThirdParty(user, loginWithThirdPartyEnum);
                            }
                            else
                            {
                                await transaction.RollbackAsync();
                                return new ApiErrorResult<Guid>() { Message = MessageConstants.FeatureAnErrorOccurred(nameof(VerifyUserLogin)) };
                            }
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            return new ApiErrorResult<Guid>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(VerifyUserLogin), ex.Message) };
                        }
                    }
                }
                else
                {
                    return await UserLoginWithThirdParty(user, loginWithThirdPartyEnum);
                }
            }
            //login with twitter
            else if (loginWithThirdPartyEnum == LoginWithThirdPartyEnum.Twitter)
            {
                return new ApiSuccessResult<Guid>() { Message = MessageConstants.CreateSuccess("User") };
            }
            else
            {
                return new ApiSuccessResult<Guid>() { Message = MessageConstants.CreateSuccess("User") };
            }
        }


        public async Task<ApiResult<Guid>> LoginWithThirdParty(string accessToken, LoginWithThirdPartyEnum loginWithThirdPartyEnum)
        {
            if (loginWithThirdPartyEnum == LoginWithThirdPartyEnum.Google)
            {
                var client = _httpClientFactory.CreateClient();
                var url = $"{SystemConstants.AppSettings.URLGooogleAPISUserInfo}{accessToken}";

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<UserInfoGoogle>(jsonResponse);

                    if (data is null)
                        return new ApiErrorResult<Guid>() { Message = MessageConstants.AnErrorOccurred };

                    var result = await VerifyUserLogin(data, new UserInfoFacebook(), loginWithThirdPartyEnum);

                    return result;
                }
                else
                {
                    return new ApiErrorResult<Guid>() { Message = MessageConstants.AnErrorOccurred };
                }

                //UserInfoGoogle user = new UserInfoGoogle()
                //{
                //    Sub = "5432109876",
                //    Name = "Alex Johnson",
                //    GivenName = "Alex",
                //    FamilyName = "Johnson",
                //    Picture = "https://c4.wallpaperflare.com/wallpaper/776/177/316/fantasy-girl-anime-girls-chinese-dress-hd-wallpaper-preview.jpg",
                //    Email = "alexjohnson@example.com",
                //    EmailVerified = true,
                //    Locale = "en_US"
                //};

                //var result = await VerifyUserLogin(user, loginWithThirdPartyEnum);

                //return result;
            }
            else if (loginWithThirdPartyEnum == LoginWithThirdPartyEnum.Facebook)
            {
                var client = _httpClientFactory.CreateClient();
                var url = $"{SystemConstants.AppSettings.URLFacebookAPISUserInfo}{accessToken}";

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<UserInfoFacebook>(jsonResponse);

                    if (data is null)
                        return new ApiErrorResult<Guid>() { Message = MessageConstants.AnErrorOccurred };

                    var result = await VerifyUserLogin(new UserInfoGoogle(), data, loginWithThirdPartyEnum);

                    return result;
                }
                else
                {
                    return new ApiErrorResult<Guid>() { Message = MessageConstants.AnErrorOccurred };
                }
            }
            else if (loginWithThirdPartyEnum == LoginWithThirdPartyEnum.Twitter)
            {
                return new ApiErrorResult<Guid>() { Message = MessageConstants.AnErrorOccurred };
            }
            else
            {
                return new ApiErrorResult<Guid>() { Message = MessageConstants.AnErrorOccurred };
            }
        }
        #endregion

        public async Task<ApiResult<bool>> Register(UserRegisterRequest request)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (await _userManager.FindByEmailAsync(request.Email) != null)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.EmailAlreadyExists };

                    var user = await _userManager.FindByNameAsync(request.Email);
                    if (user != null)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.UsernameAlreadyExists };

                    var tempAppUserCurrent = await _context.TempAppUsers.FirstOrDefaultAsync(x => x.Email == request.Email);

                    if (tempAppUserCurrent != null)
                    {
                        if (tempAppUserCurrent.OTPExpires > DateTime.Now)
                        {
                            await transaction.CommitAsync();
                            return new ApiSuccessResult<bool>() { Message = MessageConstants.EmailVerification };
                        }
                        else
                        {
                            _context.TempAppUsers.Remove(tempAppUserCurrent);

                            var tempAppUser = new TempAppUser()
                            {
                                Email = request.Email,
                                PasswordHash = _commonService.HashDataSHA256(request.Password),
                                OTP = _commonService.GenerateOTP(6),
                                OTPExpires = DateTime.Now.AddMinutes(30),
                            };

                            await _context.TempAppUsers.AddAsync(tempAppUser);
                            await _context.SaveChangesAsync();

                            var sendMailOTP = await _sendMailService.SendMailOTP(request.Email, MailTypeEnum.OTPEmailVerification, tempAppUser.OTP);

                            await transaction.CommitAsync();

                            return sendMailOTP;
                        }
                    }
                    else
                    {
                        var tempAppUser = new TempAppUser()
                        {
                            Email = request.Email,
                            PasswordHash = _commonService.HashDataSHA256(request.Password),
                            OTP = _commonService.GenerateOTP(6),
                            OTPExpires = DateTime.Now.AddMinutes(30),
                        };

                        await _context.TempAppUsers.AddAsync(tempAppUser);
                        await _context.SaveChangesAsync();

                        var sendMailOTP = await _sendMailService.SendMailOTP(request.Email, MailTypeEnum.OTPEmailVerification, tempAppUser.OTP);

                        await transaction.CommitAsync();

                        return sendMailOTP;
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(Register), ex.Message) };
                }
            }
        }

        #region verify email
        public async Task<ApiResult<bool>> UserVerifyEmail(VerifyEmailRequest request)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var tempAppUser = await _context.TempAppUsers.FirstOrDefaultAsync(x => x.Email == request.Email);

                    if (tempAppUser is null)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.EmailNotFound };

                    if (tempAppUser.PasswordHash != _commonService.HashDataSHA256(request.Password))
                        return new ApiErrorResult<bool>() { Message = MessageConstants.IncorrectPassword };

                    if (DateTime.Now > tempAppUser.OTPExpires)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.EmailVerificationOTPHasExpired };

                    if (request.OTP != tempAppUser.OTP)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.EmailVerificationOTPUnverified };

                    var user = new AppUser()
                    {
                        DOB = null,
                        Email = request.Email,
                        FirstName = null,
                        LastName = null,
                        UserName = request.Email,
                        EmailConfirmed = true,
                        GenderId = null,
                        PhoneNumber = null,
                        UserImageURL = SystemConstants.AppSettings.UserImageURLDefault,
                        DateCreated = DateTime.Now,
                        IsCreateAppUserWithThirdParty = false,
                        AppUserTypeId = (int)LoginWithThirdPartyEnum.HikiComic
                    };

                    var result = await _userManager.CreateAsync(user, request.Password);

                    if (result.Succeeded)
                    {
                        _context.TempAppUsers.Remove(tempAppUser);

                        var customerRoleId = new Guid("2F0C7B75-8934-4101-BEF2-C850E42D21DE");
                        var userRole = new AppUserRole() { RoleId = customerRoleId, UserId = user.Id, AppUserRoleId = Guid.NewGuid() };
                        await _context.UserRoles.AddAsync(userRole);

                        var account = new Account()
                        {
                            AppUserId = user.Id,
                            CoinsDeposited = 0,
                            CoinsLeft = 0,
                            CoinsSpent = 0,
                            CoinsReceived = 0,
                            Experienced = 0,
                            DateModified = DateTime.Now,
                            MoreInfo = null,
                            Nickname = null
                        };

                        await _context.Accounts.AddAsync(account);
                        await _context.SaveChangesAsync();

                        // Commit the transaction if all operations succeeded
                        await transaction.CommitAsync();

                        return new ApiSuccessResult<bool>() { Message = MessageConstants.EmailVerificationSuccess };
                    }

                    // Rollback the transaction if an error occurred
                    await transaction.RollbackAsync();

                    return new ApiErrorResult<bool>() { Message = MessageConstants.EmailVerificationNotSuccess };
                }
                catch (Exception ex)
                {
                    // Handle any exceptions and rollback the transaction
                    await transaction.RollbackAsync();
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(UserVerifyEmail), ex.Message) };
                }
            }
        }

        public async Task<ApiResult<bool>> ResendEmailVerification(UserInfoResendEmailVerificationRequest request)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var tempAppUser = await _context.TempAppUsers.FirstOrDefaultAsync(x => x.Email == request.Email);

                    if (tempAppUser is null)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.EmailNotFound };

                    if (tempAppUser.PasswordHash != _commonService.HashDataSHA256(request.Password))
                        return new ApiErrorResult<bool>() { Message = MessageConstants.IncorrectPassword };

                    string otp = _commonService.GenerateOTP(6);

                    tempAppUser.OTP = otp;
                    tempAppUser.OTPExpires = DateTime.Now.AddMinutes(30);

                    await _context.SaveChangesAsync();

                    var sendMailOTP = await _sendMailService.SendMailOTP(request.Email, MailTypeEnum.OTPEmailVerification, otp);

                    await transaction.CommitAsync();

                    return sendMailOTP;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(ResendEmailVerification), ex.Message) };
                }
            }
        }
        #endregion

        #region forgot password
        public async Task<ApiResult<bool>> ForgotPassword(string email)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

                    if (user is null)
                        return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

                    if (!user.EmailConfirmed)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.EmailUnverified, StatusCode = StatusCodeEnum.EmailNotVerified };

                    if (user.LockoutEnabled)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.AccountLocked };

                    if (user.IsDeleted)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.AccountDeleted };

                    user.OTP = _commonService.GenerateOTP(6);
                    user.IsOTPVerified = null;
                    user.OTPExpires = DateTime.Now.AddMinutes(30);
                    await _context.SaveChangesAsync();

                    string fullName = user.FirstName + " " + user.LastName;

                    var sendEmailForgotPassword = await _sendMailService.SendMailOTP(email, MailTypeEnum.OTPForgotPassword, user.OTP, fullName.Trim().Equals("") ? fullName : "Sir or Madam");

                    await transaction.CommitAsync();

                    return sendEmailForgotPassword;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(ForgotPassword), ex.Message) };
                }
            }
        }

        public async Task<ApiResult<bool>> UserVerifyForgotPassword(UserVerifyForgotPasswordRequest request)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

                    if (user is null)
                        return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

                    if (!user.EmailConfirmed)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.EmailUnverified, StatusCode = StatusCodeEnum.EmailNotVerified };

                    if (user.LockoutEnabled)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.AccountLocked };

                    if (user.IsDeleted)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.AccountDeleted };

                    if (DateTime.Now > user.OTPExpires)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.ForgotPasswordOTPHasExpired };

                    if (request.OTP != user.OTP)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.ForgotPasswordOTPUnverified };

                    user.IsOTPVerified = true;
                    user.OTPExpires = user.OTPExpires?.AddMinutes(5);

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return new ApiSuccessResult<bool>() { Message = MessageConstants.ForgotPasswordSuccess };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(UserVerifyForgotPassword), ex.Message) };
                }
            }
        }
        #endregion
    }
}

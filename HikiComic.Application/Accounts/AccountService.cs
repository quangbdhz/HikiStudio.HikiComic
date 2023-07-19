using HikiComic.Application.Common;
using HikiComic.Application.SendSMSs;
using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Accounts;
using HikiComic.ViewModels.Accounts.AccountDataRequest;
using HikiComic.ViewModels.Comics;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace HikiComic.Application.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly HikiComicDbContext _context;

        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        private readonly ISendSMSService _sendSMSService;

        private readonly ICommonService _commonService;

        private readonly IUserContextService _userContextService;

        public AccountService(HikiComicDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ISendSMSService sendSMSService, ICommonService commonService, IUserContextService userContextService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _sendSMSService = sendSMSService;
            _commonService = commonService;
            _userContextService = userContextService;
        }

        public async Task<ApiResult<AccountViewModel>> GetAccount()
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return new ApiResult<AccountViewModel>();

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userResult.ResultObj);
            if (user is null)
                return new ApiErrorResult<AccountViewModel>(MessageConstants.ObjectNotFound("User"));

            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == user.Id);
            if (account is null)
                return new ApiErrorResult<AccountViewModel>(MessageConstants.ObjectNotFound("Account"));

            string genderName = string.Empty;
            if (user.GenderId != null)
            {
                var gender = await _context.Genders.FirstOrDefaultAsync(x => x.GenderId == user.GenderId);

                if (gender != null)
                    genderName = gender.GenderName;
            }

            bool isSendRequestUpgradeCreator = false;
            var upgradeRequest = await _context.UserRoleUpgradeRequests.FirstOrDefaultAsync(x => x.AppUserId == userResult.ResultObj);
            if (upgradeRequest != null)
                isSendRequestUpgradeCreator = true;

            var accountViewModel = new AccountViewModel()
            {
                AppUserId = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email,
                DOB = user.DOB,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                UserImageURL = user.UserImageURL != null && user.UserImageURL.Contains("http") ? user.UserImageURL : SystemConstants.AppSettings.URLDomainMyHostProduct + "uploads/user-avatar/" + user.UserImageURL,
                GenderName = String.IsNullOrEmpty(genderName) ? null : genderName,
                Nickname = account.Nickname,
                MoreInfo = account.MoreInfo,
                DateModified = account.DateModified,
                Experienced = account.Experienced,
                CoinsDeposited = account.CoinsDeposited,
                CoinsLeft = account.CoinsLeft,
                CoinsSpent = account.CoinsSpent,
                CoinsReceived = account.CoinsReceived,
                IsSendRequestUpgradeCreator = isSendRequestUpgradeCreator
            };

            return new ApiSuccessResult<AccountViewModel>() { ResultObj = accountViewModel, Message = MessageConstants.GetObjectSuccess("Account") };
        }


        public async Task<ApiResult<AccountViewModel>> GetAccountByUserId(Guid userId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return new ApiResult<AccountViewModel>();

            var roleUserResult = await _context.UserRoles.Include(x => x.AppRole).FirstOrDefaultAsync(x => x.UserId == userResult.ResultObj && x.AppRole.Name == SystemConstants.AppSettings.AdminRole);

            //is team members
            if(roleUserResult is null)
            {
                var queryUser = from u in _context.Users
                                join ur in _context.UserRoles on u.Id equals ur.UserId
                                join r in _context.Roles on ur.RoleId equals r.Id
                                where u.Id == userId && r.Name == SystemConstants.AppSettings.AdminRole
                                select u;

                if(await queryUser.CountAsync() > 0)
                {
                    return new ApiErrorResult<AccountViewModel>() { StatusCode = StatusCodeEnum.DoNotHavePermission, Message = MessageConstants.DoNotHavePermission };
                }
                else
                {
                    var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

                    if (user is null)
                        return new ApiErrorResult<AccountViewModel>(MessageConstants.ObjectNotFound("User"));

                    var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == user.Id);
                    if (account is null)
                        return new ApiErrorResult<AccountViewModel>(MessageConstants.ObjectNotFound("Account"));

                    string genderName = string.Empty;
                    if (user.GenderId != null)
                    {
                        var gender = await _context.Genders.FirstOrDefaultAsync(x => x.GenderId == user.GenderId);

                        if (gender != null)
                            genderName = gender.GenderName;
                    }

                    var accountViewModel = new AccountViewModel()
                    {
                        AppUserId = user.Id,
                        LastName = user.LastName,
                        FirstName = user.FirstName,
                        Email = user.Email,
                        DOB = user.DOB,
                        PhoneNumber = user.PhoneNumber,
                        PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                        UserImageURL = user.UserImageURL,
                        GenderName = String.IsNullOrEmpty(genderName) ? null : genderName,
                        Nickname = account.Nickname,
                        MoreInfo = account.MoreInfo,
                        DateModified = account.DateModified,
                        Experienced = account.Experienced,
                        CoinsDeposited = account.CoinsDeposited,
                        CoinsLeft = account.CoinsLeft,
                        CoinsSpent = account.CoinsSpent,
                        CoinsReceived = account.CoinsReceived
                    };

                    return new ApiSuccessResult<AccountViewModel>() { ResultObj = accountViewModel, Message = MessageConstants.GetObjectSuccess("Account") };
                }            
            }
            else
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

                if (user is null)
                    return new ApiErrorResult<AccountViewModel>(MessageConstants.ObjectNotFound("User"));

                var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == user.Id);
                if (account is null)
                    return new ApiErrorResult<AccountViewModel>(MessageConstants.ObjectNotFound("Account"));

                string genderName = string.Empty;
                if (user.GenderId != null)
                {
                    var gender = await _context.Genders.FirstOrDefaultAsync(x => x.GenderId == user.GenderId);

                    if (gender != null)
                        genderName = gender.GenderName;
                }

                var accountViewModel = new AccountViewModel()
                {
                    AppUserId = user.Id,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    Email = user.Email,
                    DOB = user.DOB,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    UserImageURL = user.UserImageURL,
                    GenderName = String.IsNullOrEmpty(genderName) ? null : genderName,
                    Nickname = account.Nickname,
                    MoreInfo = account.MoreInfo,
                    DateModified = account.DateModified,
                    Experienced = account.Experienced,
                    CoinsDeposited = account.CoinsDeposited,
                    CoinsLeft = account.CoinsLeft,
                    CoinsSpent = account.CoinsSpent,
                    CoinsReceived = account.CoinsReceived
                };

                return new ApiSuccessResult<AccountViewModel>() { ResultObj = accountViewModel, Message = MessageConstants.GetObjectSuccess("Account") };
            }
        }

        public async Task<ApiResult<bool>> ChangeNickname(Guid userId, string nickname)
        {
            if (String.IsNullOrEmpty(nickname))
                return new ApiErrorResult<bool>() { Message = MessageConstants.NicknameIsRequired };

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == user.Id);
            if (account is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Account"));

            var servicePrice = await _context.ServicePrices.FirstOrDefaultAsync(x => x.ServicePriceId == (int)UsageMethodEnum.ChangeNickname);
            if (servicePrice is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ServiceDoesNotExist };

            if (String.IsNullOrEmpty(account.Nickname))
            {
                var userCoinUsageHistory = new UserCoinUsageHistory()
                {
                    AccountId = account.AccountId,
                    UsageAmount = 0,
                    UsageMethodId = UsageMethodEnum.ChangeNickname,
                    UsageStatusId = UsageStatusEnum.Completed,
                    DateCreated = DateTime.Now
                };

                account.Nickname = nickname;
                account.DateModified = DateTime.Now;

                await _context.UserCoinUsageHistories.AddAsync(userCoinUsageHistory);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>() { Message = MessageConstants.ChangeNicknameSuccess };
            }
            else
            {
                if (0 > account.CoinsLeft - servicePrice.Price)
                    return new ApiResult<bool> { Message = MessageConstants.NotEnoughMoney };

                var userCoinUsageHistory = new UserCoinUsageHistory()
                {
                    AccountId = account.AccountId,
                    UsageAmount = servicePrice.Price,
                    UsageMethodId = UsageMethodEnum.ChangeNickname,
                    UsageStatusId = UsageStatusEnum.Completed,
                    DateCreated = DateTime.Now
                };

                await _context.UserCoinUsageHistories.AddAsync(userCoinUsageHistory);

                account.CoinsLeft -= servicePrice.Price;
                account.CoinsSpent += servicePrice.Price;
                account.DateModified = DateTime.Now;

                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>() { Message = MessageConstants.ChangeNicknameSuccess };
            }
        }

        public async Task<ApiResult<bool>> ChangeAvatar(Guid userId, ChangeAvatarUserRequest request)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

            user.UserImageURL = request.UrlImage;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return new ApiSuccessResult<bool>() { Message = MessageConstants.ChangeAvatarSuccess };

            return new ApiErrorResult<bool>() { Message = MessageConstants.ChangeAvatarNotSuccess };
        }

        public async Task<ApiResult<bool>> ChangePassword(Guid userId, ChangePasswordUserRequest request)
        {
            if (request.NewPassword == request.CurrentPassword)
                return new ApiErrorResult<bool>() { Message = MessageConstants.CompareNewPasswordAndCurrentPassword };

            if (request.NewPassword != request.ConfirmPassword)
                return new ApiErrorResult<bool>() { Message = MessageConstants.CompareNewPasswordAndConfirmPassword };

            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

            var hasher = new PasswordHasher<AppUser>();
            var resultHashPassword = await _signInManager.PasswordSignInAsync(user, request.CurrentPassword, true, true);

            if (!resultHashPassword.Succeeded)
                return new ApiErrorResult<bool>() { Message = MessageConstants.IncorrectPassword };

            user.PasswordHash = hasher.HashPassword(user, request.NewPassword);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return new ApiSuccessResult<bool>() { Message = MessageConstants.ChangePasswordSuccess };

            return new ApiErrorResult<bool>() { Message = MessageConstants.ChangePasswordNotSuccess };
        }

        public async Task<ApiResult<bool>> ResetPassword(ResetPasswordRequest request, bool isNewUser = false, bool isSendMailCongratulation = false)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

            if(isSendMailCongratulation)
            {
                if (!user.EmailConfirmed)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.EmailUnverified, StatusCode = StatusCodeEnum.EmailNotVerified };

                if (user.LockoutEnabled)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AccountLocked };

                if (user.IsDeleted)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AccountDeleted };
            }

            if (!isNewUser)
            {
                if (!user.EmailConfirmed)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.EmailUnverified, StatusCode = StatusCodeEnum.EmailNotVerified };

                if (user.LockoutEnabled)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AccountLocked };

                if (user.IsDeleted)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AccountDeleted };

                if (user.IsOTPVerified is null || user.IsOTPVerified == false)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.ForgotPasswordOTPUnverified };

                if (DateTime.Now > user.OTPExpires)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.ForgotPasswordOTPHasExpired };
            }

            if (request.NewPassword != request.ConfirmPassword)
                return new ApiErrorResult<bool>() { Message = MessageConstants.CompareNewPasswordAndConfirmPassword };

            var hasher = new PasswordHasher<AppUser>();
            user.PasswordHash = hasher.HashPassword(user, request.NewPassword);
            user.OTP = null;
            user.OTPExpires = null;
            user.IsOTPVerified = null;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return new ApiSuccessResult<bool>() { Message = MessageConstants.ChangePasswordSuccess };

            return new ApiErrorResult<bool>() { Message = MessageConstants.ChangePasswordNotSuccess };
        }

        #region create, delete, verification phone number of user
        public async Task<ApiResult<bool>> SendSMSVerificationPhoneNumber(Guid userId, OTPTypeEnum oTPType)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

            if (!user.EmailConfirmed)
                return new ApiErrorResult<bool>() { Message = MessageConstants.EmailUnverified, StatusCode = StatusCodeEnum.EmailNotVerified };

            if (user.LockoutEnabled)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AccountLocked };

            if (user.IsDeleted)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AccountDeleted };

            if(oTPType == OTPTypeEnum.SMSOTPVerificationPhoneNumber)
            {
                if (user.PhoneNumberConfirmed)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.PhoneNumberVerifiedSuccess };
            }

            if (String.IsNullOrEmpty(user.PhoneNumber))
                return new ApiErrorResult<bool>() { Message = MessageConstants.PhoneNumberIsNullOrEmpty };

            if (!_commonService.CheckFormatPhoneNumber(user.PhoneNumber))
                return new ApiErrorResult<bool>() { Message = MessageConstants.FormatPhoneNumberInvalid };

            var checkOTPAlreadyExists = await _context.AppUserOTPs.OrderByDescending(x => x.DateCreated).FirstOrDefaultAsync(x => x.AppUserId == userId && x.OTPType == oTPType);

            if(checkOTPAlreadyExists != null)
            {
                if(DateTime.Now > checkOTPAlreadyExists.OTPExpires && !checkOTPAlreadyExists.IsOTPVerified)
                {
                    checkOTPAlreadyExists.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }

                if(checkOTPAlreadyExists.OTPExpires >= DateTime.Now && !checkOTPAlreadyExists.IsOTPVerified)
                {
                    return new ApiSuccessResult<bool>() { Message = MessageConstants.CheckOTPOnYourSmartPhone };
                }
            }

            string generateOTP = _commonService.GenerateOTP(6);

            var appUserOTP = new AppUserOTP()
            {
                AppUserId = user.Id,
                OTP = _commonService.HashDataSHA256(generateOTP),
                OTPType = oTPType,
                OTPExpires = DateTime.Now.AddMinutes(15),
                IsOTPVerified = false,
                IsDeleted = false,
                DateCreated = DateTime.Now
            };

            await _context.AppUserOTPs.AddAsync(appUserOTP);
            await _context.SaveChangesAsync();

            var resultSendSMS = await _sendSMSService.SendSMS(generateOTP, user.PhoneNumber);

            if (!resultSendSMS.IsSuccessed)
            {
                return new ApiErrorResult<bool>() { Message = resultSendSMS.Message };
            }

            return new ApiSuccessResult<bool>() { Message = MessageConstants.SendOTPVerificationPhoneNumberSuccess };

            //using (var transaction = await _context.Database.BeginTransactionAsync())
            //{
            //    try
            //    {
            //        var appUserOTP = new AppUserOTP()
            //        {
            //            AppUserId = user.Id,
            //            OTP = _commonService.HashDataSHA256(generateOTP),
            //            OTPType = OTPTypeEnum.SMSOTPVerificationPhoneNumber,
            //            OTPExpires = DateTime.Now.AddMinutes(15),
            //            IsOTPVerified = false,
            //            IsDeleted = false,
            //            DateCreated = DateTime.Now
            //        };

            //        await _context.AppUserOTPs.AddAsync(appUserOTP);
            //        await _context.SaveChangesAsync();

            //        var resultSendSMS = await _sendSMSService.SendSMS(generateOTP, user.PhoneNumber);

            //        if (!resultSendSMS.IsSuccessed)
            //        { 
            //            await transaction.RollbackAsync();
            //            return new ApiErrorResult<bool>() { Message = resultSendSMS.Message };
            //        }

            //        await transaction.CommitAsync();
            //        return new ApiSuccessResult<bool>() { Message = MessageConstants.SendOTPVerificationPhoneNumberSuccess };
            //    }
            //    catch(Exception ex)
            //    {
            //        await transaction.RollbackAsync();
            //        return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(SendSMSVerificationPhoneNumber), ex.Message) };
            //    }
            //}
        }

        public async Task<ApiResult<bool>> CreatePhoneNumber(CreatePhoneNumberRequest request, Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

            if (user.LockoutEnabled)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AccountLocked };

            if (user.IsDeleted)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AccountDeleted };

            if (!String.IsNullOrEmpty(user.PhoneNumber))
                return new ApiErrorResult<bool>() { Message = MessageConstants.UserAccountPhoneNumberExists };

            var phoneNumberExists = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber.Equals(request.PhoneNumber));

            if (phoneNumberExists != null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.PhoneNumberAlreadyUsed };

            if (!_commonService.CheckFormatPhoneNumber(request.PhoneNumber))
                return new ApiErrorResult<bool>() { Message = MessageConstants.FormatPhoneNumberInvalid };

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    user.PhoneNumber = request.PhoneNumber;
                    await _context.SaveChangesAsync();

                    var resultSendSMSOTPVerifed = await SendSMSVerificationPhoneNumber(userId, OTPTypeEnum.SMSOTPVerificationPhoneNumber);

                    if (!resultSendSMSOTPVerifed.IsSuccessed)
                    {
                        await transaction.RollbackAsync();
                        return new ApiErrorResult<bool>() { Message = resultSendSMSOTPVerifed.Message };
                    }

                    await transaction.CommitAsync();

                    return new ApiSuccessResult<bool>() { Message = MessageConstants.SendOTPVerificationPhoneNumberSuccess };
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(CreatePhoneNumber), ex.Message) };
                }
            }
        }

        public async Task<ApiResult<bool>> VerificationPhoneNumber(OTPSMSVerificationRequest request, Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

            if (user.LockoutEnabled)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AccountLocked };

            if (user.IsDeleted)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AccountDeleted };

            var appUserOTP = await _context.AppUserOTPs.Where(x => x.AppUserId == userId && !x.IsOTPVerified && x.OTPType == OTPTypeEnum.SMSOTPVerificationPhoneNumber && !x.IsDeleted)
                            .OrderByDescending(x => x.AppUserOTPId).FirstOrDefaultAsync();

            if (appUserOTP is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.OTPVerificationCodeNotFound };

            if (appUserOTP.OTP != _commonService.HashDataSHA256(request.OTP))
                return new ApiErrorResult<bool>() { Message = MessageConstants.IncorrectOTPVerificationCode };

            if (appUserOTP.OTPExpires < DateTime.Now)
                return new ApiErrorResult<bool>() { Message = MessageConstants.OTPVerificationCodeExpired };

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    user.PhoneNumberConfirmed = true;
                    appUserOTP.IsOTPVerified = true;
                    appUserOTP.IsDeleted = true;

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return new ApiSuccessResult<bool>() { Message = MessageConstants.PhoneNumberVerificationSuccess };
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(VerificationPhoneNumber), ex.Message) };
                }
            }
        }

        public async Task<ApiResult<bool>> VerificationPhoneNumberToDelete(OTPSMSVerificationRequest request, Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

            if (user.LockoutEnabled)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AccountLocked };

            if (user.IsDeleted)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AccountDeleted };

            var appUserOTP = await _context.AppUserOTPs.Where(x => x.AppUserId == userId && !x.IsOTPVerified && x.OTPType == OTPTypeEnum.SMSOTPVerificationPhoneNumberToDelete && !x.IsDeleted)
                            .OrderByDescending(x => x.AppUserOTPId).FirstOrDefaultAsync();

            if (appUserOTP is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.OTPVerificationCodeNotFound };

            if (appUserOTP.OTP != _commonService.HashDataSHA256(request.OTP))
                return new ApiErrorResult<bool>() { Message = MessageConstants.IncorrectOTPVerificationCode };

            if (appUserOTP.OTPExpires < DateTime.Now)
                return new ApiErrorResult<bool>() { Message = MessageConstants.OTPVerificationCodeExpired };

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    appUserOTP.IsOTPVerified = true;

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return new ApiSuccessResult<bool>() { Message = MessageConstants.PhoneNumberVerificationSuccess };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(VerificationPhoneNumberToDelete), ex.Message) };
                }
            }
        }

        public async Task<ApiResult<bool>> DeletePhoneNumber(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

            if (user.LockoutEnabled)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AccountLocked };

            if (user.IsDeleted)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AccountDeleted };

            if (!user.PhoneNumberConfirmed)
            {
                user.PhoneNumber = null;

                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>() { Message = MessageConstants.PhoneNumberDeletionSuccess };
            }
            else
            {
                var appUserOTP = await _context.AppUserOTPs.Where(x => x.AppUserId == userId && x.IsOTPVerified == true && x.OTPType == OTPTypeEnum.SMSOTPVerificationPhoneNumberToDelete && !x.IsDeleted)
                            .OrderByDescending(x => x.AppUserOTPId).FirstOrDefaultAsync();

                if (appUserOTP is null)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.OTPVerificationCodeNotFound };

                if (appUserOTP.OTPExpires.AddDays(1) < DateTime.Now)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.OTPVerificationCodeExpired };

                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        user.PhoneNumberConfirmed = false;
                        user.PhoneNumber = null;

                        appUserOTP.IsDeleted = true;

                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        return new ApiSuccessResult<bool>() { Message = MessageConstants.PhoneNumberDeletionSuccess };
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(DeletePhoneNumber), ex.Message) };
                    }
                }
            }
        }
        #endregion

    }
}

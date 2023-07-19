using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Accounts;
using HikiComic.ViewModels.Accounts.AccountDataRequest;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users.UserDataRequest;

namespace HikiComic.Application.Accounts
{
    public interface IAccountService
    {
        Task<ApiResult<AccountViewModel>> GetAccountByUserId(Guid userId);

        Task<ApiResult<AccountViewModel>> GetAccount();

        Task<ApiResult<bool>> ChangeNickname(Guid userId, string nickname);

        Task<ApiResult<bool>> ChangeAvatar(Guid userId, ChangeAvatarUserRequest request);
        
        Task<ApiResult<bool>> ChangePassword(Guid userId, ChangePasswordUserRequest request);

        Task<ApiResult<bool>> ResetPassword(ResetPasswordRequest request, bool isNewUser = false, bool isSendMailCongratulation = false);

        Task<ApiResult<bool>> SendSMSVerificationPhoneNumber(Guid userId, OTPTypeEnum oTPTypeEnum);

        Task<ApiResult<bool>> CreatePhoneNumber(CreatePhoneNumberRequest request, Guid userId);

        Task<ApiResult<bool>> VerificationPhoneNumber(OTPSMSVerificationRequest request, Guid userId);

        Task<ApiResult<bool>> VerificationPhoneNumberToDelete(OTPSMSVerificationRequest request, Guid userId);

        Task<ApiResult<bool>> DeletePhoneNumber(Guid userId);

    }
}

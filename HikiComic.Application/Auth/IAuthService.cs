using HikiComic.Data.Entities;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Auth.Token;
using HikiComic.ViewModels.Auth.VerifyDataRequest;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users.UserDataRequest;

namespace HikiComic.Application.Auth
{
    public interface IAuthService
    {
        ApiResult<Guid> ValidateToken(string token);

        RefreshTokenViewModel GenerateRefreshTokenViewModel();

        Task<ApiResult<bool>> SetRefreshToken(Guid userId, RefreshTokenViewModel refreshTokenViewModel);

        Task<string> CreateToken(AppUser user);

        Task<ApiResult<Guid>> RefreshToken(Guid userId, string refreshToken);



        Task<ApiResult<Guid>> Login(UserLoginRequest request);

        Task<ApiResult<Guid>> LoginWithThirdParty(string accessToken, LoginWithThirdPartyEnum loginWithThirdPartyEnum);

        Task<ApiResult<bool>> Register(UserRegisterRequest request);

        Task<ApiResult<bool>> UserVerifyEmail(VerifyEmailRequest request);

        Task<ApiResult<bool>> ResendEmailVerification(UserInfoResendEmailVerificationRequest request);

        Task<ApiResult<bool>> ForgotPassword(string email);

        Task<ApiResult<bool>> UserVerifyForgotPassword(UserVerifyForgotPasswordRequest request);
    }
}

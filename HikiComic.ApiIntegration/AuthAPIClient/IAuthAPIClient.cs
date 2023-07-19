using HikiComic.ViewModels.Auth.Token.TokenDataRequest;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users.UserDataRequest;

namespace HikiComic.ApiIntegration.AuthAPIClient
{
    public interface IAuthAPIClient
    {
        Task<ApiResult<string>> Login(UserLoginRequest request);

        Task<ApiResult<Guid>> Refresh(UserRefreshTokenRequest request);

        Task<ApiResult<bool>> Register(UserRegisterRequest request);
    }
}

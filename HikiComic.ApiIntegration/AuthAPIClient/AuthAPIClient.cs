using HikiComic.ViewModels.Auth.Token.TokenDataRequest;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.AuthAPIClient
{
    public class AuthAPIClient : BaseAPI, IAuthAPIClient
    {
        public AuthAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<string>> Login(UserLoginRequest request)
        {
            return await PostAsync<ApiResult<string>, UserLoginRequest>(request, "/api/auth/login");
        }

        public async Task<ApiResult<Guid>> Refresh(UserRefreshTokenRequest request)
        {
            return await PostAsync<ApiResult<Guid>, UserRefreshTokenRequest>(request, $"/api/auth/refresh");
        }

        public Task<ApiResult<bool>> Register(UserRegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

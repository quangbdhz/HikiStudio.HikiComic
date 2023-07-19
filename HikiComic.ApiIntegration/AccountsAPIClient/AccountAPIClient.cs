using HikiComic.ViewModels.Accounts;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.AccountsAPIClient
{
    public class AccountAPIClient : BaseAPI, IAccountAPIClient
    {
        public AccountAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) 
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<bool>> ChangeAvatar(ChangeAvatarUserRequest request)
        {
            return await PostAsync<ApiResult<bool>, ChangeAvatarUserRequest>(request, "/api/accounts/change-avatar");
        }

        public async Task<ApiResult<bool>> ChangePassword(ChangePasswordUserRequest request)
        {
            return await PostAsync<ApiResult<bool>, ChangePasswordUserRequest>(request, "/api/accounts/change-password");
        }

        public async Task<ApiResult<AccountViewModel>> GetAccountByUserId(Guid userId)
        {
            return await GetAsync<ApiResult<AccountViewModel>>($"/api/accounts/get-account-by-user-id/{userId}");
        }
    }
}

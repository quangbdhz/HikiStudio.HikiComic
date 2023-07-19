using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users;
using HikiComic.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.UsersAPIClient
{
    public class UserAPIClient : BaseAPI, IUserAPIClient
    {
        public UserAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<bool>> DeleteUser(DeleteUsersRequest request)
        {
            return await PostAsync<ApiResult<bool>, DeleteUsersRequest>(request, $"/api/users/delete-multiple");
        }

        public async Task<PagingResult<UserViewModel>> GetPagingManagement(PagingRequest request)
        {
            return await PostAsync<PagingResult<UserViewModel>, PagingRequest>(request, $"/api/users/paging-management");
        }

        public async Task<PagingResult<UserViewModel>> AdminGetPagingManagement(PagingRequest request)
        {
            return await PostAsync<PagingResult<UserViewModel>, PagingRequest>(request, $"/api/users/admin-paging-management");
        }

        public async Task<ApiResult<UserViewModel>> GetUserByUserId(Guid userId)
        {
            return await GetAsync<ApiResult<UserViewModel>>($"/api/users/get-user-by-user-id/{userId}");
        }

        public async Task<ApiResult<UserViewModel>> GetUserByUserId()
        {
            return await GetAsync<ApiResult<UserViewModel>>($"/api/users/get-user-by-user-id");
        }

        public async Task<ApiResult<bool>> LockoutEnabledUser(Guid userId)
        {
            return await PostAsync<ApiResult<bool>, Guid>(userId, $"/api/users/lockout-enabled");
        }

        public async Task<ApiResult<string>> Login(UserLoginRequest request)
        {
            return await PostAsync<ApiResult<string>, UserLoginRequest>(request, "/api/users/login");
        }

        public async Task<ApiResult<bool>> CreateUser(UserRegisterRequest request)
        {
            return await PostAsync<ApiResult<bool>, UserRegisterRequest>(request, "/api/users/register");
        }

        public async Task<ApiResult<bool>> RestoreDeletedUser(Guid userId)
        {
            return await PostAsync<ApiResult<bool>, Guid>(userId, $"/api/users/restore");
        }

        public async Task<ApiResult<UserViewModel>> UpdateUser(UpdateUserRequest request)
        {
            return await PutAsync<ApiResult<UserViewModel>, UpdateUserRequest>(request, "/api/users/update");
        }

        public async Task<ApiResult<bool>> CreateUserAndAssignRole(CreateUserAndAssignRoleRequest request)
        {
            return await PostAsync<ApiResult<bool>, CreateUserAndAssignRoleRequest>(request, $"/api/users/create-user-and-assign-role");
        }

        public async Task<ApiResult<bool>> ResendMailConfirmation(string email)
        {
            return await PostAsync<ApiResult<bool>, string>(email, $"/api/users/resend-mail-email-confirmation");
        }

        public async Task<ApiResult<bool>> VerifyTokenEmailConfirmation(string token)
        {
            return await PostAsync<ApiResult<bool>, string>(token, $"/api/users/verify-token-email-confirmation");
        }

        public async Task<ApiResult<bool>> UserEmailConfirmationAndChangePassword(VerifyTokenEmailAndChangePasswordRequest request)
        {
            return await PostAsync<ApiResult<bool>, VerifyTokenEmailAndChangePasswordRequest>(request, $"/api/users/user-mail-confirmations-and-change-password");
        }
    }
}

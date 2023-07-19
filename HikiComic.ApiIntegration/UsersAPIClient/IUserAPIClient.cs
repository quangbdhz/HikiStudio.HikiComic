using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users;
using HikiComic.ViewModels.Users.UserDataRequest;

namespace HikiComic.ApiIntegration.UsersAPIClient
{
    public interface IUserAPIClient
    {
        Task<ApiResult<string>> Login(UserLoginRequest request);

        Task<ApiResult<bool>> CreateUser(UserRegisterRequest request);

        Task<ApiResult<UserViewModel>> GetUserByUserId(Guid userId);

        Task<ApiResult<UserViewModel>> GetUserByUserId();

        Task<PagingResult<UserViewModel>> GetPagingManagement(PagingRequest request);

        Task<PagingResult<UserViewModel>> AdminGetPagingManagement(PagingRequest request);

        Task<ApiResult<UserViewModel>> UpdateUser(UpdateUserRequest request);

        Task<ApiResult<bool>> DeleteUser(DeleteUsersRequest request);

        Task<ApiResult<bool>> RestoreDeletedUser(Guid userId);

        Task<ApiResult<bool>> LockoutEnabledUser(Guid userId);

        Task<ApiResult<bool>> CreateUserAndAssignRole(CreateUserAndAssignRoleRequest request);

        Task<ApiResult<bool>> ResendMailConfirmation(string email);

        Task<ApiResult<bool>> VerifyTokenEmailConfirmation(string token);

        Task<ApiResult<bool>> UserEmailConfirmationAndChangePassword(VerifyTokenEmailAndChangePasswordRequest request);
    }
}

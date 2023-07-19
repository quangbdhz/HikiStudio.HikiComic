using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users;
using HikiComic.ViewModels.Users.UserDataRequest;

namespace HikiComic.Application.Users
{
    public interface IUserService
    {
        Task<PagingResult<UserViewModel>> GetPagingManagement(PagingRequest request, bool isAdmin = false);

        Task<ApiResult<UserViewModel>> GetUserByUserEmail(string email);

        Task<ApiResult<UserViewModel>> GetUserByUserId(Guid userId);

        Task<ApiResult<bool>> SendMailConfirmation(string email, MailTypeEnum mailType, string link, bool isChecked = false);

        Task<ApiResult<bool>> CreateUserAndAssignRole(CreateUserAndAssignRoleRequest request);

        Task<ApiResult<bool>> ResendMailConfirmation(string email);

        Task<ApiResult<bool>> VerifyTokenEmailConfirmation(string token);

        Task<ApiResult<bool>> UserEmailConfirmationAndChangePassword(VerifyTokenEmailAndChangePasswordRequest request);

        Task<ApiResult<UserViewModel>> UpdateUser(Guid userId, UpdateUserRequest request);

        Task<ApiResult<bool>> DeleteUser(Guid userId);

        Task<ApiResult<bool>> DeleteUsers(DeleteUsersRequest request);

        Task<ApiResult<bool>> RestoreDeletedUser(Guid userId);

        Task<ApiResult<bool>> LockoutEnabledUser(Guid userId);
    }
}

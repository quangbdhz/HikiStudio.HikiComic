using HikiComic.ViewModels.Accounts;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users.UserDataRequest;

namespace HikiComic.ApiIntegration.AccountsAPIClient
{
    public interface IAccountAPIClient
    {
        Task<ApiResult<AccountViewModel>> GetAccountByUserId(Guid userId);

        Task<ApiResult<bool>> ChangePassword(ChangePasswordUserRequest request);

        Task<ApiResult<bool>> ChangeAvatar(ChangeAvatarUserRequest request);
    }
}

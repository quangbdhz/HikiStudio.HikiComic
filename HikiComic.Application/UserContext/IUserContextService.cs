using HikiComic.ViewModels.Common;

namespace HikiComic.Application.UserContext
{
    public interface IUserContextService
    {
        public ApiResult<Guid> GetUserIdFromToken();

        public ApiResult<bool> CheckUserRoleAdminOrTeamMember();

        public ApiResult<string> GetUserURLImageAvatar();
    }
}

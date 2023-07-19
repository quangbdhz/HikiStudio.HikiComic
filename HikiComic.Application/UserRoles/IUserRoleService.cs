using HikiComic.ViewModels.Common;

namespace HikiComic.Application.UserRoles
{
    public interface IUserRoleService
    {
        public Task<ApiResult<bool>> CreateUserRoles(IList<Guid> roles, Guid userId);
    }
}

using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using System.Security.Claims;

namespace HikiComic.Application.UserContext
{
    public class UserContextService : IUserContextService
    {
        private readonly ClaimsPrincipal _user;

        public UserContextService(ClaimsPrincipal user)
        {
            _user = user;
        }

        //return true -> is admin or team members
        public ApiResult<bool> CheckUserRoleAdminOrTeamMember()
        {
            var claimRole = _user.FindFirst(ClaimTypes.Role)?.Value;

            if (String.IsNullOrEmpty(claimRole))
                return new ApiErrorResult<bool>();

            var roles = claimRole.Split(',');

            bool isHighRole = roles.Contains(SystemConstants.AppSettings.AdminRole) || roles.Contains(SystemConstants.AppSettings.TeamMembersRole);

            return new ApiSuccessResult<bool>() { ResultObj = isHighRole };
        }

        public ApiResult<Guid> GetUserIdFromToken()
        {
            var getClaimUserId = _user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return new ApiErrorResult<Guid>() { Message = "User ID not found in token." };

            Guid userId;
            if (!Guid.TryParse(getClaimUserId, out userId))
                return new ApiErrorResult<Guid>() { Message = "Invalid User ID format in token." };

            return new ApiSuccessResult<Guid>() { ResultObj = userId };

        }

        public ApiResult<string> GetUserURLImageAvatar()
        {
            var urlImageAvatar = _user.FindFirst(c => c.Type == ClaimTypes.Uri)?.Value;

            if (String.IsNullOrEmpty(urlImageAvatar))
                return new ApiErrorResult<string>();

            return new ApiSuccessResult<string>() { ResultObj = urlImageAvatar };
        }
    }
}

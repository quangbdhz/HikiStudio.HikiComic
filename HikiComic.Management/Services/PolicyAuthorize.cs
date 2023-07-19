using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;

namespace HikiComic.Management.Services
{
    public class PolicyAuthorize : IPolicyAuthorize
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PolicyAuthorize(IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)
        {
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
        }



        public PolicyEnum GetPolicyOfUser(bool isDashboard = false)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var user = httpContext.User;

                var adminPolicyResult = _authorizationService.AuthorizeAsync(user, SystemConstants.AppSettings.AdminPolicy);
                var teamMembersPolicyResult = _authorizationService.AuthorizeAsync(user, SystemConstants.AppSettings.TeamMembersPolicy);
                var creatorPolicyResult = _authorizationService.AuthorizeAsync(user, SystemConstants.AppSettings.CreatorPolicy);
                var readerPolicyResult = _authorizationService.AuthorizeAsync(user, SystemConstants.AppSettings.ReaderPolicy);
                var adminOrTeamMembersPolicyResult = _authorizationService.AuthorizeAsync(user, SystemConstants.AppSettings.AdminOrTeamMembersPolicy);

                if (isDashboard)
                {
                    if (adminPolicyResult.Result.Succeeded)
                    {
                        return PolicyEnum.AdminPolicy;
                    }
                    else if (teamMembersPolicyResult.Result.Succeeded)
                    {
                        return PolicyEnum.TeamMembersPolicy;
                    }
                    else if (creatorPolicyResult.Result.Succeeded)
                    {
                        return PolicyEnum.CreatorPolicy;
                    }
                    else if (readerPolicyResult.Result.Succeeded)
                    {
                        return PolicyEnum.ReaderPolicy;
                    }
                }
                else
                {
                    if (adminPolicyResult.Result.Succeeded || adminOrTeamMembersPolicyResult.Result.Succeeded)
                    {
                        return PolicyEnum.AdminPolicy;
                    }
                    else if (teamMembersPolicyResult.Result.Succeeded)
                    {
                        return PolicyEnum.TeamMembersPolicy;
                    }
                    else if (creatorPolicyResult.Result.Succeeded)
                    {
                        return PolicyEnum.CreatorPolicy;
                    }
                    else if (readerPolicyResult.Result.Succeeded)
                    {
                        return PolicyEnum.ReaderPolicy;
                    }
                }
                
            }

            return PolicyEnum.DoesNotHavePermission;
        }

    }
}

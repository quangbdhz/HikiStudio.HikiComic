using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace HikiComic.Application.UserRoles
{
    public class UserRoleService : IUserRoleService
    {
        private readonly HikiComicDbContext _context;

        private readonly IUserContextService _userContextService;

        public UserRoleService(HikiComicDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task<ApiResult<bool>> CreateUserRoles(IList<Guid> roles, Guid userId)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var existingRoles = await _context.Roles
                .Where(x => roles.Contains(x.Id) && !x.IsDeleted)
                .Select(x => x.Id)
                .ToListAsync();

            var existingRolesSet = new HashSet<Guid>(existingRoles);

            var errorBuilder = new StringBuilder();

            foreach (var role in roles)
            {
                if (!existingRolesSet.Contains(role))
                {
                    errorBuilder.AppendLine(MessageConstants.ObjectNotFound("RoleId: " + role));
                }
                else
                {
                    var checkUserRoleAlreadyExists = await _context.UserRoles
                        .Include(x => x.AppRole)
                        .FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == role);

                    if (checkUserRoleAlreadyExists != null)
                    {
                        errorBuilder.AppendLine(MessageConstants.ObjectAlreadyExists("RoleName: " + checkUserRoleAlreadyExists.AppRole.Name));
                    }
                    else
                    {
                        var userRole = new AppUserRole { UserId = userId, RoleId = role, AppUserRoleId = new Guid() };
                        await _context.UserRoles.AddAsync(userRole);
                    }
                }
            }

            if (errorBuilder.Length > 0)
                return new ApiErrorResult<bool> { Message = errorBuilder.ToString() };

            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool> { Message = MessageConstants.OperationSuccess(Utilities.Enums.OperationTypeEnum.Create, nameof(AppUserRole), 0) };
        }

    }
}

using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Authors;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Roles;
using HikiComic.ViewModels.Roles.RoleDataRequest;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Dynamic.Core;
using System.Text;

namespace HikiComic.Application.Roles
{
    public class RoleService : IRoleService
    {
        private readonly HikiComicDbContext _context;

        private readonly RoleManager<AppRole> _roleManager;

        private readonly IUserContextService _userContextService;

        public RoleService(HikiComicDbContext context, IUserContextService userContextService, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userContextService = userContextService;
            _roleManager = roleManager;
        }

        public async Task<ApiResult<bool>> CreateRole(CreateRoleRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var checkRoleNameAlreadyExists = await _context.Roles.FirstOrDefaultAsync(x => x.Name.ToLower() == request.RoleName.ToLower());

            if (checkRoleNameAlreadyExists != null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectAlreadyExists("Role") };

            var role = new AppRole()
            {
                Id = new Guid(),
                Name = request.RoleName.ToLower(),
                Description = request.Description,
                Priority = request.Priority,
                IsDeleted = false,
                CreatedBy = userResult.ResultObj,
                DateCreated = DateTime.Now,
                NormalizedName = request.RoleName.Normalize().ToUpperInvariant()
            };

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurred };

            return new ApiSuccessResult<bool>() { Message = MessageConstants.OperationSuccess(OperationTypeEnum.Create, nameof(AppRole), 1) };
        }

        public async Task<ApiResult<bool>> DeleteRoles(DeleteRolesRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var validRoleIds = request.RoleIds.Where(id => id != Guid.Empty).ToList();

            var existingRoles = await _context.Roles
                .Where(x => validRoleIds.Contains(x.Id))
                .ToListAsync();

            var errorMessageBuilder = new StringBuilder();

            foreach (var role in existingRoles)
            {
                if (role.IsDeleted == true)
                {
                    errorMessageBuilder.AppendLine("Role with Id: " + role.Id + " deleted.");
                }
                else
                {
                    role.IsDeleted = true;
                    role.DateUpdated = DateTime.Now;
                    role.UpdatedBy = userResult.ResultObj;
                }
            }

            if (errorMessageBuilder.Length > 0)
            {
                var errorMessage = errorMessageBuilder.ToString().Trim();
                return new ApiErrorResult<bool>(errorMessage);
            }
            else
            {
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess(nameof(AppRole)) };
            }
        }

        public async Task<ApiResult<List<RoleViewModel>>> GetAllRoles(bool isPriorityMediumToHigh = true)
        {
            var roleViewModels = await _context.Roles.Where(x => (int)x.Priority > 2).Select(x => new RoleViewModel()
            {
                RoleId = x.Id,
                RoleName = x.Name,
                Description = x.Description,
                Priority = x.Priority,
                IsDeleted = x.IsDeleted,
                CreatedBy = x.CreatedBy,
                DateCreated = x.DateCreated,
                UpdatedBy = x.UpdatedBy,
                DateUpdated = x.DateUpdated
            }).OrderByDescending(x => x.Priority).ToListAsync();

            return new ApiSuccessResult<List<RoleViewModel>>() { ResultObj = roleViewModels, Message = MessageConstants.GetObjectSuccess("Roles") };
        }

        public async Task<PagingResult<RoleViewModel>> GetPagingManagement(PagingRequest request)
        {
            var roleViewModels = await _context.Roles.Select(x => new RoleViewModel()
            {
                RoleId = x.Id,
                RoleName = x.Name,
                Description = x.Description,
                Priority = x.Priority,
                PriorityName = x.Priority.ToString(),
                IsDeleted = x.IsDeleted,
                CreatedBy = x.CreatedBy,
                DateCreated = x.DateCreated,
                UpdatedBy = x.UpdatedBy,
                DateUpdated = x.DateUpdated
            }).OrderByDescending(x => x.RoleId).ToListAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                roleViewModels = await _context.Roles.Select(x => new RoleViewModel()
                {
                    RoleId = x.Id,
                    RoleName = x.Name,
                    Description = x.Description,
                    Priority = x.Priority,
                    PriorityName = x.Priority.ToString(),
                    IsDeleted = x.IsDeleted,
                    CreatedBy = x.CreatedBy,
                    DateCreated = x.DateCreated,
                    UpdatedBy = x.UpdatedBy,
                    DateUpdated = x.DateUpdated
                }).OrderBy(request.SortColumn + " " + request.SortColumnDirection).ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                roleViewModels = roleViewModels.Where(x => x.RoleName.ToLower().Contains(request.SearchValue.ToLower())).ToList();
            }

            request.RecordsTotal = roleViewModels.Count();
            var data = roleViewModels.Skip(request.Skip).Take(request.PageSize).ToList();

            var jsonData = new { draw = request.Draw, recordsFiltered = request.RecordsTotal, recordsTotal = request.RecordsTotal, data = data };

            var result = new PagingResult<RoleViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = data
            };

            return result;
        }

        public async Task<ApiResult<RoleViewModel>> GetRoleByRoleId(Guid roleId)
        {
            var query = from r in _context.Roles where r.Id == roleId
                        join cb in _context.Users on r.CreatedBy equals cb.Id into createdByGroup
                        from cb in createdByGroup.DefaultIfEmpty()
                        join ub in _context.Users on r.UpdatedBy equals ub.Id into updatedByGroup
                        from ub in updatedByGroup.DefaultIfEmpty()
                        select new { r, cb, ub };

            var role = await query.Select(x => new RoleViewModel()
            {
                RoleId = roleId,
                RoleName = x.r.Name,
                Description = x.r.Description,
                Priority = x.r.Priority,
                PriorityName = x.r.Priority.ToString(),
                IsDeleted = x.r.IsDeleted,
                UserNameCreatedBy = x.cb.UserName,
                DateCreated = x.r.DateCreated,
                UserNameUpdatedBy = x.ub.UserName,
                DateUpdated = x.r.DateUpdated
            }).FirstOrDefaultAsync();

            if (role is null)
                return new ApiErrorResult<RoleViewModel>() { Message = MessageConstants.ObjectNotFound(nameof(AppRole)) };

            return new ApiSuccessResult<RoleViewModel>() { Message = MessageConstants.GetObjectSuccess(nameof(AppRole)), ResultObj = role };
        }

        public async Task<ApiResult<bool>> RestoreRole(Guid roleId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var checkRoleAlreadyExists = await _roleManager.FindByIdAsync(roleId.ToString());

            if (checkRoleAlreadyExists is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Role") };

            if (!checkRoleAlreadyExists.IsDeleted)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectAlreadyRestored(nameof(AppRole), checkRoleAlreadyExists.Name) };

            checkRoleAlreadyExists.IsDeleted = false;
            checkRoleAlreadyExists.DateUpdated = DateTime.Now;
            checkRoleAlreadyExists.UpdatedBy = userResult.ResultObj;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.OperationSuccess(OperationTypeEnum.Restore, nameof(AppRole), checkRoleAlreadyExists.Name, "RoleName") };
        }

        public async Task<ApiResult<bool>> UpdateRole(UpdateRoleRequest request, Guid roleId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var checkRoleAlreadyExists = await _roleManager.FindByIdAsync(roleId.ToString());

            if (checkRoleAlreadyExists is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Role") };

            var checkRoleNameAlreadyExists = await _context.Roles.FirstOrDefaultAsync(x => x.Id != roleId && x.Name.ToLower() == request.RoleName.ToLower());

            if (checkRoleNameAlreadyExists != null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectAlreadyExists("Role") };

            checkRoleAlreadyExists.Name = request.RoleName.ToLower();
            checkRoleAlreadyExists.NormalizedName = request.RoleName.Normalize().ToUpperInvariant();
            checkRoleAlreadyExists.Description = request.Description;
            checkRoleAlreadyExists.Priority = request.Priority;
            checkRoleAlreadyExists.DateUpdated = DateTime.Now;
            checkRoleAlreadyExists.UpdatedBy = userResult.ResultObj;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.OperationSuccess(OperationTypeEnum.Update, nameof(AppRole), request.RoleName, "RoleName") };
        }
    }
}

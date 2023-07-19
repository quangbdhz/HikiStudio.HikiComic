using HikiComic.Application.Accounts;
using HikiComic.Application.Common;
using HikiComic.Application.SendMails;
using HikiComic.Application.UserContext;
using HikiComic.Application.UserRoles;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Accounts.AccountDataRequest;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Roles;
using HikiComic.ViewModels.Users;
using HikiComic.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Text;

namespace HikiComic.Application.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly HikiComicDbContext _context;

        private readonly IUserContextService _userContextService;

        private readonly IUserRoleService _userRoleService;

        private readonly ISendMailService _sendMailService;

        private readonly ICommonService _commonService;

        private readonly IConfiguration _configuration;

        private readonly IAccountService _accountService;

        public UserService(HikiComicDbContext context, UserManager<AppUser> userManager, IUserContextService userContextService, IAccountService accountService,
            IUserRoleService userRoleService, ISendMailService sendMailService, ICommonService commonService, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _userContextService = userContextService;
            _userRoleService = userRoleService;
            _sendMailService = sendMailService;
            _commonService = commonService;
            _configuration = configuration;
            _accountService = accountService;
        }

        public async Task<PagingResult<UserViewModel>> GetPagingManagement(PagingRequest request, bool isAdmin = false)
        {
            var query = from u in _context.Users
                        join ur in _context.UserRoles on u.Id equals ur.UserId
                        join r in _context.Roles on ur.RoleId equals r.Id
                        select new { u, r };

            //filter user by role admin and teamMembers
            if(isAdmin)
                query = query.Where(x => x.r.Priority != RolePriorityEnum.None && x.r.Priority != RolePriorityEnum.Low);

            var userViewModels = await query.OrderByDescending(x => x.u.Id).Select(x => new UserViewModel()
            {
                Id = x.u.Id,
                UserName = x.u.UserName,
                FirstName = x.u.FirstName,
                LastName = x.u.LastName,
                Email = x.u.Email,
                EmailConfirmed = x.u.EmailConfirmed,
                PhoneNumber = x.u.PhoneNumber,
                PhoneNumberConfirmed = x.u.PhoneNumberConfirmed,
                DOB = x.u.DOB,
                IsDeleted = x.u.IsDeleted,
                LockoutEnabled = x.u.LockoutEnabled,
                Roles = query.Where(q => q.u.Id == x.u.Id).Select(x => new RoleViewModel()
                {
                    RoleName = x.r.Name,
                    Priority = x.r.Priority
                }).ToList()
            }).ToListAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                userViewModels = await query.Select(x => new UserViewModel()
                {
                    Id = x.u.Id,
                    UserName = x.u.UserName,
                    FirstName = x.u.FirstName,
                    LastName = x.u.LastName,
                    Email = x.u.Email,
                    EmailConfirmed = x.u.EmailConfirmed,
                    PhoneNumber = x.u.PhoneNumber,
                    PhoneNumberConfirmed = x.u.PhoneNumberConfirmed,
                    DOB = x.u.DOB,
                    IsDeleted = x.u.IsDeleted,
                    LockoutEnabled = x.u.LockoutEnabled,
                    Roles = query.Where(q => q.u.Id == x.u.Id).Select(x => new RoleViewModel()
                    {
                        RoleName = x.r.Name,
                        Priority = x.r.Priority
                    }).ToList()
                }).OrderBy(request.SortColumn + " " + request.SortColumnDirection).ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                userViewModels = userViewModels.Where(x => (x.Roles != null && x.Roles.Any(role => role.RoleName.IndexOf(request.SearchValue, StringComparison.OrdinalIgnoreCase) >= 0)) ||
                                                            x.UserName.ToLower().Contains(request.SearchValue.ToLower()) || x.Email.ToLower().Contains(request.SearchValue.ToLower())).ToList();
            }

            //get user has role creator (low priority) and reader (none priority)
            if (!isAdmin)
                userViewModels = userViewModels.Where(x => x.Roles != null && x.Roles.Any(r => r.Priority == RolePriorityEnum.None || r.Priority == RolePriorityEnum.Low)).ToList();

            var groupedUserViewModels = userViewModels.GroupBy(x => x.Id).Select(g => g.First()).ToList();

            request.RecordsTotal = groupedUserViewModels.Count();
            var data = groupedUserViewModels.Skip(request.Skip).Take(request.PageSize).ToList();

            var jsonData = new { draw = request.Draw, recordsFiltered = request.RecordsTotal, recordsTotal = request.RecordsTotal, data = data };

            var result = new PagingResult<UserViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = data
            };

            return result;
        }

        public async Task<ApiResult<UserViewModel>> GetUserByUserEmail(string email)
        {
            email = WebUtility.UrlDecode(email);
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return new ApiErrorResult<UserViewModel>(MessageConstants.ObjectNotFound("Email"));

            if (user.LockoutEnabled)
                return new ApiErrorResult<UserViewModel>() { Message = MessageConstants.AccountLocked };

            if (user.IsDeleted)
                return new ApiErrorResult<UserViewModel>() { Message = MessageConstants.AccountDeleted };

            var roles = await _userManager.GetRolesAsync(user);

            var gender = await _context.Genders.FirstOrDefaultAsync(x => x.GenderId == user.GenderId);

            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                DOB = user.DOB,
                UserImageURL = user.UserImageURL,
                IsDeleted = user.IsDeleted,
                GenderName = gender != null ? gender.GenderName : null,
                StringRoles = roles
            };

            return new ApiSuccessResult<UserViewModel>(userViewModel);
        }

        public async Task<ApiResult<UserViewModel>> GetUserByUserId(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
                return new ApiErrorResult<UserViewModel>(MessageConstants.ObjectNotFound("Id"));

            //if (user.IsDeleted)
            //    return new ApiErrorResult<UserViewModel>() { Message = "User is locked" };

            var roles = await _userManager.GetRolesAsync(user);

            var gender = await _context.Genders.FirstOrDefaultAsync(x => x.GenderId == user.GenderId);

            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                DOB = user.DOB,
                UserImageURL = user.UserImageURL,
                IsDeleted = user.IsDeleted,
                GenderName = gender != null ? gender.GenderName : null,
                StringRoles = roles
            };

            return new ApiSuccessResult<UserViewModel>(userViewModel);
        }

        public async Task<ApiResult<bool>> DeleteUser(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));
            }

            user.IsDeleted = true;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>(MessageConstants.DeleteSuccess("User"));
            }
            return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurred };
        }

        public async Task<ApiResult<bool>> DeleteUsers(DeleteUsersRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var validUserIds = request.UserIds.Where(id => id != Guid.Empty).ToList();

            var existingUsers = await _context.Users
                .Where(x => validUserIds.Contains(x.Id))
                .ToListAsync();

            var errorMessageBuilder = new StringBuilder();

            foreach (var user in existingUsers)
            {
                if (user.IsDeleted == true)
                {
                    errorMessageBuilder.AppendLine("User with Id: " + user.Id + " deleted.");
                }
                else
                {
                    user.IsDeleted = true;
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
                return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess(nameof(AppUser)) };
            }
        }

        public async Task<ApiResult<bool>> LockoutEnabledUser(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Id"));

            user.LockoutEnabled = !user.LockoutEnabled;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                if (user.LockoutEnabled)
                    return new ApiSuccessResult<bool>() { Message = MessageConstants.AccountLocked };
                else
                    return new ApiSuccessResult<bool>() { Message = MessageConstants.AccountUnlocked };
            }
            return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurred };

        }

        public async Task<ApiResult<bool>> RestoreDeletedUser(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));
            }

            user.IsDeleted = false;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>(MessageConstants.RestoreObjectSuccess("User"));
            }
            return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurred };
        }

        public async Task<ApiResult<UserViewModel>> UpdateUser(Guid userId, UpdateUserRequest request)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null)
                return new ApiErrorResult<UserViewModel>() { Message = MessageConstants.ObjectNotFound("User") };

            var gender = await _context.Genders.FirstOrDefaultAsync(x => x.GenderId == request.GenderId);
            if (gender is null)
                return new ApiErrorResult<UserViewModel>() { Message = MessageConstants.ObjectNotFound("Gender") };

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.DOB = request.DOB;
            user.GenderId = request.GenderId;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                var userViewModel = new UserViewModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    DOB = user.DOB,
                    GenderName = gender.GenderName
                };

                return new ApiSuccessResult<UserViewModel>() { Message = MessageConstants.UpdateSuccess("User"), ResultObj = userViewModel };
            }
            return new ApiErrorResult<UserViewModel>() { Message = MessageConstants.AnErrorOccurred };
        }

        public async Task<ApiResult<bool>> SendMailConfirmation(string email, MailTypeEnum mailType, string link, bool isChecked = false)
        {
            if (!isChecked)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

                if (user is null)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound(nameof(AppUser)) };

                if (user.EmailConfirmed)
                    return new ApiSuccessResult<bool>() { Message = MessageConstants.UserEmailConfirmationVerificationSuccess };
            }

            var sendMailConfirmation = await _sendMailService.SendMailOTP(email, mailType, link);

            return sendMailConfirmation;
        }

        public async Task<ApiResult<bool>> CreateUserAndAssignRole(CreateUserAndAssignRoleRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            if (!request.Email.EndsWith("@" + SystemConstants.AppSettings.DomainMyHost))
                return new ApiErrorResult<bool>() { Message = $"Invalid email, it should have the {SystemConstants.AppSettings.DomainMyHost} domain." };

            var checkEmailAlreadyExists = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (checkEmailAlreadyExists != null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectAlreadyExists("Email: " + request.Email) };

            var checkUserNameAlreadyExitst = await _context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == request.UserName.ToLower());
            if (checkUserNameAlreadyExitst != null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectAlreadyExists("Username: " + request.UserName) };

            var roleReader = await _context.Roles.FirstOrDefaultAsync(x => x.Name.ToLower() == SystemConstants.AppSettings.ReaderRole);
            if (roleReader is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("RoleName: Reader") };

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = new AppUser()
                    {
                        UserName = request.UserName,
                        NormalizedUserName = request.UserName.Normalize().ToUpperInvariant(),
                        Email = request.Email,
                        NormalizedEmail = request.Email.Normalize().ToUpperInvariant(),
                        EmailConfirmed = false,
                        IsDeleted = false,
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        DateCreated = DateTime.Now,
                        CreatedBy = userResult.ResultObj,
                        FirstName = null,
                        LastName = null,
                        DOB = null,
                        GenderId = null,
                        Account = new Account()
                        {
                            CoinsDeposited = 0,
                            CoinsLeft = 0,
                            CoinsSpent = 0,
                            CoinsReceived = 0,
                            Experienced = 0,
                            DateModified = DateTime.Now,
                            MoreInfo = null,
                            Nickname = request.UserName
                        }
                    };

                    var resultCreateAppUser = await _userManager.CreateAsync(user, "Abcd1234$");
                    if (!resultCreateAppUser.Succeeded)
                    {
                        await transaction.RollbackAsync();
                        return new ApiErrorResult<bool>() { Message = MessageConstants.FeatureAnErrorOccurred(nameof(CreateUserAndAssignRole)) };
                    }

                    request.RoleIds.Add(roleReader.Id);

                    var resultAssignRole = await _userRoleService.CreateUserRoles(request.RoleIds, user.Id);
                    if (!resultAssignRole.IsSuccessed)
                    {
                        await transaction.RollbackAsync();
                        return new ApiErrorResult<bool>() { Message = resultAssignRole.Message };
                    }

                    var resultGenerateToken = _commonService.GenerateToken(user.Id.ToString(), _configuration["Tokens:Key"] ?? "", 48);
                    if (!resultGenerateToken.IsSuccessed)
                    {
                        await transaction.RollbackAsync();
                        return new ApiErrorResult<bool>() { Message = resultGenerateToken.Message };
                    }

                    var sendMailConfirmation = await SendMailConfirmation(request.Email, MailTypeEnum.EmailConfirmation, SystemConstants.AppSettings.URLDomainMyHostDevelopment + "verify-email?token=" + resultGenerateToken.ResultObj, true);
                    if (!sendMailConfirmation.IsSuccessed)
                    {
                        await transaction.RollbackAsync();
                        return new ApiErrorResult<bool>() { Message = sendMailConfirmation.Message };
                    }

                    await transaction.CommitAsync();
                    return new ApiSuccessResult<bool>() { Message = MessageConstants.EmailConfirmationInstructionsSuccess };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(CreateUserAndAssignRole), ex.Message) };
                }
            }
        }

        public async Task<ApiResult<bool>> ResendMailConfirmation(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound(nameof(AppUser)) };

            if (user.EmailConfirmed)
                return new ApiSuccessResult<bool>() { Message = MessageConstants.UserEmailConfirmationVerificationSuccess };

            var resultGenerateToken = _commonService.GenerateToken(user.Id.ToString(), _configuration["Tokens:Key"] ?? "", 48);
            if (!resultGenerateToken.IsSuccessed)
                return new ApiErrorResult<bool>() { Message = resultGenerateToken.Message };

            var sendMailConfirmation = await SendMailConfirmation(email, MailTypeEnum.EmailConfirmation, SystemConstants.AppSettings.URLDomainMyHostDevelopment + "verify-email?token=" + resultGenerateToken.ResultObj, true);
            if (!sendMailConfirmation.IsSuccessed)
                return new ApiErrorResult<bool>() { Message = sendMailConfirmation.Message };

            return sendMailConfirmation;
        }

        public async Task<ApiResult<bool>> VerifyTokenEmailConfirmation(string token)
        {
            var result = _commonService.VerifyToken(token, _configuration["Tokens:Key"] ?? "");

            if (!result.IsSuccessed)
                return new ApiErrorResult<bool>() { Message = result.Message };

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == result.ResultObj);

            if (user is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("User") };

            if (user.EmailConfirmed)
                return new ApiSuccessResult<bool>() { StatusCode = StatusCodeEnum.EmailVerified };

            return new ApiSuccessResult<bool>() { Message = "Information verified successfully." };
        }

        public async Task<ApiResult<bool>> UserEmailConfirmationAndChangePassword(VerifyTokenEmailAndChangePasswordRequest request)
        {
            var result = _commonService.VerifyToken(request.Token, _configuration["Tokens:Key"] ?? "");

            if (!result.IsSuccessed)
                return new ApiErrorResult<bool>() { Message = result.Message };

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == result.ResultObj);

            if (user is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound(nameof(AppUser)) };

            if (user.IsPasswordChanged)
                return new ApiSuccessResult<bool>() { StatusCode = StatusCodeEnum.EmailVerified };

            var resultResetPassword = await _accountService.ResetPassword(new ResetPasswordRequest()
            {
                Email = user.Email,
                NewPassword = request.Password,
                ConfirmPassword = request.ConfirmPassword
            }, true);

            if (!resultResetPassword.IsSuccessed)
                return new ApiErrorResult<bool>() { Message = resultResetPassword.Message };

            user.EmailConfirmed = true;
            user.IsPasswordChanged = true;
            user.DatePasswordChanged = DateTime.Now;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = result.Message, ResultObj = true };
        }
    }
}

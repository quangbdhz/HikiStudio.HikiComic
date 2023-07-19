using HikiComic.ApiIntegration.AccountsAPIClient;
using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.ApiIntegration.RolesAPIClient;
using HikiComic.ApiIntegration.UsersAPIClient;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Users;
using HikiComic.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
    [Route("accounts/admins")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminPolicy)]
    public class AdminsController : BaseController
    {
        private readonly IUserAPIClient _userAPIClient;

        private readonly IRoleAPIClient _roleAPIClient;

        private readonly IAccountAPIClient _accountAPIClient;

        private readonly INotificationAPIClient _notificationAPIClient;

        public AdminsController(IUserAPIClient userAPIClient, IRoleAPIClient roleAPIClient, IAccountAPIClient accountAPIClient, 
            INotificationAPIClient notificationAPIClient)
        {
            _userAPIClient = userAPIClient;
            _roleAPIClient = roleAPIClient;
            _accountAPIClient = accountAPIClient;
            _notificationAPIClient = notificationAPIClient;
        }

        private async Task InitNotifications()
        {
            var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForAdminAndTeamMembers(new ViewModels.Common.PagingRequestBase() { PageIndex = 1, PageSize = 7});
            ViewData["Notifications"] = notificationsResult.Items;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _roleAPIClient.GetAllRoles();
            if (!result.IsSuccessed)
                return RedirectToAction("Index", "Home");
            
            await InitNotifications();

            ViewData["roles"] = result.ResultObj;

            await InitNotifications();

            return View();
        }

        [HttpPost("get-users")]
        public async Task<IActionResult> Users()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var orderBy = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumn = Request.Form[$"columns[{orderBy}][name]"].FirstOrDefault()?.Replace(" ", "");
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var pagingRequest = new PagingRequest()
                {
                    Draw = draw,
                    Start = start,
                    Length = length,
                    SortColumn = sortColumn,
                    SortColumnDirection = sortColumnDirection,
                    SearchValue = searchValue,
                    PageSize = pageSize,
                    Skip = skip,
                    RecordsTotal = recordsTotal
                };

                var data = await _userAPIClient.AdminGetPagingManagement(pagingRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("user-lock")]
        public async Task<IActionResult> UserLock([FromBody] Guid userId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("User Lock")));

            if (userId == Guid.Empty)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User")));

            var result = await _userAPIClient.LockoutEnabledUser(userId);
            return Ok(result);
        }

        [HttpPost("unlock-user")]
        public async Task<IActionResult> UnlockUser([FromBody] Guid userId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("User Unlock")));

            if (userId == Guid.Empty)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User")));

            var result = await _userAPIClient.LockoutEnabledUser(userId);
            return Ok(result);
        }

        [HttpDelete("delete-users")]
        public async Task<IActionResult> DeleteAuthors([FromBody] DeleteUsersRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Users")));

            var result = await _userAPIClient.DeleteUser(request);

            return Ok(result);
        }

        [HttpPost("restore-user")]
        public async Task<IActionResult> RestoreUser([FromBody] Guid userId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Restore User")));

            if (userId == Guid.Empty)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User")));

            var result = await _userAPIClient.RestoreDeletedUser(userId);
            return Ok(result);
        }

        [HttpGet("{userId}/information")]
        public async Task<IActionResult> UserInformation(Guid userId)
        {
            if (userId == Guid.Empty)
                return RedirectToAction("Index", "Admins");

            var userViewModel = await _userAPIClient.GetUserByUserId(userId);

            if (!userViewModel.IsSuccessed)
                return RedirectToAction("Index", "Admins");

            var acccountViewModel = await _accountAPIClient.GetAccountByUserId(userId);

            if (!acccountViewModel.IsSuccessed)
                return RedirectToAction("Index", "Admins");

            await InitNotifications();

            var result = new UserInformationViewModel() { Account = acccountViewModel.ResultObj, User = userViewModel.ResultObj };

            return View(result);
        }

        [HttpPost("create-user-and-assign-role")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminPolicy)]
        public async Task<IActionResult> CreateUserAndAssignRole([FromBody] CreateUserAndAssignRoleRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(CreateUserAndAssignRoleRequest)) });

            var result = await _userAPIClient.CreateUserAndAssignRole(request);

            return Ok(result);
        }

        [HttpPost("resend-mail-email-confirmation")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminPolicy)]
        public async Task<IActionResult> ResendMailConfirmation([FromBody] string email)
        {
            if (String.IsNullOrEmpty(email))
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Email") });

            var result = await _userAPIClient.ResendMailConfirmation(email);

            return Ok(result);
        }
    }
}

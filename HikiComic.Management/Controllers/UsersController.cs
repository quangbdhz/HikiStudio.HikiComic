using HikiComic.ApiIntegration.AccountsAPIClient;
using HikiComic.ApiIntegration.CommentsAPIClient;
using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.ApiIntegration.UserCoinDepositHistoriesAPIClient;
using HikiComic.ApiIntegration.UserCoinUsageHistoriesAPIClient;
using HikiComic.ApiIntegration.UsersAPIClient;
using HikiComic.Management.Extensions;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Comments.CommentDataRequest;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserCoinDepositHistories.UserCoinDepositHistoryDataRequest;
using HikiComic.ViewModels.Users;
using HikiComic.ViewModels.Users.UserDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
    [Route("accounts/users")]
    [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
    public class UsersController : BaseController
    {

        private readonly IUserAPIClient _userAPIClient;

        private readonly IAccountAPIClient _accountAPIClient;

        private readonly IUserCoinDepositHistoryAPIClient _userCoinDepositHistoryAPIClient;

        private readonly IUserCoinUsageHistoryAPIClient _userCoinUsageHistoryAPIClient;

        private readonly ICommentAPIClient _commentAPIClient;

        private readonly INotificationAPIClient _notificationAPIClient;

        public UsersController(IUserAPIClient userAPIClient, IAccountAPIClient accountAPIClient, IUserCoinDepositHistoryAPIClient userCoinDepositHistoryAPIClient,
                                IUserCoinUsageHistoryAPIClient userCoinUsageHistoryAPIClient, ICommentAPIClient commentAPIClient, INotificationAPIClient notificationAPIClient)
        {
            _userAPIClient = userAPIClient;
            _accountAPIClient = accountAPIClient;
            _userCoinDepositHistoryAPIClient = userCoinDepositHistoryAPIClient;
            _userCoinUsageHistoryAPIClient = userCoinUsageHistoryAPIClient;
            _commentAPIClient = commentAPIClient;
            _notificationAPIClient = notificationAPIClient;
        }

        private async Task InitNotifications()
        {
            var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForAdminAndTeamMembers(new ViewModels.Common.PagingRequestBase() { PageIndex = 1, PageSize = 7});
            ViewData["Notifications"] = notificationsResult.Items;
        }

        public async Task<IActionResult> Index()
        {
            HttpContext.Session.Remove("CheckUserCOINDepositHistoriesWithUserId");
            HttpContext.Session.Remove("CheckUserCOINUsageHistoriesWithUserId");

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

                var data = await _userAPIClient.GetPagingManagement(pagingRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-user-by-user-id/{userId}")]
        public async Task<IActionResult> GetUserByUserId(Guid userId)
        {
            if (userId == Guid.Empty)
                return Ok(new ApiErrorResult<UserViewModel>() { Message = MessageConstants.ObjectNotFound("User") });

            var result = await _userAPIClient.GetUserByUserId(userId);
            return Ok(result);
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
                return RedirectToAction("Index", "Users");

            var userViewModel = await _userAPIClient.GetUserByUserId(userId);

            if (!userViewModel.IsSuccessed)
                return RedirectToAction("Index", "User");

            var acccountViewModel = await _accountAPIClient.GetAccountByUserId(userId);

            if (!acccountViewModel.IsSuccessed)
            {
                if(acccountViewModel.StatusCode == Utilities.Enums.StatusCodeEnum.DoNotHavePermission)
                {
                    return RedirectToAction("403", "Error");
                }

                return RedirectToAction("Index", "User");
            }

            await InitNotifications();

            var result = new UserInformationViewModel() { Account = acccountViewModel.ResultObj, User = userViewModel.ResultObj };

            return View(result);
        }

        #region user coin deposit
        [HttpPost("get-user-coin-deposit-histories")]
        public async Task<IActionResult> UserCoinDepositHistories()
        {
            Guid userId = HttpContext.Session.Get<Guid>("CheckUserCOINDepositHistoriesWithUserId");

            if (userId == Guid.Empty)
                return BadRequest(MessageConstants.InvalidGuidFormat);

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

                var data = await _userCoinDepositHistoryAPIClient.GetUserCoinDepositHistoriesPagingManagement(pagingRequest, userId);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}/information/coin-deposit-histories")]
        public async Task<IActionResult> UserCoinDepositHistories(Guid userId)
        {
            if (userId == Guid.Empty)
                return RedirectToAction("Index", "Users");

            HttpContext.Session.Set<Guid>("CheckUserCOINDepositHistoriesWithUserId", userId);

            var userViewModel = await _userAPIClient.GetUserByUserId(userId);

            if (!userViewModel.IsSuccessed)
                return RedirectToAction("Index", "User");

            ViewBag.UserEmail = userViewModel.ResultObj.Email;

            await InitNotifications();

            return View();
        }

        [HttpGet("information/get-user-coin-deposit-history-with-user-coin-usage-history-id/{userCoinDepositHistoryId}")]
        public async Task<IActionResult> GetUserCoinDepositHistoryWithUserCoinDepositHistoryId(int userCoinDepositHistoryId)
        {
            var result = await _userCoinDepositHistoryAPIClient.GetUserCoinDepositHistoryWithUserCoinDepositHistoryId(userCoinDepositHistoryId);

            return Ok(result);
        }

        [HttpPost("{userId}/information/coin-deposit-histories/check-and-change-deposit-status")]
        public async Task<IActionResult> CheckAndChangeDepositStatus([FromBody] ChangeDepositStatusRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid("ChangeDepositStatusRequest") });

            var result = await _userCoinDepositHistoryAPIClient.CheckAndChangeDepositStatus(request);

            return Ok(result);
        }
        #endregion

        #region user coin usage
        [HttpPost("get-user-coin-usage-histories")]
        public async Task<IActionResult> UserCoinUsageHistories()
        {
            Guid userId = HttpContext.Session.Get<Guid>("CheckUserCOINUsageHistoriesWithUserId");

            if (userId == Guid.Empty)
                return BadRequest(MessageConstants.InvalidGuidFormat);

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

                var data = await _userCoinUsageHistoryAPIClient.GetUserCoinUsageHistoriesPagingManagement(pagingRequest, userId);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}/information/coin-usage-histories")]
        public async Task<IActionResult> UserCoinUsageHistories(Guid userId)
        {
            if (userId == Guid.Empty)
                return RedirectToAction("Index", "Users");

            HttpContext.Session.Set<Guid>("CheckUserCOINUsageHistoriesWithUserId", userId);

            var userViewModel = await _userAPIClient.GetUserByUserId(userId);

            if (!userViewModel.IsSuccessed)
                return RedirectToAction("Index", "User");

            ViewBag.UserEmail = userViewModel.ResultObj.Email;

            await InitNotifications();

            return View();
        }


        [HttpGet("information/user-coin-usage-histories/get-user-coin-usage-history-with-user-coin-usage-history-id/{userCoinUsageHistoryId}")]
        public async Task<IActionResult> GetUserCoinUsageHistoryWithUserCoinUsageHistoryId(int userCoinUsageHistoryId)
        {
            var result = await _userCoinUsageHistoryAPIClient.GetUserCoinUsageHistoryWithUserCoinUsageHistoryId(userCoinUsageHistoryId);

            return Ok(result);
        }
        #endregion

        [HttpGet("{userId}/comments")]
        public async Task<IActionResult> UserComment(Guid userId)
        {
            if (userId == Guid.Empty)
                return RedirectToAction("Index", "Users");

            var userViewModel = await _userAPIClient.GetUserByUserId(userId);

            if (!userViewModel.IsSuccessed)
                return RedirectToAction("Index", "User");

            ViewBag.UserEmail = userViewModel.ResultObj.Email;

            await InitNotifications();

            return View();
        }

        [HttpPost("{userId}/get-comments")]
        public async Task<IActionResult> Comments(Guid userId)
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

                var data = await _commentAPIClient.GetPagingOfUser(userId, pagingRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-comment-by-comment-id/{commentId}")]
        public async Task<IActionResult> GetArtistByArtistId(int commentId)
        {
            var result = await _commentAPIClient.GetCommentByCommentId(commentId);
            return Ok(result);
        }

        [HttpDelete("delete-comments")]
        public async Task<IActionResult> DeleteComments([FromBody] DeleteCommentsRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Comment")));

            var result = await _commentAPIClient.DeleteComments(request);

            return Ok(result);
        }

        [HttpPost("restore-comment")]
        public async Task<IActionResult> RestoreDeletedComment([FromBody] int commentId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Restore Comment")));

            var result = await _commentAPIClient.RestoreDeletedComment(commentId);
            return Ok(result);
        }
    }
}

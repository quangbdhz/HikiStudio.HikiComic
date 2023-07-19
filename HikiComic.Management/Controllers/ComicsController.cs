using HikiComic.ApiIntegration.ArtistsAPIClient;
using HikiComic.ApiIntegration.AuthorsAPIClient;
using HikiComic.ApiIntegration.ChaptersAPIClient;
using HikiComic.ApiIntegration.ComicDetailsAPIClient;
using HikiComic.ApiIntegration.ComicsAPIClient;
using HikiComic.ApiIntegration.CommentsAPIClient;
using HikiComic.ApiIntegration.GenresAPIClient;
using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.Management.Extensions;
using HikiComic.Management.Services;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Chapters;
using HikiComic.ViewModels.ComicDetails;
using HikiComic.ViewModels.Comics.ComicDataRequest;
using HikiComic.ViewModels.Comments.CommentDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
    [Route("comics")]
    [Authorize]
    public class ComicsController : BaseController
    {
        private readonly IComicAPIClient _comicAPIClient;

        private readonly IComicDetailAPIClient _comicDetailAPIClient;

        private readonly IGenreAPIClient _genreAPIClient;

        private readonly IArtistAPIClient _artistAPIClient;

        private readonly IAuthorAPIClient _authorAPIClient;

        private readonly ICommentAPIClient _commentAPIClient;

        private readonly IPolicyAuthorize _policyAuthorize;

        private readonly IChapterAPIClient _chapterAPIClient;

        private readonly INotificationAPIClient _notificationAPIClient;

        public ComicsController(IComicAPIClient comicAPIClient, IComicDetailAPIClient comicDetailAPIClient, ICommentAPIClient commentAPIClient, IChapterAPIClient chapterAPIClient,
            IGenreAPIClient genreAPIClient, IArtistAPIClient artistAPIClient, IAuthorAPIClient authorAPIClient, IPolicyAuthorize policyAuthorize, INotificationAPIClient notificationAPIClient)
        {
            _comicAPIClient = comicAPIClient;
            _comicDetailAPIClient = comicDetailAPIClient;
            _chapterAPIClient = chapterAPIClient;
            _genreAPIClient = genreAPIClient;
            _artistAPIClient = artistAPIClient;
            _authorAPIClient = authorAPIClient;
            _commentAPIClient = commentAPIClient;
            _policyAuthorize = policyAuthorize;
            _notificationAPIClient = notificationAPIClient;
        }

        private async Task InitNotifications()
        {
            var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForAdminAndTeamMembers(new ViewModels.Common.PagingRequestBase() { PageIndex = 1, PageSize = 7});
            ViewData["Notifications"] = notificationsResult.Items;
        }

        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> Index()
        {
            HttpContext.Session.Set<ComicDetailViewModel>("ComicCurrent", new ComicDetailViewModel() { ComicId = -1 });
            HttpContext.Session.Set<ChapterDetailViewModel>("ChapterCurrent", new ChapterDetailViewModel() { ChapterId = -1 });

            var policy = _policyAuthorize.GetPolicyOfUser();
            if (policy != PolicyEnum.CreatorPolicy)
            {
                await InitNotifications();
            }
            else
            {
                var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForCreator(new ViewModels.Common.PagingRequestBase() { PageIndex = 1, PageSize = 7});
                ViewData["Notifications"] = notificationsResult.Items;
            }

            return View();
        }

        [HttpPost("get-comics")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> Comics()
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

                var data = await _comicAPIClient.GetPagingManagement(pagingRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-comic-by-comic-seo-alias/{comicSEOAlias}")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> GetComicBySEOAlias(string comicSEOAlias)
        {
            if (String.IsNullOrEmpty(comicSEOAlias))
                return Ok(new ApiErrorResult<ComicDetailViewModel>() { Message = MessageConstants.ObjectNotFound("Comic") });

            var result = await _comicDetailAPIClient.GetComicDetailByComicSEOAliasWithAdmin(comicSEOAlias);

            return Ok(result);
        }

        [HttpGet("create-comic")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> CreateComic()
        {
            var genres = await _genreAPIClient.GetAll();
            ViewData["genres"] = genres.ResultObj;

            var artists = await _artistAPIClient.GetAll();
            ViewData["artists"] = artists.ResultObj;

            var authors = await _authorAPIClient.GetAll();
            ViewData["authors"] = authors.ResultObj;

            var policy = _policyAuthorize.GetPolicyOfUser();
            if (policy != PolicyEnum.CreatorPolicy)
            {
                await InitNotifications();
            }
            else
            {
                var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForCreator(new PagingRequestBase() { PageIndex = 1, PageSize = 7});
                ViewData["Notifications"] = notificationsResult.Items;
            }

            return View();
        }

        [HttpPost("create-comic")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> CreateComic([FromBody] CreateComicRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>() { Message = MessageConstants.ModelStateIsNotValid("Create Comic") });

            var result = await _comicAPIClient.CreateComic(request);

            return Ok(result);
        }

        [HttpGet("{comicSEOAlias}/update-comic")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> UpdateComic(string comicSEOAlias)
        {
            if (String.IsNullOrEmpty(comicSEOAlias))
                return RedirectToAction("Index", "Home");

            var policy = _policyAuthorize.GetPolicyOfUser();
            if (policy == PolicyEnum.CreatorPolicy)
            {
                var checkUserPermissionForComic = await _chapterAPIClient.CheckUserPermissionForComic(comicSEOAlias);
                if (!checkUserPermissionForComic.IsSuccessed)
                {
                    return RedirectToAction("403", "Error");
                }

                var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForCreator(new PagingRequestBase() { PageIndex = 1, PageSize = 7});
                ViewData["Notifications"] = notificationsResult.Items;
            }
            else
            {
                await InitNotifications();
            }

            var genres = await _genreAPIClient.GetAll();
            ViewData["genres"] = genres.ResultObj;

            var artists = await _artistAPIClient.GetAll();
            ViewData["artists"] = artists.ResultObj;

            var authors = await _authorAPIClient.GetAll();
            ViewData["authors"] = authors.ResultObj;

            var result = await _comicDetailAPIClient.GetComicDetailByComicSEOAliasWithAdmin(comicSEOAlias);

            if (!result.IsSuccessed)
                return RedirectToAction("Index", "Home");

            result.ResultObj.ComicCoverImageURL = $"<img src=\"{result.ResultObj.ComicCoverImageURL}\" width=\"150\" data-mce-src=\"{result.ResultObj.ComicCoverImageURL}\" data-mce-selected=\"1\">";

            return View(result.ResultObj);
        }

        [HttpPut("{comicId}/update-comic")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> UpdateComic([FromBody] UpdateComicRequest request, int comicId)
        {
            if (!ModelState.IsValid || comicId < 1)
                return Ok(new ApiErrorResult<int>() { Message = MessageConstants.ModelStateIsNotValid("Update Comic") });

            var result = await _comicAPIClient.UpdateComic(request, comicId);

            return Ok(result);
        }

        [HttpDelete("delete-comics")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> DeleteComics([FromBody] DeleteComicRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Comics")));

            var result = await _comicAPIClient.DeleteComics(request);

            return Ok(result);
        }

        [HttpPost("restore-comic")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> RestoreComic([FromBody] int comicId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Restore Comic")));

            if (comicId < 1)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Comic")));

            var result = await _comicAPIClient.RestoreDeletedComic(comicId);
            return Ok(result);
        }

        [HttpGet("{comicSEOAlias}/comic-information")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> ComicInformation(string comicSEOAlias)
        {
            // lỗi gì ở đây -> không getđược
            if (String.IsNullOrEmpty(comicSEOAlias))
                return RedirectToAction("Index", "Home");

            var result = await _comicDetailAPIClient.GetComicDetailByComicSEOAliasWithAdmin(comicSEOAlias);

            if (!result.IsSuccessed)
                return RedirectToAction("Index", "Home");

            var policy = _policyAuthorize.GetPolicyOfUser();
            if (policy != PolicyEnum.CreatorPolicy)
            {
                await InitNotifications();
            }
            else
            {
                var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForCreator(new PagingRequestBase() { PageIndex = 1, PageSize = 7});
                ViewData["Notifications"] = notificationsResult.Items;
            }

            return View(result.ResultObj);
        }

        [HttpGet("get-comic-by-comic-seo-alias/{comicSEOAlias}/comments")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> ComicComments(string comicSEOAlias)
        {
            if (String.IsNullOrEmpty(comicSEOAlias))
                return Ok(new ApiErrorResult<ComicDetailViewModel>() { Message = MessageConstants.ObjectNotFound("Comic") });

            HttpContext.Session.Remove("ComicComments");

            var result = await _comicDetailAPIClient.GetComicDetailByComicSEOAliasWithAdmin(comicSEOAlias);

            if (!result.IsSuccessed)
                return RedirectToAction("Index", nameof(ComicsController));

            HttpContext.Session.Set<ComicDetailViewModel>("ComicComments", result.ResultObj);

            ViewBag.ComicName = result.ResultObj.ComicName;

            var policy = _policyAuthorize.GetPolicyOfUser();
            if (policy != PolicyEnum.CreatorPolicy)
            {
                await InitNotifications();
            }
            else
            {
                var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForCreator(new PagingRequestBase() { PageIndex = 1, PageSize = 7});
                ViewData["Notifications"] = notificationsResult.Items;
            }

            return View();
        }

        [HttpPost("get-comic-information-for-read-comments")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public IActionResult ComicInformationComment()
        {
            var comicDetailViewModel = HttpContext.Session.Get<ComicDetailViewModel>("ComicComments");

            if (comicDetailViewModel is null)
                return RedirectToAction(nameof(Index), nameof(ComicsController));

            return Ok(new ApiSuccessResult<ComicDetailViewModel>() { ResultObj =  comicDetailViewModel });
        }

        [HttpPost("comments")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> Comments([FromBody] CommentPagingRequest request)
        {
            var result = await _commentAPIClient.GetPaging(request);
            return Ok(result);
        }

        [HttpPost("approve-comic")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> ApproveComic([FromBody] int comicId)
        {
            var result = await _comicAPIClient.ApproveComic(comicId);
            return Ok(result);
        }

        [HttpPost("reject-comic/{comicId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> RejectComic(int comicId, [FromBody] string feedback)
        {
            var result = await _comicAPIClient.RejectComic(comicId, feedback);
            return Ok(result);
        }

        [HttpGet("is-creator")]
        public IActionResult IsCreator()
        {
            var policy = _policyAuthorize.GetPolicyOfUser();
            if (policy != PolicyEnum.CreatorPolicy)
            {
                return Ok(new ApiSuccessResult<bool>() { ResultObj =  false });
            }
            else
            {
                return Ok(new ApiSuccessResult<bool>() { ResultObj = true });
            }
        }
    }
}

using HikiComic.ApiIntegration.ChaptersAPIClient;
using HikiComic.ApiIntegration.ComicDetailsAPIClient;
using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.Management.Extensions;
using HikiComic.Management.Services;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Chapters;
using HikiComic.ViewModels.Chapters.ChapterDataRequest;
using HikiComic.ViewModels.ComicDetails;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace HikiComic.Management.Controllers
{
    [Route("comic")]
    [Authorize]
    public class ChaptersController : BaseController
    {
        private readonly IComicDetailAPIClient _comicDetailAPIClient;

        private readonly IChapterAPIClient _chapterAPIClient;

        private readonly IPolicyAuthorize _policyAuthorize;

        private readonly INotificationAPIClient _notificationAPIClient;

        public ChaptersController(IComicDetailAPIClient comicDetailAPIClient, IChapterAPIClient chapterAPIClient, IPolicyAuthorize policyAuthorize,
            INotificationAPIClient notificationAPIClient)
        {
            _comicDetailAPIClient = comicDetailAPIClient;
            _chapterAPIClient = chapterAPIClient;
            _policyAuthorize = policyAuthorize;
            _notificationAPIClient = notificationAPIClient;
        }

        private async Task InitNotifications()
        {
            var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForAdminAndTeamMembers(new ViewModels.Common.PagingRequestBase() { PageIndex = 1, PageSize = 7});
            ViewData["Notifications"] = notificationsResult.Items;
        }

        [HttpGet("{comicSEOAlias}")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> Index(string comicSEOAlias)
        {
            var comicDetailViewModel = await _comicDetailAPIClient.GetComicDetailByComicSEOAliasWithAdmin(comicSEOAlias);

            if (!comicDetailViewModel.IsSuccessed)
                return RedirectToAction("Index", "Comics");

            HttpContext.Session.Set<ComicDetailViewModel>("ComicCurrent", comicDetailViewModel.ResultObj);
            HttpContext.Session.Set<ChapterDetailViewModel>("ChapterCurrent", new ChapterDetailViewModel() { ChapterId = -1 });

            var policy = _policyAuthorize.GetPolicyOfUser();

            if(policy == PolicyEnum.CreatorPolicy)
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

            ViewBag.ComicName = comicDetailViewModel.ResultObj.ComicName;
            ViewBag.ComicSEOAlias = comicDetailViewModel.ResultObj.ComicSEOAlias;

            return View();
        }

        [HttpGet("comic-information")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> ComicInformation()
        {
            var comicDetailViewModel = HttpContext.Session.Get<ComicDetailViewModel>("ComicCurrent");

            if (comicDetailViewModel == null || comicDetailViewModel.ComicId == -1)
                return Ok(new ApiErrorResult<ComicDetailViewModel>() { Message = MessageConstants.NoSelectedComic });

            var policy = _policyAuthorize.GetPolicyOfUser();
            if (policy == PolicyEnum.CreatorPolicy)
            {
                var checkUserPermissionForComic = await _chapterAPIClient.CheckUserPermissionForComic(comicDetailViewModel.ComicSEOAlias);
                if (!checkUserPermissionForComic.IsSuccessed)
                {
                    return RedirectToAction("403", "Error");
                }
            }

            return Ok(new ApiSuccessResult<ComicDetailViewModel>() { Message = MessageConstants.GetObjectSuccess("Comic"), ResultObj = comicDetailViewModel });
        }

        [HttpPost("{comicSEOAlias}/get-chapters")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> Chapters(string comicSEOAlias)
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

                var data = await _chapterAPIClient.GetPagingManagement(pagingRequest, comicSEOAlias);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{comicSEOAlias}/create-chapter")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> CreateChapter(string comicSEOAlias)
        {
            var comicDetailViewModel = HttpContext.Session.Get<ComicDetailViewModel>("ComicCurrent");

            if (comicDetailViewModel == null || comicDetailViewModel.ComicId == -1 || comicSEOAlias != comicDetailViewModel.ComicSEOAlias)
                return RedirectToAction("Index", "Comics");

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

            ViewBag.ComicName = comicDetailViewModel.ComicName;
            ViewBag.ComicSEOAlias = comicDetailViewModel.ComicSEOAlias;

            return View();
        }

        [HttpPost("{comicSEOAlias}/create-chapter")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> CreateChapter([FromBody] CreateChapterAndChapterImageURLRequest request, string comicSEOAlias)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>() { Message = MessageConstants.ModelStateIsNotValid("Create Chapter") });

            if (String.IsNullOrEmpty(request.StringChapterImageURLs))
                return Ok(new ApiErrorResult<int>() { Message = MessageConstants.ModelStateIsNotValid("Create Chapter") });

            var comicDetailViewModel = HttpContext.Session.Get<ComicDetailViewModel>("ComicCurrent");
            if (comicDetailViewModel == null || comicDetailViewModel.ComicId == -1 || comicSEOAlias != comicDetailViewModel.ComicSEOAlias)
                return RedirectToAction("Index", "Comics");

            List<string> urlImageChapters = new List<string>();

            int countUrl = 0;
            string fullSrc = "|";
            foreach (Match m in Regex.Matches(request.StringChapterImageURLs, "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase | RegexOptions.Multiline))
            {
                countUrl++;
                fullSrc += m.Groups[1].Value + "|";
                if (countUrl > 30)
                {
                    urlImageChapters.Add(fullSrc);
                    countUrl = 0;
                    fullSrc = "|";
                }
            }

            if (fullSrc != "|")
                urlImageChapters.Add(fullSrc);

            request.ChapterImageURLs = urlImageChapters;

            var result = await _chapterAPIClient.CreateChapterAndChapterImageURLWithComicSEOAlias(request, comicDetailViewModel.ComicSEOAlias);

            return Ok(result);
        }

        private static string ConvertLinkToHTML(List<string> url)
        {
            string result = string.Empty;
            foreach (var item in url)
            {
                result += $"<p><img src=\"{item}\" width=\"350\" data-mce-src=\"{item}\"></p>";
            }
            return result;
        }

        [HttpGet("{comicSEOAlias}/{chapterSEOAlias}/update-chapter")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> UpdateChapter(string comicSEOAlias, string chapterSEOAlias)
        {
            var comicDetailViewModel = HttpContext.Session.Get<ComicDetailViewModel>("ComicCurrent");
            if (comicDetailViewModel == null || comicDetailViewModel.ComicId == -1 || comicSEOAlias != comicDetailViewModel.ComicSEOAlias)
                return RedirectToAction("Index", "Comics");

            var chapterDetail = await _chapterAPIClient.GetChapterDetail(comicSEOAlias, chapterSEOAlias);

            if (!chapterDetail.IsSuccessed)
                return RedirectToAction("Index", "Comics");

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

            chapterDetail.ResultObj.StringChapterImageURLs = ConvertLinkToHTML(chapterDetail.ResultObj.ChapterImageURLs);

            ViewBag.ComicName = comicDetailViewModel.ComicName;
            ViewBag.ComicSEOAlias = comicDetailViewModel.ComicSEOAlias;

            HttpContext.Session.Set<ChapterDetailViewModel>("ChapterCurrent", chapterDetail.ResultObj);

            return View(chapterDetail.ResultObj);
        }

        [HttpPost("{comicSEOAlias}/{chapterSEOAlias}/update-chapter")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> UpdateChapter(string comicSEOAlias, string chapterSEOAlias, [FromBody] UpdateChapterRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>() { Message = MessageConstants.ModelStateIsNotValid("Update Chapter") });

            if (String.IsNullOrEmpty(request.StringChapterImageURLs))
                return Ok(new ApiErrorResult<int>() { Message = MessageConstants.ModelStateIsNotValid("Update Chapter") });

            var comicDetailViewModel = HttpContext.Session.Get<ComicDetailViewModel>("ComicCurrent");
            if (comicDetailViewModel == null || comicDetailViewModel.ComicId == -1 || comicSEOAlias != comicDetailViewModel.ComicSEOAlias)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurred });

            var chapterDetailViewModel = HttpContext.Session.Get<ChapterDetailViewModel>("ChapterCurrent");
            if (chapterDetailViewModel == null || chapterDetailViewModel.ComicDetailId == -1 || chapterSEOAlias != chapterDetailViewModel.ChapterSEOAlias)
                return BadRequest(new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurred });

            List<string> urlImageChapters = new List<string>();

            int countUrl = 0;
            string fullSrc = "|";
            foreach (Match m in Regex.Matches(request.StringChapterImageURLs, "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase | RegexOptions.Multiline))
            {
                countUrl++;
                fullSrc += m.Groups[1].Value + "|";
                if (countUrl > 30)
                {
                    urlImageChapters.Add(fullSrc);
                    countUrl = 0;
                    fullSrc = "|";
                }
            }

            if (fullSrc != "|")
                urlImageChapters.Add(fullSrc);

            request.ChapterImageURLs = urlImageChapters;

            var result = await _chapterAPIClient.UpdateChapter(request, chapterDetailViewModel.ChapterId);

            return Ok(result);
        }

        [HttpGet("information-chapter")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> Informationchapter()
        {
            var chapterDetailViewModel = HttpContext.Session.Get<ChapterDetailViewModel>("ChapterCurrent");

            if (chapterDetailViewModel == null || chapterDetailViewModel.ComicDetailId == -1)
                return Ok(new ApiErrorResult<ChapterDetailViewModel>() { Message = MessageConstants.NoSelectedChapter });

            var policy = _policyAuthorize.GetPolicyOfUser();
            if (policy == PolicyEnum.CreatorPolicy)
            {
                var checkUserPermissionForComic = await _chapterAPIClient.CheckUserPermissionForComic(chapterDetailViewModel.ComicSEOAlias);
                if (!checkUserPermissionForComic.IsSuccessed)
                {
                    return RedirectToAction("403", "Error");
                }
            }

            return Ok(new ApiSuccessResult<ChapterDetailViewModel>() { Message = MessageConstants.GetObjectSuccess("Comic"), ResultObj = chapterDetailViewModel });
        }

        [HttpGet("{comicSEOAlias}/{chapterSEOAlias}/chapter-detail")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> ChapterDetail(string comicSEOAlias, string chapterSEOAlias)
        {
            var comicDetailViewModel = HttpContext.Session.Get<ComicDetailViewModel>("ComicCurrent");
            if (comicDetailViewModel == null || comicDetailViewModel.ComicId == -1 || comicSEOAlias != comicDetailViewModel.ComicSEOAlias)
                return RedirectToAction("Index", "Comics");

            var chapterDetail = await _chapterAPIClient.GetChapterDetail(comicSEOAlias, chapterSEOAlias);

            if (!chapterDetail.IsSuccessed)
                return RedirectToAction("Index", "Comics");

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

            ViewBag.ComicName = comicDetailViewModel.ComicName;
            ViewBag.ComicSEOAlias = comicDetailViewModel.ComicSEOAlias;

            return View(chapterDetail.ResultObj);
        }

        [HttpDelete("delete-chapters")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> Deletechapters([FromBody] DeleteChapterRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Chapters")));

            var result = await _chapterAPIClient.DeleteChapters(request);

            return Ok(result);
        }

        [HttpPost("restore-chapter")]
        [Authorize(Policy = SystemConstants.AppSettings.CRUDComicChapterPolicy)]
        public async Task<IActionResult> RestoreAuthor([FromBody] int chapterId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Restore Chapter")));

            var result = await _chapterAPIClient.RestoreDeletedChapter(chapterId);
            return Ok(result);
        }

        [HttpPost("approve-chapter")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> ApproveChapter([FromBody] int chapterId)
        {
            var result = await _chapterAPIClient.ApproveChapter(chapterId);
            return Ok(result);
        }

        [HttpPost("reject-chapter/{chapterId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> RejectChapter(int chapterId, [FromBody] string feedback)
        {
            var result = await _chapterAPIClient.RejectChapter(chapterId, feedback);
            return Ok(result);
        }

        [HttpGet("is-creator")]
        public IActionResult IsCreator()
        {
            var policy = _policyAuthorize.GetPolicyOfUser();
            if (policy != PolicyEnum.CreatorPolicy)
            {
                return Ok(new ApiSuccessResult<bool>() { ResultObj = false });
            }
            else
            {
                return Ok(new ApiSuccessResult<bool>() { ResultObj = true });
            }
        }
    }
}

using HikiComic.ApiIntegration.ChaptersAPIClient;
using HikiComic.ApiIntegration.ComicsAPIClient;
using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Chapters.ChapterDataRequest;
using HikiComic.ViewModels.Comics.ComicDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace HikiComic.Management.Controllers
{
	[Route("crawl-comics")]
	public class CrawlComicsController : BaseController
	{
		private readonly IComicAPIClient _comicAPIClient;

		private readonly IChapterAPIClient _chapterAPIClient;

        private readonly INotificationAPIClient _notificationAPIClient;

        public CrawlComicsController(IComicAPIClient comicAPIClient, IChapterAPIClient chapterAPIClient, INotificationAPIClient notificationAPIClient)
        {
			_comicAPIClient = comicAPIClient;
			_chapterAPIClient = chapterAPIClient;
            _notificationAPIClient = notificationAPIClient;
        }

        private async Task InitNotifications()
        {
            var notificationsResult = await _notificationAPIClient.GetPagingNofiticationForAdminAndTeamMembers(new ViewModels.Common.PagingRequestBase() { PageIndex = 1, PageSize = 7});
            ViewData["Notifications"] = notificationsResult.Items;
        }

        public async Task<IActionResult> Index()
        {
            await InitNotifications();

            return View();
		}

		[HttpPost("create-comic-by-crawling")]
		public async Task<IActionResult> CreateComicByCrawling([FromBody] CreateComicByCrawlingRequest request)
		{
			if (!ModelState.IsValid)
				return Ok(new ApiErrorResult<int>() { Message = MessageConstants.ModelStateIsNotValid("Create Comic By Crawling"), ResultObj = -1 });

			//return Ok();

			var result = await _comicAPIClient.CreateComicByCrawling(request);
			return Ok(result);
		}


        [HttpPost("create-chapter-by-crawling/{comicDetailId}")]
        public async Task<IActionResult> CreateChapterByCrawling([FromBody] CreateChapterAndChapterImageURLRequest request, int comicDetailId)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<int>() { Message = MessageConstants.ModelStateIsNotValid("Create Chapter By Crawling"), ResultObj = -1 });

            //return Ok();

			var result = await _chapterAPIClient.CreateChapterAndChapterImageURLWithComicId(request, comicDetailId);
			return Ok(result);
		}


    }
}

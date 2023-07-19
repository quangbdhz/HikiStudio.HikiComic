using HikiComic.Application.ChapterImageURLs;
using HikiComic.Application.Common;
using HikiComic.Application.Notifications;
using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.ChapterImageURLs.ChapterImageURLDataRequest;
using HikiComic.ViewModels.Chapters;
using HikiComic.ViewModels.Chapters.ChapterDataRequest;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Notifications.NotificationsDataRequest;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Macs;
using System.Net;
using System.Text;

namespace HikiComic.Application.Chapters
{
    public class ChapterService : IChapterService
    {
        private readonly HikiComicDbContext _context;

        private readonly ICommonService _commonService;

        private readonly INotificationService _notificationService;

        private readonly IChapterImageURLService _chapterImageURLService;

        private readonly IUserContextService _userContextService;

        public ChapterService(HikiComicDbContext context, ICommonService commonService, INotificationService notificationService,
            IChapterImageURLService chapterImageURLService, IUserContextService userContextService)
        {
            _context = context;
            _commonService = commonService;
            _notificationService = notificationService;
            _chapterImageURLService = chapterImageURLService;
            _userContextService = userContextService;
        }

        public async Task<ApiResult<bool>> AddViewCount(string comicSEOAlias, string chapterSEOAlias)
        {
            comicSEOAlias = WebUtility.UrlDecode(comicSEOAlias);
            chapterSEOAlias = WebUtility.UrlDecode(chapterSEOAlias);

            var chapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias && x.ChapterSEOAlias == chapterSEOAlias);
            if (chapter is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Chapter"));

            chapter.ViewCount += 1;
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.CreateSuccess("View Chapter") };
        }

        public async Task<ApiResult<int>> CreateChapter(CreateChapterRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<int>();

            var checkExistComicDetail = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicDetailId == request.ComicDetailId);
            if (checkExistComicDetail == null)
                return new ApiErrorResult<int>(MessageConstants.ObjectNotFound("Comic Detail"));

            var checkExistComic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == checkExistComicDetail.ComicId);
            if (checkExistComic == null)
                return new ApiErrorResult<int>(MessageConstants.ObjectNotFound("Comic"));

            var notACreator = _userContextService.CheckUserRoleAdminOrTeamMember();
            if (!notACreator.ResultObj)
            {
                if (checkExistComic.CreatedBy != userResult.ResultObj)
                    return new ApiErrorResult<int>() { Message = MessageConstants.DoNotHavePermission, StatusCode = StatusCodeEnum.DoNotHavePermission };
            }

            var checkExistChapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterName.Equals(request.ChapterName) && x.ComicDetailId == checkExistComicDetail.ComicDetailId);
            if (checkExistChapter != null)
                return new ApiErrorResult<int>() { Message = MessageConstants.ObjectAlreadyExists("ChapterName") };

            var chapter = new Chapter()
            {
                ComicDetailId = request.ComicDetailId,
                ChapterName = request.ChapterName,
                ComicSEOAlias = checkExistComicDetail.ComicSEOAlias,
                ChapterSEOAlias = _commonService.ConvertTitleToSEOAlias(request.ChapterName, isChapter: true),
                SerialChapterOfComic = request.SerialChapterOfComic,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                IsDeleted = false,
                CreatedBy = userResult.ResultObj,
                ApprovalStatus = ApprovalStatusEnum.Sent,
                DateApproved = null,
                UserIdApproved = null,
            };

            var isAdminOrTeamMember = _userContextService.CheckUserRoleAdminOrTeamMember();
            if (isAdminOrTeamMember.ResultObj)
            {
                chapter.ApprovalStatus = ApprovalStatusEnum.Approved;
                chapter.UserIdApproved = userResult.ResultObj;
                chapter.DateApproved = DateTime.Now;
            }

            await _context.Chapters.AddAsync(chapter);
            await _context.SaveChangesAsync();

            var createNotificationRequest = new CreateNotificationRequest()
            {
                AppUserId = null,
                Actions = chapter.ComicSEOAlias + "/" + chapter.ChapterSEOAlias,
                ImageURL = null,
                ComicId = checkExistComicDetail.ComicId,
                IsRead = false,
                NotificationPriority = NotificationPriorityEnum.Low,
                Message = checkExistComic.ComicName + " just updated the new chapter.",
                Title = "The notification has a new chapter.",
                CreatedBy = userResult.ResultObj
            };

            var result = await _notificationService.CreateNotifications(createNotificationRequest, NotificationTypeEnum.NewChapter);

            if (!result.IsSuccessed)
                return new ApiErrorResult<int>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(CreateChapter), "Create Notifcations NewChapter") };

            //creator send notification -> to admin, team members
            if (!isAdminOrTeamMember.ResultObj)
            {
                var createNotificationRequestApproval = new CreateNotificationRequest()
                {
                    Actions = checkExistComicDetail.ComicSEOAlias,
                    ComicId = chapter.ChapterId,
                    ImageURL = checkExistComic.ComicCoverImageURL,
                    IsRead = false,
                    Title = $"Request for approval of the chapter '<strong>{chapter.ChapterName}</strong>'",
                    Message = $"Request for approval of the chapter '{chapter.ChapterName}' of comic '<strong>{checkExistComic.ComicName}</strong>'",
                };

                var resultCreateNotification = await _notificationService.CreateNotification(createNotificationRequestApproval, NotificationTypeEnum.RequestApproval);
            }

            return new ApiSuccessResult<int>() { ResultObj = chapter.ChapterId, Message = MessageConstants.CreateSuccess("Comic") };
        }

        public async Task<ApiResult<IList<ChapterViewModel>>> GetChapterByComicDetailId(int comicDetailId)
        {
            var numberOfComicChaptersForFree = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == (int)ServiceConfigEnum.NumberOfComicChaptersForFree);
            if (numberOfComicChaptersForFree is null)
                return new ApiErrorResult<IList<ChapterViewModel>>() { Message = MessageConstants.AnErrorOccurred };

            var queryChapter = from c in _context.Chapters
                               where c.ComicDetailId == comicDetailId && c.ApprovalStatus == ApprovalStatusEnum.Approved
                               select new { c };

            var chapters = await queryChapter.Select(x => new ChapterViewModel()
            {
                ChapterId = x.c.ChapterId,
                ComicDetailId = x.c.ComicDetailId,
                DateCreated = x.c.DateCreated,
                ChapterName = x.c.ChapterName,
                SerialChapterOfComic = x.c.SerialChapterOfComic,
                ViewCount = x.c.ViewCount,
                ComicSEOAlias = x.c.ComicSEOAlias,
                ChapterSEOAlias = x.c.ChapterSEOAlias,
                IsLockedChapter = x.c.SerialChapterOfComic < numberOfComicChaptersForFree.Value ? false : true
            }).OrderByDescending((x) => x.SerialChapterOfComic).ToListAsync();

            return new ApiSuccessResult<IList<ChapterViewModel>>() { ResultObj = chapters, Message = MessageConstants.GetObjectSuccess("Chapters") };
        }

        public async Task<ApiResult<IList<ChapterViewModel>>> GetChapterByComicDetailId(int comicDetailId, Guid userId)
        {
            var numberOfComicChaptersForFree = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == (int)ServiceConfigEnum.NumberOfComicChaptersForFree);
            if (numberOfComicChaptersForFree is null)
                return new ApiErrorResult<IList<ChapterViewModel>>() { Message = MessageConstants.AnErrorOccurred };

            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == userId);

            if (account is null)
                return new ApiErrorResult<IList<ChapterViewModel>>() { Message = MessageConstants.ObjectNotFound("Account") };

            var queryChapter = _context.Chapters.Where(c => c.ComicDetailId == comicDetailId);

            var queryUserComicPurchasesChapter = from c in _context.Chapters
                                                 join ucp in _context.UserComicPurchases on c.ChapterId equals ucp.ChapterId
                                                 join ucuh in _context.UserCoinUsageHistories on ucp.UserCoinUsageHistoryId equals ucuh.UserCoinUsageHistoryId
                                                 where c.ComicDetailId == comicDetailId && ucuh.AccountId == account.AccountId && c.ApprovalStatus == ApprovalStatusEnum.Approved
                                                 select c;

            var originalChapters = await queryChapter.ToListAsync();

            var userComicPurchasesChapters = await queryUserComicPurchasesChapter.ToListAsync();

            var chapters = originalChapters.Union(userComicPurchasesChapters).Select(x => new ChapterViewModel()
            {
                ChapterId = x.ChapterId,
                ComicDetailId = x.ComicDetailId,
                DateCreated = x.DateCreated,
                ChapterName = x.ChapterName,
                SerialChapterOfComic = x.SerialChapterOfComic,
                ViewCount = x.ViewCount,
                ComicSEOAlias = x.ComicSEOAlias,
                ChapterSEOAlias = x.ChapterSEOAlias,
                IsLockedChapter = IsLockedChapter(numberOfComicChaptersForFree.Value, x.SerialChapterOfComic, originalChapters.Contains(x) && !userComicPurchasesChapters.Contains(x))
            }).OrderByDescending((x) => x.SerialChapterOfComic).ToList();

            return new ApiSuccessResult<IList<ChapterViewModel>>() { ResultObj = chapters, Message = MessageConstants.GetObjectSuccess("Chapters") };
        }

        private static bool IsLockedChapter(int numberOfComicChaptersForFree, int serialChapterOfComic, bool isLockedChapter)
        {
            if (serialChapterOfComic < numberOfComicChaptersForFree)
                return false;

            return isLockedChapter;
        }

        public async Task<ApiResult<IList<ChapterViewModel>>> GetChapterByComicSEOAlias(string comicSEOAlias)
        {
            comicSEOAlias = WebUtility.UrlDecode(comicSEOAlias);

            var numberOfComicChaptersForFree = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == (int)ServiceConfigEnum.NumberOfComicChaptersForFree);
            if (numberOfComicChaptersForFree is null)
                return new ApiErrorResult<IList<ChapterViewModel>>() { Message = MessageConstants.AnErrorOccurred };

            var checkComicDetailAlreadyExits = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias);

            if (checkComicDetailAlreadyExits is null)
                return new ApiErrorResult<IList<ChapterViewModel>>() { Message = MessageConstants.ObjectNotFound("Comic Detail") };

            var queryChapter = from c in _context.Chapters
                               where c.ComicDetailId == checkComicDetailAlreadyExits.ComicDetailId && c.ApprovalStatus == ApprovalStatusEnum.Approved
                               select new { c };

            var chapters = await queryChapter.Select(x => new ChapterViewModel()
            {
                ChapterId = x.c.ChapterId,
                ComicDetailId = x.c.ComicDetailId,
                DateCreated = x.c.DateCreated,
                ChapterName = x.c.ChapterName,
                SerialChapterOfComic = x.c.SerialChapterOfComic,
                ViewCount = x.c.ViewCount,
                IsDeleted = x.c.IsDeleted,
                ComicSEOAlias = x.c.ComicSEOAlias,
                ChapterSEOAlias = x.c.ChapterSEOAlias,
                IsLockedChapter = x.c.SerialChapterOfComic < numberOfComicChaptersForFree.Value ? false : true
            }).OrderByDescending((x) => x.SerialChapterOfComic).ToListAsync();

            return new ApiSuccessResult<IList<ChapterViewModel>>() { ResultObj = chapters, Message = MessageConstants.GetObjectSuccess("Chapters") };
        }

        public async Task<ApiResult<IList<ChapterViewModel>>> GetChapterByComicSEOAlias(string comicSEOAlias, Guid userId)
        {
            comicSEOAlias = WebUtility.UrlDecode(comicSEOAlias);

            var numberOfComicChaptersForFree = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == (int)ServiceConfigEnum.NumberOfComicChaptersForFree);
            if (numberOfComicChaptersForFree is null)
                return new ApiErrorResult<IList<ChapterViewModel>>() { Message = MessageConstants.AnErrorOccurred };

            var checkComicDetailAlreadyExits = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias);

            if (checkComicDetailAlreadyExits is null)
                return new ApiErrorResult<IList<ChapterViewModel>>() { Message = MessageConstants.ObjectNotFound("Comic Detail") };

            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == userId);

            if (account is null)
                return new ApiErrorResult<IList<ChapterViewModel>>() { Message = MessageConstants.ObjectNotFound("Account") };

            var queryChapter = _context.Chapters.Where(c => c.ComicDetailId == checkComicDetailAlreadyExits.ComicDetailId && c.ApprovalStatus == ApprovalStatusEnum.Approved);

            var queryUserComicPurchasesChapter = from c in _context.Chapters
                                                 join ucp in _context.UserComicPurchases on c.ChapterId equals ucp.ChapterId
                                                 join ucuh in _context.UserCoinUsageHistories on ucp.UserCoinUsageHistoryId equals ucuh.UserCoinUsageHistoryId
                                                 where c.ComicDetailId == checkComicDetailAlreadyExits.ComicDetailId && ucuh.AccountId == account.AccountId
                                                 select c;

            var originalChapters = await queryChapter.ToListAsync();

            var userComicPurchasesChapters = await queryUserComicPurchasesChapter.ToListAsync();

            var chapters = originalChapters.Union(userComicPurchasesChapters).Select(x => new ChapterViewModel()
            {
                ChapterId = x.ChapterId,
                ComicDetailId = x.ComicDetailId,
                DateCreated = x.DateCreated,
                ChapterName = x.ChapterName,
                SerialChapterOfComic = x.SerialChapterOfComic,
                ViewCount = x.ViewCount,
                ComicSEOAlias = x.ComicSEOAlias,
                ChapterSEOAlias = x.ChapterSEOAlias,
                IsLockedChapter = IsLockedChapter(numberOfComicChaptersForFree.Value, x.SerialChapterOfComic, originalChapters.Contains(x) && !userComicPurchasesChapters.Contains(x))
            }).OrderByDescending((x) => x.SerialChapterOfComic).ToList();

            return new ApiSuccessResult<IList<ChapterViewModel>>() { ResultObj = chapters, Message = MessageConstants.GetObjectSuccess("Chapters") };
        }

        public async Task<ApiResult<bool>> DeleteChapter(int chapterId)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var chapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterId == chapterId);
            if (chapter is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Chapter"));

            var notACreator = _userContextService.CheckUserRoleAdminOrTeamMember();
            if (!notACreator.ResultObj)
            {
                if (chapter.CreatedBy != userResult.ResultObj)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.DoNotHavePermission, StatusCode = StatusCodeEnum.DoNotHavePermission };
            }

            chapter.IsDeleted = true;
            chapter.DateUpdated = DateTime.Now;
            chapter.UpdatedBy = userResult.ResultObj;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>(MessageConstants.DeleteSuccess("Chapter"));
        }

        public async Task<ApiResult<bool>> DeleteChapters(DeleteChapterRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var validChapterIds = request.ChapterIds.Where(id => id > 0).ToList();

            var existingChapters = await _context.Chapters
                .Where(x => validChapterIds.Contains(x.ChapterId))
                .ToListAsync();

            var errorMessageBuilder = new StringBuilder();
            var notACreator = _userContextService.CheckUserRoleAdminOrTeamMember();

            foreach (var chapter in existingChapters)
            {
                if (!notACreator.ResultObj)
                {
                    if (chapter.CreatedBy != userResult.ResultObj)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.DoNotHavePermission, StatusCode = StatusCodeEnum.DoNotHavePermission };
                }

                if (chapter.IsDeleted == true)
                {
                    errorMessageBuilder.AppendLine("Chapter with Id: " + chapter.ChapterId + " deleted.");
                }
                else
                {
                    chapter.IsDeleted = true;
                    chapter.DateUpdated = DateTime.Now;
                    chapter.UpdatedBy = userResult.ResultObj;
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
                return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess(nameof(Chapter)) };
            }
        }

        public List<string> CutUrlToListUrl(List<string> lvUrlEncode)
        {
            List<string> lvUrlDecode = new List<string>();

            foreach (string item in lvUrlEncode)
            {
                int lenghtUrl = item.Length;
                string url = item;
                string subString = "";

                for (int i = 1; i < lenghtUrl; i++)
                {
                    if (url[i] == '|' && i != 0)
                    {
                        lvUrlDecode.Add(subString);
                        subString = "";
                    }
                    else
                    {
                        subString += url[i];
                    }
                }
            }
            return lvUrlDecode;
        }

        public async Task<ApiResult<ChapterDetailViewModel>> GetChapterDetail(string comicSEOAlias, string chapterSEOAlias)
        {
            comicSEOAlias = WebUtility.UrlDecode(comicSEOAlias);
            chapterSEOAlias = WebUtility.UrlDecode(chapterSEOAlias);

            //var getChapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias && x.ChapterSEOAlias == chapterSEOAlias);

            var query = from c in _context.Chapters
                        where c.ComicSEOAlias == comicSEOAlias && c.ChapterSEOAlias == chapterSEOAlias
                        join cb in _context.Users on c.CreatedBy equals cb.Id into createdByGroup
                        from cb in createdByGroup.DefaultIfEmpty()
                        join ub in _context.Users on c.UpdatedBy equals ub.Id into updatedByGroup
                        from ub in updatedByGroup.DefaultIfEmpty()
                        select new { c, cb, ub };

            var chapter = await query.Select(x => new ChapterDetailViewModel()
            {
                ChapterId = x.c.ChapterId,
                ChapterName = x.c.ChapterName,
                ComicSEOAlias = x.c.ComicSEOAlias,
                ChapterSEOAlias = x.c.ChapterSEOAlias,
                ComicDetailId = x.c.ComicDetailId,
                SerialChapterOfComic = x.c.SerialChapterOfComic,
                ViewCount = x.c.ViewCount,
                DateCreated = x.c.DateCreated,
                UserNameCreatedBy = x.cb.UserName,
                DateUpdated = x.c.DateUpdated,
                UserNameUpdatedBy = x.ub.UserName
            }).FirstOrDefaultAsync();

            if (chapter is null)
                return new ApiErrorResult<ChapterDetailViewModel>() { Message = MessageConstants.ObjectNotFound("Chapter") };

            var queryUrlChapterImageComic = from c in _context.ChapterImageURLs where c.ChapterId == chapter.ChapterId select new { c };

            var listUrlChapterImageComics = await queryUrlChapterImageComic.Select(x => x.c.ImageURL).ToListAsync();

            List<string> urlDecode = CutUrlToListUrl(listUrlChapterImageComics);

            chapter.ChapterImageURLs = urlDecode;

            return new ApiSuccessResult<ChapterDetailViewModel>() { ResultObj = chapter, Message = MessageConstants.GetObjectSuccess("chapter") };
        }

        public async Task<ApiResult<bool>> UpdateChapter(UpdateChapterRequest request, int chapterId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var chapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterId == chapterId);
            if (chapter is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Chapter"));

            var notACreator = _userContextService.CheckUserRoleAdminOrTeamMember();
            if (!notACreator.ResultObj)
            {
                if (chapter.CreatedBy != userResult.ResultObj)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.DoNotHavePermission, StatusCode = StatusCodeEnum.DoNotHavePermission };
            }

            var checkNameChapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterName.ToLower().Contains(request.ChapterName.ToLower())
                && x.ChapterId != chapterId && x.ComicDetailId == chapter.ComicDetailId);
            if (checkNameChapter != null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectAlreadyExists("ChapterName") };

            chapter.ChapterName = request.ChapterName;
            chapter.DateUpdated = DateTime.Now;
            chapter.UpdatedBy = userResult.ResultObj;
            chapter.ChapterSEOAlias = _commonService.ConvertTitleToSEOAlias(request.ChapterName, isChapter: true);

            await _context.SaveChangesAsync();

            var oldChapterImageURLs = await _context.ChapterImageURLs.Where(x => x.ChapterId == chapterId).ToListAsync();
            _context.ChapterImageURLs.RemoveRange(oldChapterImageURLs);

            if (request.ChapterImageURLs != null)
            {
                int lengthUrlImageChapters = request.ChapterImageURLs.Count();
                for (int i = 0; i < lengthUrlImageChapters; i++)
                {
                    var createChapterImageURL = new CreateChapterImageURLRequest() { ChapterId = chapter.ChapterId, ImageURL = request.ChapterImageURLs[i], SerialImageURLOfChapter = i };
                    var result = await _chapterImageURLService.CreateChapterImageURL(createChapterImageURL);

                    if (!result.IsSuccessed)
                    {
                        return new ApiErrorResult<bool>("Chapter Image URL Error with Url: " + request.ChapterImageURLs[i]);
                    }
                }

                return new ApiSuccessResult<bool>(MessageConstants.UpdateSuccess("Chapter"));
            }

            return new ApiErrorResult<bool>(MessageConstants.ObjectAlreadyExists("URL Chapter"));
        }

        /// <summary>
        /// feature: crawl comics
        /// crawl comic by web-> not added yet (createdby)
        /// turn off -> send notifications
        /// </summary>
        /// <param name="request"></param>
        /// <param name="comicDetailId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApiResult<int>> CreateChapterAndChapterImageURLWithComicId(CreateChapterAndChapterImageURLRequest request, int comicDetailId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return new ApiErrorResult<int>();

            var checkExistComicDetail = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicDetailId == comicDetailId);
            if (checkExistComicDetail == null)
                return new ApiErrorResult<int>(MessageConstants.ObjectNotFound("Comic"));

            var checkExistComic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == checkExistComicDetail.ComicId);
            if (checkExistComic == null)
                return new ApiErrorResult<int>(MessageConstants.ObjectNotFound("Comic"));

            var notACreator = _userContextService.CheckUserRoleAdminOrTeamMember();
            if (!notACreator.ResultObj)
            {
                if (checkExistComicDetail.CreatedBy != userResult.ResultObj)
                    return new ApiErrorResult<int>() { Message = MessageConstants.DoNotHavePermission, StatusCode = StatusCodeEnum.DoNotHavePermission };
            }

            var checkExistChapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterName.Equals(request.ChapterName) && x.ComicDetailId == checkExistComicDetail.ComicDetailId);
            if (checkExistChapter != null)
                return new ApiErrorResult<int>() { Message = MessageConstants.ObjectAlreadyExists("ChapterName") };

            var chapter = new Chapter()
            {
                ComicDetailId = checkExistComicDetail.ComicDetailId,
                ChapterName = request.ChapterName,
                ComicSEOAlias = checkExistComicDetail.ComicSEOAlias,
                ChapterSEOAlias = _commonService.ConvertTitleToSEOAlias(request.ChapterName, isChapter: true),
                SerialChapterOfComic = (int)(request.SerialChapterOfComic != null ? request.SerialChapterOfComic : 0),
                ViewCount = 0,
                DateCreated = (DateTime)(request.DateCreated != null ? request.DateCreated : DateTime.Now),
                IsDeleted = false,
                CreatedBy = userResult.ResultObj,
                ApprovalStatus = ApprovalStatusEnum.Approved,
                DateApproved = DateTime.Now,
                UserIdApproved = userResult.ResultObj,
            };

            await _context.Chapters.AddAsync(chapter);
            await _context.SaveChangesAsync();

            if (request.ChapterImageURLs != null)
            {
                int lengthUrlImageChapters = request.ChapterImageURLs.Count();
                for (int i = 0; i < lengthUrlImageChapters; i++)
                {
                    var createChapterImageURL = new CreateChapterImageURLRequest()
                    {
                        ChapterId = chapter.ChapterId,
                        ImageURL = request.ChapterImageURLs[i],
                        SerialImageURLOfChapter = i
                    };
                    var result = await _chapterImageURLService.CreateChapterImageURL(createChapterImageURL);

                    if (!result.IsSuccessed)
                    {
                        return new ApiErrorResult<int>("Chapter Image URL Error with Url: " + request.ChapterImageURLs[i]);
                    }
                }
            }

            //var createNotificationRequest = new CreateNotificationRequest()
            //{
            //    AppUserId = null,
            //    Actions = chapter.ComicSEOAlias + "/" + chapter.ChapterSEOAlias,
            //    ImageURL = null,
            //    ComicId = checkExistComicDetail.ComicId,
            //    IsRead = false,
            //    NotificationPriority = NotificationPriorityEnum.Low,
            //    Message = checkExistComic.ComicName + " just updated the new chapter.",
            //    Title = "The notification has a new chapter.",
            //    CreatedBy = userId
            //};

            //var resultCreateNotifications = await _notificationService.CreateNotifications(createNotificationRequest, NotificationTypeEnum.NewChapter, userId);

            //if (!resultCreateNotifications.IsSuccessed)
            //    return new ApiErrorResult<int>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(CreateChapter), "Create Notifcations NewChapter") };

            return new ApiSuccessResult<int>(MessageConstants.CreateSuccess("Chapter"));
        }

        public async Task<ApiResult<int>> CreateChapterAndChapterImageURLWithComicSEOAlias(CreateChapterAndChapterImageURLRequest request, string comicSEOAlias)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<int>();

            var checkExistComicDetail = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias);
            if (checkExistComicDetail == null)
                return new ApiErrorResult<int>(MessageConstants.ObjectNotFound("Comic"));

            var checkExistComic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == checkExistComicDetail.ComicId);
            if (checkExistComic == null)
                return new ApiErrorResult<int>(MessageConstants.ObjectNotFound("Comic"));

            var notACreator = _userContextService.CheckUserRoleAdminOrTeamMember();
            if (!notACreator.ResultObj)
            {
                if (checkExistComicDetail.CreatedBy != userResult.ResultObj)
                    return new ApiErrorResult<int>() { Message = MessageConstants.DoNotHavePermission, StatusCode = StatusCodeEnum.DoNotHavePermission };
            }

            var checkExistChapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterName.Equals(request.ChapterName) && x.ComicDetailId == checkExistComicDetail.ComicDetailId);
            if (checkExistChapter != null)
                return new ApiErrorResult<int>() { Message = MessageConstants.ObjectAlreadyExists("ChapterName") };

            var serialChapterOfComicCurrent = await _context.Chapters.Where(x => x.ComicDetailId == checkExistComicDetail.ComicDetailId).OrderByDescending(x => x.SerialChapterOfComic).FirstOrDefaultAsync();

            int serialChapterOfComicNext = -1;
            if (serialChapterOfComicCurrent != null)
            {
                if (serialChapterOfComicCurrent.SerialChapterOfComic == -1)
                {
                    serialChapterOfComicNext = serialChapterOfComicCurrent.SerialChapterOfComic + 2;
                }
                else
                {
                    serialChapterOfComicNext = serialChapterOfComicCurrent.SerialChapterOfComic + 1;
                }
            }

            var chapter = new Chapter()
            {
                ComicDetailId = checkExistComicDetail.ComicDetailId,
                ChapterName = request.ChapterName,
                ComicSEOAlias = checkExistComicDetail.ComicSEOAlias,
                ChapterSEOAlias = _commonService.ConvertTitleToSEOAlias(request.ChapterName, isChapter: true),
                SerialChapterOfComic = serialChapterOfComicNext,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                IsDeleted = false,
                CreatedBy = userResult.ResultObj,
                ApprovalStatus = ApprovalStatusEnum.Sent,
                DateApproved = null,
                UserIdApproved = null,
            };

            var isAdminOrTeamMember = _userContextService.CheckUserRoleAdminOrTeamMember();
            if (isAdminOrTeamMember.ResultObj)
            {
                chapter.ApprovalStatus = ApprovalStatusEnum.Approved;
                chapter.UserIdApproved = userResult.ResultObj;
                chapter.DateApproved = DateTime.Now;
            }

            await _context.Chapters.AddAsync(chapter);
            await _context.SaveChangesAsync();

            if (request.ChapterImageURLs != null)
            {
                int lengthUrlImageChapters = request.ChapterImageURLs.Count();
                for (int i = 0; i < lengthUrlImageChapters; i++)
                {
                    var createChapterImageURL = new CreateChapterImageURLRequest()
                    {
                        ChapterId = chapter.ChapterId,
                        ImageURL = request.ChapterImageURLs[i],
                        SerialImageURLOfChapter = i
                    };
                    var result = await _chapterImageURLService.CreateChapterImageURL(createChapterImageURL);

                    if (!result.IsSuccessed)
                    {
                        return new ApiErrorResult<int>("Chapter Image URL Error with Url: " + request.ChapterImageURLs[i]);
                    }
                }
            }

            var createNotificationRequest = new CreateNotificationRequest()
            {
                AppUserId = null,
                Actions = chapter.ComicSEOAlias,
                ImageURL = null,
                ComicId = checkExistComicDetail.ComicId,
                IsRead = false,
                NotificationPriority = NotificationPriorityEnum.Low,
                Message = checkExistComic.ComicName + " just updated the new chapter.",
                Title = "The notification has a new chapter.",
                CreatedBy = userResult.ResultObj
            };

            var resultCreateNotifications = await _notificationService.CreateNotifications(createNotificationRequest, NotificationTypeEnum.NewChapter);

            if (!resultCreateNotifications.IsSuccessed)
                return new ApiErrorResult<int>() { Message = MessageConstants.AnErrorOccurredInFunction(nameof(CreateChapter), "Create Notifcations NewChapter") };

            //creator send notification -> to admin, team members
            if (!isAdminOrTeamMember.ResultObj)
            {
                var createNotificationRequestApproval = new CreateNotificationRequest()
                {
                    Actions = checkExistComicDetail.ComicSEOAlias,
                    ComicId = checkExistComic.ComicId,
                    ChapterId = chapter.ChapterId,
                    ImageURL = checkExistComic.ComicCoverImageURL,
                    IsRead = false,
                    Title = $"Request for approval of the chapter '<strong>{chapter.ChapterName}</strong>'",
                    Message = $"Request for approval of the chapter '{chapter.ChapterName}' of comic '<strong>{checkExistComic.ComicName}</strong>'",
                };

                var resultCreateNotification = await _notificationService.CreateNotification(createNotificationRequestApproval, NotificationTypeEnum.RequestApproval);
            }

            return new ApiSuccessResult<int>(MessageConstants.CreateSuccess("Chapter"));
        }

        public async Task<PagingResult<ChapterManagementViewModel>> GetPagingManagement(PagingRequest request, string comicSEOAlias)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return new PagingResult<ChapterManagementViewModel>();

            comicSEOAlias = WebUtility.UrlDecode(comicSEOAlias);

            var checkComicDetailAlreadyExists = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias);
            if (checkComicDetailAlreadyExists == null)
                return new PagingResult<ChapterManagementViewModel>();

            var createdBy = userResult.ResultObj;
            var isCreator = !_userContextService.CheckUserRoleAdminOrTeamMember().ResultObj;

            var query = _context.Chapters
                .Where(x => x.ComicDetailId == checkComicDetailAlreadyExists.ComicDetailId);

            if (isCreator)
                query = query.Where(x => x.CreatedBy == createdBy);

            if (!string.IsNullOrEmpty(request.SearchValue))
                query = query.Where(x => x.ChapterName.ToLower().Contains(request.SearchValue.ToLower()));

            request.RecordsTotal = await query.CountAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                query = query.OrderByDescending((x) => x.SerialChapterOfComic);
            }

            var chapterViewModels = await query
                .Select(x => new ChapterManagementViewModel()
                {
                    ChapterId = x.ChapterId,
                    ComicDetailId = x.ComicDetailId,
                    DateCreated = x.DateCreated,
                    ChapterName = x.ChapterName,
                    SerialChapterOfComic = x.SerialChapterOfComic,
                    ViewCount = x.ViewCount,
                    IsDeleted = x.IsDeleted,
                    ComicSEOAlias = x.ComicSEOAlias,
                    ChapterSEOAlias = x.ChapterSEOAlias,
                    ApprovalStatus = x.ApprovalStatus,
                    DateApproved = x.DateApproved
                })
                .OrderByDescending((x) => x.SerialChapterOfComic)
                .Skip(request.Skip)
                .Take(request.PageSize)
                .ToListAsync();

            var result = new PagingResult<ChapterManagementViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = chapterViewModels
            };

            return result;

        }

        public async Task<ApiResult<bool>> RestoreDeletedChapter(int chapterId)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var checkChapterExits = await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterId == chapterId);
            if (checkChapterExits == null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Chapter"));

            var notACreator = _userContextService.CheckUserRoleAdminOrTeamMember();
            if (!notACreator.ResultObj)
            {
                if (checkChapterExits.CreatedBy != userResult.ResultObj)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.DoNotHavePermission, StatusCode = StatusCodeEnum.DoNotHavePermission };
            }

            if (!checkChapterExits.IsDeleted)
                return new ApiErrorResult<bool>() { Message = MessageConstants.CurrentObjectDeleted("Chapter") };

            checkChapterExits.IsDeleted = false;
            checkChapterExits.DateUpdated = DateTime.Now;
            checkChapterExits.UpdatedBy = userResult.ResultObj;

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>(MessageConstants.RestoreObjectSuccess("Chapter"));
        }

        public async Task<ApiResult<bool>> CheckUserPermissionForComic(string comicSEOAlias)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return new ApiErrorResult<bool>();

            var comicDetail = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias);
            if (comicDetail is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound(nameof(Comic)) };

            if (comicDetail.CreatedBy != userResult.ResultObj)
                return new ApiErrorResult<bool>() { Message = MessageConstants.DoNotHavePermission, StatusCode = StatusCodeEnum.DoNotHavePermission };

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> ApproveChapter(int chapterId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var chapter = await _context.Chapters.Include(x => x.ComicDetail).ThenInclude(x => x.Comic).FirstOrDefaultAsync(x => x.ChapterId == chapterId);
            if (chapter is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Chapter") };

            chapter.DateApproved = DateTime.Now;
            chapter.ApprovalStatus = ApprovalStatusEnum.Approved;
            chapter.UserIdApproved = userResult.ResultObj;

            await _context.SaveChangesAsync();

            //-> send notification
            var createNotificationRequest = new CreateNotificationRequest()
            {
                AppUserId = chapter.CreatedBy,
                ComicId = chapter.ComicDetail.ComicId,
                ChapterId = chapter.ChapterId,
                Actions = chapter.ComicSEOAlias,
                ImageURL = chapter.ComicDetail.Comic.ComicCoverImageURL,
                IsRead = false,
                Title = $"HikiComic System approved your chapter.",
                Message = $"HikiComic System approved your chapter '<strong>{chapter.ChapterName}</strong>'.",
            };

            var resultCreateNotification = await _notificationService.CreateNotification(createNotificationRequest, NotificationTypeEnum.ResponseApproval);

            return new ApiSuccessResult<bool>() { Message = MessageConstants.ApproveSuccess };
        }

        public async Task<ApiResult<bool>> RejectChapter(int chapterId, string feedback)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var chapter = await _context.Chapters.Include(x => x.ComicDetail).ThenInclude(x => x.Comic).FirstOrDefaultAsync(x => x.ChapterId == chapterId);
            if (chapter is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Chapter") };

            chapter.DateApproved = DateTime.Now;
            chapter.ApprovalStatus = ApprovalStatusEnum.Rejected;
            chapter.UserIdApproved = userResult.ResultObj;

            await _context.SaveChangesAsync();

            string notificationFeedback = String.IsNullOrEmpty(feedback) ? "" : $" The reason given was '{feedback}'";

            //-> send notification
            var createNotificationRequest = new CreateNotificationRequest()
            {
                AppUserId = chapter.CreatedBy,
                ComicId = chapter.ComicDetail.ComicId,
                ChapterId = chapter.ChapterId,
                Actions = chapter.ComicSEOAlias,
                ImageURL = chapter.ComicDetail.Comic.ComicCoverImageURL,
                IsRead = false,
                Title = $"HikiComic System has rejected the approval of your chapter.",
                Message = $"HikiComic System has rejected the approval of your chapter '<strong>{chapter.ChapterName}</strong>'.{notificationFeedback}",
            };

            var resultCreateNotification = await _notificationService.CreateNotification(createNotificationRequest, NotificationTypeEnum.ResponseApproval);

            return new ApiSuccessResult<bool>() { Message = MessageConstants.RejectSuccess };
        }
    }
}

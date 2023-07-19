using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.ChapterImageURLs;
using HikiComic.ViewModels.ChapterImageURLs.ChapterImageURLDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net;

namespace HikiComic.Application.ChapterImageURLs
{
    public class ChapterImageURLService : IChapterImageURLService
    {
        private readonly HikiComicDbContext _context;

        private readonly ILogger<ChapterImageURLService> _logger;

        private readonly IUserContextService _userContextService;

        public ChapterImageURLService(HikiComicDbContext context, ILogger<ChapterImageURLService> logger, IUserContextService userContextService)
        {
            _context = context;
            _logger = logger;
            _userContextService = userContextService;
        }

        public async Task<ApiResult<ChapterImageURLViewModel>> GetChapterByChapterId(int chapterId, Guid? userId)
        {
            var getChapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterId == chapterId);

            if (getChapter is null)
                return new ApiErrorResult<ChapterImageURLViewModel>() { Message = MessageConstants.ObjectNotFound("Chapter") };

            var numberOfComicChaptersForFree = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == (int)ServiceConfigEnum.NumberOfComicChaptersForFree);
            if (numberOfComicChaptersForFree is null)
                return new ApiErrorResult<ChapterImageURLViewModel>() { Message = MessageConstants.AnErrorOccurred };

            var getComicDetail = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicDetailId == getChapter.ComicDetailId);
            if (getComicDetail is null)
                return new ApiErrorResult<ChapterImageURLViewModel>(MessageConstants.ObjectNotFound("Comic Detail"));

            var getComic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == getComicDetail.ComicId);
            if (getComic is null)
                return new ApiErrorResult<ChapterImageURLViewModel>(MessageConstants.ObjectNotFound("Comic"));

            if (getChapter.SerialChapterOfComic < numberOfComicChaptersForFree.Value)
            {
                var result = await GetChapter(getComicDetail.ComicSEOAlias, getComic, getComicDetail, getChapter, userId);

                return result;
            }
            else
            {
                if (userId is null) 
                {
                    return new ApiErrorResult<ChapterImageURLViewModel> { Message = MessageConstants.UserIsNotLogin };
                }
                else
                {
                    var queryUserComicPurchase = from ucuh in _context.UserCoinUsageHistories
                                                 join ucp in _context.UserComicPurchases on ucuh.UserCoinUsageHistoryId equals ucp.UserCoinUsageHistoryId
                                                 join a in _context.Accounts on ucuh.AccountId equals a.AccountId
                                                 where a.AppUserId == userId && ucp.ChapterId == getChapter.ChapterId && ucp.ComicId == getComic.ComicId
                                                 select new { ucp };

                    var checkUserComicPurchase = await queryUserComicPurchase.Select(x => new UserComicPurchase()
                    {
                        ComicId = x.ucp.ComicId,
                        ChapterId = x.ucp.ChapterId
                    }).ToListAsync();

                    if (checkUserComicPurchase.Count == 0)
                    {
                        return new ApiErrorResult<ChapterImageURLViewModel>() { Message = MessageConstants.HaveNotPurchasedChapter };
                    }
                    else
                    {
                        var result = await GetChapter(getComicDetail.ComicSEOAlias, getComic, getComicDetail, getChapter, userId);

                        return result;
                    }
                }
            }
        }

        public async Task<ApiResult<ChapterImageURLViewModel>> GetChapterByChapterComicSEOAlias(string comicSEOAlias, string chapterSEOAlias, Guid? userId)
        {
            comicSEOAlias = WebUtility.UrlDecode(comicSEOAlias);
            chapterSEOAlias = WebUtility.UrlDecode(chapterSEOAlias);

            var getChapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias && x.ChapterSEOAlias == chapterSEOAlias);

            if (getChapter is null)
                return new ApiErrorResult<ChapterImageURLViewModel>() { Message = MessageConstants.ObjectNotFound("Chapter") };

            var numberOfComicChaptersForFree = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == (int)ServiceConfigEnum.NumberOfComicChaptersForFree);
            if (numberOfComicChaptersForFree is null)
                return new ApiErrorResult<ChapterImageURLViewModel>() { Message = MessageConstants.AnErrorOccurred };

            var getComicDetail = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias);
            if (getComicDetail is null)
                return new ApiErrorResult<ChapterImageURLViewModel>(MessageConstants.ObjectNotFound("Comic Detail"));

            var getComic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == getComicDetail.ComicId);
            if (getComic is null)
                return new ApiErrorResult<ChapterImageURLViewModel>(MessageConstants.ObjectNotFound("Comic"));

            if (getChapter.SerialChapterOfComic < numberOfComicChaptersForFree.Value)
            {
                var result = await GetChapter(comicSEOAlias, getComic, getComicDetail, getChapter, userId);

                return result;
            }
            else
            {
                if(userId is null)
                {
                    return new ApiErrorResult<ChapterImageURLViewModel> { Message = MessageConstants.UserIsNotLogin };
                }
                else
                {
                    var queryUserComicPurchase = from ucuh in _context.UserCoinUsageHistories
                                                 join ucp in _context.UserComicPurchases on ucuh.UserCoinUsageHistoryId equals ucp.UserCoinUsageHistoryId
                                                 join a in _context.Accounts on ucuh.AccountId equals a.AccountId
                                                 where a.AppUserId == userId && ucp.ChapterId == getChapter.ChapterId && ucp.ComicId == getComic.ComicId
                                                 select new { ucp };

                    var checkUserComicPurchase = await queryUserComicPurchase.Select(x => new UserComicPurchase()
                    {
                        ComicId = x.ucp.ComicId,
                        ChapterId = x.ucp.ChapterId
                    }).ToListAsync();

                    if (checkUserComicPurchase.Count == 0)
                    {
                        return new ApiErrorResult<ChapterImageURLViewModel>() { Message = MessageConstants.HaveNotPurchasedChapter };
                    }
                    else
                    {
                        var result = await GetChapter(comicSEOAlias, getComic, getComicDetail, getChapter, userId);

                        return result;
                    }
                }
            }
        }

        private async Task<ApiResult<ChapterImageURLViewModel>> GetChapter(string comicSEOAlias, Comic getComic, ComicDetail getComicDetail, Chapter getChapter, Guid? userId)
        {
            int serialNextChapterComic = 1;
            if (getChapter.SerialChapterOfComic != -1)
                serialNextChapterComic = getChapter.SerialChapterOfComic + 1;
            var getNextChapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias && x.SerialChapterOfComic == serialNextChapterComic);

            int serialPreviousChapterComic = -1;
            if (getChapter.SerialChapterOfComic != 1)
                serialPreviousChapterComic = getChapter.SerialChapterOfComic - 1;
            var getPreviousChapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias && x.SerialChapterOfComic == serialPreviousChapterComic);

            var queryUrlChapterImageComic = from c in _context.ChapterImageURLs
                                            where c.ChapterId == getChapter.ChapterId
                                            orderby c.SerialImageURLOfChapter ascending
                                            select new { c };

            var listUrlChapterImageComics = await queryUrlChapterImageComic.Select(x => x.c.ImageURL).ToListAsync();

            List<string> urlDecode = CutUrlToListUrl(listUrlChapterImageComics);

            var chapterImageURLViewModel = new ChapterImageURLViewModel()
            {
                ComicId = getComic.ComicId,
                ChapterId = getChapter.ChapterId,
                ComicName = getComic.ComicName,
                ChapterName = getChapter.ChapterName,
                ChapterImageURLs = urlDecode,
                NextChapterSEOAlias = getNextChapter?.ChapterSEOAlias,
                PreviousChapterSEOAlias = getPreviousChapter?.ChapterSEOAlias,
                ComicSEOAlias = comicSEOAlias,
                DateCreated = getComic.DateCreated
            };

            if (userId != null)
            {
                var checkFollow = await _context.UserComicFollowings.FirstOrDefaultAsync(x => x.ComicId == getComic.ComicId && x.AppUserId == userId);

                if (checkFollow != null)
                    chapterImageURLViewModel.IsFollow = true;

                var historyReadComicOfUser = new UserComicReadingHistory()
                {
                    ChapterId = chapterImageURLViewModel.ChapterId,
                    ComicId = getComic.ComicId,
                    DateRead = DateTime.Now,
                    AppUserId = (Guid)userId
                };

                getComic.ViewCount++;
                getChapter.ViewCount++;
                await _context.UserComicReadingHistories.AddAsync(historyReadComicOfUser);

                var servicePrice = await _context.ServicePrices.FirstOrDefaultAsync(x => x.ServicePriceId == (int)UsageMethodEnum.ReadComics);
                if (servicePrice is null)
                    return new ApiResult<ChapterImageURLViewModel>() { Message = MessageConstants.AnErrorOccurred };

                var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == userId);
                if (account is null)
                    return new ApiResult<ChapterImageURLViewModel>() { Message = MessageConstants.ObjectNotFound("Account") };

                account.Experienced += servicePrice.Price;

                await _context.SaveChangesAsync();
            }
            else
            {
                getComic.ViewCount++;
                getChapter.ViewCount++;
                await _context.SaveChangesAsync();
            }

            return new ApiSuccessResult<ChapterImageURLViewModel>() { ResultObj = chapterImageURLViewModel };
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

        public async Task<ApiResult<string>> CreateChapterImageURL(CreateChapterImageURLRequest request)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<string>();

            var checkExitsChapterComic = await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterId == request.ChapterId);
            if (checkExitsChapterComic == null)
                return new ApiErrorResult<string>(MessageConstants.ObjectNotFound("Chapter"));

            var chapterImageURL = new ChapterImageURL()
            {
                ChapterId = request.ChapterId,
                ImageURL = request.ImageURL,
                SerialImageURLOfChapter = request.SerialImageURLOfChapter,
                IsDeleted = false,
                DateCreated = DateTime.Now,
                CreatedBy = userResult.ResultObj
            };

            await _context.ChapterImageURLs.AddAsync(chapterImageURL);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<string>(MessageConstants.CreateSuccess("ChapterImageURL"));
        }

        public async Task<ApiResult<ChapterImageURLViewModel>> GetFreeChapterByChapterComicSEOAlias(string comicSEOAlias, string chapterSEOAlias, Guid? userId)
        {
            comicSEOAlias = WebUtility.UrlDecode(comicSEOAlias);
            chapterSEOAlias = WebUtility.UrlDecode(chapterSEOAlias);

            var getChapterComic = await _context.Chapters.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias && x.ChapterSEOAlias == chapterSEOAlias);

            if (getChapterComic == null)
                return new ApiErrorResult<ChapterImageURLViewModel>(MessageConstants.ObjectNotFound("Chapter"));


            var getComicDetail = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias);
            if (getComicDetail == null)
                return new ApiErrorResult<ChapterImageURLViewModel>(MessageConstants.ObjectNotFound("Comic Detail"));


            var getComic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == getComicDetail.ComicId);
            if (getComic == null)
                return new ApiErrorResult<ChapterImageURLViewModel>(MessageConstants.ObjectNotFound("Comic"));

            int serialNextChapterComic = 1;
            if (getChapterComic.SerialChapterOfComic != -1)
                serialNextChapterComic = getChapterComic.SerialChapterOfComic + 1;
            var getNextChapterComic = await _context.Chapters.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias && x.SerialChapterOfComic == serialNextChapterComic);

            int serialPreviousChapterComic = -1;
            if (getChapterComic.SerialChapterOfComic != 1)
                serialPreviousChapterComic = getChapterComic.SerialChapterOfComic - 1;
            var getPreviousChapterComic = await _context.Chapters.FirstOrDefaultAsync(x => x.ComicSEOAlias == comicSEOAlias && x.SerialChapterOfComic == serialPreviousChapterComic);

            var queryUrlChapterImageComic = from c in _context.ChapterImageURLs
                                            where c.ChapterId == getChapterComic.ChapterId
                                            orderby c.SerialImageURLOfChapter ascending
                                            select new { c };

            var listUrlChapterImageComics = await queryUrlChapterImageComic.Select(x => x.c.ImageURL).ToListAsync();

            List<string> urlDecode = CutUrlToListUrl(listUrlChapterImageComics);

            var chapterImageURLViewModel = new ChapterImageURLViewModel()
            {
                ComicId = getComic.ComicId,
                ChapterId = getChapterComic.ChapterId,
                ComicName = getComic.ComicName,
                ChapterName = getChapterComic.ChapterName,
                ChapterImageURLs = urlDecode,
                NextChapterSEOAlias = getNextChapterComic?.ChapterSEOAlias,
                PreviousChapterSEOAlias = getPreviousChapterComic?.ChapterSEOAlias,
                ComicSEOAlias = comicSEOAlias,
                DateCreated = getComic.DateCreated
            };

            if (userId != null)
            {
                var checkFollow = await _context.UserComicFollowings.FirstOrDefaultAsync(x => x.ComicId == getComic.ComicId && x.AppUserId == userId);

                if (checkFollow != null)
                    chapterImageURLViewModel.IsFollow = true;

                var userComicReadingHistory = new UserComicReadingHistory()
                {
                    ChapterId = chapterImageURLViewModel.ChapterId,
                    ComicId = getComic.ComicId,
                    DateRead = DateTime.Now,
                    AppUserId = (Guid)userId
                };

                getComic.ViewCount++;
                getChapterComic.ViewCount++;
                await _context.UserComicReadingHistories.AddAsync(userComicReadingHistory);
                await _context.SaveChangesAsync();
            }
            else
            {
                getComic.ViewCount++;
                getChapterComic.ViewCount++;
                await _context.SaveChangesAsync();
            }


            return new ApiSuccessResult<ChapterImageURLViewModel>() { ResultObj = chapterImageURLViewModel };
        }
    }
}

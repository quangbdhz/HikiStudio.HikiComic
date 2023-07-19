using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Comics;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.StatisticsReportForCreators;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HikiComic.Application.StatisticsReportForCreators
{
    public class StatisticsReportForCreatorService : IStatisticsReportForCreatorService
    {
        private readonly HikiComicDbContext _context;

        private readonly IUserContextService _userContextService;

        public StatisticsReportForCreatorService(HikiComicDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        public async Task<ApiResult<CreatorCardViewModel>> CreatorCard()
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<CreatorCardViewModel>();

            var card = new CreatorCardViewModel();

            var comics = await _context.Comics.Where(x => x.CreatedBy == userResult.ResultObj && !x.IsDeleted).ToListAsync();
            card.CountComic = comics.Count;

            var queryChapter = from c in _context.Comics
                               join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                               join ch in _context.Chapters on cd.ComicDetailId equals ch.ComicDetailId
                               where c.CreatedBy == userResult.ResultObj && !c.IsDeleted && !ch.IsDeleted
                               select ch;
            var chapter = await queryChapter.ToListAsync();
            card.CountChapter = chapter.Count;

            var queryCreator = from u in _context.Users
                               join ur in _context.UserRoles on u.Id equals ur.UserId
                               join r in _context.Roles on ur.RoleId equals r.Id
                               where !u.IsDeleted && r.Name == SystemConstants.AppSettings.CreatorRole
                               select u;
            var user = await queryCreator.ToListAsync();
            card.CountCreator = user.Count;

            var queryFollow = from f in _context.UserComicFollowings
                              join c in _context.Comics on f.ComicId equals c.ComicId
                              where c.CreatedBy == userResult.ResultObj && !c.IsDeleted
                              select c;

            var follow = await queryFollow.ToListAsync();
            card.CountFollowed = follow.Count;

            var viewedComic = await _context.Comics.Where(x => x.CreatedBy == userResult.ResultObj && !x.IsDeleted).SumAsync(x => x.ViewCount);
            card.TotalViewed = viewedComic;

            var queryCoin = from u in _context.Users
                            join a in _context.Accounts on u.Id equals a.AppUserId
                            join c in _context.Comics on u.Id equals c.CreatedBy
                            join ucp in _context.UserComicPurchases on c.ComicId equals ucp.ComicId
                            join ucuh in _context.UserCoinUsageHistories on ucp.UserCoinUsageHistoryId equals ucuh.UserCoinUsageHistoryId
                            where u.Id == userResult.ResultObj
                            select ucuh;

            var totalCoin = await queryCoin.SumAsync(x => x.UsageAmount);
            card.TotalRevenue = totalCoin;

            return new ApiSuccessResult<CreatorCardViewModel>() { ResultObj = card };
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> CreatorCreatedComics()
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<StatisticsReportBase<int>>();

            var query = from c in _context.Comics
                        where c.CreatedBy == userResult.ResultObj && !c.IsDeleted
                        select c;

            var twelveMonthsAgo = DateTime.Now.AddMonths(-11);

            var labels = Enumerable.Range(0, 12)
                                   .Select(i => twelveMonthsAgo.AddMonths(i).ToString("MM/yyyy"))
                                   .ToList();

            var data = await query.ToListAsync();

            var values = labels.Select(label => data.Where(c => c.DateCreated.Month == int.Parse(label.Substring(0, 2)) &&
                                                                   c.DateCreated.Year == int.Parse(label.Substring(3)))
                                                     .Count()).ToList();

            var result = new StatisticsReportBase<int>
            {
                Labels = labels,
                Data = values
            };

            return new ApiSuccessResult<StatisticsReportBase<int>>() { ResultObj = result };
        }

        public async Task<ApiResult<StatisticsReportBase<double>>> CreatorRevenueByOption(StatisticsEnum statistics)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<StatisticsReportBase<double>>();

            var query = from u in _context.Users
                        join a in _context.Accounts on u.Id equals a.AppUserId
                        join c in _context.Comics on u.Id equals c.CreatedBy
                        join ucp in _context.UserComicPurchases on c.ComicId equals ucp.ComicId
                        join ucuh in _context.UserCoinUsageHistories on ucp.UserCoinUsageHistoryId equals ucuh.UserCoinUsageHistoryId
                        where u.Id == userResult.ResultObj && ucuh.UsageMethodId == UsageMethodEnum.ReadComics
                        select ucuh;

            if (statistics == StatisticsEnum.Day)
            {
                var twelveDaysAgo = DateTime.Today.AddDays(-11);

                var labels = Enumerable.Range(0, 12)
                                       .Select(i => twelveDaysAgo.AddDays(i).ToString("dd/MM"))
                                       .ToList();

                var data = await query.ToListAsync();

                var values = labels.Select(label => data.Where(ucuh => ucuh.DateCreated.ToString("dd/MM") == label)
                                                         .Sum(ucuh => ucuh.UsageAmount))
                                   .ToList();

                var result = new StatisticsReportBase<double>
                {
                    Labels = labels,
                    Data = values
                };

                return new ApiSuccessResult<StatisticsReportBase<double>>() { ResultObj = result };
            }
            else if (statistics == StatisticsEnum.Month)
            {
                var twelveMonthsAgo = DateTime.Now.AddMonths(-11);

                var labels = Enumerable.Range(0, 12)
                                       .Select(i => twelveMonthsAgo.AddMonths(i).ToString("MM/yyyy"))
                                       .ToList();

                var data = await query.ToListAsync();

                var values = labels.Select(label => data.Where(ucuh => ucuh.DateCreated.Month == int.Parse(label.Substring(0, 2)) &&
                                                                       ucuh.DateCreated.Year == int.Parse(label.Substring(3)))
                                                         .Sum(ucuh => ucuh.UsageAmount))
                                   .ToList();

                var result = new StatisticsReportBase<double>
                {
                    Labels = labels,
                    Data = values
                };

                return new ApiSuccessResult<StatisticsReportBase<double>>() { ResultObj = result };
            }
            else if (statistics == StatisticsEnum.Year)
            {
                var fiveYearsAgo = DateTime.Now.AddYears(-4);

                var labels = Enumerable.Range(0, 5)
                                       .Select(i => (fiveYearsAgo.Year + i).ToString())
                                       .ToList();

                var data = await query.ToListAsync();

                var values = labels.Select(label => data.Where(ucuh => ucuh.DateCreated.Year == int.Parse(label))
                                                         .Sum(ucuh => ucuh.UsageAmount))
                                   .ToList();

                var result = new StatisticsReportBase<double>
                {
                    Labels = labels,
                    Data = values
                };

                return new ApiSuccessResult<StatisticsReportBase<double>>() { ResultObj = result };
            }
            else
            {
                return new ApiErrorResult<StatisticsReportBase<double>>() { Message = MessageConstants.AnErrorOccurred };
            }
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> CreatorTopComicMostFollowed(int numberOfComics)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<StatisticsReportBase<int>>();

            var query = from c in _context.Comics
                        where !c.IsDeleted && c.CreatedBy == userResult.ResultObj
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                        orderby c.CountFollow descending
                        select new { c, cd };

            var data = await query.Select(x => new InfoTopComicViewModel()
            {
                ComicName = x.c.ComicName,
                ComicSEOAlias = x.cd.ComicSEOAlias,
                Count = x.c.CountFollow
            }).OrderByDescending(x => x.Count).Take(numberOfComics).ToListAsync();

            var report = new StatisticsReportBase<int>();
            report.TopComics = data;

            return new ApiSuccessResult<StatisticsReportBase<int>>() { ResultObj = report };
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> CreatorTopComicMostViewed(int numberOfComics)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<StatisticsReportBase<int>>();

            var query = from c in _context.Comics
                        where !c.IsDeleted && c.CreatedBy == userResult.ResultObj
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                        orderby c.ViewCount descending
                        select new { c, cd };

            var data = await query.Select(x => new InfoTopComicViewModel()
            {
                ComicName = x.c.ComicName,
                ComicSEOAlias = x.cd.ComicSEOAlias,
                Count = x.c.ViewCount
            }).OrderByDescending(x => x.Count).Take(numberOfComics).ToListAsync();

            var report = new StatisticsReportBase<int>();
            report.TopComics = data;

            return new ApiSuccessResult<StatisticsReportBase<int>>() { ResultObj = report };
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> CreatorTopMostBoughtComics(int numberOfComics)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<StatisticsReportBase<int>>();

            var query = from c in _context.Comics
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                        join ch in _context.Chapters on cd.ComicDetailId equals ch.ComicDetailId
                        join cp in _context.UserComicPurchases on ch.ChapterId equals cp.ChapterId
                        where !c.IsDeleted && !ch.IsDeleted && c.CreatedBy == userResult.ResultObj && ch.CreatedBy == userResult.ResultObj
                        group c by new { c.ComicId, c.ComicName, cd.ComicSEOAlias } into g
                        orderby g.Count() descending
                        select new { ComicId = g.Key.ComicId, ComicName = g.Key.ComicName, ComicSEOAlias = g.Key.ComicSEOAlias, ChapterCount = g.Count() };

            var data = await query.Select(x => new InfoTopComicViewModel()
            {
                ComicName = x.ComicName,
                ComicSEOAlias = x.ComicSEOAlias,
                Count = x.ChapterCount
            }).OrderByDescending(x => x.Count).Take(numberOfComics).ToListAsync();

            var report = new StatisticsReportBase<int>();
            report.TopComics = data;

            return new ApiSuccessResult<StatisticsReportBase<int>>() { ResultObj = report };
        }

        public async Task<ApiResult<TopUserByComicViewModel<double>>> CreatorTopUserByComics(int numberOfComics)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<TopUserByComicViewModel<double>>();

            var query = from c in _context.Comics
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                        join ch in _context.Chapters on cd.ComicDetailId equals ch.ComicDetailId
                        join ucp in _context.UserComicPurchases on ch.ChapterId equals ucp.ChapterId
                        join ucuh in _context.UserCoinUsageHistories on ucp.UserCoinUsageHistoryId equals ucuh.UserCoinUsageHistoryId
                        join a in _context.Accounts on ucuh.AccountId equals a.AccountId
                        join u in _context.Users on a.AppUserId equals u.Id
                        where !c.IsDeleted && !ch.IsDeleted && c.CreatedBy == userResult.ResultObj && ch.CreatedBy == userResult.ResultObj
                        group new { u.Email, a.Nickname, u.UserImageURL, ucuh.UsageAmount } by new { u.Email, a.Nickname, u.UserImageURL } into g
                        select new { Email = g.Key.Email, UserImageURL = g.Key.UserImageURL, NickName = g.Key.Nickname, ChapterCount = g.Count(), UsageAmountSum = g.Sum(x => x.UsageAmount) };

            var data = await query.Select(x => new InfoTopComicViewModel()
            {
                ComicName = x.Email,
                ComicSEOAlias = x.UserImageURL.Contains("http") ? x.UserImageURL : SystemConstants.AppSettings.URLDomainMyHostProduct + "uploads/user-avatar/" + x.UserImageURL,
                Count = x.UsageAmountSum
            }).OrderByDescending(x => x.Count).Take(numberOfComics).ToListAsync();

            var report = new TopUserByComicViewModel<double>();
            report.TopComics = data;

            return new ApiSuccessResult<TopUserByComicViewModel<double>>() { ResultObj = report };
        }
    }
}

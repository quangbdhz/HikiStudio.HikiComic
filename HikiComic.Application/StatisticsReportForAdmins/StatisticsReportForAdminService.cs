using HikiComic.Application.ExchangeRate;
using HikiComic.Application.UserContext;
using HikiComic.Data.EF;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.StatisticsReportForAdmins;
using Microsoft.EntityFrameworkCore;

namespace HikiComic.Application.StatisticsReportForAdmins
{
    public class StatisticsReportForAdminService : IStatisticsReportForAdminService
    {
        private readonly HikiComicDbContext _context;

        private readonly IUserContextService _userContextService;

        private readonly IExchangeRateService _exchangeRateService;

        public StatisticsReportForAdminService(HikiComicDbContext context, IUserContextService userContextService, IExchangeRateService exchangeRateService)
        {
            _context = context;
            _userContextService = userContextService;
            _exchangeRateService = exchangeRateService;
        }

        public async Task<ApiResult<AdminCardViewModel>> AdminCard()
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<AdminCardViewModel>();

            var card = new AdminCardViewModel();

            //get the number of comics 
            var comics = await _context.Comics.Where(x => !x.IsDeleted).ToListAsync();
            card.CountComic = comics.Count;

            //get the number of chapters
            var queryChapter = from c in _context.Comics
                               join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                               join ch in _context.Chapters on cd.ComicDetailId equals ch.ComicDetailId
                               where !c.IsDeleted && !ch.IsDeleted
                               select ch;
            var chapter = await queryChapter.ToListAsync();
            card.CountChapter = chapter.Count;

            //get the number of readers
            var queryReader = from u in _context.Users
                              join ur in _context.UserRoles on u.Id equals ur.UserId
                              join r in _context.Roles on ur.RoleId equals r.Id
                              where !u.IsDeleted && r.Name == SystemConstants.AppSettings.ReaderRole
                              select u;
            var userWithRoleReader = await queryReader.ToListAsync();
            card.CountReader = userWithRoleReader.Count;

            //get the number of creators
            var queryCreator = from u in _context.Users
                               join ur in _context.UserRoles on u.Id equals ur.UserId
                               join r in _context.Roles on ur.RoleId equals r.Id
                               where !u.IsDeleted && r.Name == SystemConstants.AppSettings.CreatorRole
                               select u;
            var userWithRoleCreator = await queryCreator.ToListAsync();
            card.CountCreator = userWithRoleCreator.Count;

            //get the number of team members
            var queryTeamMembers = from u in _context.Users
                                   join ur in _context.UserRoles on u.Id equals ur.UserId
                                   join r in _context.Roles on ur.RoleId equals r.Id
                                   where !u.IsDeleted && r.Name == SystemConstants.AppSettings.TeamMembersRole
                                   select u;
            var userWithRoleTeamMembers = await queryTeamMembers.ToListAsync();
            card.CountTeamMeber = userWithRoleTeamMembers.Count;

            //get the number of admins
            var queryAdmin = from u in _context.Users
                             join ur in _context.UserRoles on u.Id equals ur.UserId
                             join r in _context.Roles on ur.RoleId equals r.Id
                             where !u.IsDeleted && r.Name == SystemConstants.AppSettings.AdminRole
                             select u;
            var userWithRoleAdmin = await queryAdmin.ToListAsync();
            card.CountAdmin = userWithRoleAdmin.Count;

            //get the number of followed
            var queryFollow = from f in _context.UserComicFollowings
                              join c in _context.Comics on f.ComicId equals c.ComicId
                              where !c.IsDeleted
                              select c;
            var follow = await queryFollow.ToListAsync();
            card.CountFollowed = follow.Count;

            //get the number of viewed
            var viewedComic = await _context.Comics.Where(x => !x.IsDeleted).SumAsync(x => x.ViewCount);
            card.TotalViewed = viewedComic;

            //get the number of total coins
            var queryCoin = from u in _context.Users
                            join a in _context.Accounts on u.Id equals a.AppUserId
                            join c in _context.Comics on u.Id equals c.CreatedBy
                            join ucp in _context.UserComicPurchases on c.ComicId equals ucp.ComicId
                            join ucuh in _context.UserCoinUsageHistories on ucp.UserCoinUsageHistoryId equals ucuh.UserCoinUsageHistoryId
                            where ucuh.UsageStatusId == UsageStatusEnum.Completed
                            select ucuh;
            var totalCoin = await queryCoin.SumAsync(x => x.UsageAmount);
            card.TotalRevenue = totalCoin;

            //get the number of configs
            var config = await _context.ServiceConfigs.Where(x => !x.IsDeleted).ToListAsync();
            card.CountConfig = config.Count();

            //get the number of roles
            var roles = await _context.Roles.Where(x => !x.IsDeleted).ToListAsync();
            card.CountRole = roles.Count();

            //get the number of authors
            var authors = await _context.Authors.Where(x => !x.IsDeleted).ToListAsync();
            card.CountAuthor = authors.Count();

            //get the number of genres
            var genres = await _context.Genres.Where(x => !x.IsDeleted).ToListAsync();
            card.CountGenre = genres.Count();

            //get the number of artists
            var artists = await _context.Artists.Where(x => !x.IsDeleted).ToListAsync();
            card.CountArtist = artists.Count();

            return new ApiSuccessResult<AdminCardViewModel>() { ResultObj = card };
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> AdminCreatedComicByYear(int year)
        {
            List<string> month = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            List<int> value = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var Comics = await _context.Comics.Where(x => x.DateCreated.Year == year).ToListAsync();

            foreach (var item in Comics)
            {
                value[item.DateCreated.Month - 1]++;
            }

            int maxValueColumn = value.Max(x => x) + (int)(value.Max(x => x) / 12) + 2;

            var statisticsReport = new StatisticsReportBase<int>()
            {
                Labels = month,
                Data = value,
                ValueMaxColumn = maxValueColumn
            };

            return new ApiSuccessResult<StatisticsReportBase<int>>() { ResultObj = statisticsReport };
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> AdminDOBUserByAge()
        {
            List<string> groupAge = new List<string> { "Not update", "1-17", "18-29", "30-49", "50-64", "65+" };
            List<int> value = new List<int> { 0, 0, 0, 0, 0, 0 };
            List<string> colors = new List<string> { "#44bd32", "#487eb0", "#e84118", "#8c7ae6", "#f5f6fa", "#2f3640" };

            var users = await _context.Users.ToListAsync();

            foreach (var item in users)
            {
                if (item.DOB == null)
                {
                    value[0]++;
                }
                else
                {
                    DateTime dob = (DateTime)(item.DOB != null ? item.DOB : DateTime.Now);

                    int age = DateTime.Now.Year - dob.Year;

                    if (0 <= age && 17 >= age)
                    {
                        value[1]++;
                    }
                    else if (18 <= age && 29 >= age)
                    {
                        value[2]++;
                    }
                    else if (30 <= age && 49 >= age)
                    {
                        value[3]++;
                    }
                    else if (50 <= age && 64 >= age)
                    {
                        value[4]++;
                    }
                    else
                    {
                        value[5]++;
                    }
                }
            }

            var reportBase = new StatisticsReportBase<int>() { Data = value, Labels = groupAge, ColorColumn = colors };

            return new ApiSuccessResult<StatisticsReportBase<int>>() { ResultObj = reportBase };
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> AdminGenders()
        {
            var query = from u in _context.Users
                        join ur in _context.UserRoles on u.Id equals ur.UserId
                        join r in _context.Roles on ur.RoleId equals r.Id
                        join g in _context.Genders on u.GenderId equals g.GenderId into genderGroup
                        from g in genderGroup.DefaultIfEmpty()
                        where r.Name == SystemConstants.AppSettings.ReaderRole
                        select new { u, g };

            var genders = await query.GroupBy(x => new { x.g.GenderId, x.g.GenderName })
                                    .Select(group => new
                                    {
                                        GenderId = group.Key.GenderId,
                                        GenderName = group.Key.GenderName,
                                        Count = group.Count()
                                    })
                                    .ToListAsync();

            int totalUser = await query.CountAsync();

            int totalUserGroup = 0;
            var result = new StatisticsReportBase<int>();
            foreach (var item in genders)
            {
                result.Labels.Add(item.GenderName);
                result.Data.Add(item.Count);
                totalUserGroup += item.Count;
            }

            result.Labels.Add("Not Updated");
            result.Data.Add(totalUser - totalUserGroup);

            return new ApiSuccessResult<StatisticsReportBase<int>>() { ResultObj = result };
        }

        public async Task<ApiResult<StatisticsReportBase<int>>> AdminGroupGenders()
        {
            var query = _context.Users
            .Include(u => u.AppUserRoles)
                .ThenInclude(ur => ur.AppRole)
            .Include(u => u.Gender)
            .Where(u => u.AppUserRoles.Any(ur => ur.AppRole.Name == SystemConstants.AppSettings.ReaderRole))
            .Select(u => new { u, g = u.Gender });

            var genders = await query.GroupBy(x => new
            {
                GenderId = x.g != null ? x.g.GenderId : default(int?),
                GenderName = x.g != null ? x.g.GenderName : null
            })
            .Select(group => new
            {
                GenderId = group.Key.GenderId,
                GenderName = group.Key.GenderName,
                Count = group.Count()
            })
            .ToListAsync();

            int totalUser = query.Count();

            int totalUserGroup = 0;
            var result = new StatisticsReportBase<int>();
            foreach (var item in genders)
            {
                result.Labels.Add(item.GenderName ?? "");
                result.Data.Add(item.Count);
                totalUserGroup += item.Count;
            }

            result.Labels.Add("Not Updated");
            result.Data.Add(totalUser - totalUserGroup);

            return new ApiSuccessResult<StatisticsReportBase<int>>() { ResultObj = result };

        }

        public async Task<ApiResult<StatisticsReportBase<int>>> AdminRegisterUserByYear(int year)
        {
            List<string> month = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            List<int> value = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var users = await _context.Users.Where(x => x.DateCreated.Year == year).ToListAsync();

            foreach (var item in users)
            {
                value[item.DateCreated.Month - 1]++;
            }

            int maxValueColumn = value.Max(x => x) + (int)(value.Max(x => x) / 12) + 2;

            var statisticsReport = new StatisticsReportBase<int>()
            {
                Labels = month,
                Data = value,
                ValueMaxColumn = maxValueColumn
            };

            return new ApiSuccessResult<StatisticsReportBase<int>>() { ResultObj = statisticsReport };
        }

        public async Task<ApiResult<List<TopUserViewModel<double>>>> AdminTopCreatorComicMostCoin(int numberOfCreators, StatisticsEnum statisticsEnum)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<List<TopUserViewModel<double>>>();

            if (statisticsEnum == StatisticsEnum.Day)
            {
                var currentDate = DateTime.UtcNow.Date;

                var query = from u in _context.Users
                            join ur in _context.UserRoles on u.Id equals ur.UserId
                            join r in _context.Roles on ur.RoleId equals r.Id
                            join a in _context.Accounts on u.Id equals a.AppUserId
                            join c in _context.Comics on u.Id equals c.CreatedBy
                            join ucp in _context.UserComicPurchases on c.ComicId equals ucp.ComicId
                            join ucuh in _context.UserCoinUsageHistories on ucp.UserCoinUsageHistoryId equals ucuh.UserCoinUsageHistoryId
                            where ucuh.UsageMethodId == UsageMethodEnum.ReadComics && ucuh.UsageStatusId == UsageStatusEnum.Completed
                                    && !u.IsDeleted && r.Name == SystemConstants.AppSettings.CreatorRole && (ucuh.DateCreated >= currentDate && ucuh.DateCreated <= currentDate.AddDays(1).AddTicks(-1))
                            group ucuh.UsageAmount by new { u.UserName, u.Email, a.Nickname, u.UserImageURL } into g
                            select new
                            {
                                UserName = g.Key.UserName,
                                Email = g.Key.Email,
                                Nickname = g.Key.Nickname,
                                UserImageURL = g.Key.UserImageURL.Contains("http") ? g.Key.UserImageURL : SystemConstants.AppSettings.URLDomainMyHostProduct + "uploads/user-avatar/" + g.Key.UserImageURL,
                                TotalUsageCoin = g.Sum()
                            };


                var data = await query.OrderByDescending(x => x.TotalUsageCoin).Take(numberOfCreators).Select(x => new TopUserViewModel<double>()
                {
                    Email = x.Email,
                    UserName = x.UserName,
                    Nickname = x.Nickname,
                    UserImageURL = x.UserImageURL,
                    Value = x.TotalUsageCoin
                }).ToListAsync();

                return new ApiSuccessResult<List<TopUserViewModel<double>>>() { ResultObj = data };
            }
            else if (statisticsEnum == StatisticsEnum.Month)
            {
                var currentYear = DateTime.UtcNow.Year;
                var currentMonth = DateTime.UtcNow.Month;

                var query = from u in _context.Users
                            join ur in _context.UserRoles on u.Id equals ur.UserId
                            join r in _context.Roles on ur.RoleId equals r.Id
                            join a in _context.Accounts on u.Id equals a.AppUserId
                            join c in _context.Comics on u.Id equals c.CreatedBy
                            join ucp in _context.UserComicPurchases on c.ComicId equals ucp.ComicId
                            join ucuh in _context.UserCoinUsageHistories on ucp.UserCoinUsageHistoryId equals ucuh.UserCoinUsageHistoryId
                            where ucuh.UsageMethodId == UsageMethodEnum.ReadComics && ucuh.UsageStatusId == UsageStatusEnum.Completed
                                    && !u.IsDeleted && r.Name == SystemConstants.AppSettings.CreatorRole && (ucuh.DateCreated.Year == currentYear && ucuh.DateCreated.Month == currentMonth)
                            group ucuh.UsageAmount by new { u.UserName, u.Email, a.Nickname, u.UserImageURL } into g
                            select new
                            {
                                UserName = g.Key.UserName,
                                Email = g.Key.Email,
                                Nickname = g.Key.Nickname,
                                UserImageURL = g.Key.UserImageURL.Contains("http") ? g.Key.UserImageURL : SystemConstants.AppSettings.URLDomainMyHostProduct + "uploads/user-avatar/" + g.Key.UserImageURL,
                                TotalUsageCoin = g.Sum()
                            };

                var data = await query.OrderByDescending(x => x.TotalUsageCoin).Take(numberOfCreators).Select(x => new TopUserViewModel<double>()
                {
                    Email = x.Email,
                    UserName = x.UserName,
                    Nickname = x.Nickname,
                    UserImageURL = x.UserImageURL,
                    Value = x.TotalUsageCoin
                }).ToListAsync();


                return new ApiSuccessResult<List<TopUserViewModel<double>>>() { ResultObj = data };
            }
            else if (statisticsEnum == StatisticsEnum.Year)
            {
                var currentYear = DateTime.UtcNow.Year;
                var query = from u in _context.Users
                            join ur in _context.UserRoles on u.Id equals ur.UserId
                            join r in _context.Roles on ur.RoleId equals r.Id
                            join a in _context.Accounts on u.Id equals a.AppUserId
                            join c in _context.Comics on u.Id equals c.CreatedBy
                            join ucp in _context.UserComicPurchases on c.ComicId equals ucp.ComicId
                            join ucuh in _context.UserCoinUsageHistories on ucp.UserCoinUsageHistoryId equals ucuh.UserCoinUsageHistoryId
                            where ucuh.UsageMethodId == UsageMethodEnum.ReadComics && ucuh.UsageStatusId == UsageStatusEnum.Completed
                                    && !u.IsDeleted && r.Name == SystemConstants.AppSettings.CreatorRole && (ucuh.DateCreated.Year == currentYear)
                            group ucuh.UsageAmount by new { u.UserName, u.Email, a.Nickname, u.UserImageURL } into g
                            select new
                            {
                                UserName = g.Key.UserName,
                                Email = g.Key.Email,
                                Nickname = g.Key.Nickname,
                                UserImageURL = g.Key.UserImageURL.Contains("http") ? g.Key.UserImageURL : SystemConstants.AppSettings.URLDomainMyHostProduct + "uploads/user-avatar/" + g.Key.UserImageURL,
                                TotalUsageCoin = g.Sum()
                            };

                var data = await query.OrderByDescending(x => x.TotalUsageCoin).Take(numberOfCreators).Select(x => new TopUserViewModel<double>()
                {
                    Email = x.Email,
                    UserName = x.UserName,
                    Nickname = x.Nickname,
                    UserImageURL = x.UserImageURL,
                    Value = x.TotalUsageCoin
                }).ToListAsync();

                return new ApiSuccessResult<List<TopUserViewModel<double>>>() { ResultObj = data };
            }
            else
            {
                return new ApiSuccessResult<List<TopUserViewModel<double>>>() { Message = MessageConstants.AnErrorOccurred };
            }
        }

        public async Task<ApiResult<List<TopUserViewModel<double>>>> AdminTopCreatorComicMostViewed(int numberOfCreators)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<List<TopUserViewModel<double>>>();

            var query = from u in _context.Users
                        join ur in _context.UserRoles on u.Id equals ur.UserId
                        join r in _context.Roles on ur.RoleId equals r.Id
                        join a in _context.Accounts on u.Id equals a.AppUserId
                        join c in _context.Comics on u.Id equals c.CreatedBy
                        where c.CreatedBy == u.Id && !u.IsDeleted && r.Name == SystemConstants.AppSettings.CreatorRole
                        group c.ViewCount by new { u.UserName, u.Email, a.Nickname, u.UserImageURL } into g
                        select new
                        {
                            UserName = g.Key.UserName,
                            Email = g.Key.Email,
                            Nickname = g.Key.Nickname,
                            UserImageURL = g.Key.UserImageURL.Contains("http") ? g.Key.UserImageURL : SystemConstants.AppSettings.URLDomainMyHostProduct + "uploads/user-avatar/" + g.Key.UserImageURL,
                            TotalViewed = g.Sum()
                        };

            var data = await query.OrderByDescending(x => x.TotalViewed).Take(numberOfCreators).Select(x => new TopUserViewModel<double>()
            {
                Email = x.Email,
                UserName = x.UserName,
                Nickname = x.Nickname,
                UserImageURL = x.UserImageURL,
                Value = x.TotalViewed
            }).ToListAsync();

            return new ApiSuccessResult<List<TopUserViewModel<double>>>() { ResultObj = data };
        }

        public async Task<ApiResult<List<TopUserCoinViewModel<double>>>> AdminTopReaderDepositCoin(int numberOfReaders, StatisticsEnum statisticsEnum)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<List<TopUserCoinViewModel<double>>>();

            if (statisticsEnum == StatisticsEnum.Day)
            {
                var currentDate = DateTime.UtcNow.Date;

                var query = from u in _context.Users
                            join ur in _context.UserRoles on u.Id equals ur.UserId
                            join r in _context.Roles on ur.RoleId equals r.Id
                            join a in _context.Accounts on u.Id equals a.AppUserId
                            join ucph in _context.UserCoinDepositHistories on a.AccountId equals ucph.AccountId
                            where ucph.DepositStatusId == DepositStatusEnum.Completed && !u.IsDeleted && r.Name == SystemConstants.AppSettings.ReaderRole && (ucph.DateCreated >= currentDate && ucph.DateCreated <= currentDate.AddDays(1).AddTicks(-1))
                            group ucph.DepositAmount by new { u.UserName, u.Email, a.Nickname, ucph.ConvertCurrency } into g
                            select new
                            {
                                UserName = g.Key.UserName,
                                Email = g.Key.Email,
                                Nickname = g.Key.Nickname,
                                ConvertCurrency = g.Key.Nickname,
                                TotalDepositCoin = g.Sum()
                            };

                var data = await query.OrderByDescending(x => x.TotalDepositCoin).Take(numberOfReaders).Select(x => new TopUserCoinViewModel<double>()
                {
                    Email = x.Email,
                    UserName = x.UserName,
                    Nickname = x.Nickname,
                    Currency = x.ConvertCurrency,
                    Value = x.TotalDepositCoin
                }).ToListAsync();

                //if(data.Count > 0)
                //{
                //    var defaultCurrent = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == (int)ServiceConfigEnum.DefaultCurrency);
                //    if (defaultCurrent is null)
                //        return new ApiErrorResult<List<TopUserCoinViewModel<double>>>() { Message = MessageConstants.AnErrorOccurred };

                //    if (data[0].Currency == defaultCurrent.StringValue)
                //    {
                //        var resultExchangeDefault = await _exchangeRateService.GetExchangeRateByCurrency("VND");
                //        if (resultExchangeDefault is null)
                //            return new ApiErrorResult<List<TopUserCoinViewModel<double>>>() { Message = MessageConstants.AnErrorOccurred };

                //        var resultExchangeNew = await _exchangeRateService.GetExchangeRateByCurrency(defaultCurrent.StringValue);
                //        if (resultExchangeNew is null)
                //            return new ApiErrorResult<List<TopUserCoinViewModel<double>>>() { Message = MessageConstants.AnErrorOccurred };

                //        foreach (var item in data)
                //        {
                //            item.Value = item.Value / resultExchangeDefault.ResultObj * resultExchangeNew.ResultObj;
                //        }
                //    }
                //}

                return new ApiSuccessResult<List<TopUserCoinViewModel<double>>>() { ResultObj = data };
            }
            else if (statisticsEnum == StatisticsEnum.Month)
            {
                var currentYear = DateTime.UtcNow.Year;
                var currentMonth = DateTime.UtcNow.Month;

                var query = from u in _context.Users
                            join ur in _context.UserRoles on u.Id equals ur.UserId
                            join r in _context.Roles on ur.RoleId equals r.Id
                            join a in _context.Accounts on u.Id equals a.AppUserId
                            join ucph in _context.UserCoinDepositHistories on a.AccountId equals ucph.AccountId
                            where ucph.DepositStatusId == DepositStatusEnum.Completed && !u.IsDeleted && r.Name == SystemConstants.AppSettings.ReaderRole && (ucph.DateCreated.Year == currentYear && ucph.DateCreated.Month == currentMonth)
                            group ucph.DepositAmount by new { u.UserName, u.Email, a.Nickname, ucph.ConvertCurrency } into g
                            select new
                            {
                                UserName = g.Key.UserName,
                                Email = g.Key.Email,
                                Nickname = g.Key.Nickname,
                                ConvertCurrency = g.Key.Nickname,
                                TotalDepositCoin = g.Sum()
                            };

                var data = await query.OrderByDescending(x => x.TotalDepositCoin).Take(numberOfReaders).Select(x => new TopUserCoinViewModel<double>()
                {
                    Email = x.Email,
                    UserName = x.UserName,
                    Nickname = x.Nickname,
                    Currency = x.ConvertCurrency,
                    Value = x.TotalDepositCoin
                }).ToListAsync();

                return new ApiSuccessResult<List<TopUserCoinViewModel<double>>>() { ResultObj = data };
            }
            else if (statisticsEnum == StatisticsEnum.Year)
            {
                var currentYear = DateTime.UtcNow.Year;

                var query = from u in _context.Users
                            join ur in _context.UserRoles on u.Id equals ur.UserId
                            join r in _context.Roles on ur.RoleId equals r.Id
                            join a in _context.Accounts on u.Id equals a.AppUserId
                            join ucph in _context.UserCoinDepositHistories on a.AccountId equals ucph.AccountId
                            where ucph.DepositStatusId == DepositStatusEnum.Completed && !u.IsDeleted && r.Name == SystemConstants.AppSettings.ReaderRole && (ucph.DateCreated.Year == currentYear)
                            group ucph.DepositAmount by new { u.UserName, u.Email, a.Nickname, ucph.ConvertCurrency } into g
                            select new
                            {
                                UserName = g.Key.UserName,
                                Email = g.Key.Email,
                                Nickname = g.Key.Nickname,
                                ConvertCurrency = g.Key.Nickname,
                                TotalDepositCoin = g.Sum()
                            };

                var data = await query.OrderByDescending(x => x.TotalDepositCoin).Take(numberOfReaders).Select(x => new TopUserCoinViewModel<double>()
                {
                    Email = x.Email,
                    UserName = x.UserName,
                    Nickname = x.Nickname,
                    Currency = x.ConvertCurrency,
                    Value = x.TotalDepositCoin
                }).ToListAsync();

                return new ApiSuccessResult<List<TopUserCoinViewModel<double>>>() { ResultObj = data };
            }
            else
            {
                return new ApiSuccessResult<List<TopUserCoinViewModel<double>>>() { Message = MessageConstants.AnErrorOccurred };
            }
        }

        public async Task<ApiResult<List<TopUserCoinViewModel<double>>>> AdminTopReaderUsageCoin(int numberOfReaders, StatisticsEnum statisticsEnum)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<List<TopUserCoinViewModel<double>>>();

            if (statisticsEnum == StatisticsEnum.Day)
            {
                var currentDate = DateTime.UtcNow.Date;

                var query = from u in _context.Users
                            join ur in _context.UserRoles on u.Id equals ur.UserId
                            join r in _context.Roles on ur.RoleId equals r.Id
                            join a in _context.Accounts on u.Id equals a.AppUserId
                            join ucuh in _context.UserCoinUsageHistories on a.AccountId equals ucuh.AccountId
                            where ucuh.UsageStatusId == UsageStatusEnum.Completed && !u.IsDeleted && r.Name == SystemConstants.AppSettings.ReaderRole && (ucuh.DateCreated >= currentDate && ucuh.DateCreated <= currentDate.AddDays(1).AddTicks(-1))
                            group ucuh.UsageAmount by new { u.UserName, u.Email, a.Nickname } into g
                            select new
                            {
                                UserName = g.Key.UserName,
                                Email = g.Key.Email,
                                Nickname = g.Key.Nickname,
                                TotalUsageCoin = g.Sum()
                            };

                var data = await query.OrderByDescending(x => x.TotalUsageCoin).Take(numberOfReaders).Select(x => new TopUserCoinViewModel<double>()
                {
                    Email = x.Email,
                    UserName = x.UserName,
                    Nickname = x.Nickname,
                    Value = x.TotalUsageCoin
                }).ToListAsync();

                return new ApiSuccessResult<List<TopUserCoinViewModel<double>>>() { ResultObj = data };
            }
            else if (statisticsEnum == StatisticsEnum.Month)
            {
                var currentYear = DateTime.UtcNow.Year;
                var currentMonth = DateTime.UtcNow.Month;

                var query = from u in _context.Users
                            join ur in _context.UserRoles on u.Id equals ur.UserId
                            join r in _context.Roles on ur.RoleId equals r.Id
                            join a in _context.Accounts on u.Id equals a.AppUserId
                            join ucuh in _context.UserCoinUsageHistories on a.AccountId equals ucuh.AccountId
                            where ucuh.UsageStatusId == UsageStatusEnum.Completed && !u.IsDeleted && r.Name == SystemConstants.AppSettings.ReaderRole && (ucuh.DateCreated.Year == currentYear && ucuh.DateCreated.Month == currentMonth)
                            group ucuh.UsageAmount by new { u.UserName, u.Email, a.Nickname } into g
                            select new
                            {
                                UserName = g.Key.UserName,
                                Email = g.Key.Email,
                                Nickname = g.Key.Nickname,
                                TotalUsageCoin = g.Sum()
                            };

                var data = await query.OrderByDescending(x => x.TotalUsageCoin).Take(numberOfReaders).Select(x => new TopUserCoinViewModel<double>()
                {
                    Email = x.Email,
                    UserName = x.UserName,
                    Nickname = x.Nickname,
                    Value = x.TotalUsageCoin
                }).ToListAsync();


                return new ApiSuccessResult<List<TopUserCoinViewModel<double>>>() { ResultObj = data };
            }
            else if (statisticsEnum == StatisticsEnum.Year)
            {
                var currentYear = DateTime.UtcNow.Year;

                var query = from u in _context.Users
                            join ur in _context.UserRoles on u.Id equals ur.UserId
                            join r in _context.Roles on ur.RoleId equals r.Id
                            join a in _context.Accounts on u.Id equals a.AppUserId
                            join ucuh in _context.UserCoinUsageHistories on a.AccountId equals ucuh.AccountId
                            where ucuh.UsageStatusId == UsageStatusEnum.Completed && !u.IsDeleted && r.Name == SystemConstants.AppSettings.ReaderRole && (ucuh.DateCreated.Year == currentYear)
                            group ucuh.UsageAmount by new { u.UserName, u.Email, a.Nickname } into g
                            select new
                            {
                                UserName = g.Key.UserName,
                                Email = g.Key.Email,
                                Nickname = g.Key.Nickname,
                                TotalUsageCoin = g.Sum()
                            };

                var data = await query.OrderByDescending(x => x.TotalUsageCoin).Take(numberOfReaders).Select(x => new TopUserCoinViewModel<double>()
                {
                    Email = x.Email,
                    UserName = x.UserName,
                    Nickname = x.Nickname,
                    Value = x.TotalUsageCoin
                }).ToListAsync();

                return new ApiSuccessResult<List<TopUserCoinViewModel<double>>>() { ResultObj = data };
            }
            else
            {
                return new ApiSuccessResult<List<TopUserCoinViewModel<double>>>() { Message = MessageConstants.AnErrorOccurred };
            }
        }
    }
}

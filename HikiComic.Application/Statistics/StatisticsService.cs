using HikiComic.Data.EF;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Comics;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Statistics;
using Microsoft.EntityFrameworkCore;

namespace HikiComic.Application.Statistics
{
    public class StatisticsService : IStatisticsService
    {

        private readonly HikiComicDbContext _context;

        public StatisticsService(HikiComicDbContext context)
        {
            _context = context;
        }

        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public async Task<ApiResult<StatisticalCreateComicByMonthViewModel>> StatisticalCreateComicByYear(int year)
        {
            List<string> month = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            List<int> value = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var Comics = await _context.Comics.Where(x => x.DateCreated.Year == year).ToListAsync();

            foreach (var item in Comics)
            {
                value[item.DateCreated.Month - 1]++;
            }

            int maxValueColumn = value.Max(x => x) + (int)(value.Max(x => x) / 12) + 2;

            var statisticalCreateComicByYearViewModel = new StatisticalCreateComicByMonthViewModel()
            {
                Labels = month,
                Data = value,
                ValueMaxColumn = maxValueColumn
            };

            return new ApiSuccessResult<StatisticalCreateComicByMonthViewModel>()
            {
                ResultObj = statisticalCreateComicByYearViewModel,
                Message = MessageConstants.GetObjectSuccess("Create Comic By Year")
            };
        }

        public async Task<ApiResult<StatisticsDashboardViewModel>> StatisticalForDashboard()
        {
            var numberOfUsers = await _context.Users.CountAsync();
            var numberOfComics = await _context.Comics.CountAsync();
            var numberOfChapters = await _context.Chapters.CountAsync();
            var numberOfGenres = await _context.Genres.CountAsync();
            var numberOfAuthors = await _context.Authors.CountAsync();

            var query = (from c in _context.Comics
                         join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                         orderby c.ViewCount descending
                         select new { c, cd }).Take(5);

            var top5Comic = await query.Select(x => new ComicViewModel()
            {
                ComicId = x.c.ComicId,
                ComicName = x.c.ComicName,
                DateCreated = x.c.DateCreated,
                Alternative = x.c.Alternative,
                ViewCount = x.c.ViewCount,
                ComicCoverImageURL = x.c.ComicCoverImageURL,
                NewChapterId = x.c.NewChapterId,
                ComicSEOAlias = x.cd.ComicSEOAlias,
                Rating = x.c.Rating,
                IsDeleted = x.c.IsDeleted
            }).ToListAsync();


            var statisticsDashboardViewModel = new StatisticsDashboardViewModel()
            {
                NumberOfUsers = numberOfUsers,
                NumberOfComics = numberOfComics,
                NumberOfAuthors = numberOfAuthors,
                NumberOfGenres = numberOfGenres,
                NumberOfChapters = numberOfChapters,
                Top5ComicMostViews = top5Comic
            };

            return new ApiSuccessResult<StatisticsDashboardViewModel> { ResultObj = statisticsDashboardViewModel, Message = MessageConstants.GetObjectSuccess("Dashboard") };
        }

        public async Task<ApiResult<StatisticalRegisterUserByMonthViewModel>> StatisticalRegisterUserByYear(int year)
        {
            List<string> month = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            List<int> value = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var users = await _context.Users.Where(x => x.DateCreated.Year == year).ToListAsync();

            foreach (var item in users)
            {
                value[item.DateCreated.Month - 1]++;
            }

            int maxValueColumn = value.Max(x => x) + (int)(value.Max(x => x) / 12) + 2;

            var statisticalRegisterUserByYearViewModel = new StatisticalRegisterUserByMonthViewModel()
            {
                Labels = month,
                Data = value,
                ValueMaxColumn = maxValueColumn
            };

            return new ApiSuccessResult<StatisticalRegisterUserByMonthViewModel>()
            {
                ResultObj = statisticalRegisterUserByYearViewModel,
                Message = MessageConstants.GetObjectSuccess("Register User By Year")
            };
        }

        public async Task<ApiResult<StatisticsDOBUserByAgeViewModel>> StatisticsDOBUserByAge()
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

            var statisticsDOBUserByAgeViewModel = new StatisticsDOBUserByAgeViewModel() { Data = value, Labels = groupAge, Colors = colors };

            return new ApiSuccessResult<StatisticsDOBUserByAgeViewModel>()
            {
                ResultObj = statisticsDOBUserByAgeViewModel,
                Message = MessageConstants.GetObjectSuccess("Statistics DOB User By Age")
            };
        }

        public ApiResult<StatisticsReadComicByDayViewModel> StatisticsReadComicByDay(Guid userId)
        {
            StatisticsReadComicByDayViewModel output = new StatisticsReadComicByDayViewModel();
            output.Lables = new List<string>();
            output.Numbers = new List<int>();

            DateTime endDate = DateTime.Now;
            DateTime startDate = endDate.AddDays(-9);
            List<DateTime> dates = new List<DateTime>();

            var query = from c in _context.UserComicReadingHistories
                        where c.AppUserId == userId && c.DateRead >= startDate && c.DateRead <= endDate
                        select c;

            var history = query.ToList();

            //var history = await _context.HistoryReadComicOfUsers.Where(x => x.AppUserId == userId).ToListAsync();

            foreach (DateTime day in EachDay(startDate, endDate))
            {
                output.Lables.Add(day.ToString("dd/MM"));
                output.Numbers.Add(0);
                dates.Add(day);
            }

            foreach (var item in history)
            {
                if (item.DateRead.Day == dates[0].Day)
                {
                    output.Numbers[0]++;
                }

                if (item.DateRead.Day == dates[1].Day)
                {
                    output.Numbers[1]++;
                }

                if (item.DateRead.Day == dates[2].Day)
                {
                    output.Numbers[2]++;
                }

                if (item.DateRead.Day == dates[3].Day)
                {
                    output.Numbers[3]++;
                }

                if (item.DateRead.Day == dates[4].Day)
                {
                    output.Numbers[4]++;
                }

                if (item.DateRead.Day == dates[5].Day)
                {
                    output.Numbers[5]++;
                }

                if (item.DateRead.Day == dates[6].Day)
                {
                    output.Numbers[6]++;
                }

                if (item.DateRead.Day == dates[7].Day)
                {
                    output.Numbers[7]++;
                }

                if (item.DateRead.Day == dates[8].Day)
                {
                    output.Numbers[8]++;
                }

                if (item.DateRead.Day == dates[9].Day)
                {
                    output.Numbers[9]++;
                }
            }

            return new ApiSuccessResult<StatisticsReadComicByDayViewModel>() { ResultObj = output };
        }
    }
}

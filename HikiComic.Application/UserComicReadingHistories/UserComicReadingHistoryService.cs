using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserComicReadingHistories;
using HikiComic.ViewModels.UserComicReadingHistories.UserComicReadingHistoryDataRequest;
using Microsoft.EntityFrameworkCore;

namespace HikiComic.Application.UserComicReadingHistories
{
    public class UserComicReadingHistoryService : IUserComicReadingHistoryService
    {

        private readonly HikiComicDbContext _context;

        public UserComicReadingHistoryService(HikiComicDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> CreateHistoryReadComicOfUser(CreateUserComicReadingHistoryRequest request, Guid userId)
        {
            var query = from c in _context.Comics
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                        join ct in _context.Chapters on cd.ComicDetailId equals ct.ComicDetailId
                        orderby c.ComicId descending
                        select new { c, cd, ct };

            query = query.Where(p => p.ct.ChapterSEOAlias == request.ChapterSEOAlias && p.cd.ComicSEOAlias == request.ComicSEOAlias);

            var comicReadingHistoryViewModels = await query.Select(x => new ComicReadingHistoryViewModel()
            {
                UserId = userId,
                ChapterId = x.ct.ChapterId,
                ComicId = x.c.ComicId
            }).ToListAsync();

            if (comicReadingHistoryViewModels.Count < 1)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Comic"));

            var historyReadComicOfUser = new UserComicReadingHistory()
            {
                ChapterId = comicReadingHistoryViewModels[0].ChapterId,
                ComicId = comicReadingHistoryViewModels[0].ComicId,
                DateRead = DateTime.Now,
                AppUserId = userId
            };

            await _context.UserComicReadingHistories.AddAsync(historyReadComicOfUser);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.CreateSuccess("History Comic") };
        }

        public async Task<PagedResult<UserComicReadingHistoryViewModel>> PagingHistoryReadComicOfUser(PagingRequestBase request, Guid userId)
        {
            var query = from c in _context.Comics
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                        join s in _context.Statuses on cd.StatusId equals s.StatusId
                        join h in _context.UserComicReadingHistories on c.ComicId equals h.ComicId
                        join cc in _context.Chapters on h.ChapterId equals cc.ChapterId
                        where h.AppUserId == userId
                        orderby h.DateRead descending
                        select new { c, cd, h, cc, s };

            //var fullComics = await query.OrderByDescending(x => x.h.DateRead).ToListAsync();

            var comics = await query.Select(x => new UserComicReadingHistoryViewModel()
            {
                UserComicReadingHistoryId = x.h.UserComicReadingHistoryId,
                ComicId = x.c.ComicId,
                ComicName = x.c.ComicName,
                ViewCount = x.c.ViewCount,
                ComicCoverImageURL = x.c.ComicCoverImageURL,
                ComicSEOAlias = x.cd.ComicSEOAlias,
                Rating = x.c.Rating,
                DateRead = x.h.DateRead,
                ChapterSEOAlias = x.cc.ChapterSEOAlias,
                ChapterName = x.cc.ChapterName,
                Status = ((ComicStatusEnum)x.s.StatusId).ToString()
            }).ToListAsync();

            var newComics = comics.DistinctBy(x => x.ComicId).ToList();

            int totalRow = newComics.Count;

            var data = newComics.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToList();

            var pagedResult = new PagedResult<UserComicReadingHistoryViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
    }
}

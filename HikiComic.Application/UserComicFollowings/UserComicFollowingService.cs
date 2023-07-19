using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Comics;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserComicFollowings.UserComicFollowingDataRequest;
using Microsoft.EntityFrameworkCore;

namespace HikiComic.Application.UserComicFollowings
{
    //tới đây
    public class UserComicFollowingService : IUserComicFollowingService
    {
        private readonly HikiComicDbContext _context;

        public UserComicFollowingService(HikiComicDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> CreateOrDeleteUserComicFollowing(InfoUserComicFollowingRequest request, Guid userId)
        {
            Comic currentComic = new Comic();

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));


            if(request.ComicId != null && request.ComicId > 0)
            {
                var comic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == request.ComicId);

                if (comic is null)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Comic") };

                currentComic = comic;
            }
            else
            {
                var comicDetail = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicSEOAlias == request.ComicSEOAlias);

                if (comicDetail is null)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Comic") };

                var comic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == comicDetail.ComicId);

                if (comic is null)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Comic") };

                currentComic = comic;
            }

            var currentUserComicFollowing = await _context.UserComicFollowings.FirstOrDefaultAsync(x => x.ComicId == currentComic.ComicId && x.AppUserId == userId);

            if (currentUserComicFollowing is null)
            {
                currentComic.CountFollow += 1;

                var userComicFollowing = new UserComicFollowing()
                {
                    ComicId = currentComic.ComicId,
                    AppUserId = userId,
                    DateFollow = DateTime.Now
                };

                await _context.AddAsync(userComicFollowing);
                await _context.SaveChangesAsync();

                return new ApiResult<bool>() { Message = MessageConstants.ComicFollowingSuccess };
            }
            else
            {
                currentComic.CountFollow -= 1;

                _context.UserComicFollowings.Remove(currentUserComicFollowing);
                await _context.SaveChangesAsync();

                return new ApiResult<bool>() { Message = MessageConstants.UnfollowComicSuccess };
            }
        }

        public async Task<PagedResult<ComicViewModel>> GetUserFollowedComics(PagingRequestBase request, Guid userId)
        {
            var query = from c in _context.Comics
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                        join s in _context.Statuses on cd.StatusId equals s.StatusId
                        join uf in _context.UserComicFollowings on c.ComicId equals uf.ComicId
                        where c.IsDeleted == false && uf.AppUserId == userId
                        orderby uf.DateFollow descending
                        select new { c, cd, s };

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ComicViewModel()
                {
                    ComicId = x.c.ComicId,
                    ComicName = x.c.ComicName,
                    Alternative = x.c.Alternative,
                    DateCreated = x.c.DateCreated,
                    ViewCount = x.c.ViewCount,
                    ComicCoverImageURL = x.c.ComicCoverImageURL,
                    NewChapterId = x.c.NewChapterId,
                    ComicSEOAlias = x.cd.ComicSEOAlias,
                    Rating = x.c.Rating,
                    Status = ((ComicStatusEnum)x.s.StatusId).ToString()
                }).ToListAsync();

            var pagedResult = new PagedResult<ComicViewModel>()
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

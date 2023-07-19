using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserComicRatings.UserComicRatingDataRequest;
using Microsoft.EntityFrameworkCore;

namespace HikiComic.Application.UserComicRatings
{
    public class UserComicRatingService : IUserComicRatingService
    {
        private readonly HikiComicDbContext _context;

        public UserComicRatingService(HikiComicDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> CreateUserComicRating(CreateUserComicRatingRequest request, Guid userId)
        {
            Comic currentComic = new Comic();

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

            if (request.ComicId != null && request.ComicId > 0)
            {
                var comic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == request.ComicId);

                if (comic is null)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Comic") };

                currentComic = comic;
            }
            else
            {
                var comicDetail = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicSEOAlias == request.ComicSEOAlias);

                if(comicDetail is null)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Comic") };

                var comic = await _context.Comics.FirstOrDefaultAsync(x => x.ComicId == comicDetail.ComicId);

                if (comic is null)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Comic") };

                currentComic = comic;
            }

            var rating = await _context.UserComicRatings.FirstOrDefaultAsync(x => x.ComicId == currentComic.ComicId && x.AppUserId == userId);

            if(rating is null)
            {
                currentComic.Rating = ((currentComic.CountRating * currentComic.Rating) + request.Rating) / (currentComic.CountRating + 1);
                currentComic.CountRating += 1;

                var userComicRating = new UserComicRating()
                {
                    AppUserId = userId,
                    ComicId = currentComic.ComicId,
                    Rating = request.Rating,
                    DateRating = DateTime.Now
                };

                await _context.UserComicRatings.AddAsync(userComicRating);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>() { Message = MessageConstants.ObjectActionSuccess("Rated Comic") };
            }
            else
            {
                double removeRating = -1;

                if (currentComic.CountRating == 1)
                {
                    removeRating = ((currentComic.CountRating * currentComic.Rating) - rating.Rating);
                }
                else
                {
                    removeRating = ((currentComic.CountRating * currentComic.Rating) - rating.Rating) / (currentComic.CountRating - 1);
                }

                currentComic.Rating = (((currentComic.CountRating - 1) * removeRating) + request.Rating) / (currentComic.CountRating);

                rating.Rating = request.Rating;
                rating.DateRating = DateTime.Now;

                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>() { Message = MessageConstants.ObjectActionSuccess("Changed Comic Rating") };
            }
        }

       
        
    }
}

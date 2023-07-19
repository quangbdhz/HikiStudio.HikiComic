using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserComicRatings.UserComicRatingDataRequest;

namespace HikiComic.Application.UserComicRatings
{
    public interface IUserComicRatingService
    {
        Task<ApiResult<bool>> CreateUserComicRating(CreateUserComicRatingRequest request, Guid userId);

    }
}

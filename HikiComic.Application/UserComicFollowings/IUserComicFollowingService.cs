using HikiComic.ViewModels.Comics;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserComicFollowings.UserComicFollowingDataRequest;

namespace HikiComic.Application.UserComicFollowings
{
    public interface IUserComicFollowingService
    {
        Task<ApiResult<bool>> CreateOrDeleteUserComicFollowing(InfoUserComicFollowingRequest request, Guid userId);

        Task<PagedResult<ComicViewModel>> GetUserFollowedComics(PagingRequestBase request, Guid userId);

    }
}

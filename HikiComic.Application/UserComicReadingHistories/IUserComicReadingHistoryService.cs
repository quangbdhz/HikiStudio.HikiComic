using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserComicReadingHistories;
using HikiComic.ViewModels.UserComicReadingHistories.UserComicReadingHistoryDataRequest;

namespace HikiComic.Application.UserComicReadingHistories
{
    public interface IUserComicReadingHistoryService
    {
        Task<PagedResult<UserComicReadingHistoryViewModel>> PagingHistoryReadComicOfUser(PagingRequestBase request, Guid userId);

        Task<ApiResult<bool>> CreateHistoryReadComicOfUser(CreateUserComicReadingHistoryRequest request, Guid userId);
    }
}

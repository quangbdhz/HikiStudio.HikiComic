using HikiComic.ViewModels.Comics;
using HikiComic.ViewModels.Common;

namespace HikiComic.ApiIntegration.UserComicReadingHistoriesAPIClient
{
    public interface IUserComicReadingHistoryAPIClient
    {
        Task<PagedResult<ComicViewModel>> GetPagingHistoryReadComicOfUsers(PagingRequestBase request);
    }
}

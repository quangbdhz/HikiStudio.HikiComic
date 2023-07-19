using HikiComic.ViewModels.Comics;
using HikiComic.ViewModels.Comics.ComicDataRequest;
using HikiComic.ViewModels.Common;

namespace HikiComic.ApiIntegration.ComicsAPIClient
{
    public interface IComicAPIClient
    {
        Task<PagedResult<ComicViewModel>> GetComicPaging(ComicByGenrePagingRequest request);

        Task<PagingResult<ComicManagementViewModel>> GetPagingManagement(PagingRequest request);

        Task<PagedResult<ComicViewModel>> GetComicPagingUserFollow(PagingRequestBase request);

        Task<ApiResult<int>> CreateComic(CreateComicRequest request);

        Task<ApiResult<int>> CreateComicByCrawling(CreateComicByCrawlingRequest request);

        Task<ApiResult<bool>> UpdateComic(UpdateComicRequest request, int comicId);

        Task<ApiResult<bool>> DeleteComics(DeleteComicRequest request);

        Task<ApiResult<bool>> RestoreDeletedComic(int comicId);

        Task<ApiResult<bool>> ApproveComic(int comicId);

        Task<ApiResult<bool>> RejectComic(int comicId, string feedback);
    }
}

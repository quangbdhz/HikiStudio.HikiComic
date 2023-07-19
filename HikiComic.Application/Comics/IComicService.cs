using HikiComic.ViewModels.Comics;
using HikiComic.ViewModels.Comics.ComicDataRequest;
using HikiComic.ViewModels.Common;

namespace HikiComic.Application.Comics
{
    public interface IComicService
    {
        Task<List<ComicViewModel>> GetRecommendedComic(Guid userId, int numRecommendations);

        Task<PagedResult<ComicViewModel>> GetComicByGenrePaging(ComicByGenrePagingRequest request);

        Task<PagedResult<ComicViewModel>> GetComicByAuthorPaging(ComicByAuthorPagingRequest request);

        Task<PagedResult<ComicViewModel>> GetComicByArtistPaging(ComicByArtistPagingRequest request);

        Task<PagedResult<ComicViewModel>> GetComicByStatusPaging(ComicByStatusPagingRequest request);

        Task<PagedResult<ComicViewModel>> GetComicByCreatorPaging(ComicByCreatorPagingRequest request);

        Task<ComicRankingViewModel> GetComicByRankingComics(int numberOfElement);

        Task<List<ComicViewModel>> GeComicByNewComics(PagingRequestBase request);

        Task<PagingResult<ComicManagementViewModel>> GetPagingManagement(PagingRequest request);

        Task<ApiResult<int>> CreateComic(CreateComicRequest request);

        Task<ApiResult<int>> CreateComicByCrawling(CreateComicByCrawlingRequest request);

        Task<ApiResult<bool>> UpdateComic(UpdateComicRequest request, int comicId);

        Task<ApiResult<bool>> DeleteComic(int comicId);

        Task<ApiResult<bool>> DeleteComics(DeleteComicRequest request);

        Task<ApiResult<bool>> RestoreDeletedComic(int comicId);

        Task<int> AddViewCount(int comicId);

        Task<ApiResult<bool>> ApproveComic(int comicId);

        Task<ApiResult<bool>> RejectComic(int comicId, string feedback);

    }
}

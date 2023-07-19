using HikiComic.ViewModels.ComicDetails;
using HikiComic.ViewModels.ComicDetails.ComicDetailDataRequest;
using HikiComic.ViewModels.Common;

namespace HikiComic.Application.ComicDetails
{
    public interface IComicDetailService
    {
        Task<ApiResult<ComicDetailViewModel>> GetComicDetailByComicId(int comicId);

        Task<ApiResult<ComicDetailViewModel>> GetComicDetailByComicSEOAlias(string comicSEOAlias, bool isManagement = false);

        Task<ApiResult<ComicDetailViewModel>> GetComicDetailByComicId(Guid userId, int comicId);

        Task<ApiResult<ComicDetailViewModel>> GetComicDetailByComicSEOAliasWithUser(Guid userId, string comicSEOAlias);

        Task<ApiResult<bool>> UpdateStatusUserFollowComic(Guid userId, int comicId);

        //Task<ApiResult<bool>> UpdateSummaryComicDetail(UpdateSummaryComicDetailRequest request);
    }
}

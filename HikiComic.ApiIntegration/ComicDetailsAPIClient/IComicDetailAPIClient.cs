using HikiComic.ViewModels.ComicDetails;
using HikiComic.ViewModels.Common;

namespace HikiComic.ApiIntegration.ComicDetailsAPIClient
{
    public interface IComicDetailAPIClient
    {
        Task<ApiResult<ComicDetailViewModel>> GetComicDetailByComicSEOAliasWithAdmin(string comicSEOAlias);

        Task<ApiResult<ComicDetailViewModel>> GetComicDetailByComicSEOAliasWithUser(string comicSEOAlias);
    }
}

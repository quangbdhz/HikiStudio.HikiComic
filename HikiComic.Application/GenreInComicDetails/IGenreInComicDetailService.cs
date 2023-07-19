using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.GenreInComicDetails.GenreInComicDetailDataRequest;

namespace HikiComic.Application.GenreInComicDetails
{
    public interface IGenreInComicDetailService
    {
        Task<int> GetGenreByGenreName(string genreName);

        Task<ApiResult<bool>> CreateGenreInComicDetail(CreateGenreInComicDetailRequest request);

        Task<ApiResult<bool>> DeleteGenreInComicDetail(int genreId, int comicDetailId);
    }
}

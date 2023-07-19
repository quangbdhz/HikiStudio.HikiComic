using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Genres;
using HikiComic.ViewModels.Genres.GenresDataRequest;

namespace HikiComic.ApiIntegration.GenresAPIClient
{
    public interface IGenreAPIClient
    {
        Task<ApiResult<List<GenreViewModel>>> GetAll();

        Task<PagingResult<GenreViewModel>> GetPagingManagement(PagingRequest request);

        Task<ApiResult<GenreViewModel>> GetGenreByGenreId(int genreId);

        Task<ApiResult<GenreViewModel>> GetGenreByGenreSEOAlias(string genreSEOAlias);

        Task<ApiResult<UpdateGenreRequest>> GetGenreByGenreSEOAliasToDoUpdate(string genreSEOAlias);

        Task<ApiResult<int>> CreateGenre(CreateGenreRequest request);

        Task<ApiResult<bool>> UpdateGenre(int genreId, UpdateGenreRequest request);

        Task<ApiResult<bool>> DeleteGenre(DeleteGenreRequest request);

        Task<ApiResult<bool>> RestoreDeletedGenre(int genreId);
    }
}

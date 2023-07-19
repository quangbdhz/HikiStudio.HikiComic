using HikiComic.Application.Base;
using HikiComic.Data.Entities;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Genres;
using HikiComic.ViewModels.Genres.GenresDataRequest;

namespace HikiComic.Application.Genres
{
    public interface IGenreService : IBaseService<Genre>
    {
        Task<ApiResult<List<GenreViewModel>>> GetAll();

        Task<ApiResult<GenreViewModel>> GetGenreByGenreId(int genreId);

        Task<ApiResult<GenreViewModel>> GetGenreByGenreSEOAlias(string genreSEOAlias);

        Task<ApiResult<UpdateGenreRequest>> GetGenreByGenreSEOAliasToDoUpdate(string genreSEOAlias);

        Task<ApiResult<List<GenreViewModel>>> GetGenreShowHome();

        Task<PagingResult<GenreViewModel>> GetPagingManagement(PagingRequest request);

        //Task<ApiResult<bool>> UpdateSummaryGenreDetail(UpdateSummaryGenreDetailRequest request);


        Task<ApiResult<int>> CreateGenre(CreateGenreRequest request);

        Task<ApiResult<bool>> UpdateGenre(UpdateGenreRequest request, int genreId);
    }
}

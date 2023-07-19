using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Genres;
using HikiComic.ViewModels.Genres.GenresDataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.GenresAPIClient
{
    public class GenreAPIClient : BaseAPI, IGenreAPIClient
    {
        public GenreAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<int>> CreateGenre(CreateGenreRequest request)
        {
            return await PostAsync<ApiResult<int>, CreateGenreRequest>(request, "/api/genres/create");
        }

        public async Task<ApiResult<bool>> DeleteGenre(DeleteGenreRequest request)
        {
            return await PostAsync<ApiResult<bool>, DeleteGenreRequest>(request, $"/api/genres/delete-multiple");
        }

        public async Task<PagingResult<GenreViewModel>> GetPagingManagement(PagingRequest request)
        {
            return await PostAsync<PagingResult<GenreViewModel>, PagingRequest>(request, $"/api/genres/paging-management");
        }

        public async Task<ApiResult<GenreViewModel>> GetGenreByGenreId(int genreId)
        {
            return await GetAsync<ApiResult<GenreViewModel>>($"/api/genres/get-genre-by-genre-id/{genreId}");
        }

        public async Task<ApiResult<GenreViewModel>> GetGenreByGenreSEOAlias(string genreSEOAlias)
        {
            return await GetAsync<ApiResult<GenreViewModel>>($"/api/genres/get-genre-by-genre-seo-alias/{genreSEOAlias}");
        }

        public async Task<ApiResult<UpdateGenreRequest>> GetGenreByGenreSEOAliasToDoUpdate(string genreSEOAlias)
        {
            return await GetAsync<ApiResult<UpdateGenreRequest>>($"/api/genres/get-by-seo-alias-genre-to-do-update/{genreSEOAlias}");
        }

        public async Task<ApiResult<bool>> RestoreDeletedGenre(int genreId)
        {
            return await PostAsync<ApiResult<bool>, int>(genreId, $"/api/genres/restore");
        }

        public async Task<ApiResult<bool>> UpdateGenre(int genreId, UpdateGenreRequest request)
        {
            return await PutAsync<ApiResult<bool>, UpdateGenreRequest>(request, $"/api/genres/update/{genreId}");
        }

        public async Task<ApiResult<List<GenreViewModel>>> GetAll()
        {
            return await GetAsync<ApiResult<List<GenreViewModel>>>($"/api/genres/get-all");
        }
    }
}

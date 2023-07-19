using HikiComic.ViewModels.Artists;
using HikiComic.ViewModels.Artists.ArtistDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.ArtistsAPIClient
{
    public class ArtistAPIClient : BaseAPI, IArtistAPIClient
    {
        public ArtistAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<int>> CreateArtist(CreateArtistRequest request)
        {
            return await PostAsync<ApiResult<int>, CreateArtistRequest>(request, "/api/artists/create");
        }

        public async Task<ApiResult<bool>> DeleteArtist(int artistId)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/artists/delete/{artistId}");
        }

        public async Task<ApiResult<bool>> DeleteArtists(DeleteArtistsRequest request)
        {
            return await PostAsync<ApiResult<bool>, DeleteArtistsRequest>(request, $"/api/artists/delete-multiple");
        }

        public async Task<ApiResult<List<ArtistViewModel>>> GetAll()
        {
            return await GetAsync<ApiResult<List<ArtistViewModel>>>($"/api/artists/get-all");
        }

        public async Task<ApiResult<ArtistViewModel>> GetArtistByArtistId(int artistId)
        {
            return await GetAsync<ApiResult<ArtistViewModel>>($"/api/artists/get-artist-by-artist-id/{artistId}");
        }

        public async Task<ApiResult<ArtistViewModel>> GetArtistByArtistSEOAlias(string artistSEOAlias)
        {
            return await GetAsync<ApiResult<ArtistViewModel>>($"/api/artists/get-artist-by-artist-seo-alias/{artistSEOAlias}");
        }

        public async Task<PagingResult<ArtistViewModel>> GetPagingManagement(PagingRequest request)
        {
            return await PostAsync<PagingResult<ArtistViewModel>, PagingRequest>(request, $"/api/artists/paging-management");
        }

        public async Task<ApiResult<bool>> RestoreDeletedArtist(int artistId)
        {
            return await PostAsync<ApiResult<bool>, int>(artistId, $"/api/artists/restore");
        }

        public async Task<ApiResult<bool>> UpdateArtist(int artistId, UpdateArtistRequest request)
        {
            return await PutAsync<ApiResult<bool>, UpdateArtistRequest>(request, $"/api/artists/update/{artistId}");
        }
    }
}

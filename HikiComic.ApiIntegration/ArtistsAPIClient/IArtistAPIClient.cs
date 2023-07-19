using HikiComic.ViewModels.Artists;
using HikiComic.ViewModels.Artists.ArtistDataRequest;
using HikiComic.ViewModels.Common;

namespace HikiComic.ApiIntegration.ArtistsAPIClient
{
    public interface IArtistAPIClient
    {
        Task<ApiResult<List<ArtistViewModel>>> GetAll();

        Task<PagingResult<ArtistViewModel>> GetPagingManagement(PagingRequest request);

        Task<ApiResult<ArtistViewModel>> GetArtistByArtistSEOAlias(string artistSEOAlias);

        Task<ApiResult<ArtistViewModel>> GetArtistByArtistId(int artistId);

        Task<ApiResult<int>> CreateArtist(CreateArtistRequest request);

        Task<ApiResult<bool>> UpdateArtist(int artistId, UpdateArtistRequest request);

        Task<ApiResult<bool>> DeleteArtist(int artistId);

        Task<ApiResult<bool>> DeleteArtists(DeleteArtistsRequest request);

        Task<ApiResult<bool>> RestoreDeletedArtist(int artistId);
    }
}

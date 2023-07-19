using HikiComic.Application.Base;
using HikiComic.Data.Entities;
using HikiComic.ViewModels.Artists;
using HikiComic.ViewModels.Common;

namespace HikiComic.Application.Artists
{
    public interface IArtistService : IBaseService<Artist>
    {
        Task<ApiResult<List<ArtistViewModel>>> GetAll();

        Task<PagingResult<ArtistViewModel>> GetPagingManagement(PagingRequest request);

        Task<ApiResult<ArtistViewModel>> GetArtistByArtistSEOAlias(string artistSEOAlias);

        Task<ApiResult<ArtistViewModel>> GetArtistByArtistId(int artistId);
    }
}

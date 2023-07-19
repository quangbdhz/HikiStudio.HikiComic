using HikiComic.ViewModels.Comics;
using HikiComic.ViewModels.Comics.ComicDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.ComicsAPIClient
{
    public class ComicAPIClient : BaseAPI, IComicAPIClient
    {
        public ComicAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<int>> CreateComic(CreateComicRequest request)
        {
            return await PostAsync<ApiResult<int>, CreateComicRequest>(request, "/api/comics/create");
        }

        public async Task<ApiResult<int>> CreateComicByCrawling(CreateComicByCrawlingRequest request)
        {
            return await PostAsync<ApiResult<int>, CreateComicByCrawlingRequest>(request, "/api/comics/create-comic-by-crawling");
        }

        public async Task<ApiResult<bool>> DeleteComics(DeleteComicRequest request)
        {
            return await PostAsync<ApiResult<bool>, DeleteComicRequest>(request, "/api/comics/delete-multiple");
        }

        public async Task<PagedResult<ComicViewModel>> GetComicPaging(ComicByGenrePagingRequest request)
        {
            return await GetAsync<PagedResult<ComicViewModel>>($"/api/comics/paging?pageindex={request.PageIndex}" +
                $"&pagesize={request.PageSize}" +
                $"&keyword={request.Keyword}&genreId={request.GenreId}");
        }

        public async Task<PagingResult<ComicManagementViewModel>> GetPagingManagement(PagingRequest request)
        {
            return await PostAsync<PagingResult<ComicManagementViewModel>, PagingRequest>(request, $"/api/comics/paging-management");
        }

        public async Task<PagedResult<ComicViewModel>> GetComicPagingUserFollow(PagingRequestBase request)
        {
            return await GetAsync<PagedResult<ComicViewModel>>($"/api/comics/paging-user-follow?pageindex={request.PageIndex}" +
                $"&pagesize={request.PageSize}");
        }

        public async Task<ApiResult<bool>> UpdateComic(UpdateComicRequest request, int comicId)
        {
            return await PutAsync<ApiResult<bool>, UpdateComicRequest>(request, $"/api/comics/update/{comicId}");
        }

        public async Task<ApiResult<bool>> RestoreDeletedComic(int comicId)
        {
            return await PostAsync<ApiResult<bool>, int>(comicId, $"/api/comics/restore");
        }

        public async Task<ApiResult<bool>> ApproveComic(int comicId)
        {
            return await PostAsync<ApiResult<bool>, int>(comicId, $"/api/comics/approve-comic");
        }

        public async Task<ApiResult<bool>> RejectComic(int comicId, string feedback)
        {
            return await PostAsync<ApiResult<bool>, string>(feedback, $"/api/comics/reject-comic/{comicId}");
        }
    }
}

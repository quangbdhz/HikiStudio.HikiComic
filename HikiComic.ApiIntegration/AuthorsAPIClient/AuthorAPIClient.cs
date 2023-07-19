using HikiComic.ViewModels.Authors;
using HikiComic.ViewModels.Authors.AuthorDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.AuthorsAPIClient
{
    public class AuthorAPIClient : BaseAPI, IAuthorAPIClient
    {
        public AuthorAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<int>> CreateAuthor(CreateAuthorRequest request)
        {
            return await PostAsync<ApiResult<int>, CreateAuthorRequest>(request, "/api/authors/create");
        }

        public async Task<ApiResult<bool>> DeleteAuthor(int authorId)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/authors/delete/{authorId}");
        }

        public async Task<ApiResult<bool>> DeleteAuthors(DeleteAuthorsRequest request)
        {
            return await PostAsync<ApiResult<bool>, DeleteAuthorsRequest>(request, $"/api/authors/delete-multiple");
        }

        public async Task<PagingResult<AuthorViewModel>> GetPagingManagement(PagingRequest request)
        {
            return await PostAsync<PagingResult<AuthorViewModel>, PagingRequest>(request, $"/api/authors/paging-management");
        }

        public async Task<ApiResult<AuthorViewModel>> GetAuthorByAuthorId(int authorId)
        {
            return await GetAsync<ApiResult<AuthorViewModel>>($"/api/authors/get-author-by-author-id/{authorId}");
        }

        public async Task<ApiResult<AuthorViewModel>> GetAuthorByAuthorSEOAlias(string authorSEOAlias)
        {
            return await GetAsync<ApiResult<AuthorViewModel>>($"/api/authors/get-author-by-author-seo-alias/{authorSEOAlias}");
        }

        public async Task<ApiResult<bool>> RestoreDeletedAuthor(int authorId)
        {
            return await PostAsync<ApiResult<bool>, int>(authorId, $"/api/authors/restore");
        }

        public async Task<ApiResult<bool>> UpdateAuthor(int authorId, UpdateAuthorRequest request)
        {
            return await PutAsync<ApiResult<bool>, UpdateAuthorRequest>(request, $"/api/authors/update/{authorId}");
        }

        public async Task<ApiResult<List<AuthorViewModel>>> GetAll()
        {
            return await GetAsync<ApiResult<List<AuthorViewModel>>>($"/api/authors/get-all");
        }
    }
}

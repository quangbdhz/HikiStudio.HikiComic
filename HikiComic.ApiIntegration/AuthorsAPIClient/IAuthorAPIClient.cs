using HikiComic.ViewModels.Authors;
using HikiComic.ViewModels.Authors.AuthorDataRequest;
using HikiComic.ViewModels.Common;

namespace HikiComic.ApiIntegration.AuthorsAPIClient
{
    public interface IAuthorAPIClient
    {
        Task<ApiResult<List<AuthorViewModel>>> GetAll();

        Task<PagingResult<AuthorViewModel>> GetPagingManagement(PagingRequest request);

        Task<ApiResult<AuthorViewModel>> GetAuthorByAuthorSEOAlias(string authorSEOAlias);

        Task<ApiResult<AuthorViewModel>> GetAuthorByAuthorId(int authorId);

        Task<ApiResult<int>> CreateAuthor(CreateAuthorRequest request);

        Task<ApiResult<bool>> UpdateAuthor(int authorId, UpdateAuthorRequest request);

        Task<ApiResult<bool>> DeleteAuthor(int authorId);

        Task<ApiResult<bool>> DeleteAuthors(DeleteAuthorsRequest request);

        Task<ApiResult<bool>> RestoreDeletedAuthor(int authorId);
    }
}

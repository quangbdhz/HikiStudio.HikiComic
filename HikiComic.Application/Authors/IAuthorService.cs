using HikiComic.Application.Base;
using HikiComic.Data.Entities;
using HikiComic.ViewModels.Authors;
using HikiComic.ViewModels.Common;

namespace HikiComic.Application.Authors
{
    public interface IAuthorService : IBaseService<Author>
    {
        Task<ApiResult<List<AuthorViewModel>>> GetAll();

        Task<PagingResult<AuthorViewModel>> GetPagingManagement(PagingRequest request);

        Task<ApiResult<AuthorViewModel>> GetAuthorByAuthorSEOAlias(string authorSEOAlias);

        Task<ApiResult<AuthorViewModel>> GetAuthorByAuthorId(int authorId);

    }
}

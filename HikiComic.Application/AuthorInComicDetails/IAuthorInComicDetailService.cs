using HikiComic.ViewModels.AuthorInComicDetails.AuthorInComicDetailRequest;
using HikiComic.ViewModels.Common;

namespace HikiComic.Application.AuthorInComicDetails
{
    public interface IAuthorInComicDetailService
    {
        Task<ApiResult<bool>> CreateAuthorInComicDetail(CreateAuthorInComicDetailRequest request);

        Task<ApiResult<bool>> DeleteAuthorInComicDetail(int authorId, int comicDetailId);
    }
}

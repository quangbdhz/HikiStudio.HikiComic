using HikiComic.ViewModels.Comments;
using HikiComic.ViewModels.Comments.CommentDataRequest;
using HikiComic.ViewModels.Common;

namespace HikiComic.ApiIntegration.CommentsAPIClient
{
    public interface ICommentAPIClient
    {
        Task<PagedResult<CommentViewModel>> GetPaging(CommentPagingRequest request);

        Task<PagingResult<UserCommentViewModel>> GetPagingOfUser(Guid userId, PagingRequest request);

        Task<PagedResult<CommentViewModel>> GetPagingManagement(CommentPagingRequest request);

        Task<ApiResult<UserCommentViewModel>> GetCommentByCommentId(int commentId);

        Task<ApiResult<CommentViewModel>> CreateComment(CreateCommentRequest request);

        Task<ApiResult<int>> UserDeleteComment(int commentId);

        Task<ApiResult<bool>> DeleteComment(int commentId);

        Task<ApiResult<bool>> DeleteComments(DeleteCommentsRequest request);

        Task<ApiResult<bool>> RestoreDeletedComment(int commentId);

    }
}

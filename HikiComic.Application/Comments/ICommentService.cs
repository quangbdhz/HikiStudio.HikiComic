using HikiComic.ViewModels.Comments;
using HikiComic.ViewModels.Comments.CommentDataRequest;
using HikiComic.ViewModels.Common;

namespace HikiComic.Application.Comments
{
    public interface ICommentService
    {
        Task<PagedResult<CommentViewModel>> GetPaging(CommentPagingRequest request);

        Task<PagingResult<UserCommentViewModel>> GetPagingOfUser(Guid userId, PagingRequest request);

        PagingResult<CommentViewModel> GetPagingManagement(CommentPagingManagementRequest request);

        Task<ApiResult<UserCommentViewModel>> GetCommentByCommentId(int commentId);

        Task<ApiResult<CommentViewModel>> CreateComment(Guid userId, CreateCommentRequest request);

        Task<ApiResult<int>> UserDeleteComment(Guid userId, int commentId);

        Task<ApiResult<bool>> DeleteComment(int commentId);

        Task<ApiResult<bool>> DeleteComments(DeleteCommentsRequest request);

        Task<ApiResult<bool>> RestoreDeletedComment(int commentId);

        //Task<ApiResult<int>> AdminDeleteComment(int commentId);
    }
}

using HikiComic.ViewModels.Comments;
using HikiComic.ViewModels.Comments.CommentDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HikiComic.ApiIntegration.CommentsAPIClient
{
    public class CommentAPIClient : BaseAPI, ICommentAPIClient
    {
        public CommentAPIClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<int>> AdminDeleteComment(int commentId)
        {
            return await DeleteAsync<ApiResult<int>>($"/api/comments/admin-delete/{commentId}");
        }

        public Task<ApiResult<CommentViewModel>> CreateComment(CreateCommentRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<int>> UserDeleteComment(int commentId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<UserCommentViewModel>> GetCommentByCommentId(int commentId)
        {
            return await GetAsync<ApiResult<UserCommentViewModel>>($"/api/comments/get-comment-by-comment-id/{commentId}");
        }

        public async Task<PagedResult<CommentViewModel>> GetPaging(CommentPagingRequest request)
        {
            return await PostAsync<PagedResult<CommentViewModel>, CommentPagingRequest>(request, $"/api/comments/paging");
        }

        public async Task<PagedResult<CommentViewModel>> GetPagingManagement(CommentPagingRequest request)
        {
            if (request.ChapterId == 0 || request.ChapterId is null)
            {
                return await GetAsync<PagedResult<CommentViewModel>>($"/api/comments/paging-management?comicId={request.ComicId}&pageindex={request.PageIndex}&pagesize={request.PageSize}");
            }
            else
            {
                return await GetAsync<PagedResult<CommentViewModel>>($"/api/comments/paging-management?comicId={request.ComicId}&chapterid={request.ChapterId}&pageindex={request.PageIndex}" +
                    $"&pagesize={request.PageSize}");
            }
        }

        public async Task<PagingResult<UserCommentViewModel>> GetPagingOfUser(Guid userId, PagingRequest request)
        {
            return await PostAsync<PagingResult<UserCommentViewModel>, PagingRequest>(request, $"/api/comments/paging-of-user/{userId}");
        }

        public async Task<ApiResult<bool>> DeleteComment(int commentId)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/comments/delete/{commentId}");
        }

        public async Task<ApiResult<bool>> DeleteComments(DeleteCommentsRequest request)
        {
            return await PostAsync<ApiResult<bool>, DeleteCommentsRequest>(request, $"/api/comments/delete-multiple");
        }

        public async Task<ApiResult<bool>> RestoreDeletedComment(int commentId)
        {
            return await PostAsync<ApiResult<bool>, int>(commentId, $"/api/comments/restore");
        }
    }
}

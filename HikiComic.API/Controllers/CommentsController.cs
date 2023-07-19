using HikiComic.Application.Comments;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Artists.ArtistDataRequest;
using HikiComic.ViewModels.Comments;
using HikiComic.ViewModels.Comments.CommentDataRequest;
using HikiComic.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HikiComic.API.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPaging([FromBody] CommentPagingRequest request)
        {
            var comments = await _commentService.GetPaging(request);
            return Ok(comments);
        }

        [HttpPost("paging-management")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public IActionResult GetPagingManagement([FromBody] CommentPagingManagementRequest request)
        {
            var comments = _commentService.GetPagingManagement(request);
            return Ok(comments);
        }

        [HttpPost("paging-of-user/{userId}")]
        public async Task<IActionResult> GetPagingOfUser([FromBody] PagingRequest request, Guid userId)
        {
            var comments = await _commentService.GetPagingOfUser(userId, request);
            return Ok(comments);
        }

        [HttpGet("get-comment-by-comment-id/{commentId}")]
        public async Task<IActionResult> GetCommentByCommentId(int commentId)
        {
            var comments = await _commentService.GetCommentByCommentId(commentId);
            return Ok(comments);
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentRequest request)
        {
            if (String.IsNullOrEmpty(request.CommentContent))
                return BadRequest(new ApiErrorResult<CommentViewModel>("Comment Content is required"));

            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest(new ApiErrorResult<CommentViewModel>(MessageConstants.UserIsNotLogin));

            Guid userId = new Guid(getClaimUserId);

            var result = await _commentService.CreateComment(userId, request);
            return Ok(result);
        }

        [HttpDelete("user-delete/{commentId}")]
        [Authorize]
        public async Task<IActionResult> UserDeleteComment(int commentId)
        {
            var getClaimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(getClaimUserId))
                return BadRequest(new ApiErrorResult<CommentViewModel>(MessageConstants.UserIsNotLogin));

            Guid userId = new Guid(getClaimUserId);

            var result = await _commentService.UserDeleteComment(userId, commentId);
            return Ok(result);
        }

        [HttpDelete("delete/{commentId}")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var result = await _commentService.DeleteComment(commentId);

            return Ok(result);
        }

        [HttpPost("delete-multiple")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> DeleteComments([FromBody] DeleteCommentsRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiErrorResult<bool>(MessageConstants.ModelStateIsNotValid("Delete Comments")));

            return Ok(await _commentService.DeleteComments(request));
        }

        [HttpPost("restore")]
        [Authorize(Policy = SystemConstants.AppSettings.AdminOrTeamMembersPolicy)]
        public async Task<IActionResult> RestoreDeletedComment([FromBody] int commentId)
        {
            var result = await _commentService.RestoreDeletedComment(commentId);

            return Ok(result);
        }

        //[HttpDelete("admin-delete/{commentId}")]
        //[Authorize(Roles = "admin")]
        //public async Task<IActionResult> AdminDeleteComment(int commentId)
        //{
        //    var result = await _commentService.AdminDeleteComment(commentId);
        //    return Ok(result);
        //}
    }
}

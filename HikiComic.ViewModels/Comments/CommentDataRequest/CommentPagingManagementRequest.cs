using HikiComic.ViewModels.Common;

namespace HikiComic.ViewModels.Comments.CommentDataRequest
{
    public class CommentPagingManagementRequest : PagingRequest
    {
        public Guid AppUserId { get; set; }
    }
}

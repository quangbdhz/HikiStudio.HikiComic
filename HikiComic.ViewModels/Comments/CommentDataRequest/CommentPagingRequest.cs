using HikiComic.ViewModels.Common;

namespace HikiComic.ViewModels.Comments.CommentDataRequest
{
    public class CommentPagingRequest : PagingRequestBase
    {
        public int ComicId { get; set; }

        public int? ChapterId { get; set; }
    }
}

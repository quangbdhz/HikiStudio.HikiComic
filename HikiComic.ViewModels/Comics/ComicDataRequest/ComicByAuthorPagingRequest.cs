using HikiComic.ViewModels.Common;

namespace HikiComic.ViewModels.Comics.ComicDataRequest
{
    public class ComicByAuthorPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }

        public int? AuthorId { get; set; }
    }
}

using HikiComic.ViewModels.Common;

namespace HikiComic.ViewModels.Comics.ComicDataRequest
{
    public class ComicByStatusPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }

        public int? StatusId { get; set; }
    }
}

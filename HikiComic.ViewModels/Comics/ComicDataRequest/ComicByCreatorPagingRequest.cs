using HikiComic.ViewModels.Common;

namespace HikiComic.ViewModels.Comics.ComicDataRequest
{
    public class ComicByCreatorPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
    }
}

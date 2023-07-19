using HikiComic.ViewModels.Common;

namespace HikiComic.ViewModels.Comics.ComicDataRequest
{
    public class ComicByGenrePagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }

        public int? GenreId { get; set; }
    }
}

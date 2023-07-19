using HikiComic.ViewModels.Common;

namespace HikiComic.ViewModels.Comics.ComicDataRequest
{
    public class ComicByArtistPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }

        public int? ArtistId { get; set; }
    }
}

using System.ComponentModel;

namespace HikiComic.ViewModels.ComicDetails.ComicDetailDataRequest
{
    public class UpdateSummaryComicDetailRequest
    {
        public int ComicDetailId { get; set; }

        public string Summary { get; set; } = null!;
    }
}

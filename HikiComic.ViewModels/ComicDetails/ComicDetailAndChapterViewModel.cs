using HikiComic.ViewModels.Chapters;

namespace HikiComic.ViewModels.ComicDetails
{
    public class ComicDetailAndChapterViewModel
    {
        public ComicDetailViewModel ComicDetailViewModel { get; set; }

        public IList<ChapterViewModel> Chapters { get; set; }

        //public PagedResult<CommentViewModel> PagingComments { get; set; }
    }
}

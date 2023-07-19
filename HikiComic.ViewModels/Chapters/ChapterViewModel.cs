using HikiComic.ViewModels.Base;

namespace HikiComic.ViewModels.Chapters
{
    public class ChapterViewModel : BaseViewModel<Guid>, IEquatable<ChapterViewModel>
    {
        public int ChapterId { get; set; }

        public int ComicDetailId { get; set; }


        public string ChapterName { get; set; } = null!;

        public int SerialChapterOfComic { get; set; }

        public int ViewCount { get; set; }


        public string ComicSEOAlias { get; set; } = null!;

        public string ChapterSEOAlias { get; set; } = null!;


        public bool IsLockedChapter { get; set; } = true;


        public bool Equals(ChapterViewModel? other)
        {
            if (other == null) return false;

            return (this.ChapterId == other.ChapterId && this.ComicDetailId == other.ComicDetailId);
        }

        public override int GetHashCode()
        {
            return (this.ChapterId.ToString() + this.ComicDetailId.ToString()).GetHashCode();
        }
    }
}

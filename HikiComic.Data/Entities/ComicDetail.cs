using HikiComic.Data.Entities.Base.Entities;

namespace HikiComic.Data.Entities
{
    public class ComicDetail : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int ComicDetailId { get; set; }

        public int ComicId { get; set; }

        public int StatusId { get; set; }


        public string? ComicDetailCoverImageURL { get; set; }

        public string Summary { get; set; } = null!;


        public string? ComicSEOSummary { get; set; }

        public string? ComicSEOTitle { get; set; }

        public string ComicSEOAlias { get; set; } = null!;


        public Comic Comic { get; set; }

        public Status Status { get; set; }


        public List<Chapter> Chapters { get; set; }

        public List<AuthorInComicDetail> AuthorInComicDetails { get; set; }

        public List<ArtistInComicDetail> ArtistInComicDetails { get; set; }

        public List<GenreInComicDetail> GenreInComicDetails { get; set; }
    }
}

using HikiComic.Data.Entities.Base.Entities;

namespace HikiComic.Data.Entities
{
    public class Author : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int AuthorId { get; set; }


        public string AuthorName { get; set; } = null!;

        public string? Alternative { get; set; }

        public string Summary { get; set; } = null!;


        public string? AuthorSEOSummary { get; set; }

        public string? AuthorSEOTitle { get; set; }

        public string AuthorSEOAlias { get; set; } = null!;


        public List<AuthorInComicDetail> AuthorInComicDetails { get; set; }
    }
}

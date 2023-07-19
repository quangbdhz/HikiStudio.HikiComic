using System.ComponentModel;

namespace HikiComic.ViewModels.Authors.AuthorDataRequest
{
    public class CreateAuthorRequest
    {
        public string AuthorName { get; set; } = null!;

        public string? Alternative { get; set; }

        public string Summary { get; set; } = null!;

        public string? AuthorSEOSummary { get; set; }

        public string? AuthorSEOTitle { get; set; }

    }
}

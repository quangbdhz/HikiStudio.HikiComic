using HikiComic.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace HikiComic.ViewModels.Authors
{
    public class AuthorViewModel : BaseViewModel<Guid>
    {
        public int AuthorId { get; set; }


        public string AuthorName { get; set; } = null!;

        public string? Alternative { get; set; }

        public string Summary { get; set; } = null!;


        public string? AuthorSEOSummary { get; set; }

        public string? AuthorSEOTitle { get; set; }

        public string AuthorSEOAlias { get; set; } = null!;

    }
}

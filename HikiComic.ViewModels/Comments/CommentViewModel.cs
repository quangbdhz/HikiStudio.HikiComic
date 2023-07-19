using System.Text.Json.Serialization;

namespace HikiComic.ViewModels.Comments
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }

        public int? ParentCommentId { get; set; }

        public DateTime DateCreated { get; set; }

        public string StringDateCreated
        {
            get
            {
                return DateCreated.ToString("hh:mm tt dd/MM/yyyy");
            }
        }

        public Guid AppUserId { get; set; }

        public string UserName { get; set; }

        public bool UserIsVerified { get; set; }

        public string? URLImageUser { get; set; }

        public int ComicId { get; set; }

        public int? ChapterId { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }

        public string CommentContent { get; set; }

        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public virtual CommentViewModel ParentComment { get; set; }

        public virtual ICollection<CommentViewModel> ChildComments { get; set; }
    }
}

namespace HikiComic.ViewModels.Comments
{
    public class UserCommentViewModel
    {
        public int ComicId { get; set; }

        public int? ChapterId { get; set; }

        public int CommentId { get; set; }

        public string ComicName { get; set; }

        public string ComicSEOAlias { get; set; }

        public string CommentContent { get; set; }

        public DateTime DateCreated { get; set; }

        public string StringDateCreated
        {
            get
            {
                return DateCreated.ToString("hh:mm tt dd/MM/yyyy");
            }
        }

        public int Like { get; set; }

        public int Dislike { get; set; }

        public bool IsDeleted { get; set; }
    }
}

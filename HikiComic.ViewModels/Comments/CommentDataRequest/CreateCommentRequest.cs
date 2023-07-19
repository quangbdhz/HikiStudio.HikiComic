namespace HikiComic.ViewModels.Comments.CommentDataRequest
{
    public class CreateCommentRequest
    {
        public int ComicId { get; set; }

        public int? ChapterId { get; set; }

        public int? ParentCommentId { get; set; }

        public string CommentContent { get; set; }
    }
}

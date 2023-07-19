using HikiComic.Data.Entities.Base.Entities;
using System.Text.Json.Serialization;

namespace HikiComic.Data.Entities
{
    public class Comment : EntitySoftDeletableWithCreatedDate
    {
        public int CommentId { get; set; }

        public int ComicId { get; set; }

        public int? ChapterId { get; set; }

        public Guid AppUserId { get; set; }

        public int? ParentCommentId { get; set; }


        public int Like { get; set; }

        public int Dislike { get; set; }

        public string CommentContent { get; set; }


        public AppUser AppUser { get; set; }

        public Comic Comic { get; set; }

        [JsonIgnore]
        public virtual Comment ParentComment { get; set; }

        public virtual ICollection<Comment> ChildComments { get; set; }
    }
}

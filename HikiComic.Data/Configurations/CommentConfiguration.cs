using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class CommentConfiguration : EntityTypeConfigurationBase<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);

            builder.ToTable("Comments");

            builder.HasKey(x => x.CommentId);
            builder.Property(x => x.CommentId).UseIdentityColumn();

            builder.Property(x => x.DateCreated).IsRequired(true).HasDefaultValue(DateTime.Now);

            builder.Property(x => x.Like).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.Dislike).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.CommentContent).IsUnicode(true).HasMaxLength(2500).IsRequired(true);

            builder.Property(x => x.ChapterId).IsRequired(false);

            builder.Property(x => x.ParentCommentId).IsRequired(false);

            builder.Property(x => x.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Comments).HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.Comic).WithMany(x => x.Comments).HasForeignKey(x => x.ComicId);

            builder.HasOne(c => c.ParentComment).WithMany(c => c.ChildComments).HasForeignKey(c => c.ParentCommentId);
        }
    }
}

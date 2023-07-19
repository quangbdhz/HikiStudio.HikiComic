using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class ChapterConfiguration : EntityTypeConfigurationBase<Chapter>
    {
        public override void Configure(EntityTypeBuilder<Chapter> builder)
        {
            base.Configure(builder);

            builder.ToTable("Chapters");

            builder.HasKey(x => x.ChapterId);
            builder.Property(x => x.ChapterId).UseIdentityColumn();

            builder.Property(x => x.ChapterName).HasMaxLength(100).IsRequired(true);

            builder.Property(x => x.SerialChapterOfComic).IsRequired(true).HasDefaultValue(-1);

            builder.Property(x => x.ViewCount).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.ComicSEOAlias).IsRequired(true).IsUnicode(false).HasMaxLength(300);
            //builder.HasIndex(x => x.ComicSEOAlias).IsUnique(true).HasDatabaseName("ComicSEOAliasIndex");

            builder.Property(x => x.ChapterSEOAlias).IsRequired(true).IsUnicode(true).HasMaxLength(300);
            //builder.HasIndex(x => x.ChapterSEOAlias).IsUnique(true).HasDatabaseName("ChapterSEOAliasIndex");

            builder.HasOne(x => x.ComicDetail).WithMany(x => x.Chapters).HasForeignKey(x => x.ComicDetailId);

            builder.Property(x => x.ApprovalStatus).IsRequired(true);

            builder.Property(x => x.UserIdApproved).IsRequired(false);

            builder.Property(x => x.DateApproved).IsRequired(false);
        }
    }
}

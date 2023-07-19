using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class ComicConfiguration : EntityTypeConfigurationBase<Comic>
    {
        public override void Configure(EntityTypeBuilder<Comic> builder)
        {
            base.Configure(builder);

            builder.ToTable("Comics");

            builder.HasKey(x => x.ComicId);
            builder.Property(x => x.ComicId).UseIdentityColumn();

            builder.Property(x => x.ComicName).IsRequired(true).HasMaxLength(200);

            builder.Property(x => x.Alternative).IsRequired(false).HasMaxLength(200);

            builder.Property(x => x.ViewCount).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.CountFollow).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.CountRating).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.Rating).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.ComicCoverImageURL).IsRequired(true).IsUnicode(false).HasMaxLength(300);

            builder.Property(x => x.NewChapterId).IsRequired(false);

            builder.Property(x => x.ApprovalStatus).IsRequired(true);

            builder.Property(x => x.UserIdApproved).IsRequired(false);

            builder.Property(x => x.DateApproved).IsRequired(false);
        }
    }
}

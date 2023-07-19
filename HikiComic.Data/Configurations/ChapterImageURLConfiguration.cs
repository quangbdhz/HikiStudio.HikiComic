using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class ChapterImageURLConfiguration : EntityTypeConfigurationBase<ChapterImageURL>
    {
        public override void Configure(EntityTypeBuilder<ChapterImageURL> builder)
        {
            base.Configure(builder);

            builder.ToTable("ChapterImageURLs");

            builder.HasKey(x => x.ChapterImageURLId);
            builder.Property(x => x.ChapterImageURLId).UseIdentityColumn();

            builder.Property(x => x.ImageURL).IsUnicode(false).IsRequired(true).HasMaxLength(7800);

            builder.Property(x => x.SerialImageURLOfChapter).IsRequired(true).HasDefaultValue(0);

            builder.HasOne(x => x.Chapter).WithMany(x => x.ChapterImageURLs).HasForeignKey(x => x.ChapterId);
        }
    }
}

using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class ComicDetailConfiguration : EntityTypeConfigurationBase<ComicDetail>
    {
        public override void Configure(EntityTypeBuilder<ComicDetail> builder)
        {
            base.Configure(builder);

            builder.ToTable("ComicDetails");

            builder.HasKey(x => x.ComicDetailId);
            builder.Property(x => x.ComicDetailId).UseIdentityColumn();

            builder.Property(x => x.Summary).IsRequired(true).HasMaxLength(3800);

            builder.Property(x => x.ComicSEOSummary).IsRequired(false).HasMaxLength(1000);

            builder.Property(x => x.ComicSEOTitle).IsRequired(false).HasMaxLength(200);

            builder.Property(x => x.ComicSEOAlias).IsRequired(true).HasMaxLength(200).IsUnicode(true);

            builder.Property(x => x.ComicDetailCoverImageURL).IsRequired(false).HasMaxLength(1000);
            //builder.HasIndex(x => x.ComicSEOAlias).IsUnique(true).HasDatabaseName("ComicSEOAliasIndex"); // Create non-clustered index on ComicSEOAlias with a name

            builder.HasOne(x => x.Comic).WithOne(x => x.ComicDetail).HasForeignKey<ComicDetail>(x => x.ComicId);

            builder.HasOne(x => x.Status).WithMany(x => x.ComicDetails).HasForeignKey(x => x.StatusId);
        }
    }
}

using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class ArtistConfiguration : EntityTypeConfigurationBase<Artist>
    {
        public override void Configure(EntityTypeBuilder<Artist> builder)
        {
            base.Configure(builder);

            builder.ToTable("Artists");

            builder.HasKey(x => x.ArtistId);
            builder.Property(x => x.ArtistId).UseIdentityColumn();

            builder.Property(x => x.ArtistName).IsRequired(true).HasMaxLength(150);

            builder.Property(x => x.Alternative).IsRequired(false).HasMaxLength(150);

            builder.Property(x => x.Summary).IsRequired(false).HasMaxLength(3800);

            builder.Property(x => x.ArtistSEOSummary).IsRequired(false).HasMaxLength(500);

            builder.Property(x => x.ArtistSEOTitle).IsRequired(false).HasMaxLength(150);

            builder.Property(x => x.ArtistSEOAlias).IsRequired(true).IsUnicode(true);
            //builder.HasIndex(x => x.ArtistSEOAlias).IsUnique(true).HasDatabaseName("ArtistSEOAliasIndex");
        }
    }
}

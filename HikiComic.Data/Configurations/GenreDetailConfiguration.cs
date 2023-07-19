using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class GenreDetailConfiguration : EntityTypeConfigurationBase<GenreDetail>
    {
        public override void Configure(EntityTypeBuilder<GenreDetail> builder)
        {
            base.Configure(builder);

            builder.ToTable("GenreDetails");

            builder.HasKey(x => x.GenreDetailId);
            builder.Property(x => x.GenreDetailId).UseIdentityColumn();

            builder.Property(x => x.GenreId).IsRequired();

            builder.Property(x => x.GenreName).IsRequired(true).HasMaxLength(100);

            builder.Property(x => x.Summary).IsRequired(false).HasMaxLength(1000);

            builder.Property(x => x.GenreSEOSummary).IsRequired(false).HasMaxLength(500);

            builder.Property(x => x.GenreSEOTitle).IsRequired(false).HasMaxLength(150);

            builder.Property(x => x.GenreSEOAlias).IsRequired(true).IsUnicode(true).HasMaxLength(100);
            //builder.HasIndex(x => x.GenreSEOAlias).IsUnique(true).HasDatabaseName("GenreSEOAliasIndex");

            builder.HasOne(x => x.Genre).WithOne(x => x.GenreDetail).HasForeignKey<GenreDetail>(x => x.GenreId);
        }
    }
}

using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class AuthorConfiguration : EntityTypeConfigurationBase<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder);

            builder.ToTable("Authors");

            builder.HasKey(x => x.AuthorId);
            builder.Property(x => x.AuthorId).UseIdentityColumn();

            builder.Property(x => x.AuthorName).IsRequired(true).HasMaxLength(150);

            builder.Property(x => x.Alternative).IsRequired(false).HasMaxLength(150);

            builder.Property(x => x.Summary).IsRequired(false).HasMaxLength(3800);

            builder.Property(x => x.AuthorSEOSummary).IsRequired(false).HasMaxLength(500);

            builder.Property(x => x.AuthorSEOTitle).IsRequired(false).HasMaxLength(150);

            builder.Property(x => x.AuthorSEOAlias).IsRequired(true).IsUnicode(true);
            //builder.HasIndex(x => x.AuthorSEOAlias).IsUnique(true).HasDatabaseName("AuthorSEOAliasIndex");

        }

    }
}

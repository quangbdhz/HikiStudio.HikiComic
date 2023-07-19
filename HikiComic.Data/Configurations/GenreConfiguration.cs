using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class GenreConfiguration : EntityTypeConfigurationBase<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            base.Configure(builder);

            builder.ToTable("Genres");

            builder.HasKey(x => x.GenreId);
            builder.Property(x => x.GenreId).UseIdentityColumn();

            builder.Property(x => x.GenreParentId).IsRequired(false);

            builder.Property(x => x.IsShowHome).IsRequired(true);

            builder.Property(x => x.GenreImageURL).IsRequired(true).HasMaxLength(300).IsUnicode(false);

            builder.Property(x => x.ApprovalStatus).IsRequired(true);

            builder.Property(x => x.UserIdApproved).IsRequired(false);

            builder.Property(x => x.DateApproved).IsRequired(false);

        }
    }
}

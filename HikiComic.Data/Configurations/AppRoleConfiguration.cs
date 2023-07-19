using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("AppRoles");

            builder.Property(x => x.Description).HasMaxLength(200).IsRequired(false);

            builder.Property(x => x.Priority).IsRequired(true);

            builder.Property(x => x.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.Property(x => x.CreatedBy).IsRequired(true);

            builder.Property(x => x.DateCreated).IsRequired(true);

            builder.Property(x => x.UpdatedBy).IsRequired(false);

            builder.Property(x => x.DateUpdated).IsRequired(false);
        }
    }
}

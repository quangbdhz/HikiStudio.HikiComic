using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.ToTable("AppUserRoles");

            builder.HasKey(x => new { x.UserId, x.RoleId, x.AppUserRoleId });

            builder.Property(x => x.AppUserRoleId).HasDefaultValue(new Guid());

            builder.Property(x => x.RoleId).IsRequired(true);

            builder.Property(x => x.UserId).IsRequired(true);

            builder.HasOne(x => x.AppRole).WithMany(x => x.AppUserRoles).HasForeignKey(x => x.RoleId);

            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserRoles).HasForeignKey(x => x.UserId);
        }
    }
}

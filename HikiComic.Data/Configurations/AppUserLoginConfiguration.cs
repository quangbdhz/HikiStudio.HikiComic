using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class AppUserLoginConfiguration : IEntityTypeConfiguration<AppUserLogin>
    {
        public void Configure(EntityTypeBuilder<AppUserLogin> builder)
        {

            builder.ToTable("AppUserLogins");

            builder.HasKey(x => x.AppUserLoginId);

            builder.Property(x => x.AppUserLoginId).UseIdentityColumn();

            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserLogins).HasForeignKey(x => x.UserId);
        }
    }
}

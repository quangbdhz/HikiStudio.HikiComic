using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class AppUserClaimConfiguration : IEntityTypeConfiguration<AppUserClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
            builder.ToTable("AppUserClaims");

            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserClaims).HasForeignKey(x => x.UserId);
        }
    }
}

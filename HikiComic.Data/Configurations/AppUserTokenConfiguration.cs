using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class AppUserTokenConfiguration : IEntityTypeConfiguration<AppUserToken>
    {
        public void Configure(EntityTypeBuilder<AppUserToken> builder)
        {

            builder.ToTable("AppUserTokens");

            builder.HasKey(x => x.AppUserTokenId);

            builder.Property(x => x.AppUserTokenId).UseIdentityColumn();

            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserTokens).HasForeignKey(x => x.UserId);
        }
    }
}

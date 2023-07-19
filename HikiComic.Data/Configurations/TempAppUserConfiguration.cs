using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class TempAppUserConfiguration : IEntityTypeConfiguration<TempAppUser>
    {
        public void Configure(EntityTypeBuilder<TempAppUser> builder)
        {
            builder.ToTable("TempAppUsers");

            builder.HasKey(x => x.TempAppUserId);
            builder.Property(x => x.TempAppUserId).UseIdentityColumn();

            builder.Property(x => x.Email).IsRequired(true).HasMaxLength(300);
            //builder.HasIndex(x => x.Email).IsUnique(true).HasDatabaseName("EmailIndex");

            builder.Property(x => x.PasswordHash).IsRequired(true).HasMaxLength(256);

            builder.Property(x => x.OTP).IsRequired(false).HasMaxLength(10);

            builder.Property(x => x.OTPExpires).IsRequired(false);
        }
    }
}

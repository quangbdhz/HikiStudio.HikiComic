using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HikiComic.Data.Configurations.Base;

namespace HikiComic.Data.Configurations
{
    public class AppUserOTPConfiguration : EntityTypeConfigurationBase<AppUserOTP>
    {
        public override void Configure(EntityTypeBuilder<AppUserOTP> builder)
        {
            base.Configure(builder);

            builder.ToTable("AppUserOTPs");

            builder.HasKey(x => x.AppUserOTPId);
            builder.Property(x => x.AppUserOTPId).UseIdentityColumn();

            builder.Property(e => e.OTPType).IsRequired(true);

            builder.Property(e => e.OTP).IsRequired(true).HasMaxLength(200);

            builder.Property(e => e.OTPExpires).IsRequired(true);

            builder.Property(e => e.IsOTPVerified).IsRequired(true);


            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserOTPs).HasForeignKey(x => x.AppUserId);
        }
    }
}

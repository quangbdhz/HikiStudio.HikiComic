using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class AppUserDeviceConfiguration : EntityTypeConfigurationBase<AppUserDevice>
    {
        public override void Configure(EntityTypeBuilder<AppUserDevice> builder)
        {
            base.Configure(builder);

            builder.ToTable("AppUserDevices");

            builder.HasKey(x => x.AppUserDeviceId);
            builder.Property(x => x.AppUserDeviceId).UseIdentityColumn();

            builder.Property(x => x.DeviceId).IsRequired(true).HasMaxLength(200);

            builder.Property(x => x.FCMDeviceToken).IsRequired(true).HasMaxLength(1000);

            builder.Property(x => x.DeviceType).IsRequired(true).HasMaxLength(100);

            builder.Property(x => x.DeviceName).IsRequired(true).HasMaxLength(500);

            builder.Property(x => x.DeviceOS).IsRequired(true).HasMaxLength(100);

            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserDevices).HasForeignKey(x => x.AppUserId);
        }
    }
}

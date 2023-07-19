using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class NotificationConfiguration : EntityTypeConfigurationBase<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            base.Configure(builder);
            builder.ToTable("Notifications");

            builder.HasKey(x => x.NotificationId);
            builder.Property(x => x.NotificationId).UseIdentityColumn();

            builder.Property(x => x.Title).IsRequired(true).HasMaxLength(500);

            builder.Property(x => x.NotificationType).IsRequired(true);

            builder.Property(x => x.Message).IsRequired(true).HasMaxLength(1000);

            builder.Property(x => x.IsRead).IsRequired(true).HasDefaultValue(false);

            builder.Property(x => x.Actions).IsRequired(false).HasMaxLength(500);

            builder.Property(x => x.ImageURL).IsRequired(false).HasMaxLength(500).IsUnicode(true);

            builder.Property(x => x.NotificationPriority).IsRequired(true);


            builder.HasOne(x => x.AppUser).WithMany(x => x.Notifications).HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Notifications).HasForeignKey(x => x.CreatedBy);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Notifications).HasForeignKey(x => x.UpdatedBy);

            builder.HasOne(x => x.Comic).WithMany(x => x.Notifications).HasForeignKey(x => x.ComicId);

            builder.HasOne(x => x.Chapter).WithMany(x => x.Notifications).HasForeignKey(x => x.ChapterId).IsRequired(false);
        }
    }
}

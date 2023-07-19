using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class UserRoleUpgradeRequestConfiguration : EntityTypeConfigurationBase<UserRoleUpgradeRequest>
    {
        public override void Configure(EntityTypeBuilder<UserRoleUpgradeRequest> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserRoleUpgradeRequests");

            builder.HasKey(x => x.UserRoleUpgradeRequestId);
            builder.Property(x => x.UserRoleUpgradeRequestId).UseIdentityColumn();

            builder.Property(x => x.ApprovalStatus).IsRequired(true);

            builder.HasOne(x => x.AppUser).WithMany(x => x.UserRoleUpgradeRequests).HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.AppRole).WithMany(x => x.UserRoleUpgradeRequests).HasForeignKey(x => x.CurrentRoleId).IsRequired();

            builder.HasOne(x => x.AppRole).WithMany(x => x.UserRoleUpgradeRequests).HasForeignKey(x => x.DesiredRoleId).IsRequired();
        }
    }
}

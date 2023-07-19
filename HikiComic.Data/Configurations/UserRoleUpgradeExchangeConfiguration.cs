using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class UserRoleUpgradeExchangeConfiguration : EntityTypeConfigurationBase<UserRoleUpgradeExchange>
    {
        public override void Configure(EntityTypeBuilder<UserRoleUpgradeExchange> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserRoleUpgradeExchanges");

            builder.HasKey(x => x.UserRoleUpgradeExchangeId);
            builder.Property(x => x.UserRoleUpgradeExchangeId).UseIdentityColumn();

            builder.Property(x => x.Message).IsUnicode(true).HasMaxLength(3000).IsRequired(true);

            builder.Property(x => x.IsReaded).IsRequired(true).HasDefaultValue(false);

            builder.Property(x => x.IsReader).IsRequired(true);

            builder.HasOne(x => x.UserRoleUpgradeRequest).WithMany(x => x.UserRoleUpgradeExchanges).HasForeignKey(x => x.UserRoleUpgradeRequestId);

        }
    }
}
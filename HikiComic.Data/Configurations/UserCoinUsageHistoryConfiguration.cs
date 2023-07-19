using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class UserCoinUsageHistoryConfiguration : EntityTypeConfigurationBase<UserCoinUsageHistory>
    {
        public override void Configure(EntityTypeBuilder<UserCoinUsageHistory> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserCoinUsageHistories");

            builder.HasKey(x => x.UserCoinUsageHistoryId);
            builder.Property(x => x.UserCoinUsageHistoryId).UseIdentityColumn();

            builder.Property(x => x.UsageAmount).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.UsageMethodId).IsRequired(true);

            builder.Property(x => x.UsageStatusId).IsRequired(true);

            builder.HasOne(x => x.Account).WithMany(x => x.UserCoinUsageHistories).HasForeignKey(x => x.AccountId);
        }
    }
}

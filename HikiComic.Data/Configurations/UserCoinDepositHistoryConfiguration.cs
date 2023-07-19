using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class UserCoinDepositHistoryConfiguration : EntityTypeConfigurationBase<UserCoinDepositHistory>
    {
        public override void Configure(EntityTypeBuilder<UserCoinDepositHistory> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserCoinDepositHistories");

            builder.HasKey(x => x.UserCoinDepositHistoryId);
            builder.Property(x => x.UserCoinDepositHistoryId).UseIdentityColumn();

            builder.Property(x => x.OriginalAmount).IsRequired(true);

            builder.Property(x => x.OriginalCurrency).IsRequired(true);

            builder.Property(x => x.DepositAmount).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.ConvertCurrency).IsRequired(true);

            builder.Property(x => x.DepositMethodId).IsRequired(true);

            builder.Property(x => x.TransactionId).IsRequired(true).HasMaxLength(200);

            builder.Property(x => x.DepositStatusId).IsRequired(true);

            builder.Property(x => x.DepositCreateTime).IsRequired(true);

            builder.Property(x => x.DepositUpdateTime).IsRequired(false);

            builder.Property(x => x.Remarks).HasMaxLength(1000).IsUnicode(true);

            builder.Property(x => x.ExchangeRate).HasMaxLength(500);

            builder.HasOne(x => x.Account).WithMany(x => x.UserCoinDepositHistories).HasForeignKey(x => x.AccountId);
        }
    }
}

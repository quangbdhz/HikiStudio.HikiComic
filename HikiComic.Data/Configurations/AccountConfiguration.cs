using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class AccountConfiguration : EntityTypeConfigurationBase<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.ToTable("Accounts");

            builder.HasKey(x => x.AccountId);
            builder.Property(x => x.AccountId).UseIdentityColumn();

            builder.Property(x => x.Nickname).IsRequired(false).HasMaxLength(200).IsUnicode(true);

            builder.Property(x => x.CoinsLeft).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.CoinsSpent).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.CoinsDeposited).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.CoinsReceived).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.MoreInfo).IsRequired(false).HasMaxLength(500);

            builder.Property(x => x.Experienced).IsRequired(true).HasDefaultValue(0);

            builder.Property(x => x.DateModified).IsRequired(true).HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.AppUser).WithOne(x => x.Account).HasForeignKey<Account>(x => x.AppUserId);
        }
    }

}

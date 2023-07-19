using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class UserComicPurchaseConfiguration : EntityTypeConfigurationBase<UserComicPurchase>
    {
        public override void Configure(EntityTypeBuilder<UserComicPurchase> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserComicPurchases");

            builder.HasKey(x => x.UserComicPurchaseId);
            builder.Property(x => x.UserComicPurchaseId).UseIdentityColumn();

            builder.Property(x => x.MoreInfo).IsRequired(false).HasMaxLength(1000).IsUnicode(true);

            builder.HasOne(x => x.UserCoinUsageHistory).WithOne(x => x.UserComicPurchase).HasForeignKey<UserComicPurchase>(x => x.UserCoinUsageHistoryId);

            builder.HasOne(x => x.Comic).WithMany(x => x.UserComicPurchases).HasForeignKey(x => x.ComicId);

            builder.HasOne(x => x.Chapter).WithMany(x => x.UserComicPurchases).HasForeignKey(x => x.ChapterId);

        }
    }
}

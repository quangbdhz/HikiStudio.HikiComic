using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class ServicePriceConfiguration : EntityTypeConfigurationBase<ServicePrice>
    {
        public override void Configure(EntityTypeBuilder<ServicePrice> builder)
        {
            base.Configure(builder);

            builder.ToTable("ServicePrices");

            builder.HasKey(x => x.ServicePriceId);
            builder.Property(x => x.ServicePriceId).UseIdentityColumn();

            builder.Property(x => x.ServicePriceName).HasMaxLength(200).IsRequired(true);

            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired(false);

            builder.Property(x => x.Price).IsRequired(true);

        }
    }
}

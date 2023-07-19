using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class ServiceConfigConfiguration : EntityTypeConfigurationBase<ServiceConfig>
    {
        public override void Configure(EntityTypeBuilder<ServiceConfig> builder)
        {
            base.Configure(builder);

            builder.ToTable("ServiceConfigs");

            builder.HasKey(x => x.ServiceConfigId);
            builder.Property(x => x.ServiceConfigId).UseIdentityColumn();

            builder.Property(x => x.ServiceConfigName).IsRequired(true).HasMaxLength(200);

            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(1000);

            builder.Property(x => x.Value).IsRequired(true);

            builder.Property(x => x.StringValue).IsRequired(true).HasMaxLength(500);

            builder.Property(x => x.Note).IsRequired(false).HasMaxLength(1000);
        }
    }
}

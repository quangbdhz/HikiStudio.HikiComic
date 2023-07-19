using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class StatusConfiguration : EntityTypeConfigurationBase<Status>
    {
        public override void Configure(EntityTypeBuilder<Status> builder)
        {
            base.Configure(builder);

            builder.ToTable("Statuses");

            builder.HasKey(x => x.StatusId);
            builder.Property(x => x.StatusId).UseIdentityColumn();

            builder.Property(x => x.StatusName).IsRequired(true).HasMaxLength(100);
        }
    }
}

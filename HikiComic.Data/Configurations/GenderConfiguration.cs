using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class GenderConfiguration : EntityTypeConfigurationBase<Gender>
    {
        public override void Configure(EntityTypeBuilder<Gender> builder)
        {
            base.Configure(builder);
            builder.ToTable("Genders");

            builder.HasKey(x => x.GenderId);
            builder.Property(x => x.GenderId).UseIdentityColumn();

            builder.Property(x => x.GenderName).IsRequired(true).HasMaxLength(100);
        }
    }
}

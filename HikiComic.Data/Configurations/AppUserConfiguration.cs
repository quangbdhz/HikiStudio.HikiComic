using HikiComic.Data.Configurations.Base;
using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");

            //builder.HasIndex(x => x.NormalizedEmail).IsUnique(true).HasDatabaseName("NormalizedEmailIndex");
            //builder.HasIndex(x => x.Email).IsUnique(true).HasDatabaseName("EmailIndex");

            builder.Property(x => x.FirstName).IsRequired(false).HasMaxLength(200);

            builder.Property(x => x.LastName).IsRequired(false).HasMaxLength(200);

            builder.Property(x => x.DOB).IsRequired(false);

            builder.Property(x => x.UserImageURL).IsRequired(false).HasMaxLength(500);

            builder.Property(x => x.RefreshToken).IsRequired(false).HasMaxLength(1000).IsUnicode(false);

            builder.Property(x => x.TokenCreated).IsRequired(false);

            builder.Property(x => x.TokenExpires).IsRequired(false);

            builder.Property(x => x.GenderId).IsRequired(false);

            builder.Property(x => x.OTP).IsRequired(false).HasMaxLength(10);

            builder.Property(x => x.OTPExpires).IsRequired(false);

            builder.Property(x => x.IsOTPVerified).IsRequired(false);

            builder.Property(x => x.AppUserTypeId).IsRequired(true);

            builder.Property(x => x.IsCreateAppUserWithThirdParty).IsRequired(true);

            builder.Property(x => x.IsPasswordChanged).IsRequired(true).HasDefaultValue(false);

            builder.Property(x => x.DatePasswordChanged).IsRequired(false);

            builder.Property(x => x.DateCreated).IsRequired(true);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired(true);

            builder.Property(x => x.CreatedBy).IsRequired(false);

            builder.HasOne(x => x.Gender).WithMany(x => x.AppUsers).HasForeignKey(x => x.GenderId);
        }
    }
}

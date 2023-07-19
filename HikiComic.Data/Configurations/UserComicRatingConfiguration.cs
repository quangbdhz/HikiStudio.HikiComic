using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class UserComicRatingConfiguration : IEntityTypeConfiguration<UserComicRating>
    {
        public void Configure(EntityTypeBuilder<UserComicRating> builder)
        {

            builder.ToTable("UserComicRatings");

            builder.HasKey(x => x.UserComicRatingId);
            builder.Property(x => x.UserComicRatingId).UseIdentityColumn();

            builder.Property(x => x.Rating).IsRequired(true);

            builder.Property(x => x.DateRating).IsRequired(true).HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.AppUser).WithMany(x => x.UserComicRatings).HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.Comic).WithMany(x => x.UserComicRatings).HasForeignKey(x => x.ComicId);
        }
    }
}

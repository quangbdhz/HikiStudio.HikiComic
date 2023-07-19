using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class UserComicLikeConfiguration : IEntityTypeConfiguration<UserComicLike>
    {
        public void Configure(EntityTypeBuilder<UserComicLike> builder)
        {
            builder.ToTable("UserComicLikes"); 
            
            builder.HasKey(x => x.UserComicLikeId);
            builder.Property(x => x.UserComicLikeId).UseIdentityColumn();

            builder.Property(x => x.Liked).IsRequired(true).HasDefaultValue(true);

            builder.Property(x => x.DateLiked).IsRequired(true).HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.AppUser).WithMany(x => x.UserComicLikes).HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.Comic).WithMany(x => x.UserComicLikes).HasForeignKey(x => x.ComicId);
        }
    }
}

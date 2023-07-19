using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class UserComicFollowingConfiguration : IEntityTypeConfiguration<UserComicFollowing>
    {
        public void Configure(EntityTypeBuilder<UserComicFollowing> builder)
        {
            builder.ToTable("UserComicFollowings");

            builder.HasKey(x => x.UserComicFollowingId);
            builder.Property(x => x.UserComicFollowingId).UseIdentityColumn();

            builder.Property(x => x.DateFollow).IsRequired(true);

            builder.HasOne(x => x.AppUser).WithMany(x => x.UserComicFollowings).HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.Comic).WithMany(x => x.UserComicFollowings).HasForeignKey(x => x.ComicId);
        }
    }
}

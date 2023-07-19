using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class UserComicReadingHistoryConfiguration : IEntityTypeConfiguration<UserComicReadingHistory>
    {
        public void Configure(EntityTypeBuilder<UserComicReadingHistory> builder)
        {
            builder.ToTable("UserComicReadingHistories");

            builder.HasKey(x => x.UserComicReadingHistoryId);
            builder.Property(x => x.UserComicReadingHistoryId).UseIdentityColumn();

            builder.Property(x => x.DateRead).IsRequired(true);

            builder.HasOne(x => x.AppUser).WithMany(x => x.UserComicReadingHistories).HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.Comic).WithMany(x => x.UserComicReadingHistories).HasForeignKey(x => x.ComicId);

            builder.HasOne(x => x.Chapter).WithMany(x => x.UserComicReadingHistories).HasForeignKey(x => x.ChapterId);

        }
    }
}

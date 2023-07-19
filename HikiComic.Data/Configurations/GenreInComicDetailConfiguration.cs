using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class GenreInComicDetailConfiguration : IEntityTypeConfiguration<GenreInComicDetail>
    {
        public void Configure(EntityTypeBuilder<GenreInComicDetail> builder)
        {
            builder.ToTable("GenreInComicDetails");

            builder.HasKey(x => new { x.GenreId, x.ComicDetailId });

            builder.HasOne(x => x.Genre).WithMany(x => x.GenreInComicDetails).HasForeignKey(x => x.GenreId);

            builder.HasOne(x => x.ComicDetail).WithMany(x => x.GenreInComicDetails).HasForeignKey(x => x.ComicDetailId);
        }
    }
}

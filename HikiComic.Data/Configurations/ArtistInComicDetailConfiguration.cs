using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class ArtistInComicDetailConfiguration : IEntityTypeConfiguration<ArtistInComicDetail>
    {
        public void Configure(EntityTypeBuilder<ArtistInComicDetail> builder)
        {
            builder.ToTable("ArtistInComicDetails");

            builder.HasKey(x => new { x.ArtistId, x.ComicDetailId });

            builder.HasOne(x => x.Artist).WithMany(x => x.ArtistInComicDetails).HasForeignKey(x => x.ArtistId);

            builder.HasOne(x => x.ComicDetail).WithMany(x => x.ArtistInComicDetails).HasForeignKey(x => x.ComicDetailId);
        }
    }
}

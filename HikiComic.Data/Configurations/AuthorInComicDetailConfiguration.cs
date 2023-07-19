using HikiComic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikiComic.Data.Configurations
{
    public class AuthorInComicDetailConfiguration : IEntityTypeConfiguration<AuthorInComicDetail>
    {
        public void Configure(EntityTypeBuilder<AuthorInComicDetail> builder)
        {
            builder.ToTable("AuthorInComicDetails");

            builder.HasKey(x => new { x.AuthorId, x.ComicDetailId });

            builder.HasOne(x => x.Author).WithMany(x => x.AuthorInComicDetails).HasForeignKey(x => x.AuthorId);

            builder.HasOne(x => x.ComicDetail).WithMany(x => x.AuthorInComicDetails).HasForeignKey(x => x.ComicDetailId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HikiComic.Data.EF
{
    public class HikiComicDbContextFactory : IDesignTimeDbContextFactory<HikiComicDbContext>
    {
        public HikiComicDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("HikiComicDB");

            var optionsBuilder = new DbContextOptionsBuilder<HikiComicDbContext>();
            optionsBuilder.UseSqlServer(connectionString ?? "");

            return new HikiComicDbContext(optionsBuilder.Options);
        }
    }
}

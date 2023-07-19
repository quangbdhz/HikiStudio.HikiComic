using HikiComic.Data.Configurations;
using HikiComic.Data.Entities;
using HikiComic.Data.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HikiComic.Data.EF
{
    public class HikiComicDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public HikiComicDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());

            modelBuilder.ApplyConfiguration(new AppRoleClaimConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserClaimConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserTokenConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserOTPConfiguration());

            modelBuilder.ApplyConfiguration(new AppUserDeviceConfiguration());

            modelBuilder.ApplyConfiguration(new NotificationConfiguration());

            modelBuilder.ApplyConfiguration(new TempAppUserConfiguration());

            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            modelBuilder.ApplyConfiguration(new ServicePriceConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfigConfiguration());

            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());

            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistInComicDetailConfiguration());

            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorInComicDetailConfiguration());

            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new GenreInComicDetailConfiguration());
            modelBuilder.ApplyConfiguration(new GenreDetailConfiguration());

            modelBuilder.ApplyConfiguration(new ComicConfiguration());
            modelBuilder.ApplyConfiguration(new ComicDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ChapterConfiguration());
            modelBuilder.ApplyConfiguration(new ChapterImageURLConfiguration());

            modelBuilder.ApplyConfiguration(new UserComicReadingHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserComicFollowingConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());

            modelBuilder.ApplyConfiguration(new UserComicLikeConfiguration());
            modelBuilder.ApplyConfiguration(new UserComicRatingConfiguration());

            modelBuilder.ApplyConfiguration(new UserCoinDepositHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserCoinUsageHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserComicPurchaseConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleUpgradeRequestConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleUpgradeExchangeConfiguration());
            //
            modelBuilder.Seed();
        }

        public override DbSet<AppRole> Roles { get; set; }

        public DbSet<TempAppUser> TempAppUsers { get; set; }

        public DbSet<AppUserOTP> AppUserOTPs { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<ArtistInComicDetail> ArtistInComicDetails { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<AuthorInComicDetail> AuthorInComicDetails { get; set; }

        public DbSet<Chapter> Chapters { get; set; }

        public DbSet<Comic> Comics { get; set; }

        public DbSet<ChapterImageURL> ChapterImageURLs { get; set; }

        public DbSet<ComicDetail> ComicDetails { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<GenreDetail> GenreDetails { get; set; }

        public DbSet<GenreInComicDetail> GenreInComicDetails { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<UserComicReadingHistory> UserComicReadingHistories { get; set; }

        public DbSet<UserComicFollowing> UserComicFollowings { get; set; }

        public DbSet<UserComicLike> UserComicLikes { get; set; }

        public DbSet<UserComicRating> UserComicRatings { get; set; }

        public DbSet<UserCoinDepositHistory> UserCoinDepositHistories { get; set; }

        public DbSet<UserCoinUsageHistory> UserCoinUsageHistories { get; set; }

        public DbSet<UserComicPurchase> UserComicPurchases { get; set; }

        public DbSet<ServicePrice> ServicePrices { get; set; }

        public DbSet<ServiceConfig> ServiceConfigs { get; set; }

        public DbSet<AppUserDevice> AppUserDevices { get; set; }

        public DbSet<UserRoleUpgradeRequest> UserRoleUpgradeRequests { get; set; }

        public DbSet<UserRoleUpgradeExchange> UserRoleUpgradeExchanges { get; set; }

        public DbSet<Notification> Notifications { get; set; }


    }
}

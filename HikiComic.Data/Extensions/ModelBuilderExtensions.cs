using HikiComic.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Text;
using HikiComic.Utilities.Enums;

namespace HikiComic.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var adminId = new Guid("0B64F6F0-9F60-45C9-9E7B-F68CCC3FC57F");

            modelBuilder.Entity<Status>().HasData(
                new Status() { StatusId = 1, StatusName = "New", CreatedBy = adminId, DateCreated = DateTime.Now },
                new Status() { StatusId = 2, StatusName = "Ongoing", CreatedBy = adminId, DateCreated = DateTime.Now },
                new Status() { StatusId = 3, StatusName = "Drop", CreatedBy = adminId, DateCreated = DateTime.Now },
                new Status() { StatusId = 4, StatusName = "Completed", CreatedBy = adminId, DateCreated = DateTime.Now });

            modelBuilder.Entity<Gender>().HasData(
                new Gender() { GenderId = 1, GenderName = "Male", CreatedBy = adminId, DateCreated = DateTime.Now },
                new Gender() { GenderId = 2, GenderName = "Female", CreatedBy = adminId, DateCreated = DateTime.Now },
                new Gender() { GenderId = 3, GenderName = "Other", CreatedBy = adminId, DateCreated = DateTime.Now });

            modelBuilder.Entity<ServicePrice>().HasData(
                new ServicePrice() { ServicePriceId = 1, ServicePriceName = "Read Comics", Price = 2, IsDeleted = false, Description = null, CreatedBy = adminId, DateCreated = DateTime.Now },
                new ServicePrice() { ServicePriceId = 2, ServicePriceName = "Change Nickname", Price = 5, IsDeleted = false, Description = null, CreatedBy = adminId, DateCreated = DateTime.Now },
                new ServicePrice() { ServicePriceId = 3, ServicePriceName = "Change Avatar", Price = 10, IsDeleted = false, Description = null, CreatedBy = adminId, DateCreated = DateTime.Now });

            modelBuilder.Entity<ServiceConfig>().HasData(
                new ServiceConfig() { ServiceConfigId = 1, ServiceConfigName = "Number of comic chapters for free", Description = null, StringValue = "3", Value = 3, Note = null, CreatedBy = adminId, DateCreated = DateTime.Now },
                new ServiceConfig() { ServiceConfigId = 2, ServiceConfigName = "Conversion ratio COINS", Description = null, StringValue = "1000", Value = 1000, Note = null, CreatedBy = adminId, DateCreated = DateTime.Now },
                new ServiceConfig() { ServiceConfigId = 3, ServiceConfigName = "Default Currency", Description = null, StringValue = "VND", Value = 0, Note = null, CreatedBy = adminId, DateCreated = DateTime.Now });

            var adminRoleId = new Guid("E1DB1200-1BB6-4156-9DA3-135E91D94ABA");
            var teamMemeberRoleId = new Guid("C489F858-AABD-4264-96C1-5CDCA251D871");
            var creatorRoleId = new Guid("71B1B0A6-7EAB-476C-B177-1D37E120184C");
            var readerRoleId = new Guid("2F0C7B75-8934-4101-BEF2-C850E42D21DE");

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole() { Id = adminRoleId, Name = "admin", NormalizedName = "ADMIN", Description = "Administrator Role", Priority = RolePriorityEnum.High, CreatedBy = adminId, DateCreated = DateTime.Now },
                new AppRole() { Id = teamMemeberRoleId, Name = "teamMembers", NormalizedName = "TEAMMEMBERS", Description = "Team Members Role", Priority = RolePriorityEnum.Medium, CreatedBy = adminId, DateCreated = DateTime.Now },
                new AppRole() { Id = creatorRoleId, Name = "creator", NormalizedName = "CREATOR", Description = "Creator Role", Priority = RolePriorityEnum.Low, CreatedBy = adminId, DateCreated = DateTime.Now },
                new AppRole() { Id = readerRoleId, Name = "reader", NormalizedName = "READER", Description = "Reader Role", Priority = RolePriorityEnum.None, CreatedBy = adminId, DateCreated = DateTime.Now });

            var appUserDefaultNull = new AppUser();

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = adminId,
                    UserName = "quangbdhz",
                    NormalizedUserName = "ADMIN",
                    Email = "tranquangbdhz@gmail.com",
                    NormalizedEmail = "TRANQUANGBDHZ@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(appUserDefaultNull, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "Tran",
                    LastName = "Quang",
                    DOB = new DateTime(2001, 10, 08),
                    UserImageURL = "",
                    IsDeleted = false,
                    GenderId = 1
                });

            var hikistudioId = new Guid("0AE34DB7-EA08-42D2-9AEF-098EFCDD2C1E");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = hikistudioId,
                    UserName = "hikistudio",
                    NormalizedUserName = "HIKISTUDIO",
                    Email = "hikistudio@hiki.space",
                    NormalizedEmail = "HIKISTUDIO@HIKI.SPACE",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(appUserDefaultNull, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "Admin",
                    LastName = "HikiStudio",
                    UserImageURL = "",
                    DOB = new DateTime(2000, 05, 08),
                    IsDeleted = false,
                    IsPasswordChanged = true,
                    DatePasswordChanged = DateTime.Now,
                    GenderId = 2
                });

            var teamMemeberId = new Guid("3E3245CB-BC7B-4C08-AD09-72FBD736FC9A");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = teamMemeberId,
                    UserName = "lionelmessi",
                    NormalizedUserName = "YUKINO",
                    Email = "lionelmessi@hiki.space",
                    NormalizedEmail = "LIONELMESSI@HIKI.SPACE",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(appUserDefaultNull, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "Lionel",
                    LastName = "Messi",
                    DOB = new DateTime(1990, 10, 08),
                    UserImageURL = "",
                    IsDeleted = false,
                    IsPasswordChanged = true,
                    DatePasswordChanged = DateTime.Now,
                    GenderId = 1
                });

            var creatorId = new Guid("D8682AA6-255A-4B31-AEAA-1AFF35A8BE58");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = creatorId,
                    UserName = "creator",
                    NormalizedUserName = "CREATOR",
                    Email = "creator@hiki.space",
                    NormalizedEmail = "CREATOR@HIKI.SPACE",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(appUserDefaultNull, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "Creator",
                    LastName = "HikiStudio",
                    DOB = new DateTime(2001, 10, 08),
                    UserImageURL = "",
                    IsDeleted = false,
                    IsPasswordChanged = true,
                    DatePasswordChanged = DateTime.Now,
                    GenderId = 2
                });

            var readerId = new Guid("4354ACBC-A32A-4A28-B865-DEB49695171F");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = readerId,
                    UserName = "reader",
                    NormalizedUserName = "READER",
                    Email = "reader@hiki.space",
                    NormalizedEmail = "READER@HIKI.SPACE",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(appUserDefaultNull, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    FirstName = "Reader",
                    LastName = "HikiStudio",
                    DOB = new DateTime(2001, 10, 08),
                    UserImageURL = "",
                    IsDeleted = false,
                    IsPasswordChanged = true,
                    DatePasswordChanged = DateTime.Now,
                    GenderId = 3
                });

            modelBuilder.Entity<Account>().HasData(
                new Account() { AccountId = 1, AppUserId = adminId, Experienced = 0, MoreInfo = "Administrator", Nickname = null },
                new Account() { AccountId = 2, AppUserId = hikistudioId, Experienced = 0, MoreInfo = "Supper VIP PRO", Nickname = null },
                new Account() { AccountId = 3, AppUserId = teamMemeberId, Experienced = 0, MoreInfo = "team members", Nickname = null },
                new Account() { AccountId = 4, AppUserId = creatorId, Experienced = 0, MoreInfo = "creator", Nickname = null },
                new Account() { AccountId = 5, AppUserId = readerId, Experienced = 0, MoreInfo = "reader", Nickname = null });

            modelBuilder.Entity<AppUserRole>().HasData(
                new AppUserRole() { RoleId = adminRoleId, UserId = adminId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = readerRoleId, UserId = adminId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = adminRoleId, UserId = hikistudioId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = readerRoleId, UserId = hikistudioId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = teamMemeberRoleId, UserId = teamMemeberId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = readerRoleId, UserId = teamMemeberId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = creatorRoleId, UserId = creatorId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = readerRoleId, UserId = creatorId, AppUserRoleId = Guid.NewGuid() },
                new AppUserRole() { RoleId = readerRoleId, UserId = readerId, AppUserRoleId = Guid.NewGuid() });

            modelBuilder.Entity<Artist>().HasData(
                new Artist()
                {
                    ArtistId = 1,
                    ArtistName = "Updating",
                    Alternative = "Updating",
                    IsDeleted = false,
                    ArtistSEOAlias = "updating-349149",
                    ArtistSEOSummary = "Updating SEO Summary - HIKICOMIC",
                    ArtistSEOTitle = "Updating SEO Title - HIKICOMIC",
                    Summary = "Updating Summary - HIKICOMIC",
                    CreatedBy = adminId,
                    DateCreated = DateTime.Now
                });

            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    AuthorId = 1,
                    AuthorName = "Updating",
                    Alternative = "Updating",
                    IsDeleted = false,
                    AuthorSEOAlias = "updating-713713",
                    AuthorSEOSummary = "Updating SEO Summary - HIKICOMIC",
                    AuthorSEOTitle = "Updating SEO Title - HIKICOMIC",
                    Summary = "Updating Summary - HIKICOMIC",
                    CreatedBy = adminId,
                    DateCreated = DateTime.Now
                });

            modelBuilder.Entity<Genre>().HasData(
                new Genre()
                {
                    GenreId = 1,
                    GenreParentId = null,
                    GenreImageURL = "",
                    IsShowHome = false,
                    IsDeleted = false,
                    CreatedBy = adminId,
                    DateCreated = DateTime.Now
                });

            modelBuilder.Entity<GenreDetail>().HasData(
                new GenreDetail()
                {
                    GenreDetailId = 1,
                    GenreId = 1,
                    GenreName = "Updating",
                    Summary = "Updating Summary - HIKICOMIC",
                    GenreSEOAlias = "updating-391314",
                    GenreSEOSummary = "Updating SEO Summary - HIKICOMIC",
                    GenreSEOTitle = "Updating SEO Title - HIKICOMIC",
                    CreatedBy = adminId,
                });

            #region init genres data
            var genreDetails = new List<GenreDetail> {
            new GenreDetail() {
                GenreDetailId= 2,
                GenreId= 2,
                GenreName= "Action",
                Summary= "A genre focused on physical action, often involving fighting or combat scenes. Action stories are typically fast-paced and thrilling, with a lot of movement and high stakes.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "action-304301",
                CreatedBy = adminId
            },
            new GenreDetail() {
                GenreDetailId= 3,
                GenreId= 3,
                GenreName= "Adaptation",
                Summary= "A genre that is based on existing source material, such as a novel, manga, or video game. Adaptations can be faithful or loose, and can vary greatly in terms of how closely they follow the source material.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "adaptation-934546",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 4,
                GenreId= 4,
                GenreName= "Adult",
                Summary= "A genre that contains explicit sexual content and/or graphic violence. Adult stories are typically intended for mature audiences only, and may explore taboo or controversial subjects.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias = "adult-774714",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 5,
                GenreId= 5,
                GenreName= "Adventure",
                Summary= "A genre focused on exploration, often involving exotic locations, treasure hunting, or quests. Adventure stories are typically exciting and full of surprises, with a strong sense of adventure and discovery.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "adventure-300184",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 6,
                GenreId= 6,
                GenreName= "Animal",
                Summary= "A genre that features animals as main characters or as a significant aspect of the story. Animal stories can be anthropomorphic or realistic, and often explore themes related to nature, survival, and the animal kingdom.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "animal-305529",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 7,
                GenreId= 7,
                GenreName= "Chinese",
                Summary= "A genre that originates from China or is heavily influenced by Chinese culture. Chinese stories can vary greatly in terms of style and subject matter, but often feature elements such as martial arts, mythology, and historical drama.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "chinese-993685",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 8,
                GenreId= 8,
                GenreName= "Comedy",
                Summary= "A genre focused on humor and comedic situations. Comedy stories can range from light-hearted and silly to dark and satirical, and often involve witty banter, physical comedy, or absurd situations.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "comedy-262691",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 9,
                GenreId= 9,
                GenreName= "Comic",
                Summary= "A genre that originates from comic strips or comic books. Comic stories can be funny or serious, and often feature unique visual styles, such as exaggerated character designs, bold colors, and dynamic panel layouts.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "comic-547961",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 10,
                GenreId= 10,
                GenreName= "Cooking",
                Summary= "A genre focused on cooking and food preparation. Cooking stories often explore the art and science of cooking, as well as the cultural and social significance of food. They may also involve elements of drama, romance, or competition.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "cooking-860807",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 11,
                GenreId= 11,
                GenreName= "Crime",
                Summary= "A genre focused on crime and criminal activity. Crime stories can be gritty and realistic or stylized and pulpy, and often involve elements such as detectives, heists, or organized crime.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "crime-819021",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 12,
                GenreId= 12,
                GenreName= "Crossdressing",
                Summary= "Involves characters who dress in clothing traditionally associated with the opposite gender.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "crossdressing-730811",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 13,
                GenreId= 13,
                GenreName= "Demons",
                Summary= "Involves supernatural creatures who are often malevolent towards humans.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "demons-698466",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 14,
                GenreId= 14,
                GenreName= "Drama",
                Summary= "Focuses on realistic, often emotional, conflicts between characters.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "drama-310439",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 15,
                GenreId= 15,
                GenreName= "Ecchi",
                Summary= "Contains sexual themes and humor, but is less explicit than hentai.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "ecchi-837736",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 16,
                GenreId= 16,
                GenreName= "Fantasy",
                Summary= "Involves elements of magic, supernatural powers, and mythical creatures.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "fantasy-445140",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 17,
                GenreId= 17,
                GenreName= "Full Color",
                Summary= "Comics or manga that are colored, rather than black and white.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "full-color-870413",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 18,
                GenreId= 18,
                GenreName= "Game",
                Summary= "Involves characters playing games, whether video games or other types.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "game-107608",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 19,
                GenreId= 19,
                GenreName= "Gender Bender",
                Summary= "Involves characters who switch or blur gender roles, often through magic or supernatural means.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "gender-bender-321894",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 20,
                GenreId= 20,
                GenreName= "Gore",
                Summary= "Involves graphic violence and bloodshed.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "gore-834307",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 21,
                GenreId= 21,
                GenreName= "Gyaru",
                Summary= "Involves characters, usually female, who dress in a flamboyant and trendy style popularized by Japanese youth culture.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "gyaru-576806",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 22,
                GenreId= 22,
                GenreName= "Harem",
                Summary= "Involves one male character surrounded by multiple female characters, often with romantic undertones.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "harem-234937",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 23,
                GenreId= 23,
                GenreName= "Historical",
                Summary= "Set in a specific time period or historical era, often with a focus on accuracy and realism.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "historical-253593",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 24,
                GenreId= 24,
                GenreName= "Horror",
                Summary= "Involves supernatural or otherwise terrifying elements that aim to frighten the reader.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "horror-530733",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 25,
                GenreId= 25,
                GenreName= "Isekai",
                Summary= "Involves characters who are transported to a different world or parallel universe.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "isekai-432467",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 26,
                GenreId= 26,
                GenreName= "Josei",
                Summary= "Targeted at adult women and often features more mature and realistic themes than shoujo manga.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "josei-506035",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 27,
                GenreId= 27,
                GenreName= "Kids",
                Summary= "Targeted at children, often with simple storylines and morals to teach.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "kids-982363",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 28,
                GenreId= 28,
                GenreName= "Korean",
                Summary= "Originates from South Korea or is heavily influenced by Korean culture.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "korean-104879",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 29,
                GenreId= 29,
                GenreName= "Liexing",
                Summary= "Involves characters with superpowers, often set in a martial arts or wuxia-inspired setting.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "liexing-525129",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 30,
                GenreId= 30,
                GenreName= "Loli",
                Summary= "Involves young or childlike female characters, often with a focus on their cuteness.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "loli-569249",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 31,
                GenreId= 31,
                GenreName= "Magic",
                Summary= "Involves characters with magical powers, often in a fantasy setting.",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "magic-574842",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 32,
                GenreId= 32,
                GenreName= "Manga",
                Summary= "Japanese comics that are typically serialized in magazines and collected into tankobon volumes",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "manga-933975",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 33,
                GenreId= 33,
                GenreName= "Manhua",
                Summary= "Chinese comics produced in mainland China, Hong Kong, and Taiwan",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "manhua-244576",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 34,
                GenreId= 34,
                GenreName= "Manhwa",
                Summary= "Korean comics",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "manhwa-350029",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 35,
                GenreId= 35,
                GenreName= "Martial Arts",
                Summary= "Genre focused on martial arts and hand-to-hand combat",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "martial-arts-815171",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 36,
                GenreId= 36,
                GenreName= "Mature",
                Summary= "Contains themes and content that may not be suitable for younger readers",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "mature-520359",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 37,
                GenreId= 37,
                GenreName= "Medical",
                Summary= "Genre focused on medical professionals and their work",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "medical-187458",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 38,
                GenreId= 38,
                GenreName= "Military",
                Summary= "Genre focused on warfare and military operations",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "military-737144",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 39,
                GenreId= 39,
                GenreName= "Moder",
                Summary= "Moderate content that may be suitable for all ages",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "moder-982246",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 40,
                GenreId= 40,
                GenreName= "Monster",
                Summary= "Features creatures or beings that are not human, often with superhuman powers",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "monster-332277",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 41,
                GenreId= 41,
                GenreName= "Monsters",
                Summary= "Similar to Monster, but with multiple non-human creatures as opposed to a single entity",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "monsters-494836",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 42,
                GenreId= 42,
                GenreName= "Murim",
                Summary= "Korean genre focused on martial arts, cultivation, and adventure",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "murim-488176",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 43,
                GenreId= 43,
                GenreName= "Music",
                Summary= "Genre focused on music and musicians",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "music-624300",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 44,
                GenreId= 44,
                GenreName= "Mystery",
                Summary= "Genre focused on solving puzzles or mysteries",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "mystery-471578",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 45,
                GenreId= 45,
                GenreName= "Office workers",
                Summary= "Genre focused on the lives and work of office employees",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "office-workers-331875",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 46,
                GenreId= 46,
                GenreName= "One shot",
                Summary= "A standalone story or short manga, typically not serialized",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "one-shot-132635",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 47,
                GenreId= 47,
                GenreName= "Ping Ping Jun",
                Summary= "A genre of Chinese comics that are typically short and humorous",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "ping-ping-jun-870281",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 48,
                GenreId= 48,
                GenreName= "Police",
                Summary= "Genre focused on police work and investigations",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "police-615043",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 49,
                GenreId= 49,
                GenreName= "Post apocalyptic",
                Summary= "Set in a world after a catastrophic event, often involving survival and rebuilding",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "post-apocalyptic-508983",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 50,
                GenreId= 50,
                GenreName= "Psychological",
                Summary= "Genre focused on the human mind and mental states",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "psychological-566138",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 51,
                GenreId= 51,
                GenreName= "Reincarnation",
                Summary= "Features characters who are reincarnated or transported to another world or time",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "reincarnation-652399",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 52,
                GenreId= 52,
                GenreName= "Reverse",
                Summary= "A story where the gender roles of the main characters are reversed",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "reverse-298615",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 53,
                GenreId= 53,
                GenreName= "Reverse harem",
                Summary= "A genre typically featuring a female protagonist surrounded by multiple male love interests",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "reverse-harem-871746",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 54,
                GenreId= 54,
                GenreName= "Romance",
                Summary= "A genre focused on romantic relationships between characters",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "romance-505289",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 55,
                GenreId= 55,
                GenreName= "Royal family",
                Summary= "A genre that involves royalty, aristocracy, or other nobility",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "royal-family-209618",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 56,
                GenreId= 56,
                GenreName= "School Life",
                Summary= "A genre focused on the daily lives of students attending school",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "school-life-515479",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 57,
                GenreId= 57,
                GenreName= "Sci-fi",
                Summary= "A genre that involves speculative or imaginary concepts related to science and technology",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "sci-fi-735975",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 58,
                GenreId= 58,
                GenreName= "Seinen",
                Summary= "A genre targeted towards adult men",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "seinen-619518",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 59,
                GenreId= 59,
                GenreName= "Shoujo",
                Summary= "A genre targeted towards teenage girls",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "shoujo-733458",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 60,
                GenreId= 60,
                GenreName= "Shoujo ai",
                Summary= "A genre focused on romantic relationships between female characters",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "shoujo-ai-648025",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 61,
                GenreId= 61,
                GenreName= "Shounen",
                Summary= "A genre targeted towards teenage boys",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "shounen-737005",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 62,
                GenreId= 62,
                GenreName= "Shounen ai",
                Summary= "A genre focused on romantic relationships between male characters",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "shounen-ai-879165",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 63,
                GenreId= 63,
                GenreName= "Slice of Life",
                Summary= "A genre focused on everyday life experiences",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "slice-of-life-940599",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 64,
                GenreId= 64,
                GenreName= "Smut",
                Summary= "A genre that includes explicit sexual content",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "smut-635916",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 65,
                GenreId= 65,
                GenreName= "Sports",
                Summary= "A genre that involves sports or athletic competitions",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "sports-417542",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 66,
                GenreId= 66,
                GenreName= "Super power",
                Summary= "A genre that involves characters with supernatural abilities",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "super-power-853064",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 67,
                GenreId= 67,
                GenreName= "Supernatural",
                Summary= "A genre that involves supernatural or paranormal elements",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "supernatural-814683",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 68,
                GenreId= 68,
                GenreName= "Survival",
                Summary= "A genre that involves characters struggling to survive in a challenging environment",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "survival-268998",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 69,
                GenreId= 69,
                GenreName= "Thriller",
                Summary= "A genre that involves suspense, excitement, and high tension",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "thriller-499105",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 70,
                GenreId= 70,
                GenreName= "Time Travel",
                Summary= "A genre that involves characters traveling through time",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "time-travel-766708",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 71,
                GenreId= 71,
                GenreName= "Tragedy",
                Summary= "A genre that involves sorrowful or disastrous events",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "tragedy-858685",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 72,
                GenreId= 72,
                GenreName= "Violence",
                Summary= "Contains explicit and graphic depictions of violent acts, often with a focus on gore and brutality",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "violence-746986",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 73,
                GenreId= 73,
                GenreName= "Webtoon",
                Summary= "A type of digital comic that originated in South Korea and is published in a vertical scrolling format optimized for viewing on mobile devices",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "webtoon-740813",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 74,
                GenreId= 74,
                GenreName= "Webtoons",
                Summary= "A platform for publishing and reading webtoons, which are digital comics that originated in South Korea and are published in a vertical scrolling format optimized for viewing on mobile devices",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "webtoons-298763",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 75,
                GenreId= 75,
                GenreName= "Yaoi",
                Summary= "A genre focused on male-male romantic relationships, often with explicit sexual content",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "yaoi-986343",
                CreatedBy = adminId
              },
              new GenreDetail() {
                GenreDetailId= 76,
                GenreId= 76,
                GenreName= "Zombies",
                Summary= "Features zombies or other undead creatures as a significant aspect of the story, often with a focus on survival and/or horror",
                GenreSEOSummary= "Updating SEO Summary - HIKICOMIC",
                GenreSEOTitle= "Updating SEO Title - HIKICOMIC",
                GenreSEOAlias= "zombies-506247",
                CreatedBy = adminId
              }
            };


            int countGenre = genreDetails.Count;

            var genres = new List<Genre>();

            for (int i = 0; i < countGenre; i++)
            {
                genres.Add(new Genre()
                {
                    GenreId = i + 2,
                    GenreParentId = null,
                    GenreImageURL = "",
                    IsShowHome = false,
                    IsDeleted = false,
                    DateCreated = DateTime.Now,
                    CreatedBy = adminId,
                });
            }

            modelBuilder.Entity<Genre>().HasData(genres);
            modelBuilder.Entity<GenreDetail>().HasData(genreDetails);

            #endregion
        }

        private static string ToSEOAlias(string value)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = value.Normalize(NormalizationForm.FormD);
            value = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

            Regex trimmer = new Regex(@"\s\s+");

            value = trimmer.Replace(value, " ");

            return value;
        }

        public static string ConvertTitleToSEOAlias(string value, bool isSolidus = false, bool isChapter = false)
        {
            if (isChapter)
            {
                int index = value.IndexOf(":");
                if (index != -1)
                    value = value.Substring(0, index);
            }
            else
                value = value.Replace(":", "");

            value = value.Replace(".", "");
            value = value.Replace(",", "");
            value = value.Replace("'", "");
            value = value.Replace("’", "");

            //
            List<string> charSEOAlias = new List<string>();
            List<bool> specials = new List<bool>();

            foreach (var item in value)
            {
                charSEOAlias.Add(item.ToString());
                int code = (int)item;
                if ((code > 300 && code <= 7680) || code > 8200)
                    specials.Add(true);
                else
                    specials.Add(false);
            }

            Random rd = new Random();

            List<string> output = new List<string>();
            int length = charSEOAlias.Count;

            for (int i = 0; i < length; i++)
            {
                if (!specials[i])
                    output.Add(ToSEOAlias(charSEOAlias[i]));
                else
                    output.Add(charSEOAlias[i]);
            }

            value = String.Join("", output);

            if (!isSolidus)
                value = value.Replace(" ", "-") + "-" + rd.Next(100000, 999999);
            else
                value = "/" + value.Replace(" ", "-") + "-" + rd.Next(100000, 999999);

            return value.ToLower();
        }
    }
}

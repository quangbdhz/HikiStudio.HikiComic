using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiComic.Data.Migrations
{
    public partial class updatedbversion31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Alternative = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(3800)", maxLength: 3800, nullable: true),
                    ArtistSEOSummary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ArtistSEOTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ArtistSEOAlias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Alternative = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(3800)", maxLength: 3800, nullable: true),
                    AuthorSEOSummary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AuthorSEOTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AuthorSEOAlias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Comics",
                columns: table => new
                {
                    ComicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComicName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Alternative = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ComicCoverImageURL = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CountLike = table.Column<int>(type: "int", nullable: false),
                    CountFollow = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CountRating = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Rating = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    NewChapterId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comics", x => x.ComicId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreParentId = table.Column<int>(type: "int", nullable: true),
                    IsShowHome = table.Column<bool>(type: "bit", nullable: false),
                    GenreImageURL = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceConfigs",
                columns: table => new
                {
                    ServiceConfigId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceConfigName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceConfigs", x => x.ServiceConfigId);
                });

            migrationBuilder.CreateTable(
                name: "ServicePrices",
                columns: table => new
                {
                    ServicePriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicePriceName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePrices", x => x.ServicePriceId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "TempAppUsers",
                columns: table => new
                {
                    TempAppUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    OTPExpires = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempAppUsers", x => x.TempAppUserId);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoleClaims_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserImageURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    RefreshToken = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OTP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    OTPExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsOTPVerified = table.Column<bool>(type: "bit", nullable: true),
                    AppUserTypeId = table.Column<int>(type: "int", nullable: false),
                    IsCreateAppUserWithThirdParty = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreDetails",
                columns: table => new
                {
                    GenreDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    GenreName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    GenreSEOSummary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GenreSEOTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    GenreSEOAlias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreDetails", x => x.GenreDetailId);
                    table.ForeignKey(
                        name: "FK_GenreDetails_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComicDetails",
                columns: table => new
                {
                    ComicDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComicId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ComicDetailCoverImageURL = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(3800)", maxLength: 3800, nullable: false),
                    ComicSEOSummary = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ComicSEOTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ComicSEOAlias = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicDetails", x => x.ComicDetailId);
                    table.ForeignKey(
                        name: "FK_ComicDetails_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "ComicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicDetails_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Experienced = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    MoreInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CoinsLeft = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    CoinsSpent = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    CoinsDeposited = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    CoinsReceived = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 6, 20, 21, 44, 47, 801, DateTimeKind.Local).AddTicks(3914)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserClaims_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserDevices",
                columns: table => new
                {
                    AppUserDeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FCMDeviceToken = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DeviceOS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserDevices", x => x.AppUserDeviceId);
                    table.ForeignKey(
                        name: "FK_AppUserDevices_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    AppUserLoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.AppUserLoginId);
                    table.ForeignKey(
                        name: "FK_AppUserLogins_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserOTPs",
                columns: table => new
                {
                    AppUserOTPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OTPType = table.Column<int>(type: "int", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OTPExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOTPVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserOTPs", x => x.AppUserOTPId);
                    table.ForeignKey(
                        name: "FK_AppUserOTPs_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId, x.AppUserRoleId });
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    AppUserTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.AppUserTokenId);
                    table.ForeignKey(
                        name: "FK_AppUserTokens_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComicId = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true),
                    Like = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Dislike = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CommentContent = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 6, 20, 21, 44, 47, 805, DateTimeKind.Local).AddTicks(6885))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "ComicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ComicId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Actions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NotificationPriority = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_AppUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "ComicId");
                });

            migrationBuilder.CreateTable(
                name: "UserComicFollowings",
                columns: table => new
                {
                    UserComicFollowingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComicId = table.Column<int>(type: "int", nullable: false),
                    DateFollow = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComicFollowings", x => x.UserComicFollowingId);
                    table.ForeignKey(
                        name: "FK_UserComicFollowings_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserComicFollowings_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "ComicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserComicLikes",
                columns: table => new
                {
                    UserComicLikeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComicId = table.Column<int>(type: "int", nullable: false),
                    Liked = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateLiked = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 6, 20, 21, 44, 47, 806, DateTimeKind.Local).AddTicks(3179))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComicLikes", x => x.UserComicLikeId);
                    table.ForeignKey(
                        name: "FK_UserComicLikes_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserComicLikes_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "ComicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserComicRatings",
                columns: table => new
                {
                    UserComicRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComicId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    DateRating = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 6, 20, 21, 44, 47, 806, DateTimeKind.Local).AddTicks(6033))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComicRatings", x => x.UserComicRatingId);
                    table.ForeignKey(
                        name: "FK_UserComicRatings_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserComicRatings_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "ComicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistInComicDetails",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    ComicDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistInComicDetails", x => new { x.ArtistId, x.ComicDetailId });
                    table.ForeignKey(
                        name: "FK_ArtistInComicDetails_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistInComicDetails_ComicDetails_ComicDetailId",
                        column: x => x.ComicDetailId,
                        principalTable: "ComicDetails",
                        principalColumn: "ComicDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorInComicDetails",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    ComicDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorInComicDetails", x => new { x.AuthorId, x.ComicDetailId });
                    table.ForeignKey(
                        name: "FK_AuthorInComicDetails_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorInComicDetails_ComicDetails_ComicDetailId",
                        column: x => x.ComicDetailId,
                        principalTable: "ComicDetails",
                        principalColumn: "ComicDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    ChapterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComicDetailId = table.Column<int>(type: "int", nullable: false),
                    ChapterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SerialChapterOfComic = table.Column<int>(type: "int", nullable: false, defaultValue: -1),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ComicSEOAlias = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    ChapterSEOAlias = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.ChapterId);
                    table.ForeignKey(
                        name: "FK_Chapters_ComicDetails_ComicDetailId",
                        column: x => x.ComicDetailId,
                        principalTable: "ComicDetails",
                        principalColumn: "ComicDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreInComicDetails",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ComicDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreInComicDetails", x => new { x.GenreId, x.ComicDetailId });
                    table.ForeignKey(
                        name: "FK_GenreInComicDetails_ComicDetails_ComicDetailId",
                        column: x => x.ComicDetailId,
                        principalTable: "ComicDetails",
                        principalColumn: "ComicDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreInComicDetails_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCoinDepositHistories",
                columns: table => new
                {
                    UserCoinDepositHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    DepositAmount = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    DepositMethodId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DepositStatusId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCoinDepositHistories", x => x.UserCoinDepositHistoryId);
                    table.ForeignKey(
                        name: "FK_UserCoinDepositHistories_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCoinUsageHistories",
                columns: table => new
                {
                    UserCoinUsageHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    UsageAmount = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    UsageMethodId = table.Column<int>(type: "int", nullable: false),
                    UsageStatusId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCoinUsageHistories", x => x.UserCoinUsageHistoryId);
                    table.ForeignKey(
                        name: "FK_UserCoinUsageHistories_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterImageURLs",
                columns: table => new
                {
                    ChapterImageURLId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "varchar(7800)", unicode: false, maxLength: 7800, nullable: false),
                    SerialImageURLOfChapter = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterImageURLs", x => x.ChapterImageURLId);
                    table.ForeignKey(
                        name: "FK_ChapterImageURLs_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "ChapterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserComicReadingHistories",
                columns: table => new
                {
                    UserComicReadingHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComicId = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    DateRead = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComicReadingHistories", x => x.UserComicReadingHistoryId);
                    table.ForeignKey(
                        name: "FK_UserComicReadingHistories_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserComicReadingHistories_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "ChapterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserComicReadingHistories_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "ComicId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserComicPurchases",
                columns: table => new
                {
                    UserComicPurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCoinUsageHistoryId = table.Column<int>(type: "int", nullable: false),
                    ComicId = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    MoreInfo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComicPurchases", x => x.UserComicPurchaseId);
                    table.ForeignKey(
                        name: "FK_UserComicPurchases_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "ChapterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserComicPurchases_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "ComicId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserComicPurchases_UserCoinUsageHistories_UserCoinUsageHistoryId",
                        column: x => x.UserCoinUsageHistoryId,
                        principalTable: "UserCoinUsageHistories",
                        principalColumn: "UserCoinUsageHistoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Name", "NormalizedName", "Priority", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), "abae83ae-b93f-4db3-ac5f-5ba5444ecc0d", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Reader Role", "reader", "READER", 1, null },
                    { new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), "649b262b-67b9-403a-9844-721d996fa966", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Creator Role", "creator", "CREATOR", 2, null },
                    { new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), "24190d35-1e77-49c0-ae16-a34044516d4c", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Team Members Role", "teamMembers", "TEAMMEMBERS", 3, null },
                    { new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), "fadadc12-56b0-413b-bc13-2224841d2f31", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Administrator Role", "admin", "ADMIN", 4, null }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Alternative", "ArtistName", "ArtistSEOAlias", "ArtistSEOSummary", "ArtistSEOTitle", "CreatedBy", "DateCreated", "DateUpdated", "Summary", "UpdatedBy" },
                values: new object[] { 1, "Updating", "Updating", "updating-349149", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 853, DateTimeKind.Local).AddTicks(9822), null, "Updating Summary - HIKICOMIC", null });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Alternative", "AuthorName", "AuthorSEOAlias", "AuthorSEOSummary", "AuthorSEOTitle", "CreatedBy", "DateCreated", "DateUpdated", "Summary", "UpdatedBy" },
                values: new object[] { 1, "Updating", "Updating", "updating-713713", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 853, DateTimeKind.Local).AddTicks(9885), null, "Updating Summary - HIKICOMIC", null });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "CreatedBy", "DateCreated", "DateUpdated", "GenderName", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8260), null, "Male", null },
                    { 2, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8263), null, "Female", null },
                    { 3, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8264), null, "Other", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "CreatedBy", "DateCreated", "DateUpdated", "GenreImageURL", "GenreParentId", "IsShowHome", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 853, DateTimeKind.Local).AddTicks(9928), null, "", null, false, null },
                    { 2, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(136), null, "", null, false, null },
                    { 3, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(141), null, "", null, false, null },
                    { 4, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(143), null, "", null, false, null },
                    { 5, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(144), null, "", null, false, null },
                    { 6, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(146), null, "", null, false, null },
                    { 7, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(149), null, "", null, false, null },
                    { 8, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(150), null, "", null, false, null },
                    { 9, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(152), null, "", null, false, null },
                    { 10, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(153), null, "", null, false, null },
                    { 11, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(156), null, "", null, false, null },
                    { 12, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(157), null, "", null, false, null },
                    { 13, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(159), null, "", null, false, null },
                    { 14, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(160), null, "", null, false, null },
                    { 15, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(161), null, "", null, false, null },
                    { 16, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(163), null, "", null, false, null },
                    { 17, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(164), null, "", null, false, null },
                    { 18, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(165), null, "", null, false, null },
                    { 19, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(168), null, "", null, false, null },
                    { 20, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(169), null, "", null, false, null },
                    { 21, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(171), null, "", null, false, null },
                    { 22, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(172), null, "", null, false, null },
                    { 23, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(174), null, "", null, false, null },
                    { 24, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(175), null, "", null, false, null },
                    { 25, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(176), null, "", null, false, null },
                    { 26, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(178), null, "", null, false, null },
                    { 27, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(179), null, "", null, false, null },
                    { 28, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(191), null, "", null, false, null },
                    { 29, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(204), null, "", null, false, null },
                    { 30, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(206), null, "", null, false, null },
                    { 31, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(213), null, "", null, false, null },
                    { 32, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(214), null, "", null, false, null },
                    { 33, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(216), null, "", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "CreatedBy", "DateCreated", "DateUpdated", "GenreImageURL", "GenreParentId", "IsShowHome", "UpdatedBy" },
                values: new object[,]
                {
                    { 34, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(217), null, "", null, false, null },
                    { 35, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(220), null, "", null, false, null },
                    { 36, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(222), null, "", null, false, null },
                    { 37, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(223), null, "", null, false, null },
                    { 38, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(225), null, "", null, false, null },
                    { 39, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(226), null, "", null, false, null },
                    { 40, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(227), null, "", null, false, null },
                    { 41, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(229), null, "", null, false, null },
                    { 42, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(230), null, "", null, false, null },
                    { 43, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(232), null, "", null, false, null },
                    { 44, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(233), null, "", null, false, null },
                    { 45, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(234), null, "", null, false, null },
                    { 46, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(236), null, "", null, false, null },
                    { 47, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(237), null, "", null, false, null },
                    { 48, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(239), null, "", null, false, null },
                    { 49, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(240), null, "", null, false, null },
                    { 50, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(242), null, "", null, false, null },
                    { 51, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(243), null, "", null, false, null },
                    { 52, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(244), null, "", null, false, null },
                    { 53, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(246), null, "", null, false, null },
                    { 54, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(247), null, "", null, false, null },
                    { 55, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(248), null, "", null, false, null },
                    { 56, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(250), null, "", null, false, null },
                    { 57, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(251), null, "", null, false, null },
                    { 58, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(253), null, "", null, false, null },
                    { 59, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(254), null, "", null, false, null },
                    { 60, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(255), null, "", null, false, null },
                    { 61, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(257), null, "", null, false, null },
                    { 62, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(258), null, "", null, false, null },
                    { 63, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(259), null, "", null, false, null },
                    { 64, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(261), null, "", null, false, null },
                    { 65, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(262), null, "", null, false, null },
                    { 66, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(264), null, "", null, false, null },
                    { 67, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(266), null, "", null, false, null },
                    { 68, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(268), null, "", null, false, null },
                    { 69, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(269), null, "", null, false, null },
                    { 70, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(270), null, "", null, false, null },
                    { 71, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(272), null, "", null, false, null },
                    { 72, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(273), null, "", null, false, null },
                    { 73, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(275), null, "", null, false, null },
                    { 74, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(276), null, "", null, false, null },
                    { 75, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(277), null, "", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "CreatedBy", "DateCreated", "DateUpdated", "GenreImageURL", "GenreParentId", "IsShowHome", "UpdatedBy" },
                values: new object[] { 76, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(279), null, "", null, false, null });

            migrationBuilder.InsertData(
                table: "ServiceConfigs",
                columns: new[] { "ServiceConfigId", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Note", "ServiceConfigName", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 1, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8313), null, null, null, "Number of comic chapters for free", null, 3 },
                    { 2, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8315), null, null, null, "Conversion ratio COINS", null, 1000 }
                });

            migrationBuilder.InsertData(
                table: "ServicePrices",
                columns: new[] { "ServicePriceId", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Price", "ServicePriceName", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8287), null, null, 2.0, "Read Comics", null },
                    { 2, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8288), null, null, 5.0, "Change Nickname", null },
                    { 3, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8290), null, null, 10.0, "Change Avatar", null }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "CreatedBy", "DateCreated", "DateUpdated", "StatusName", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8090), null, "New", null },
                    { 2, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8096), null, "Ongoing", null },
                    { 3, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8098), null, "Drop", null },
                    { 4, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8099), null, "Completed", null }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "AppUserTypeId", "ConcurrencyStamp", "DOB", "DateCreated", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsCreateAppUserWithThirdParty", "IsOTPVerified", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "OTPExpires", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserImageURL", "UserName" },
                values: new object[,]
                {
                    { new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"), 0, 0, "ecfe8006-83a1-440e-82f1-41ec639e99b6", new DateTime(2000, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hikistudio@hiki.space", true, "Admin", 2, false, null, "HikiStudio", false, null, "HIKISTUDIO@HIKI.SPACE", "HIKISTUDIO", null, null, "AQAAAAEAACcQAAAAEPBruOBs1Jy2UyA9+LBiI3JUtOIsiDmbnuZgD5cxfSOzTV2/wCoFYtdJnsSNLaqqFg==", null, false, null, "", null, null, false, "", "hikistudio" },
                    { new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), 0, 0, "8cf57a15-61e4-44fe-9bf2-23ad51231672", new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tranquangbdhz@gmail.com", true, "Tran", 1, false, null, "Quang", false, null, "TRANQUANGBDHZ@GMAIL.COM", "ADMIN", null, null, "AQAAAAEAACcQAAAAELdW4a7uC2vsZfx8nxf3NcFfw4VEUOkemyTI+w9DISngDu7awpoCLo9iky81qS6L8Q==", null, false, null, "", null, null, false, "", "quangbdhz" },
                    { new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"), 0, 0, "6d6d0efb-fee6-41fc-825c-29f86942625e", new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "yukino@hiki.space", true, "Yukino", 1, false, null, "HikiStudio", false, null, "READER@HIKI.SPACE", "YUKINO", null, null, "AQAAAAEAACcQAAAAEOZi2ik/Ky7BMZ0bH0ln3Y6+kPvJ/MI/TGjDIN2yGuXFM3Zgnsv2d9ouMXk5vKdRTQ==", null, false, null, "", null, null, false, "", "yukino" },
                    { new Guid("4354acbc-a32a-4a28-b865-deb49695171f"), 0, 0, "de9c6958-10fc-4ed4-9cff-144ec901cdc0", new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "reader@hiki.space", true, "Reader", 3, false, null, "HikiStudio", false, null, "READER@HIKI.SPACE", "READER", null, null, "AQAAAAEAACcQAAAAEOvnG5dAhBS8SSnsvxHULf26QiGA63Y9IBD76GMQ+yWvgvPjO/otPWrCxYvsCtDaDQ==", null, false, null, "", null, null, false, "", "reader" },
                    { new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"), 0, 0, "d38a0ccb-7a4f-4fbc-a21f-fe651fef5eaa", new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "creator@hiki.space", true, "Creator", 2, false, null, "HikiStudio", false, null, "CREATOR@HIKI.SPACE", "CREATOR", null, null, "AQAAAAEAACcQAAAAEOf24BxLpjivPKGncH5wfq5fcYrjDpvoB1taVRTCKhXKQuAEqjLq7q1KWeJPvxnppQ==", null, false, null, "", null, null, false, "", "creator" }
                });

            migrationBuilder.InsertData(
                table: "GenreDetails",
                columns: new[] { "GenreDetailId", "CreatedBy", "DateCreated", "DateUpdated", "GenreId", "GenreName", "GenreSEOAlias", "GenreSEOSummary", "GenreSEOTitle", "Summary", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Updating", "updating-391314", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Updating Summary - HIKICOMIC", null },
                    { 2, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Action", "action-304301", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre focused on physical action, often involving fighting or combat scenes. Action stories are typically fast-paced and thrilling, with a lot of movement and high stakes.", null },
                    { 3, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "Adaptation", "adaptation-934546", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that is based on existing source material, such as a novel, manga, or video game. Adaptations can be faithful or loose, and can vary greatly in terms of how closely they follow the source material.", null },
                    { 4, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "Adult", "adult-774714", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that contains explicit sexual content and/or graphic violence. Adult stories are typically intended for mature audiences only, and may explore taboo or controversial subjects.", null },
                    { 5, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, "Adventure", "adventure-300184", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre focused on exploration, often involving exotic locations, treasure hunting, or quests. Adventure stories are typically exciting and full of surprises, with a strong sense of adventure and discovery.", null },
                    { 6, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, "Animal", "animal-305529", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that features animals as main characters or as a significant aspect of the story. Animal stories can be anthropomorphic or realistic, and often explore themes related to nature, survival, and the animal kingdom.", null },
                    { 7, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, "Chinese", "chinese-993685", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that originates from China or is heavily influenced by Chinese culture. Chinese stories can vary greatly in terms of style and subject matter, but often feature elements such as martial arts, mythology, and historical drama.", null },
                    { 8, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, "Comedy", "comedy-262691", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre focused on humor and comedic situations. Comedy stories can range from light-hearted and silly to dark and satirical, and often involve witty banter, physical comedy, or absurd situations.", null },
                    { 9, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, "Comic", "comic-547961", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that originates from comic strips or comic books. Comic stories can be funny or serious, and often feature unique visual styles, such as exaggerated character designs, bold colors, and dynamic panel layouts.", null },
                    { 10, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, "Cooking", "cooking-860807", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre focused on cooking and food preparation. Cooking stories often explore the art and science of cooking, as well as the cultural and social significance of food. They may also involve elements of drama, romance, or competition.", null },
                    { 11, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, "Crime", "crime-819021", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre focused on crime and criminal activity. Crime stories can be gritty and realistic or stylized and pulpy, and often involve elements such as detectives, heists, or organized crime.", null },
                    { 12, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12, "Crossdressing", "crossdressing-730811", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Involves characters who dress in clothing traditionally associated with the opposite gender.", null },
                    { 13, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 13, "Demons", "demons-698466", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Involves supernatural creatures who are often malevolent towards humans.", null },
                    { 14, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 14, "Drama", "drama-310439", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Focuses on realistic, often emotional, conflicts between characters.", null },
                    { 15, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, "Ecchi", "ecchi-837736", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Contains sexual themes and humor, but is less explicit than hentai.", null },
                    { 16, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 16, "Fantasy", "fantasy-445140", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Involves elements of magic, supernatural powers, and mythical creatures.", null },
                    { 17, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 17, "Full Color", "full-color-870413", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Comics or manga that are colored, rather than black and white.", null },
                    { 18, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 18, "Game", "game-107608", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Involves characters playing games, whether video games or other types.", null },
                    { 19, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 19, "Gender Bender", "gender-bender-321894", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Involves characters who switch or blur gender roles, often through magic or supernatural means.", null },
                    { 20, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 20, "Gore", "gore-834307", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Involves graphic violence and bloodshed.", null },
                    { 21, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 21, "Gyaru", "gyaru-576806", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Involves characters, usually female, who dress in a flamboyant and trendy style popularized by Japanese youth culture.", null },
                    { 22, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 22, "Harem", "harem-234937", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Involves one male character surrounded by multiple female characters, often with romantic undertones.", null },
                    { 23, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 23, "Historical", "historical-253593", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Set in a specific time period or historical era, often with a focus on accuracy and realism.", null },
                    { 24, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 24, "Horror", "horror-530733", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Involves supernatural or otherwise terrifying elements that aim to frighten the reader.", null },
                    { 25, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 25, "Isekai", "isekai-432467", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Involves characters who are transported to a different world or parallel universe.", null },
                    { 26, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 26, "Josei", "josei-506035", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Targeted at adult women and often features more mature and realistic themes than shoujo manga.", null },
                    { 27, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 27, "Kids", "kids-982363", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Targeted at children, often with simple storylines and morals to teach.", null },
                    { 28, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 28, "Korean", "korean-104879", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Originates from South Korea or is heavily influenced by Korean culture.", null },
                    { 29, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 29, "Liexing", "liexing-525129", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Involves characters with superpowers, often set in a martial arts or wuxia-inspired setting.", null },
                    { 30, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 30, "Loli", "loli-569249", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Involves young or childlike female characters, often with a focus on their cuteness.", null },
                    { 31, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 31, "Magic", "magic-574842", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Involves characters with magical powers, often in a fantasy setting.", null },
                    { 32, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 32, "Manga", "manga-933975", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Japanese comics that are typically serialized in magazines and collected into tankobon volumes", null },
                    { 33, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 33, "Manhua", "manhua-244576", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Chinese comics produced in mainland China, Hong Kong, and Taiwan", null },
                    { 34, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 34, "Manhwa", "manhwa-350029", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Korean comics", null },
                    { 35, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 35, "Martial Arts", "martial-arts-815171", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Genre focused on martial arts and hand-to-hand combat", null },
                    { 36, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 36, "Mature", "mature-520359", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Contains themes and content that may not be suitable for younger readers", null },
                    { 37, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 37, "Medical", "medical-187458", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Genre focused on medical professionals and their work", null }
                });

            migrationBuilder.InsertData(
                table: "GenreDetails",
                columns: new[] { "GenreDetailId", "CreatedBy", "DateCreated", "DateUpdated", "GenreId", "GenreName", "GenreSEOAlias", "GenreSEOSummary", "GenreSEOTitle", "Summary", "UpdatedBy" },
                values: new object[,]
                {
                    { 38, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 38, "Military", "military-737144", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Genre focused on warfare and military operations", null },
                    { 39, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 39, "Moder", "moder-982246", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Moderate content that may be suitable for all ages", null },
                    { 40, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 40, "Monster", "monster-332277", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Features creatures or beings that are not human, often with superhuman powers", null },
                    { 41, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 41, "Monsters", "monsters-494836", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Similar to Monster, but with multiple non-human creatures as opposed to a single entity", null },
                    { 42, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 42, "Murim", "murim-488176", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Korean genre focused on martial arts, cultivation, and adventure", null },
                    { 43, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 43, "Music", "music-624300", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Genre focused on music and musicians", null },
                    { 44, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 44, "Mystery", "mystery-471578", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Genre focused on solving puzzles or mysteries", null },
                    { 45, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 45, "Office workers", "office-workers-331875", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Genre focused on the lives and work of office employees", null },
                    { 46, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 46, "One shot", "one-shot-132635", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A standalone story or short manga, typically not serialized", null },
                    { 47, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 47, "Ping Ping Jun", "ping-ping-jun-870281", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre of Chinese comics that are typically short and humorous", null },
                    { 48, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 48, "Police", "police-615043", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Genre focused on police work and investigations", null },
                    { 49, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 49, "Post apocalyptic", "post-apocalyptic-508983", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Set in a world after a catastrophic event, often involving survival and rebuilding", null },
                    { 50, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, "Psychological", "psychological-566138", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Genre focused on the human mind and mental states", null },
                    { 51, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 51, "Reincarnation", "reincarnation-652399", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Features characters who are reincarnated or transported to another world or time", null },
                    { 52, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 52, "Reverse", "reverse-298615", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A story where the gender roles of the main characters are reversed", null },
                    { 53, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 53, "Reverse harem", "reverse-harem-871746", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre typically featuring a female protagonist surrounded by multiple male love interests", null },
                    { 54, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 54, "Romance", "romance-505289", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre focused on romantic relationships between characters", null },
                    { 55, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 55, "Royal family", "royal-family-209618", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that involves royalty, aristocracy, or other nobility", null },
                    { 56, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 56, "School Life", "school-life-515479", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre focused on the daily lives of students attending school", null },
                    { 57, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 57, "Sci-fi", "sci-fi-735975", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that involves speculative or imaginary concepts related to science and technology", null },
                    { 58, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 58, "Seinen", "seinen-619518", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre targeted towards adult men", null },
                    { 59, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 59, "Shoujo", "shoujo-733458", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre targeted towards teenage girls", null },
                    { 60, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 60, "Shoujo ai", "shoujo-ai-648025", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre focused on romantic relationships between female characters", null },
                    { 61, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 61, "Shounen", "shounen-737005", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre targeted towards teenage boys", null },
                    { 62, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 62, "Shounen ai", "shounen-ai-879165", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre focused on romantic relationships between male characters", null },
                    { 63, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 63, "Slice of Life", "slice-of-life-940599", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre focused on everyday life experiences", null },
                    { 64, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 64, "Smut", "smut-635916", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that includes explicit sexual content", null },
                    { 65, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 65, "Sports", "sports-417542", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that involves sports or athletic competitions", null },
                    { 66, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 66, "Super power", "super-power-853064", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that involves characters with supernatural abilities", null },
                    { 67, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 67, "Supernatural", "supernatural-814683", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that involves supernatural or paranormal elements", null },
                    { 68, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 68, "Survival", "survival-268998", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that involves characters struggling to survive in a challenging environment", null },
                    { 69, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 69, "Thriller", "thriller-499105", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that involves suspense, excitement, and high tension", null },
                    { 70, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 70, "Time Travel", "time-travel-766708", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that involves characters traveling through time", null },
                    { 71, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 71, "Tragedy", "tragedy-858685", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre that involves sorrowful or disastrous events", null },
                    { 72, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 72, "Violence", "violence-746986", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Contains explicit and graphic depictions of violent acts, often with a focus on gore and brutality", null },
                    { 73, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 73, "Webtoon", "webtoon-740813", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A type of digital comic that originated in South Korea and is published in a vertical scrolling format optimized for viewing on mobile devices", null },
                    { 74, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 74, "Webtoons", "webtoons-298763", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A platform for publishing and reading webtoons, which are digital comics that originated in South Korea and are published in a vertical scrolling format optimized for viewing on mobile devices", null },
                    { 75, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 75, "Yaoi", "yaoi-986343", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "A genre focused on male-male romantic relationships, often with explicit sexual content", null },
                    { 76, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 76, "Zombies", "zombies-506247", "Updating SEO Summary - HIKICOMIC", "Updating SEO Title - HIKICOMIC", "Features zombies or other undead creatures as a significant aspect of the story, often with a focus on survival and/or horror", null }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AppUserId", "DateCreated", "MoreInfo", "Nickname" },
                values: new object[,]
                {
                    { 1, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", null },
                    { 2, new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Supper VIP PRO", null },
                    { 3, new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "team members", null },
                    { 4, new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "creator", null },
                    { 5, new Guid("4354acbc-a32a-4a28-b865-deb49695171f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "reader", null }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8211294c-647f-42c7-8c48-2a704d890933"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("0c036207-511d-422b-94bb-7bafb31097ce"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("e99c9797-334f-43b7-a4c4-30fb77b4fc25"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("7ba4ec51-e792-4e11-a13e-bfbe00f73889"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("159d0b3b-7567-4b18-8e56-59b20cb94eae"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AppUserId",
                table: "Accounts",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaims_RoleId",
                table: "AppRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AppRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaims_UserId",
                table: "AppUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDevices_AppUserId",
                table: "AppUserDevices",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserLogins_UserId",
                table: "AppUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserOTPs_AppUserId",
                table: "AppUserOTPs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_RoleId",
                table: "AppUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_GenderId",
                table: "AppUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AppUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTokens_UserId",
                table: "AppUserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistInComicDetails_ComicDetailId",
                table: "ArtistInComicDetails",
                column: "ComicDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorInComicDetails_ComicDetailId",
                table: "AuthorInComicDetails",
                column: "ComicDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterImageURLs_ChapterId",
                table: "ChapterImageURLs",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_ComicDetailId",
                table: "Chapters",
                column: "ComicDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicDetails_ComicId",
                table: "ComicDetails",
                column: "ComicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComicDetails_StatusId",
                table: "ComicDetails",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ComicId",
                table: "Comments",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreDetails_GenreId",
                table: "GenreDetails",
                column: "GenreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenreInComicDetails_ComicDetailId",
                table: "GenreInComicDetails",
                column: "ComicDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ComicId",
                table: "Notifications",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UpdatedBy",
                table: "Notifications",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserCoinDepositHistories_AccountId",
                table: "UserCoinDepositHistories",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCoinUsageHistories_AccountId",
                table: "UserCoinUsageHistories",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComicFollowings_AppUserId",
                table: "UserComicFollowings",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComicFollowings_ComicId",
                table: "UserComicFollowings",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComicLikes_AppUserId",
                table: "UserComicLikes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComicLikes_ComicId",
                table: "UserComicLikes",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComicPurchases_ChapterId",
                table: "UserComicPurchases",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComicPurchases_ComicId",
                table: "UserComicPurchases",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComicPurchases_UserCoinUsageHistoryId",
                table: "UserComicPurchases",
                column: "UserCoinUsageHistoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserComicRatings_AppUserId",
                table: "UserComicRatings",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComicRatings_ComicId",
                table: "UserComicRatings",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComicReadingHistories_AppUserId",
                table: "UserComicReadingHistories",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComicReadingHistories_ChapterId",
                table: "UserComicReadingHistories",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComicReadingHistories_ComicId",
                table: "UserComicReadingHistories",
                column: "ComicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserDevices");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserOTPs");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "ArtistInComicDetails");

            migrationBuilder.DropTable(
                name: "AuthorInComicDetails");

            migrationBuilder.DropTable(
                name: "ChapterImageURLs");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "GenreDetails");

            migrationBuilder.DropTable(
                name: "GenreInComicDetails");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ServiceConfigs");

            migrationBuilder.DropTable(
                name: "ServicePrices");

            migrationBuilder.DropTable(
                name: "TempAppUsers");

            migrationBuilder.DropTable(
                name: "UserCoinDepositHistories");

            migrationBuilder.DropTable(
                name: "UserComicFollowings");

            migrationBuilder.DropTable(
                name: "UserComicLikes");

            migrationBuilder.DropTable(
                name: "UserComicPurchases");

            migrationBuilder.DropTable(
                name: "UserComicRatings");

            migrationBuilder.DropTable(
                name: "UserComicReadingHistories");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "UserCoinUsageHistories");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ComicDetails");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Comics");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}

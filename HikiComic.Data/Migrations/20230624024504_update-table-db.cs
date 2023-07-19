using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiComic.Data.Migrations
{
    public partial class updatetabledb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8211294c-647f-42c7-8c48-2a704d890933"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0c036207-511d-422b-94bb-7bafb31097ce"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e99c9797-334f-43b7-a4c4-30fb77b4fc25"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7ba4ec51-e792-4e11-a13e-bfbe00f73889"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("159d0b3b-7567-4b18-8e56-59b20cb94eae"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 578, DateTimeKind.Local).AddTicks(2608),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 20, 21, 44, 47, 806, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 577, DateTimeKind.Local).AddTicks(9925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 20, 21, 44, 47, 806, DateTimeKind.Local).AddTicks(3179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 577, DateTimeKind.Local).AddTicks(5051),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 20, 21, 44, 47, 805, DateTimeKind.Local).AddTicks(6885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 573, DateTimeKind.Local).AddTicks(8545),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 20, 21, 44, 47, 801, DateTimeKind.Local).AddTicks(3914));

            migrationBuilder.CreateTable(
                name: "UserRoleUpgradeRequests",
                columns: table => new
                {
                    UserRoleUpgradeRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesiredRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleUpgradeRequests", x => x.UserRoleUpgradeRequestId);
                    table.ForeignKey(
                        name: "FK_UserRoleUpgradeRequests_AppRoles_DesiredRoleId",
                        column: x => x.DesiredRoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleUpgradeRequests_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleUpgradeExchanges",
                columns: table => new
                {
                    UserRoleUpgradeExchangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleUpgradeRequestId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    IsReaded = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleUpgradeExchanges", x => x.UserRoleUpgradeExchangeId);
                    table.ForeignKey(
                        name: "FK_UserRoleUpgradeExchanges_UserRoleUpgradeRequests_UserRoleUpgradeRequestId",
                        column: x => x.UserRoleUpgradeRequestId,
                        principalTable: "UserRoleUpgradeRequests",
                        principalColumn: "UserRoleUpgradeRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "CreatedBy", "DateCreated" },
                values: new object[] { "c2ec9bb0-5b77-4d2b-a95d-8c83d18c316c", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8719) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "CreatedBy", "DateCreated" },
                values: new object[] { "111952db-0de3-458c-8f21-031277d0a007", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8716) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "CreatedBy", "DateCreated" },
                values: new object[] { "8931deef-17fc-4523-a029-0ce6a1cf2167", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8703) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "CreatedBy", "DateCreated" },
                values: new object[] { "6e7f7414-923c-4236-8157-dc3cdfaf2e4c", new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8699) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("29c14e13-cd5c-4581-9d43-0bd560364578"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("9d3ae50c-ef24-4334-ad96-deda0ab2c1d2"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("2f8aba76-70ce-4b53-8d1d-a043e0cada55"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("befa1cf8-c437-45d9-9a86-71130b50ceac"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("d3aabf03-2e68-4dd1-84c5-8002693d00d9"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "644eee69-f83d-44e2-bba5-cc3fb9c14c11", "AQAAAAEAACcQAAAAEGIoFl4GN6IgOwD03BULPbQbYLcGNZdtmBBmI5Zi+0JAIvVXA4NxhUynGv3oLZBxbQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "808c5536-38bc-4528-9d43-84d7c1905edd", "AQAAAAEAACcQAAAAEGDfVXpig9Ehaz/mHGUUt4Cu8KhQPVHndQ9SGCQRqgxVRSKjYabYYQIWz000oPkjSQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "823e1251-755e-429c-ba29-688ad891040b", "AQAAAAEAACcQAAAAEJPgXyUh8A7Rr9EgnjJZTtZ/wVghKD2dYPJCFApLKofAyG8Mn4GcvXcsb1dMqhmBVw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5647fe6f-5dd1-4b5a-b152-59fd850d4f92", "AQAAAAEAACcQAAAAEAdfhfweYCb/Hbt+3mZHZFPwmixaI2DNIFR+1hDJ36YAKPXry7r1So+nXe4/ZHce7Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "011a2917-32a3-4c4d-89b9-68f6abe6fad6", "AQAAAAEAACcQAAAAEN7BI4EpvFOsT3slJe17V2X6P8Yw36rm3R9oX7xOwWTyptajH+VSyJDFG9N3R0h0dA==" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6062));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8600));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8602));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8604));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6297));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6298));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6342));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6342));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6343));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6345));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6346));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6346));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6354));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6361));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 72,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 73,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 74,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 75,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 76,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 615, DateTimeKind.Local).AddTicks(6365));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8623));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8451));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8454));

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleUpgradeExchanges_UserRoleUpgradeRequestId",
                table: "UserRoleUpgradeExchanges",
                column: "UserRoleUpgradeRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleUpgradeRequests_AppUserId",
                table: "UserRoleUpgradeRequests",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleUpgradeRequests_DesiredRoleId",
                table: "UserRoleUpgradeRequests",
                column: "DesiredRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoleUpgradeExchanges");

            migrationBuilder.DropTable(
                name: "UserRoleUpgradeRequests");

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("29c14e13-cd5c-4581-9d43-0bd560364578"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9d3ae50c-ef24-4334-ad96-deda0ab2c1d2"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2f8aba76-70ce-4b53-8d1d-a043e0cada55"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("befa1cf8-c437-45d9-9a86-71130b50ceac"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d3aabf03-2e68-4dd1-84c5-8002693d00d9"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 20, 21, 44, 47, 806, DateTimeKind.Local).AddTicks(6033),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 578, DateTimeKind.Local).AddTicks(2608));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 20, 21, 44, 47, 806, DateTimeKind.Local).AddTicks(3179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 577, DateTimeKind.Local).AddTicks(9925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 20, 21, 44, 47, 805, DateTimeKind.Local).AddTicks(6885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 577, DateTimeKind.Local).AddTicks(5051));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 20, 21, 44, 47, 801, DateTimeKind.Local).AddTicks(3914),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 573, DateTimeKind.Local).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "CreatedBy", "DateCreated" },
                values: new object[] { "abae83ae-b93f-4db3-ac5f-5ba5444ecc0d", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "CreatedBy", "DateCreated" },
                values: new object[] { "649b262b-67b9-403a-9844-721d996fa966", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "CreatedBy", "DateCreated" },
                values: new object[] { "24190d35-1e77-49c0-ae16-a34044516d4c", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "CreatedBy", "DateCreated" },
                values: new object[] { "fadadc12-56b0-413b-bc13-2224841d2f31", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ecfe8006-83a1-440e-82f1-41ec639e99b6", "AQAAAAEAACcQAAAAEPBruOBs1Jy2UyA9+LBiI3JUtOIsiDmbnuZgD5cxfSOzTV2/wCoFYtdJnsSNLaqqFg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8cf57a15-61e4-44fe-9bf2-23ad51231672", "AQAAAAEAACcQAAAAELdW4a7uC2vsZfx8nxf3NcFfw4VEUOkemyTI+w9DISngDu7awpoCLo9iky81qS6L8Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d6d0efb-fee6-41fc-825c-29f86942625e", "AQAAAAEAACcQAAAAEOZi2ik/Ky7BMZ0bH0ln3Y6+kPvJ/MI/TGjDIN2yGuXFM3Zgnsv2d9ouMXk5vKdRTQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "de9c6958-10fc-4ed4-9cff-144ec901cdc0", "AQAAAAEAACcQAAAAEOvnG5dAhBS8SSnsvxHULf26QiGA63Y9IBD76GMQ+yWvgvPjO/otPWrCxYvsCtDaDQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d38a0ccb-7a4f-4fbc-a21f-fe651fef5eaa", "AQAAAAEAACcQAAAAEOf24BxLpjivPKGncH5wfq5fcYrjDpvoB1taVRTCKhXKQuAEqjLq7q1KWeJPvxnppQ==" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 853, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 853, DateTimeKind.Local).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8264));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 853, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(136));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(141));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(143));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(144));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(146));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(149));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(150));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(153));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(163));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(169));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(171));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(172));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(174));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(178));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(179));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(191));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(204));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(216));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(217));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(237));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(253));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(255));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(258));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(259));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(261));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(266));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(268));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(270));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(272));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 72,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(273));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 73,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(275));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 74,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 75,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 76,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 854, DateTimeKind.Local).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 20, 21, 44, 47, 807, DateTimeKind.Local).AddTicks(8099));
        }
    }
}

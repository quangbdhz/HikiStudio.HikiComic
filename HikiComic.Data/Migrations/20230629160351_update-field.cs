using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiComic.Data.Migrations
{
    public partial class updatefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f3006b81-9687-44fe-b9a7-f786d50cff9b"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("348f7cbf-b2da-4741-91ad-e9fa2000cf1b"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e0ea4603-7ea6-4f78-93c0-05421652a1e4"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1c46dbd9-b495-45b7-be76-72443f67d145"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d7edd6b-e056-4081-8a3c-ab58f40c2ea9"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 175, DateTimeKind.Local).AddTicks(4016),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 28, 22, 17, 33, 715, DateTimeKind.Local).AddTicks(2722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 174, DateTimeKind.Local).AddTicks(1817),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 28, 22, 17, 33, 715, DateTimeKind.Local).AddTicks(36));

            migrationBuilder.AddColumn<string>(
                name: "ConvertCurrency",
                table: "UserCoinDepositHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DepositCreateTime",
                table: "UserCoinDepositHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepositUpdateTime",
                table: "UserCoinDepositHistories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExchangeRate",
                table: "UserCoinDepositHistories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "OriginalAmount",
                table: "UserCoinDepositHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "OriginalCurrency",
                table: "UserCoinDepositHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 172, DateTimeKind.Local).AddTicks(6430),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 28, 22, 17, 33, 714, DateTimeKind.Local).AddTicks(5040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 117, DateTimeKind.Local).AddTicks(7895),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 28, 22, 17, 33, 711, DateTimeKind.Local).AddTicks(878));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "fdaaef7c-c17e-40f4-b3ba-ede1a992aa07", new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(4620) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "8a55e093-fcd6-4842-b2a4-7054c02b54b9", new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(4601) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "a7c9c9ce-4f97-404d-baa2-2c4e49bb9791", new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(4592) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "7054bb86-7d62-4bdc-9e97-58eb4815acc5", new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(4580) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3eb489c9-9fd5-4704-b43a-f379b6702c82"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("b76297d8-044c-4391-860e-59b9869d7b50"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("32845115-04c3-4056-84da-fbba6347a5a7"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("2944aa1a-9844-41b4-a9a2-0743562b5c77"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("462494d3-841f-4fbe-af19-70cfab8a3d8e"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b0cdb5cc-231f-46a0-b3c4-11e7bcdd8c4d", "AQAAAAEAACcQAAAAEMNcCMbG0F0xRc2ti+0QkUaT4G+XFDCuFV0Z2CqcSW54klEXkESnaVRnEdiDR652RA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0b650c4-6d07-4483-8405-b53ce807a798", "AQAAAAEAACcQAAAAEDeiitMECOhkkZy3TRPXQ+3nIX1ghhRS9AiUGyVHWds+4sL9K52mWDCoks89p2BAog==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9613bd1b-08dc-4b63-9508-1bae719a7ed9", "AQAAAAEAACcQAAAAENtxnVIbnisYBcBqq9I1Rs+71oMx+j8wM7fRs0MKnhsIe4ps1CyAKhaXwAHRRrKEgg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9dcde636-9074-4f38-9a70-59790bae943d", "AQAAAAEAACcQAAAAEHtIwb7gmNov2I+qcBQzeDoGAL5NWziANYRs0XQrvjVQnmkAmqhzG9UhA/BwPiAemQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "edf4a808-6b0e-438a-a6cb-6287bbc01038", "AQAAAAEAACcQAAAAELpoJUhAglQM/cbWLAqo76AK/61ArWSe3A63Q/S2A4+zS95mbAnHMBWrYFhSpc8JIQ==" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8074));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8139));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8173));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8197));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8211));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8270));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8301));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8304));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8309));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 72,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 73,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 74,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 75,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 76,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 266, DateTimeKind.Local).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(4452));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(4391));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(3721));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 29, 23, 3, 48, 189, DateTimeKind.Local).AddTicks(3741));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3eb489c9-9fd5-4704-b43a-f379b6702c82"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b76297d8-044c-4391-860e-59b9869d7b50"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("32845115-04c3-4056-84da-fbba6347a5a7"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2944aa1a-9844-41b4-a9a2-0743562b5c77"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("462494d3-841f-4fbe-af19-70cfab8a3d8e"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DropColumn(
                name: "ConvertCurrency",
                table: "UserCoinDepositHistories");

            migrationBuilder.DropColumn(
                name: "DepositCreateTime",
                table: "UserCoinDepositHistories");

            migrationBuilder.DropColumn(
                name: "DepositUpdateTime",
                table: "UserCoinDepositHistories");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "UserCoinDepositHistories");

            migrationBuilder.DropColumn(
                name: "OriginalAmount",
                table: "UserCoinDepositHistories");

            migrationBuilder.DropColumn(
                name: "OriginalCurrency",
                table: "UserCoinDepositHistories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 28, 22, 17, 33, 715, DateTimeKind.Local).AddTicks(2722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 175, DateTimeKind.Local).AddTicks(4016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 28, 22, 17, 33, 715, DateTimeKind.Local).AddTicks(36),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 174, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 28, 22, 17, 33, 714, DateTimeKind.Local).AddTicks(5040),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 172, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 28, 22, 17, 33, 711, DateTimeKind.Local).AddTicks(878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 117, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "e64bc0e3-4f19-4521-b1ac-e7da641846a0", new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(425) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "9afa3404-3cc0-4025-93c0-f5efffd73b54", new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(421) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "921c191c-0405-457d-9525-692abb507272", new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(410) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "3cd84b83-33a4-4fec-883b-1bc09194d9a3", new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(405) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f3006b81-9687-44fe-b9a7-f786d50cff9b"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("348f7cbf-b2da-4741-91ad-e9fa2000cf1b"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("e0ea4603-7ea6-4f78-93c0-05421652a1e4"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("1c46dbd9-b495-45b7-be76-72443f67d145"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("2d7edd6b-e056-4081-8a3c-ab58f40c2ea9"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9ac106c3-5c4d-44e3-bb39-2e5c96399f12", "AQAAAAEAACcQAAAAEJoOnNJ23IflLv9moY2f9ehgf245F9KODBrMHPczR2QH+OKrYqMKXilGkzj80JHUaw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9f0a2f00-4b81-4339-a396-50a7fd57c602", "AQAAAAEAACcQAAAAEHSrL/R9L/bee+ekkM1QQTlb3taaMnA8CwD30gq+GtDl5rUi9FnA1DfiqFvaOAvo6A==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e68c150-8bb4-449a-8365-4a4e7db9f32a", "AQAAAAEAACcQAAAAEO1z4dq848OjISJX//pnlSFjGGom9SpbCcLJOIt/nivsP8Pc1KGfNs2bVkYH6C8r7g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b7267e4-3fff-4f8f-9a39-2bb1af1fa094", "AQAAAAEAACcQAAAAEN6VX2tw8on3M7Y0oLa+aKRlMEAedd1L5fIVIrWuUL8Nl3Q0DSyURHAm6L2P6SVhhw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "48723cfe-67ed-4c8e-8849-5a42a6023dd3", "AQAAAAEAACcQAAAAENmsjw5GRSPHMTyQCVFwQtW+15pmYB/O+o7WmWLTlDvqWUlUiHqSqb2BYb1L76uc+Q==" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(1985));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(299));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2051));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2212));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2216));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2218));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2219));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2223));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2224));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2230));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 72,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 73,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 74,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 75,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 76,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 769, DateTimeKind.Local).AddTicks(2258));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(344));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(318));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(320));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(322));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(68));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 22, 17, 33, 717, DateTimeKind.Local).AddTicks(77));
        }
    }
}

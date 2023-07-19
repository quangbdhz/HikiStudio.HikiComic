using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiComic.Data.Migrations
{
    public partial class updatetableuserfieldcreatedby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                defaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 908, DateTimeKind.Local).AddTicks(6687),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 578, DateTimeKind.Local).AddTicks(2608));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 908, DateTimeKind.Local).AddTicks(3991),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 577, DateTimeKind.Local).AddTicks(9925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 907, DateTimeKind.Local).AddTicks(8871),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 577, DateTimeKind.Local).AddTicks(5051));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "AppUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 903, DateTimeKind.Local).AddTicks(8544),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 573, DateTimeKind.Local).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "ee377093-f95d-4101-8ea7-cf3d4ffa75dd", new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7523) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "9586bd83-8a82-41ce-bd97-e783bea7d00d", new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7519) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "96d83243-d5f8-4250-9b9d-330dacd8bed2", new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7516) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "92a65130-ea8f-4b87-b997-5efcc1c3e07a", new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7511) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("07d7f286-7eb6-438b-9a10-44764b98b340"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("831dd3af-500a-4377-b8a7-971b5197d16b"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("27bf9ad3-5928-4da3-8cf2-8322ee4d4604"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("3b1df4db-a328-4e55-8147-7b73c9898bf1"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("a0111f9e-ff1c-47e7-9987-9d22ac26805d"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "825c3fd9-653b-407f-be47-079dcef7b159", "AQAAAAEAACcQAAAAEKXMDHaQ8dfSgbSdPwl1s2IrnGK6Y5hXut60sRw3IZayRT7NivFmnt9LZbQPRSYfgg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6b61c8f-b7b4-452d-bc09-22739be467a4", "AQAAAAEAACcQAAAAEGmZtI8jUwt60oCTI62AZHzXzBASyokpe6Bj9k8Gi6SFnBhaPTwzVXsuRCHF7KDWyA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a27fd121-b472-4d96-92bf-834507b4b68c", "AQAAAAEAACcQAAAAEDpv5MsPJFNiiH1pLqotPGiryFlX5MS6vkTGd7caYkg3FUgrMkz75SCEw+8JPbgwiw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee877a9d-565e-4571-8679-1883c0280159", "AQAAAAEAACcQAAAAEFC3lGbvS/zsVFb0h1hSS0qM3wAb1FtAezs7a5/O3/qAfzQpOuuxrcQyt9/830tMVw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11cc5e8a-bbbf-47bf-8782-495ae1cfd9a1", "AQAAAAEAACcQAAAAEB5LG5hsqWOATIXg2wx6Oepm9ro98xIZUqB80rx4SHqX0sJQS8er8T73a2SMH/0Ypw==" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1280));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7397));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7399));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1331));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1576));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1585));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1590));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1591));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1597));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1599));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1601));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1604));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1605));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1611));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1613));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1615));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1616));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1695));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1696));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1698));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1699));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1707));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1712));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1714));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1718));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1724));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1726));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1727));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1731));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1732));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1733));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1735));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1738));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1740));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1742));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1743));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 72,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 73,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1745));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 74,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 75,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 76,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 949, DateTimeKind.Local).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 24, 21, 50, 9, 910, DateTimeKind.Local).AddTicks(7228));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("07d7f286-7eb6-438b-9a10-44764b98b340"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("831dd3af-500a-4377-b8a7-971b5197d16b"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("27bf9ad3-5928-4da3-8cf2-8322ee4d4604"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3b1df4db-a328-4e55-8147-7b73c9898bf1"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a0111f9e-ff1c-47e7-9987-9d22ac26805d"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AppUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 578, DateTimeKind.Local).AddTicks(2608),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 908, DateTimeKind.Local).AddTicks(6687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 577, DateTimeKind.Local).AddTicks(9925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 908, DateTimeKind.Local).AddTicks(3991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 577, DateTimeKind.Local).AddTicks(5051),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 907, DateTimeKind.Local).AddTicks(8871));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 9, 45, 2, 573, DateTimeKind.Local).AddTicks(8545),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 903, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "c2ec9bb0-5b77-4d2b-a95d-8c83d18c316c", new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8719) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "111952db-0de3-458c-8f21-031277d0a007", new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8716) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "8931deef-17fc-4523-a029-0ce6a1cf2167", new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8703) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "6e7f7414-923c-4236-8157-dc3cdfaf2e4c", new DateTime(2023, 6, 24, 9, 45, 2, 579, DateTimeKind.Local).AddTicks(8699) });

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
        }
    }
}

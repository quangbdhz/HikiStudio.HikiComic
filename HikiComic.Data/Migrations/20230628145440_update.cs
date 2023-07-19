using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiComic.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2fa995fa-e8dd-45c8-8ace-e6bb375e4379"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("73fbda3f-89a5-4af5-878c-196947a884b4"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e54a7f85-0705-46b2-a8cf-b6a89a87e2c1"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("415c9c47-fcbf-49c4-87ed-7e1929a6d656"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ca67745a-19f3-4f59-866a-3bed3a03be2d"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.AddColumn<bool>(
                name: "IsReader",
                table: "UserRoleUpgradeExchanges",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 28, 21, 54, 37, 525, DateTimeKind.Local).AddTicks(2094),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 176, DateTimeKind.Local).AddTicks(6973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 28, 21, 54, 37, 524, DateTimeKind.Local).AddTicks(9273),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 176, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 28, 21, 54, 37, 524, DateTimeKind.Local).AddTicks(3988),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 175, DateTimeKind.Local).AddTicks(6345));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 28, 21, 54, 37, 520, DateTimeKind.Local).AddTicks(4606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 170, DateTimeKind.Local).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "466f9808-f239-4eb1-b1cf-a6b920b8a271", new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4808) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "9c1aae49-375e-4af9-83a6-384ab3c60bf6", new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4805) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "2d6b4908-58a9-4e0e-8f1b-2b26f42c528a", new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4801) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "136efa51-26c2-4b2a-b010-4e7251787dbc", new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4788) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7a006d39-db8b-492d-ab68-e854e67ecad4"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("4a51e311-01b6-4891-bcdc-d0e4e0cc0e22"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("683575c5-7aa8-45b6-a135-c3edfb7c6fe4"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("d083dfa8-37a9-45bf-a65b-51d4163f2b3e"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("b59832e4-ac9a-4913-9645-2a416ca053d6"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cf468256-5f43-40fe-ad59-fee87ebfc255", "AQAAAAEAACcQAAAAELeYoII5rwIttRe6F3Up5tcn+Ziypmk96kuPK+Kz3HgJxn/d9AGMi27nK0tHk9de3Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "54b08608-728f-44a2-8d75-e81ac5be60ed", "AQAAAAEAACcQAAAAECfavMJ1MTKnu5zhbf5FyXTMkFcBeYhYxQHV7p2hBnV6RAHbRiM2bwf4/1+pCcSYVA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "905c238a-1f9f-4e26-8d69-a9f6fdfc418d", "AQAAAAEAACcQAAAAECfU7/zq2rmpvs3FyUwkfF+WGS2Lecz/w7rdC3mnj0a2yX+gXpA8kVcKJDpBOqHVxQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2e36ead0-17ce-469d-9aa7-359ff41ea940", "AQAAAAEAACcQAAAAEHUfupt+enWgfvgGVhNh2QC67bgU67pFZjmE0Yj/t4Lk9bACRpzefF9wYyW8U0+7BA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81d7187e-a339-4fa5-a4bd-6476d2e38e00", "AQAAAAEAACcQAAAAEEM+afxTWWTQfofrv6D4+D7oiOroRjzhR/aISS8wM0O55W+Ed51ZrNDf3zZoedXiCA==" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 563, DateTimeKind.Local).AddTicks(9884));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 563, DateTimeKind.Local).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4683));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 563, DateTimeKind.Local).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(106));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(107));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(121));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(123));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(123));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(124));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(126));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(126));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(127));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(128));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(133));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(134));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(135));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(136));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(136));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(139));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(139));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(140));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(141));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(143));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(144));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(146));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(148));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(148));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(153));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(158));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(166));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 72,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 73,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 74,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(169));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 75,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 76,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 564, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4705));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 21, 54, 37, 527, DateTimeKind.Local).AddTicks(4499));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7a006d39-db8b-492d-ab68-e854e67ecad4"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4a51e311-01b6-4891-bcdc-d0e4e0cc0e22"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("683575c5-7aa8-45b6-a135-c3edfb7c6fe4"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d083dfa8-37a9-45bf-a65b-51d4163f2b3e"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b59832e4-ac9a-4913-9645-2a416ca053d6"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DropColumn(
                name: "IsReader",
                table: "UserRoleUpgradeExchanges");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 176, DateTimeKind.Local).AddTicks(6973),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 28, 21, 54, 37, 525, DateTimeKind.Local).AddTicks(2094));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 176, DateTimeKind.Local).AddTicks(3426),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 28, 21, 54, 37, 524, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 175, DateTimeKind.Local).AddTicks(6345),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 28, 21, 54, 37, 524, DateTimeKind.Local).AddTicks(3988));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 170, DateTimeKind.Local).AddTicks(4803),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 28, 21, 54, 37, 520, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "6ec007b8-7e03-40fe-971b-ed1300f3f7de", new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2622) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "d51e13bc-66b2-41a1-944c-d152d9e98098", new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2611) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "4b6f19df-3b07-42db-8c9e-03464569f08c", new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2605) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "e5af65ec-c9dd-482e-9ca7-6a76226fa1cd", new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2586) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2fa995fa-e8dd-45c8-8ace-e6bb375e4379"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("73fbda3f-89a5-4af5-878c-196947a884b4"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("e54a7f85-0705-46b2-a8cf-b6a89a87e2c1"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("415c9c47-fcbf-49c4-87ed-7e1929a6d656"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("ca67745a-19f3-4f59-866a-3bed3a03be2d"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "501bd119-0771-4cf4-8e9c-7652b730fc29", "AQAAAAEAACcQAAAAEGESv3Dz3JX2uITBKf8e0r3Ze9/zgQy1Q5ecvKlnzvT6QPrMhaRDTx/Rf4o46rMmQw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "50c22bce-4252-48bf-9488-8e063d6ccdad", "AQAAAAEAACcQAAAAEOZIc1XLZU8p1oKJk3uC+YGjwQ1Hm3MPEDadAhrdh7Yn6GovHSTuS0PYg0SVwOraoA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6ec455a8-428c-48d8-b840-0eca0112f83b", "AQAAAAEAACcQAAAAEFzV1UrqIW66XQweh+DvIDaT3skglMSWeVBu+RW3GA3rkR6GtIoUwKUZt73SfBELWQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d80b6299-14fe-4ee8-8905-856b079e9473", "AQAAAAEAACcQAAAAEOZGKncCoWaLKRrlMXwJNTis774BP4dcHy56DAAmtNbREm2lF1vlFRJ/GOdwClhhyw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5ee3abc6-ec7e-44bc-8784-aaaa22350fcb", "AQAAAAEAACcQAAAAEOcszLgPhApFZW6XZ2Nh8D2K6iYRfQuhOog41dpcXqTI1nFkK4clXSgILW46/3WFKA==" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2429));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2432));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2434));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8635));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8637));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8687));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8689));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8695));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8697));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8700));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8701));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8703));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8708));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8714));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8715));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8717));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8720));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8725));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8731));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8732));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8735));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8735));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8738));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8741));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8743));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 72,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 73,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 74,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 75,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 76,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 233, DateTimeKind.Local).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2505));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2464));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2467));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2118));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 26, 21, 21, 36, 179, DateTimeKind.Local).AddTicks(2121));
        }
    }
}

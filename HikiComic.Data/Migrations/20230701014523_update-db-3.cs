using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiComic.Data.Migrations
{
    public partial class updatedb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 302, DateTimeKind.Local).AddTicks(1237),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 175, DateTimeKind.Local).AddTicks(4016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 301, DateTimeKind.Local).AddTicks(7795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 174, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 301, DateTimeKind.Local).AddTicks(2681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 172, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePasswordChanged",
                table: "AppUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPasswordChanged",
                table: "AppUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 297, DateTimeKind.Local).AddTicks(7951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 117, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "2983547c-991e-4b92-823f-8dfe078e4dcf", new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9732) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "ee378d5d-19d9-4319-9831-4a26c23b59d5", new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9729) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "2908498b-8e2f-43ef-9ccc-fab151a8059f", new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9725) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "3eb94881-c345-453e-9cd2-e0938e6154e5", new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9721) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("390eb07c-7962-44e2-a77e-2d755af8d311"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("d9d52706-b057-4ac5-b954-eee3ca082b1b"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("4aad11be-2fab-40ea-b339-caff7c661be6"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("5e2aaa7b-906e-4069-9245-58f95eafa0ff"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("918a9340-5505-4892-b603-2f4403bf51bc"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "IsPasswordChanged", "PasswordHash" },
                values: new object[] { "fa1f74de-1d89-4281-9626-46acb97a2001", new DateTime(2023, 7, 1, 8, 45, 21, 319, DateTimeKind.Local).AddTicks(5730), true, "AQAAAAEAACcQAAAAEKX0icODkCoTuRBi1unqASj6cihkNJf2yRbFwdUzRPXPnlb2LxwyRZYAFN7pHPUeEg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "42f7a7b7-625d-4ef6-a30f-a0e0c0b64e0b", "AQAAAAEAACcQAAAAEMgvli/WSjo6yRHssRbBJCXNU7+s8qT6Oor2HivSv026gypRF1xa+b09MzNZwvtJTg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "IsPasswordChanged", "PasswordHash" },
                values: new object[] { "f5757e09-268f-48e4-a2b3-c286b8833ebe", new DateTime(2023, 7, 1, 8, 45, 21, 326, DateTimeKind.Local).AddTicks(8831), true, "AQAAAAEAACcQAAAAEA3g47PztBDRgBu1vIqLN9MelzxGMeCTfLmzj4aKnryEkjy+MBY1lfi57iUOXXQanA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "IsPasswordChanged", "PasswordHash" },
                values: new object[] { "aa687d27-a77c-428c-95bc-b2c54a65651d", new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(368), true, "AQAAAAEAACcQAAAAEJlwlIzv//MLs0lL81D6D76LUNyxq/6L+/fD+tmbpXQpDl7GXSqAjtE/UrA1jAe/Rg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "IsPasswordChanged", "PasswordHash" },
                values: new object[] { "9fc9c5b0-0c42-4f70-9434-b2c5a5876d45", new DateTime(2023, 7, 1, 8, 45, 21, 334, DateTimeKind.Local).AddTicks(1713), true, "AQAAAAEAACcQAAAAEKoILx8lwRbfsOvYW+cgXxuxUHxzWsCZdTp6UIQe2vJGs2CfMGjowpEvdQJwt/WSsg==" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9621));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9623));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9624));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(725));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(728));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(730));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(735));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(744));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(748));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(751));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(753));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(754));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(755));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(755));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(757));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(761));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(763));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(776));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(794));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 72,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(798));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 73,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(799));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 74,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(799));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 75,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 76,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(801));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9664));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9642));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9645));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 8, 45, 21, 303, DateTimeKind.Local).AddTicks(9461));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("390eb07c-7962-44e2-a77e-2d755af8d311"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d9d52706-b057-4ac5-b954-eee3ca082b1b"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4aad11be-2fab-40ea-b339-caff7c661be6"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5e2aaa7b-906e-4069-9245-58f95eafa0ff"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("918a9340-5505-4892-b603-2f4403bf51bc"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DropColumn(
                name: "DatePasswordChanged",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "IsPasswordChanged",
                table: "AppUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 175, DateTimeKind.Local).AddTicks(4016),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 302, DateTimeKind.Local).AddTicks(1237));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 174, DateTimeKind.Local).AddTicks(1817),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 301, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 172, DateTimeKind.Local).AddTicks(6430),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 301, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 23, 3, 48, 117, DateTimeKind.Local).AddTicks(7895),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 297, DateTimeKind.Local).AddTicks(7951));

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
    }
}

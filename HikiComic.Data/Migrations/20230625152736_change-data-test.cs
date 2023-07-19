using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiComic.Data.Migrations
{
    public partial class changedatatest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 191, DateTimeKind.Local).AddTicks(8466),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 908, DateTimeKind.Local).AddTicks(6687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 191, DateTimeKind.Local).AddTicks(5914),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 908, DateTimeKind.Local).AddTicks(3991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 191, DateTimeKind.Local).AddTicks(986),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 907, DateTimeKind.Local).AddTicks(8871));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 187, DateTimeKind.Local).AddTicks(4853),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 903, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "d863e5df-0a78-4382-8315-3679927c697f", new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5643) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "411d5ec0-2719-418f-b456-a06721af9277", new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5640) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "6b9cc5ce-0259-4a27-9cf8-6b8b0d1376a4", new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5637) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "57ba48e7-22fb-4de4-96d8-300acee043ba", new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5632) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f4b6801a-a26e-4123-9eec-37b85a62a289"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("335238a1-d4df-4e12-b7f6-5ed9cf103a52"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("9e24df9d-313b-400f-b64e-08816ad827a1"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("77d4ca72-5f79-44d2-895c-e17ad019253b"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("19830ad0-300c-45c9-a107-bb16674d936f"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "41e4c078-2837-4275-b29f-033e23c2ec0c", "AQAAAAEAACcQAAAAEGZqHRpwAxOX2Sx9O97C6ShANraZr6WuCjZaSFrIlgRUXBUysFVT9s7Y/UalyjWZkQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "73720a48-4018-43e3-bbfa-77b6a71f1c23", "AQAAAAEAACcQAAAAEC5hP6vJMfNUtyu4ZTEhDqCprcAFrvwmR7zh/2Z0Xh5NoYX2Qqse4JZtTIbuY7uNpQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "DOB", "Email", "FirstName", "LastName", "NormalizedEmail", "PasswordHash", "UserName" },
                values: new object[] { "9dda27c8-66a0-45c3-8562-327f7ea6c2ea", new DateTime(1990, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "lionelmessi@hiki.space", "Lionel", "Messi", "LIONELMESSI@HIKI.SPACE", "AQAAAAEAACcQAAAAELZ1Xd7abobCMV5d/4vNfTZrzZh2PV3XGQ020Qn+skGIY2+41m//O0GWap8AVDB92A==", "lionelmessi" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "85f02dee-4cd9-4ea6-a3ba-738444e15a89", "AQAAAAEAACcQAAAAEBQGDFhJEy66gy8yEttIMdkxuB1FxZCQkYy9C47rQ/XEPiq65ka3c2Grw4eqWepLaA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b0e7b6f-4fd9-4d40-b6a5-8b01d21f5b91", "AQAAAAEAACcQAAAAEB4NTH+ygSsMuH44nW3RkboX4C//KgVmSdn3/3c5N29xJTwVYiFDJQqUVFFxv0h+FQ==" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5527));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5528));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2481));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2639));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2645));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2648));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2648));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2649));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2661));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2662));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2662));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2663));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2665));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2669));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2671));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2672));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2675));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2679));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2683));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2683));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2687));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2688));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2690));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2697));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2699));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2707));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2708));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 72,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2710));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 73,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2710));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 74,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 75,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2712));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 76,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 229, DateTimeKind.Local).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5571));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5547));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5549));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5296));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 6, 25, 22, 27, 35, 193, DateTimeKind.Local).AddTicks(5303));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f4b6801a-a26e-4123-9eec-37b85a62a289"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("335238a1-d4df-4e12-b7f6-5ed9cf103a52"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9e24df9d-313b-400f-b64e-08816ad827a1"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77d4ca72-5f79-44d2-895c-e17ad019253b"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("19830ad0-300c-45c9-a107-bb16674d936f"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 908, DateTimeKind.Local).AddTicks(6687),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 191, DateTimeKind.Local).AddTicks(8466));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 908, DateTimeKind.Local).AddTicks(3991),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 191, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 907, DateTimeKind.Local).AddTicks(8871),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 191, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 21, 50, 9, 903, DateTimeKind.Local).AddTicks(8544),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 187, DateTimeKind.Local).AddTicks(4853));

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
                columns: new[] { "ConcurrencyStamp", "DOB", "Email", "FirstName", "LastName", "NormalizedEmail", "PasswordHash", "UserName" },
                values: new object[] { "a27fd121-b472-4d96-92bf-834507b4b68c", new DateTime(2001, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "yukino@hiki.space", "Yukino", "HikiStudio", "READER@HIKI.SPACE", "AQAAAAEAACcQAAAAEDpv5MsPJFNiiH1pLqotPGiryFlX5MS6vkTGd7caYkg3FUgrMkz75SCEw+8JPbgwiw==", "yukino" });

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiComic.Data.Migrations
{
    public partial class addvaluedefaultuserroletabl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 176, DateTimeKind.Local).AddTicks(6973),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 191, DateTimeKind.Local).AddTicks(8466));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 176, DateTimeKind.Local).AddTicks(3426),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 191, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 175, DateTimeKind.Local).AddTicks(6345),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 191, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserRoleId",
                table: "AppUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 170, DateTimeKind.Local).AddTicks(4803),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 187, DateTimeKind.Local).AddTicks(4853));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 191, DateTimeKind.Local).AddTicks(8466),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 176, DateTimeKind.Local).AddTicks(6973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 191, DateTimeKind.Local).AddTicks(5914),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 176, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 191, DateTimeKind.Local).AddTicks(986),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 175, DateTimeKind.Local).AddTicks(6345));

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserRoleId",
                table: "AppUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 22, 27, 35, 187, DateTimeKind.Local).AddTicks(4853),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 26, 21, 21, 36, 170, DateTimeKind.Local).AddTicks(4803));

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9dda27c8-66a0-45c3-8562-327f7ea6c2ea", "AQAAAAEAACcQAAAAELZ1Xd7abobCMV5d/4vNfTZrzZh2PV3XGQ020Qn+skGIY2+41m//O0GWap8AVDB92A==" });

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
    }
}

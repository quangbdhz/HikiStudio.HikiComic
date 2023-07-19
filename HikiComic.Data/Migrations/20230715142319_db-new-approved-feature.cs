using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiComic.Data.Migrations
{
    public partial class dbnewapprovedfeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c80dd411-3570-4cbb-b2d6-f6d0be242a15"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("933e3e30-3a74-4563-ad28-e411cd2746b1"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("27b436f7-cc29-4313-a577-70fd8038eb83"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7137c991-5d9c-451a-8a75-66219e9e7b22"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("074bb49d-5be8-40f6-8b01-6aac0d098f85"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("dcaecea7-cb8d-4ea8-aedf-259c8b425bf9"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c0be6fd8-90d6-4a07-8a98-0513b5d38b47"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b7f5ded0-0a59-4c01-86f0-b7ff341e4b63"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ed7b906c-0c56-484d-a657-9f438cf5a5d1"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 945, DateTimeKind.Local).AddTicks(7919),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 23, 28, 24, 11, DateTimeKind.Local).AddTicks(5091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 945, DateTimeKind.Local).AddTicks(5354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 23, 28, 24, 10, DateTimeKind.Local).AddTicks(8947));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApproved",
                table: "Genres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Genres",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserIdApproved",
                table: "Genres",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 945, DateTimeKind.Local).AddTicks(417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 23, 28, 24, 9, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApproved",
                table: "Comics",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Comics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserIdApproved",
                table: "Comics",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApproved",
                table: "Chapters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Chapters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserIdApproved",
                table: "Chapters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 940, DateTimeKind.Local).AddTicks(9303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 23, 28, 23, 992, DateTimeKind.Local).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "9c4c093d-6ef0-4614-a9ca-151468740856", new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8648) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "cc3e6388-3bf1-48c7-b8a8-5b2a4eff09ef", new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8636) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "00d7c8cb-c22a-4688-882b-76333abf4719", new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8632) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "c4b7454c-209f-4735-855c-092a39100c2f", new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8627) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7ee49474-d8a7-4276-a80f-f391224ccb6e"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("b7adf6f6-a2e1-4637-9502-cef7d541d4c4"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("32d2bd79-3800-4e93-85b1-955cb2fbe72e"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("ee732cee-66ee-4418-8d7f-9fc9c87d4e87"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("fb3e9e4b-f855-4e2a-8204-566dd4bce73c"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("dd851957-28f2-49be-9206-fcd5a90ec2be"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("7a394ee1-7403-4543-be9b-665aabc544b3"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("40d6234e-3800-4b7b-bbb0-4a722a60426c"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") },
                    { new Guid("6c1212a5-8c99-4dde-b0a5-4cd282ab06bb"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "18e47a61-5a09-40e0-8f61-2ae2f2e88ef3", new DateTime(2023, 7, 15, 21, 23, 17, 962, DateTimeKind.Local).AddTicks(2358), "AQAAAAEAACcQAAAAEM/woxwl/V0w9XAGoi5JARL0Ejinufn8t6ULXm6SWPoxasF0PkIwQLFmhfq/5yHjog==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9d6143e5-8fba-4338-ac68-b6afe4c6edb3", "AQAAAAEAACcQAAAAEGl2YmvAj9csePN3Qsj2sUrBmjUkST1snD4wBNVO8ZIAhAtW+9Pae+IPd0KREEOXyw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "4d30957b-a3b5-47f0-8950-fe1e08bfa298", new DateTime(2023, 7, 15, 21, 23, 17, 969, DateTimeKind.Local).AddTicks(4395), "AQAAAAEAACcQAAAAEMosDgTkSIoNPXkAR0n1wwhvLJJEVSyDCVXBGUCWiYNPY15Eo+34l/csrKrzrGDMIg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "749edcda-be05-4a96-926f-ae8908c41b98", new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7133), "AQAAAAEAACcQAAAAEJRDqGvb1IVirwjOTu50WvnhZ2Ny5tRlyk0klv4JycQZtzDIOVH49tdygCyEUB7iCA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "dec067d7-c72b-4590-8822-a42ac126376b", new DateTime(2023, 7, 15, 21, 23, 17, 977, DateTimeKind.Local).AddTicks(5927), "AQAAAAEAACcQAAAAEEiOhTVWOvtPdtMl91hCc84k4IHPPgoeVqoXAMHBxuG/pXxG9ZRjF8mEAyp9zJhciw==" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7438));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8512));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8514));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7486));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7690));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7702));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7725));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7739));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7744));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7748));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7753));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7753));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7755));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7756));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7767));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 72,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 73,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 74,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 75,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 76,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 984, DateTimeKind.Local).AddTicks(7776));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8538));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8299));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 21, 23, 17, 947, DateTimeKind.Local).AddTicks(8313));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7ee49474-d8a7-4276-a80f-f391224ccb6e"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b7adf6f6-a2e1-4637-9502-cef7d541d4c4"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("32d2bd79-3800-4e93-85b1-955cb2fbe72e"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ee732cee-66ee-4418-8d7f-9fc9c87d4e87"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fb3e9e4b-f855-4e2a-8204-566dd4bce73c"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("dd851957-28f2-49be-9206-fcd5a90ec2be"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7a394ee1-7403-4543-be9b-665aabc544b3"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("40d6234e-3800-4b7b-bbb0-4a722a60426c"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6c1212a5-8c99-4dde-b0a5-4cd282ab06bb"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DropColumn(
                name: "DateApproved",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "UserIdApproved",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "DateApproved",
                table: "Comics");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Comics");

            migrationBuilder.DropColumn(
                name: "UserIdApproved",
                table: "Comics");

            migrationBuilder.DropColumn(
                name: "DateApproved",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "UserIdApproved",
                table: "Chapters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 23, 28, 24, 11, DateTimeKind.Local).AddTicks(5091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 945, DateTimeKind.Local).AddTicks(7919));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 23, 28, 24, 10, DateTimeKind.Local).AddTicks(8947),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 945, DateTimeKind.Local).AddTicks(5354));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 23, 28, 24, 9, DateTimeKind.Local).AddTicks(7072),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 945, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 23, 28, 23, 992, DateTimeKind.Local).AddTicks(6099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 940, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "ee252a62-07cb-467a-afef-6f8489ef9c3e", new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7382) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "a1ff8264-c349-433d-8926-a9a08aa4e37a", new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7371) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "8d6fc896-b86b-4d4e-9520-22ca763d627e", new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7366) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "b5b867dc-cb2f-46bd-be08-9b8ecc47161d", new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7358) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c80dd411-3570-4cbb-b2d6-f6d0be242a15"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("933e3e30-3a74-4563-ad28-e411cd2746b1"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("27b436f7-cc29-4313-a577-70fd8038eb83"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("7137c991-5d9c-451a-8a75-66219e9e7b22"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("074bb49d-5be8-40f6-8b01-6aac0d098f85"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("dcaecea7-cb8d-4ea8-aedf-259c8b425bf9"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("c0be6fd8-90d6-4a07-8a98-0513b5d38b47"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("b7f5ded0-0a59-4c01-86f0-b7ff341e4b63"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") },
                    { new Guid("ed7b906c-0c56-484d-a657-9f438cf5a5d1"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "a1f59c97-9e73-49b9-9f79-a8382fa859da", new DateTime(2023, 7, 4, 23, 28, 24, 44, DateTimeKind.Local).AddTicks(7900), "AQAAAAEAACcQAAAAEAxzy4MVt/Td5DURIQHEnH31kTpaNia+pduIuTzbJaCHUqQoC28N3DcL7FdyIKQlWg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a108bb9f-ef65-4675-8c87-55f1d2bb1f7c", "AQAAAAEAACcQAAAAEHzWP+LhqUX4ShpcstfBuBnlKvy2kVmxkSu+W+v8NFzZMU+iQ68OhcG7MUMojSA1lA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "9eadbe58-f0ed-4710-8fcf-8dd63c5e18b1", new DateTime(2023, 7, 4, 23, 28, 24, 55, DateTimeKind.Local).AddTicks(3867), "AQAAAAEAACcQAAAAEICFNuLbAPlmwyaKpFwHNachG6n/GLLxBxrhiPT9yvU5DbxDBMBLb/lY1AP0lm4J2g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "c3c08306-dd67-47d7-82fa-788dda79cfbd", new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(3982), "AQAAAAEAACcQAAAAEOFesTn9jAYFJubwQixhVwcwP65ePElzFEpTdHczybr5qS2+5UdfyAXfQ4F9YVzobQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "632851e8-e925-482e-9b60-376d87b36ed0", new DateTime(2023, 7, 4, 23, 28, 24, 65, DateTimeKind.Local).AddTicks(8058), "AQAAAAEAACcQAAAAEAuDU0atafnY1lNBIS1pkcGcxArHc5Opa0TAoGsWYpN54qgD3xkYHjgg4xyBGtovlA==" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7199));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4888));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4901));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4911));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4916));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4921));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4932));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4944));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 72,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 73,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 74,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 75,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4952));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 76,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 76, DateTimeKind.Local).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7271));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7273));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7237));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(6918));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(6940));
        }
    }
}

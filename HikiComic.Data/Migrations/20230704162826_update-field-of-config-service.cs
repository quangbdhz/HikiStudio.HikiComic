﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiComic.Data.Migrations
{
    public partial class updatefieldofconfigservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 23, 28, 24, 11, DateTimeKind.Local).AddTicks(5091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 302, DateTimeKind.Local).AddTicks(1237));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 23, 28, 24, 10, DateTimeKind.Local).AddTicks(8947),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 301, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.AddColumn<string>(
                name: "StringValue",
                table: "ServiceConfigs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 23, 28, 24, 9, DateTimeKind.Local).AddTicks(7072),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 301, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 23, 28, 23, 992, DateTimeKind.Local).AddTicks(6099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 297, DateTimeKind.Local).AddTicks(7951));

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
                columns: new[] { "DateCreated", "StringValue" },
                values: new object[] { new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7271), "3" });

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                columns: new[] { "DateCreated", "StringValue" },
                values: new object[] { new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7273), "1000" });

            migrationBuilder.InsertData(
                table: "ServiceConfigs",
                columns: new[] { "ServiceConfigId", "CreatedBy", "DateCreated", "DateUpdated", "Description", "Note", "ServiceConfigName", "StringValue", "UpdatedBy", "Value" },
                values: new object[] { 3, new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"), new DateTime(2023, 7, 4, 23, 28, 24, 21, DateTimeKind.Local).AddTicks(7276), null, null, null, "Default Currency", "VND", null, 0 });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "StringValue",
                table: "ServiceConfigs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 302, DateTimeKind.Local).AddTicks(1237),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 23, 28, 24, 11, DateTimeKind.Local).AddTicks(5091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 301, DateTimeKind.Local).AddTicks(7795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 23, 28, 24, 10, DateTimeKind.Local).AddTicks(8947));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 301, DateTimeKind.Local).AddTicks(2681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 23, 28, 24, 9, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 8, 45, 21, 297, DateTimeKind.Local).AddTicks(7951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 23, 28, 23, 992, DateTimeKind.Local).AddTicks(6099));

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
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "fa1f74de-1d89-4281-9626-46acb97a2001", new DateTime(2023, 7, 1, 8, 45, 21, 319, DateTimeKind.Local).AddTicks(5730), "AQAAAAEAACcQAAAAEKX0icODkCoTuRBi1unqASj6cihkNJf2yRbFwdUzRPXPnlb2LxwyRZYAFN7pHPUeEg==" });

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
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "f5757e09-268f-48e4-a2b3-c286b8833ebe", new DateTime(2023, 7, 1, 8, 45, 21, 326, DateTimeKind.Local).AddTicks(8831), "AQAAAAEAACcQAAAAEA3g47PztBDRgBu1vIqLN9MelzxGMeCTfLmzj4aKnryEkjy+MBY1lfi57iUOXXQanA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "aa687d27-a77c-428c-95bc-b2c54a65651d", new DateTime(2023, 7, 1, 8, 45, 21, 341, DateTimeKind.Local).AddTicks(368), "AQAAAAEAACcQAAAAEJlwlIzv//MLs0lL81D6D76LUNyxq/6L+/fD+tmbpXQpDl7GXSqAjtE/UrA1jAe/Rg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "9fc9c5b0-0c42-4f70-9434-b2c5a5876d45", new DateTime(2023, 7, 1, 8, 45, 21, 334, DateTimeKind.Local).AddTicks(1713), "AQAAAAEAACcQAAAAEKoILx8lwRbfsOvYW+cgXxuxUHxzWsCZdTp6UIQe2vJGs2CfMGjowpEvdQJwt/WSsg==" });

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
    }
}

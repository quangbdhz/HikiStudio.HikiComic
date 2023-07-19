using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiComic.Data.Migrations
{
    public partial class dbnewfieldnotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 270, DateTimeKind.Local).AddTicks(6996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 945, DateTimeKind.Local).AddTicks(7919));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 270, DateTimeKind.Local).AddTicks(2085),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 945, DateTimeKind.Local).AddTicks(5354));

            migrationBuilder.AddColumn<int>(
                name: "ChapterId",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 269, DateTimeKind.Local).AddTicks(2334),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 945, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 262, DateTimeKind.Local).AddTicks(2269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 940, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "26a854c4-edd6-4fa9-aa64-c9572f14f80c", new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8732) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "c18c5921-5111-44a7-abe4-dd397c58610e", new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8716) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "3d0b9e5f-e6dd-4cb3-a412-83d3dc284812", new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8710) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "ee209927-0478-4a35-b71f-ce99bdc25eec", new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8686) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7c4707ad-d54f-4ce2-bc6c-ca732f52a479"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("01969a1d-e7b3-4558-bb65-aeb419dea034"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("ccacce4e-a9ba-4fdb-b8d7-a6e9f969e5fd"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("967d256f-b5ac-47c3-8e67-31456e8df5a5"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("e46bd57a-dd3a-4b1b-ac74-ded90c47bf9b"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("cbbb5df2-7b98-49e1-96e8-c47e40e6a3a2"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("b5065c1a-7717-4cde-b7f9-def0052b10e0"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("52e419a3-9eae-4f48-b3a0-cb287d08d177"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") },
                    { new Guid("bca50d6e-f514-4c0b-9da4-b80115f8ac25"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "3260d0ff-8378-432b-8d79-f335e78b436f", new DateTime(2023, 7, 15, 23, 20, 44, 289, DateTimeKind.Local).AddTicks(8809), "AQAAAAEAACcQAAAAEE80BSjJM40nGsV4bG1a1yVo8t61uelf4hrnwZNAPKQusGBeEhcPJso70siVyV2yMA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "393ee076-15fc-42ac-8c5d-203e5f4bcb21", "AQAAAAEAACcQAAAAEOMzNI2ms4BGoEGpGPJYvY/7boJKZo5jOKuhJJpEou357Ysx3bu1uLx9tdHnV9UEXg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "e9a1d9e0-3725-41fa-b2e4-3d73b5af0461", new DateTime(2023, 7, 15, 23, 20, 44, 301, DateTimeKind.Local).AddTicks(8633), "AQAAAAEAACcQAAAAEOAK03kvktbGIayxkq4/JqyQNrHNcPs9/Af+mh93x7kJwvePbvewj1oeMeJSEnfgCA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "d7271523-7baa-4985-8491-1f0c519a1498", new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3287), "AQAAAAEAACcQAAAAEGF8WE1e5Si7hngw7BBvgo3fkgVps4BzK6TXKmJ1C9gSRg/il6aRIWHixl7U0lRN6w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "e90fc086-7175-4f7b-b3bd-6cb65b7da46c", new DateTime(2023, 7, 15, 23, 20, 44, 313, DateTimeKind.Local).AddTicks(7943), "AQAAAAEAACcQAAAAEH25WwB7x9/INA8Z4ujL9GySTuqVdR8oPG62/PM9RyLGRC4IKAEybpfDhFHwPZQiIQ==" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3491));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3517));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8516));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8520));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8522));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3544));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3759));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3766));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3771));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3775));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3777));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3783));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3785));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3788));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3794));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3812));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3814));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3814));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3821));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3822));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3825));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3828));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3829));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3833));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3833));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 72,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 73,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 74,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 75,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 76,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 321, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8600));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8555));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8561));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8224));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 15, 23, 20, 44, 273, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ChapterId",
                table: "Notifications",
                column: "ChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Chapters_ChapterId",
                table: "Notifications",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "ChapterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Chapters_ChapterId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ChapterId",
                table: "Notifications");

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7c4707ad-d54f-4ce2-bc6c-ca732f52a479"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("01969a1d-e7b3-4558-bb65-aeb419dea034"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ccacce4e-a9ba-4fdb-b8d7-a6e9f969e5fd"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("967d256f-b5ac-47c3-8e67-31456e8df5a5"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e46bd57a-dd3a-4b1b-ac74-ded90c47bf9b"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cbbb5df2-7b98-49e1-96e8-c47e40e6a3a2"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b5065c1a-7717-4cde-b7f9-def0052b10e0"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("52e419a3-9eae-4f48-b3a0-cb287d08d177"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bca50d6e-f514-4c0b-9da4-b80115f8ac25"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "Notifications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 945, DateTimeKind.Local).AddTicks(7919),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 270, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 945, DateTimeKind.Local).AddTicks(5354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 270, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 945, DateTimeKind.Local).AddTicks(417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 269, DateTimeKind.Local).AddTicks(2334));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 21, 23, 17, 940, DateTimeKind.Local).AddTicks(9303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 262, DateTimeKind.Local).AddTicks(2269));

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
    }
}

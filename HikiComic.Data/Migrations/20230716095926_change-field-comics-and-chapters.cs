using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikiComic.Data.Migrations
{
    public partial class changefieldcomicsandchapters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IsApproved",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Comics");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Chapters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 16, 59, 23, 723, DateTimeKind.Local).AddTicks(9318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 270, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 16, 59, 23, 722, DateTimeKind.Local).AddTicks(9338),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 270, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 16, 59, 23, 721, DateTimeKind.Local).AddTicks(2640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 269, DateTimeKind.Local).AddTicks(2334));

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "Comics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "Chapters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 16, 59, 23, 708, DateTimeKind.Local).AddTicks(7442),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 262, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "e94eb55b-1a95-4295-8478-4698c57c33c1", new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(1382) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "eb63a64f-3e14-4ca4-82c2-a0f4d38ca15f", new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c489f858-aabd-4264-96c1-5cdca251d871"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "5a39b602-83c4-46c6-88bf-568882d975bb", new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"),
                columns: new[] { "ConcurrencyStamp", "DateCreated" },
                values: new object[] { "770d7e6b-ba53-495a-9429-482ab868c6a4", new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(1326) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1d314fd9-e44b-4104-9099-4069463627af"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("bcbd335f-5a69-4cef-9555-ff299dfb3239"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") },
                    { new Guid("541ab1a2-f09a-432c-babf-00826480ba6c"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("75cdcc7f-0ba0-4468-98b5-bd7db97f8552"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") },
                    { new Guid("eacf7b2a-1a88-40e9-a870-6e6c534d5ccb"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("bc1fb812-9359-4bd8-ae73-9066aa124054"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") },
                    { new Guid("a605f8ef-5b0f-4bc4-9182-ca934566dc30"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") },
                    { new Guid("5acdfb9b-6ab8-4017-ba9a-bff8051b15ea"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") },
                    { new Guid("0b5a67f2-05c9-423f-9328-e78c72c667e2"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "a16b51ce-0153-4c85-93c5-9a8ebc0421b7", new DateTime(2023, 7, 16, 16, 59, 23, 750, DateTimeKind.Local).AddTicks(3822), "AQAAAAEAACcQAAAAEAbI1uDWC8FE7RdOWK1jW2icLpBa5WuXideasgWsD6pSxSwla1StYNNaFUem6KG0wA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d433cc22-554d-4bd4-9f4c-6d68f17b0475", "AQAAAAEAACcQAAAAEOHo2Ja8HT7jNjTakrcFnzsYrbnnJx7j/iU+sVYMOmg3iQigd9GkaiM6zK478AIfVg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "ea383559-3f38-4d94-921e-53eb3c0c17c2", new DateTime(2023, 7, 16, 16, 59, 23, 763, DateTimeKind.Local).AddTicks(8287), "AQAAAAEAACcQAAAAEFIxAcylidccR1zTDOk3jdkW1H0B/rVizROSJ8i28fGQasrXxDKlbNXIAFiv1KNJwg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("4354acbc-a32a-4a28-b865-deb49695171f"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "c508cb47-6ecb-40a7-9391-e5c64c438d42", new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(5474), "AQAAAAEAACcQAAAAEFqpd3WG506/Tem6G0xYGEWWhLIu3zNHgaTIlu7rx/+Gg5oWc3YP2vDtMcpdhywNtQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58"),
                columns: new[] { "ConcurrencyStamp", "DatePasswordChanged", "PasswordHash" },
                values: new object[] { "1206298d-12d3-458e-8a97-9c159ae8b490", new DateTime(2023, 7, 16, 16, 59, 23, 774, DateTimeKind.Local).AddTicks(9937), "AQAAAAEAACcQAAAAEGG21KwuvZB+v3NL8IjrO7ffIqEgXgwFvS6jd9wimxf3po0dVPBjnp29/nxs3pHiKQ==" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6039));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(1055));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(1059));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6498));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6514));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6519));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6528));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6530));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6531));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6532));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6533));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6536));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6538));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6541));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6542));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6543));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6545));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6546));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6548));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 32,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6549));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 33,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 34,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6579));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 35,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6582));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 36,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 37,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 38,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 39,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 40,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 41,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 42,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 43,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 44,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6622));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 45,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6623));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 46,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 47,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6636));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 48,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 49,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 50,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6639));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 51,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 52,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 53,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 54,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 55,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 56,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 57,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 58,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6667));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 59,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 60,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 61,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 62,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 63,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6679));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 64,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6682));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 65,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 66,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 67,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 68,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 69,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6698));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 70,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6713));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 71,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 72,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 73,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 74,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 75,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 76,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 783, DateTimeKind.Local).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "ServiceConfigs",
                keyColumn: "ServiceConfigId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(1131));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "ServicePriceId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(696));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(711));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 16, 16, 59, 23, 728, DateTimeKind.Local).AddTicks(716));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1d314fd9-e44b-4104-9099-4069463627af"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bcbd335f-5a69-4cef-9555-ff299dfb3239"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0ae34db7-ea08-42d2-9aef-098efcdd2c1e") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("541ab1a2-f09a-432c-babf-00826480ba6c"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("75cdcc7f-0ba0-4468-98b5-bd7db97f8552"), new Guid("e1db1200-1bb6-4156-9da3-135e91d94aba"), new Guid("0b64f6f0-9f60-45c9-9e7b-f68ccc3fc57f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("eacf7b2a-1a88-40e9-a870-6e6c534d5ccb"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bc1fb812-9359-4bd8-ae73-9066aa124054"), new Guid("c489f858-aabd-4264-96c1-5cdca251d871"), new Guid("3e3245cb-bc7b-4c08-ad09-72fbd736fc9a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a605f8ef-5b0f-4bc4-9182-ca934566dc30"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("4354acbc-a32a-4a28-b865-deb49695171f") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5acdfb9b-6ab8-4017-ba9a-bff8051b15ea"), new Guid("2f0c7b75-8934-4101-bef2-c850e42d21de"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "AppUserRoleId", "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0b5a67f2-05c9-423f-9328-e78c72c667e2"), new Guid("71b1b0a6-7eab-476c-b177-1d37e120184c"), new Guid("d8682aa6-255a-4b31-aeaa-1aff35a8be58") });

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Comics");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Chapters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRating",
                table: "UserComicRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 270, DateTimeKind.Local).AddTicks(6996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 16, 59, 23, 723, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLiked",
                table: "UserComicLikes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 270, DateTimeKind.Local).AddTicks(2085),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 16, 59, 23, 722, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Genres",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 269, DateTimeKind.Local).AddTicks(2334),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 16, 59, 23, 721, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Comics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Chapters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 23, 20, 44, 262, DateTimeKind.Local).AddTicks(2269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 16, 59, 23, 708, DateTimeKind.Local).AddTicks(7442));

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
        }
    }
}

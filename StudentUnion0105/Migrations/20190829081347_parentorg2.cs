using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class parentorg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddb5fe66-c24b-467d-9dac-77c5afd38788");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be13a95b-f246-4758-8ca4-36e45d35457e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90a41a74-1ea0-4937-b352-a191a17855e8", "bf8c23ef-e8cd-44df-b45a-6937a75f948e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultLangauge", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c241d475-4a4e-438a-b790-d42fac1e15e0", 0, "eee2d4cf-6df5-4e5e-88b6-eddeb3473b7a", 41, "eplegrand@gmail.com", false, false, null, null, "EPLEGRAND@GMAIL.COM", "AQAAAAEAACcQAAAAENz3TKYdkSJi2eMWVeD3pglKKn//AllniYlKqPYFvar4NYg6l6QBeLCeLhGuBRL4VQ==", null, false, null, false, "eplegrand@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90a41a74-1ea0-4937-b352-a191a17855e8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c241d475-4a4e-438a-b790-d42fac1e15e0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ddb5fe66-c24b-467d-9dac-77c5afd38788", "873abf51-214a-458c-b1a6-db57de8c99ae", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultLangauge", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "be13a95b-f246-4758-8ca4-36e45d35457e", 0, "4de67c56-4ce0-4c69-8e1d-ac3e03b134ac", 41, "eplegrand@gmail.com", false, false, null, null, "EPLEGRAND@GMAIL.COM", "AQAAAAEAACcQAAAAENz3TKYdkSJi2eMWVeD3pglKKn//AllniYlKqPYFvar4NYg6l6QBeLCeLhGuBRL4VQ==", null, false, null, false, "eplegrand@gmail.com" });
        }
    }
}

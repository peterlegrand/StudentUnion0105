using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class parentorg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "ae422482-4dc2-43c4-84e2-c249efbdecd4", "cdc93a0d-1cd9-4677-a548-8fcdbc3b437f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultLangauge", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eb43a1eb-5eea-463f-8ff2-2b23048fd643", 0, "6f8c5590-871d-47c0-8813-8a18775663ca", 41, "eplegrand@gmail.com", false, false, null, null, "EPLEGRAND@GMAIL.COM", "AQAAAAEAACcQAAAAENz3TKYdkSJi2eMWVeD3pglKKn//AllniYlKqPYFvar4NYg6l6QBeLCeLhGuBRL4VQ==", null, false, null, false, "eplegrand@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae422482-4dc2-43c4-84e2-c249efbdecd4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb43a1eb-5eea-463f-8ff2-2b23048fd643");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90a41a74-1ea0-4937-b352-a191a17855e8", "bf8c23ef-e8cd-44df-b45a-6937a75f948e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultLangauge", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c241d475-4a4e-438a-b790-d42fac1e15e0", 0, "eee2d4cf-6df5-4e5e-88b6-eddeb3473b7a", 41, "eplegrand@gmail.com", false, false, null, null, "EPLEGRAND@GMAIL.COM", "AQAAAAEAACcQAAAAENz3TKYdkSJi2eMWVeD3pglKKn//AllniYlKqPYFvar4NYg6l6QBeLCeLhGuBRL4VQ==", null, false, null, false, "eplegrand@gmail.com" });
        }
    }
}

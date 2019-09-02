using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class parentorg4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "48a638bb-e655-4b17-b385-02c376eedd9a", "560dfd2f-7cf0-4d77-8982-daf03ec5218b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultLangauge", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "490150f4-c37f-419d-8d3e-d1540fd9e172", 0, "b55a61c9-12f8-4a7c-bedd-78aec03bc89d", 41, "eplegrand@gmail.com", false, false, null, null, "EPLEGRAND@GMAIL.COM", "AQAAAAEAACcQAAAAENz3TKYdkSJi2eMWVeD3pglKKn//AllniYlKqPYFvar4NYg6l6QBeLCeLhGuBRL4VQ==", null, false, null, false, "eplegrand@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48a638bb-e655-4b17-b385-02c376eedd9a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "490150f4-c37f-419d-8d3e-d1540fd9e172");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae422482-4dc2-43c4-84e2-c249efbdecd4", "cdc93a0d-1cd9-4677-a548-8fcdbc3b437f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultLangauge", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eb43a1eb-5eea-463f-8ff2-2b23048fd643", 0, "6f8c5590-871d-47c0-8813-8a18775663ca", 41, "eplegrand@gmail.com", false, false, null, null, "EPLEGRAND@GMAIL.COM", "AQAAAAEAACcQAAAAENz3TKYdkSJi2eMWVeD3pglKKn//AllniYlKqPYFvar4NYg6l6QBeLCeLhGuBRL4VQ==", null, false, null, false, "eplegrand@gmail.com" });
        }
    }
}

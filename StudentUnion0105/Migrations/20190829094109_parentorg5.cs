using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class parentorg5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "c5632127-5b24-4527-9b96-8b452c1b5564", "32117d85-fc15-45f5-b399-0cdce7c051ad", "Admin", "ADMIN" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5632127-5b24-4527-9b96-8b452c1b5564");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da9bd0bc-26fa-4794-9db6-42ec2f3be0ce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "48a638bb-e655-4b17-b385-02c376eedd9a", "560dfd2f-7cf0-4d77-8982-daf03ec5218b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultLangauge", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "490150f4-c37f-419d-8d3e-d1540fd9e172", 0, "b55a61c9-12f8-4a7c-bedd-78aec03bc89d", 41, "eplegrand@gmail.com", false, false, null, null, "EPLEGRAND@GMAIL.COM", "AQAAAAEAACcQAAAAENz3TKYdkSJi2eMWVeD3pglKKn//AllniYlKqPYFvar4NYg6l6QBeLCeLhGuBRL4VQ==", null, false, null, false, "eplegrand@gmail.com" });
        }
    }
}

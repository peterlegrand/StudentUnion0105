using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class AddMoreSeedData4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e1aa76d-3603-4445-b56d-a1a530c62470");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "416590b2-722e-44f0-b942-9cb093b1e9a7", "7289ecbd-6590-4f87-9225-6ec21f089470", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultLangauge", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "33d3dc01-4a46-4ccf-9554-3cba1d399dd0", 0, "0a4c3a35-3343-4298-9883-d94eeaa1e9cd", 41, "eplegrand@gmail.com", false, false, null, null, "EPLEGRAND@GMAIL.COM", null, null, false, null, false, "eplegrand@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "416590b2-722e-44f0-b942-9cb093b1e9a7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33d3dc01-4a46-4ccf-9554-3cba1d399dd0");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultLangauge", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0e1aa76d-3603-4445-b56d-a1a530c62470", 0, "fe95f00d-fe47-4278-b55e-dd392932480a", 41, "eplegrand@gmail.com", false, false, null, null, "EPLEGRAND@GMAIL.COM", null, null, false, null, false, "eplegrand@gmail.com" });
        }
    }
}

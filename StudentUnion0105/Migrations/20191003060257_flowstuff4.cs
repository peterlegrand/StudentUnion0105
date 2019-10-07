using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class flowstuff4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64a854a3-c217-46af-b99a-6a61984f8b2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc87dee6-aca1-44a2-b019-1dbaa95d88fc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "114c7525-3219-4893-86c8-eec54f39335c", "6f4c3d2f-ea08-4a6d-98b3-6a333dfcf357", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2bc9fb3-e1ae-44a9-8aee-e7f7933284f3", "0fda2d18-3b5d-4438-ac48-61098f1be0c7", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "114c7525-3219-4893-86c8-eec54f39335c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2bc9fb3-e1ae-44a9-8aee-e7f7933284f3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc87dee6-aca1-44a2-b019-1dbaa95d88fc", "af70830a-49bf-457a-8a83-b851efcfd5c2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64a854a3-c217-46af-b99a-6a61984f8b2e", "175ce399-ffda-4e40-a69e-4a4fc0cf158b", "Super admin", "SUPER ADMIN" });
        }
    }
}

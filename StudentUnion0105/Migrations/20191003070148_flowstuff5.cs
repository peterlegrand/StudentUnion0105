using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class flowstuff5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "eea79803-1698-4d2a-8f73-b54b20650ece", "6f8c0a23-6794-4da9-ad96-eadbd717d1d7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ff8660a-d6b7-4503-aca9-58c757b05027", "dcf65086-99e7-4685-8ffc-f5de116636de", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ff8660a-d6b7-4503-aca9-58c757b05027");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eea79803-1698-4d2a-8f73-b54b20650ece");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "114c7525-3219-4893-86c8-eec54f39335c", "6f4c3d2f-ea08-4a6d-98b3-6a333dfcf357", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2bc9fb3-e1ae-44a9-8aee-e7f7933284f3", "0fda2d18-3b5d-4438-ac48-61098f1be0c7", "Super admin", "SUPER ADMIN" });
        }
    }
}

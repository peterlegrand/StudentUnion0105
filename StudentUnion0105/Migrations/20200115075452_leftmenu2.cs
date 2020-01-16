using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class leftmenu2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bfaaa80-e979-4ea1-b17f-0947d1c31140");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5edaa5b-de5b-47c4-9a50-8dba7455709f");

            migrationBuilder.AddColumn<string>(
                name: "MenuAddURL",
                table: "dbLeftMenu",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f17bd31-f0e4-454c-a454-4878d71b8ef3", "b441ae43-75d2-4f62-a0b5-219647492cd6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4cc1037d-2c53-4a09-849f-862dfc3864cc", "0a39d379-04cc-4da7-ace8-57097a801428", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cc1037d-2c53-4a09-849f-862dfc3864cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f17bd31-f0e4-454c-a454-4878d71b8ef3");

            migrationBuilder.DropColumn(
                name: "MenuAddURL",
                table: "dbLeftMenu");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5edaa5b-de5b-47c4-9a50-8dba7455709f", "9d7a850a-7ca0-4257-9419-883a94e64057", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2bfaaa80-e979-4ea1-b17f-0947d1c31140", "d536b486-a555-4b14-b711-66dd3fda6ce9", "Super admin", "SUPER ADMIN" });
        }
    }
}

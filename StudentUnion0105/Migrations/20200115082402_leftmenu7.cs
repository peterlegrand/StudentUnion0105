using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class leftmenu7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49971536-2404-4696-9549-0001719c43dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5477a11-1233-4f3c-a877-bbbadce81513");

            migrationBuilder.RenameColumn(
                name: "MouseOver",
                table: "dbLeftMenuLanguage",
                newName: "MainName");

            migrationBuilder.RenameColumn(
                name: "MenuName",
                table: "dbLeftMenuLanguage",
                newName: "MainMouseOver");

            migrationBuilder.AddColumn<string>(
                name: "AddMenuName",
                table: "dbLeftMenuLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddMouseOver",
                table: "dbLeftMenuLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00ddd63b-e7fd-453e-a087-393835747d00", "5cc9a4b5-a34d-40ca-aa1e-72eef981e5be", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15aca2c7-d78e-442a-b33e-5e9690f00cef", "13b73ba7-2961-4125-8b3f-383088c35b16", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00ddd63b-e7fd-453e-a087-393835747d00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15aca2c7-d78e-442a-b33e-5e9690f00cef");

            migrationBuilder.DropColumn(
                name: "AddMenuName",
                table: "dbLeftMenuLanguage");

            migrationBuilder.DropColumn(
                name: "AddMouseOver",
                table: "dbLeftMenuLanguage");

            migrationBuilder.RenameColumn(
                name: "MainName",
                table: "dbLeftMenuLanguage",
                newName: "MouseOver");

            migrationBuilder.RenameColumn(
                name: "MainMouseOver",
                table: "dbLeftMenuLanguage",
                newName: "MenuName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49971536-2404-4696-9549-0001719c43dc", "d4aa3a87-f0c8-4dd9-8dab-ae9c0ca2f381", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5477a11-1233-4f3c-a877-bbbadce81513", "aa59a037-98e8-447f-bfb3-1169d38c36ff", "Super admin", "SUPER ADMIN" });
        }
    }
}

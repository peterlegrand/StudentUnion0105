using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class leftmenu8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00ddd63b-e7fd-453e-a087-393835747d00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15aca2c7-d78e-442a-b33e-5e9690f00cef");

            migrationBuilder.RenameColumn(
                name: "AddMenuName",
                table: "dbLeftMenuLanguage",
                newName: "AddName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4c7d52c-1e00-4008-8d70-6e95ed8f369f", "a95637ca-5a8f-40cf-b4e8-51598597cb0f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1cf3aac-db08-4f61-a3cf-0e043e5aa909", "ff52ace4-e17e-4473-bfde-7fccaeb486c8", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4c7d52c-1e00-4008-8d70-6e95ed8f369f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1cf3aac-db08-4f61-a3cf-0e043e5aa909");

            migrationBuilder.RenameColumn(
                name: "AddName",
                table: "dbLeftMenuLanguage",
                newName: "AddMenuName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00ddd63b-e7fd-453e-a087-393835747d00", "5cc9a4b5-a34d-40ca-aa1e-72eef981e5be", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15aca2c7-d78e-442a-b33e-5e9690f00cef", "13b73ba7-2961-4125-8b3f-383088c35b16", "Super admin", "SUPER ADMIN" });
        }
    }
}

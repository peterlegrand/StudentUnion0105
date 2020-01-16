using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class leftmenu3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cc1037d-2c53-4a09-849f-862dfc3864cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f17bd31-f0e4-454c-a454-4878d71b8ef3");

            migrationBuilder.AddColumn<bool>(
                name: "AdvancedSearchShow",
                table: "dbLeftMenuUser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SearchShow",
                table: "dbLeftMenuUser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasAdvancedSearch",
                table: "dbLeftMenu",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasMenu",
                table: "dbLeftMenu",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasMenuAdd",
                table: "dbLeftMenu",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSearch",
                table: "dbLeftMenu",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "717f8293-acbd-490c-8ec8-5d684b6f2d6d", "c7beec3a-2612-43bb-b84f-2c74a7f1ae78", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ebf41719-72b7-41a1-804f-4242bbe61bb2", "824bffa8-05a7-4747-9a5b-cb528bad219d", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "717f8293-acbd-490c-8ec8-5d684b6f2d6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebf41719-72b7-41a1-804f-4242bbe61bb2");

            migrationBuilder.DropColumn(
                name: "AdvancedSearchShow",
                table: "dbLeftMenuUser");

            migrationBuilder.DropColumn(
                name: "SearchShow",
                table: "dbLeftMenuUser");

            migrationBuilder.DropColumn(
                name: "HasAdvancedSearch",
                table: "dbLeftMenu");

            migrationBuilder.DropColumn(
                name: "HasMenu",
                table: "dbLeftMenu");

            migrationBuilder.DropColumn(
                name: "HasMenuAdd",
                table: "dbLeftMenu");

            migrationBuilder.DropColumn(
                name: "HasSearch",
                table: "dbLeftMenu");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f17bd31-f0e4-454c-a454-4878d71b8ef3", "b441ae43-75d2-4f62-a0b5-219647492cd6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4cc1037d-2c53-4a09-849f-862dfc3864cc", "0a39d379-04cc-4da7-ace8-57097a801428", "Super admin", "SUPER ADMIN" });
        }
    }
}

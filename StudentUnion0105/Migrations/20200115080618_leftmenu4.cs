using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class leftmenu4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "717f8293-acbd-490c-8ec8-5d684b6f2d6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebf41719-72b7-41a1-804f-4242bbe61bb2");

            migrationBuilder.RenameColumn(
                name: "MenuURL",
                table: "dbLeftMenu",
                newName: "MainURL");

            migrationBuilder.RenameColumn(
                name: "MenuAddURL",
                table: "dbLeftMenu",
                newName: "AddURL");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fe6cc53-b471-4d93-91cc-e2ce34d0c885", "d38f1403-375e-4223-a12e-503d63efaa4a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78161f8c-a369-415c-bff5-c547940fe921", "6a9ef7dd-1544-48ca-af2f-dcab011bc72d", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78161f8c-a369-415c-bff5-c547940fe921");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fe6cc53-b471-4d93-91cc-e2ce34d0c885");

            migrationBuilder.RenameColumn(
                name: "MainURL",
                table: "dbLeftMenu",
                newName: "MenuURL");

            migrationBuilder.RenameColumn(
                name: "AddURL",
                table: "dbLeftMenu",
                newName: "MenuAddURL");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "717f8293-acbd-490c-8ec8-5d684b6f2d6d", "c7beec3a-2612-43bb-b84f-2c74a7f1ae78", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ebf41719-72b7-41a1-804f-4242bbe61bb2", "824bffa8-05a7-4747-9a5b-cb528bad219d", "Super admin", "SUPER ADMIN" });
        }
    }
}

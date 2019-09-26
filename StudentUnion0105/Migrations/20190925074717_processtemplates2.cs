using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class processtemplates2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ea67e24-a691-4894-a27b-f38d37b7aab5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97f07be5-c035-4839-80af-7e0d3cf4d095");

            migrationBuilder.RenameColumn(
                name: "SuProcessTemplateMouseOver",
                table: "dbProcessTemplateLanguage",
                newName: "ProcessTemplateMouseOver");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "dbProcessTemplate",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16892f9f-a9f0-4b22-abfe-af2533de960e", "3e12192f-31b2-465d-a0fe-84963471a924", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "444a0f6b-2f3f-4c2d-a10c-4780dc853450", "e4ea6913-ca83-4dff-ab85-16ce4b4aa30a", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16892f9f-a9f0-4b22-abfe-af2533de960e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "444a0f6b-2f3f-4c2d-a10c-4780dc853450");

            migrationBuilder.RenameColumn(
                name: "ProcessTemplateMouseOver",
                table: "dbProcessTemplateLanguage",
                newName: "SuProcessTemplateMouseOver");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "dbProcessTemplate",
                newName: "ID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97f07be5-c035-4839-80af-7e0d3cf4d095", "2503a8c4-23ab-4cae-8db4-9a620fa939d6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ea67e24-a691-4894-a27b-f38d37b7aab5", "d3d78e06-acbe-428f-9408-4a6a75af2663", "Super admin", "SUPER ADMIN" });
        }
    }
}

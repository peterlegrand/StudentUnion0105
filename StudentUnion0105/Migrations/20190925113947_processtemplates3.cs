using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class processtemplates3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "SuProcessTemplateGroupMouseOver",
                table: "dbProcessTemplateGroupLanguage",
                newName: "ProcessTemplateGroupMouseOver");

            migrationBuilder.RenameColumn(
                name: "SuProcessTemplateFieldMouseOver",
                table: "dbProcessTemplateFieldLanguage",
                newName: "ProcessTemplateFieldMouseOver");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a67d9932-13b9-41cb-91a0-99fc50fb2c98", "dd2f63a7-6712-4fc6-b4e4-102de9a8052c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5c1bfed-38e9-4457-9538-f6e15ba55562", "8606dabf-4a0b-4ce4-af4d-1c09c01077fa", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5c1bfed-38e9-4457-9538-f6e15ba55562");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a67d9932-13b9-41cb-91a0-99fc50fb2c98");

            migrationBuilder.RenameColumn(
                name: "ProcessTemplateGroupMouseOver",
                table: "dbProcessTemplateGroupLanguage",
                newName: "SuProcessTemplateGroupMouseOver");

            migrationBuilder.RenameColumn(
                name: "ProcessTemplateFieldMouseOver",
                table: "dbProcessTemplateFieldLanguage",
                newName: "SuProcessTemplateFieldMouseOver");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16892f9f-a9f0-4b22-abfe-af2533de960e", "3e12192f-31b2-465d-a0fe-84963471a924", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "444a0f6b-2f3f-4c2d-a10c-4780dc853450", "e4ea6913-ca83-4dff-ab85-16ce4b4aa30a", "Super admin", "SUPER ADMIN" });
        }
    }
}

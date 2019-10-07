using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class stepnamefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dbf6907-d76a-4ee3-9d93-46df7b07e741");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c403d671-69b2-4a34-a9a3-7909fda2df62");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "dbProcessTemplateStepLanguage",
                newName: "ProcessTemplateStepName");

            migrationBuilder.RenameColumn(
                name: "MouseOver",
                table: "dbProcessTemplateStepLanguage",
                newName: "ProcessTemplateStepMouseOver");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "dbProcessTemplateStepLanguage",
                newName: "ProcessTemplateStepDescription");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ffb39abc-c9e9-410b-8e78-de538f64333d", "86e11765-ea95-4e65-af45-0b9ab550159f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5fe687a1-b2d0-4911-9c71-303c70cb43e8", "07e519f2-ae3f-4ec3-875b-f5ae90e8525d", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fe687a1-b2d0-4911-9c71-303c70cb43e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffb39abc-c9e9-410b-8e78-de538f64333d");

            migrationBuilder.RenameColumn(
                name: "ProcessTemplateStepName",
                table: "dbProcessTemplateStepLanguage",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProcessTemplateStepMouseOver",
                table: "dbProcessTemplateStepLanguage",
                newName: "MouseOver");

            migrationBuilder.RenameColumn(
                name: "ProcessTemplateStepDescription",
                table: "dbProcessTemplateStepLanguage",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c403d671-69b2-4a34-a9a3-7909fda2df62", "67f67c93-3e86-46df-aac3-8032aa8b32c7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0dbf6907-d76a-4ee3-9d93-46df7b07e741", "7597887f-d357-44df-8ca8-8e3c9a43a1fe", "Super admin", "SUPER ADMIN" });
        }
    }
}

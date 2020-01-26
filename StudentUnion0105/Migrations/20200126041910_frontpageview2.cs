using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class frontpageview2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "052ef3eb-7f3c-4d8b-9129-b2a3ba28f074");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e875352f-7b0f-40fc-a838-9897810c462d");

            migrationBuilder.RenameColumn(
                name: "ClassicationName",
                table: "ZdbSuFrontPageViewGetClassificationValues",
                newName: "ClassificationName");

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentUser",
                table: "ZdbFrontPageViewGet",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4b26dbf-dece-42b0-8bf0-091c46b1490f", "289d4aff-0e72-4ae8-b5cd-a7d23fd4c0bb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c5b29f7-5ee9-44a6-9ab5-550b8f5382f7", "8a3839cd-6ce2-4deb-a087-996a4bff388a", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c5b29f7-5ee9-44a6-9ab5-550b8f5382f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4b26dbf-dece-42b0-8bf0-091c46b1490f");

            migrationBuilder.DropColumn(
                name: "IsCurrentUser",
                table: "ZdbFrontPageViewGet");

            migrationBuilder.RenameColumn(
                name: "ClassificationName",
                table: "ZdbSuFrontPageViewGetClassificationValues",
                newName: "ClassicationName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "052ef3eb-7f3c-4d8b-9129-b2a3ba28f074", "b546e3c7-4b29-499d-b7ea-954830cf02b1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e875352f-7b0f-40fc-a838-9897810c462d", "310e345b-211b-4149-94fa-b126e1294880", "Super admin", "SUPER ADMIN" });
        }
    }
}

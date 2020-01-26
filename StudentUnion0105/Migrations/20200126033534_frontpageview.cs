using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class frontpageview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a237c92-4686-4ddc-9313-46fc28c5d3ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a4cac03-0ad3-4b13-90fa-3826ed315859");

            migrationBuilder.CreateTable(
                name: "ZdbSuFrontPageViewGetClassificationValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ValueName = table.Column<string>(nullable: true),
                    ClassicationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbSuFrontPageViewGetClassificationValues", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "052ef3eb-7f3c-4d8b-9129-b2a3ba28f074", "b546e3c7-4b29-499d-b7ea-954830cf02b1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e875352f-7b0f-40fc-a838-9897810c462d", "310e345b-211b-4149-94fa-b126e1294880", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbSuFrontPageViewGetClassificationValues");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "052ef3eb-7f3c-4d8b-9129-b2a3ba28f074");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e875352f-7b0f-40fc-a838-9897810c462d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a237c92-4686-4ddc-9313-46fc28c5d3ce", "aa5287e2-377b-4743-a765-81528bc98ef9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a4cac03-0ad3-4b13-90fa-3826ed315859", "a896e22a-dc99-4b98-8d1c-68e59ea1b7eb", "Super admin", "SUPER ADMIN" });
        }
    }
}

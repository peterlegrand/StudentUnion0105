using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class fresh2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "591975eb-fb35-428d-a6c5-45ff688f9bdc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6efc6d1-2613-4b43-8a7e-75a64bc21452");

            migrationBuilder.CreateTable(
                name: "ZdbHomeIndexAdminGetLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbHomeIndexAdminGetLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbHomeIndexAdminGetTableName",
                columns: table => new
                {
                    TableDescription = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbHomeIndexAdminGetTableName", x => x.TableDescription);
                });

            migrationBuilder.CreateTable(
                name: "ZdbHomeIndexAdminGetNoOfRecordsAndPerLanguage",
                columns: table => new
                {
                    LanguageName = table.Column<string>(nullable: false),
                    TableDescription = table.Column<string>(nullable: true),
                    NoOfRecords = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbHomeIndexAdminGetNoOfRecordsAndPerLanguage", x => x.LanguageName);
                    table.ForeignKey(
                        name: "FK_ZdbHomeIndexAdminGetNoOfRecordsAndPerLanguage_ZdbHomeIndexAdminGetTableName_TableDescription",
                        column: x => x.TableDescription,
                        principalTable: "ZdbHomeIndexAdminGetTableName",
                        principalColumn: "TableDescription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a237c92-4686-4ddc-9313-46fc28c5d3ce", "aa5287e2-377b-4743-a765-81528bc98ef9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a4cac03-0ad3-4b13-90fa-3826ed315859", "a896e22a-dc99-4b98-8d1c-68e59ea1b7eb", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_ZdbHomeIndexAdminGetNoOfRecordsAndPerLanguage_TableDescription",
                table: "ZdbHomeIndexAdminGetNoOfRecordsAndPerLanguage",
                column: "TableDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbHomeIndexAdminGetLanguages");

            migrationBuilder.DropTable(
                name: "ZdbHomeIndexAdminGetNoOfRecordsAndPerLanguage");

            migrationBuilder.DropTable(
                name: "ZdbHomeIndexAdminGetTableName");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a237c92-4686-4ddc-9313-46fc28c5d3ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a4cac03-0ad3-4b13-90fa-3826ed315859");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "591975eb-fb35-428d-a6c5-45ff688f9bdc", "604d129f-6f27-482f-b859-30914676664b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f6efc6d1-2613-4b43-8a7e-75a64bc21452", "4af1de92-ac53-4d7d-b04c-d53fa243109d", "Super admin", "SUPER ADMIN" });
        }
    }
}

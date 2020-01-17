using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class topmenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b550720f-d84f-4481-a26e-a7979bde0df9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2309876-e259-4cac-b965-efd5e1b0e1f6");

            migrationBuilder.CreateTable(
                name: "ZdbTopMenu1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuName = table.Column<string>(nullable: true),
                    MenuController = table.Column<string>(nullable: true),
                    MenuAction = table.Column<string>(nullable: true),
                    MenuDestinationId = table.Column<int>(nullable: false),
                    IconCss = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbTopMenu1", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e2b8167-abb0-4449-8a33-c19ef42bc0ca", "ee3e0896-1ed9-4f88-980f-71f527c4077c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b31d2cf-c2be-4b7b-8493-c5cce47c4bc9", "01b15cb0-5068-45b2-a325-9242c01848cb", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbTopMenu1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b31d2cf-c2be-4b7b-8493-c5cce47c4bc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e2b8167-abb0-4449-8a33-c19ef42bc0ca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b550720f-d84f-4481-a26e-a7979bde0df9", "82abdee3-7c2d-475f-b219-4934b66590b9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2309876-e259-4cac-b965-efd5e1b0e1f6", "8a2d8c44-0243-4249-8de0-ab5e832aea3c", "Super admin", "SUPER ADMIN" });
        }
    }
}

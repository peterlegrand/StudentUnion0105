using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class userstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "264cf283-d9d0-473e-b928-5d68c51a1e56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a055b720-c298-41b8-8f49-3ccfcfe12bae");

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "dbTermScreen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "dbCountryList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbCountryList", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9b6ce57-8d26-43be-8536-38b648004747", "161c3d9b-07a5-438d-a146-5848a43ebcdd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a3f6870-9e9d-47a3-bb48-8545b2a01b38", "039a12a5-205b-4260-8a40-e81705e9890b", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbCountryList");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a3f6870-9e9d-47a3-bb48-8545b2a01b38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9b6ce57-8d26-43be-8536-38b648004747");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "dbTermScreen");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "264cf283-d9d0-473e-b928-5d68c51a1e56", "1d9fafc4-6bcd-430f-afd5-9bb198e21c0d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a055b720-c298-41b8-8f49-3ccfcfe12bae", "b003e6de-86b3-454e-8401-9b1ecc79b773", "Super admin", "SUPER ADMIN" });
        }
    }
}

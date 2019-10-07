using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class addcountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fde9bce-9893-4bf9-a23f-dc767c1b2973");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b71cb87b-ba43-4c98-937c-1e71e197b6a8");

            migrationBuilder.CreateTable(
                name: "dbCountry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: false),
                    ForeignName = table.Column<string>(nullable: true),
                    ISO31662 = table.Column<string>(nullable: true),
                    ISO31663 = table.Column<string>(nullable: true),
                    ISO3166Num = table.Column<int>(nullable: false),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbCountry", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bdc0d4d4-021c-45aa-a71d-4f06b283a7c4", "937d9c83-6b98-4b87-b4a1-40e636e1d0dd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2892773-59bf-4dfb-980d-dccc2165cc20", "f47891da-ce7a-4941-8cd4-903bff56473d", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbCountry");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdc0d4d4-021c-45aa-a71d-4f06b283a7c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2892773-59bf-4dfb-980d-dccc2165cc20");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b71cb87b-ba43-4c98-937c-1e71e197b6a8", "b8fec86c-7371-45a4-ac1c-463f6fcd6a4b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fde9bce-9893-4bf9-a23f-dc767c1b2973", "dcb364c0-45b8-4d6a-a4aa-8faaec6ff534", "Super admin", "SUPER ADMIN" });
        }
    }
}

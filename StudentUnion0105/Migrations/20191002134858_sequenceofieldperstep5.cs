using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class sequenceofieldperstep5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70e8ecb7-e565-489b-b84a-a7064d93aa3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3e0ee35-fbf5-4c91-a155-15e9f231fe3c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e830224-8600-4bdf-b012-3f8f719501e7", "0373b872-acc6-4dbc-aade-ab6ebed416ed", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52b9c140-b5ea-4526-978a-2a8dbd946c42", "320b64da-fb5a-4d12-935d-1bc723657ee0", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e830224-8600-4bdf-b012-3f8f719501e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52b9c140-b5ea-4526-978a-2a8dbd946c42");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70e8ecb7-e565-489b-b84a-a7064d93aa3b", "8cd1c187-fbad-4dd5-af6b-dbfbd48b958e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3e0ee35-fbf5-4c91-a155-15e9f231fe3c", "33731e85-686b-4b7e-ac09-9c1058c1a867", "Super admin", "SUPER ADMIN" });
        }
    }
}

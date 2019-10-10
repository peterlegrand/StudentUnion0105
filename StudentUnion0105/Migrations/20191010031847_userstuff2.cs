using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class userstuff2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a3f6870-9e9d-47a3-bb48-8545b2a01b38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9b6ce57-8d26-43be-8536-38b648004747");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "AspNetUsers",
                newName: "CountryId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "131a6f89-3879-471f-b033-474a3f1d0fc7", "7dd3ecd2-0e3a-4775-87f0-3ed737e57409", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb34fe58-63e5-40ef-8d3a-50942462da19", "acac1faa-ee79-4aa0-a02b-0779ce89b85f", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "131a6f89-3879-471f-b033-474a3f1d0fc7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb34fe58-63e5-40ef-8d3a-50942462da19");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "AspNetUsers",
                newName: "Country");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9b6ce57-8d26-43be-8536-38b648004747", "161c3d9b-07a5-438d-a146-5848a43ebcdd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a3f6870-9e9d-47a3-bb48-8545b2a01b38", "039a12a5-205b-4260-8a40-e81705e9890b", "Super admin", "SUPER ADMIN" });
        }
    }
}

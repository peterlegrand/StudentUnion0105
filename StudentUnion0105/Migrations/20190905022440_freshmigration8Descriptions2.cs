using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class freshmigration8Descriptions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d9fffb9-0835-4963-ab0d-bc5c82c3ded3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0bce2e0-0402-4ea2-9dc8-3bc442940d03");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7bb5b2dd-f06d-42c2-8fd1-42116c0a7f98", "320080ec-d468-47d2-83e8-b394a94959b4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "505ce9cc-922e-4348-9781-6fbd7cc528de", "c751525d-402b-4fde-baed-79699905558d", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "505ce9cc-922e-4348-9781-6fbd7cc528de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bb5b2dd-f06d-42c2-8fd1-42116c0a7f98");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d9fffb9-0835-4963-ab0d-bc5c82c3ded3", "8e2965fa-3421-4330-8127-b91999a07416", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0bce2e0-0402-4ea2-9dc8-3bc442940d03", "d4a6db6f-3685-4101-b53a-71c7df02e948", "Super admin", "SUPER ADMIN" });
        }
    }
}

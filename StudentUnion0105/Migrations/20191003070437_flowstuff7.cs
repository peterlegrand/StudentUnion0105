using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class flowstuff7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "465779de-f279-4ae2-80ec-c65d06a2c2d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae37a772-b977-4c9f-95af-2ac1c6d762f3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "067cea50-9886-411b-beb0-79234c81d3ee", "70a5182a-b620-44d8-ab0d-df2cfa877296", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29b52066-5c95-4c07-bb72-e4ffdf75c4be", "cf8dd447-8a75-4f0e-84c3-205dd588139a", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "067cea50-9886-411b-beb0-79234c81d3ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29b52066-5c95-4c07-bb72-e4ffdf75c4be");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "465779de-f279-4ae2-80ec-c65d06a2c2d9", "0bbcabfe-a50c-45e5-bd88-ca9909bb9b3b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae37a772-b977-4c9f-95af-2ac1c6d762f3", "9fb90255-e79b-47ec-94fd-686b3e18c1cf", "Super admin", "SUPER ADMIN" });
        }
    }
}

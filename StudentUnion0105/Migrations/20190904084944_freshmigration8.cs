using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class freshmigration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87039d7f-0a96-4f46-8a85-c58a74cd69a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a695700d-79a8-4e5b-9b12-8b5dbc6edb3a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca26d3b0-be59-4c91-b7bd-01eebe6f5a6a", "8a2839b3-10a7-4ac1-b29a-48fd90668ce9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3bc1021-faf2-4a18-a5c5-3ee85a9abf8f", "d6d35c98-1932-4923-9fde-a0dfec8cb5e2", "Super admin", "SUPER ADMIN" });

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 3,
                column: "Claim",
                value: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3bc1021-faf2-4a18-a5c5-3ee85a9abf8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca26d3b0-be59-4c91-b7bd-01eebe6f5a6a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a695700d-79a8-4e5b-9b12-8b5dbc6edb3a", "db98c7d2-36df-4fcf-9cec-89972a2bc3cc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87039d7f-0a96-4f46-8a85-c58a74cd69a0", "3eb074dd-03c3-4f46-b64c-5d8061606ec7", "Super admin", "SUPER ADMIN" });

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 3,
                column: "Claim",
                value: "Roles");
        }
    }
}

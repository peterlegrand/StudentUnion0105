using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class freshmigration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02760e7f-6215-4d77-92ce-2001cc347b30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae97c75a-0762-447b-b9c2-e89320176951");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a695700d-79a8-4e5b-9b12-8b5dbc6edb3a", "db98c7d2-36df-4fcf-9cec-89972a2bc3cc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87039d7f-0a96-4f46-8a85-c58a74cd69a0", "3eb074dd-03c3-4f46-b64c-5d8061606ec7", "Super admin", "SUPER ADMIN" });

            migrationBuilder.InsertData(
                table: "dbClaim",
                columns: new[] { "Id", "Claim", "ClaimGroup", "ClaimType" },
                values: new object[] { 10, "Type", "Type", "Menu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87039d7f-0a96-4f46-8a85-c58a74cd69a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a695700d-79a8-4e5b-9b12-8b5dbc6edb3a");

            migrationBuilder.DeleteData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae97c75a-0762-447b-b9c2-e89320176951", "8ddb0d15-0eb4-43ca-85ed-5a1f0be94d33", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02760e7f-6215-4d77-92ce-2001cc347b30", "3f6d680c-bac4-4592-90b7-f6312d8860a4", "Super admin", "SUPER ADMIN" });
        }
    }
}

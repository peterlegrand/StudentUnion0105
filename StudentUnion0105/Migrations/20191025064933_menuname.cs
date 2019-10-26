using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class menuname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47d659e9-e7f6-41fb-9cc6-d34a3955b387");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fca0c82b-5f23-48d6-ae75-1909d77543a9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff02fc31-573b-4f0b-8586-042fc2df5a82", "99457f21-edca-42e6-aadb-b3789143e437", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ad10056-5422-4229-82de-f018b5c34217", "a1491015-565b-4aa0-bc6a-30c7d87d5cb0", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ad10056-5422-4229-82de-f018b5c34217");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff02fc31-573b-4f0b-8586-042fc2df5a82");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "47d659e9-e7f6-41fb-9cc6-d34a3955b387", "63704595-21b9-41fc-b954-bf7d07b0b73a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fca0c82b-5f23-48d6-ae75-1909d77543a9", "2a411aa2-e3ed-4819-81e6-06b068f4dc6a", "Super admin", "SUPER ADMIN" });
        }
    }
}

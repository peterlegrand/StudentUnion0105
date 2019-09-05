using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class freshmigration8Descriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3bc1021-faf2-4a18-a5c5-3ee85a9abf8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca26d3b0-be59-4c91-b7bd-01eebe6f5a6a");

            migrationBuilder.AddColumn<string>(
                name: "ClassificationLevelDescription",
                table: "dbClassificationLevelLanguage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassificationDescription",
                table: "dbClassificationLanguage",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d9fffb9-0835-4963-ab0d-bc5c82c3ded3", "8e2965fa-3421-4330-8127-b91999a07416", "Admin", "ADMIN" },
                    { "b0bce2e0-0402-4ea2-9dc8-3bc442940d03", "d4a6db6f-3685-4101-b53a-71c7df02e948", "Super admin", "SUPER ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 5,
                column: "ClaimGroup",
                value: "Type");

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 6,
                column: "ClaimGroup",
                value: "Type");

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 7,
                column: "ClaimGroup",
                value: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d9fffb9-0835-4963-ab0d-bc5c82c3ded3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0bce2e0-0402-4ea2-9dc8-3bc442940d03");

            migrationBuilder.DropColumn(
                name: "ClassificationLevelDescription",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.DropColumn(
                name: "ClassificationDescription",
                table: "dbClassificationLanguage");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ca26d3b0-be59-4c91-b7bd-01eebe6f5a6a", "8a2839b3-10a7-4ac1-b29a-48fd90668ce9", "Admin", "ADMIN" },
                    { "b3bc1021-faf2-4a18-a5c5-3ee85a9abf8f", "d6d35c98-1932-4923-9fde-a0dfec8cb5e2", "Super admin", "SUPER ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 5,
                column: "ClaimGroup",
                value: "Types");

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 6,
                column: "ClaimGroup",
                value: "Types");

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 7,
                column: "ClaimGroup",
                value: "Types");
        }
    }
}

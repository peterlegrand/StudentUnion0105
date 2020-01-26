using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class frontpageview22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c5b29f7-5ee9-44a6-9ab5-550b8f5382f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4b26dbf-dece-42b0-8bf0-091c46b1490f");

            migrationBuilder.AlterColumn<int>(
                name: "IsCurrentUser",
                table: "ZdbFrontPageViewGet",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35a68c07-39c0-4029-b605-aa1ee03d66e8", "3553a95a-c113-4384-9d14-539bb08c3437", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "314e79b6-d994-4c0d-89ca-4a762da16c7a", "6eaf86bf-3f12-488a-aa75-aa0bef4f2630", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "314e79b6-d994-4c0d-89ca-4a762da16c7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35a68c07-39c0-4029-b605-aa1ee03d66e8");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCurrentUser",
                table: "ZdbFrontPageViewGet",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4b26dbf-dece-42b0-8bf0-091c46b1490f", "289d4aff-0e72-4ae8-b5cd-a7d23fd4c0bb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c5b29f7-5ee9-44a6-9ab5-550b8f5382f7", "8a3839cd-6ce2-4deb-a087-996a4bff388a", "Super admin", "SUPER ADMIN" });
        }
    }
}

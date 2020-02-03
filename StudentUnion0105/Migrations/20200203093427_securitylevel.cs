using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class securitylevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4da81dd9-8df2-4121-9f85-1991770bb8a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "515cee09-4337-45ad-bad9-a6d1dd23f5ac");

            migrationBuilder.AddColumn<int>(
                name: "SecurityLevel",
                table: "ZdbContentTypeEditGet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecurityLevel",
                table: "DbContentTypeDeleteGet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecurityLevel",
                table: "DbContentType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a37355ec-c5c6-4c06-b4ff-73e64aeeac60", "ecfee822-8e43-4d8f-a71c-2f138495e82c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30d98497-df0c-463c-8557-f4adc9b9a69d", "8e0f2d39-339a-4474-9df2-870ff04a4639", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30d98497-df0c-463c-8557-f4adc9b9a69d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a37355ec-c5c6-4c06-b4ff-73e64aeeac60");

            migrationBuilder.DropColumn(
                name: "SecurityLevel",
                table: "ZdbContentTypeEditGet");

            migrationBuilder.DropColumn(
                name: "SecurityLevel",
                table: "DbContentTypeDeleteGet");

            migrationBuilder.DropColumn(
                name: "SecurityLevel",
                table: "DbContentType");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "515cee09-4337-45ad-bad9-a6d1dd23f5ac", "8fdd4228-1d34-4105-a0c8-cedb10ca51f5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4da81dd9-8df2-4121-9f85-1991770bb8a8", "b27281df-6035-4fbd-8aa2-d691296805b3", "Super admin", "SUPER ADMIN" });
        }
    }
}

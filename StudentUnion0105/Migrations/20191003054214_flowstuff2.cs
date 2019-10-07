using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class flowstuff2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8572960b-efdc-462d-9f33-cad6d6ab3429");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef4ddcf0-10f1-4905-8ef5-1b134d868c4c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1c71d4d-dbc3-494b-9241-0c1f3ab402c5", "d75c9019-ea45-4cb3-9bf0-5f143447c522", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f3f3c99-6182-4248-89fc-a4a52844dc74", "9b83948e-7890-41a3-8d85-cf7c0e31646b", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f3f3c99-6182-4248-89fc-a4a52844dc74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1c71d4d-dbc3-494b-9241-0c1f3ab402c5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8572960b-efdc-462d-9f33-cad6d6ab3429", "e4c20088-d70c-491b-b289-d2dd5188f371", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef4ddcf0-10f1-4905-8ef5-1b134d868c4c", "f67423f3-813a-4d07-8a80-cbc040440999", "Super admin", "SUPER ADMIN" });
        }
    }
}

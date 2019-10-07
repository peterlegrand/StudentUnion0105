using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class flowstuff3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "dc87dee6-aca1-44a2-b019-1dbaa95d88fc", "af70830a-49bf-457a-8a83-b851efcfd5c2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64a854a3-c217-46af-b99a-6a61984f8b2e", "175ce399-ffda-4e40-a69e-4a4fc0cf158b", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64a854a3-c217-46af-b99a-6a61984f8b2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc87dee6-aca1-44a2-b019-1dbaa95d88fc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1c71d4d-dbc3-494b-9241-0c1f3ab402c5", "d75c9019-ea45-4cb3-9bf0-5f143447c522", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f3f3c99-6182-4248-89fc-a4a52844dc74", "9b83948e-7890-41a3-8d85-cf7c0e31646b", "Super admin", "SUPER ADMIN" });
        }
    }
}

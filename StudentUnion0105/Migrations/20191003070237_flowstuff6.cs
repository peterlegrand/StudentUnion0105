using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class flowstuff6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ff8660a-d6b7-4503-aca9-58c757b05027");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eea79803-1698-4d2a-8f73-b54b20650ece");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "465779de-f279-4ae2-80ec-c65d06a2c2d9", "0bbcabfe-a50c-45e5-bd88-ca9909bb9b3b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae37a772-b977-4c9f-95af-2ac1c6d762f3", "9fb90255-e79b-47ec-94fd-686b3e18c1cf", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "eea79803-1698-4d2a-8f73-b54b20650ece", "6f8c0a23-6794-4da9-ad96-eadbd717d1d7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ff8660a-d6b7-4503-aca9-58c757b05027", "dcf65086-99e7-4685-8ffc-f5de116636de", "Super admin", "SUPER ADMIN" });
        }
    }
}

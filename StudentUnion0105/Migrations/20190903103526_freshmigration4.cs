using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class freshmigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef3d2a98-d41e-4995-a5b3-a5c9c2566351");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0da65bfb-9fac-434e-b6e3-9eeb92489b51", "12117dd1-a8ab-4497-8a19-3f98caf36e98", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c2e4a2d-d101-4d1b-a6d7-220c52bfc399", "152a9170-acf7-4339-98fd-22143a6f3006", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0da65bfb-9fac-434e-b6e3-9eeb92489b51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c2e4a2d-d101-4d1b-a6d7-220c52bfc399");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef3d2a98-d41e-4995-a5b3-a5c9c2566351", "39f2f3d9-99e7-4aad-b795-f62d89d18ba5", "Admin", "ADMIN" });
        }
    }
}

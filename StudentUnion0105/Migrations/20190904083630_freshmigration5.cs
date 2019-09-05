using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class freshmigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0da65bfb-9fac-434e-b6e3-9eeb92489b51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c2e4a2d-d101-4d1b-a6d7-220c52bfc399");

            migrationBuilder.AddColumn<string>(
                name: "ClaimType",
                table: "dbClaim",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67cf88b2-44b5-44ca-8472-b7f1d0756ff9", "7ea4f7a8-a3fd-4176-bcbd-22e13c9e1780", "Admin", "ADMIN" },
                    { "4743a993-6fe5-439b-95c0-6d5cd16e1f33", "4f859ea0-0cb1-42e2-91e9-633d9e229c8e", "Super admin", "SUPER ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClaimType",
                value: "Menu");

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClaimType",
                value: "Menu");

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClaimType",
                value: "Menu");

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClaimType",
                value: "Menu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4743a993-6fe5-439b-95c0-6d5cd16e1f33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67cf88b2-44b5-44ca-8472-b7f1d0756ff9");

            migrationBuilder.DropColumn(
                name: "ClaimType",
                table: "dbClaim");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0da65bfb-9fac-434e-b6e3-9eeb92489b51", "12117dd1-a8ab-4497-8a19-3f98caf36e98", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c2e4a2d-d101-4d1b-a6d7-220c52bfc399", "152a9170-acf7-4339-98fd-22143a6f3006", "Super admin", "SUPER ADMIN" });
        }
    }
}

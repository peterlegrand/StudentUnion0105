using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class userorg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29e32a1b-cfb9-43dd-aacc-678d9f064270");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57436b03-a584-44c1-9d84-87b488199ac6");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbIdWithStrings");

            migrationBuilder.DropColumn(
                name: "MouseOver",
                table: "dbIdWithStrings");

            migrationBuilder.DropColumn(
                name: "String1",
                table: "dbIdWithStrings");

            migrationBuilder.DropColumn(
                name: "String2",
                table: "dbIdWithStrings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dea7c34d-b863-4114-86ad-00daa006f480", "bf03105d-4558-4135-8240-f66104f899b3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37624060-f541-4b91-b600-bf60ab3223b0", "87d5f39e-1e85-4e20-9938-27bdc2200b38", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37624060-f541-4b91-b600-bf60ab3223b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea7c34d-b863-4114-86ad-00daa006f480");

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbIdWithStrings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MouseOver",
                table: "dbIdWithStrings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "String1",
                table: "dbIdWithStrings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "String2",
                table: "dbIdWithStrings",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57436b03-a584-44c1-9d84-87b488199ac6", "03ef53a7-f788-49da-bcd6-a67239909733", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29e32a1b-cfb9-43dd-aacc-678d9f064270", "1587d1b4-b0b9-4d8f-bfd7-ba9cade8d9c8", "Super admin", "SUPER ADMIN" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class showcalendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cf6dbfd-7ae7-467d-bb3e-4e4e1f1028f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cef8a935-57da-4159-a1b6-1713401f1bf0");

            migrationBuilder.AddColumn<bool>(
                name: "ShowInEventCalendar",
                table: "DbProcessTemplate",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowInPersonalCalendar",
                table: "DbProcessTemplate",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "031a72d7-98b1-41eb-a7fb-ec47d8f43256", "e39f569f-5667-4da3-97c5-8f1fea6cb5b9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66474b27-7f53-416a-a235-12be8e396ea9", "12a6ed79-8d9c-4222-a2f1-a89b4172cf82", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "031a72d7-98b1-41eb-a7fb-ec47d8f43256");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66474b27-7f53-416a-a235-12be8e396ea9");

            migrationBuilder.DropColumn(
                name: "ShowInEventCalendar",
                table: "DbProcessTemplate");

            migrationBuilder.DropColumn(
                name: "ShowInPersonalCalendar",
                table: "DbProcessTemplate");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cef8a935-57da-4159-a1b6-1713401f1bf0", "cdcebbd7-9f7a-447d-88ca-5d678b403e75", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0cf6dbfd-7ae7-467d-bb3e-4e4e1f1028f2", "d0084690-4444-4726-9fb5-0b7670418b6d", "Super admin", "SUPER ADMIN" });
        }
    }
}

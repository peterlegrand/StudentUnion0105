using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class fresher2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "991b0a88-3abc-4fba-a45b-041e32a7bec1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cedd09d3-58dc-4db8-93d5-b683bdeb0edc");

            migrationBuilder.AlterColumn<int>(
                name: "IntValue",
                table: "dbSetting",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "GuidValue",
                table: "dbSetting",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeValue",
                table: "dbSetting",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "837a7cf5-3ff3-453f-a275-7c1e681e2319", "d5ab44ac-b1e4-4378-859c-895ec381c659", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e650115-c208-408a-9b29-cd962c457b98", "a3fd9efc-79e2-4992-a645-cfbc0d718b5c", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e650115-c208-408a-9b29-cd962c457b98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "837a7cf5-3ff3-453f-a275-7c1e681e2319");

            migrationBuilder.AlterColumn<int>(
                name: "IntValue",
                table: "dbSetting",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GuidValue",
                table: "dbSetting",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeValue",
                table: "dbSetting",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cedd09d3-58dc-4db8-93d5-b683bdeb0edc", "64beb618-3839-48d6-8997-c3430b9cd2ca", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "991b0a88-3abc-4fba-a45b-041e32a7bec1", "8e450aae-0066-48ba-a0f2-13ff4c28da65", "Super admin", "SUPER ADMIN" });
        }
    }
}

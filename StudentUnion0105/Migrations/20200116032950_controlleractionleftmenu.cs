using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class controlleractionleftmenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3be18dc3-f622-4532-b8da-6196cf7763f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da202433-0ade-494d-8844-89bc34130790");

            migrationBuilder.RenameColumn(
                name: "MainURL",
                table: "ZdbLeftMenu",
                newName: "MainController");

            migrationBuilder.RenameColumn(
                name: "AddURL",
                table: "ZdbLeftMenu",
                newName: "MainAction");

            migrationBuilder.RenameColumn(
                name: "MainURL",
                table: "dbLeftMenu",
                newName: "MainController");

            migrationBuilder.RenameColumn(
                name: "AddURL",
                table: "dbLeftMenu",
                newName: "MainAction");

            migrationBuilder.AddColumn<string>(
                name: "AddAction",
                table: "ZdbLeftMenu",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddController",
                table: "ZdbLeftMenu",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddAction",
                table: "dbLeftMenu",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddController",
                table: "dbLeftMenu",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b550720f-d84f-4481-a26e-a7979bde0df9", "82abdee3-7c2d-475f-b219-4934b66590b9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2309876-e259-4cac-b965-efd5e1b0e1f6", "8a2d8c44-0243-4249-8de0-ab5e832aea3c", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b550720f-d84f-4481-a26e-a7979bde0df9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2309876-e259-4cac-b965-efd5e1b0e1f6");

            migrationBuilder.DropColumn(
                name: "AddAction",
                table: "ZdbLeftMenu");

            migrationBuilder.DropColumn(
                name: "AddController",
                table: "ZdbLeftMenu");

            migrationBuilder.DropColumn(
                name: "AddAction",
                table: "dbLeftMenu");

            migrationBuilder.DropColumn(
                name: "AddController",
                table: "dbLeftMenu");

            migrationBuilder.RenameColumn(
                name: "MainController",
                table: "ZdbLeftMenu",
                newName: "MainURL");

            migrationBuilder.RenameColumn(
                name: "MainAction",
                table: "ZdbLeftMenu",
                newName: "AddURL");

            migrationBuilder.RenameColumn(
                name: "MainController",
                table: "dbLeftMenu",
                newName: "MainURL");

            migrationBuilder.RenameColumn(
                name: "MainAction",
                table: "dbLeftMenu",
                newName: "AddURL");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da202433-0ade-494d-8844-89bc34130790", "9f43823f-bb6d-4a8f-8c89-7f39daad0457", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3be18dc3-f622-4532-b8da-6196cf7763f7", "0cb9223a-38bd-44f8-b78b-a068fda1d332", "Super admin", "SUPER ADMIN" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class leftmenu9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4c7d52c-1e00-4008-8d70-6e95ed8f369f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1cf3aac-db08-4f61-a3cf-0e043e5aa909");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "dbLeftMenu",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ZdbLeftMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuName = table.Column<string>(nullable: true),
                    MenuShow = table.Column<bool>(nullable: false),
                    MenuAddShow = table.Column<bool>(nullable: false),
                    SearchShow = table.Column<bool>(nullable: false),
                    AdvancedSearchShow = table.Column<bool>(nullable: false),
                    HasMenu = table.Column<bool>(nullable: false),
                    HasAdd = table.Column<bool>(nullable: false),
                    HasSearch = table.Column<bool>(nullable: false),
                    HasAdvancedSearch = table.Column<bool>(nullable: false),
                    MainURL = table.Column<string>(nullable: true),
                    AddURL = table.Column<string>(nullable: true),
                    AddName = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbLeftMenu", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da202433-0ade-494d-8844-89bc34130790", "9f43823f-bb6d-4a8f-8c89-7f39daad0457", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3be18dc3-f622-4532-b8da-6196cf7763f7", "0cb9223a-38bd-44f8-b78b-a068fda1d332", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbLeftMenu");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3be18dc3-f622-4532-b8da-6196cf7763f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da202433-0ade-494d-8844-89bc34130790");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "dbLeftMenu");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4c7d52c-1e00-4008-8d70-6e95ed8f369f", "a95637ca-5a8f-40cf-b4e8-51598597cb0f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1cf3aac-db08-4f61-a3cf-0e043e5aa909", "ff52ace4-e17e-4473-bfde-7fccaeb486c8", "Super admin", "SUPER ADMIN" });
        }
    }
}

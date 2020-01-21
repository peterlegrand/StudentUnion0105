using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class leftmenumain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0af5bd17-ea4b-4b4d-9c3f-c67fbe51861e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb540e35-7356-4095-a066-007efb069708");

            migrationBuilder.CreateTable(
                name: "ZdbFrontCalendarEventCalendar",
                columns: table => new
                {
                    ProcessFieldId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessId = table.Column<int>(nullable: false),
                    StepId = table.Column<int>(nullable: false),
                    DateTimeValue = table.Column<DateTime>(nullable: false),
                    IntValue = table.Column<int>(nullable: false),
                    StringValue = table.Column<string>(nullable: true),
                    ProcessTemplateFieldId = table.Column<int>(nullable: false),
                    ProcessTemplateFieldTypeId = table.Column<int>(nullable: false),
                    MainDate = table.Column<DateTime>(nullable: false),
                    ProcessTemplateStepTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontCalendarEventCalendar", x => x.ProcessFieldId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbPreferenceLeftMenuGet",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MainController = table.Column<string>(nullable: true),
                    MainAction = table.Column<string>(nullable: true),
                    AddController = table.Column<string>(nullable: true),
                    AddAction = table.Column<string>(nullable: true),
                    HasMenu = table.Column<bool>(nullable: false),
                    HasAdd = table.Column<bool>(nullable: false),
                    HasSearch = table.Column<bool>(nullable: false),
                    HasAdvancedSearch = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MainName = table.Column<string>(nullable: true),
                    MainMouseOver = table.Column<string>(nullable: true),
                    AddName = table.Column<string>(nullable: true),
                    AddMouseOver = table.Column<string>(nullable: true),
                    MenuShow = table.Column<bool>(nullable: false),
                    MenuAddShow = table.Column<bool>(nullable: false),
                    SearchShow = table.Column<bool>(nullable: false),
                    AdvancedSearchShow = table.Column<bool>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MenuURL = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbPreferenceLeftMenuGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbPreferenceLeftMenuGetAvailableMenus",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MainController = table.Column<string>(nullable: true),
                    MainAction = table.Column<string>(nullable: true),
                    AddController = table.Column<string>(nullable: true),
                    AddAction = table.Column<string>(nullable: true),
                    HasMenu = table.Column<bool>(nullable: false),
                    HasAdd = table.Column<bool>(nullable: false),
                    HasSearch = table.Column<bool>(nullable: false),
                    HasAdvancedSearch = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MainName = table.Column<string>(nullable: true),
                    MainMouseOver = table.Column<string>(nullable: true),
                    AddName = table.Column<string>(nullable: true),
                    AddMouseOver = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbPreferenceLeftMenuGetAvailableMenus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b02ef825-0680-4a37-8492-b7bc8567ec28", "7b743c64-9810-4e26-913e-c32c2572f2ef", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71d0acc8-cd5e-4264-9d07-3cb757d075d8", "418b8002-7dc6-497b-9805-43c585d939a3", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbFrontCalendarEventCalendar");

            migrationBuilder.DropTable(
                name: "ZdbPreferenceLeftMenuGet");

            migrationBuilder.DropTable(
                name: "ZdbPreferenceLeftMenuGetAvailableMenus");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71d0acc8-cd5e-4264-9d07-3cb757d075d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b02ef825-0680-4a37-8492-b7bc8567ec28");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0af5bd17-ea4b-4b4d-9c3f-c67fbe51861e", "21e5a422-0e5c-4f23-8997-6c8b2ccdcabb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb540e35-7356-4095-a066-007efb069708", "252a3a3a-634e-4b89-8b28-7e9f99cd3768", "Super admin", "SUPER ADMIN" });
        }
    }
}

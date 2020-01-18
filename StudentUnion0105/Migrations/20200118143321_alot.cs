using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class alot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "133f2c47-de8d-4926-a9dc-89dd523e1648");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a977936-2207-4aa5-ade3-200054bbb052");

            migrationBuilder.CreateTable(
                name: "ZdbFrontOrganizationDashboardGetContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ContentTypeName = table.Column<string>(nullable: true),
                    ContentStatusName = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontOrganizationDashboardGetContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontOrganizationDashboardGetOrganization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationName = table.Column<string>(nullable: true),
                    StatusName = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontOrganizationDashboardGetOrganization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontOrganizationDashboardGetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontOrganizationDashboardGetUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cef8a935-57da-4159-a1b6-1713401f1bf0", "cdcebbd7-9f7a-447d-88ca-5d678b403e75", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0cf6dbfd-7ae7-467d-bb3e-4e4e1f1028f2", "d0084690-4444-4726-9fb5-0b7670418b6d", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbFrontOrganizationDashboardGetContent");

            migrationBuilder.DropTable(
                name: "ZdbFrontOrganizationDashboardGetOrganization");

            migrationBuilder.DropTable(
                name: "ZdbFrontOrganizationDashboardGetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cf6dbfd-7ae7-467d-bb3e-4e4e1f1028f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cef8a935-57da-4159-a1b6-1713401f1bf0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a977936-2207-4aa5-ade3-200054bbb052", "8acce520-897a-406d-9ffc-b8ae28587a1c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "133f2c47-de8d-4926-a9dc-89dd523e1648", "0811253c-8591-4251-bd0c-6ade5e79e23c", "Super admin", "SUPER ADMIN" });
        }
    }
}

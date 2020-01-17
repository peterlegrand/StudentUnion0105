using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class mycontent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b31d2cf-c2be-4b7b-8493-c5cce47c4bc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e2b8167-abb0-4449-8a33-c19ef42bc0ca");

            migrationBuilder.CreateTable(
                name: "ZdbFrontPageMyContentGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    StatusName = table.Column<bool>(nullable: false),
                    TypeName = table.Column<bool>(nullable: false),
                    OrganizationName = table.Column<bool>(nullable: false),
                    ProjectName = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontPageMyContentGet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12f4bec1-93ef-4e7e-99a8-08f55599e532", "2d489f31-138f-4413-a101-f852a12b15ce", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f4f8b75-4bec-4392-b2fa-0752d5144458", "322c084a-287a-45db-9357-3a6b70bb124c", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbFrontPageMyContentGet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12f4bec1-93ef-4e7e-99a8-08f55599e532");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f4f8b75-4bec-4392-b2fa-0752d5144458");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e2b8167-abb0-4449-8a33-c19ef42bc0ca", "ee3e0896-1ed9-4f88-980f-71f527c4077c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b31d2cf-c2be-4b7b-8493-c5cce47c4bc9", "01b15cb0-5068-45b2-a325-9242c01848cb", "Super admin", "SUPER ADMIN" });
        }
    }
}

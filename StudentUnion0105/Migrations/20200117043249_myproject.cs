using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class myproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8da0375a-b890-4baa-8b1d-246cd4a4760c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1346921-e584-4c5b-9f30-cac3111fdf44");

            migrationBuilder.CreateTable(
                name: "ZdbFrontProjectMyProjectGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    RelatioName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontProjectMyProjectGet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "772800cc-a32e-4bec-9753-8b13604d59fe", "ee6e9136-9842-440c-abf5-53a875aa35b1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d129c8eb-b71f-4856-a5a7-3d63f39cb2d6", "aa402422-a861-4d6d-8fc7-f90c003b8974", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbFrontProjectMyProjectGet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "772800cc-a32e-4bec-9753-8b13604d59fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d129c8eb-b71f-4856-a5a7-3d63f39cb2d6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8da0375a-b890-4baa-8b1d-246cd4a4760c", "047b245f-493e-4d4c-a934-d569223eb206", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1346921-e584-4c5b-9f30-cac3111fdf44", "c9322731-ede6-4a8e-b621-7b86333d7f05", "Super admin", "SUPER ADMIN" });
        }
    }
}

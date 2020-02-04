using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class editcontent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "387ba9cd-5cf6-47da-9e54-161bcbd43399");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a837f8b7-1674-499b-bf5d-f84fba8afed6");

            migrationBuilder.CreateTable(
                name: "ZdbContentEditGetClassificationValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbContentEditGetClassificationValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbContentEditGetContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeId = table.Column<int>(nullable: false),
                    ContentStatusId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SecurityLevel = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbContentEditGetContent", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce2a49d4-d310-4c24-85bf-e229ad659f63", "b768a33e-0f42-4b90-90fa-d3b491d811b0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0268c39e-0273-4ace-bf44-1c36f4ef2810", "770ca4e8-4132-4358-8622-69ad12e4939c", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbContentEditGetClassificationValues");

            migrationBuilder.DropTable(
                name: "ZdbContentEditGetContent");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0268c39e-0273-4ace-bf44-1c36f4ef2810");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce2a49d4-d310-4c24-85bf-e229ad659f63");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "387ba9cd-5cf6-47da-9e54-161bcbd43399", "219cdfc0-f581-43a9-8f7f-739b6c28838e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a837f8b7-1674-499b-bf5d-f84fba8afed6", "52df97e6-117a-4fe5-aa81-ad803aff5193", "Super admin", "SUPER ADMIN" });
        }
    }
}

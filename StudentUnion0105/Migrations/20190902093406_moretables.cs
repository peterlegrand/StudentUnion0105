using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class moretables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5632127-5b24-4527-9b96-8b452c1b5564");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da9bd0bc-26fa-4794-9db6-42ec2f3be0ce");

            migrationBuilder.CreateTable(
                name: "dbGetOrganizationStructure",
                columns: table => new
                {
                    Id1 = table.Column<int>(nullable: false),
                    Id2 = table.Column<int>(nullable: false),
                    Id3 = table.Column<int>(nullable: false),
                    Name1 = table.Column<string>(nullable: true),
                    Name2 = table.Column<string>(nullable: true),
                    Name3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbGetOrganizationStructure", x => new { x.Id1, x.Id2, x.Id3 });
                });

            migrationBuilder.CreateTable(
                name: "dbPageStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPageStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbPageType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbPage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageStatusId = table.Column<int>(nullable: false),
                    PageTypeId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbPage_dbPageStatus_PageStatusId",
                        column: x => x.PageStatusId,
                        principalTable: "dbPageStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbPage_dbPageType_PageTypeId",
                        column: x => x.PageTypeId,
                        principalTable: "dbPageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbPageTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPageTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbPageTypeLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbPageTypeLanguage_dbPageType_PageTypeId",
                        column: x => x.PageTypeId,
                        principalTable: "dbPageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbPageLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    PageTitle = table.Column<string>(nullable: true),
                    PageDescription = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPageLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbPageLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbPageLanguage_dbPage_PageId",
                        column: x => x.PageId,
                        principalTable: "dbPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "324d6982-830b-4757-a163-4987bc3af36b", "69ef5c83-b0ed-4fad-9ef2-eb886037f1fd", "Admin", "ADMIN" });


            migrationBuilder.CreateIndex(
                name: "IX_dbPage_PageStatusId",
                table: "dbPage",
                column: "PageStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPage_PageTypeId",
                table: "dbPage",
                column: "PageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageLanguage_LanguageId",
                table: "dbPageLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageLanguage_PageId",
                table: "dbPageLanguage",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageTypeLanguage_LanguageId",
                table: "dbPageTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageTypeLanguage_PageTypeId",
                table: "dbPageTypeLanguage",
                column: "PageTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbGetOrganizationStructure");

            migrationBuilder.DropTable(
                name: "dbPageLanguage");

            migrationBuilder.DropTable(
                name: "dbPageTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbPage");

            migrationBuilder.DropTable(
                name: "dbPageStatus");

            migrationBuilder.DropTable(
                name: "dbPageType");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "324d6982-830b-4757-a163-4987bc3af36b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49e84172-20c0-49e1-b1d8-e654fb31fec8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5632127-5b24-4527-9b96-8b452c1b5564", "32117d85-fc15-45f5-b399-0cdce7c051ad", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da9bd0bc-26fa-4794-9db6-42ec2f3be0ce", "3f3144ef-f448-4dc4-ab9e-aa8bb8f569b7", "Admin", "ADMIN" });
        }
    }
}

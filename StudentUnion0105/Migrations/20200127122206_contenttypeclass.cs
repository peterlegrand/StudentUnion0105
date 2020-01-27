using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class contenttypeclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbContentTypeClassificationStatusLangauge");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "573c4e50-5b3d-4edb-a865-b93e436289b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8adf2907-a402-4292-8800-82e2f51eded7");

            migrationBuilder.CreateTable(
                name: "dbContentTypeClassificationStatusLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeClassificationStatusId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbContentTypeClassificationStatusLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbContentTypeClassificationStatusLanguage_dbContentTypeClassificationStatus_ContentTypeClassificationStatusId",
                        column: x => x.ContentTypeClassificationStatusId,
                        principalTable: "dbContentTypeClassificationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbContentTypeClassificationStatusLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZdbContentTypeClassificationIndexGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeId = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    StatusName = table.Column<string>(nullable: true),
                    ClassificationName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbContentTypeClassificationIndexGet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23534f0d-73a6-4887-a4a3-df86f5bda4ec", "f5a19f9b-d30e-45ed-988a-36fae1691b67", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3f44b8a-f98d-4bf2-ac46-30748d1f9889", "e7ec6620-050f-4a7d-b52b-a6261763e967", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeClassificationStatusLanguage_ContentTypeClassificationStatusId",
                table: "dbContentTypeClassificationStatusLanguage",
                column: "ContentTypeClassificationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeClassificationStatusLanguage_LanguageId",
                table: "dbContentTypeClassificationStatusLanguage",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbContentTypeClassificationStatusLanguage");

            migrationBuilder.DropTable(
                name: "ZdbContentTypeClassificationIndexGet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23534f0d-73a6-4887-a4a3-df86f5bda4ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3f44b8a-f98d-4bf2-ac46-30748d1f9889");

            migrationBuilder.CreateTable(
                name: "dbContentTypeClassificationStatusLangauge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeClassificationStatusId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifierId = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbContentTypeClassificationStatusLangauge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbContentTypeClassificationStatusLangauge_dbContentTypeClassificationStatus_ContentTypeClassificationStatusId",
                        column: x => x.ContentTypeClassificationStatusId,
                        principalTable: "dbContentTypeClassificationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbContentTypeClassificationStatusLangauge_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "573c4e50-5b3d-4edb-a865-b93e436289b5", "2ad5f4a2-ba6d-4d38-ae61-08dda30df469", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8adf2907-a402-4292-8800-82e2f51eded7", "5ac01607-abbb-4c1d-9ab5-b10f703541c5", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeClassificationStatusLangauge_ContentTypeClassificationStatusId",
                table: "dbContentTypeClassificationStatusLangauge",
                column: "ContentTypeClassificationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeClassificationStatusLangauge_LanguageId",
                table: "dbContentTypeClassificationStatusLangauge",
                column: "LanguageId");
        }
    }
}

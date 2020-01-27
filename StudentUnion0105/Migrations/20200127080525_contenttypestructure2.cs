using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class contenttypestructure2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuContentTypeClassificationModel_DbClassification_ClassificationId",
                table: "SuContentTypeClassificationModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SuContentTypeClassificationModel_DbContentType_ContentTypeId",
                table: "SuContentTypeClassificationModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuContentTypeClassificationModel",
                table: "SuContentTypeClassificationModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aebeecf6-805a-431e-b97b-ffcad4bdd48c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4d7164d-b7c5-4312-a5bb-554162cca94b");

            migrationBuilder.RenameTable(
                name: "SuContentTypeClassificationModel",
                newName: "ZdbSuContentTypeClassification");

            migrationBuilder.RenameIndex(
                name: "IX_SuContentTypeClassificationModel_ContentTypeId",
                table: "ZdbSuContentTypeClassification",
                newName: "IX_ZdbSuContentTypeClassification_ContentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SuContentTypeClassificationModel_ClassificationId",
                table: "ZdbSuContentTypeClassification",
                newName: "IX_ZdbSuContentTypeClassification_ClassificationId");

            migrationBuilder.AddColumn<int>(
                name: "SuContentTypeClassificationStatusModelId",
                table: "ZdbSuContentTypeClassification",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZdbSuContentTypeClassification",
                table: "ZdbSuContentTypeClassification",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ZdbSuContentTypeClassificationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbSuContentTypeClassificationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbSuContentTypeClassificationStatusLangauge",
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
                    table.PrimaryKey("PK_ZdbSuContentTypeClassificationStatusLangauge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZdbSuContentTypeClassificationStatusLangauge_ZdbSuContentTypeClassificationStatus_ContentTypeClassificationStatusId",
                        column: x => x.ContentTypeClassificationStatusId,
                        principalTable: "ZdbSuContentTypeClassificationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZdbSuContentTypeClassificationStatusLangauge_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0251a44-2b7b-4ff9-b71a-822b7091bfcb", "f25d7e28-bdde-4861-bfd1-c16069765e54", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "deb52a71-9fe6-4da3-a5dc-eb0a6c91ca8b", "94fed212-2c98-42ab-9316-ac7f32b47f9a", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_ZdbSuContentTypeClassification_SuContentTypeClassificationStatusModelId",
                table: "ZdbSuContentTypeClassification",
                column: "SuContentTypeClassificationStatusModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdbSuContentTypeClassificationStatusLangauge_ContentTypeClassificationStatusId",
                table: "ZdbSuContentTypeClassificationStatusLangauge",
                column: "ContentTypeClassificationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdbSuContentTypeClassificationStatusLangauge_LanguageId",
                table: "ZdbSuContentTypeClassificationStatusLangauge",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ZdbSuContentTypeClassification_DbClassification_ClassificationId",
                table: "ZdbSuContentTypeClassification",
                column: "ClassificationId",
                principalTable: "DbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZdbSuContentTypeClassification_DbContentType_ContentTypeId",
                table: "ZdbSuContentTypeClassification",
                column: "ContentTypeId",
                principalTable: "DbContentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZdbSuContentTypeClassification_ZdbSuContentTypeClassificationStatus_SuContentTypeClassificationStatusModelId",
                table: "ZdbSuContentTypeClassification",
                column: "SuContentTypeClassificationStatusModelId",
                principalTable: "ZdbSuContentTypeClassificationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZdbSuContentTypeClassification_DbClassification_ClassificationId",
                table: "ZdbSuContentTypeClassification");

            migrationBuilder.DropForeignKey(
                name: "FK_ZdbSuContentTypeClassification_DbContentType_ContentTypeId",
                table: "ZdbSuContentTypeClassification");

            migrationBuilder.DropForeignKey(
                name: "FK_ZdbSuContentTypeClassification_ZdbSuContentTypeClassificationStatus_SuContentTypeClassificationStatusModelId",
                table: "ZdbSuContentTypeClassification");

            migrationBuilder.DropTable(
                name: "ZdbSuContentTypeClassificationStatusLangauge");

            migrationBuilder.DropTable(
                name: "ZdbSuContentTypeClassificationStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZdbSuContentTypeClassification",
                table: "ZdbSuContentTypeClassification");

            migrationBuilder.DropIndex(
                name: "IX_ZdbSuContentTypeClassification_SuContentTypeClassificationStatusModelId",
                table: "ZdbSuContentTypeClassification");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0251a44-2b7b-4ff9-b71a-822b7091bfcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "deb52a71-9fe6-4da3-a5dc-eb0a6c91ca8b");

            migrationBuilder.DropColumn(
                name: "SuContentTypeClassificationStatusModelId",
                table: "ZdbSuContentTypeClassification");

            migrationBuilder.RenameTable(
                name: "ZdbSuContentTypeClassification",
                newName: "SuContentTypeClassificationModel");

            migrationBuilder.RenameIndex(
                name: "IX_ZdbSuContentTypeClassification_ContentTypeId",
                table: "SuContentTypeClassificationModel",
                newName: "IX_SuContentTypeClassificationModel_ContentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ZdbSuContentTypeClassification_ClassificationId",
                table: "SuContentTypeClassificationModel",
                newName: "IX_SuContentTypeClassificationModel_ClassificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuContentTypeClassificationModel",
                table: "SuContentTypeClassificationModel",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aebeecf6-805a-431e-b97b-ffcad4bdd48c", "1f8fcf7c-3a40-4600-827a-3ec1a67c6839", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4d7164d-b7c5-4312-a5bb-554162cca94b", "2d9d8b51-af64-4948-bd04-264d8704c32b", "Super admin", "SUPER ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_SuContentTypeClassificationModel_DbClassification_ClassificationId",
                table: "SuContentTypeClassificationModel",
                column: "ClassificationId",
                principalTable: "DbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SuContentTypeClassificationModel_DbContentType_ContentTypeId",
                table: "SuContentTypeClassificationModel",
                column: "ContentTypeId",
                principalTable: "DbContentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

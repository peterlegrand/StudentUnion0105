using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class contenttypestructure3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_ZdbSuContentTypeClassificationStatusLangauge_ZdbSuContentTypeClassificationStatus_ContentTypeClassificationStatusId",
                table: "ZdbSuContentTypeClassificationStatusLangauge");

            migrationBuilder.DropForeignKey(
                name: "FK_ZdbSuContentTypeClassificationStatusLangauge_DbLanguage_LanguageId",
                table: "ZdbSuContentTypeClassificationStatusLangauge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZdbSuContentTypeClassificationStatusLangauge",
                table: "ZdbSuContentTypeClassificationStatusLangauge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZdbSuContentTypeClassificationStatus",
                table: "ZdbSuContentTypeClassificationStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZdbSuContentTypeClassification",
                table: "ZdbSuContentTypeClassification");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0251a44-2b7b-4ff9-b71a-822b7091bfcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "deb52a71-9fe6-4da3-a5dc-eb0a6c91ca8b");

            migrationBuilder.RenameTable(
                name: "ZdbSuContentTypeClassificationStatusLangauge",
                newName: "dbSuContentTypeClassificationStatusLangauge");

            migrationBuilder.RenameTable(
                name: "ZdbSuContentTypeClassificationStatus",
                newName: "dbSuContentTypeClassificationStatus");

            migrationBuilder.RenameTable(
                name: "ZdbSuContentTypeClassification",
                newName: "dbSuContentTypeClassification");

            migrationBuilder.RenameIndex(
                name: "IX_ZdbSuContentTypeClassificationStatusLangauge_LanguageId",
                table: "dbSuContentTypeClassificationStatusLangauge",
                newName: "IX_dbSuContentTypeClassificationStatusLangauge_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_ZdbSuContentTypeClassificationStatusLangauge_ContentTypeClassificationStatusId",
                table: "dbSuContentTypeClassificationStatusLangauge",
                newName: "IX_dbSuContentTypeClassificationStatusLangauge_ContentTypeClassificationStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ZdbSuContentTypeClassification_SuContentTypeClassificationStatusModelId",
                table: "dbSuContentTypeClassification",
                newName: "IX_dbSuContentTypeClassification_SuContentTypeClassificationStatusModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ZdbSuContentTypeClassification_ContentTypeId",
                table: "dbSuContentTypeClassification",
                newName: "IX_dbSuContentTypeClassification_ContentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ZdbSuContentTypeClassification_ClassificationId",
                table: "dbSuContentTypeClassification",
                newName: "IX_dbSuContentTypeClassification_ClassificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbSuContentTypeClassificationStatusLangauge",
                table: "dbSuContentTypeClassificationStatusLangauge",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbSuContentTypeClassificationStatus",
                table: "dbSuContentTypeClassificationStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbSuContentTypeClassification",
                table: "dbSuContentTypeClassification",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c848b54-878a-4b69-a4a2-fe7f0e23405a", "ccb21349-7b72-4a5c-b22a-244cca95fa2b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b91c780b-a855-45d7-9a0b-023ea80928a8", "1906c046-36b9-4b7f-a227-18a86c83aab1", "Super admin", "SUPER ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_dbSuContentTypeClassification_DbClassification_ClassificationId",
                table: "dbSuContentTypeClassification",
                column: "ClassificationId",
                principalTable: "DbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbSuContentTypeClassification_DbContentType_ContentTypeId",
                table: "dbSuContentTypeClassification",
                column: "ContentTypeId",
                principalTable: "DbContentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbSuContentTypeClassification_dbSuContentTypeClassificationStatus_SuContentTypeClassificationStatusModelId",
                table: "dbSuContentTypeClassification",
                column: "SuContentTypeClassificationStatusModelId",
                principalTable: "dbSuContentTypeClassificationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbSuContentTypeClassificationStatusLangauge_dbSuContentTypeClassificationStatus_ContentTypeClassificationStatusId",
                table: "dbSuContentTypeClassificationStatusLangauge",
                column: "ContentTypeClassificationStatusId",
                principalTable: "dbSuContentTypeClassificationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbSuContentTypeClassificationStatusLangauge_DbLanguage_LanguageId",
                table: "dbSuContentTypeClassificationStatusLangauge",
                column: "LanguageId",
                principalTable: "DbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbSuContentTypeClassification_DbClassification_ClassificationId",
                table: "dbSuContentTypeClassification");

            migrationBuilder.DropForeignKey(
                name: "FK_dbSuContentTypeClassification_DbContentType_ContentTypeId",
                table: "dbSuContentTypeClassification");

            migrationBuilder.DropForeignKey(
                name: "FK_dbSuContentTypeClassification_dbSuContentTypeClassificationStatus_SuContentTypeClassificationStatusModelId",
                table: "dbSuContentTypeClassification");

            migrationBuilder.DropForeignKey(
                name: "FK_dbSuContentTypeClassificationStatusLangauge_dbSuContentTypeClassificationStatus_ContentTypeClassificationStatusId",
                table: "dbSuContentTypeClassificationStatusLangauge");

            migrationBuilder.DropForeignKey(
                name: "FK_dbSuContentTypeClassificationStatusLangauge_DbLanguage_LanguageId",
                table: "dbSuContentTypeClassificationStatusLangauge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbSuContentTypeClassificationStatusLangauge",
                table: "dbSuContentTypeClassificationStatusLangauge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbSuContentTypeClassificationStatus",
                table: "dbSuContentTypeClassificationStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbSuContentTypeClassification",
                table: "dbSuContentTypeClassification");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c848b54-878a-4b69-a4a2-fe7f0e23405a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b91c780b-a855-45d7-9a0b-023ea80928a8");

            migrationBuilder.RenameTable(
                name: "dbSuContentTypeClassificationStatusLangauge",
                newName: "ZdbSuContentTypeClassificationStatusLangauge");

            migrationBuilder.RenameTable(
                name: "dbSuContentTypeClassificationStatus",
                newName: "ZdbSuContentTypeClassificationStatus");

            migrationBuilder.RenameTable(
                name: "dbSuContentTypeClassification",
                newName: "ZdbSuContentTypeClassification");

            migrationBuilder.RenameIndex(
                name: "IX_dbSuContentTypeClassificationStatusLangauge_LanguageId",
                table: "ZdbSuContentTypeClassificationStatusLangauge",
                newName: "IX_ZdbSuContentTypeClassificationStatusLangauge_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_dbSuContentTypeClassificationStatusLangauge_ContentTypeClassificationStatusId",
                table: "ZdbSuContentTypeClassificationStatusLangauge",
                newName: "IX_ZdbSuContentTypeClassificationStatusLangauge_ContentTypeClassificationStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_dbSuContentTypeClassification_SuContentTypeClassificationStatusModelId",
                table: "ZdbSuContentTypeClassification",
                newName: "IX_ZdbSuContentTypeClassification_SuContentTypeClassificationStatusModelId");

            migrationBuilder.RenameIndex(
                name: "IX_dbSuContentTypeClassification_ContentTypeId",
                table: "ZdbSuContentTypeClassification",
                newName: "IX_ZdbSuContentTypeClassification_ContentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_dbSuContentTypeClassification_ClassificationId",
                table: "ZdbSuContentTypeClassification",
                newName: "IX_ZdbSuContentTypeClassification_ClassificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZdbSuContentTypeClassificationStatusLangauge",
                table: "ZdbSuContentTypeClassificationStatusLangauge",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZdbSuContentTypeClassificationStatus",
                table: "ZdbSuContentTypeClassificationStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZdbSuContentTypeClassification",
                table: "ZdbSuContentTypeClassification",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0251a44-2b7b-4ff9-b71a-822b7091bfcb", "f25d7e28-bdde-4861-bfd1-c16069765e54", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "deb52a71-9fe6-4da3-a5dc-eb0a6c91ca8b", "94fed212-2c98-42ab-9316-ac7f32b47f9a", "Super admin", "SUPER ADMIN" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ZdbSuContentTypeClassificationStatusLangauge_ZdbSuContentTypeClassificationStatus_ContentTypeClassificationStatusId",
                table: "ZdbSuContentTypeClassificationStatusLangauge",
                column: "ContentTypeClassificationStatusId",
                principalTable: "ZdbSuContentTypeClassificationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZdbSuContentTypeClassificationStatusLangauge_DbLanguage_LanguageId",
                table: "ZdbSuContentTypeClassificationStatusLangauge",
                column: "LanguageId",
                principalTable: "DbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

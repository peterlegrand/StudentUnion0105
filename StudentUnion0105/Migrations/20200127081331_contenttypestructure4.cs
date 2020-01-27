using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class contenttypestructure4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "dbContentTypeClassificationStatusLangauge");

            migrationBuilder.RenameTable(
                name: "dbSuContentTypeClassificationStatus",
                newName: "dbContentTypeClassificationStatus");

            migrationBuilder.RenameTable(
                name: "dbSuContentTypeClassification",
                newName: "dbContentTypeClassification");

            migrationBuilder.RenameIndex(
                name: "IX_dbSuContentTypeClassificationStatusLangauge_LanguageId",
                table: "dbContentTypeClassificationStatusLangauge",
                newName: "IX_dbContentTypeClassificationStatusLangauge_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_dbSuContentTypeClassificationStatusLangauge_ContentTypeClassificationStatusId",
                table: "dbContentTypeClassificationStatusLangauge",
                newName: "IX_dbContentTypeClassificationStatusLangauge_ContentTypeClassificationStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_dbSuContentTypeClassification_SuContentTypeClassificationStatusModelId",
                table: "dbContentTypeClassification",
                newName: "IX_dbContentTypeClassification_SuContentTypeClassificationStatusModelId");

            migrationBuilder.RenameIndex(
                name: "IX_dbSuContentTypeClassification_ContentTypeId",
                table: "dbContentTypeClassification",
                newName: "IX_dbContentTypeClassification_ContentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_dbSuContentTypeClassification_ClassificationId",
                table: "dbContentTypeClassification",
                newName: "IX_dbContentTypeClassification_ClassificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbContentTypeClassificationStatusLangauge",
                table: "dbContentTypeClassificationStatusLangauge",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbContentTypeClassificationStatus",
                table: "dbContentTypeClassificationStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbContentTypeClassification",
                table: "dbContentTypeClassification",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee4979ee-c31c-47c2-b88a-88718046f5c8", "0d4d2e42-0164-482b-b664-9e3acf5abec1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0dbecb36-826f-4ff5-b629-8d0fa0e76f4e", "7811bbeb-7614-401b-9b10-b60ec8f1a3f8", "Super admin", "SUPER ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_dbContentTypeClassification_DbClassification_ClassificationId",
                table: "dbContentTypeClassification",
                column: "ClassificationId",
                principalTable: "DbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbContentTypeClassification_DbContentType_ContentTypeId",
                table: "dbContentTypeClassification",
                column: "ContentTypeId",
                principalTable: "DbContentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbContentTypeClassification_dbContentTypeClassificationStatus_SuContentTypeClassificationStatusModelId",
                table: "dbContentTypeClassification",
                column: "SuContentTypeClassificationStatusModelId",
                principalTable: "dbContentTypeClassificationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbContentTypeClassificationStatusLangauge_dbContentTypeClassificationStatus_ContentTypeClassificationStatusId",
                table: "dbContentTypeClassificationStatusLangauge",
                column: "ContentTypeClassificationStatusId",
                principalTable: "dbContentTypeClassificationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbContentTypeClassificationStatusLangauge_DbLanguage_LanguageId",
                table: "dbContentTypeClassificationStatusLangauge",
                column: "LanguageId",
                principalTable: "DbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbContentTypeClassification_DbClassification_ClassificationId",
                table: "dbContentTypeClassification");

            migrationBuilder.DropForeignKey(
                name: "FK_dbContentTypeClassification_DbContentType_ContentTypeId",
                table: "dbContentTypeClassification");

            migrationBuilder.DropForeignKey(
                name: "FK_dbContentTypeClassification_dbContentTypeClassificationStatus_SuContentTypeClassificationStatusModelId",
                table: "dbContentTypeClassification");

            migrationBuilder.DropForeignKey(
                name: "FK_dbContentTypeClassificationStatusLangauge_dbContentTypeClassificationStatus_ContentTypeClassificationStatusId",
                table: "dbContentTypeClassificationStatusLangauge");

            migrationBuilder.DropForeignKey(
                name: "FK_dbContentTypeClassificationStatusLangauge_DbLanguage_LanguageId",
                table: "dbContentTypeClassificationStatusLangauge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbContentTypeClassificationStatusLangauge",
                table: "dbContentTypeClassificationStatusLangauge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbContentTypeClassificationStatus",
                table: "dbContentTypeClassificationStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbContentTypeClassification",
                table: "dbContentTypeClassification");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dbecb36-826f-4ff5-b629-8d0fa0e76f4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee4979ee-c31c-47c2-b88a-88718046f5c8");

            migrationBuilder.RenameTable(
                name: "dbContentTypeClassificationStatusLangauge",
                newName: "dbSuContentTypeClassificationStatusLangauge");

            migrationBuilder.RenameTable(
                name: "dbContentTypeClassificationStatus",
                newName: "dbSuContentTypeClassificationStatus");

            migrationBuilder.RenameTable(
                name: "dbContentTypeClassification",
                newName: "dbSuContentTypeClassification");

            migrationBuilder.RenameIndex(
                name: "IX_dbContentTypeClassificationStatusLangauge_LanguageId",
                table: "dbSuContentTypeClassificationStatusLangauge",
                newName: "IX_dbSuContentTypeClassificationStatusLangauge_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_dbContentTypeClassificationStatusLangauge_ContentTypeClassificationStatusId",
                table: "dbSuContentTypeClassificationStatusLangauge",
                newName: "IX_dbSuContentTypeClassificationStatusLangauge_ContentTypeClassificationStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_dbContentTypeClassification_SuContentTypeClassificationStatusModelId",
                table: "dbSuContentTypeClassification",
                newName: "IX_dbSuContentTypeClassification_SuContentTypeClassificationStatusModelId");

            migrationBuilder.RenameIndex(
                name: "IX_dbContentTypeClassification_ContentTypeId",
                table: "dbSuContentTypeClassification",
                newName: "IX_dbSuContentTypeClassification_ContentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_dbContentTypeClassification_ClassificationId",
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
    }
}

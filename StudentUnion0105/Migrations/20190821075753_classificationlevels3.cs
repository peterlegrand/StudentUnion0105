using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class classificationlevels3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuClassificationLevelLanguageModel_dbClassificationLevel_ClassificationLevelId",
                table: "SuClassificationLevelLanguageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SuClassificationLevelLanguageModel_dbLanguage_LanguageId",
                table: "SuClassificationLevelLanguageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuClassificationLevelLanguageModel",
                table: "SuClassificationLevelLanguageModel");

            migrationBuilder.RenameTable(
                name: "SuClassificationLevelLanguageModel",
                newName: "dbClassificationLevelLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_SuClassificationLevelLanguageModel_LanguageId",
                table: "dbClassificationLevelLanguage",
                newName: "IX_dbClassificationLevelLanguage_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_SuClassificationLevelLanguageModel_ClassificationLevelId",
                table: "dbClassificationLevelLanguage",
                newName: "IX_dbClassificationLevelLanguage_ClassificationLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbClassificationLevelLanguage",
                table: "dbClassificationLevelLanguage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbClassificationLevel_ClassificationLevelId",
                table: "dbClassificationLevelLanguage",
                column: "ClassificationLevelId",
                principalTable: "dbClassificationLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbLanguage_LanguageId",
                table: "dbClassificationLevelLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbClassificationLevel_ClassificationLevelId",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbLanguage_LanguageId",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbClassificationLevelLanguage",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.RenameTable(
                name: "dbClassificationLevelLanguage",
                newName: "SuClassificationLevelLanguageModel");

            migrationBuilder.RenameIndex(
                name: "IX_dbClassificationLevelLanguage_LanguageId",
                table: "SuClassificationLevelLanguageModel",
                newName: "IX_SuClassificationLevelLanguageModel_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_dbClassificationLevelLanguage_ClassificationLevelId",
                table: "SuClassificationLevelLanguageModel",
                newName: "IX_SuClassificationLevelLanguageModel_ClassificationLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuClassificationLevelLanguageModel",
                table: "SuClassificationLevelLanguageModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuClassificationLevelLanguageModel_dbClassificationLevel_ClassificationLevelId",
                table: "SuClassificationLevelLanguageModel",
                column: "ClassificationLevelId",
                principalTable: "dbClassificationLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SuClassificationLevelLanguageModel_dbLanguage_LanguageId",
                table: "SuClassificationLevelLanguageModel",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class classificationlevels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuClassificationLevelLanguageModel_SuClassificationLevelModel_ClassificationLevelId",
                table: "SuClassificationLevelLanguageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SuClassificationLevelModel_dbClassification_ClassificationId",
                table: "SuClassificationLevelModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuClassificationLevelModel",
                table: "SuClassificationLevelModel");

            migrationBuilder.RenameTable(
                name: "SuClassificationLevelModel",
                newName: "dbClassificationLevel");

            migrationBuilder.RenameIndex(
                name: "IX_SuClassificationLevelModel_ClassificationId",
                table: "dbClassificationLevel",
                newName: "IX_dbClassificationLevel_ClassificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbClassificationLevel",
                table: "dbClassificationLevel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLevel_dbClassification_ClassificationId",
                table: "dbClassificationLevel",
                column: "ClassificationId",
                principalTable: "dbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SuClassificationLevelLanguageModel_dbClassificationLevel_ClassificationLevelId",
                table: "SuClassificationLevelLanguageModel",
                column: "ClassificationLevelId",
                principalTable: "dbClassificationLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLevel_dbClassification_ClassificationId",
                table: "dbClassificationLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_SuClassificationLevelLanguageModel_dbClassificationLevel_ClassificationLevelId",
                table: "SuClassificationLevelLanguageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbClassificationLevel",
                table: "dbClassificationLevel");

            migrationBuilder.RenameTable(
                name: "dbClassificationLevel",
                newName: "SuClassificationLevelModel");

            migrationBuilder.RenameIndex(
                name: "IX_dbClassificationLevel_ClassificationId",
                table: "SuClassificationLevelModel",
                newName: "IX_SuClassificationLevelModel_ClassificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuClassificationLevelModel",
                table: "SuClassificationLevelModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuClassificationLevelLanguageModel_SuClassificationLevelModel_ClassificationLevelId",
                table: "SuClassificationLevelLanguageModel",
                column: "ClassificationLevelId",
                principalTable: "SuClassificationLevelModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SuClassificationLevelModel_dbClassification_ClassificationId",
                table: "SuClassificationLevelModel",
                column: "ClassificationId",
                principalTable: "dbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

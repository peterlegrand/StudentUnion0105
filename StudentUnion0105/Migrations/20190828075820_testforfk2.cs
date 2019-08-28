using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class testforfk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationValue_dbClassificationLevel_ClassificationLevelId",
                table: "dbClassificationValue");

            migrationBuilder.AddForeignKey(
                name: "FKClassificationValuestoLevel",
                table: "dbClassificationValue",
                column: "ClassificationLevelId",
                principalTable: "dbClassificationLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKClassificationValuestoLevel",
                table: "dbClassificationValue");

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationValue_dbClassificationLevel_ClassificationLevelId",
                table: "dbClassificationValue",
                column: "ClassificationLevelId",
                principalTable: "dbClassificationLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

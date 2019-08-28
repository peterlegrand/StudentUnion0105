using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class newcontrollerstructureandvaluesWithMore4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLevel_dbClassification_ClassificationId",
                table: "dbClassificationLevel");

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLevel_dbClassification_ClassificationId",
                table: "dbClassificationLevel",
                column: "ClassificationId",
                principalTable: "dbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLevel_dbClassification_ClassificationId",
                table: "dbClassificationLevel");

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLevel_dbClassification_ClassificationId",
                table: "dbClassificationLevel",
                column: "ClassificationId",
                principalTable: "dbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

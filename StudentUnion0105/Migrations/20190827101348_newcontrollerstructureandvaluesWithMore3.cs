using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class newcontrollerstructureandvaluesWithMore3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationValue_dbClassification_ClassificationId",
                table: "dbClassificationValue");

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationValue_dbClassification_ClassificationId",
                table: "dbClassificationValue",
                column: "ClassificationId",
                principalTable: "dbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationValue_dbClassification_ClassificationId",
                table: "dbClassificationValue");

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationValue_dbClassification_ClassificationId",
                table: "dbClassificationValue",
                column: "ClassificationId",
                principalTable: "dbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

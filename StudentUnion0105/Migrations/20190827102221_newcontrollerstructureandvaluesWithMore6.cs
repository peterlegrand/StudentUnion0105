using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class newcontrollerstructureandvaluesWithMore6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationValue_dbClassification_ClassificationId",
                table: "dbClassificationValue");

            migrationBuilder.DropIndex(
                name: "IX_dbClassificationValue_ClassificationId",
                table: "dbClassificationValue");

            migrationBuilder.DropColumn(
                name: "ClassificationId",
                table: "dbClassificationValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassificationId",
                table: "dbClassificationValue",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationValue_ClassificationId",
                table: "dbClassificationValue",
                column: "ClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationValue_dbClassification_ClassificationId",
                table: "dbClassificationValue",
                column: "ClassificationId",
                principalTable: "dbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

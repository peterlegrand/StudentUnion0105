using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class stepfieldstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e830224-8600-4bdf-b012-3f8f719501e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52b9c140-b5ea-4526-978a-2a8dbd946c42");

            migrationBuilder.AddColumn<int>(
                name: "SuProcessTemplateStepFieldStatusModelId",
                table: "dbContent",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateStepFieldStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateStepFieldStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53518a78-309d-43ef-92d8-b694c6c8baee", "63b1efc0-5d03-432e-94ac-2b1774ddd908", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6213412d-7568-4bc3-a1f9-0e1fc0c46921", "b1141278-3746-4e61-a38f-266f828e705a", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepField_StatusId",
                table: "dbProcessTemplateStepField",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContent_SuProcessTemplateStepFieldStatusModelId",
                table: "dbContent",
                column: "SuProcessTemplateStepFieldStatusModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbContent_dbProcessTemplateStepFieldStatus_SuProcessTemplateStepFieldStatusModelId",
                table: "dbContent",
                column: "SuProcessTemplateStepFieldStatusModelId",
                principalTable: "dbProcessTemplateStepFieldStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateStepField_dbProcessTemplateStepFieldStatus_StatusId",
                table: "dbProcessTemplateStepField",
                column: "StatusId",
                principalTable: "dbProcessTemplateStepFieldStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbContent_dbProcessTemplateStepFieldStatus_SuProcessTemplateStepFieldStatusModelId",
                table: "dbContent");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateStepField_dbProcessTemplateStepFieldStatus_StatusId",
                table: "dbProcessTemplateStepField");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateStepFieldStatus");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateStepField_StatusId",
                table: "dbProcessTemplateStepField");

            migrationBuilder.DropIndex(
                name: "IX_dbContent_SuProcessTemplateStepFieldStatusModelId",
                table: "dbContent");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53518a78-309d-43ef-92d8-b694c6c8baee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6213412d-7568-4bc3-a1f9-0e1fc0c46921");

            migrationBuilder.DropColumn(
                name: "SuProcessTemplateStepFieldStatusModelId",
                table: "dbContent");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e830224-8600-4bdf-b012-3f8f719501e7", "0373b872-acc6-4dbc-aade-ab6ebed416ed", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52b9c140-b5ea-4526-978a-2a8dbd946c42", "320b64da-fb5a-4d12-935d-1bc723657ee0", "Super admin", "SUPER ADMIN" });
        }
    }
}

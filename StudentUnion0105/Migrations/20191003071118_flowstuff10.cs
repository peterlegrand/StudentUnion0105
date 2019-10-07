using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class flowstuff10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76e9897-b06e-4ea7-9c4b-f8ad7124700d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b755e5f3-7c5d-4874-96f4-0903812822d5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0526109d-c1e0-4d80-abed-b10bcf136a01", "a8ff3fde-d9e9-4385-853f-24d685d0eb68", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee097ca0-653f-4245-9b95-fc4c1d45eac3", "0121750b-6edc-4dd8-8521-6d23fded7c7f", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlow_ProcessTemplateFromStepId",
                table: "dbProcessTemplateFlow",
                column: "ProcessTemplateFromStepId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlow_ProcessTemplateToStepId",
                table: "dbProcessTemplateFlow",
                column: "ProcessTemplateToStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateFlow_dbProcessTemplateStep_ProcessTemplateFromStepId",
                table: "dbProcessTemplateFlow",
                column: "ProcessTemplateFromStepId",
                principalTable: "dbProcessTemplateStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateFlow_dbProcessTemplateStep_ProcessTemplateToStepId",
                table: "dbProcessTemplateFlow",
                column: "ProcessTemplateToStepId",
                principalTable: "dbProcessTemplateStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateFlow_dbProcessTemplateStep_ProcessTemplateFromStepId",
                table: "dbProcessTemplateFlow");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateFlow_dbProcessTemplateStep_ProcessTemplateToStepId",
                table: "dbProcessTemplateFlow");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateFlow_ProcessTemplateFromStepId",
                table: "dbProcessTemplateFlow");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateFlow_ProcessTemplateToStepId",
                table: "dbProcessTemplateFlow");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0526109d-c1e0-4d80-abed-b10bcf136a01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee097ca0-653f-4245-9b95-fc4c1d45eac3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a76e9897-b06e-4ea7-9c4b-f8ad7124700d", "30b441a1-15cf-4008-be64-14fab31de25e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b755e5f3-7c5d-4874-96f4-0903812822d5", "1c188c34-d50f-4f68-82c6-c7cdc65cf865", "Super admin", "SUPER ADMIN" });
        }
    }
}

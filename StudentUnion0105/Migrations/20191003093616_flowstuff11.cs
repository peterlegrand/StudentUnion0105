using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class flowstuff11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "ProcessTemplateToStepId",
                table: "dbProcessTemplateFlow",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessTemplateFromStepId",
                table: "dbProcessTemplateFlow",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88ac0b2f-518c-4f72-be6b-8c24ea7209d5", "cbf322a8-8189-44f4-93e9-ff7c116e8ac0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c79f82dd-9573-4149-9383-9e8712da7a6a", "3911d3a0-7e6b-4332-8841-f5c369510a36", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ac0b2f-518c-4f72-be6b-8c24ea7209d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c79f82dd-9573-4149-9383-9e8712da7a6a");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessTemplateToStepId",
                table: "dbProcessTemplateFlow",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProcessTemplateFromStepId",
                table: "dbProcessTemplateFlow",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}

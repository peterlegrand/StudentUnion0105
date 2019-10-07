using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class flowstuff9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "067cea50-9886-411b-beb0-79234c81d3ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29b52066-5c95-4c07-bb72-e4ffdf75c4be");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateFromStep",
                table: "dbProcessTemplateFlow");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateToStep",
                table: "dbProcessTemplateFlow");

            migrationBuilder.AddColumn<int>(
                name: "ProcessTemplateFromStepId",
                table: "dbProcessTemplateFlow",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessTemplateToStepId",
                table: "dbProcessTemplateFlow",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a76e9897-b06e-4ea7-9c4b-f8ad7124700d", "30b441a1-15cf-4008-be64-14fab31de25e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b755e5f3-7c5d-4874-96f4-0903812822d5", "1c188c34-d50f-4f68-82c6-c7cdc65cf865", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlow_ProcessTemplateId",
                table: "dbProcessTemplateFlow",
                column: "ProcessTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateFlow_dbProcessTemplate_ProcessTemplateId",
                table: "dbProcessTemplateFlow",
                column: "ProcessTemplateId",
                principalTable: "dbProcessTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateFlow_dbProcessTemplate_ProcessTemplateId",
                table: "dbProcessTemplateFlow");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateFlow_ProcessTemplateId",
                table: "dbProcessTemplateFlow");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a76e9897-b06e-4ea7-9c4b-f8ad7124700d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b755e5f3-7c5d-4874-96f4-0903812822d5");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateFromStepId",
                table: "dbProcessTemplateFlow");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateToStepId",
                table: "dbProcessTemplateFlow");

            migrationBuilder.AddColumn<int>(
                name: "ProcessTemplateFromStep",
                table: "dbProcessTemplateFlow",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessTemplateToStep",
                table: "dbProcessTemplateFlow",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "067cea50-9886-411b-beb0-79234c81d3ee", "70a5182a-b620-44d8-ab0d-df2cfa877296", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29b52066-5c95-4c07-bb72-e4ffdf75c4be", "cf8dd447-8a75-4f0e-84c3-205dd588139a", "Super admin", "SUPER ADMIN" });
        }
    }
}

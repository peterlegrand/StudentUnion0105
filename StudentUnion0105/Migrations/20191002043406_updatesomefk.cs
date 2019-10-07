using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class updatesomefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdc0d4d4-021c-45aa-a71d-4f06b283a7c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2892773-59bf-4dfb-980d-dccc2165cc20");

            migrationBuilder.AddColumn<int>(
                name: "ProcessTemplateId",
                table: "dbProcessTemplateStep",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15b42e34-01c4-4489-8bb2-53e880a4b44e", "59199461-8531-4060-ae77-4b4230c7b41e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3d1dd72-79e9-4831-8224-ec28d3fc8435", "6752f0dd-185f-4d72-b20d-a784db4ff5f4", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepLanguage_LanguageId",
                table: "dbProcessTemplateStepLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepLanguage_StepId",
                table: "dbProcessTemplateStepLanguage",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStep_ProcessTemplateId",
                table: "dbProcessTemplateStep",
                column: "ProcessTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateStep_dbProcessTemplate_ProcessTemplateId",
                table: "dbProcessTemplateStep",
                column: "ProcessTemplateId",
                principalTable: "dbProcessTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateStepLanguage_dbLanguage_LanguageId",
                table: "dbProcessTemplateStepLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateStepLanguage_dbProcessTemplateStep_StepId",
                table: "dbProcessTemplateStepLanguage",
                column: "StepId",
                principalTable: "dbProcessTemplateStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateStep_dbProcessTemplate_ProcessTemplateId",
                table: "dbProcessTemplateStep");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateStepLanguage_dbLanguage_LanguageId",
                table: "dbProcessTemplateStepLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateStepLanguage_dbProcessTemplateStep_StepId",
                table: "dbProcessTemplateStepLanguage");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateStepLanguage_LanguageId",
                table: "dbProcessTemplateStepLanguage");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateStepLanguage_StepId",
                table: "dbProcessTemplateStepLanguage");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateStep_ProcessTemplateId",
                table: "dbProcessTemplateStep");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15b42e34-01c4-4489-8bb2-53e880a4b44e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3d1dd72-79e9-4831-8224-ec28d3fc8435");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateId",
                table: "dbProcessTemplateStep");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bdc0d4d4-021c-45aa-a71d-4f06b283a7c4", "937d9c83-6b98-4b87-b4a1-40e636e1d0dd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2892773-59bf-4dfb-980d-dccc2165cc20", "f47891da-ce7a-4941-8cd4-903bff56473d", "Super admin", "SUPER ADMIN" });
        }
    }
}

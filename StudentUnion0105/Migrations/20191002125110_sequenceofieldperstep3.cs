using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class sequenceofieldperstep3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45f1d805-caad-40aa-ba02-33c1486c22eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df890959-d4ff-4ce9-bedd-bb97d8756daf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ddc47d7a-49cd-4df8-a616-68abbca98750", "c1383b73-51f2-4c6c-b21a-7071ce83224d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d85ba88d-8dd0-4ea3-b058-84e882cf3603", "b3855ac3-5c11-4824-a49d-66eb1db649d7", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepField_FieldId",
                table: "dbProcessTemplateStepField",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepField_StepId",
                table: "dbProcessTemplateStepField",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateStepField_dbProcessTemplateField_FieldId",
                table: "dbProcessTemplateStepField",
                column: "FieldId",
                principalTable: "dbProcessTemplateField",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateStepField_dbProcessTemplateStep_StepId",
                table: "dbProcessTemplateStepField",
                column: "StepId",
                principalTable: "dbProcessTemplateStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateStepField_dbProcessTemplateField_FieldId",
                table: "dbProcessTemplateStepField");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateStepField_dbProcessTemplateStep_StepId",
                table: "dbProcessTemplateStepField");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateStepField_FieldId",
                table: "dbProcessTemplateStepField");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateStepField_StepId",
                table: "dbProcessTemplateStepField");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d85ba88d-8dd0-4ea3-b058-84e882cf3603");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddc47d7a-49cd-4df8-a616-68abbca98750");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "45f1d805-caad-40aa-ba02-33c1486c22eb", "aec9a4ae-8c8a-41d5-856a-6c210c0deabe", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df890959-d4ff-4ce9-bedd-bb97d8756daf", "399128db-377d-44ff-be15-14168df2d324", "Super admin", "SUPER ADMIN" });
        }
    }
}

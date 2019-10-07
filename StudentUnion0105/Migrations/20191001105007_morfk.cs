using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class morfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1958a873-ee53-4510-b9b5-7508ed2456cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e2b3265-9c1e-483c-b2eb-c057209ee559");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<int>(
                name: "ProcessTemplateGroupId",
                table: "dbProcessTemplateLanguage",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SuProcessTemplateGroupModelId",
                table: "dbProcessTemplateGroupLanguage",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateGroup",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateGroup",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "407aa912-b0ca-454f-bc28-dbb430df8057", "f0be32ab-8510-448b-b781-e2e07c0dcd4b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "798a4a21-8b1f-4b47-a884-80deaa1e3977", "51d590ff-f6e7-4a19-a87e-9ba258233be4", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateLanguage_LanguageId",
                table: "dbProcessTemplateLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateLanguage_ProcessTemplateGroupId",
                table: "dbProcessTemplateLanguage",
                column: "ProcessTemplateGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateGroupLanguage_SuProcessTemplateGroupModelId",
                table: "dbProcessTemplateGroupLanguage",
                column: "SuProcessTemplateGroupModelId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplate_ProcessTemplateGroupId",
                table: "dbProcessTemplate",
                column: "ProcessTemplateGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplate_dbProcessTemplateGroup_ProcessTemplateGroupId",
                table: "dbProcessTemplate",
                column: "ProcessTemplateGroupId",
                principalTable: "dbProcessTemplateGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateGroupLanguage_dbProcessTemplateGroup_SuProcessTemplateGroupModelId",
                table: "dbProcessTemplateGroupLanguage",
                column: "SuProcessTemplateGroupModelId",
                principalTable: "dbProcessTemplateGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateLanguage_dbLanguage_LanguageId",
                table: "dbProcessTemplateLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateLanguage_dbProcessTemplateGroup_ProcessTemplateGroupId",
                table: "dbProcessTemplateLanguage",
                column: "ProcessTemplateGroupId",
                principalTable: "dbProcessTemplateGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplate_dbProcessTemplateGroup_ProcessTemplateGroupId",
                table: "dbProcessTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateGroupLanguage_dbProcessTemplateGroup_SuProcessTemplateGroupModelId",
                table: "dbProcessTemplateGroupLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateLanguage_dbLanguage_LanguageId",
                table: "dbProcessTemplateLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateLanguage_dbProcessTemplateGroup_ProcessTemplateGroupId",
                table: "dbProcessTemplateLanguage");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateLanguage_LanguageId",
                table: "dbProcessTemplateLanguage");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateLanguage_ProcessTemplateGroupId",
                table: "dbProcessTemplateLanguage");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateGroupLanguage_SuProcessTemplateGroupModelId",
                table: "dbProcessTemplateGroupLanguage");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplate_ProcessTemplateGroupId",
                table: "dbProcessTemplate");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "407aa912-b0ca-454f-bc28-dbb430df8057");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "798a4a21-8b1f-4b47-a884-80deaa1e3977");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateGroupId",
                table: "dbProcessTemplateLanguage");

            migrationBuilder.DropColumn(
                name: "SuProcessTemplateGroupModelId",
                table: "dbProcessTemplateGroupLanguage");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateGroup",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateGroup",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1958a873-ee53-4510-b9b5-7508ed2456cb", "fe1b029e-cb18-4071-b43c-f43a4e522457", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e2b3265-9c1e-483c-b2eb-c057209ee559", "6aab8efb-49f1-4b88-854d-2a96485d02c0", "Super admin", "SUPER ADMIN" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class flowstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateFlowCondition_SuProcessTemplateFlowConditionTypeModel_ProcessTemplateConditionTypeId",
                table: "dbProcessTemplateFlowCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_SuProcessTemplateFlowConditionTypeLanguageModel_SuProcessTemplateFlowConditionTypeModel_FlowConditionTypeId",
                table: "SuProcessTemplateFlowConditionTypeLanguageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SuProcessTemplateFlowConditionTypeLanguageModel_dbLanguage_LanguageId",
                table: "SuProcessTemplateFlowConditionTypeLanguageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuProcessTemplateFlowConditionTypeModel",
                table: "SuProcessTemplateFlowConditionTypeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuProcessTemplateFlowConditionTypeLanguageModel",
                table: "SuProcessTemplateFlowConditionTypeLanguageModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5ef35a4-672b-4746-adf6-4949512375e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea1dc766-5653-4cd9-a168-c10afc79f977");

            migrationBuilder.RenameTable(
                name: "SuProcessTemplateFlowConditionTypeModel",
                newName: "dbProcessTemplateFlowConditionType");

            migrationBuilder.RenameTable(
                name: "SuProcessTemplateFlowConditionTypeLanguageModel",
                newName: "dbProcessTemplateFlowConditionTypeLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_SuProcessTemplateFlowConditionTypeLanguageModel_LanguageId",
                table: "dbProcessTemplateFlowConditionTypeLanguage",
                newName: "IX_dbProcessTemplateFlowConditionTypeLanguage_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_SuProcessTemplateFlowConditionTypeLanguageModel_FlowConditionTypeId",
                table: "dbProcessTemplateFlowConditionTypeLanguage",
                newName: "IX_dbProcessTemplateFlowConditionTypeLanguage_FlowConditionTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbProcessTemplateFlowConditionType",
                table: "dbProcessTemplateFlowConditionType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbProcessTemplateFlowConditionTypeLanguage",
                table: "dbProcessTemplateFlowConditionTypeLanguage",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFlowLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlowId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFlowLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFlowLanguage_dbProcessTemplateFlow_FlowId",
                        column: x => x.FlowId,
                        principalTable: "dbProcessTemplateFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFlowLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8572960b-efdc-462d-9f33-cad6d6ab3429", "e4c20088-d70c-491b-b289-d2dd5188f371", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef4ddcf0-10f1-4905-8ef5-1b134d868c4c", "f67423f3-813a-4d07-8a80-cbc040440999", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowLanguage_FlowId",
                table: "dbProcessTemplateFlowLanguage",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowLanguage_LanguageId",
                table: "dbProcessTemplateFlowLanguage",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateFlowCondition_dbProcessTemplateFlowConditionType_ProcessTemplateConditionTypeId",
                table: "dbProcessTemplateFlowCondition",
                column: "ProcessTemplateConditionTypeId",
                principalTable: "dbProcessTemplateFlowConditionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateFlowConditionTypeLanguage_dbProcessTemplateFlowConditionType_FlowConditionTypeId",
                table: "dbProcessTemplateFlowConditionTypeLanguage",
                column: "FlowConditionTypeId",
                principalTable: "dbProcessTemplateFlowConditionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateFlowConditionTypeLanguage_dbLanguage_LanguageId",
                table: "dbProcessTemplateFlowConditionTypeLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateFlowCondition_dbProcessTemplateFlowConditionType_ProcessTemplateConditionTypeId",
                table: "dbProcessTemplateFlowCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateFlowConditionTypeLanguage_dbProcessTemplateFlowConditionType_FlowConditionTypeId",
                table: "dbProcessTemplateFlowConditionTypeLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateFlowConditionTypeLanguage_dbLanguage_LanguageId",
                table: "dbProcessTemplateFlowConditionTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFlowLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbProcessTemplateFlowConditionTypeLanguage",
                table: "dbProcessTemplateFlowConditionTypeLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbProcessTemplateFlowConditionType",
                table: "dbProcessTemplateFlowConditionType");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8572960b-efdc-462d-9f33-cad6d6ab3429");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef4ddcf0-10f1-4905-8ef5-1b134d868c4c");

            migrationBuilder.RenameTable(
                name: "dbProcessTemplateFlowConditionTypeLanguage",
                newName: "SuProcessTemplateFlowConditionTypeLanguageModel");

            migrationBuilder.RenameTable(
                name: "dbProcessTemplateFlowConditionType",
                newName: "SuProcessTemplateFlowConditionTypeModel");

            migrationBuilder.RenameIndex(
                name: "IX_dbProcessTemplateFlowConditionTypeLanguage_LanguageId",
                table: "SuProcessTemplateFlowConditionTypeLanguageModel",
                newName: "IX_SuProcessTemplateFlowConditionTypeLanguageModel_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_dbProcessTemplateFlowConditionTypeLanguage_FlowConditionTypeId",
                table: "SuProcessTemplateFlowConditionTypeLanguageModel",
                newName: "IX_SuProcessTemplateFlowConditionTypeLanguageModel_FlowConditionTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuProcessTemplateFlowConditionTypeLanguageModel",
                table: "SuProcessTemplateFlowConditionTypeLanguageModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuProcessTemplateFlowConditionTypeModel",
                table: "SuProcessTemplateFlowConditionTypeModel",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5ef35a4-672b-4746-adf6-4949512375e2", "3d17152b-9e81-4fba-99ee-b4d6b77391de", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea1dc766-5653-4cd9-a168-c10afc79f977", "67bf03ad-af84-4006-9d9d-acb0191f4701", "Super admin", "SUPER ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateFlowCondition_SuProcessTemplateFlowConditionTypeModel_ProcessTemplateConditionTypeId",
                table: "dbProcessTemplateFlowCondition",
                column: "ProcessTemplateConditionTypeId",
                principalTable: "SuProcessTemplateFlowConditionTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SuProcessTemplateFlowConditionTypeLanguageModel_SuProcessTemplateFlowConditionTypeModel_FlowConditionTypeId",
                table: "SuProcessTemplateFlowConditionTypeLanguageModel",
                column: "FlowConditionTypeId",
                principalTable: "SuProcessTemplateFlowConditionTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SuProcessTemplateFlowConditionTypeLanguageModel_dbLanguage_LanguageId",
                table: "SuProcessTemplateFlowConditionTypeLanguageModel",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

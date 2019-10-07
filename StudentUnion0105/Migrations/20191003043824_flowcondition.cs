using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class flowcondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53518a78-309d-43ef-92d8-b694c6c8baee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6213412d-7568-4bc3-a1f9-0e1fc0c46921");

            migrationBuilder.CreateTable(
                name: "SuProcessTemplateFlowConditionTypeModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuProcessTemplateFlowConditionTypeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuProcessTemplateFlowConditionTypeLanguageModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlowConditionTypeId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_SuProcessTemplateFlowConditionTypeLanguageModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuProcessTemplateFlowConditionTypeLanguageModel_SuProcessTemplateFlowConditionTypeModel_FlowConditionTypeId",
                        column: x => x.FlowConditionTypeId,
                        principalTable: "SuProcessTemplateFlowConditionTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuProcessTemplateFlowConditionTypeLanguageModel_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18220deb-bcdc-48bf-ba84-cbdcfe96445f", "b720e54b-034f-412d-8715-69e33ed022a5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28a20918-f11e-4f37-bd0f-cfe012808f9f", "f87eff3f-3dea-48d5-9dd2-c8af9e360927", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowConditionLanguage_FlowConditionId",
                table: "dbProcessTemplateFlowConditionLanguage",
                column: "FlowConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowConditionLanguage_LanguageId",
                table: "dbProcessTemplateFlowConditionLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowCondition_ProcessTemplateConditionTypeId",
                table: "dbProcessTemplateFlowCondition",
                column: "ProcessTemplateConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowCondition_ProcessTemplateFlowId",
                table: "dbProcessTemplateFlowCondition",
                column: "ProcessTemplateFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_SuProcessTemplateFlowConditionTypeLanguageModel_FlowConditionTypeId",
                table: "SuProcessTemplateFlowConditionTypeLanguageModel",
                column: "FlowConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SuProcessTemplateFlowConditionTypeLanguageModel_LanguageId",
                table: "SuProcessTemplateFlowConditionTypeLanguageModel",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateFlowCondition_SuProcessTemplateFlowConditionTypeModel_ProcessTemplateConditionTypeId",
                table: "dbProcessTemplateFlowCondition",
                column: "ProcessTemplateConditionTypeId",
                principalTable: "SuProcessTemplateFlowConditionTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateFlowCondition_dbProcessTemplateFlow_ProcessTemplateFlowId",
                table: "dbProcessTemplateFlowCondition",
                column: "ProcessTemplateFlowId",
                principalTable: "dbProcessTemplateFlow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateFlowConditionLanguage_dbProcessTemplateFlowCondition_FlowConditionId",
                table: "dbProcessTemplateFlowConditionLanguage",
                column: "FlowConditionId",
                principalTable: "dbProcessTemplateFlowCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateFlowConditionLanguage_dbLanguage_LanguageId",
                table: "dbProcessTemplateFlowConditionLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateFlowCondition_SuProcessTemplateFlowConditionTypeModel_ProcessTemplateConditionTypeId",
                table: "dbProcessTemplateFlowCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateFlowCondition_dbProcessTemplateFlow_ProcessTemplateFlowId",
                table: "dbProcessTemplateFlowCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateFlowConditionLanguage_dbProcessTemplateFlowCondition_FlowConditionId",
                table: "dbProcessTemplateFlowConditionLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateFlowConditionLanguage_dbLanguage_LanguageId",
                table: "dbProcessTemplateFlowConditionLanguage");

            migrationBuilder.DropTable(
                name: "SuProcessTemplateFlowConditionTypeLanguageModel");

            migrationBuilder.DropTable(
                name: "SuProcessTemplateFlowConditionTypeModel");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateFlowConditionLanguage_FlowConditionId",
                table: "dbProcessTemplateFlowConditionLanguage");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateFlowConditionLanguage_LanguageId",
                table: "dbProcessTemplateFlowConditionLanguage");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateFlowCondition_ProcessTemplateConditionTypeId",
                table: "dbProcessTemplateFlowCondition");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateFlowCondition_ProcessTemplateFlowId",
                table: "dbProcessTemplateFlowCondition");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18220deb-bcdc-48bf-ba84-cbdcfe96445f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28a20918-f11e-4f37-bd0f-cfe012808f9f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53518a78-309d-43ef-92d8-b694c6c8baee", "63b1efc0-5d03-432e-94ac-2b1774ddd908", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6213412d-7568-4bc3-a1f9-0e1fc0c46921", "b1141278-3746-4e61-a38f-266f828e705a", "Super admin", "SUPER ADMIN" });
        }
    }
}

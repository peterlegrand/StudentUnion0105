using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class fresh2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbProcessTemplateStep_SuProcessTemplateStepTypeModel_ProcessTemplateStepTypeId",
                table: "DbProcessTemplateStep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuProcessTemplateStepTypeModel",
                table: "SuProcessTemplateStepTypeModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "336f930e-5761-49c1-80ce-896f1c08f489");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62db02ae-f23f-481f-abd3-42f243e0f1a2");

            migrationBuilder.RenameTable(
                name: "SuProcessTemplateStepTypeModel",
                newName: "dbProcessTemplateStepType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbProcessTemplateStepType",
                table: "dbProcessTemplateStepType",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateStepTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StepTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateStepTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateStepTypeLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateStepTypeLanguage_dbProcessTemplateStepType_StepTypeId",
                        column: x => x.StepTypeId,
                        principalTable: "dbProcessTemplateStepType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2809e63f-130a-45fa-8729-98368edc8cac", "81e774fa-3f39-494c-bcb4-eb0185580a8c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c364846e-243f-4016-8f06-6d90733f743d", "b0e7d788-fe5f-41fe-be24-0104ba177324", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepTypeLanguage_LanguageId",
                table: "dbProcessTemplateStepTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepTypeLanguage_StepTypeId",
                table: "dbProcessTemplateStepTypeLanguage",
                column: "StepTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbProcessTemplateStep_dbProcessTemplateStepType_ProcessTemplateStepTypeId",
                table: "DbProcessTemplateStep",
                column: "ProcessTemplateStepTypeId",
                principalTable: "dbProcessTemplateStepType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbProcessTemplateStep_dbProcessTemplateStepType_ProcessTemplateStepTypeId",
                table: "DbProcessTemplateStep");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateStepTypeLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbProcessTemplateStepType",
                table: "dbProcessTemplateStepType");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2809e63f-130a-45fa-8729-98368edc8cac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c364846e-243f-4016-8f06-6d90733f743d");

            migrationBuilder.RenameTable(
                name: "dbProcessTemplateStepType",
                newName: "SuProcessTemplateStepTypeModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuProcessTemplateStepTypeModel",
                table: "SuProcessTemplateStepTypeModel",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62db02ae-f23f-481f-abd3-42f243e0f1a2", "7f78da46-dbaa-4014-bf9b-42a315b1c9ec", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "336f930e-5761-49c1-80ce-896f1c08f489", "9fb39a8b-f3f7-4947-a7c9-41881d0a9bb0", "Super admin", "SUPER ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_DbProcessTemplateStep_SuProcessTemplateStepTypeModel_ProcessTemplateStepTypeId",
                table: "DbProcessTemplateStep",
                column: "ProcessTemplateStepTypeId",
                principalTable: "SuProcessTemplateStepTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

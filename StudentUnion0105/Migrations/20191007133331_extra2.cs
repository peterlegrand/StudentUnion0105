using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class extra2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbProcessTemplateFlowConditionTypeLanguage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "122785d8-5c84-4c11-b5de-0281d8b38bca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1eed3044-3ab1-41b1-92c7-d1069d1b7ab0");

            migrationBuilder.AddColumn<string>(
                name: "ConditionTypeName",
                table: "dbProcessTemplateFlowConditionType",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessTemplateFieldId",
                table: "dbProcessTemplateFlowCondition",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ComparisonOperatorId",
                table: "dbProcessTemplateFlowCondition",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a35c5aef-5c34-4633-a5bd-5aa43967b743", "2b093fd8-c1ed-476d-a08e-e8a9af4911d6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3f834fe-fcaf-43c7-ba10-f9970c897ff5", "10e3601d-ac06-44c0-9932-1d2c8f05728e", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a35c5aef-5c34-4633-a5bd-5aa43967b743");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3f834fe-fcaf-43c7-ba10-f9970c897ff5");

            migrationBuilder.DropColumn(
                name: "ConditionTypeName",
                table: "dbProcessTemplateFlowConditionType");

            migrationBuilder.DropColumn(
                name: "ComparisonOperatorId",
                table: "dbProcessTemplateFlowCondition");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessTemplateFieldId",
                table: "dbProcessTemplateFlowCondition",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFlowConditionTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FlowConditionTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFlowConditionTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFlowConditionTypeLanguage_dbProcessTemplateFlowConditionType_FlowConditionTypeId",
                        column: x => x.FlowConditionTypeId,
                        principalTable: "dbProcessTemplateFlowConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFlowConditionTypeLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1eed3044-3ab1-41b1-92c7-d1069d1b7ab0", "8123f92e-c0d1-434f-9d58-d447df230e6b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "122785d8-5c84-4c11-b5de-0281d8b38bca", "99d17113-a069-45f5-b66d-f0e873895e56", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowConditionTypeLanguage_FlowConditionTypeId",
                table: "dbProcessTemplateFlowConditionTypeLanguage",
                column: "FlowConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowConditionTypeLanguage_LanguageId",
                table: "dbProcessTemplateFlowConditionTypeLanguage",
                column: "LanguageId");
        }
    }
}

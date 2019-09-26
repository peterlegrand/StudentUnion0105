using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class processtemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e650115-c208-408a-9b29-cd962c457b98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "837a7cf5-3ff3-453f-a275-7c1e681e2319");

            migrationBuilder.CreateTable(
                name: "dbProcessTemplate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateGroupId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateField",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFieldLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateFieldId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ProcessTemplateFieldName = table.Column<string>(nullable: true),
                    ProcessTemplateFieldDescription = table.Column<string>(nullable: true),
                    SuProcessTemplateFieldMouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFieldLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFieldType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFieldType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFieldTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FieldTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFieldTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFieldTypeLanguage_dbPageType_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "dbPageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFieldTypeLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFlow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateId = table.Column<int>(nullable: false),
                    ProcessTemplateFromStep = table.Column<int>(nullable: false),
                    ProcessTemplateToStep = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFlow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFlowCondition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateFlowId = table.Column<int>(nullable: false),
                    ProcessTemplateFieldId = table.Column<int>(nullable: false),
                    ProcessTemplateConditionTypeId = table.Column<int>(nullable: false),
                    ProcessTemplateFlowConditionString = table.Column<string>(nullable: true),
                    ProcessTemplateFlowConditionInt = table.Column<int>(nullable: false),
                    ProcessTemplateFlowConditionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFlowCondition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFlowConditionLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlowConditionId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFlowConditionLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sequence = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateGroupLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateGroupId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ProcessTemplateGroupName = table.Column<string>(nullable: true),
                    ProcessTemplateGroupDescription = table.Column<string>(nullable: true),
                    SuProcessTemplateGroupMouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateGroupLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ProcessTemplateName = table.Column<string>(nullable: true),
                    ProcessTemplateDescription = table.Column<string>(nullable: true),
                    SuProcessTemplateMouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateStep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateStep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateStepField",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StepId = table.Column<int>(nullable: false),
                    FieldId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateStepField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateStepLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StepId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateStepLanguage", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97f07be5-c035-4839-80af-7e0d3cf4d095", "2503a8c4-23ab-4cae-8db4-9a620fa939d6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ea67e24-a691-4894-a27b-f38d37b7aab5", "d3d78e06-acbe-428f-9408-4a6a75af2663", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFieldTypeLanguage_FieldTypeId",
                table: "dbProcessTemplateFieldTypeLanguage",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFieldTypeLanguage_LanguageId",
                table: "dbProcessTemplateFieldTypeLanguage",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbProcessTemplate");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateField");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFieldLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFieldType");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFieldTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFlow");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFlowCondition");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFlowConditionLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateGroup");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateGroupLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateStep");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateStepField");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateStepLanguage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ea67e24-a691-4894-a27b-f38d37b7aab5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97f07be5-c035-4839-80af-7e0d3cf4d095");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "837a7cf5-3ff3-453f-a275-7c1e681e2319", "d5ab44ac-b1e4-4378-859c-895ec381c659", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e650115-c208-408a-9b29-cd962c457b98", "a3fd9efc-79e2-4992-a645-cfbc0d718b5c", "Super admin", "SUPER ADMIN" });
        }
    }
}

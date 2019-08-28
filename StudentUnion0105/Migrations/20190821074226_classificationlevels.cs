using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class classificationlevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuClassificationLevelModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    DateLevel = table.Column<bool>(nullable: false),
                    OnTheFly = table.Column<bool>(nullable: false),
                    Alphabetically = table.Column<bool>(nullable: false),
                    CanLink = table.Column<bool>(nullable: false),
                    InDropDown = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuClassificationLevelModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuClassificationLevelModel_dbClassification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "dbClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuClassificationLevelLanguageModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationLevelId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ClassificationLevelName = table.Column<string>(nullable: true),
                    ClassificationLevelMenuName = table.Column<string>(nullable: true),
                    ClassificationLevelMouseOver = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuClassificationLevelLanguageModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuClassificationLevelLanguageModel_SuClassificationLevelModel_ClassificationLevelId",
                        column: x => x.ClassificationLevelId,
                        principalTable: "SuClassificationLevelModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SuClassificationLevelLanguageModel_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuClassificationLevelLanguageModel_ClassificationLevelId",
                table: "SuClassificationLevelLanguageModel",
                column: "ClassificationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SuClassificationLevelLanguageModel_LanguageId",
                table: "SuClassificationLevelLanguageModel",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SuClassificationLevelModel_ClassificationId",
                table: "SuClassificationLevelModel",
                column: "ClassificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuClassificationLevelLanguageModel");

            migrationBuilder.DropTable(
                name: "SuClassificationLevelModel");
        }
    }
}

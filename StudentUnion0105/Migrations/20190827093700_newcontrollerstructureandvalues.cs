using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class newcontrollerstructureandvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbClassificationValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationId = table.Column<int>(nullable: false),
                    ClassificationLevelId = table.Column<int>(nullable: false),
                    ParentValueId = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTimeOffset>(nullable: false),
                    DateTo = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClassificationValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbClassificationValue_dbClassification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "dbClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbClassificationValue_dbClassificationLevel_ClassificationLevelId",
                        column: x => x.ClassificationLevelId,
                        principalTable: "dbClassificationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbClassificationValueLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationValueId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ClassificationValueName = table.Column<string>(nullable: true),
                    ClassificationValueDescription = table.Column<string>(nullable: true),
                    ClassificationValueDropDownName = table.Column<string>(nullable: true),
                    ClassificationValueMenuName = table.Column<string>(nullable: true),
                    ClassificationValueMouseOver = table.Column<string>(nullable: true),
                    ClassificationValuePageName = table.Column<string>(nullable: true),
                    ClassificationValuePageDescription = table.Column<string>(nullable: true),
                    ClassificationValueHeaderName = table.Column<string>(nullable: true),
                    ClassificationValueHeaderDescription = table.Column<string>(nullable: true),
                    ClassificationValueTopicName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClassificationValueLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbClassificationValueLanguage_dbClassificationValue_ClassificationValueId",
                        column: x => x.ClassificationValueId,
                        principalTable: "dbClassificationValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbClassificationValueLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationValue_ClassificationId",
                table: "dbClassificationValue",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationValue_ClassificationLevelId",
                table: "dbClassificationValue",
                column: "ClassificationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationValueLanguage_ClassificationValueId",
                table: "dbClassificationValueLanguage",
                column: "ClassificationValueId");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationValueLanguage_LanguageId",
                table: "dbClassificationValueLanguage",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbClassificationValueLanguage");

            migrationBuilder.DropTable(
                name: "dbClassificationValue");
        }
    }
}

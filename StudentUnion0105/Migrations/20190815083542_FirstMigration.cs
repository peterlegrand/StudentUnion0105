using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbClassificationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClassificationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbClassification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClassification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbClassification_dbClassificationStatus_ClassificationStatusId",
                        column: x => x.ClassificationStatusId,
                        principalTable: "dbClassificationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbClassificationLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ClassificationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClassificationLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbClassificationLanguage_dbClassification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "dbClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbClassificationLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbClassification_ClassificationStatusId",
                table: "dbClassification",
                column: "ClassificationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationLanguage_ClassificationId",
                table: "dbClassificationLanguage",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationLanguage_LanguageId",
                table: "dbClassificationLanguage",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbClassificationLanguage");

            migrationBuilder.DropTable(
                name: "dbClassification");

            migrationBuilder.DropTable(
                name: "dbLanguage");

            migrationBuilder.DropTable(
                name: "dbClassificationStatus");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class terms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "364d9c0a-45f6-49fb-a22d-70ddcc7cfa30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef498e6e-5deb-4cf5-8f13-989252542be3");

            migrationBuilder.CreateTable(
                name: "dbScreen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbScreen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbTerm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbTerm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbTermLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TermId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Customization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbTermLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbTermLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbTermLanguage_dbTerm_TermId",
                        column: x => x.TermId,
                        principalTable: "dbTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbTermScreen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TermId = table.Column<int>(nullable: false),
                    ScreenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbTermScreen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbTermScreen_dbScreen_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "dbScreen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbTermScreen_dbTerm_TermId",
                        column: x => x.TermId,
                        principalTable: "dbTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "264cf283-d9d0-473e-b928-5d68c51a1e56", "1d9fafc4-6bcd-430f-afd5-9bb198e21c0d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a055b720-c298-41b8-8f49-3ccfcfe12bae", "b003e6de-86b3-454e-8401-9b1ecc79b773", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbTermLanguage_LanguageId",
                table: "dbTermLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbTermLanguage_TermId",
                table: "dbTermLanguage",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_dbTermScreen_ScreenId",
                table: "dbTermScreen",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_dbTermScreen_TermId",
                table: "dbTermScreen",
                column: "TermId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbTermLanguage");

            migrationBuilder.DropTable(
                name: "dbTermScreen");

            migrationBuilder.DropTable(
                name: "dbScreen");

            migrationBuilder.DropTable(
                name: "dbTerm");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "264cf283-d9d0-473e-b928-5d68c51a1e56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a055b720-c298-41b8-8f49-3ccfcfe12bae");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef498e6e-5deb-4cf5-8f13-989252542be3", "669a6594-fdf5-4a1c-8a25-7b09309bdf36", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "364d9c0a-45f6-49fb-a22d-70ddcc7cfa30", "ff2eed93-a578-4276-8605-b79253447e56", "Super admin", "SUPER ADMIN" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class claims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimGroup = table.Column<string>(nullable: true),
                    Claim = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuClaim", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SuClaim",
                columns: new[] { "Id", "Claim", "ClaimGroup" },
                values: new object[] { 1, "Classification", "Classification" });

            migrationBuilder.InsertData(
                table: "SuClaim",
                columns: new[] { "Id", "Claim", "ClaimGroup" },
                values: new object[] { 2, "ClassificationLevel", "Classification" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuClaim");
        }
    }
}

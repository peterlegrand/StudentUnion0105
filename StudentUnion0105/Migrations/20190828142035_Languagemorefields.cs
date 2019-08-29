using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class Languagemorefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "dbLanguage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ISO6391",
                table: "dbLanguage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISO6392",
                table: "dbLanguage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "dbLanguage");

            migrationBuilder.DropColumn(
                name: "ISO6391",
                table: "dbLanguage");

            migrationBuilder.DropColumn(
                name: "ISO6392",
                table: "dbLanguage");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class claims23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SuClaim",
                table: "SuClaim");

            migrationBuilder.RenameTable(
                name: "SuClaim",
                newName: "dbClaim");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbClaim",
                table: "dbClaim",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dbClaim",
                table: "dbClaim");

            migrationBuilder.RenameTable(
                name: "dbClaim",
                newName: "SuClaim");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuClaim",
                table: "SuClaim",
                column: "Id");
        }
    }
}

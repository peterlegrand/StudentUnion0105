using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class onemoreclaimagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "dbClaim",
                columns: new[] { "Id", "Claim", "ClaimGroup" },
                values: new object[] { 4, "Roles", "Administration" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

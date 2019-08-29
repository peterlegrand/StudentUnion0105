using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class AddMoreSeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 39,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 41,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 157,
                column: "Active",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 39,
                column: "Active",
                value: false);

            migrationBuilder.UpdateData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 41,
                column: "Active",
                value: false);

            migrationBuilder.UpdateData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 157,
                column: "Active",
                value: false);
        }
    }
}

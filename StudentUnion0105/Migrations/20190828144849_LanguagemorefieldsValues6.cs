using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class LanguagemorefieldsValues6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "dbLanguage",
                columns: new[] { "Id", "Active", "ForeignName", "ISO6391", "ISO6392", "LanguageName" },
                values: new object[,]
                {
                    { 3, false, "Afrikaans", "af", "afr", "Afrikaans" },
                    { 4, false, "Akan", "ak", "aka", "Akan" },
                    { 5, false, "Shqip", "sq", "sqi", "Albanian" },
                    { 6, false, "አማርኛ", "am", "amh", "Amharic" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}

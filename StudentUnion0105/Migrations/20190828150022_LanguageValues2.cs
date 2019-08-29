using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class LanguageValues2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "dbLanguage",
                columns: new[] { "Id", "Active", "ForeignName", "ISO6391", "ISO6392", "LanguageName" },
                values: new object[,]
                {
                    { 49, false, "Fulfulde, Pulaar, Pular", "ff", "ful", "Fulah" },
                    { 50, false, "Galego", "gl", "glg", "Galician" },
                    { 51, false, "ქართული", "ka", "kat", "Georgian" },
                    { 52, false, "Deutsch", "de", "deu", "German" },
                    { 53, false, "ελληνικά", "el", "ell", "Greek, Modern (1453-)" },
                    { 54, false, "Avañe ẽ", "gn", "grn", "Guarani" },
                    { 55, false, "ગુજરાતી", "gu", "guj", "Gujarati" },
                    { 56, false, "Kreyòl ayisyen", "ht", "hat", "Haitian, Haitian Creole" },
                    { 57, false, "(Hausa) هَوُسَ", "ha", "hau", "Hausa" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 57);
        }
    }
}

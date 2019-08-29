using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class LanguagemorefieldsValues7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "dbLanguage",
                columns: new[] { "Id", "Active", "ForeignName", "ISO6391", "ISO6392", "LanguageName" },
                values: new object[,]
                {
                    { 7, false, "العربية", "ar", "ara", "Arabic" },
                    { 22, false, "bosanski jezik", "bs", "bos", "Bosnian" },
                    { 21, false, "Bislama", "bi", "bis", "Bislama" },
                    { 20, false, "भोजपुरी", "bh", "bih", "Bihari languages" },
                    { 19, false, "বাংলা", "bn", "ben", "Bengali" },
                    { 18, false, "беларуская мова", "be", "bel", "Belarusian" },
                    { 17, false, "euskara, euskera", "eu", "eus", "Basque" },
                    { 16, false, "башҡорт теле", "ba", "bak", "Bashkir" },
                    { 15, false, "bamanankan", "bm", "bam", "Bambara" },
                    { 14, false, "azərbaycan dili", "az", "aze", "Azerbaijani" },
                    { 13, false, "aymar aru", "ay", "aym", "Aymara" },
                    { 12, false, "avesta", "ae", "ave", "Avestan" },
                    { 11, false, "авар мацӀ, магӀарул мацӀ", "av", "ava", "Avaric" },
                    { 10, false, "অসমীয়া", "as", "asm", "Assamese" },
                    { 9, false, "Հայերեն", "hy", "hye", "Armenian" },
                    { 8, false, "aragonés", "an", "arg", "Aragonese" },
                    { 23, false, "brezhoneg", "br", "bre", "Breton" },
                    { 24, false, "български език", "bg", "bul", "Bulgarian" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}

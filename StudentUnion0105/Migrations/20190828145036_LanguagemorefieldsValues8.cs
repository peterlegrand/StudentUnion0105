using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class LanguagemorefieldsValues8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "dbLanguage",
                columns: new[] { "Id", "Active", "ForeignName", "ISO6391", "ISO6392", "LanguageName" },
                values: new object[,]
                {
                    { 25, false, "ဗမာစာ", "my", "mya", "Burmese" },
                    { 41, false, "English", "en", "eng", "English" },
                    { 40, false, "རྫོང་ཁ", "dz", "dzo", "Dzongkha" },
                    { 39, false, "Nederlands, Vlaams", "nl", "nld", "Dutch, Flemish" },
                    { 38, false, "ދިވެހި", "dv", "div", "Divehi, Dhivehi, Maldivian" },
                    { 37, false, "dansk", "da", "dan", "Danish" },
                    { 36, false, "čeština, český jazyk", "cs", "ces", "Czech" },
                    { 35, false, "hrvatski jezik", "hr", "hrv", "Croatian" },
                    { 42, false, "Esperanto", "eo", "epo", "Esperanto" },
                    { 34, false, "ᓀᐦᐃᔭᐍᐏᐣ", "cr", "cre", "Cree" },
                    { 32, false, "Kernewek", "kw", "cor", "Cornish" },
                    { 31, false, "чӑваш чӗлхи", "cv", "chv", "Chuvash" },
                    { 30, false, "中文(Zhōngwén), 汉语, 漢語", "zh", "zho", "Chinese" },
                    { 29, false, "chiCheŵa, chinyanja", "ny", "nya", "Chichewa, Chewa, Nyanja" },
                    { 28, false, "нохчийн мотт", "ce", "che", "Chechen" },
                    { 27, false, "Chamoru", "ch", "cha", "Chamorro" },
                    { 26, false, "català, valencià", "ca", "cat", "Catalan, Valencian" },
                    { 33, false, "corsu, lingua corsa", "co", "cos", "Corsican" },
                    { 43, false, "eesti, eesti keel", "et", "est", "Estonian" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 43);
        }
    }
}

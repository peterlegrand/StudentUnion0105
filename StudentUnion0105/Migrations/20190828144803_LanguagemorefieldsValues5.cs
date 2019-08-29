using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class LanguagemorefieldsValues5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "dbLanguage",
                columns: new[] { "Id", "Active", "ForeignName", "ISO6391", "ISO6392", "LanguageName" },
                values: new object[] { 1, false, "аҧсуа бызшәа, аҧсшәа", "ab", "abk", "Abkhazian" });

            migrationBuilder.InsertData(
                table: "dbLanguage",
                columns: new[] { "Id", "Active", "ForeignName", "ISO6391", "ISO6392", "LanguageName" },
                values: new object[] { 2, false, "Afaraf", "aa", "aar", "Afar" });

            migrationBuilder.InsertData(
                table: "dbLanguage",
                columns: new[] { "Id", "Active", "ForeignName", "ISO6391", "ISO6392", "LanguageName" },
                values: new object[] { 184, false, "isiZulu", "zu", "zul", "Zulu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 184);
        }
    }
}

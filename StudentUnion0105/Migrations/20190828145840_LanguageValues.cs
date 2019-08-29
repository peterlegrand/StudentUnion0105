using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class LanguageValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "dbLanguage",
                columns: new[] { "Id", "Active", "ForeignName", "ISO6391", "ISO6392", "LanguageName" },
                values: new object[,]
                {
                    { 44, false, "Eʋegbe", "ee", "ewe", "Ewe" },
                    { 45, false, "føroyskt", "fo", "fao", "Faroese" },
                    { 46, false, "vosa Vakaviti", "fj", "fij", "Fijian" },
                    { 47, false, "suomi, suomen kieli", "fi", "fin", "Finnish" },
                    { 48, false, "français, langue française", "fr", "fra", "French" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "dbLanguage",
                keyColumn: "Id",
                keyValue: 48);
        }
    }
}

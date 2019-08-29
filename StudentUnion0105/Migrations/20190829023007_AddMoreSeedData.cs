using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class AddMoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "dbClassificationStatus",
                columns: new[] { "Id", "ClassificationStatusName" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" }
                });

            migrationBuilder.InsertData(
                table: "dbOrganizationStatus",
                columns: new[] { "Id", "OrganizationStatusName" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" }
                });

            migrationBuilder.InsertData(
                table: "dbProjectStatus",
                columns: new[] { "Id", "ProjectStatusName" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" }
                });

            migrationBuilder.UpdateData(
                table: "dbSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "IntValue",
                value: 41);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dbClassificationStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "dbClassificationStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "dbOrganizationStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "dbOrganizationStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "dbProjectStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "dbProjectStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "dbSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "IntValue",
                value: 1);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class fresh05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32d21312-809b-4a4e-be4f-bf4efbc21ac2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab201a6-1a2a-4b00-b022-a343cc6794c3");

            migrationBuilder.RenameColumn(
                name: "ConditionTypeName",
                table: "dbProcessTemplateFlowConditionType",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef6e30e8-ca2e-4472-8814-97750c256fb9", "12e8eee5-6ec1-40c8-9fc7-98106a92b35a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07819592-4a51-4bd9-9619-fcf1abba15b3", "d5c6cb9e-3a36-4802-9787-e952212ce7a4", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07819592-4a51-4bd9-9619-fcf1abba15b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef6e30e8-ca2e-4472-8814-97750c256fb9");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "dbProcessTemplateFlowConditionType",
                newName: "ConditionTypeName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fab201a6-1a2a-4b00-b022-a343cc6794c3", "36493c01-1ee8-4b2b-9dbe-5cc69a4186eb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "32d21312-809b-4a4e-be4f-bf4efbc21ac2", "cea33a62-d08c-4aca-88f9-bfdc723060f9", "Super admin", "SUPER ADMIN" });
        }
    }
}

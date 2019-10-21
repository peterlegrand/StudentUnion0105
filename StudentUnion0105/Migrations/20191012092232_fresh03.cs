using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class fresh03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e805711-b206-4ee0-9d8d-9f2e232704a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0968f84-d809-485c-b63b-a154665a81d8");

            migrationBuilder.RenameColumn(
                name: "DataTypeName",
                table: "dbDataType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "dbCountry",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d6a59c5-6274-473b-aa58-5f474290c967", "d16a3f21-7b9f-40bd-be77-c3378e80d8ae", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53699586-6019-4365-866e-036c865ed23a", "85520afe-74bf-4630-9077-186a950dd441", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53699586-6019-4365-866e-036c865ed23a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d6a59c5-6274-473b-aa58-5f474290c967");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "dbDataType",
                newName: "DataTypeName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "dbCountry",
                newName: "CountryName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e805711-b206-4ee0-9d8d-9f2e232704a0", "832cfcd9-01f1-4fba-80a1-1fe464bb8aef", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0968f84-d809-485c-b63b-a154665a81d8", "12f717ad-d0fe-42df-85f8-0f23bfb297c0", "Super admin", "SUPER ADMIN" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class fresh02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9208e3a-a93d-4573-8a56-a4a20374737d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfc27e37-116e-4a4a-930b-4583141983c4");

            migrationBuilder.RenameColumn(
                name: "MasterListName",
                table: "dbMasterList",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MasterListDescription",
                table: "dbMasterList",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e805711-b206-4ee0-9d8d-9f2e232704a0", "832cfcd9-01f1-4fba-80a1-1fe464bb8aef", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0968f84-d809-485c-b63b-a154665a81d8", "12f717ad-d0fe-42df-85f8-0f23bfb297c0", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Name",
                table: "dbMasterList",
                newName: "MasterListName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "dbMasterList",
                newName: "MasterListDescription");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9208e3a-a93d-4573-8a56-a4a20374737d", "91442afb-3388-422d-be90-3e9671c3ba94", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfc27e37-116e-4a4a-930b-4583141983c4", "132ae80b-2134-4a1e-8c9c-e1a19d86282f", "Super admin", "SUPER ADMIN" });
        }
    }
}

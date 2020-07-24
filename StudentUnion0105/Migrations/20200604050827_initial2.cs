using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84af8d2c-1196-473e-b819-37815fdbcf0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d409b39f-40cd-42b9-bb8d-fcb7288f6938");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "DbContent",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb488192-8623-49e3-803f-c4cd49ca4b2f", "3ecc05d7-7870-4d30-90a1-b30b71527c56", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc0d1c81-b32c-4ae5-b04c-a0121236a791", "6cdaee06-1be6-4c9f-898b-ce59612a1fff", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc0d1c81-b32c-4ae5-b04c-a0121236a791");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb488192-8623-49e3-803f-c4cd49ca4b2f");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "DbContent",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d409b39f-40cd-42b9-bb8d-fcb7288f6938", "4dc35a90-dabc-4525-b987-950c1a5a1452", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84af8d2c-1196-473e-b819-37815fdbcf0d", "0ed11f91-9230-4791-ae8e-0b7608e7d4a3", "Super admin", "SUPER ADMIN" });
        }
    }
}

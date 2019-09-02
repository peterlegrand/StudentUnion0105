using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class pagestatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "324d6982-830b-4757-a163-4987bc3af36b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49e84172-20c0-49e1-b1d8-e654fb31fec8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4def7b04-7f47-4e98-9e79-4fa3eef00070", "3ca333dd-e202-449b-88ad-f1cc1a9c230d", "Admin", "ADMIN" },
                });

            migrationBuilder.InsertData(
                table: "dbPageStatus",
                columns: new[] { "Id", "PageStatusName" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4def7b04-7f47-4e98-9e79-4fa3eef00070");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e812274f-fc2c-433a-8bb3-f3e76beb0fc0");

            migrationBuilder.DeleteData(
                table: "dbPageStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "dbPageStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "324d6982-830b-4757-a163-4987bc3af36b", "69ef5c83-b0ed-4fad-9ef2-eb886037f1fd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49e84172-20c0-49e1-b1d8-e654fb31fec8", "f84cea53-bb71-452f-9da2-9828de82c1f3", "Admin", "ADMIN" });
        }
    }
}

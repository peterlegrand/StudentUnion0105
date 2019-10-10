using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class userstuff3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "131a6f89-3879-471f-b033-474a3f1d0fc7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb34fe58-63e5-40ef-8d3a-50942462da19");

            migrationBuilder.RenameColumn(
                name: "DefaultLangauge",
                table: "AspNetUsers",
                newName: "DefaultLanguageId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a829a79-05ff-40d9-9585-debea7235878", "f997c61f-0b61-45d5-a8b1-7077def6a93d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d75f50e-08cf-43d4-9c84-8ec4c82fc295", "56131ec6-6f59-4e13-a6af-67a140cf5d94", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d75f50e-08cf-43d4-9c84-8ec4c82fc295");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a829a79-05ff-40d9-9585-debea7235878");

            migrationBuilder.RenameColumn(
                name: "DefaultLanguageId",
                table: "AspNetUsers",
                newName: "DefaultLangauge");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "131a6f89-3879-471f-b033-474a3f1d0fc7", "7dd3ecd2-0e3a-4775-87f0-3ed737e57409", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb34fe58-63e5-40ef-8d3a-50942462da19", "acac1faa-ee79-4aa0-a02b-0779ce89b85f", "Super admin", "SUPER ADMIN" });
        }
    }
}

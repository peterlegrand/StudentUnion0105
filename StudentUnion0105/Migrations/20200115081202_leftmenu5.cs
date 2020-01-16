using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class leftmenu5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78161f8c-a369-415c-bff5-c547940fe921");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fe6cc53-b471-4d93-91cc-e2ce34d0c885");

            migrationBuilder.RenameColumn(
                name: "HasMenuAdd",
                table: "dbLeftMenu",
                newName: "HasAdd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2e35001-f68f-468f-98c2-51c6886d8614", "88ce3db1-6966-4162-b652-3135fe574607", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b50ec20-3795-49c9-88fc-7b2a817d1aa2", "5d129c16-1540-4c33-b9a3-e5535e0770e0", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b50ec20-3795-49c9-88fc-7b2a817d1aa2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2e35001-f68f-468f-98c2-51c6886d8614");

            migrationBuilder.RenameColumn(
                name: "HasAdd",
                table: "dbLeftMenu",
                newName: "HasMenuAdd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fe6cc53-b471-4d93-91cc-e2ce34d0c885", "d38f1403-375e-4223-a12e-503d63efaa4a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78161f8c-a369-415c-bff5-c547940fe921", "6a9ef7dd-1544-48ca-af2f-dcab011bc72d", "Super admin", "SUPER ADMIN" });
        }
    }
}

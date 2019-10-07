using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class updatestep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15b42e34-01c4-4489-8bb2-53e880a4b44e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3d1dd72-79e9-4831-8224-ec28d3fc8435");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c403d671-69b2-4a34-a9a3-7909fda2df62", "67f67c93-3e86-46df-aac3-8032aa8b32c7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0dbf6907-d76a-4ee3-9d93-46df7b07e741", "7597887f-d357-44df-8ca8-8e3c9a43a1fe", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dbf6907-d76a-4ee3-9d93-46df7b07e741");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c403d671-69b2-4a34-a9a3-7909fda2df62");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15b42e34-01c4-4489-8bb2-53e880a4b44e", "59199461-8531-4060-ae77-4b4230c7b41e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3d1dd72-79e9-4831-8224-ec28d3fc8435", "6752f0dd-185f-4d72-b20d-a784db4ff5f4", "Super admin", "SUPER ADMIN" });
        }
    }
}

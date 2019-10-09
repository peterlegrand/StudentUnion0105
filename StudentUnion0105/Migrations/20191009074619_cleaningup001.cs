using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class cleaningup001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a424360a-e4e0-4284-95e2-ba4611970104");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbd0e9a6-419f-4a19-ac5e-1e241264934e");

            migrationBuilder.AlterColumn<string>(
                name: "ClassificationName",
                table: "dbClassificationLanguage",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassificationMouseOver",
                table: "dbClassificationLanguage",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassificationMenuName",
                table: "dbClassificationLanguage",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4722069-791b-4e82-8ec4-f0d8cb80391a", "bc7b2eb8-5271-4561-89a6-19be0f56da6b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ece065c9-78dd-4100-b788-8ea64d09d5f4", "bf8906ff-25b8-47ad-a190-87dacb1c1d65", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4722069-791b-4e82-8ec4-f0d8cb80391a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ece065c9-78dd-4100-b788-8ea64d09d5f4");

            migrationBuilder.AlterColumn<string>(
                name: "ClassificationName",
                table: "dbClassificationLanguage",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassificationMouseOver",
                table: "dbClassificationLanguage",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassificationMenuName",
                table: "dbClassificationLanguage",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a424360a-e4e0-4284-95e2-ba4611970104", "a6917896-4bcf-440e-807f-2ec97209c7dd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dbd0e9a6-419f-4a19-ac5e-1e241264934e", "6beda58c-d236-4d70-8096-c05883c9f70a", "Super admin", "SUPER ADMIN" });
        }
    }
}

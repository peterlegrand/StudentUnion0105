using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class mycontent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12f4bec1-93ef-4e7e-99a8-08f55599e532");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f4f8b75-4bec-4392-b2fa-0752d5144458");

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "ZdbFrontPageMyContentGet",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ZdbFrontPageMyContentGet",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "ZdbFrontPageMyContentGet",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "ZdbFrontPageMyContentGet",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationName",
                table: "ZdbFrontPageMyContentGet",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8da0375a-b890-4baa-8b1d-246cd4a4760c", "047b245f-493e-4d4c-a934-d569223eb206", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1346921-e584-4c5b-9f30-cac3111fdf44", "c9322731-ede6-4a8e-b621-7b86333d7f05", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8da0375a-b890-4baa-8b1d-246cd4a4760c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1346921-e584-4c5b-9f30-cac3111fdf44");

            migrationBuilder.AlterColumn<bool>(
                name: "TypeName",
                table: "ZdbFrontPageMyContentGet",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Title",
                table: "ZdbFrontPageMyContentGet",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "StatusName",
                table: "ZdbFrontPageMyContentGet",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ProjectName",
                table: "ZdbFrontPageMyContentGet",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "OrganizationName",
                table: "ZdbFrontPageMyContentGet",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12f4bec1-93ef-4e7e-99a8-08f55599e532", "2d489f31-138f-4413-a101-f852a12b15ce", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f4f8b75-4bec-4392-b2fa-0752d5144458", "322c084a-287a-45db-9357-3a6b70bb124c", "Super admin", "SUPER ADMIN" });
        }
    }
}

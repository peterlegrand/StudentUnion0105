using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class fresh3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2809e63f-130a-45fa-8729-98368edc8cac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c364846e-243f-4016-8f06-6d90733f743d");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateStepId",
                table: "dbProcessTemplateStepType");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0af5bd17-ea4b-4b4d-9c3f-c67fbe51861e", "21e5a422-0e5c-4f23-8997-6c8b2ccdcabb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb540e35-7356-4095-a066-007efb069708", "252a3a3a-634e-4b89-8b28-7e9f99cd3768", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0af5bd17-ea4b-4b4d-9c3f-c67fbe51861e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb540e35-7356-4095-a066-007efb069708");

            migrationBuilder.AddColumn<int>(
                name: "ProcessTemplateStepId",
                table: "dbProcessTemplateStepType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2809e63f-130a-45fa-8729-98368edc8cac", "81e774fa-3f39-494c-bcb4-eb0185580a8c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c364846e-243f-4016-8f06-6d90733f743d", "b0e7d788-fe5f-41fe-be24-0104ba177324", "Super admin", "SUPER ADMIN" });
        }
    }
}

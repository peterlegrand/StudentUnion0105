using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class extra4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09c120ff-66ef-4f70-b67d-ff6a886f64fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1223c7e9-e75c-4e9a-8b94-255a72734059");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessTemplateFlowConditionInt",
                table: "dbProcessTemplateFlowCondition",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessTemplateFlowConditionDate",
                table: "dbProcessTemplateFlowCondition",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8557923d-3194-49ed-a368-167803eb68b7", "3c8dc1c2-f953-4754-b22e-e347da91a44c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4f3cf26-bd0b-4fa1-94cb-9cc801d5e6cc", "6af14f71-ed68-4669-80d7-692766f3d466", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8557923d-3194-49ed-a368-167803eb68b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4f3cf26-bd0b-4fa1-94cb-9cc801d5e6cc");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessTemplateFlowConditionInt",
                table: "dbProcessTemplateFlowCondition",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessTemplateFlowConditionDate",
                table: "dbProcessTemplateFlowCondition",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1223c7e9-e75c-4e9a-8b94-255a72734059", "db7801dd-ef18-4d6e-bf9e-08ecd9923d1f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09c120ff-66ef-4f70-b67d-ff6a886f64fc", "6d297fbb-93c1-4f6d-8091-5fc645942f7d", "Super admin", "SUPER ADMIN" });
        }
    }
}

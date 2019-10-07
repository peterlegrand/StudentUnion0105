using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class extra6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d10d58c-5f73-4f9f-9ec9-1d929767684c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3997b47-0a83-49b8-a01a-f50f4e2aaaca");

            migrationBuilder.RenameColumn(
                name: "ComparisonOperatorId",
                table: "dbProcessTemplateFlowCondition",
                newName: "ComparisonOperator");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a424360a-e4e0-4284-95e2-ba4611970104", "a6917896-4bcf-440e-807f-2ec97209c7dd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dbd0e9a6-419f-4a19-ac5e-1e241264934e", "6beda58c-d236-4d70-8096-c05883c9f70a", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a424360a-e4e0-4284-95e2-ba4611970104");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbd0e9a6-419f-4a19-ac5e-1e241264934e");

            migrationBuilder.RenameColumn(
                name: "ComparisonOperator",
                table: "dbProcessTemplateFlowCondition",
                newName: "ComparisonOperatorId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d10d58c-5f73-4f9f-9ec9-1d929767684c", "37b7ae4e-3123-411a-a3a0-868bcf052547", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3997b47-0a83-49b8-a01a-f50f4e2aaaca", "1814bd5e-74d1-4018-a57b-dfd5930da65a", "Super admin", "SUPER ADMIN" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class extra5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8557923d-3194-49ed-a368-167803eb68b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4f3cf26-bd0b-4fa1-94cb-9cc801d5e6cc");

            migrationBuilder.AlterColumn<string>(
                name: "ComparisonOperatorId",
                table: "dbProcessTemplateFlowCondition",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d10d58c-5f73-4f9f-9ec9-1d929767684c", "37b7ae4e-3123-411a-a3a0-868bcf052547", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3997b47-0a83-49b8-a01a-f50f4e2aaaca", "1814bd5e-74d1-4018-a57b-dfd5930da65a", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d10d58c-5f73-4f9f-9ec9-1d929767684c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3997b47-0a83-49b8-a01a-f50f4e2aaaca");

            migrationBuilder.AlterColumn<int>(
                name: "ComparisonOperatorId",
                table: "dbProcessTemplateFlowCondition",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8557923d-3194-49ed-a368-167803eb68b7", "3c8dc1c2-f953-4754-b22e-e347da91a44c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4f3cf26-bd0b-4fa1-94cb-9cc801d5e6cc", "6af14f71-ed68-4669-80d7-692766f3d466", "Super admin", "SUPER ADMIN" });
        }
    }
}

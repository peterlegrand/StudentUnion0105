using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class extra3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a35c5aef-5c34-4633-a5bd-5aa43967b743");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3f834fe-fcaf-43c7-ba10-f9970c897ff5");

            migrationBuilder.AddColumn<string>(
                name: "ConditionCharacter",
                table: "dbProcessTemplateFlowCondition",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1223c7e9-e75c-4e9a-8b94-255a72734059", "db7801dd-ef18-4d6e-bf9e-08ecd9923d1f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09c120ff-66ef-4f70-b67d-ff6a886f64fc", "6d297fbb-93c1-4f6d-8091-5fc645942f7d", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09c120ff-66ef-4f70-b67d-ff6a886f64fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1223c7e9-e75c-4e9a-8b94-255a72734059");

            migrationBuilder.DropColumn(
                name: "ConditionCharacter",
                table: "dbProcessTemplateFlowCondition");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a35c5aef-5c34-4633-a5bd-5aa43967b743", "2b093fd8-c1ed-476d-a08e-e8a9af4911d6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3f834fe-fcaf-43c7-ba10-f9970c897ff5", "10e3601d-ac06-44c0-9932-1d2c8f05728e", "Super admin", "SUPER ADMIN" });
        }
    }
}

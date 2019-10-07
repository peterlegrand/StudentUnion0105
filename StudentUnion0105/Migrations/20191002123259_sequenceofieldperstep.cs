using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class sequenceofieldperstep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fe687a1-b2d0-4911-9c71-303c70cb43e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffb39abc-c9e9-410b-8e78-de538f64333d");

            migrationBuilder.AddColumn<int>(
                name: "Sueqence",
                table: "dbProcessTemplateStepField",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d429321-bf53-4fa8-b99f-3ecf143f8a87", "f775e264-84a8-4272-82ca-031635d740d0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37cb8241-ea75-41a2-97de-9ff171957caf", "d918b7f7-44ed-46ca-8f8d-341be82128e3", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37cb8241-ea75-41a2-97de-9ff171957caf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d429321-bf53-4fa8-b99f-3ecf143f8a87");

            migrationBuilder.DropColumn(
                name: "Sueqence",
                table: "dbProcessTemplateStepField");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ffb39abc-c9e9-410b-8e78-de538f64333d", "86e11765-ea95-4e65-af45-0b9ab550159f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5fe687a1-b2d0-4911-9c71-303c70cb43e8", "07e519f2-ae3f-4ec3-875b-f5ae90e8525d", "Super admin", "SUPER ADMIN" });
        }
    }
}

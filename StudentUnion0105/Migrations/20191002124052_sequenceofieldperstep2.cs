using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class sequenceofieldperstep2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37cb8241-ea75-41a2-97de-9ff171957caf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d429321-bf53-4fa8-b99f-3ecf143f8a87");

            migrationBuilder.RenameColumn(
                name: "Sueqence",
                table: "dbProcessTemplateStepField",
                newName: "Sequence");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "45f1d805-caad-40aa-ba02-33c1486c22eb", "aec9a4ae-8c8a-41d5-856a-6c210c0deabe", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df890959-d4ff-4ce9-bedd-bb97d8756daf", "399128db-377d-44ff-be15-14168df2d324", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45f1d805-caad-40aa-ba02-33c1486c22eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df890959-d4ff-4ce9-bedd-bb97d8756daf");

            migrationBuilder.RenameColumn(
                name: "Sequence",
                table: "dbProcessTemplateStepField",
                newName: "Sueqence");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d429321-bf53-4fa8-b99f-3ecf143f8a87", "f775e264-84a8-4272-82ca-031635d740d0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37cb8241-ea75-41a2-97de-9ff171957caf", "d918b7f7-44ed-46ca-8f8d-341be82128e3", "Super admin", "SUPER ADMIN" });
        }
    }
}

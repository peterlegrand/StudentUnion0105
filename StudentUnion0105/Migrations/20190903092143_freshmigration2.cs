using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class freshmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc1c0b27-8d91-4c65-824b-9e1915ce2b28");

            migrationBuilder.DropColumn(
                name: "ClassificationLevelId",
                table: "dbClassificationValue");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5cfb7d3-7e16-46e6-840e-2a6979237376", "b6b6e251-95e5-4166-80d8-d489f872f811", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5cfb7d3-7e16-46e6-840e-2a6979237376");

            migrationBuilder.AddColumn<int>(
                name: "ClassificationLevelId",
                table: "dbClassificationValue",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc1c0b27-8d91-4c65-824b-9e1915ce2b28", "53cee3b0-cdce-4650-8543-9312b31f49c6", "Admin", "ADMIN" });
        }
    }
}

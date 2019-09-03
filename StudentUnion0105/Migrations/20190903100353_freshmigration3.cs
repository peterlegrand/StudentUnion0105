using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class freshmigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5cfb7d3-7e16-46e6-840e-2a6979237376");

            migrationBuilder.AlterColumn<int>(
                name: "ParentProjectId",
                table: "dbProject",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "dbGetProjectStructure",
                columns: table => new
                {
                    Path = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbGetProjectStructure", x => x.Path);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef3d2a98-d41e-4995-a5b3-a5c9c2566351", "39f2f3d9-99e7-4aad-b795-f62d89d18ba5", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbGetProjectStructure");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef3d2a98-d41e-4995-a5b3-a5c9c2566351");

            migrationBuilder.AlterColumn<int>(
                name: "ParentProjectId",
                table: "dbProject",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5cfb7d3-7e16-46e6-840e-2a6979237376", "b6b6e251-95e5-4166-80d8-d489f872f811", "Admin", "ADMIN" });
        }
    }
}

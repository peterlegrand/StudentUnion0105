using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class multiprocessandcontentprocesslink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53f85736-7e95-4b9b-9e4f-8cebd2cca218");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93d3a1ed-7186-4baf-9802-10614d52e542");

            migrationBuilder.AddColumn<int>(
                name: "ContentId",
                table: "DbProcess",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SuMultiProcessModelId",
                table: "DbProcess",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "DbContent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "dbMultiProcess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbMultiProcess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbObjectIndexGet2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbObjectIndexGet2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbSuFrontUserUserDashboardGetRelation",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbSuFrontUserUserDashboardGetRelation", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85fd28aa-fef0-44d7-8d2d-20c36ae65d7f", "96b49926-1f04-496d-90e0-542b80c6e9da", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f596a56b-d27b-420f-9fd5-e35de671fbc3", "7a378ab9-f87b-4df1-a65d-92aa31796f1f", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_DbProcess_SuMultiProcessModelId",
                table: "DbProcess",
                column: "SuMultiProcessModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbProcess_dbMultiProcess_SuMultiProcessModelId",
                table: "DbProcess",
                column: "SuMultiProcessModelId",
                principalTable: "dbMultiProcess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbProcess_dbMultiProcess_SuMultiProcessModelId",
                table: "DbProcess");

            migrationBuilder.DropTable(
                name: "dbMultiProcess");

            migrationBuilder.DropTable(
                name: "ZdbObjectIndexGet2");

            migrationBuilder.DropTable(
                name: "ZdbSuFrontUserUserDashboardGetRelation");

            migrationBuilder.DropIndex(
                name: "IX_DbProcess_SuMultiProcessModelId",
                table: "DbProcess");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85fd28aa-fef0-44d7-8d2d-20c36ae65d7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f596a56b-d27b-420f-9fd5-e35de671fbc3");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "DbProcess");

            migrationBuilder.DropColumn(
                name: "SuMultiProcessModelId",
                table: "DbProcess");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "DbContent");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53f85736-7e95-4b9b-9e4f-8cebd2cca218", "47b02eef-fc26-49ff-ad9d-e99fd174dfd9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93d3a1ed-7186-4baf-9802-10614d52e542", "3dea3cdd-440c-43c9-b050-49e794d638f3", "Super admin", "SUPER ADMIN" });
        }
    }
}

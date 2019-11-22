using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class managerinuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02588eba-1071-47fd-a92a-86e1f5288c61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8e8c39c-8611-48e3-acf0-62e21369bad0");

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ZdbFrontProcessIndexGetTemplateFlowCondition",
                columns: table => new
                {
                    ConditionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConditionString = table.Column<string>(nullable: true),
                    ConditionInt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontProcessIndexGetTemplateFlowCondition", x => x.ConditionTypeId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a03f9216-1873-4c6d-8d50-d3f274affd62", "5ceed3ab-b313-4412-833d-86fe906d6d03", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0609b63e-2040-4a43-bb56-7335c2b3c735", "15cdcb0d-2da8-4e04-8d12-6f0c7f9b212a", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbFrontProcessIndexGetTemplateFlowCondition");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0609b63e-2040-4a43-bb56-7335c2b3c735");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9216-1873-4c6d-8d50-d3f274affd62");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8e8c39c-8611-48e3-acf0-62e21369bad0", "8fd59577-f963-4e80-a95c-1e3f6381ea80", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02588eba-1071-47fd-a92a-86e1f5288c61", "6ac559b4-3715-4c46-ac68-9d179c5e363e", "Super admin", "SUPER ADMIN" });
        }
    }
}

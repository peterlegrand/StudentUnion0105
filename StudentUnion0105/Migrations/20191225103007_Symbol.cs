using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class Symbol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ae1162e-72d2-4d9e-bf6c-54c015ad3206");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68a83ec3-931e-41ed-851b-ef7aa85634a1");

            migrationBuilder.DropColumn(
                name: "DataTypeId",
                table: "ZdbFrontProcessCreateGetField");

            migrationBuilder.RenameColumn(
                name: "MasterListId",
                table: "ZdbFrontProcessCreateGetField",
                newName: "ProcessTemplateFieldTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "DbComparison",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ZdbFrontProcessToDoIndex2GetForAndOr",
                columns: table => new
                {
                    ConditionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlowId = table.Column<int>(nullable: false),
                    ConditionTypeId = table.Column<int>(nullable: false),
                    ConditionFieldId = table.Column<int>(nullable: false),
                    ComparisonOperatorId = table.Column<int>(nullable: false),
                    ConditionString = table.Column<string>(nullable: true),
                    ConditionInt = table.Column<int>(nullable: false),
                    ConditionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontProcessToDoIndex2GetForAndOr", x => x.ConditionId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "47b671e2-82eb-4642-991b-1cc4e165c498", "6114b66a-af4b-4133-8f2d-b8331a0ac89c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29bfe8fc-2a38-46ac-85c7-ba71233e298a", "86837f67-7a99-4956-8960-2566fa6c9863", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbFrontProcessToDoIndex2GetForAndOr");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bfe8fc-2a38-46ac-85c7-ba71233e298a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47b671e2-82eb-4642-991b-1cc4e165c498");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "DbComparison");

            migrationBuilder.RenameColumn(
                name: "ProcessTemplateFieldTypeId",
                table: "ZdbFrontProcessCreateGetField",
                newName: "MasterListId");

            migrationBuilder.AddColumn<int>(
                name: "DataTypeId",
                table: "ZdbFrontProcessCreateGetField",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ae1162e-72d2-4d9e-bf6c-54c015ad3206", "7affd8ce-8200-476c-84eb-0f507d9eebc5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68a83ec3-931e-41ed-851b-ef7aa85634a1", "6b814610-2a33-49a5-bd0e-fdd55442b2c2", "Super admin", "SUPER ADMIN" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class contentprocess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DbSecurityLevelList",
                table: "DbSecurityLevelList");

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

            migrationBuilder.RenameTable(
                name: "DbSecurityLevelList",
                newName: "ZDbSecurityLevelList");

            migrationBuilder.AddColumn<int>(
                name: "ContentTypeGroupId",
                table: "ZdbContentTypeEditGet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessTemplateId",
                table: "ZdbContentTypeEditGet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessTemplateId",
                table: "ZdbContentEditGetContent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZDbSecurityLevelList",
                table: "ZDbSecurityLevelList",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ZdbInt2",
                columns: table => new
                {
                    intValue = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbInt2", x => x.intValue);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf7c8713-77af-403b-afc7-694c232612df", "36ea5859-af31-4e2d-a2cb-9593cf68d0ff", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a35a1bbb-c96c-42e2-9f6a-7d69f28651c0", "e8d0421f-5b0e-4834-8c5f-bbd5946c7d7d", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbInt2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZDbSecurityLevelList",
                table: "ZDbSecurityLevelList");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a35a1bbb-c96c-42e2-9f6a-7d69f28651c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf7c8713-77af-403b-afc7-694c232612df");

            migrationBuilder.DropColumn(
                name: "ContentTypeGroupId",
                table: "ZdbContentTypeEditGet");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateId",
                table: "ZdbContentTypeEditGet");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateId",
                table: "ZdbContentEditGetContent");

            migrationBuilder.RenameTable(
                name: "ZDbSecurityLevelList",
                newName: "DbSecurityLevelList");

            migrationBuilder.AddColumn<int>(
                name: "ContentId",
                table: "DbProcess",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbSecurityLevelList",
                table: "DbSecurityLevelList",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85fd28aa-fef0-44d7-8d2d-20c36ae65d7f", "96b49926-1f04-496d-90e0-542b80c6e9da", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f596a56b-d27b-420f-9fd5-e35de671fbc3", "7a378ab9-f87b-4df1-a65d-92aa31796f1f", "Super admin", "SUPER ADMIN" });
        }
    }
}

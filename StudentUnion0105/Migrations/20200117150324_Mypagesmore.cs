using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class Mypagesmore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "772800cc-a32e-4bec-9753-8b13604d59fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d129c8eb-b71f-4856-a5a7-3d63f39cb2d6");

            migrationBuilder.RenameColumn(
                name: "RelatioName",
                table: "ZdbFrontProjectMyProjectGet",
                newName: "RelationName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ZdbFrontProjectMyProjectGet",
                newName: "ProjectName");

            migrationBuilder.CreateTable(
                name: "ZdbFrontOrganizationMyOrganizationGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationName = table.Column<string>(nullable: true),
                    UserOrganizationTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontOrganizationMyOrganizationGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontRelationMyRelationGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    RelationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontRelationMyRelationGet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a977936-2207-4aa5-ade3-200054bbb052", "8acce520-897a-406d-9ffc-b8ae28587a1c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "133f2c47-de8d-4926-a9dc-89dd523e1648", "0811253c-8591-4251-bd0c-6ade5e79e23c", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbFrontOrganizationMyOrganizationGet");

            migrationBuilder.DropTable(
                name: "ZdbFrontRelationMyRelationGet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "133f2c47-de8d-4926-a9dc-89dd523e1648");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a977936-2207-4aa5-ade3-200054bbb052");

            migrationBuilder.RenameColumn(
                name: "RelationName",
                table: "ZdbFrontProjectMyProjectGet",
                newName: "RelatioName");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "ZdbFrontProjectMyProjectGet",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "772800cc-a32e-4bec-9753-8b13604d59fe", "ee6e9136-9842-440c-abf5-53a875aa35b1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d129c8eb-b71f-4856-a5a7-3d63f39cb2d6", "aa402422-a861-4d6d-8fc7-f90c003b8974", "Super admin", "SUPER ADMIN" });
        }
    }
}

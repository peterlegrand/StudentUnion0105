using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class menulev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c852bcf-6d0b-4340-ba33-6873f95a9c6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc6c9db3-bd34-4a99-ad94-a7085d082779");

            migrationBuilder.CreateTable(
                name: "ZdbTopMenu2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuName = table.Column<string>(nullable: true),
                    MenuController = table.Column<string>(nullable: true),
                    MenuAction = table.Column<string>(nullable: true),
                    MenuDestinationId = table.Column<int>(nullable: false),
                    IconCss = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbTopMenu2", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9e0004a5-2548-4287-9496-6376ac0f5a38", "37e1bd89-36c3-413b-bcef-9f906af6f16c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b15006a0-d8f6-4a2b-b6c6-bc91206beccf", "4e5bffe6-e01f-4a00-a7a4-624f176eff93", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbTopMenu2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0004a5-2548-4287-9496-6376ac0f5a38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b15006a0-d8f6-4a2b-b6c6-bc91206beccf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c852bcf-6d0b-4340-ba33-6873f95a9c6c", "e1b73e2d-fb48-4d29-8b35-2410f1dfb1ff", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc6c9db3-bd34-4a99-ad94-a7085d082779", "a9a83345-ef25-416b-9eb9-042b81fb0487", "Super admin", "SUPER ADMIN" });
        }
    }
}

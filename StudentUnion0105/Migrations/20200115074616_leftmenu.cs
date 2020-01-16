using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class leftmenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d712003-387c-4772-a41b-7c4d9c69340d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df4cf4c2-e081-4d16-860d-c83e4af15e40");

            migrationBuilder.DropColumn(
                name: "NoOfClassifications",
                table: "ZdbMenu2");

            migrationBuilder.DropColumn(
                name: "NoOfMenus3",
                table: "ZdbMenu2");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "ZdbMenu1");

            migrationBuilder.DropColumn(
                name: "ClassificationId",
                table: "ZdbMenu1");

            migrationBuilder.DropColumn(
                name: "Controller",
                table: "ZdbMenu1");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "ZdbMenu1");

            migrationBuilder.DropColumn(
                name: "MenuTypeId",
                table: "ZdbMenu1");

            migrationBuilder.DropColumn(
                name: "NoOfClassifications",
                table: "ZdbMenu1");

            migrationBuilder.DropColumn(
                name: "NoOfMenus2",
                table: "ZdbMenu1");

            migrationBuilder.RenameColumn(
                name: "MenuType",
                table: "ZdbMenu3",
                newName: "DestinationURL");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ZdbMenu3",
                newName: "OId");

            migrationBuilder.RenameColumn(
                name: "MenuType",
                table: "ZdbMenu2",
                newName: "DestinationURL");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ZdbMenu2",
                newName: "OId");

            migrationBuilder.RenameColumn(
                name: "MouseOver",
                table: "ZdbMenu1",
                newName: "DestinationURL");

            migrationBuilder.AddColumn<int>(
                name: "PPId",
                table: "ZdbMenu3",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "dbLeftMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuName = table.Column<string>(nullable: true),
                    MenuURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbLeftMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbLeftMenuLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeftMenuId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbLeftMenuLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbLeftMenuUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeftMenuId = table.Column<int>(nullable: false),
                    MenuShow = table.Column<bool>(nullable: false),
                    MenuAddShow = table.Column<bool>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MenuURL = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbLeftMenuUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5edaa5b-de5b-47c4-9a50-8dba7455709f", "9d7a850a-7ca0-4257-9419-883a94e64057", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2bfaaa80-e979-4ea1-b17f-0947d1c31140", "d536b486-a555-4b14-b711-66dd3fda6ce9", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_ZdbMenu3_PId",
                table: "ZdbMenu3",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdbMenu2_PId",
                table: "ZdbMenu2",
                column: "PId");

            migrationBuilder.AddForeignKey(
                name: "FK_ZdbMenu2_ZdbMenu1_PId",
                table: "ZdbMenu2",
                column: "PId",
                principalTable: "ZdbMenu1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZdbMenu3_ZdbMenu2_PId",
                table: "ZdbMenu3",
                column: "PId",
                principalTable: "ZdbMenu2",
                principalColumn: "OId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZdbMenu2_ZdbMenu1_PId",
                table: "ZdbMenu2");

            migrationBuilder.DropForeignKey(
                name: "FK_ZdbMenu3_ZdbMenu2_PId",
                table: "ZdbMenu3");

            migrationBuilder.DropTable(
                name: "dbLeftMenu");

            migrationBuilder.DropTable(
                name: "dbLeftMenuLanguage");

            migrationBuilder.DropTable(
                name: "dbLeftMenuUser");

            migrationBuilder.DropIndex(
                name: "IX_ZdbMenu3_PId",
                table: "ZdbMenu3");

            migrationBuilder.DropIndex(
                name: "IX_ZdbMenu2_PId",
                table: "ZdbMenu2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bfaaa80-e979-4ea1-b17f-0947d1c31140");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5edaa5b-de5b-47c4-9a50-8dba7455709f");

            migrationBuilder.DropColumn(
                name: "PPId",
                table: "ZdbMenu3");

            migrationBuilder.RenameColumn(
                name: "DestinationURL",
                table: "ZdbMenu3",
                newName: "MenuType");

            migrationBuilder.RenameColumn(
                name: "OId",
                table: "ZdbMenu3",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DestinationURL",
                table: "ZdbMenu2",
                newName: "MenuType");

            migrationBuilder.RenameColumn(
                name: "OId",
                table: "ZdbMenu2",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DestinationURL",
                table: "ZdbMenu1",
                newName: "MouseOver");

            migrationBuilder.AddColumn<int>(
                name: "NoOfClassifications",
                table: "ZdbMenu2",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoOfMenus3",
                table: "ZdbMenu2",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "ZdbMenu1",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassificationId",
                table: "ZdbMenu1",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Controller",
                table: "ZdbMenu1",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "ZdbMenu1",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuTypeId",
                table: "ZdbMenu1",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoOfClassifications",
                table: "ZdbMenu1",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoOfMenus2",
                table: "ZdbMenu1",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df4cf4c2-e081-4d16-860d-c83e4af15e40", "8559372a-2b78-4f3c-9422-5b5ba45f8d63", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d712003-387c-4772-a41b-7c4d9c69340d", "2188120a-f5b4-4794-952a-2c1911b625bf", "Super admin", "SUPER ADMIN" });
        }
    }
}

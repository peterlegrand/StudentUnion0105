using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class userstuff5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3797bf3-05a8-4373-9d12-618ce387a3ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e89299cf-0126-4323-a4c0-271d70ace4ab");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "dbUserRelationTypeLanguage",
                newName: "ToIsOfFromName");

            migrationBuilder.RenameColumn(
                name: "MouseOver",
                table: "dbUserRelationTypeLanguage",
                newName: "ToIsOfFromMouseOver");

            migrationBuilder.RenameColumn(
                name: "MenuName",
                table: "dbUserRelationTypeLanguage",
                newName: "ToIsOfFromMenuName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "dbUserRelationTypeLanguage",
                newName: "ToIsOfFromDescription");

            migrationBuilder.AddColumn<string>(
                name: "FromIsOfToDescription",
                table: "dbUserRelationTypeLanguage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromIsOfToMenuName",
                table: "dbUserRelationTypeLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromIsOfToMouseOver",
                table: "dbUserRelationTypeLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromIsOfToName",
                table: "dbUserRelationTypeLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8fce28fc-392b-452a-91de-e4406f14153f", "21454962-820b-4c37-82cb-9605bcc6ba80", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3178f384-2d13-45d8-a1a7-99cd4ee51f22", "fdb531f1-fd90-4bc6-bda2-c85f48d52eba", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3178f384-2d13-45d8-a1a7-99cd4ee51f22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fce28fc-392b-452a-91de-e4406f14153f");

            migrationBuilder.DropColumn(
                name: "FromIsOfToDescription",
                table: "dbUserRelationTypeLanguage");

            migrationBuilder.DropColumn(
                name: "FromIsOfToMenuName",
                table: "dbUserRelationTypeLanguage");

            migrationBuilder.DropColumn(
                name: "FromIsOfToMouseOver",
                table: "dbUserRelationTypeLanguage");

            migrationBuilder.DropColumn(
                name: "FromIsOfToName",
                table: "dbUserRelationTypeLanguage");

            migrationBuilder.RenameColumn(
                name: "ToIsOfFromName",
                table: "dbUserRelationTypeLanguage",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ToIsOfFromMouseOver",
                table: "dbUserRelationTypeLanguage",
                newName: "MouseOver");

            migrationBuilder.RenameColumn(
                name: "ToIsOfFromMenuName",
                table: "dbUserRelationTypeLanguage",
                newName: "MenuName");

            migrationBuilder.RenameColumn(
                name: "ToIsOfFromDescription",
                table: "dbUserRelationTypeLanguage",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3797bf3-05a8-4373-9d12-618ce387a3ae", "be9682f4-00bf-4fb0-b672-68912237942d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e89299cf-0126-4323-a4c0-271d70ace4ab", "19da4287-1803-4186-9df3-4844789a728c", "Super admin", "SUPER ADMIN" });
        }
    }
}

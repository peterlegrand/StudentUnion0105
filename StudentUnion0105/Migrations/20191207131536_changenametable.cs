using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class changenametable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ffed300-8687-4b65-a065-9e37c54b790e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7e15690-1857-48ab-9674-eb05cf794469");

            migrationBuilder.DropColumn(
                name: "ShowClassificationTitleDescriptipn",
                table: "DbClassificationPage");

            migrationBuilder.RenameColumn(
                name: "ShowTitleDescription",
                table: "DbClassificationPage",
                newName: "ShowClassificationTitleDescription");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c89dcf6a-ad2f-4c3f-aae9-b85ea5293cac", "b96b38d9-1a61-415f-a5b2-4c57f9d40f1b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "736e1327-3b11-4b3b-8b5a-d87d35b64df8", "1057481f-8391-4009-a9f4-0165a06fea3a", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "736e1327-3b11-4b3b-8b5a-d87d35b64df8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c89dcf6a-ad2f-4c3f-aae9-b85ea5293cac");

            migrationBuilder.RenameColumn(
                name: "ShowClassificationTitleDescription",
                table: "DbClassificationPage",
                newName: "ShowTitleDescription");

            migrationBuilder.AddColumn<bool>(
                name: "ShowClassificationTitleDescriptipn",
                table: "DbClassificationPage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7e15690-1857-48ab-9674-eb05cf794469", "d3323cdf-dbe2-4100-a7a9-0b9b67d0c234", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ffed300-8687-4b65-a065-9e37c54b790e", "9cb2bb5f-eec2-4a9c-8fd5-3cb500a958d0", "Super admin", "SUPER ADMIN" });
        }
    }
}

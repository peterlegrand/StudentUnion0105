using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class sequenceofieldperstep4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d85ba88d-8dd0-4ea3-b058-84e882cf3603");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddc47d7a-49cd-4df8-a616-68abbca98750");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70e8ecb7-e565-489b-b84a-a7064d93aa3b", "8cd1c187-fbad-4dd5-af6b-dbfbd48b958e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3e0ee35-fbf5-4c91-a155-15e9f231fe3c", "33731e85-686b-4b7e-ac09-9c1058c1a867", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70e8ecb7-e565-489b-b84a-a7064d93aa3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3e0ee35-fbf5-4c91-a155-15e9f231fe3c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ddc47d7a-49cd-4df8-a616-68abbca98750", "c1383b73-51f2-4c6c-b21a-7071ce83224d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d85ba88d-8dd0-4ea3-b058-84e882cf3603", "b3855ac3-5c11-4824-a49d-66eb1db649d7", "Super admin", "SUPER ADMIN" });
        }
    }
}

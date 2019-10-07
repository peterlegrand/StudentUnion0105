using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class extra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ac0b2f-518c-4f72-be6b-8c24ea7209d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c79f82dd-9573-4149-9383-9e8712da7a6a");

            migrationBuilder.AddColumn<string>(
                name: "ConditionRelation",
                table: "dbProcessTemplateFlow",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1eed3044-3ab1-41b1-92c7-d1069d1b7ab0", "8123f92e-c0d1-434f-9d58-d447df230e6b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "122785d8-5c84-4c11-b5de-0281d8b38bca", "99d17113-a069-45f5-b66d-f0e873895e56", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "122785d8-5c84-4c11-b5de-0281d8b38bca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1eed3044-3ab1-41b1-92c7-d1069d1b7ab0");

            migrationBuilder.DropColumn(
                name: "ConditionRelation",
                table: "dbProcessTemplateFlow");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88ac0b2f-518c-4f72-be6b-8c24ea7209d5", "cbf322a8-8189-44f4-93e9-ff7c116e8ac0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c79f82dd-9573-4149-9383-9e8712da7a6a", "3911d3a0-7e6b-4332-8841-f5c369510a36", "Super admin", "SUPER ADMIN" });
        }
    }
}

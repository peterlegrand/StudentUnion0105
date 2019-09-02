using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class parentorg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba132183-517c-4b70-a13b-9e99301b4963");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c74d33b0-ccdd-4f71-bef8-be4d4329c0dc");

            migrationBuilder.AlterColumn<int>(
                name: "ParentOrganizationId",
                table: "dbOrganization",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ddb5fe66-c24b-467d-9dac-77c5afd38788", "873abf51-214a-458c-b1a6-db57de8c99ae", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultLangauge", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "be13a95b-f246-4758-8ca4-36e45d35457e", 0, "4de67c56-4ce0-4c69-8e1d-ac3e03b134ac", 41, "eplegrand@gmail.com", false, false, null, null, "EPLEGRAND@GMAIL.COM", "AQAAAAEAACcQAAAAENz3TKYdkSJi2eMWVeD3pglKKn//AllniYlKqPYFvar4NYg6l6QBeLCeLhGuBRL4VQ==", null, false, null, false, "eplegrand@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_dbOrganization_ParentOrganizationId",
                table: "dbOrganization",
                column: "ParentOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbOrganization_dbOrganization_ParentOrganizationId",
                table: "dbOrganization",
                column: "ParentOrganizationId",
                principalTable: "dbOrganization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbOrganization_dbOrganization_ParentOrganizationId",
                table: "dbOrganization");

            migrationBuilder.DropIndex(
                name: "IX_dbOrganization_ParentOrganizationId",
                table: "dbOrganization");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddb5fe66-c24b-467d-9dac-77c5afd38788");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be13a95b-f246-4758-8ca4-36e45d35457e");

            migrationBuilder.AlterColumn<int>(
                name: "ParentOrganizationId",
                table: "dbOrganization",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba132183-517c-4b70-a13b-9e99301b4963", "22160578-5d22-4a1d-8911-c8544ae53ee0", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultLangauge", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c74d33b0-ccdd-4f71-bef8-be4d4329c0dc", 0, "bc2190d4-e2c2-489d-aeb6-a7041d9b3c95", 41, "eplegrand@gmail.com", false, false, null, null, "EPLEGRAND@GMAIL.COM", "AQAAAAEAACcQAAAAENz3TKYdkSJi2eMWVeD3pglKKn//AllniYlKqPYFvar4NYg6l6QBeLCeLhGuBRL4VQ==", null, false, null, false, "eplegrand@gmail.com" });
        }
    }
}

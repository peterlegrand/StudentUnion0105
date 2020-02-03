using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class contenttypegroup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ab6e6b9-d881-415d-b079-df9cb43a0f30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "543b5e64-2d39-4667-a061-5a4ff5e3bc11");

            migrationBuilder.AddColumn<int>(
                name: "ContentTypeGroupId",
                table: "dbContentTypeClassificationStatusLanguage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5cf3a25-a422-4371-9bd1-661346c19700", "35be7d7c-0400-45d9-aed5-a9eda5652b0e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "50ec2bdd-72d4-4efc-85ba-ccc12af4bf3b", "a2ee17c3-620a-4226-b053-4e7d86561a0e", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeClassificationStatusLanguage_ContentTypeGroupId",
                table: "dbContentTypeClassificationStatusLanguage",
                column: "ContentTypeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbContentTypeClassificationStatusLanguage_DbContentTypeGroup_ContentTypeGroupId",
                table: "dbContentTypeClassificationStatusLanguage",
                column: "ContentTypeGroupId",
                principalTable: "DbContentTypeGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbContentTypeClassificationStatusLanguage_DbContentTypeGroup_ContentTypeGroupId",
                table: "dbContentTypeClassificationStatusLanguage");

            migrationBuilder.DropIndex(
                name: "IX_dbContentTypeClassificationStatusLanguage_ContentTypeGroupId",
                table: "dbContentTypeClassificationStatusLanguage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50ec2bdd-72d4-4efc-85ba-ccc12af4bf3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5cf3a25-a422-4371-9bd1-661346c19700");

            migrationBuilder.DropColumn(
                name: "ContentTypeGroupId",
                table: "dbContentTypeClassificationStatusLanguage");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ab6e6b9-d881-415d-b079-df9cb43a0f30", "52b9c656-f9c6-4a61-a1fe-a15bfbc58109", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "543b5e64-2d39-4667-a061-5a4ff5e3bc11", "a21f1a3a-d0e4-4518-86cf-079890e0a74b", "Super admin", "SUPER ADMIN" });
        }
    }
}

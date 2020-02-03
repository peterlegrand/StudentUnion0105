using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class contenttypegroup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbContentType_DbContentTypeGroup_SuContentTypeGroupModelId",
                table: "DbContentType");

            migrationBuilder.DropForeignKey(
                name: "FK_dbContentTypeClassificationStatusLanguage_DbContentTypeGroup_ContentTypeGroupId",
                table: "dbContentTypeClassificationStatusLanguage");

            migrationBuilder.DropIndex(
                name: "IX_dbContentTypeClassificationStatusLanguage_ContentTypeGroupId",
                table: "dbContentTypeClassificationStatusLanguage");

            migrationBuilder.DropIndex(
                name: "IX_DbContentType_SuContentTypeGroupModelId",
                table: "DbContentType");

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

            migrationBuilder.DropColumn(
                name: "SuContentTypeGroupModelId",
                table: "DbContentType");

            migrationBuilder.AddColumn<int>(
                name: "ContentTypeGroupId",
                table: "DbContentType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "515cee09-4337-45ad-bad9-a6d1dd23f5ac", "8fdd4228-1d34-4105-a0c8-cedb10ca51f5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4da81dd9-8df2-4121-9f85-1991770bb8a8", "b27281df-6035-4fbd-8aa2-d691296805b3", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_DbContentType_ContentTypeGroupId",
                table: "DbContentType",
                column: "ContentTypeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbContentType_DbContentTypeGroup_ContentTypeGroupId",
                table: "DbContentType",
                column: "ContentTypeGroupId",
                principalTable: "DbContentTypeGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbContentType_DbContentTypeGroup_ContentTypeGroupId",
                table: "DbContentType");

            migrationBuilder.DropIndex(
                name: "IX_DbContentType_ContentTypeGroupId",
                table: "DbContentType");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4da81dd9-8df2-4121-9f85-1991770bb8a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "515cee09-4337-45ad-bad9-a6d1dd23f5ac");

            migrationBuilder.DropColumn(
                name: "ContentTypeGroupId",
                table: "DbContentType");

            migrationBuilder.AddColumn<int>(
                name: "ContentTypeGroupId",
                table: "dbContentTypeClassificationStatusLanguage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SuContentTypeGroupModelId",
                table: "DbContentType",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_DbContentType_SuContentTypeGroupModelId",
                table: "DbContentType",
                column: "SuContentTypeGroupModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbContentType_DbContentTypeGroup_SuContentTypeGroupModelId",
                table: "DbContentType",
                column: "SuContentTypeGroupModelId",
                principalTable: "DbContentTypeGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbContentTypeClassificationStatusLanguage_DbContentTypeGroup_ContentTypeGroupId",
                table: "dbContentTypeClassificationStatusLanguage",
                column: "ContentTypeGroupId",
                principalTable: "DbContentTypeGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

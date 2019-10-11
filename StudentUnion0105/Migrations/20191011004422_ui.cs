using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class ui : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbTermLanguage_dbLanguage_LanguageId",
                table: "dbTermLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbTermLanguage_dbTerm_TermId",
                table: "dbTermLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbTermScreen_dbScreen_ScreenId",
                table: "dbTermScreen");

            migrationBuilder.DropForeignKey(
                name: "FK_dbTermScreen_dbTerm_TermId",
                table: "dbTermScreen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbTermScreen",
                table: "dbTermScreen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbTermLanguage",
                table: "dbTermLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbTerm",
                table: "dbTerm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbScreen",
                table: "dbScreen");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37624060-f541-4b91-b600-bf60ab3223b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea7c34d-b863-4114-86ad-00daa006f480");

            migrationBuilder.RenameTable(
                name: "dbTermScreen",
                newName: "dbUITermScreen");

            migrationBuilder.RenameTable(
                name: "dbTermLanguage",
                newName: "dbUITermLanguage");

            migrationBuilder.RenameTable(
                name: "dbTerm",
                newName: "dbUITerm");

            migrationBuilder.RenameTable(
                name: "dbScreen",
                newName: "dbUIScreen");

            migrationBuilder.RenameIndex(
                name: "IX_dbTermScreen_TermId",
                table: "dbUITermScreen",
                newName: "IX_dbUITermScreen_TermId");

            migrationBuilder.RenameIndex(
                name: "IX_dbTermScreen_ScreenId",
                table: "dbUITermScreen",
                newName: "IX_dbUITermScreen_ScreenId");

            migrationBuilder.RenameIndex(
                name: "IX_dbTermLanguage_TermId",
                table: "dbUITermLanguage",
                newName: "IX_dbUITermLanguage_TermId");

            migrationBuilder.RenameIndex(
                name: "IX_dbTermLanguage_LanguageId",
                table: "dbUITermLanguage",
                newName: "IX_dbUITermLanguage_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbUITermScreen",
                table: "dbUITermScreen",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbUITermLanguage",
                table: "dbUITermLanguage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbUITerm",
                table: "dbUITerm",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbUIScreen",
                table: "dbUIScreen",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8e9cd2b-caa8-4887-9b06-e66e5939fe56", "9c416bc1-8eb0-40d6-8cc4-ec063cc5dba7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd8316ea-7da8-412a-9508-7155e203be69", "3f1cf129-fca3-4335-bb58-2d94020ed112", "Super admin", "SUPER ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_dbUITermLanguage_dbLanguage_LanguageId",
                table: "dbUITermLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbUITermLanguage_dbUITerm_TermId",
                table: "dbUITermLanguage",
                column: "TermId",
                principalTable: "dbUITerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbUITermScreen_dbUIScreen_ScreenId",
                table: "dbUITermScreen",
                column: "ScreenId",
                principalTable: "dbUIScreen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbUITermScreen_dbUITerm_TermId",
                table: "dbUITermScreen",
                column: "TermId",
                principalTable: "dbUITerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbUITermLanguage_dbLanguage_LanguageId",
                table: "dbUITermLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbUITermLanguage_dbUITerm_TermId",
                table: "dbUITermLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbUITermScreen_dbUIScreen_ScreenId",
                table: "dbUITermScreen");

            migrationBuilder.DropForeignKey(
                name: "FK_dbUITermScreen_dbUITerm_TermId",
                table: "dbUITermScreen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbUITermScreen",
                table: "dbUITermScreen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbUITermLanguage",
                table: "dbUITermLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbUITerm",
                table: "dbUITerm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbUIScreen",
                table: "dbUIScreen");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8e9cd2b-caa8-4887-9b06-e66e5939fe56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd8316ea-7da8-412a-9508-7155e203be69");

            migrationBuilder.RenameTable(
                name: "dbUITermScreen",
                newName: "dbTermScreen");

            migrationBuilder.RenameTable(
                name: "dbUITermLanguage",
                newName: "dbTermLanguage");

            migrationBuilder.RenameTable(
                name: "dbUITerm",
                newName: "dbTerm");

            migrationBuilder.RenameTable(
                name: "dbUIScreen",
                newName: "dbScreen");

            migrationBuilder.RenameIndex(
                name: "IX_dbUITermScreen_TermId",
                table: "dbTermScreen",
                newName: "IX_dbTermScreen_TermId");

            migrationBuilder.RenameIndex(
                name: "IX_dbUITermScreen_ScreenId",
                table: "dbTermScreen",
                newName: "IX_dbTermScreen_ScreenId");

            migrationBuilder.RenameIndex(
                name: "IX_dbUITermLanguage_TermId",
                table: "dbTermLanguage",
                newName: "IX_dbTermLanguage_TermId");

            migrationBuilder.RenameIndex(
                name: "IX_dbUITermLanguage_LanguageId",
                table: "dbTermLanguage",
                newName: "IX_dbTermLanguage_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbTermScreen",
                table: "dbTermScreen",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbTermLanguage",
                table: "dbTermLanguage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbTerm",
                table: "dbTerm",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbScreen",
                table: "dbScreen",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dea7c34d-b863-4114-86ad-00daa006f480", "bf03105d-4558-4135-8240-f66104f899b3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37624060-f541-4b91-b600-bf60ab3223b0", "87d5f39e-1e85-4e20-9938-27bdc2200b38", "Super admin", "SUPER ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_dbTermLanguage_dbLanguage_LanguageId",
                table: "dbTermLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbTermLanguage_dbTerm_TermId",
                table: "dbTermLanguage",
                column: "TermId",
                principalTable: "dbTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbTermScreen_dbScreen_ScreenId",
                table: "dbTermScreen",
                column: "ScreenId",
                principalTable: "dbScreen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbTermScreen_dbTerm_TermId",
                table: "dbTermScreen",
                column: "TermId",
                principalTable: "dbTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

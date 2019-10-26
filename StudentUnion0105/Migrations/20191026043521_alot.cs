using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class alot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateGroupLanguage_dbProcessTemplateGroup_SuProcessTemplateGroupModelId",
                table: "dbProcessTemplateGroupLanguage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ad10056-5422-4229-82de-f018b5c34217");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff02fc31-573b-4f0b-8586-042fc2df5a82");

            migrationBuilder.RenameColumn(
                name: "SuProcessTemplateGroupModelId",
                table: "dbProcessTemplateGroupLanguage",
                newName: "FlowId");

            migrationBuilder.RenameIndex(
                name: "IX_dbProcessTemplateGroupLanguage_SuProcessTemplateGroupModelId",
                table: "dbProcessTemplateGroupLanguage",
                newName: "IX_dbProcessTemplateGroupLanguage_FlowId");

            migrationBuilder.CreateTable(
                name: "dbContentTypeDeleteGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbContentTypeDeleteGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbObjectLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbObjectLanguage", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72265118-b768-421b-aa15-a0675ff95cfb", "802a5f3d-48c3-41aa-bcca-bc9b76458472", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bab266c-757c-4568-8120-0f138be3096f", "62484318-c36d-4afd-91ca-d6efa12b4177", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateGroupLanguage_LanguageId",
                table: "dbProcessTemplateGroupLanguage",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateGroupLanguage_dbProcessTemplateGroup_FlowId",
                table: "dbProcessTemplateGroupLanguage",
                column: "FlowId",
                principalTable: "dbProcessTemplateGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateGroupLanguage_dbLanguage_LanguageId",
                table: "dbProcessTemplateGroupLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateGroupLanguage_dbProcessTemplateGroup_FlowId",
                table: "dbProcessTemplateGroupLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbProcessTemplateGroupLanguage_dbLanguage_LanguageId",
                table: "dbProcessTemplateGroupLanguage");

            migrationBuilder.DropTable(
                name: "dbContentTypeDeleteGet");

            migrationBuilder.DropTable(
                name: "dbObjectLanguage");

            migrationBuilder.DropIndex(
                name: "IX_dbProcessTemplateGroupLanguage_LanguageId",
                table: "dbProcessTemplateGroupLanguage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72265118-b768-421b-aa15-a0675ff95cfb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bab266c-757c-4568-8120-0f138be3096f");

            migrationBuilder.RenameColumn(
                name: "FlowId",
                table: "dbProcessTemplateGroupLanguage",
                newName: "SuProcessTemplateGroupModelId");

            migrationBuilder.RenameIndex(
                name: "IX_dbProcessTemplateGroupLanguage_FlowId",
                table: "dbProcessTemplateGroupLanguage",
                newName: "IX_dbProcessTemplateGroupLanguage_SuProcessTemplateGroupModelId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff02fc31-573b-4f0b-8586-042fc2df5a82", "99457f21-edca-42e6-aadb-b3789143e437", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ad10056-5422-4229-82de-f018b5c34217", "a1491015-565b-4aa0-bc6a-30c7d87d5cb0", "Super admin", "SUPER ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_dbProcessTemplateGroupLanguage_dbProcessTemplateGroup_SuProcessTemplateGroupModelId",
                table: "dbProcessTemplateGroupLanguage",
                column: "SuProcessTemplateGroupModelId",
                principalTable: "dbProcessTemplateGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

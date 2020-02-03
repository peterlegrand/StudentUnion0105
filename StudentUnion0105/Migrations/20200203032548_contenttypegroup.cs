using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class contenttypegroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbProcessTemplateGroupLanguage_DbProcessTemplateGroup_FlowId",
                table: "DbProcessTemplateGroupLanguage");

            migrationBuilder.DropIndex(
                name: "IX_DbProcessTemplateGroupLanguage_FlowId",
                table: "DbProcessTemplateGroupLanguage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b3dfb0b-be88-42ce-87df-483fae8fb634");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f046b5f7-97dc-4c92-b0a9-deacb6e37725");

            migrationBuilder.DropColumn(
                name: "FlowId",
                table: "DbProcessTemplateGroupLanguage");

            migrationBuilder.AddColumn<int>(
                name: "SuContentTypeGroupModelId",
                table: "DbContentType",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DbContentTypeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sequence = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbContentTypeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbContentTypeGroupEditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbContentTypeGroupEditGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbContentTypeGroupLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeGroupId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbContentTypeGroupLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbContentTypeGroupLanguage_DbContentTypeGroup_ContentTypeGroupId",
                        column: x => x.ContentTypeGroupId,
                        principalTable: "DbContentTypeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbContentTypeGroupLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ab6e6b9-d881-415d-b079-df9cb43a0f30", "52b9c656-f9c6-4a61-a1fe-a15bfbc58109", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "543b5e64-2d39-4667-a061-5a4ff5e3bc11", "a21f1a3a-d0e4-4518-86cf-079890e0a74b", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateGroupLanguage_ProcessTemplateGroupId",
                table: "DbProcessTemplateGroupLanguage",
                column: "ProcessTemplateGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContentType_SuContentTypeGroupModelId",
                table: "DbContentType",
                column: "SuContentTypeGroupModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContentTypeGroupLanguage_ContentTypeGroupId",
                table: "DbContentTypeGroupLanguage",
                column: "ContentTypeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContentTypeGroupLanguage_LanguageId",
                table: "DbContentTypeGroupLanguage",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbContentType_DbContentTypeGroup_SuContentTypeGroupModelId",
                table: "DbContentType",
                column: "SuContentTypeGroupModelId",
                principalTable: "DbContentTypeGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DbProcessTemplateGroupLanguage_DbProcessTemplateGroup_ProcessTemplateGroupId",
                table: "DbProcessTemplateGroupLanguage",
                column: "ProcessTemplateGroupId",
                principalTable: "DbProcessTemplateGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbContentType_DbContentTypeGroup_SuContentTypeGroupModelId",
                table: "DbContentType");

            migrationBuilder.DropForeignKey(
                name: "FK_DbProcessTemplateGroupLanguage_DbProcessTemplateGroup_ProcessTemplateGroupId",
                table: "DbProcessTemplateGroupLanguage");

            migrationBuilder.DropTable(
                name: "DbContentTypeGroupLanguage");

            migrationBuilder.DropTable(
                name: "ZdbContentTypeGroupEditGet");

            migrationBuilder.DropTable(
                name: "DbContentTypeGroup");

            migrationBuilder.DropIndex(
                name: "IX_DbProcessTemplateGroupLanguage_ProcessTemplateGroupId",
                table: "DbProcessTemplateGroupLanguage");

            migrationBuilder.DropIndex(
                name: "IX_DbContentType_SuContentTypeGroupModelId",
                table: "DbContentType");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ab6e6b9-d881-415d-b079-df9cb43a0f30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "543b5e64-2d39-4667-a061-5a4ff5e3bc11");

            migrationBuilder.DropColumn(
                name: "SuContentTypeGroupModelId",
                table: "DbContentType");

            migrationBuilder.AddColumn<int>(
                name: "FlowId",
                table: "DbProcessTemplateGroupLanguage",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b3dfb0b-be88-42ce-87df-483fae8fb634", "f1dd3c1e-a94c-46ad-a078-e66e9d2e1c50", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f046b5f7-97dc-4c92-b0a9-deacb6e37725", "5cf96365-60c1-4238-91e7-8c9379798f84", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateGroupLanguage_FlowId",
                table: "DbProcessTemplateGroupLanguage",
                column: "FlowId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbProcessTemplateGroupLanguage_DbProcessTemplateGroup_FlowId",
                table: "DbProcessTemplateGroupLanguage",
                column: "FlowId",
                principalTable: "DbProcessTemplateGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

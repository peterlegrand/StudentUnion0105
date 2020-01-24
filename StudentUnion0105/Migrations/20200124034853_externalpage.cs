using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class externalpage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0004a5-2548-4287-9496-6376ac0f5a38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b15006a0-d8f6-4a2b-b6c6-bc91206beccf");

            migrationBuilder.AddColumn<int>(
                name: "Menu1MenuTypeId",
                table: "ZdbTopMenu2",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Menu2MenuTypeId",
                table: "ZdbTopMenu2",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ZdbExternalPage",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShowTitleName = table.Column<bool>(nullable: false),
                    ShowTitleDescription = table.Column<bool>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbExternalPage", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbExternalPageMyContentGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    StatusName = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbExternalPageMyContentGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbExternalPageViewGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SecurityLevel = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    StatusName = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbExternalPageViewGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbExternalPageSection",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    OneTwoColumns = table.Column<int>(nullable: false),
                    ShowSectionTitleName = table.Column<bool>(nullable: false),
                    ShowSectionTitleDescription = table.Column<bool>(nullable: false),
                    ShowContentTypeTitle = table.Column<bool>(nullable: false),
                    ShowContentTypeDescription = table.Column<bool>(nullable: false),
                    ContentTitleName = table.Column<string>(nullable: true),
                    ContentTitleDescription = table.Column<string>(nullable: true),
                    MaxContent = table.Column<int>(nullable: false),
                    HasPaging = table.Column<bool>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbExternalPageSection", x => x.OId);
                    table.ForeignKey(
                        name: "FK_ZdbExternalPageSection_ZdbExternalPage_PId",
                        column: x => x.PId,
                        principalTable: "ZdbExternalPage",
                        principalColumn: "OId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZdbExternalContent",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbExternalContent", x => x.OId);
                    table.ForeignKey(
                        name: "FK_ZdbExternalContent_ZdbExternalPageSection_PId",
                        column: x => x.PId,
                        principalTable: "ZdbExternalPageSection",
                        principalColumn: "OId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6445118a-2448-4b03-bcdb-6aaa36ac2f24", "07a092ae-f975-4fbb-b23b-26bc3199336b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1a12221-103b-4216-bb17-ba7b8295424d", "d337ed26-79d9-4d14-a286-2bb972686083", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_ZdbExternalContent_PId",
                table: "ZdbExternalContent",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdbExternalPageSection_PId",
                table: "ZdbExternalPageSection",
                column: "PId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbExternalContent");

            migrationBuilder.DropTable(
                name: "ZdbExternalPageMyContentGet");

            migrationBuilder.DropTable(
                name: "ZdbExternalPageViewGet");

            migrationBuilder.DropTable(
                name: "ZdbExternalPageSection");

            migrationBuilder.DropTable(
                name: "ZdbExternalPage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6445118a-2448-4b03-bcdb-6aaa36ac2f24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1a12221-103b-4216-bb17-ba7b8295424d");

            migrationBuilder.DropColumn(
                name: "Menu1MenuTypeId",
                table: "ZdbTopMenu2");

            migrationBuilder.DropColumn(
                name: "Menu2MenuTypeId",
                table: "ZdbTopMenu2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9e0004a5-2548-4287-9496-6376ac0f5a38", "37e1bd89-36c3-413b-bcef-9f906af6f16c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b15006a0-d8f6-4a2b-b6c6-bc91206beccf", "4e5bffe6-e01f-4a00-a7a4-624f176eff93", "Super admin", "SUPER ADMIN" });
        }
    }
}

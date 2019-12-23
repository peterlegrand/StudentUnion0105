using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class fieldtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99f78a9e-2579-44cc-b0df-326b60e0053c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab888578-a519-48da-a58f-add9e29cdad3");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DbProcessTemplateFieldType");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "DbProcessTemplateFieldType");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "DbProcessTemplateFieldType");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "DbProcessTemplateFieldType");

            migrationBuilder.AddColumn<string>(
                name: "TitleDescription",
                table: "ZdbContentTypeEditGet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleName",
                table: "ZdbContentTypeEditGet",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ZdbOrganizationEditGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentOrganization = table.Column<string>(nullable: true),
                    OrganizationStatusId = table.Column<int>(nullable: false),
                    OrganizationTypeId = table.Column<int>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbOrganizationEditGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbOrganizationTypeEditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbOrganizationTypeEditGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbPageSectionEditGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeId = table.Column<int>(nullable: false),
                    HasPaging = table.Column<bool>(nullable: false),
                    MaxContent = table.Column<int>(nullable: false),
                    OneTwoColumns = table.Column<int>(nullable: false),
                    PageSectionTypeId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    ShowContentTypeTitle = table.Column<bool>(nullable: false),
                    ShowContentTypeDescription = table.Column<bool>(nullable: false),
                    ShowSectionTitleName = table.Column<bool>(nullable: false),
                    ShowSectionTitleDescription = table.Column<bool>(nullable: false),
                    SortById = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    titleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbPageSectionEditGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbPageSectionTypeEditGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    IndexSection = table.Column<bool>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbPageSectionTypeEditGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbPageTypeEditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbPageTypeEditGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbSuFrontProcessTodoEditGet",
                columns: table => new
                {
                    PTFId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    FId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    StringValue = table.Column<string>(nullable: true),
                    IntValue = table.Column<int>(nullable: false),
                    DateTimeValue = table.Column<DateTime>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    FieldDataTypeId = table.Column<int>(nullable: false),
                    FieldMasterListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbSuFrontProcessTodoEditGet", x => x.PTFId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbSuFrontProcessTodoIndexGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbSuFrontProcessTodoIndexGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbUserRelationTypeIndexGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromIsOfToName = table.Column<string>(nullable: true),
                    ToIsOfFromName = table.Column<string>(nullable: true),
                    FromIsOfToDescription = table.Column<string>(nullable: true),
                    ToIsOfFromDescription = table.Column<string>(nullable: true),
                    FromIsOfToMouseOver = table.Column<string>(nullable: true),
                    ToIsOfFromMouseOver = table.Column<string>(nullable: true),
                    FromIsOfToMenuName = table.Column<string>(nullable: true),
                    ToIsOfFromMenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbUserRelationTypeIndexGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbUserRelationTypeLanguageDeleteGet",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromIsOfToName = table.Column<string>(nullable: true),
                    ToIsOfFromName = table.Column<string>(nullable: true),
                    FromIsOfToDescription = table.Column<string>(nullable: false),
                    ToIsOfFromDescription = table.Column<string>(nullable: false),
                    FromIsOfToMouseOver = table.Column<string>(nullable: true),
                    ToIsOfFromMouseOver = table.Column<string>(nullable: false),
                    FromIsOfToMenuName = table.Column<string>(nullable: false),
                    ToIsOfFromMenuName = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbUserRelationTypeLanguageDeleteGet", x => x.LId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbUserRelationTypeLanguageEditGet",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    FromIsOfToName = table.Column<string>(nullable: true),
                    ToIsOfFromName = table.Column<string>(nullable: true),
                    FromIsOfToDescription = table.Column<string>(nullable: false),
                    ToIsOfFromDescription = table.Column<string>(nullable: false),
                    FromIsOfToMouseOver = table.Column<string>(nullable: true),
                    ToIsOfFromMouseOver = table.Column<string>(nullable: false),
                    FromIsOfToMenuName = table.Column<string>(nullable: false),
                    ToIsOfFromMenuName = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbUserRelationTypeLanguageEditGet", x => x.LId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbUserRelationTypeLanguageIndexGet",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OId = table.Column<int>(nullable: false),
                    FromIsOfToName = table.Column<string>(nullable: true),
                    ToIsOfFromName = table.Column<string>(nullable: true),
                    FromIsOfToDescription = table.Column<string>(nullable: false),
                    ToIsOfFromDescription = table.Column<string>(nullable: false),
                    FromIsOfToMouseOver = table.Column<string>(nullable: true),
                    ToIsOfFromMouseOver = table.Column<string>(nullable: false),
                    FromIsOfToMenuName = table.Column<string>(nullable: false),
                    ToIsOfFromMenuName = table.Column<string>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    LanguageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbUserRelationTypeLanguageIndexGet", x => x.LId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "61bf82a7-65e2-420a-a0ea-c6a9b5dcdc56", "2f171c19-b773-4135-a8f1-979967e0c1eb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eff511f5-db74-4966-9a10-6a81c91d2c74", "1384fded-cbb9-4757-872b-df4d65b767fd", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbOrganizationEditGet");

            migrationBuilder.DropTable(
                name: "ZdbOrganizationTypeEditGet");

            migrationBuilder.DropTable(
                name: "ZdbPageSectionEditGet");

            migrationBuilder.DropTable(
                name: "ZdbPageSectionTypeEditGet");

            migrationBuilder.DropTable(
                name: "ZdbPageTypeEditGet");

            migrationBuilder.DropTable(
                name: "ZdbSuFrontProcessTodoEditGet");

            migrationBuilder.DropTable(
                name: "ZdbSuFrontProcessTodoIndexGet");

            migrationBuilder.DropTable(
                name: "ZdbUserRelationTypeIndexGet");

            migrationBuilder.DropTable(
                name: "ZdbUserRelationTypeLanguageDeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbUserRelationTypeLanguageEditGet");

            migrationBuilder.DropTable(
                name: "ZdbUserRelationTypeLanguageIndexGet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61bf82a7-65e2-420a-a0ea-c6a9b5dcdc56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff511f5-db74-4966-9a10-6a81c91d2c74");

            migrationBuilder.DropColumn(
                name: "TitleDescription",
                table: "ZdbContentTypeEditGet");

            migrationBuilder.DropColumn(
                name: "TitleName",
                table: "ZdbContentTypeEditGet");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DbProcessTemplateFieldType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "DbProcessTemplateFieldType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "DbProcessTemplateFieldType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifierId",
                table: "DbProcessTemplateFieldType",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab888578-a519-48da-a58f-add9e29cdad3", "227273dc-e77b-4c07-8315-3453c944b3c5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99f78a9e-2579-44cc-b0df-326b60e0053c", "80b1ba51-6119-4b12-bbd8-821285ccc238", "Super admin", "SUPER ADMIN" });
        }
    }
}

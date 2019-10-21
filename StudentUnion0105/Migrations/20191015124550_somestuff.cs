using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class somestuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07819592-4a51-4bd9-9619-fcf1abba15b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef6e30e8-ca2e-4472-8814-97750c256fb9");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProjectLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProjectLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbProjectLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateStepLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateStepLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbProcessTemplateStepLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbProcessTemplateLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateGroupLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateGroupLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbProcessTemplateGroupLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateFlowLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateFlowLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbProcessTemplateFlowLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateFlowConditionType",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateFlowConditionType",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateFlowConditionLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateFlowConditionLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbProcessTemplateFlowConditionLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateFieldTypeLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateFieldTypeLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbProcessTemplateFieldTypeLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateFieldLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateFieldLanguage",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbProcessTemplateFieldLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbPageTypeLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbPageSectionTypeLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbPageSectionLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbPageLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbOrganizationTypeLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbOrganizationLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "dbContentTypeLanguage",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MouseOver",
                table: "dbClassificationValueLanguage",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "dbClassificationValueLanguage",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "dbObject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Int1 = table.Column<int>(nullable: false),
                    Int2 = table.Column<int>(nullable: false),
                    IntNull1 = table.Column<int>(nullable: true),
                    IntNull2 = table.Column<int>(nullable: true),
                    Bool1 = table.Column<bool>(nullable: false),
                    Bool2 = table.Column<bool>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbObject", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "47d659e9-e7f6-41fb-9cc6-d34a3955b387", "63704595-21b9-41fc-b954-bf7d07b0b73a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fca0c82b-5f23-48d6-ae75-1909d77543a9", "2a411aa2-e3ed-4819-81e6-06b068f4dc6a", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbObject");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47d659e9-e7f6-41fb-9cc6-d34a3955b387");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fca0c82b-5f23-48d6-ae75-1909d77543a9");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbProjectLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbProcessTemplateStepLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbProcessTemplateLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbProcessTemplateGroupLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbProcessTemplateFlowLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbProcessTemplateFlowConditionLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbProcessTemplateFieldTypeLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbProcessTemplateFieldLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbPageTypeLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbPageSectionTypeLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbPageSectionLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbPageLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbOrganizationTypeLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbOrganizationLanguage");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "dbContentTypeLanguage");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProjectLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProjectLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateStepLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateStepLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateGroupLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateGroupLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateFlowLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateFlowLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateFlowConditionType",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateFlowConditionType",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateFlowConditionLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateFlowConditionLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateFieldTypeLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateFieldTypeLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateFieldLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateFieldLanguage",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "MouseOver",
                table: "dbClassificationValueLanguage",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "dbClassificationValueLanguage",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef6e30e8-ca2e-4472-8814-97750c256fb9", "12e8eee5-6ec1-40c8-9fc7-98106a92b35a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07819592-4a51-4bd9-9619-fcf1abba15b3", "d5c6cb9e-3a36-4802-9787-e952212ce7a4", "Super admin", "SUPER ADMIN" });
        }
    }
}

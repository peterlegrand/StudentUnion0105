using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class fieldtypeadjustmet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbProcessTemplateField_DbDataType_FieldDataTypeId",
                table: "DbProcessTemplateField");

            migrationBuilder.DropForeignKey(
                name: "FK_DbProcessTemplateField_DbMasterList_FieldMasterListId",
                table: "DbProcessTemplateField");

            migrationBuilder.DropIndex(
                name: "IX_DbProcessTemplateField_FieldDataTypeId",
                table: "DbProcessTemplateField");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "167c88b9-6f61-465f-ae77-2012f133a0f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a99567d8-9e29-42da-8579-1cbe425d3cb3");

            migrationBuilder.DropColumn(
                name: "FieldDataTypeId",
                table: "DbProcessTemplateField");

            migrationBuilder.RenameColumn(
                name: "FieldMasterListId",
                table: "DbProcessTemplateField",
                newName: "ProcessTemplateFieldTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_DbProcessTemplateField_FieldMasterListId",
                table: "DbProcessTemplateField",
                newName: "IX_DbProcessTemplateField_ProcessTemplateFieldTypeId");

            migrationBuilder.CreateTable(
                name: "ZdbSuProcessTemplateFieldEditGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ProcessTemplateFieldTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbSuProcessTemplateFieldEditGet", x => x.OId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ae1162e-72d2-4d9e-bf6c-54c015ad3206", "7affd8ce-8200-476c-84eb-0f507d9eebc5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68a83ec3-931e-41ed-851b-ef7aa85634a1", "6b814610-2a33-49a5-bd0e-fdd55442b2c2", "Super admin", "SUPER ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_DbProcessTemplateField_DbProcessTemplateFieldType_ProcessTemplateFieldTypeId",
                table: "DbProcessTemplateField",
                column: "ProcessTemplateFieldTypeId",
                principalTable: "DbProcessTemplateFieldType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbProcessTemplateField_DbProcessTemplateFieldType_ProcessTemplateFieldTypeId",
                table: "DbProcessTemplateField");

            migrationBuilder.DropTable(
                name: "ZdbSuProcessTemplateFieldEditGet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ae1162e-72d2-4d9e-bf6c-54c015ad3206");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68a83ec3-931e-41ed-851b-ef7aa85634a1");

            migrationBuilder.RenameColumn(
                name: "ProcessTemplateFieldTypeId",
                table: "DbProcessTemplateField",
                newName: "FieldMasterListId");

            migrationBuilder.RenameIndex(
                name: "IX_DbProcessTemplateField_ProcessTemplateFieldTypeId",
                table: "DbProcessTemplateField",
                newName: "IX_DbProcessTemplateField_FieldMasterListId");

            migrationBuilder.AddColumn<int>(
                name: "FieldDataTypeId",
                table: "DbProcessTemplateField",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "167c88b9-6f61-465f-ae77-2012f133a0f0", "2fda2096-75f7-4aa7-ae7a-16324614c09a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a99567d8-9e29-42da-8579-1cbe425d3cb3", "f9de9807-64d1-49c9-a1cd-4a01ee48e44e", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateField_FieldDataTypeId",
                table: "DbProcessTemplateField",
                column: "FieldDataTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbProcessTemplateField_DbDataType_FieldDataTypeId",
                table: "DbProcessTemplateField",
                column: "FieldDataTypeId",
                principalTable: "DbDataType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbProcessTemplateField_DbMasterList_FieldMasterListId",
                table: "DbProcessTemplateField",
                column: "FieldMasterListId",
                principalTable: "DbMasterList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

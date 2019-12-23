using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class fieldtype2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbProcessTemplateFieldTypeLanguage_DbPageType_FieldTypeId",
                table: "DbProcessTemplateFieldTypeLanguage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61bf82a7-65e2-420a-a0ea-c6a9b5dcdc56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff511f5-db74-4966-9a10-6a81c91d2c74");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "167c88b9-6f61-465f-ae77-2012f133a0f0", "2fda2096-75f7-4aa7-ae7a-16324614c09a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a99567d8-9e29-42da-8579-1cbe425d3cb3", "f9de9807-64d1-49c9-a1cd-4a01ee48e44e", "Super admin", "SUPER ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_DbProcessTemplateFieldTypeLanguage_DbProcessTemplateFieldType_FieldTypeId",
                table: "DbProcessTemplateFieldTypeLanguage",
                column: "FieldTypeId",
                principalTable: "DbProcessTemplateFieldType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbProcessTemplateFieldTypeLanguage_DbProcessTemplateFieldType_FieldTypeId",
                table: "DbProcessTemplateFieldTypeLanguage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "167c88b9-6f61-465f-ae77-2012f133a0f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a99567d8-9e29-42da-8579-1cbe425d3cb3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "61bf82a7-65e2-420a-a0ea-c6a9b5dcdc56", "2f171c19-b773-4135-a8f1-979967e0c1eb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eff511f5-db74-4966-9a10-6a81c91d2c74", "1384fded-cbb9-4757-872b-df4d65b767fd", "Super admin", "SUPER ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_DbProcessTemplateFieldTypeLanguage_DbPageType_FieldTypeId",
                table: "DbProcessTemplateFieldTypeLanguage",
                column: "FieldTypeId",
                principalTable: "DbPageType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

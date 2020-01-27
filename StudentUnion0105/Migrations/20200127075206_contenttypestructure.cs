using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class contenttypestructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "314e79b6-d994-4c0d-89ca-4a762da16c7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35a68c07-39c0-4029-b605-aa1ee03d66e8");

            migrationBuilder.AddColumn<int>(
                name: "ProcessTemplateId",
                table: "DbContentType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SuContentTypeClassificationModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeId = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuContentTypeClassificationModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuContentTypeClassificationModel_DbClassification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "DbClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuContentTypeClassificationModel_DbContentType_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "DbContentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aebeecf6-805a-431e-b97b-ffcad4bdd48c", "1f8fcf7c-3a40-4600-827a-3ec1a67c6839", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4d7164d-b7c5-4312-a5bb-554162cca94b", "2d9d8b51-af64-4948-bd04-264d8704c32b", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_SuContentTypeClassificationModel_ClassificationId",
                table: "SuContentTypeClassificationModel",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SuContentTypeClassificationModel_ContentTypeId",
                table: "SuContentTypeClassificationModel",
                column: "ContentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuContentTypeClassificationModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aebeecf6-805a-431e-b97b-ffcad4bdd48c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4d7164d-b7c5-4312-a5bb-554162cca94b");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateId",
                table: "DbContentType");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35a68c07-39c0-4029-b605-aa1ee03d66e8", "3553a95a-c113-4384-9d14-539bb08c3437", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "314e79b6-d994-4c0d-89ca-4a762da16c7a", "6eaf86bf-3f12-488a-aa75-aa0bef4f2630", "Super admin", "SUPER ADMIN" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class contenttypestructure5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbContentTypeClassification_dbContentTypeClassificationStatus_SuContentTypeClassificationStatusModelId",
                table: "dbContentTypeClassification");

            migrationBuilder.DropIndex(
                name: "IX_dbContentTypeClassification_SuContentTypeClassificationStatusModelId",
                table: "dbContentTypeClassification");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dbecb36-826f-4ff5-b629-8d0fa0e76f4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee4979ee-c31c-47c2-b88a-88718046f5c8");

            migrationBuilder.DropColumn(
                name: "SuContentTypeClassificationStatusModelId",
                table: "dbContentTypeClassification");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "573c4e50-5b3d-4edb-a865-b93e436289b5", "2ad5f4a2-ba6d-4d38-ae61-08dda30df469", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8adf2907-a402-4292-8800-82e2f51eded7", "5ac01607-abbb-4c1d-9ab5-b10f703541c5", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeClassification_StatusId",
                table: "dbContentTypeClassification",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbContentTypeClassification_dbContentTypeClassificationStatus_StatusId",
                table: "dbContentTypeClassification",
                column: "StatusId",
                principalTable: "dbContentTypeClassificationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbContentTypeClassification_dbContentTypeClassificationStatus_StatusId",
                table: "dbContentTypeClassification");

            migrationBuilder.DropIndex(
                name: "IX_dbContentTypeClassification_StatusId",
                table: "dbContentTypeClassification");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "573c4e50-5b3d-4edb-a865-b93e436289b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8adf2907-a402-4292-8800-82e2f51eded7");

            migrationBuilder.AddColumn<int>(
                name: "SuContentTypeClassificationStatusModelId",
                table: "dbContentTypeClassification",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee4979ee-c31c-47c2-b88a-88718046f5c8", "0d4d2e42-0164-482b-b664-9e3acf5abec1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0dbecb36-826f-4ff5-b629-8d0fa0e76f4e", "7811bbeb-7614-401b-9b10-b60ec8f1a3f8", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeClassification_SuContentTypeClassificationStatusModelId",
                table: "dbContentTypeClassification",
                column: "SuContentTypeClassificationStatusModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbContentTypeClassification_dbContentTypeClassificationStatus_SuContentTypeClassificationStatusModelId",
                table: "dbContentTypeClassification",
                column: "SuContentTypeClassificationStatusModelId",
                principalTable: "dbContentTypeClassificationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

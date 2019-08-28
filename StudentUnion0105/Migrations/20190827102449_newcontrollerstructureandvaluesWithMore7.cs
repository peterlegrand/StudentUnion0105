using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class newcontrollerstructureandvaluesWithMore7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassification_dbClassificationStatus_ClassificationStatusId",
                table: "dbClassification");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLanguage_dbClassification_ClassificationId",
                table: "dbClassificationLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLanguage_dbLanguage_LanguageId",
                table: "dbClassificationLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbClassificationLevel_ClassificationLevelId",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbLanguage_LanguageId",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationValueLanguage_dbClassificationValue_ClassificationValueId",
                table: "dbClassificationValueLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationValueLanguage_dbLanguage_LanguageId",
                table: "dbClassificationValueLanguage");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassification_dbClassificationStatus_ClassificationStatusId",
                table: "dbClassification",
                column: "ClassificationStatusId",
                principalTable: "dbClassificationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLanguage_dbClassification_ClassificationId",
                table: "dbClassificationLanguage",
                column: "ClassificationId",
                principalTable: "dbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLanguage_dbLanguage_LanguageId",
                table: "dbClassificationLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbClassificationLevel_ClassificationLevelId",
                table: "dbClassificationLevelLanguage",
                column: "ClassificationLevelId",
                principalTable: "dbClassificationLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbLanguage_LanguageId",
                table: "dbClassificationLevelLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationValueLanguage_dbClassificationValue_ClassificationValueId",
                table: "dbClassificationValueLanguage",
                column: "ClassificationValueId",
                principalTable: "dbClassificationValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationValueLanguage_dbLanguage_LanguageId",
                table: "dbClassificationValueLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassification_dbClassificationStatus_ClassificationStatusId",
                table: "dbClassification");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLanguage_dbClassification_ClassificationId",
                table: "dbClassificationLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLanguage_dbLanguage_LanguageId",
                table: "dbClassificationLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbClassificationLevel_ClassificationLevelId",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbLanguage_LanguageId",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationValueLanguage_dbClassificationValue_ClassificationValueId",
                table: "dbClassificationValueLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationValueLanguage_dbLanguage_LanguageId",
                table: "dbClassificationValueLanguage");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassification_dbClassificationStatus_ClassificationStatusId",
                table: "dbClassification",
                column: "ClassificationStatusId",
                principalTable: "dbClassificationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLanguage_dbClassification_ClassificationId",
                table: "dbClassificationLanguage",
                column: "ClassificationId",
                principalTable: "dbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLanguage_dbLanguage_LanguageId",
                table: "dbClassificationLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbClassificationLevel_ClassificationLevelId",
                table: "dbClassificationLevelLanguage",
                column: "ClassificationLevelId",
                principalTable: "dbClassificationLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbLanguage_LanguageId",
                table: "dbClassificationLevelLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationValueLanguage_dbClassificationValue_ClassificationValueId",
                table: "dbClassificationValueLanguage",
                column: "ClassificationValueId",
                principalTable: "dbClassificationValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationValueLanguage_dbLanguage_LanguageId",
                table: "dbClassificationValueLanguage",
                column: "LanguageId",
                principalTable: "dbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

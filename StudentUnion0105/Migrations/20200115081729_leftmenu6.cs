using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class leftmenu6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b50ec20-3795-49c9-88fc-7b2a817d1aa2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2e35001-f68f-468f-98c2-51c6886d8614");

            migrationBuilder.AlterColumn<string>(
                name: "MouseOver",
                table: "dbLeftMenuLanguage",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "dbLeftMenuLanguage",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "dbLeftMenuLanguage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "dbLeftMenuLanguage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "dbLeftMenuLanguage",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "dbLeftMenuLanguage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifierId",
                table: "dbLeftMenuLanguage",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "dbLeftMenuLanguage",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49971536-2404-4696-9549-0001719c43dc", "d4aa3a87-f0c8-4dd9-8dab-ae9c0ca2f381", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5477a11-1233-4f3c-a877-bbbadce81513", "aa59a037-98e8-447f-bfb3-1169d38c36ff", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbLeftMenuUser_LeftMenuId",
                table: "dbLeftMenuUser",
                column: "LeftMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_dbLeftMenuLanguage_LanguageId",
                table: "dbLeftMenuLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbLeftMenuLanguage_LeftMenuId",
                table: "dbLeftMenuLanguage",
                column: "LeftMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbLeftMenuLanguage_DbLanguage_LanguageId",
                table: "dbLeftMenuLanguage",
                column: "LanguageId",
                principalTable: "DbLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbLeftMenuLanguage_dbLeftMenu_LeftMenuId",
                table: "dbLeftMenuLanguage",
                column: "LeftMenuId",
                principalTable: "dbLeftMenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbLeftMenuUser_dbLeftMenu_LeftMenuId",
                table: "dbLeftMenuUser",
                column: "LeftMenuId",
                principalTable: "dbLeftMenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbLeftMenuLanguage_DbLanguage_LanguageId",
                table: "dbLeftMenuLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbLeftMenuLanguage_dbLeftMenu_LeftMenuId",
                table: "dbLeftMenuLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbLeftMenuUser_dbLeftMenu_LeftMenuId",
                table: "dbLeftMenuUser");

            migrationBuilder.DropIndex(
                name: "IX_dbLeftMenuUser_LeftMenuId",
                table: "dbLeftMenuUser");

            migrationBuilder.DropIndex(
                name: "IX_dbLeftMenuLanguage_LanguageId",
                table: "dbLeftMenuLanguage");

            migrationBuilder.DropIndex(
                name: "IX_dbLeftMenuLanguage_LeftMenuId",
                table: "dbLeftMenuLanguage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49971536-2404-4696-9549-0001719c43dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5477a11-1233-4f3c-a877-bbbadce81513");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "dbLeftMenuLanguage");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "dbLeftMenuLanguage");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "dbLeftMenuLanguage");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "dbLeftMenuLanguage");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "dbLeftMenuLanguage");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "dbLeftMenuLanguage");

            migrationBuilder.AlterColumn<string>(
                name: "MouseOver",
                table: "dbLeftMenuLanguage",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "dbLeftMenuLanguage",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2e35001-f68f-468f-98c2-51c6886d8614", "88ce3db1-6966-4162-b652-3135fe574607", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b50ec20-3795-49c9-88fc-7b2a817d1aa2", "5d129c16-1540-4c33-b9a3-e5535e0770e0", "Super admin", "SUPER ADMIN" });
        }
    }
}

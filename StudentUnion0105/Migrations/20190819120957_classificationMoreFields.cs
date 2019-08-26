using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class classificationMoreFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "dbClassification",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "dbClassification",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "DefailClassificationPageId",
                table: "dbClassification",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DropDownSequence",
                table: "dbClassification",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasDropDown",
                table: "dbClassification",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "dbClassification",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "dbClassification",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "dbClassification");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "dbClassification");

            migrationBuilder.DropColumn(
                name: "DefailClassificationPageId",
                table: "dbClassification");

            migrationBuilder.DropColumn(
                name: "DropDownSequence",
                table: "dbClassification");

            migrationBuilder.DropColumn(
                name: "HasDropDown",
                table: "dbClassification");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "dbClassification");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "dbClassification");
        }
    }
}

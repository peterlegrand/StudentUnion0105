using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class alot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "224c710e-582c-4fab-9dd7-ee7e8bf2c09c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f3be070-1e3a-4966-a027-8f33a50a8535");

            migrationBuilder.DropColumn(
                name: "ComparisonOperator",
                table: "dbProcessTemplateFlowCondition");

            migrationBuilder.DropColumn(
                name: "ConditionCharacter",
                table: "dbProcessTemplateFlowCondition");

            migrationBuilder.DropColumn(
                name: "ConditionRelation",
                table: "dbProcessTemplateFlow");

            migrationBuilder.AddColumn<int>(
                name: "ComparisonOperatorId",
                table: "dbProcessTemplateFlowCondition",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DataTypeId",
                table: "dbProcessTemplateFlowCondition",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "dbComparison",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbComparison", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbProcessTemplateFlowConditionEditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationStatusId = table.Column<int>(nullable: false),
                    ProcessTemplateConditionTypeId = table.Column<int>(nullable: false),
                    ComparisonOperator = table.Column<bool>(nullable: false),
                    DropDownSequence = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_ZdbProcessTemplateFlowConditionEditGet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d313a3be-3a23-4fbf-9132-44814c745fe4", "9565310a-2574-4e44-80e7-100a1f742745", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f044199-8e50-4203-9009-250e22ade484", "5c288706-08e3-438a-b0e3-fd2981dd54dc", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbComparison");

            migrationBuilder.DropTable(
                name: "ZdbProcessTemplateFlowConditionEditGet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f044199-8e50-4203-9009-250e22ade484");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d313a3be-3a23-4fbf-9132-44814c745fe4");

            migrationBuilder.DropColumn(
                name: "ComparisonOperatorId",
                table: "dbProcessTemplateFlowCondition");

            migrationBuilder.DropColumn(
                name: "DataTypeId",
                table: "dbProcessTemplateFlowCondition");

            migrationBuilder.AddColumn<string>(
                name: "ComparisonOperator",
                table: "dbProcessTemplateFlowCondition",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionCharacter",
                table: "dbProcessTemplateFlowCondition",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionRelation",
                table: "dbProcessTemplateFlow",
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "224c710e-582c-4fab-9dd7-ee7e8bf2c09c", "5e742af9-33bd-46a2-a079-f9810936689d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f3be070-1e3a-4966-a027-8f33a50a8535", "82075821-4e86-4339-a80f-cb20705e4eb3", "Super admin", "SUPER ADMIN" });
        }
    }
}

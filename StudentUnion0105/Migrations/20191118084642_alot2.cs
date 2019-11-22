using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class alot2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f044199-8e50-4203-9009-250e22ade484");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d313a3be-3a23-4fbf-9132-44814c745fe4");

            migrationBuilder.DropColumn(
                name: "ClassificationStatusId",
                table: "ZdbProcessTemplateFlowConditionEditGet");

            migrationBuilder.DropColumn(
                name: "ComparisonOperator",
                table: "ZdbProcessTemplateFlowConditionEditGet");

            migrationBuilder.RenameColumn(
                name: "Lid",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                newName: "LId");

            migrationBuilder.RenameColumn(
                name: "DropDownSequence",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                newName: "OId");

            migrationBuilder.AddColumn<int>(
                name: "ComparisonOperatorId",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DataTypeId",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessTemplateFieldId",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProcessTemplateFlowConditionDate",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProcessTemplateFlowConditionInt",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessTemplateFlowConditionString",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8e8c39c-8611-48e3-acf0-62e21369bad0", "8fd59577-f963-4e80-a95c-1e3f6381ea80", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02588eba-1071-47fd-a92a-86e1f5288c61", "6ac559b4-3715-4c46-ac68-9d179c5e363e", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02588eba-1071-47fd-a92a-86e1f5288c61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8e8c39c-8611-48e3-acf0-62e21369bad0");

            migrationBuilder.DropColumn(
                name: "ComparisonOperatorId",
                table: "ZdbProcessTemplateFlowConditionEditGet");

            migrationBuilder.DropColumn(
                name: "DataTypeId",
                table: "ZdbProcessTemplateFlowConditionEditGet");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateFieldId",
                table: "ZdbProcessTemplateFlowConditionEditGet");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateFlowConditionDate",
                table: "ZdbProcessTemplateFlowConditionEditGet");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateFlowConditionInt",
                table: "ZdbProcessTemplateFlowConditionEditGet");

            migrationBuilder.DropColumn(
                name: "ProcessTemplateFlowConditionString",
                table: "ZdbProcessTemplateFlowConditionEditGet");

            migrationBuilder.RenameColumn(
                name: "LId",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                newName: "Lid");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                newName: "DropDownSequence");

            migrationBuilder.RenameColumn(
                name: "OId",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ClassificationStatusId",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ComparisonOperator",
                table: "ZdbProcessTemplateFlowConditionEditGet",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d313a3be-3a23-4fbf-9132-44814c745fe4", "9565310a-2574-4e44-80e7-100a1f742745", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f044199-8e50-4203-9009-250e22ade484", "5c288706-08e3-438a-b0e3-fd2981dd54dc", "Super admin", "SUPER ADMIN" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class updatenulluser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "407aa912-b0ca-454f-bc28-dbb430df8057");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "798a4a21-8b1f-4b47-a884-80deaa1e3977");

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
                table: "dbProcessTemplateFieldType",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateFieldType",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplate",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplate",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b71cb87b-ba43-4c98-937c-1e71e197b6a8", "b8fec86c-7371-45a4-ac1c-463f6fcd6a4b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fde9bce-9893-4bf9-a23f-dc767c1b2973", "dcb364c0-45b8-4d6a-a4aa-8faaec6ff534", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fde9bce-9893-4bf9-a23f-dc767c1b2973");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b71cb87b-ba43-4c98-937c-1e71e197b6a8");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplateFieldType",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplateFieldType",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierId",
                table: "dbProcessTemplate",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "dbProcessTemplate",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "407aa912-b0ca-454f-bc28-dbb430df8057", "f0be32ab-8510-448b-b781-e2e07c0dcd4b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "798a4a21-8b1f-4b47-a884-80deaa1e3977", "51d590ff-f6e7-4a19-a87e-9ba258233be4", "Super admin", "SUPER ADMIN" });
        }
    }
}

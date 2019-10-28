﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class fresh04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53699586-6019-4365-866e-036c865ed23a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d6a59c5-6274-473b-aa58-5f474290c967");

            migrationBuilder.RenameColumn(
                name: "DataTypeDescription",
                table: "dbDataType",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fab201a6-1a2a-4b00-b022-a343cc6794c3", "36493c01-1ee8-4b2b-9dbe-5cc69a4186eb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "32d21312-809b-4a4e-be4f-bf4efbc21ac2", "cea33a62-d08c-4aca-88f9-bfdc723060f9", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32d21312-809b-4a4e-be4f-bf4efbc21ac2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab201a6-1a2a-4b00-b022-a343cc6794c3");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "dbDataType",
                newName: "DataTypeDescription");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d6a59c5-6274-473b-aa58-5f474290c967", "d16a3f21-7b9f-40bd-be77-c3378e80d8ae", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53699586-6019-4365-866e-036c865ed23a", "85520afe-74bf-4630-9077-186a950dd441", "Super admin", "SUPER ADMIN" });
        }
    }
}
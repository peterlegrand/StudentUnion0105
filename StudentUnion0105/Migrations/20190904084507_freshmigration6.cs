using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class freshmigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4743a993-6fe5-439b-95c0-6d5cd16e1f33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67cf88b2-44b5-44ca-8472-b7f1d0756ff9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ae97c75a-0762-447b-b9c2-e89320176951", "8ddb0d15-0eb4-43ca-85ed-5a1f0be94d33", "Admin", "ADMIN" },
                    { "02760e7f-6215-4d77-92ce-2001cc347b30", "3f6d680c-bac4-4592-90b7-f6312d8860a4", "Super admin", "SUPER ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 2,
                column: "Claim",
                value: "ClassificationPage");

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Claim", "ClaimGroup" },
                values: new object[] { "Roles", "Administration" });

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Claim", "ClaimGroup" },
                values: new object[] { "ClassificationLevel", "Classification" });

            migrationBuilder.InsertData(
                table: "dbClaim",
                columns: new[] { "Id", "Claim", "ClaimGroup", "ClaimType" },
                values: new object[,]
                {
                    { 5, "ContentType", "Types", "Menu" },
                    { 6, "OrganizationType", "Types", "Menu" },
                    { 7, "PageType", "Types", "Menu" },
                    { 8, "Page", "Page", "Menu" },
                    { 9, "Project", "Project", "Menu" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02760e7f-6215-4d77-92ce-2001cc347b30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae97c75a-0762-447b-b9c2-e89320176951");

            migrationBuilder.DeleteData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67cf88b2-44b5-44ca-8472-b7f1d0756ff9", "7ea4f7a8-a3fd-4176-bcbd-22e13c9e1780", "Admin", "ADMIN" },
                    { "4743a993-6fe5-439b-95c0-6d5cd16e1f33", "4f859ea0-0cb1-42e2-91e9-633d9e229c8e", "Super admin", "SUPER ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 2,
                column: "Claim",
                value: "ClassificationLevel");

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Claim", "ClaimGroup" },
                values: new object[] { "ClassificationPage", "Classification" });

            migrationBuilder.UpdateData(
                table: "dbClaim",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Claim", "ClaimGroup" },
                values: new object[] { "Roles", "Administration" });
        }
    }
}

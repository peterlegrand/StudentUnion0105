using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class flowcondition2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18220deb-bcdc-48bf-ba84-cbdcfe96445f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28a20918-f11e-4f37-bd0f-cfe012808f9f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5ef35a4-672b-4746-adf6-4949512375e2", "3d17152b-9e81-4fba-99ee-b4d6b77391de", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea1dc766-5653-4cd9-a168-c10afc79f977", "67bf03ad-af84-4006-9d9d-acb0191f4701", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5ef35a4-672b-4746-adf6-4949512375e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea1dc766-5653-4cd9-a168-c10afc79f977");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18220deb-bcdc-48bf-ba84-cbdcfe96445f", "b720e54b-034f-412d-8715-69e33ed022a5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28a20918-f11e-4f37-bd0f-cfe012808f9f", "f87eff3f-3dea-48d5-9dd2-c8af9e360927", "Super admin", "SUPER ADMIN" });
        }
    }
}

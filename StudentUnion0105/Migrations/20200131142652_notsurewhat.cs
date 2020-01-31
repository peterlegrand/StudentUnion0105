using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class notsurewhat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12eb3b56-7ea9-4312-bfce-ca0e13cb442a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5ba9177-c9a8-4fa6-a79f-f64af77316c4");

            migrationBuilder.AddColumn<string>(
                name: "DropDownName",
                table: "ZdbObjectLanguageEditGet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeaderDescription",
                table: "ZdbObjectLanguageEditGet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeaderName",
                table: "ZdbObjectLanguageEditGet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageDescription",
                table: "ZdbObjectLanguageEditGet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageName",
                table: "ZdbObjectLanguageEditGet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopicName",
                table: "ZdbObjectLanguageEditGet",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b3dfb0b-be88-42ce-87df-483fae8fb634", "f1dd3c1e-a94c-46ad-a078-e66e9d2e1c50", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f046b5f7-97dc-4c92-b0a9-deacb6e37725", "5cf96365-60c1-4238-91e7-8c9379798f84", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b3dfb0b-be88-42ce-87df-483fae8fb634");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f046b5f7-97dc-4c92-b0a9-deacb6e37725");

            migrationBuilder.DropColumn(
                name: "DropDownName",
                table: "ZdbObjectLanguageEditGet");

            migrationBuilder.DropColumn(
                name: "HeaderDescription",
                table: "ZdbObjectLanguageEditGet");

            migrationBuilder.DropColumn(
                name: "HeaderName",
                table: "ZdbObjectLanguageEditGet");

            migrationBuilder.DropColumn(
                name: "PageDescription",
                table: "ZdbObjectLanguageEditGet");

            migrationBuilder.DropColumn(
                name: "PageName",
                table: "ZdbObjectLanguageEditGet");

            migrationBuilder.DropColumn(
                name: "TopicName",
                table: "ZdbObjectLanguageEditGet");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5ba9177-c9a8-4fa6-a79f-f64af77316c4", "01e4b0bc-3cbe-41cf-8be3-d57b6b25776b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12eb3b56-7ea9-4312-bfce-ca0e13cb442a", "e7490d33-41cb-4e28-a6ef-3ad2295dbf6a", "Super admin", "SUPER ADMIN" });
        }
    }
}

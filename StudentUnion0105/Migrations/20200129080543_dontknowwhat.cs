using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class dontknowwhat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ec2270a-dbf2-471a-a873-c0b1c92520bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9d27f68-fb7a-41d4-809b-1627c5501cd8");

            migrationBuilder.AddColumn<string>(
                name: "TitleDesciption",
                table: "ZdbObjectLanguageEditGet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleName",
                table: "ZdbObjectLanguageEditGet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ZdbObjectLanguageEditGet",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ZdbObjectLanguageEditGet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ZdbLanguageCreateGetLanguageList",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbLanguageCreateGetLanguageList", x => x.Value);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5ba9177-c9a8-4fa6-a79f-f64af77316c4", "01e4b0bc-3cbe-41cf-8be3-d57b6b25776b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12eb3b56-7ea9-4312-bfce-ca0e13cb442a", "e7490d33-41cb-4e28-a6ef-3ad2295dbf6a", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbLanguageCreateGetLanguageList");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12eb3b56-7ea9-4312-bfce-ca0e13cb442a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5ba9177-c9a8-4fa6-a79f-f64af77316c4");

            migrationBuilder.DropColumn(
                name: "TitleDesciption",
                table: "ZdbObjectLanguageEditGet");

            migrationBuilder.DropColumn(
                name: "TitleName",
                table: "ZdbObjectLanguageEditGet");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ZdbObjectLanguageEditGet");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ZdbObjectLanguageEditGet");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ec2270a-dbf2-471a-a873-c0b1c92520bd", "c30b621e-341a-454e-a216-dcd9b6000d0e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9d27f68-fb7a-41d4-809b-1627c5501cd8", "164a6f1d-8f34-4b8c-9909-b056d00606b4", "Super admin", "SUPER ADMIN" });
        }
    }
}

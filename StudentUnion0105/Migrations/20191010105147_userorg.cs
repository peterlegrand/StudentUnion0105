using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class userorg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3178f384-2d13-45d8-a1a7-99cd4ee51f22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fce28fc-392b-452a-91de-e4406f14153f");

            migrationBuilder.CreateTable(
                name: "dbIdWithStrings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    String1 = table.Column<string>(nullable: true),
                    String2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbIdWithStrings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbObjectVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    ObjectLanguageId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    HasDropDown = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    ObjectId = table.Column<int>(nullable: false),
                    DateLevel = table.Column<int>(nullable: false),
                    OnTheFly = table.Column<bool>(nullable: false),
                    Alphabetically = table.Column<bool>(nullable: false),
                    CanLink = table.Column<bool>(nullable: false),
                    InDropDown = table.Column<bool>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    NullId = table.Column<int>(nullable: true),
                    NullId2 = table.Column<int>(nullable: true),
                    NotNullId = table.Column<int>(nullable: false),
                    NotNullId2 = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description2 = table.Column<string>(nullable: true),
                    DropDownName = table.Column<string>(nullable: true),
                    PageName = table.Column<string>(nullable: true),
                    PageDescription = table.Column<string>(nullable: true),
                    HeaderName = table.Column<string>(nullable: true),
                    HeaderDescription = table.Column<string>(nullable: true),
                    TopicName = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTimeOffset>(nullable: true),
                    DateTo = table.Column<DateTimeOffset>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    IndexSection = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbObjectVM", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57436b03-a584-44c1-9d84-87b488199ac6", "03ef53a7-f788-49da-bcd6-a67239909733", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29e32a1b-cfb9-43dd-aacc-678d9f064270", "1587d1b4-b0b9-4d8f-bfd7-ba9cade8d9c8", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbIdWithStrings");

            migrationBuilder.DropTable(
                name: "dbObjectVM");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29e32a1b-cfb9-43dd-aacc-678d9f064270");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57436b03-a584-44c1-9d84-87b488199ac6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8fce28fc-392b-452a-91de-e4406f14153f", "21454962-820b-4c37-82cb-9605bcc6ba80", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3178f384-2d13-45d8-a1a7-99cd4ee51f22", "fdb531f1-fd90-4bc6-bda2-c85f48d52eba", "Super admin", "SUPER ADMIN" });
        }
    }
}

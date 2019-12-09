using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class renamesomefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25ecb899-6678-42ce-bef9-fb13cbc1a612");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "775522cb-160c-4bde-a7b1-d59130e7144b");

            migrationBuilder.DropColumn(
                name: "ClassificationId",
                table: "ZdbClassificationPageEditGet");

            migrationBuilder.AddColumn<string>(
                name: "TitleDescription",
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

            migrationBuilder.CreateTable(
                name: "ZdbClassificationPageDeleteGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ShowClassificationPageTitleName = table.Column<bool>(nullable: false),
                    ShowClassificationPageTitleDescription = table.Column<bool>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationPageDeleteGet", x => x.OId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b71536d-37c0-4b36-bff0-6ae23bccb6ad", "8691d24b-05e9-456b-af4a-14a9f5bf8b6f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b7d2898-4d7e-43be-b196-9cecc9c6d82f", "b3f85846-c73c-4421-832e-ddab89e6b680", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbClassificationPageDeleteGet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b71536d-37c0-4b36-bff0-6ae23bccb6ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b7d2898-4d7e-43be-b196-9cecc9c6d82f");

            migrationBuilder.DropColumn(
                name: "TitleDescription",
                table: "ZdbObjectLanguageEditGet");

            migrationBuilder.DropColumn(
                name: "TitleName",
                table: "ZdbObjectLanguageEditGet");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ZdbObjectLanguageEditGet");

            migrationBuilder.AddColumn<int>(
                name: "ClassificationId",
                table: "ZdbClassificationPageEditGet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25ecb899-6678-42ce-bef9-fb13cbc1a612", "eec9775f-9ce8-4936-bcba-e71d5c581976", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "775522cb-160c-4bde-a7b1-d59130e7144b", "dc764a7d-c50f-41d4-9d5c-84e76a9c470e", "Super admin", "SUPER ADMIN" });
        }
    }
}

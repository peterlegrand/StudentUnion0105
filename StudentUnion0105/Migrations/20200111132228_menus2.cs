using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class menus2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bfe8fc-2a38-46ac-85c7-ba71233e298a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47b671e2-82eb-4642-991b-1cc4e165c498");

            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "dbMenu3",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "dbMenu3",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "dbMenu2",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "dbMenu2",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "dbMenu1",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "dbMenu1",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ZdbFrontProcessToDoIndex2Get",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontProcessToDoIndex2Get", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuTypeId = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    DestinationId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    NoOfMenus2 = table.Column<int>(nullable: false),
                    NoOfClassifications = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu1DeleteGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(nullable: true),
                    ClassificationName = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    FeatureId = table.Column<int>(nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    LanguageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu1DeleteGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu1EditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuTypeId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    DestinationId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu1EditGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu1IndexGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu1IndexGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    MenuType = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    NoOfMenus3 = table.Column<int>(nullable: false),
                    NoOfClassifications = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu2DeleteGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(nullable: true),
                    ClassificationName = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    FeatureId = table.Column<int>(nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    LanguageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu2DeleteGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu2EditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Menu1Id = table.Column<int>(nullable: false),
                    MenuTypeId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    DestinationId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu2EditGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu2IndexGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu2IndexGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    MenuType = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu3DeleteGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(nullable: true),
                    ClassificationName = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    FeatureId = table.Column<int>(nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    LanguageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu3DeleteGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu3EditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sequence = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    DestinationId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu3EditGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu3IndexGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu3IndexGet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df4cf4c2-e081-4d16-860d-c83e4af15e40", "8559372a-2b78-4f3c-9422-5b5ba45f8d63", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d712003-387c-4772-a41b-7c4d9c69340d", "2188120a-f5b4-4794-952a-2c1911b625bf", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbFrontProcessToDoIndex2Get");

            migrationBuilder.DropTable(
                name: "ZdbMenu1");

            migrationBuilder.DropTable(
                name: "ZdbMenu1DeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbMenu1EditGet");

            migrationBuilder.DropTable(
                name: "ZdbMenu1IndexGet");

            migrationBuilder.DropTable(
                name: "ZdbMenu2");

            migrationBuilder.DropTable(
                name: "ZdbMenu2DeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbMenu2EditGet");

            migrationBuilder.DropTable(
                name: "ZdbMenu2IndexGet");

            migrationBuilder.DropTable(
                name: "ZdbMenu3");

            migrationBuilder.DropTable(
                name: "ZdbMenu3DeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbMenu3EditGet");

            migrationBuilder.DropTable(
                name: "ZdbMenu3IndexGet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d712003-387c-4772-a41b-7c4d9c69340d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df4cf4c2-e081-4d16-860d-c83e4af15e40");

            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "dbMenu3",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "dbMenu3",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "dbMenu2",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "dbMenu2",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Controller",
                table: "dbMenu1",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "dbMenu1",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "47b671e2-82eb-4642-991b-1cc4e165c498", "6114b66a-af4b-4133-8f2d-b8331a0ac89c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29bfe8fc-2a38-46ac-85c7-ba71233e298a", "86837f67-7a99-4956-8960-2566fa6c9863", "Super admin", "SUPER ADMIN" });
        }
    }
}

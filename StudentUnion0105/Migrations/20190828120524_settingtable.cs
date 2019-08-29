using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class settingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IntValue = table.Column<int>(nullable: false),
                    StringValue = table.Column<string>(nullable: true),
                    DateTimeValue = table.Column<DateTime>(nullable: false),
                    GuidValue = table.Column<Guid>(nullable: false),
                    SettingName = table.Column<string>(nullable: true),
                    SettingDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbSetting", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "dbSetting",
                columns: new[] { "Id", "DateTimeValue", "GuidValue", "IntValue", "SettingDescription", "SettingName", "StringValue" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 1, null, "Dedault language", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbSetting");
        }
    }
}

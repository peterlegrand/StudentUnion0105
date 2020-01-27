using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class classtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23534f0d-73a6-4887-a4a3-df86f5bda4ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3f44b8a-f98d-4bf2-ac46-30748d1f9889");

            migrationBuilder.CreateTable(
                name: "ZdbContentTypeClassificationEditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeId = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    ClassificationName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbContentTypeClassificationEditGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbContentTypeClassificationEditGetStatusList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbContentTypeClassificationEditGetStatusList", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ec2270a-dbf2-471a-a873-c0b1c92520bd", "c30b621e-341a-454e-a216-dcd9b6000d0e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9d27f68-fb7a-41d4-809b-1627c5501cd8", "164a6f1d-8f34-4b8c-9909-b056d00606b4", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbContentTypeClassificationEditGet");

            migrationBuilder.DropTable(
                name: "ZdbContentTypeClassificationEditGetStatusList");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ec2270a-dbf2-471a-a873-c0b1c92520bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9d27f68-fb7a-41d4-809b-1627c5501cd8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23534f0d-73a6-4887-a4a3-df86f5bda4ec", "f5a19f9b-d30e-45ed-988a-36fae1691b67", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3f44b8a-f98d-4bf2-ac46-30748d1f9889", "e7ec6620-050f-4a7d-b52b-a6261763e967", "Super admin", "SUPER ADMIN" });
        }
    }
}

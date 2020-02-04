using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class createcontent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30d98497-df0c-463c-8557-f4adc9b9a69d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a37355ec-c5c6-4c06-b4ff-73e64aeeac60");

            migrationBuilder.CreateTable(
                name: "ZdbContentCreate2GetClassifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbContentCreate2GetClassifications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "387ba9cd-5cf6-47da-9e54-161bcbd43399", "219cdfc0-f581-43a9-8f7f-739b6c28838e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a837f8b7-1674-499b-bf5d-f84fba8afed6", "52df97e6-117a-4fe5-aa81-ad803aff5193", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZdbContentCreate2GetClassifications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "387ba9cd-5cf6-47da-9e54-161bcbd43399");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a837f8b7-1674-499b-bf5d-f84fba8afed6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a37355ec-c5c6-4c06-b4ff-73e64aeeac60", "ecfee822-8e43-4d8f-a71c-2f138495e82c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30d98497-df0c-463c-8557-f4adc9b9a69d", "8e0f2d39-339a-4474-9df2-870ff04a4639", "Super admin", "SUPER ADMIN" });
        }
    }
}

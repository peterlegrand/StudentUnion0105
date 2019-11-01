using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class objectindex2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2228fbdf-b451-4bbc-bd41-4e1bfb56744c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54d8959b-7f54-44d7-96e6-74f76f635baf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9015894b-87bb-4985-b19d-c19626073391", "84cd9451-9e3b-44c2-8fee-866b414faa6a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ceb260f0-0687-474f-9510-e2759986d243", "a58b51b1-8f1d-46b9-b756-c3f4022b6f7d", "Super admin", "SUPER ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9015894b-87bb-4985-b19d-c19626073391");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ceb260f0-0687-474f-9510-e2759986d243");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54d8959b-7f54-44d7-96e6-74f76f635baf", "ad6d5fea-3a02-4106-a37a-11c5f17b6e2e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2228fbdf-b451-4bbc-bd41-4e1bfb56744c", "002e0442-04aa-44b3-872c-1ce4af8a207b", "Super admin", "SUPER ADMIN" });
        }
    }
}

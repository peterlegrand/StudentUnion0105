using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class userstuff4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d75f50e-08cf-43d4-9c84-8ec4c82fc295");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a829a79-05ff-40d9-9585-debea7235878");

            migrationBuilder.CreateTable(
                name: "dbUserOrganizationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbUserOrganizationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbUserProjectType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbUserProjectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbUserRelationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbUserRelationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbUserOrganization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(maxLength: 450, nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbUserOrganization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbUserOrganization_dbOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "dbOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbUserOrganization_dbUserOrganizationType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "dbUserOrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbUserOrganization_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbUserOrganizationTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbUserOrganizationTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbUserOrganizationTypeLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbUserOrganizationTypeLanguage_dbUserOrganizationType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "dbUserOrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbUserProject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(maxLength: 450, nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbUserProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbUserProject_dbProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "dbProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbUserProject_dbUserProjectType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "dbUserProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbUserProject_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbUserProjectTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbUserProjectTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbUserProjectTypeLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbUserProjectTypeLanguage_dbUserProjectType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "dbUserProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbUserRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromUserId = table.Column<string>(maxLength: 450, nullable: true),
                    ToUserId = table.Column<string>(maxLength: 450, nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbUserRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbUserRelation_AspNetUsers_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbUserRelation_AspNetUsers_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbUserRelation_dbUserRelationType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "dbUserRelationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbUserRelationTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbUserRelationTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbUserRelationTypeLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbUserRelationTypeLanguage_dbUserRelationType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "dbUserRelationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3797bf3-05a8-4373-9d12-618ce387a3ae", "be9682f4-00bf-4fb0-b672-68912237942d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e89299cf-0126-4323-a4c0-271d70ace4ab", "19da4287-1803-4186-9df3-4844789a728c", "Super admin", "SUPER ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_dbUserOrganization_OrganizationId",
                table: "dbUserOrganization",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserOrganization_TypeId",
                table: "dbUserOrganization",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserOrganization_UserId",
                table: "dbUserOrganization",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserOrganizationTypeLanguage_LanguageId",
                table: "dbUserOrganizationTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserOrganizationTypeLanguage_TypeId",
                table: "dbUserOrganizationTypeLanguage",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserProject_ProjectId",
                table: "dbUserProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserProject_TypeId",
                table: "dbUserProject",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserProject_UserId",
                table: "dbUserProject",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserProjectTypeLanguage_LanguageId",
                table: "dbUserProjectTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserProjectTypeLanguage_TypeId",
                table: "dbUserProjectTypeLanguage",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserRelation_FromUserId",
                table: "dbUserRelation",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserRelation_ToUserId",
                table: "dbUserRelation",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserRelation_TypeId",
                table: "dbUserRelation",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserRelationTypeLanguage_LanguageId",
                table: "dbUserRelationTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbUserRelationTypeLanguage_TypeId",
                table: "dbUserRelationTypeLanguage",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbUserOrganization");

            migrationBuilder.DropTable(
                name: "dbUserOrganizationTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbUserProject");

            migrationBuilder.DropTable(
                name: "dbUserProjectTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbUserRelation");

            migrationBuilder.DropTable(
                name: "dbUserRelationTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbUserOrganizationType");

            migrationBuilder.DropTable(
                name: "dbUserProjectType");

            migrationBuilder.DropTable(
                name: "dbUserRelationType");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3797bf3-05a8-4373-9d12-618ce387a3ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e89299cf-0126-4323-a4c0-271d70ace4ab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a829a79-05ff-40d9-9585-debea7235878", "f997c61f-0b61-45d5-a8b1-7077def6a93d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d75f50e-08cf-43d4-9c84-8ec4c82fc295", "56131ec6-6f59-4e13-a6af-67a140cf5d94", "Super admin", "SUPER ADMIN" });
        }
    }
}

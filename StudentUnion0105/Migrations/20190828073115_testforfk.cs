using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class testforfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbClassification_dbClassificationStatus_ClassificationStatusId",
                table: "dbClassification");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLanguage_dbClassification_ClassificationId",
                table: "dbClassificationLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbClassificationLevel_ClassificationLevelId",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "dbClassificationValueLanguage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "dbClassificationValueLanguage",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "dbClassificationValueLanguage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "dbClassificationValueLanguage",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "ParentValueId",
                table: "dbClassificationValue",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "dbClassificationValue",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "dbClassificationValue",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "dbClassificationValue",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "dbClassificationValue",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "dbClassificationLevelLanguage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "dbClassificationLevelLanguage",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "dbClassificationLevelLanguage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "dbClassificationLevelLanguage",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "dbClassificationLanguage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "dbClassificationLanguage",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "dbClassificationLanguage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "dbClassificationLanguage",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "dbContentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbContentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbOrganizationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbOrganizationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbOrganizationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbOrganizationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProjectStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProjectStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbContentTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbContentTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbContentTypeLanguage_dbContentType_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "dbContentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbContentTypeLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbOrganization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentOrganizationId = table.Column<int>(nullable: false),
                    OrganizationStatusId = table.Column<int>(nullable: false),
                    OrganizationTypeId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbOrganization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbOrganization_dbOrganizationStatus_OrganizationStatusId",
                        column: x => x.OrganizationStatusId,
                        principalTable: "dbOrganizationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbOrganization_dbOrganizationType_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "dbOrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbOrganizationTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbOrganizationTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbOrganizationTypeLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbOrganizationTypeLanguage_dbOrganizationType_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "dbOrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbProject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentProjectId = table.Column<int>(nullable: false),
                    ProjectStatusId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProject_dbProjectStatus_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "dbProjectStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbOrganizationLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbOrganizationLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbOrganizationLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbOrganizationLanguage_dbOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "dbOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbProjectLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProjectLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProjectLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbProjectLanguage_dbProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "dbProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeLanguage_ContentTypeId",
                table: "dbContentTypeLanguage",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeLanguage_LanguageId",
                table: "dbContentTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbOrganization_OrganizationStatusId",
                table: "dbOrganization",
                column: "OrganizationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dbOrganization_OrganizationTypeId",
                table: "dbOrganization",
                column: "OrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbOrganizationLanguage_LanguageId",
                table: "dbOrganizationLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbOrganizationLanguage_OrganizationId",
                table: "dbOrganizationLanguage",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_dbOrganizationTypeLanguage_LanguageId",
                table: "dbOrganizationTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbOrganizationTypeLanguage_OrganizationTypeId",
                table: "dbOrganizationTypeLanguage",
                column: "OrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProject_ProjectStatusId",
                table: "dbProject",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProjectLanguage_LanguageId",
                table: "dbProjectLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProjectLanguage_ProjectId",
                table: "dbProjectLanguage",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassification_dbClassificationStatus_ClassificationStatusId",
                table: "dbClassification",
                column: "ClassificationStatusId",
                principalTable: "dbClassificationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLanguage_dbClassification_ClassificationId",
                table: "dbClassificationLanguage",
                column: "ClassificationId",
                principalTable: "dbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbClassificationLevel_ClassificationLevelId",
                table: "dbClassificationLevelLanguage",
                column: "ClassificationLevelId",
                principalTable: "dbClassificationLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbClassification_dbClassificationStatus_ClassificationStatusId",
                table: "dbClassification");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLanguage_dbClassification_ClassificationId",
                table: "dbClassificationLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbClassificationLevel_ClassificationLevelId",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.DropTable(
                name: "dbContentTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbOrganizationLanguage");

            migrationBuilder.DropTable(
                name: "dbOrganizationTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbProjectLanguage");

            migrationBuilder.DropTable(
                name: "dbContentType");

            migrationBuilder.DropTable(
                name: "dbOrganization");

            migrationBuilder.DropTable(
                name: "dbProject");

            migrationBuilder.DropTable(
                name: "dbOrganizationStatus");

            migrationBuilder.DropTable(
                name: "dbOrganizationType");

            migrationBuilder.DropTable(
                name: "dbProjectStatus");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "dbClassificationValueLanguage");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "dbClassificationValueLanguage");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "dbClassificationValueLanguage");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "dbClassificationValueLanguage");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "dbClassificationValue");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "dbClassificationValue");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "dbClassificationValue");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "dbClassificationValue");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "dbClassificationLevelLanguage");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "dbClassificationLanguage");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "dbClassificationLanguage");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "dbClassificationLanguage");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "dbClassificationLanguage");

            migrationBuilder.AlterColumn<int>(
                name: "ParentValueId",
                table: "dbClassificationValue",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassification_dbClassificationStatus_ClassificationStatusId",
                table: "dbClassification",
                column: "ClassificationStatusId",
                principalTable: "dbClassificationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLanguage_dbClassification_ClassificationId",
                table: "dbClassificationLanguage",
                column: "ClassificationId",
                principalTable: "dbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbClassificationLevel_ClassificationLevelId",
                table: "dbClassificationLevelLanguage",
                column: "ClassificationLevelId",
                principalTable: "dbClassificationLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

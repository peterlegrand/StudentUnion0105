using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class test3 : Migration
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
                name: "SuContentTypeModel",
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
                    table.PrimaryKey("PK_SuContentTypeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuOrganizationStatusModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuOrganizationStatusModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuOrganizationTypeModel",
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
                    table.PrimaryKey("PK_SuOrganizationTypeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuProjectStatusModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuProjectStatusModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuContentTypeLanguageModel",
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
                    table.PrimaryKey("PK_SuContentTypeLanguageModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuContentTypeLanguageModel_SuContentTypeModel_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "SuContentTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuContentTypeLanguageModel_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuOrganizationModel",
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
                    table.PrimaryKey("PK_SuOrganizationModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuOrganizationModel_SuOrganizationStatusModel_OrganizationStatusId",
                        column: x => x.OrganizationStatusId,
                        principalTable: "SuOrganizationStatusModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuOrganizationModel_SuOrganizationTypeModel_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "SuOrganizationTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuOrganizationTypeLanguageModel",
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
                    table.PrimaryKey("PK_SuOrganizationTypeLanguageModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuOrganizationTypeLanguageModel_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuOrganizationTypeLanguageModel_SuOrganizationTypeModel_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "SuOrganizationTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuProjectModel",
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
                    table.PrimaryKey("PK_SuProjectModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuProjectModel_SuProjectStatusModel_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "SuProjectStatusModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuOrganizationLanguageModel",
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
                    table.PrimaryKey("PK_SuOrganizationLanguageModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuOrganizationLanguageModel_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuOrganizationLanguageModel_SuOrganizationModel_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "SuOrganizationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuProjectLanguageModel",
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
                    table.PrimaryKey("PK_SuProjectLanguageModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuProjectLanguageModel_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuProjectLanguageModel_SuProjectModel_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "SuProjectModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuContentTypeLanguageModel_ContentTypeId",
                table: "SuContentTypeLanguageModel",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SuContentTypeLanguageModel_LanguageId",
                table: "SuContentTypeLanguageModel",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SuOrganizationLanguageModel_LanguageId",
                table: "SuOrganizationLanguageModel",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SuOrganizationLanguageModel_OrganizationId",
                table: "SuOrganizationLanguageModel",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_SuOrganizationModel_OrganizationStatusId",
                table: "SuOrganizationModel",
                column: "OrganizationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SuOrganizationModel_OrganizationTypeId",
                table: "SuOrganizationModel",
                column: "OrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SuOrganizationTypeLanguageModel_LanguageId",
                table: "SuOrganizationTypeLanguageModel",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SuOrganizationTypeLanguageModel_OrganizationTypeId",
                table: "SuOrganizationTypeLanguageModel",
                column: "OrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SuProjectLanguageModel_LanguageId",
                table: "SuProjectLanguageModel",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SuProjectLanguageModel_ProjectId",
                table: "SuProjectLanguageModel",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SuProjectModel_ProjectStatusId",
                table: "SuProjectModel",
                column: "ProjectStatusId");

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
                name: "SuContentTypeLanguageModel");

            migrationBuilder.DropTable(
                name: "SuOrganizationLanguageModel");

            migrationBuilder.DropTable(
                name: "SuOrganizationTypeLanguageModel");

            migrationBuilder.DropTable(
                name: "SuProjectLanguageModel");

            migrationBuilder.DropTable(
                name: "SuContentTypeModel");

            migrationBuilder.DropTable(
                name: "SuOrganizationModel");

            migrationBuilder.DropTable(
                name: "SuProjectModel");

            migrationBuilder.DropTable(
                name: "SuOrganizationStatusModel");

            migrationBuilder.DropTable(
                name: "SuOrganizationTypeModel");

            migrationBuilder.DropTable(
                name: "SuProjectStatusModel");

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

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassification_dbClassificationStatus_ClassificationStatusId",
                table: "dbClassification",
                column: "ClassificationStatusId",
                principalTable: "dbClassificationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLanguage_dbClassification_ClassificationId",
                table: "dbClassificationLanguage",
                column: "ClassificationId",
                principalTable: "dbClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbClassificationLevelLanguage_dbClassificationLevel_ClassificationLevelId",
                table: "dbClassificationLevelLanguage",
                column: "ClassificationLevelId",
                principalTable: "dbClassificationLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

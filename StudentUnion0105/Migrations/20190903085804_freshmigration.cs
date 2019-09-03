using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class freshmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp_classvaluestructure = @"CREATE PROCEDURE ClassificationValueStructure (@Language Int, @ClassificationId Int )
                                        AS 
                                        WITH StructureClassValue (ParentId, Id, Name, Level, Path)
                                        AS
                                        (
                                    	    SELECT v.ParentValueId
                                        		, v.Id
                                        		, l.ClassificationValueName
                                        		, 0 AS level
                                        		, CAST(v.Id AS VARCHAR(255)) AS Path
                                        	FROM dbClassificationValue AS v
                                        	JOIN dbClassificationValueLanguage AS l
                                        		ON v.Id = l.ClassificationValueId
                                        	WHERE v.ParentValueId IS NULL
                                        		AND l.LanguageId = @Language
                                        		AND v.ClassificationId = @ClassificationId
                                        	UNION ALL
                                        	SELECT v.ParentValueId
                                        		, v.Id
                                        		, l.ClassificationValueName
                                        		, level + 1
                                        		, CAST(s.Path + '.' + CAST(v.Id AS VARCHAR(255)) AS VARCHAR(255))
                                        	FROM dbClassificationValue AS v
                                        	JOIN dbClassificationValueLanguage AS l
                                        		ON v.Id = l.ClassificationValueId
                                        	JOIN StructureClassValue s
                                        		ON s.Id = v.ParentValueId
                                        	WHERE l.LanguageId = @Language
                                        	AND v.ClassificationId = @ClassificationId
                                        	)

                                        	SELECT ISNULL(ParentId,0) ParentId
                                        	, Id, Name, Level, Path
                                        	FROM StructureClassValue ORDER BY Path
                                        GO	
                                        ";
            migrationBuilder.Sql(sp_classvaluestructure);

            var sp_orgstructure = @"CREATE PROCEDURE [OrgStructure] (@Language Int )
                                    AS 
                                    WITH StructureOrg (ParentId, Id, Name, Level, Path)
                                    AS
                                    (
                                    	SELECT o.ParentOrganizationId
                                    		, o.Id
                                    		, l.Name
                                    		, 0 AS level
                                    		, CAST(o.Id AS VARCHAR(255)) AS Path
                                    	FROM dbOrganization AS o
                                    	JOIN dbOrganizationLanguage AS l
                                    		ON o.Id = l.OrganizationId
                                    	WHERE o.ParentOrganizationId IS NULL
                                    		AND l.LanguageId = @Language
                                    	UNION ALL
                                    	SELECT o.ParentOrganizationId
                                    		, o.Id
                                    		, l.Name
                                    		, level + 1
                                    		, CAST(s.Path + '.' + CAST(o.Id AS VARCHAR(255)) AS VARCHAR(255))
                                    	FROM dbOrganization AS o
                                    	JOIN dbOrganizationLanguage AS l
                                    		ON o.Id = l.OrganizationId
                                    	JOIN StructureOrg s
                                    		ON s.Id = o.ParentOrganizationId
                                    	WHERE l.LanguageId = @Language
                                    	)

                                    	SELECT ISNULL(ParentId,0) ParentId
                                    	, Id, Name, Level, Path
                                    	FROM StructureOrg ORDER BY Path
                                    GO
                                    ";
            migrationBuilder.Sql(sp_orgstructure);

            var sp_projstructure = @"CREATE PROCEDURE [dbo].[ProjStructure] (@Language Int )
                                    AS 
                                    WITH StructureProj (ParentId, Id, Name, Level, Path)
                                    AS
                                    (
                                    	SELECT p.ParentProjectId
                                    		, p.Id
                                    		, l.Name
                                    		, 0 AS level
                                    		, CAST(p.Id AS VARCHAR(255)) AS Path
                                    	FROM dbProject AS p
                                    	JOIN dbProjectLanguage AS l
                                    		ON p.Id = l.ProjectId
                                    	WHERE p.ParentProjectId IS NULL
                                    		AND l.LanguageId = @Language
                                    	UNION ALL
                                    	SELECT p.ParentProjectId
                                    		, p.Id
                                    		, l.Name
                                    		, level + 1
                                    		, CAST(s.Path + '.' + CAST(p.Id AS VARCHAR(255)) AS VARCHAR(255))
                                    	FROM dbProject AS p
                                    	JOIN dbProjectLanguage AS l
                                    		ON p.Id = l.ProjectId
                                    	JOIN StructureProj s
                                    		ON s.Id = p.ParentProjectId
                                    	WHERE l.LanguageId = @Language
                                    	)

                                    	SELECT ISNULL(ParentId,0) ParentId
                                    	, Id, Name, Level, Path
                                    	FROM StructureProj ORDER BY Path
                                    GO
                                    ";
            migrationBuilder.Sql(sp_projstructure);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    DefaultLangauge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimGroup = table.Column<string>(nullable: true),
                    Claim = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbClassificationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClassificationStatus", x => x.Id);
                });

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
                name: "dbGetOrganizationStructure",
                columns: table => new
                {
                    Path = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbGetOrganizationStructure", x => x.Path);
                });

            migrationBuilder.CreateTable(
                name: "dbLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageName = table.Column<string>(maxLength: 50, nullable: false),
                    ForeignName = table.Column<string>(nullable: true),
                    ISO6391 = table.Column<string>(nullable: true),
                    ISO6392 = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbLanguage", x => x.Id);
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
                name: "dbPageStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPageStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbPageType",
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
                    table.PrimaryKey("PK_dbPageType", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "SuPageSectionTypeModel",
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
                    table.PrimaryKey("PK_SuPageSectionTypeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbClassification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationStatusId = table.Column<int>(nullable: false),
                    DefailClassificationPageId = table.Column<int>(nullable: false),
                    HasDropDown = table.Column<bool>(nullable: false),
                    DropDownSequence = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClassification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbClassification_dbClassificationStatus_ClassificationStatusId",
                        column: x => x.ClassificationStatusId,
                        principalTable: "dbClassificationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbContentTypeLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbOrganization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentOrganizationId = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbOrganization_dbOrganizationType_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "dbOrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbOrganization_dbOrganization_ParentOrganizationId",
                        column: x => x.ParentOrganizationId,
                        principalTable: "dbOrganization",
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbOrganizationTypeLanguage_dbOrganizationType_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "dbOrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbPage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageStatusId = table.Column<int>(nullable: false),
                    PageTypeId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbPage_dbPageStatus_PageStatusId",
                        column: x => x.PageStatusId,
                        principalTable: "dbPageStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbPage_dbPageType_PageTypeId",
                        column: x => x.PageTypeId,
                        principalTable: "dbPageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbPageTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageTypeId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_dbPageTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbPageTypeLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbPageTypeLanguage_dbPageType_PageTypeId",
                        column: x => x.PageTypeId,
                        principalTable: "dbPageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuPageSectionTypeLanguageModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageSectionTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    PageTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuPageSectionTypeLanguageModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuPageSectionTypeLanguageModel_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuPageSectionTypeLanguageModel_SuPageSectionTypeModel_PageTypeId",
                        column: x => x.PageTypeId,
                        principalTable: "SuPageSectionTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbClassificationLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ClassificationName = table.Column<string>(nullable: true),
                    ClassificationMenuName = table.Column<string>(nullable: true),
                    ClassificationMouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClassificationLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbClassificationLanguage_dbClassification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "dbClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbClassificationLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbClassificationLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    DateLevel = table.Column<bool>(nullable: false),
                    OnTheFly = table.Column<bool>(nullable: false),
                    Alphabetically = table.Column<bool>(nullable: false),
                    CanLink = table.Column<bool>(nullable: false),
                    InDropDown = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClassificationLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbClassificationLevel_dbClassification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "dbClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbClassificationValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationId = table.Column<int>(nullable: false),
                    ParentValueId = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTimeOffset>(nullable: false),
                    DateTo = table.Column<DateTimeOffset>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ClassificationLevelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClassificationValue", x => x.Id);
                    table.ForeignKey(
                        name: "FKClassificationValues",
                        column: x => x.ClassificationId,
                        principalTable: "dbClassification",
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbOrganizationLanguage_dbOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "dbOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbPageLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    PageTitle = table.Column<string>(nullable: true),
                    PageDescription = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPageLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbPageLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbPageLanguage_dbPage_PageId",
                        column: x => x.PageId,
                        principalTable: "dbPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuPageSectionModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    PageSectionTypeId = table.Column<int>(nullable: false),
                    ShowSectionTitle = table.Column<bool>(nullable: false),
                    ShowSectionTitleDescription = table.Column<bool>(nullable: false),
                    ShowContentTypeTitle = table.Column<bool>(nullable: false),
                    ShowContentTypeDescription = table.Column<bool>(nullable: false),
                    OneTwoColumns = table.Column<int>(nullable: false),
                    ContentTypeId = table.Column<int>(nullable: false),
                    SortById = table.Column<int>(nullable: false),
                    MaxContent = table.Column<int>(nullable: false),
                    HasPaging = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuPageSectionModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuPageSectionModel_dbContentType_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "dbContentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuPageSectionModel_dbPage_PageId",
                        column: x => x.PageId,
                        principalTable: "dbPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuPageSectionModel_SuPageSectionTypeModel_PageSectionTypeId",
                        column: x => x.PageSectionTypeId,
                        principalTable: "SuPageSectionTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbProjectLanguage_dbProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "dbProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbClassificationLevelLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationLevelId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ClassificationLevelName = table.Column<string>(nullable: true),
                    ClassificationLevelMenuName = table.Column<string>(nullable: true),
                    ClassificationLevelMouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClassificationLevelLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbClassificationLevelLanguage_dbClassificationLevel_ClassificationLevelId",
                        column: x => x.ClassificationLevelId,
                        principalTable: "dbClassificationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbClassificationLevelLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbClassificationValueLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationValueId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ClassificationValueName = table.Column<string>(nullable: true),
                    ClassificationValueDescription = table.Column<string>(nullable: true),
                    ClassificationValueDropDownName = table.Column<string>(nullable: true),
                    ClassificationValueMenuName = table.Column<string>(nullable: true),
                    ClassificationValueMouseOver = table.Column<string>(nullable: true),
                    ClassificationValuePageName = table.Column<string>(nullable: true),
                    ClassificationValuePageDescription = table.Column<string>(nullable: true),
                    ClassificationValueHeaderName = table.Column<string>(nullable: true),
                    ClassificationValueHeaderDescription = table.Column<string>(nullable: true),
                    ClassificationValueTopicName = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClassificationValueLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbClassificationValueLanguage_dbClassificationValue_ClassificationValueId",
                        column: x => x.ClassificationValueId,
                        principalTable: "dbClassificationValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbClassificationValueLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuPageSectionLanguageModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageSectionId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    PageSectionName = table.Column<string>(nullable: true),
                    PageSectionDescription = table.Column<string>(nullable: true),
                    PageSectionTitle = table.Column<string>(nullable: true),
                    PageSectionTitleDescription = table.Column<string>(nullable: true),
                    PageSectionMouseOver = table.Column<string>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    PageLanguageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuPageSectionLanguageModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuPageSectionLanguageModel_dbLanguage_PageLanguageId",
                        column: x => x.PageLanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SuPageSectionLanguageModel_SuPageSectionModel_PageSectionId",
                        column: x => x.PageSectionId,
                        principalTable: "SuPageSectionModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc1c0b27-8d91-4c65-824b-9e1915ce2b28", "53cee3b0-cdce-4650-8543-9312b31f49c6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "dbClaim",
                columns: new[] { "Id", "Claim", "ClaimGroup" },
                values: new object[,]
                {
                    { 1, "Classification", "Classification" },
                    { 3, "ClassificationPage", "Classification" },
                    { 4, "Roles", "Administration" },
                    { 2, "ClassificationLevel", "Classification" }
                });

            migrationBuilder.InsertData(
                table: "dbClassificationStatus",
                columns: new[] { "Id", "ClassificationStatusName" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" }
                });

            migrationBuilder.InsertData(
                table: "dbLanguage",
                columns: new[] { "Id", "Active", "ForeignName", "ISO6391", "ISO6392", "LanguageName" },
                values: new object[,]
                {
                    { 119, false, "", "oj", "oji", "Ojibwa" },
                    { 120, false, "", "cu", "chu", "Old Slavonic, Old Bulgarian" },
                    { 121, false, "", "om", "orm", "Oromo" },
                    { 122, false, "", "or", "ori", "Oriya" },
                    { 123, false, "", "os", "oss", "Ossetian, Ossetic" },
                    { 124, false, "", "pa", "pan", "Punjabi, Panjabi" },
                    { 125, false, "", "pi", "pli", "Pali" },
                    { 126, false, "", "fa", "fas", "Persian" },
                    { 127, false, "", "pl", "pol", "Polish" },
                    { 131, false, "", "rm", "roh", "Romansh" },
                    { 129, false, "", "pt", "por", "Portuguese" },
                    { 130, false, "", "qu", "que", "Quechua" },
                    { 118, false, "", "oc", "oci", "Occitan" },
                    { 132, false, "", "rn", "run", "Rundi" },
                    { 133, false, "", "ro", "ron", "Romanian, Moldavian, Moldovan" },
                    { 134, false, "", "ru", "rus", "Russian" },
                    { 135, false, "", "sa", "san", "Sanskrit" },
                    { 136, false, "", "sc", "srd", "Sardinian" },
                    { 137, false, "", "sd", "snd", "Sindhi" },
                    { 128, false, "", "ps", "pus", "Pashto, Pushto" },
                    { 117, false, "", "nr", "nbl", "South Ndebele" },
                    { 113, false, "", "nb", "nob", "Norwegian Bokmål" },
                    { 115, false, "", "no", "nor", "Norwegian" },
                    { 95, false, "", "lt", "lit", "Lithuanian" },
                    { 96, false, "", "lu", "lub", "Luba-Katanga" },
                    { 97, false, "", "lv", "lav", "Latvian" },
                    { 98, false, "", "gv", "glv", "Manx" },
                    { 99, false, "", "mk", "mkd", "Macedonian" },
                    { 100, false, "", "mg", "mlg", "Malagasy" },
                    { 101, false, "", "ms", "msa", "Malay" },
                    { 102, false, "", "ml", "mal", "Malayalam" },
                    { 103, false, "", "mt", "mlt", "Maltese" },
                    { 116, false, "", "ii", "iii", "Sichuan Yi, Nuosu" },
                    { 104, false, "", "mi", "mri", "Maori" },
                    { 106, false, "", "mh", "mah", "Marshallese" },
                    { 107, false, "", "mn", "mon", "Mongolian" },
                    { 108, false, "", "na", "nau", "Nauru" },
                    { 109, false, "", "nv", "nav", "Navajo, Navaho" },
                    { 110, false, "", "nd", "nde", "North Ndebele" },
                    { 111, false, "", "ne", "nep", "Nepali" },
                    { 112, false, "", "ng", "ndo", "Ndonga" },
                    { 138, false, "", "se", "sme", "Northern Sami" },
                    { 114, false, "", "nn", "nno", "Norwegian Nynorsk" },
                    { 105, false, "", "mr", "mar", "Marathi" },
                    { 139, false, "", "sm", "smo", "Samoan" },
                    { 142, false, "", "gd", "gla", "Gaelic, Scottish Gaelic" },
                    { 141, false, "", "sr", "srp", "Serbian" },
                    { 166, false, "", "tt", "tat", "Tatar" },
                    { 167, false, "", "tw", "twi", "Twi" },
                    { 168, false, "", "ty", "tah", "Tahitian" },
                    { 169, false, "", "ug", "uig", "Uighur, Uyghur" },
                    { 170, false, "", "uk", "ukr", "Ukrainian" },
                    { 171, false, "", "ur", "urd", "Urdu" },
                    { 172, false, "", "uz", "uzb", "Uzbek" },
                    { 173, false, "", "ve", "ven", "Venda" },
                    { 174, false, "", "vi", "vie", "Vietnamese" },
                    { 175, false, "", "vo", "vol", "Volapük" },
                    { 176, false, "", "wa", "wln", "Walloon" },
                    { 177, false, "", "cy", "cym", "Welsh" },
                    { 178, false, "", "wo", "wol", "Wolof" },
                    { 179, false, "", "fy", "fry", "Western Frisian" },
                    { 180, false, "", "xh", "xho", "Xhosa" },
                    { 181, false, "", "yi", "yid", "Yiddish" },
                    { 182, false, "", "yo", "yor", "Yoruba" },
                    { 183, false, "", "za", "zha", "Zhuang, Chuang" },
                    { 184, false, "", "zu", "zul", "Zulu" },
                    { 165, false, "", "ts", "tso", "Tsonga" },
                    { 164, false, "", "tr", "tur", "Turkish" },
                    { 163, false, "", "to", "ton", "Tonga (Tonga Islands)" },
                    { 162, false, "", "tn", "tsn", "Tswana" },
                    { 94, false, "", "lo", "lao", "Lao" },
                    { 143, false, "", "sn", "sna", "Shona" },
                    { 144, false, "", "si", "sin", "Sinhala, Sinhalese" },
                    { 145, false, "", "sk", "slk", "Slovak" },
                    { 146, false, "", "sl", "slv", "Slovenian" },
                    { 147, false, "", "so", "som", "Somali" },
                    { 148, false, "", "st", "sot", "Southern Sotho" },
                    { 149, false, "", "es", "spa", "Spanish, Castilian" },
                    { 150, false, "", "su", "sun", "Sundanese" },
                    { 140, false, "", "sg", "sag", "Sango" },
                    { 151, false, "", "sw", "swa", "Swahili" },
                    { 153, false, "", "sv", "swe", "Swedish" },
                    { 154, false, "", "ta", "tam", "Tamil" },
                    { 155, false, "", "te", "tel", "Telugu" },
                    { 156, false, "", "tg", "tgk", "Tajik" },
                    { 157, true, "", "th", "tha", "Thai" },
                    { 158, false, "", "ti", "tir", "Tigrinya" },
                    { 159, false, "", "bo", "bod", "Tibetan" },
                    { 160, false, "", "tk", "tuk", "Turkmen" },
                    { 161, false, "", "tl", "tgl", "Tagalog" },
                    { 152, false, "", "ss", "ssw", "Swati" },
                    { 93, false, "", "ln", "lin", "Lingala" },
                    { 92, false, "", "li", "lim", "Limburgan, Limburger, Limburgish" },
                    { 91, false, "", "lg", "lug", "Ganda" },
                    { 24, false, "", "bg", "bul", "Bulgarian" },
                    { 25, false, "", "my", "mya", "Burmese" },
                    { 26, false, "", "ca", "cat", "Catalan, Valencian" },
                    { 27, false, "", "ch", "cha", "Chamorro" },
                    { 28, false, "", "ce", "che", "Chechen" },
                    { 29, false, "", "ny", "nya", "Chichewa, Chewa, Nyanja" },
                    { 30, false, "", "zh", "zho", "Chinese" },
                    { 31, false, "", "cv", "chv", "Chuvash" },
                    { 32, false, "", "kw", "cor", "Cornish" },
                    { 33, false, "", "co", "cos", "Corsican" },
                    { 34, false, "", "cr", "cre", "Cree" },
                    { 35, false, "", "hr", "hrv", "Croatian" },
                    { 36, false, "", "cs", "ces", "Czech" },
                    { 37, false, "", "da", "dan", "Danish" },
                    { 38, false, "", "dv", "div", "Divehi, Dhivehi, Maldivian" },
                    { 39, true, "", "nl", "nld", "Dutch, Flemish" },
                    { 40, false, "", "dz", "dzo", "Dzongkha" },
                    { 41, true, "", "en", "eng", "English" },
                    { 42, false, "", "eo", "epo", "Esperanto" },
                    { 23, false, "", "br", "bre", "Breton" },
                    { 44, false, "", "ee", "ewe", "Ewe" },
                    { 22, false, "", "bs", "bos", "Bosnian" },
                    { 20, false, "", "bh", "bih", "Bihari languages" },
                    { 1, false, "", "ab", "abk", "Abkhazian" },
                    { 2, false, "", "aa", "aar", "Afar" },
                    { 3, false, "", "af", "afr", "Afrikaans" },
                    { 4, false, "", "ak", "aka", "Akan" },
                    { 5, false, "", "sq", "sqi", "Albanian" },
                    { 6, false, "", "am", "amh", "Amharic" },
                    { 7, false, "", "ar", "ara", "Arabic" },
                    { 8, false, "", "an", "arg", "Aragonese" },
                    { 9, false, "", "hy", "hye", "Armenian" },
                    { 10, false, "", "as", "asm", "Assamese" },
                    { 11, false, "", "av", "ava", "Avaric" },
                    { 12, false, "", "ae", "ave", "Avestan" },
                    { 13, false, "", "ay", "aym", "Aymara" },
                    { 14, false, "", "az", "aze", "Azerbaijani" },
                    { 15, false, "", "bm", "bam", "Bambara" },
                    { 16, false, "", "ba", "bak", "Bashkir" },
                    { 17, false, "", "eu", "eus", "Basque" },
                    { 18, false, "", "be", "bel", "Belarusian" },
                    { 19, false, "", "bn", "ben", "Bengali" },
                    { 21, false, "", "bi", "bis", "Bislama" },
                    { 45, false, "", "fo", "fao", "Faroese" },
                    { 43, false, "", "et", "est", "Estonian" },
                    { 47, false, "", "fi", "fin", "Finnish" },
                    { 46, false, "", "fj", "fij", "Fijian" },
                    { 72, false, "", "iu", "iku", "Inuktitut" },
                    { 73, false, "", "ja", "jpn", "Japanese" },
                    { 74, false, "", "jv", "jav", "Javanese" },
                    { 75, false, "", "kl", "kal", "Kalaallisut, Greenlandic" },
                    { 76, false, "", "kn", "kan", "Kannada" },
                    { 77, false, "", "kr", "kau", "Kanuri" },
                    { 78, false, "", "ks", "kas", "Kashmiri" },
                    { 79, false, "", "kk", "kaz", "Kazakh" },
                    { 70, false, "", "is", "isl", "Icelandic" },
                    { 80, false, "", "km", "khm", "Central Khmer" },
                    { 82, false, "", "rw", "kin", "Kinyarwanda" },
                    { 83, false, "", "ky", "kir", "Kirghiz, Kyrgyz" },
                    { 84, false, "", "kv", "kom", "Komi" },
                    { 85, false, "", "kg", "kon", "Kongo" },
                    { 86, false, "", "ko", "kor", "Korean" },
                    { 87, false, "", "ku", "kur", "Kurdish" },
                    { 88, false, "", "kj", "kua", "Kuanyama, Kwanyama" },
                    { 89, false, "", "la", "lat", "Latin" },
                    { 90, false, "", "lb", "ltz", "Luxembourgish, Letzeburgesch" },
                    { 81, false, "", "ki", "kik", "Kikuyu, Gikuyu" },
                    { 69, false, "", "io", "ido", "Ido" },
                    { 71, false, "", "it", "ita", "Italian" },
                    { 67, false, "", "ig", "ibo", "Igbo" },
                    { 48, false, "", "fr", "fra", "French" },
                    { 49, false, "", "ff", "ful", "Fulah" },
                    { 50, false, "", "gl", "glg", "Galician" },
                    { 51, false, "", "ka", "kat", "Georgian" },
                    { 52, false, "", "de", "deu", "German" },
                    { 53, false, "", "el", "ell", "Greek, Modern (1453-)" },
                    { 68, false, "", "ik", "ipk", "Inupiaq" },
                    { 55, false, "", "gu", "guj", "Gujarati" },
                    { 56, false, "", "ht", "hat", "Haitian, Haitian Creole" },
                    { 54, false, "", "gn", "grn", "Guarani" },
                    { 58, false, "", "he", "heb", "Hebrew" },
                    { 59, false, "", "hz", "her", "Herero" },
                    { 60, false, "", "hi", "hin", "Hindi" },
                    { 61, false, "", "ho", "hmo", "Hiri Motu" },
                    { 62, false, "", "hu", "hun", "Hungarian" },
                    { 63, false, "", "ia", "ina", "Interlingua" },
                    { 64, false, "", "id", "ind", "Indonesian" },
                    { 65, false, "", "ie", "ile", "Interlingue, Occidental" },
                    { 57, false, "", "ha", "hau", "Hausa" },
                    { 66, false, "", "ga", "gle", "Irish" }
                });

            migrationBuilder.InsertData(
                table: "dbOrganizationStatus",
                columns: new[] { "Id", "OrganizationStatusName" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" }
                });

            migrationBuilder.InsertData(
                table: "dbPageStatus",
                columns: new[] { "Id", "PageStatusName" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" }
                });

            migrationBuilder.InsertData(
                table: "dbProjectStatus",
                columns: new[] { "Id", "ProjectStatusName" },
                values: new object[,]
                {
                    { 2, "Inactive" },
                    { 1, "Active" }
                });

            migrationBuilder.InsertData(
                table: "dbSetting",
                columns: new[] { "Id", "DateTimeValue", "GuidValue", "IntValue", "SettingDescription", "SettingName", "StringValue" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), 41, null, "Dedault language", null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassification_ClassificationStatusId",
                table: "dbClassification",
                column: "ClassificationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationLanguage_ClassificationId",
                table: "dbClassificationLanguage",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationLanguage_LanguageId",
                table: "dbClassificationLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationLevel_ClassificationId",
                table: "dbClassificationLevel",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationLevelLanguage_ClassificationLevelId",
                table: "dbClassificationLevelLanguage",
                column: "ClassificationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationLevelLanguage_LanguageId",
                table: "dbClassificationLevelLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationValue_ClassificationId",
                table: "dbClassificationValue",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationValueLanguage_ClassificationValueId",
                table: "dbClassificationValueLanguage",
                column: "ClassificationValueId");

            migrationBuilder.CreateIndex(
                name: "IX_dbClassificationValueLanguage_LanguageId",
                table: "dbClassificationValueLanguage",
                column: "LanguageId");

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
                name: "IX_dbOrganization_ParentOrganizationId",
                table: "dbOrganization",
                column: "ParentOrganizationId");

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
                name: "IX_dbPage_PageStatusId",
                table: "dbPage",
                column: "PageStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPage_PageTypeId",
                table: "dbPage",
                column: "PageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageLanguage_LanguageId",
                table: "dbPageLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageLanguage_PageId",
                table: "dbPageLanguage",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageTypeLanguage_LanguageId",
                table: "dbPageTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageTypeLanguage_PageTypeId",
                table: "dbPageTypeLanguage",
                column: "PageTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SuPageSectionLanguageModel_PageLanguageId",
                table: "SuPageSectionLanguageModel",
                column: "PageLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SuPageSectionLanguageModel_PageSectionId",
                table: "SuPageSectionLanguageModel",
                column: "PageSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SuPageSectionModel_ContentTypeId",
                table: "SuPageSectionModel",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SuPageSectionModel_PageId",
                table: "SuPageSectionModel",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_SuPageSectionModel_PageSectionTypeId",
                table: "SuPageSectionModel",
                column: "PageSectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SuPageSectionTypeLanguageModel_LanguageId",
                table: "SuPageSectionTypeLanguageModel",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SuPageSectionTypeLanguageModel_PageTypeId",
                table: "SuPageSectionTypeLanguageModel",
                column: "PageTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "dbClaim");

            migrationBuilder.DropTable(
                name: "dbClassificationLanguage");

            migrationBuilder.DropTable(
                name: "dbClassificationLevelLanguage");

            migrationBuilder.DropTable(
                name: "dbClassificationValueLanguage");

            migrationBuilder.DropTable(
                name: "dbContentTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbGetOrganizationStructure");

            migrationBuilder.DropTable(
                name: "dbOrganizationLanguage");

            migrationBuilder.DropTable(
                name: "dbOrganizationTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbPageLanguage");

            migrationBuilder.DropTable(
                name: "dbPageTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbProjectLanguage");

            migrationBuilder.DropTable(
                name: "dbSetting");

            migrationBuilder.DropTable(
                name: "SuPageSectionLanguageModel");

            migrationBuilder.DropTable(
                name: "SuPageSectionTypeLanguageModel");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "dbClassificationLevel");

            migrationBuilder.DropTable(
                name: "dbClassificationValue");

            migrationBuilder.DropTable(
                name: "dbOrganization");

            migrationBuilder.DropTable(
                name: "dbProject");

            migrationBuilder.DropTable(
                name: "SuPageSectionModel");

            migrationBuilder.DropTable(
                name: "dbLanguage");

            migrationBuilder.DropTable(
                name: "dbClassification");

            migrationBuilder.DropTable(
                name: "dbOrganizationStatus");

            migrationBuilder.DropTable(
                name: "dbOrganizationType");

            migrationBuilder.DropTable(
                name: "dbProjectStatus");

            migrationBuilder.DropTable(
                name: "dbContentType");

            migrationBuilder.DropTable(
                name: "dbPage");

            migrationBuilder.DropTable(
                name: "SuPageSectionTypeModel");

            migrationBuilder.DropTable(
                name: "dbClassificationStatus");

            migrationBuilder.DropTable(
                name: "dbPageStatus");

            migrationBuilder.DropTable(
                name: "dbPageType");
        }
    }
}

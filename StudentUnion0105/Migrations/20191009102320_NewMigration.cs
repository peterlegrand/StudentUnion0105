using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Claim = table.Column<string>(nullable: true),
                    ClaimType = table.Column<string>(nullable: true)
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
                    ClassificationStatusName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbClassificationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbContentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentStatusName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbContentStatus", x => x.Id);
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
                name: "dbCountry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: false),
                    ForeignName = table.Column<string>(nullable: true),
                    ISO31662 = table.Column<string>(nullable: true),
                    ISO31663 = table.Column<string>(nullable: true),
                    ISO3166Num = table.Column<int>(nullable: false),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbDataType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataTypeName = table.Column<string>(maxLength: 50, nullable: true),
                    DataTypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbDataType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbGetClassificationValueStructure",
                columns: table => new
                {
                    Path = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    ClassificationValueName = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbGetClassificationValueStructure", x => x.Path);
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
                name: "dbGetProjectStructure",
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
                    table.PrimaryKey("PK_dbGetProjectStructure", x => x.Path);
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
                name: "dbLanguageList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbLanguageList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbMasterList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MasterListName = table.Column<string>(nullable: true),
                    MasterListDescription = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbMasterList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbOrganizationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationStatusName = table.Column<string>(maxLength: 50, nullable: true)
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
                name: "dbPageSectionsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    ShowSectionTitle = table.Column<bool>(nullable: false),
                    ShowSectionTitleDescription = table.Column<bool>(nullable: false),
                    ShowContentTypeTitle = table.Column<bool>(nullable: false),
                    ShowContentTypeDescription = table.Column<bool>(nullable: false),
                    OneTwoColumns = table.Column<int>(nullable: false),
                    ContentTypeId = table.Column<int>(nullable: true),
                    SortById = table.Column<int>(nullable: false),
                    MaxContent = table.Column<int>(nullable: false),
                    HasPaging = table.Column<bool>(nullable: false),
                    PageSectionTitle = table.Column<string>(maxLength: 50, nullable: true),
                    PageSectionDescription = table.Column<string>(nullable: true),
                    IndexSection = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPageSectionsViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbPageSectionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IndexSection = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPageSectionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbPageStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageStatusName = table.Column<string>(maxLength: 50, nullable: true)
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
                name: "dbProcessTemplateFieldType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFieldType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFlowConditionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConditionTypeName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFlowConditionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sequence = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateStepFieldStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateStepFieldStatus", x => x.Id);
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
                name: "dbSecurityLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbSecurityLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbSecurityLevelList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbSecurityLevelList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IntValue = table.Column<int>(nullable: true),
                    StringValue = table.Column<string>(nullable: true),
                    DateTimeValue = table.Column<DateTime>(nullable: true),
                    GuidValue = table.Column<Guid>(nullable: true),
                    SettingName = table.Column<string>(nullable: true),
                    SettingDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbStatusList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbStatusList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbTypeList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbTypeList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbValueList",
                columns: table => new
                {
                    ClassificationValueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationValueName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbValueList", x => x.ClassificationValueId);
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbClassification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationStatusId = table.Column<int>(nullable: false),
                    DefaultClassificationPageId = table.Column<int>(nullable: false),
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
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbContentTypeLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbOrganization_dbOrganizationType_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "dbOrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbOrganizationTypeLanguage_dbOrganizationType_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "dbOrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbPageSectionTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageSectionTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    PageTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPageSectionTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbPageSectionTypeLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbPageSectionTypeLanguage_dbPageSectionType_PageTypeId",
                        column: x => x.PageTypeId,
                        principalTable: "dbPageSectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbPage_dbPageType_PageTypeId",
                        column: x => x.PageTypeId,
                        principalTable: "dbPageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbPageTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbPageTypeLanguage_dbPageType_PageTypeId",
                        column: x => x.PageTypeId,
                        principalTable: "dbPageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFieldTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FieldTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFieldTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFieldTypeLanguage_dbPageType_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "dbPageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFieldTypeLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateGroupId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplate_dbProcessTemplateGroup_ProcessTemplateGroupId",
                        column: x => x.ProcessTemplateGroupId,
                        principalTable: "dbProcessTemplateGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateGroupLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateGroupId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ProcessTemplateGroupName = table.Column<string>(maxLength: 50, nullable: true),
                    ProcessTemplateGroupDescription = table.Column<string>(nullable: true),
                    ProcessTemplateGroupMouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    SuProcessTemplateGroupModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateGroupLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateGroupLanguage_dbProcessTemplateGroup_SuProcessTemplateGroupModelId",
                        column: x => x.SuProcessTemplateGroupModelId,
                        principalTable: "dbProcessTemplateGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ProcessTemplateName = table.Column<string>(maxLength: 50, nullable: true),
                    ProcessTemplateDescription = table.Column<string>(maxLength: 50, nullable: true),
                    ProcessTemplateMouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ProcessTemplateGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateLanguage_dbProcessTemplateGroup_ProcessTemplateGroupId",
                        column: x => x.ProcessTemplateGroupId,
                        principalTable: "dbProcessTemplateGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbProject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentProjectId = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbClassificationLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ClassificationName = table.Column<string>(maxLength: 50, nullable: true),
                    ClassificationDescription = table.Column<string>(nullable: true),
                    ClassificationMenuName = table.Column<string>(maxLength: 50, nullable: true),
                    ClassificationMouseOver = table.Column<string>(maxLength: 50, nullable: true),
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbClassificationLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    DateLevel = table.Column<int>(nullable: false),
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
                    DateFrom = table.Column<DateTimeOffset>(nullable: true),
                    DateTo = table.Column<DateTimeOffset>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
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
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbOrganizationLanguage_dbOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "dbOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbPageLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    PageTitle = table.Column<string>(maxLength: 50, nullable: true),
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbPageLanguage_dbPage_PageId",
                        column: x => x.PageId,
                        principalTable: "dbPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbPageSection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    PageSectionTypeId = table.Column<int>(nullable: false),
                    ShowSectionTitle = table.Column<bool>(maxLength: 50, nullable: false),
                    ShowSectionTitleDescription = table.Column<bool>(nullable: false),
                    ShowContentTypeTitle = table.Column<bool>(maxLength: 50, nullable: false),
                    ShowContentTypeDescription = table.Column<bool>(nullable: false),
                    OneTwoColumns = table.Column<int>(nullable: false),
                    ContentTypeId = table.Column<int>(nullable: true),
                    SortById = table.Column<int>(nullable: false),
                    MaxContent = table.Column<int>(nullable: false),
                    HasPaging = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPageSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbPageSection_dbContentType_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "dbContentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbPageSection_dbPage_PageId",
                        column: x => x.PageId,
                        principalTable: "dbPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbPageSection_dbPageSectionType_PageSectionTypeId",
                        column: x => x.PageSectionTypeId,
                        principalTable: "dbPageSectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateField",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateId = table.Column<int>(nullable: false),
                    FieldDataTypeId = table.Column<int>(nullable: false),
                    FieldMasterListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateField_dbDataType_FieldDataTypeId",
                        column: x => x.FieldDataTypeId,
                        principalTable: "dbDataType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateField_dbMasterList_FieldMasterListId",
                        column: x => x.FieldMasterListId,
                        principalTable: "dbMasterList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateField_dbProcessTemplate_ProcessTemplateId",
                        column: x => x.ProcessTemplateId,
                        principalTable: "dbProcessTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFlow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateId = table.Column<int>(nullable: false),
                    ProcessTemplateFromStepId = table.Column<int>(nullable: false),
                    ProcessTemplateToStepId = table.Column<int>(nullable: false),
                    ConditionRelation = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFlow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFlow_dbProcessTemplate_ProcessTemplateId",
                        column: x => x.ProcessTemplateId,
                        principalTable: "dbProcessTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateStep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateStep_dbProcessTemplate_ProcessTemplateId",
                        column: x => x.ProcessTemplateId,
                        principalTable: "dbProcessTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeId = table.Column<int>(nullable: false),
                    ContentStatusId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SecurityLevel = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    SuProcessTemplateStepFieldStatusModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbContent_dbContentStatus_ContentStatusId",
                        column: x => x.ContentStatusId,
                        principalTable: "dbContentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbContent_dbContentType_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "dbContentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbContent_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbContent_dbOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "dbOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbContent_dbProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "dbProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbContent_dbSecurityLevel_SecurityLevel",
                        column: x => x.SecurityLevel,
                        principalTable: "dbSecurityLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbContent_dbProcessTemplateStepFieldStatus_SuProcessTemplateStepFieldStatusModelId",
                        column: x => x.SuProcessTemplateStepFieldStatusModelId,
                        principalTable: "dbProcessTemplateStepFieldStatus",
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
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbProjectLanguage_dbProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "dbProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbClassificationLevelLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationLevelId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ClassificationLevelName = table.Column<string>(maxLength: 50, nullable: true),
                    ClassificationLevelMenuName = table.Column<string>(maxLength: 50, nullable: true),
                    ClassificationLevelDescription = table.Column<string>(nullable: true),
                    ClassificationLevelMouseOver = table.Column<string>(maxLength: 50, nullable: true),
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbPageSectionLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageSectionId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    PageSectionName = table.Column<string>(maxLength: 50, nullable: true),
                    PageSectionDescription = table.Column<string>(nullable: true),
                    PageSectionTitle = table.Column<string>(maxLength: 50, nullable: true),
                    PageSectionTitleDescription = table.Column<string>(nullable: true),
                    PageSectionMouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: false),
                    ModifierId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbPageSectionLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbPageSectionLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbPageSectionLanguage_dbPageSection_PageSectionId",
                        column: x => x.PageSectionId,
                        principalTable: "dbPageSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFieldLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateFieldId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ProcessTemplateFieldName = table.Column<string>(maxLength: 50, nullable: true),
                    ProcessTemplateFieldDescription = table.Column<string>(nullable: true),
                    ProcessTemplateFieldMouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFieldLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFieldLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFieldLanguage_dbProcessTemplateField_ProcessTemplateFieldId",
                        column: x => x.ProcessTemplateFieldId,
                        principalTable: "dbProcessTemplateField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFlowCondition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateFlowId = table.Column<int>(nullable: false),
                    ConditionCharacter = table.Column<string>(maxLength: 1, nullable: true),
                    ProcessTemplateConditionTypeId = table.Column<int>(nullable: false),
                    ProcessTemplateFieldId = table.Column<int>(nullable: true),
                    ComparisonOperator = table.Column<string>(nullable: true),
                    ProcessTemplateFlowConditionString = table.Column<string>(nullable: true),
                    ProcessTemplateFlowConditionInt = table.Column<int>(nullable: true),
                    ProcessTemplateFlowConditionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFlowCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFlowCondition_dbProcessTemplateFlowConditionType_ProcessTemplateConditionTypeId",
                        column: x => x.ProcessTemplateConditionTypeId,
                        principalTable: "dbProcessTemplateFlowConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFlowCondition_dbProcessTemplateFlow_ProcessTemplateFlowId",
                        column: x => x.ProcessTemplateFlowId,
                        principalTable: "dbProcessTemplateFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFlowLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlowId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFlowLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFlowLanguage_dbProcessTemplateFlow_FlowId",
                        column: x => x.FlowId,
                        principalTable: "dbProcessTemplateFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFlowLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateStepField",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StepId = table.Column<int>(nullable: false),
                    FieldId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateStepField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateStepField_dbProcessTemplateField_FieldId",
                        column: x => x.FieldId,
                        principalTable: "dbProcessTemplateField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateStepField_dbProcessTemplateStepFieldStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "dbProcessTemplateStepFieldStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateStepField_dbProcessTemplateStep_StepId",
                        column: x => x.StepId,
                        principalTable: "dbProcessTemplateStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateStepLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StepId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ProcessTemplateStepName = table.Column<string>(maxLength: 50, nullable: true),
                    ProcessTemplateStepDescription = table.Column<string>(nullable: true),
                    ProcessTemplateStepMouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateStepLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateStepLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateStepLanguage_dbProcessTemplateStep_StepId",
                        column: x => x.StepId,
                        principalTable: "dbProcessTemplateStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbContentClassificationValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentId = table.Column<int>(nullable: false),
                    ClassificationValueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbContentClassificationValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbContentClassificationValue_dbClassificationValue_ClassificationValueId",
                        column: x => x.ClassificationValueId,
                        principalTable: "dbClassificationValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbContentClassificationValue_dbContent_ContentId",
                        column: x => x.ContentId,
                        principalTable: "dbContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateFlowConditionLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlowConditionId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<Guid>(nullable: true),
                    ModifierId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateFlowConditionLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFlowConditionLanguage_dbProcessTemplateFlowCondition_FlowConditionId",
                        column: x => x.FlowConditionId,
                        principalTable: "dbProcessTemplateFlowCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateFlowConditionLanguage_dbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "dbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef498e6e-5deb-4cf5-8f13-989252542be3", "669a6594-fdf5-4a1c-8a25-7b09309bdf36", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "364d9c0a-45f6-49fb-a22d-70ddcc7cfa30", "ff2eed93-a578-4276-8605-b79253447e56", "Super admin", "SUPER ADMIN" });

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
                name: "IX_dbContent_ContentStatusId",
                table: "dbContent",
                column: "ContentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContent_ContentTypeId",
                table: "dbContent",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContent_LanguageId",
                table: "dbContent",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContent_OrganizationId",
                table: "dbContent",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContent_ProjectId",
                table: "dbContent",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContent_SecurityLevel",
                table: "dbContent",
                column: "SecurityLevel");

            migrationBuilder.CreateIndex(
                name: "IX_dbContent_SuProcessTemplateStepFieldStatusModelId",
                table: "dbContent",
                column: "SuProcessTemplateStepFieldStatusModelId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContentClassificationValue_ClassificationValueId",
                table: "dbContentClassificationValue",
                column: "ClassificationValueId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContentClassificationValue_ContentId",
                table: "dbContentClassificationValue",
                column: "ContentId");

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
                name: "IX_dbPageSection_ContentTypeId",
                table: "dbPageSection",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageSection_PageId",
                table: "dbPageSection",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageSection_PageSectionTypeId",
                table: "dbPageSection",
                column: "PageSectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageSectionLanguage_LanguageId",
                table: "dbPageSectionLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageSectionLanguage_PageSectionId",
                table: "dbPageSectionLanguage",
                column: "PageSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageSectionTypeLanguage_LanguageId",
                table: "dbPageSectionTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageSectionTypeLanguage_PageTypeId",
                table: "dbPageSectionTypeLanguage",
                column: "PageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageTypeLanguage_LanguageId",
                table: "dbPageTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbPageTypeLanguage_PageTypeId",
                table: "dbPageTypeLanguage",
                column: "PageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplate_ProcessTemplateGroupId",
                table: "dbProcessTemplate",
                column: "ProcessTemplateGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateField_FieldDataTypeId",
                table: "dbProcessTemplateField",
                column: "FieldDataTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateField_FieldMasterListId",
                table: "dbProcessTemplateField",
                column: "FieldMasterListId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateField_ProcessTemplateId",
                table: "dbProcessTemplateField",
                column: "ProcessTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFieldLanguage_LanguageId",
                table: "dbProcessTemplateFieldLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFieldLanguage_ProcessTemplateFieldId",
                table: "dbProcessTemplateFieldLanguage",
                column: "ProcessTemplateFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFieldTypeLanguage_FieldTypeId",
                table: "dbProcessTemplateFieldTypeLanguage",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFieldTypeLanguage_LanguageId",
                table: "dbProcessTemplateFieldTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlow_ProcessTemplateId",
                table: "dbProcessTemplateFlow",
                column: "ProcessTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowCondition_ProcessTemplateConditionTypeId",
                table: "dbProcessTemplateFlowCondition",
                column: "ProcessTemplateConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowCondition_ProcessTemplateFlowId",
                table: "dbProcessTemplateFlowCondition",
                column: "ProcessTemplateFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowConditionLanguage_FlowConditionId",
                table: "dbProcessTemplateFlowConditionLanguage",
                column: "FlowConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowConditionLanguage_LanguageId",
                table: "dbProcessTemplateFlowConditionLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowLanguage_FlowId",
                table: "dbProcessTemplateFlowLanguage",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateFlowLanguage_LanguageId",
                table: "dbProcessTemplateFlowLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateGroupLanguage_SuProcessTemplateGroupModelId",
                table: "dbProcessTemplateGroupLanguage",
                column: "SuProcessTemplateGroupModelId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateLanguage_LanguageId",
                table: "dbProcessTemplateLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateLanguage_ProcessTemplateGroupId",
                table: "dbProcessTemplateLanguage",
                column: "ProcessTemplateGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStep_ProcessTemplateId",
                table: "dbProcessTemplateStep",
                column: "ProcessTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepField_FieldId",
                table: "dbProcessTemplateStepField",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepField_StatusId",
                table: "dbProcessTemplateStepField",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepField_StepId",
                table: "dbProcessTemplateStepField",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepLanguage_LanguageId",
                table: "dbProcessTemplateStepLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepLanguage_StepId",
                table: "dbProcessTemplateStepLanguage",
                column: "StepId");

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
                name: "dbContentClassificationValue");

            migrationBuilder.DropTable(
                name: "dbContentTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbCountry");

            migrationBuilder.DropTable(
                name: "dbGetClassificationValueStructure");

            migrationBuilder.DropTable(
                name: "dbGetOrganizationStructure");

            migrationBuilder.DropTable(
                name: "dbGetProjectStructure");

            migrationBuilder.DropTable(
                name: "dbLanguageList");

            migrationBuilder.DropTable(
                name: "dbOrganizationLanguage");

            migrationBuilder.DropTable(
                name: "dbOrganizationTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbPageLanguage");

            migrationBuilder.DropTable(
                name: "dbPageSectionLanguage");

            migrationBuilder.DropTable(
                name: "dbPageSectionsViewModel");

            migrationBuilder.DropTable(
                name: "dbPageSectionTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbPageTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFieldLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFieldType");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFieldTypeLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFlowConditionLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFlowLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateGroupLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateStepField");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateStepLanguage");

            migrationBuilder.DropTable(
                name: "dbProjectLanguage");

            migrationBuilder.DropTable(
                name: "dbSecurityLevelList");

            migrationBuilder.DropTable(
                name: "dbSetting");

            migrationBuilder.DropTable(
                name: "dbStatusList");

            migrationBuilder.DropTable(
                name: "dbTypeList");

            migrationBuilder.DropTable(
                name: "dbValueList");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "dbClassificationLevel");

            migrationBuilder.DropTable(
                name: "dbClassificationValue");

            migrationBuilder.DropTable(
                name: "dbContent");

            migrationBuilder.DropTable(
                name: "dbPageSection");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFlowCondition");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateField");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateStep");

            migrationBuilder.DropTable(
                name: "dbClassification");

            migrationBuilder.DropTable(
                name: "dbContentStatus");

            migrationBuilder.DropTable(
                name: "dbLanguage");

            migrationBuilder.DropTable(
                name: "dbOrganization");

            migrationBuilder.DropTable(
                name: "dbProject");

            migrationBuilder.DropTable(
                name: "dbSecurityLevel");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateStepFieldStatus");

            migrationBuilder.DropTable(
                name: "dbContentType");

            migrationBuilder.DropTable(
                name: "dbPage");

            migrationBuilder.DropTable(
                name: "dbPageSectionType");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFlowConditionType");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateFlow");

            migrationBuilder.DropTable(
                name: "dbDataType");

            migrationBuilder.DropTable(
                name: "dbMasterList");

            migrationBuilder.DropTable(
                name: "dbClassificationStatus");

            migrationBuilder.DropTable(
                name: "dbOrganizationStatus");

            migrationBuilder.DropTable(
                name: "dbOrganizationType");

            migrationBuilder.DropTable(
                name: "dbProjectStatus");

            migrationBuilder.DropTable(
                name: "dbPageStatus");

            migrationBuilder.DropTable(
                name: "dbPageType");

            migrationBuilder.DropTable(
                name: "dbProcessTemplate");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateGroup");
        }
    }
}

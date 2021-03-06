﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentUnion0105.Migrations
{
    public partial class initial : Migration
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
                    DefaultLanguageId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: true),
                    SecurityLevel = table.Column<int>(nullable: false),
                    ManagerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbClaim",
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
                    table.PrimaryKey("PK_DbClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbClassificationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbClassificationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbComparison",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbComparison", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbContentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbContentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbContentTypeClassificationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbContentTypeClassificationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbContentTypeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sequence = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbContentTypeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbCountry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ForeignName = table.Column<string>(nullable: true),
                    ISO31662 = table.Column<string>(nullable: true),
                    ISO31663 = table.Column<string>(nullable: true),
                    ISO3166Num = table.Column<int>(nullable: false),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbDataType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbDataType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbIdWithStrings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbIdWithStrings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbLanguage",
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
                    table.PrimaryKey("PK_DbLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbLeftMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuName = table.Column<string>(nullable: true),
                    MainController = table.Column<string>(nullable: true),
                    MainAction = table.Column<string>(nullable: true),
                    AddController = table.Column<string>(nullable: true),
                    AddAction = table.Column<string>(nullable: true),
                    HasMenu = table.Column<bool>(nullable: false),
                    HasAdd = table.Column<bool>(nullable: false),
                    HasSearch = table.Column<bool>(nullable: false),
                    HasAdvancedSearch = table.Column<bool>(nullable: false),
                    ImageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbLeftMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbMenuType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbMenuType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbObject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Int1 = table.Column<int>(nullable: false),
                    Int2 = table.Column<int>(nullable: false),
                    IntNull1 = table.Column<int>(nullable: true),
                    IntNull2 = table.Column<int>(nullable: true),
                    Bool1 = table.Column<bool>(nullable: false),
                    Bool2 = table.Column<bool>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbObject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbObjectVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    ObjectLanguageId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    HasDropDown = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    ObjectId = table.Column<int>(nullable: false),
                    DateLevel = table.Column<int>(nullable: false),
                    OnTheFly = table.Column<bool>(nullable: false),
                    Alphabetically = table.Column<bool>(nullable: false),
                    CanLink = table.Column<bool>(nullable: false),
                    InDropDown = table.Column<bool>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    NullId = table.Column<int>(nullable: true),
                    NullId2 = table.Column<int>(nullable: true),
                    NotNullId = table.Column<int>(nullable: false),
                    NotNullId2 = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description2 = table.Column<string>(nullable: true),
                    DropDownName = table.Column<string>(nullable: true),
                    PageDescription = table.Column<string>(nullable: true),
                    HeaderName = table.Column<string>(nullable: true),
                    HeaderDescription = table.Column<string>(nullable: true),
                    TopicName = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTimeOffset>(nullable: true),
                    DateTo = table.Column<DateTimeOffset>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    IndexSection = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbObjectVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbOrganizationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbOrganizationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbOrganizationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbOrganizationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbPageSectionsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    ShowSectionTitleName = table.Column<bool>(nullable: false),
                    ShowSectionTitleDescription = table.Column<bool>(nullable: false),
                    ShowContentTypeTitle = table.Column<bool>(nullable: false),
                    ShowContentTypeDescription = table.Column<bool>(nullable: false),
                    OneTwoColumns = table.Column<int>(nullable: false),
                    ContentTypeId = table.Column<int>(nullable: true),
                    SortById = table.Column<int>(nullable: false),
                    MaxContent = table.Column<int>(nullable: false),
                    HasPaging = table.Column<bool>(nullable: false),
                    TitleName = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IndexSection = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPageSectionsViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbPageSectionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IndexSection = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPageSectionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbPageStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPageStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbPageType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessMulti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessMulti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateFieldType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateFieldType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateFlowConditionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateFlowConditionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sequence = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateStepFieldStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateStepFieldStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateStepType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateStepType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbProjectStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProjectStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbSecurityLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSecurityLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbSetting",
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
                    table.PrimaryKey("PK_DbSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbTableName",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TableName = table.Column<string>(maxLength: 50, nullable: true),
                    TableDescription = table.Column<string>(nullable: true),
                    StatusFieldName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbTableName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbUIScreen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUIScreen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbUITerm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUITerm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbUserOrganizationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUserOrganizationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbUserProjectType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUserProjectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbUserRelationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUserRelationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbValueList",
                columns: table => new
                {
                    ClassificationValueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbValueList", x => x.ClassificationValueId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationDeleteGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(nullable: true),
                    HasDropDown = table.Column<bool>(nullable: false),
                    DropDownSequence = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationDeleteGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationEditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationStatusId = table.Column<int>(nullable: false),
                    DefaultClassificationPageId = table.Column<int>(nullable: false),
                    HasDropDown = table.Column<bool>(nullable: false),
                    DropDownSequence = table.Column<int>(nullable: false),
                    Lid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationEditGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationLevelDeleteGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    DateLevel = table.Column<int>(nullable: false),
                    OnTheFly = table.Column<bool>(nullable: false),
                    Alphabetically = table.Column<bool>(nullable: false),
                    CanLink = table.Column<bool>(nullable: false),
                    InDropDown = table.Column<bool>(nullable: false),
                    InMenu = table.Column<bool>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationLevelDeleteGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationLevelEditGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    DateLevel = table.Column<int>(nullable: false),
                    OnTheFly = table.Column<bool>(nullable: false),
                    Alphabetically = table.Column<bool>(nullable: false),
                    CanLink = table.Column<bool>(nullable: false),
                    InDropDown = table.Column<bool>(nullable: false),
                    InMenu = table.Column<bool>(nullable: false),
                    Lid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationLevelEditGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationLevelIndexGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationLevelIndexGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationPageDeleteGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ShowTitleName = table.Column<bool>(nullable: false),
                    ShowTitleDescription = table.Column<bool>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationPageDeleteGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationPageEditGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    ShowTitleName = table.Column<bool>(nullable: false),
                    ShowTitleDescription = table.Column<bool>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationPageEditGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationPageLanguageEditGet",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationPageLanguageEditGet", x => x.LId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationPageSectionDeleteGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    SectionTypeName = table.Column<string>(nullable: true),
                    ShowSectionTitleName = table.Column<bool>(nullable: false),
                    ShowSectionTitleDescription = table.Column<bool>(nullable: false),
                    ShowContentTypeTitleName = table.Column<bool>(nullable: false),
                    ShowContentTypeTitleDescription = table.Column<bool>(nullable: false),
                    OneTwoColumns = table.Column<int>(nullable: false),
                    ContentTypeName = table.Column<string>(nullable: true),
                    SortById = table.Column<int>(nullable: false),
                    MaxContent = table.Column<int>(nullable: false),
                    HasPaging = table.Column<bool>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationPageSectionDeleteGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationPageSectionEditGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    SectionTypeId = table.Column<int>(nullable: false),
                    ShowSectionTitleName = table.Column<bool>(nullable: false),
                    ShowSectionTitleDescription = table.Column<bool>(nullable: false),
                    ShowContentTypeTitleName = table.Column<bool>(nullable: false),
                    ShowContentTypeTitleDescription = table.Column<bool>(nullable: false),
                    OneTwoColumns = table.Column<int>(nullable: false),
                    ContentTypeId = table.Column<int>(nullable: false),
                    SortById = table.Column<int>(nullable: false),
                    MaxContent = table.Column<int>(nullable: false),
                    HasPaging = table.Column<bool>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationPageSectionEditGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationPageSectionLanguageEditGet",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationPageSectionLanguageEditGet", x => x.LId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationValueEditGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTimeOffset>(nullable: false),
                    ToDate = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    DropDownName = table.Column<string>(nullable: true),
                    HeaderName = table.Column<string>(nullable: true),
                    HeaderDescription = table.Column<string>(nullable: true),
                    PageName = table.Column<string>(nullable: true),
                    PageDescription = table.Column<string>(nullable: true),
                    TopicName = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    DateLevel = table.Column<int>(nullable: false),
                    InDropDown = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationValueEditGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationValueEditGetLevel",
                columns: table => new
                {
                    DateLevel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InDropDown = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationValueEditGetLevel", x => x.DateLevel);
                });

            migrationBuilder.CreateTable(
                name: "ZdbClassificationValueIndexGet",
                columns: table => new
                {
                    Path = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbClassificationValueIndexGet", x => x.Path);
                });

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

            migrationBuilder.CreateTable(
                name: "ZdbContentEditGetClassificationValues",
                columns: table => new
                {
                    ClassificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<int>(nullable: false),
                    ValueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbContentEditGetClassificationValues", x => x.ClassificationId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbContentEditGetContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeId = table.Column<int>(nullable: false),
                    ProcessTemplateId = table.Column<int>(nullable: false),
                    ContentStatusId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SecurityLevel = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbContentEditGetContent", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "ZdbContentTypeClassificationIndexGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeId = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    StatusName = table.Column<string>(nullable: true),
                    ClassificationName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbContentTypeClassificationIndexGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZDbContentTypeDeleteGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    SecurityLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZDbContentTypeDeleteGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbContentTypeEditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeGroupId = table.Column<int>(nullable: false),
                    ProcessTemplateId = table.Column<int>(nullable: false),
                    SecurityLevel = table.Column<int>(nullable: false),
                    Lid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbContentTypeEditGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbContentTypeGroupEditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbContentTypeGroupEditGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZDbCountryList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZDbCountryList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbExternalPage",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShowTitleName = table.Column<bool>(nullable: false),
                    ShowTitleDescription = table.Column<bool>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbExternalPage", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbExternalPageMyContentGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    StatusName = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbExternalPageMyContentGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbExternalPageViewGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SecurityLevel = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    StatusName = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbExternalPageViewGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontCalendarEventCalendar",
                columns: table => new
                {
                    ProcessFieldId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessId = table.Column<int>(nullable: false),
                    StepId = table.Column<int>(nullable: false),
                    DateTimeValue = table.Column<DateTime>(nullable: false),
                    IntValue = table.Column<int>(nullable: false),
                    StringValue = table.Column<string>(nullable: true),
                    ProcessTemplateFieldId = table.Column<int>(nullable: false),
                    ProcessTemplateFieldTypeId = table.Column<int>(nullable: false),
                    MainDate = table.Column<DateTime>(nullable: false),
                    ProcessTemplateStepTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontCalendarEventCalendar", x => x.ProcessFieldId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontOrganizationDashboardGetContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ContentTypeName = table.Column<string>(nullable: true),
                    ContentStatusName = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontOrganizationDashboardGetContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontOrganizationDashboardGetOrganization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationName = table.Column<string>(nullable: true),
                    StatusName = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontOrganizationDashboardGetOrganization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontOrganizationDashboardGetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontOrganizationDashboardGetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontOrganizationMyOrganizationGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationName = table.Column<string>(nullable: true),
                    UserOrganizationTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontOrganizationMyOrganizationGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontPage",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShowTitleName = table.Column<bool>(nullable: false),
                    ShowTitleDescription = table.Column<bool>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontPage", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontPageMyContentGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    StatusName = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontPageMyContentGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontPageViewGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SecurityLevel = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Modifier = table.Column<string>(nullable: true),
                    StatusName = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true),
                    IsCurrentUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontPageViewGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontProcessCreateGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    StepId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontProcessCreateGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontProcessIndexGetTemplateFlowCondition",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConditionTypeId = table.Column<int>(nullable: false),
                    ComparisonOperatorId = table.Column<int>(nullable: false),
                    ConditionString = table.Column<string>(nullable: true),
                    ConditionInt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontProcessIndexGetTemplateFlowCondition", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontProcessIndexGetTemplateGroup",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontProcessIndexGetTemplateGroup", x => x.OId);
                });

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
                name: "ZdbFrontProcessToDoIndex2GetForAndOr",
                columns: table => new
                {
                    ConditionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlowId = table.Column<int>(nullable: false),
                    ConditionTypeId = table.Column<int>(nullable: false),
                    ConditionFieldId = table.Column<int>(nullable: false),
                    ComparisonOperatorId = table.Column<int>(nullable: false),
                    ConditionString = table.Column<string>(nullable: true),
                    ConditionInt = table.Column<int>(nullable: false),
                    ConditionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontProcessToDoIndex2GetForAndOr", x => x.ConditionId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontProjectMyProjectGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    RelationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontProjectMyProjectGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontRelationMyRelationGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    RelationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontRelationMyRelationGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontUserIndexGet",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontUserIndexGet", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ZDbGetProjectStructure",
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
                    table.PrimaryKey("PK_ZDbGetProjectStructure", x => x.Path);
                });

            migrationBuilder.CreateTable(
                name: "ZdbHomeIndexAdminGetLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbHomeIndexAdminGetLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbHomeIndexAdminGetTableName",
                columns: table => new
                {
                    TableDescription = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbHomeIndexAdminGetTableName", x => x.TableDescription);
                });

            migrationBuilder.CreateTable(
                name: "ZdbInt",
                columns: table => new
                {
                    intValue = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbInt", x => x.intValue);
                });

            migrationBuilder.CreateTable(
                name: "ZdbInt2",
                columns: table => new
                {
                    intValue = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbInt2", x => x.intValue);
                });

            migrationBuilder.CreateTable(
                name: "ZdbLanguageCreateGetLanguageList",
                columns: table => new
                {
                    Value = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbLanguageCreateGetLanguageList", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "ZDbLanguageList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZDbLanguageList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbLayoutTermList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbLayoutTermList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbLeftMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuName = table.Column<string>(nullable: true),
                    MenuShow = table.Column<bool>(nullable: false),
                    MenuAddShow = table.Column<bool>(nullable: false),
                    SearchShow = table.Column<bool>(nullable: false),
                    AdvancedSearchShow = table.Column<bool>(nullable: false),
                    HasMenu = table.Column<bool>(nullable: false),
                    HasAdd = table.Column<bool>(nullable: false),
                    HasSearch = table.Column<bool>(nullable: false),
                    HasAdvancedSearch = table.Column<bool>(nullable: false),
                    MainController = table.Column<string>(nullable: true),
                    MainAction = table.Column<string>(nullable: true),
                    AddController = table.Column<string>(nullable: true),
                    AddAction = table.Column<string>(nullable: true),
                    AddName = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbLeftMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZDbMasterList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZDbMasterList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DestinationURL = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ZdbObjectIndexGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbObjectIndexGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbObjectIndexGet2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbObjectIndexGet2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbObjectLanguageCreateGet",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbObjectLanguageCreateGet", x => x.LId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbObjectLanguageEditGet",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    DropDownName = table.Column<string>(nullable: true),
                    PageName = table.Column<string>(nullable: true),
                    PageDescription = table.Column<string>(nullable: true),
                    HeaderName = table.Column<string>(nullable: true),
                    HeaderDescription = table.Column<string>(nullable: true),
                    TopicName = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDesciption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbObjectLanguageEditGet", x => x.LId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbObjectLanguageIndexGet",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OId = table.Column<int>(nullable: false),
                    PId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false),
                    LanguageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbObjectLanguageIndexGet", x => x.LId);
                });

            migrationBuilder.CreateTable(
                name: "ZDbOrganizationDeleteGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZDbOrganizationDeleteGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbOrganizationEditGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentOrganization = table.Column<string>(nullable: true),
                    OrganizationStatusId = table.Column<int>(nullable: false),
                    OrganizationTypeId = table.Column<int>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbOrganizationEditGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbOrganizationIndexGet",
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
                    table.PrimaryKey("PK_ZdbOrganizationIndexGet", x => x.Path);
                });

            migrationBuilder.CreateTable(
                name: "ZDbOrganizationTypeDeleteGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZDbOrganizationTypeDeleteGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbOrganizationTypeEditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbOrganizationTypeEditGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZDbPageDeleteGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true),
                    ShowTitleName = table.Column<bool>(nullable: false),
                    ShowTitleDescription = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZDbPageDeleteGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbPageLanguageEditGet",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbPageLanguageEditGet", x => x.LId);
                });

            migrationBuilder.CreateTable(
                name: "ZDbPageSectionDeleteGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    HasPaging = table.Column<bool>(nullable: false),
                    MaxContent = table.Column<int>(nullable: false),
                    OneTwoColumns = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    ShowContentTypeTitle = table.Column<bool>(nullable: false),
                    ShowContentTypeDescription = table.Column<bool>(nullable: false),
                    ShowSectionTitleName = table.Column<bool>(nullable: false),
                    ShowSectionTitleDescription = table.Column<bool>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZDbPageSectionDeleteGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbPageSectionEditGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeId = table.Column<int>(nullable: false),
                    HasPaging = table.Column<bool>(nullable: false),
                    MaxContent = table.Column<int>(nullable: false),
                    OneTwoColumns = table.Column<int>(nullable: false),
                    PageSectionTypeId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    ShowContentTypeTitle = table.Column<bool>(nullable: false),
                    ShowContentTypeDescription = table.Column<bool>(nullable: false),
                    ShowSectionTitleName = table.Column<bool>(nullable: false),
                    ShowSectionTitleDescription = table.Column<bool>(nullable: false),
                    SortById = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    titleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbPageSectionEditGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbPageSectionTypeEditGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    IndexSection = table.Column<bool>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbPageSectionTypeEditGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbPageTypeEditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbPageTypeEditGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbPreferenceIndexGet",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    DefaultLanguageId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbPreferenceIndexGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbPreferenceLeftMenuEditGet",
                columns: table => new
                {
                    UserMenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<int>(nullable: false),
                    MainController = table.Column<string>(nullable: true),
                    MainAction = table.Column<string>(nullable: true),
                    AddController = table.Column<string>(nullable: true),
                    AddAction = table.Column<string>(nullable: true),
                    HasMenu = table.Column<bool>(nullable: false),
                    HasAdd = table.Column<bool>(nullable: false),
                    HasSearch = table.Column<bool>(nullable: false),
                    HasAdvancedSearch = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MainName = table.Column<string>(nullable: true),
                    MainMouseOver = table.Column<string>(nullable: true),
                    AddName = table.Column<string>(nullable: true),
                    AddMouseOver = table.Column<string>(nullable: true),
                    MenuShow = table.Column<bool>(nullable: false),
                    MenuAddShow = table.Column<bool>(nullable: false),
                    SearchShow = table.Column<bool>(nullable: false),
                    AdvancedSearchShow = table.Column<bool>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MenuURL = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbPreferenceLeftMenuEditGet", x => x.UserMenuId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbPreferenceLeftMenuGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MainController = table.Column<string>(nullable: true),
                    MainAction = table.Column<string>(nullable: true),
                    AddController = table.Column<string>(nullable: true),
                    AddAction = table.Column<string>(nullable: true),
                    HasMenu = table.Column<bool>(nullable: false),
                    HasAdd = table.Column<bool>(nullable: false),
                    HasSearch = table.Column<bool>(nullable: false),
                    HasAdvancedSearch = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MainName = table.Column<string>(nullable: true),
                    MainMouseOver = table.Column<string>(nullable: true),
                    AddName = table.Column<string>(nullable: true),
                    AddMouseOver = table.Column<string>(nullable: true),
                    MenuShow = table.Column<bool>(nullable: false),
                    MenuAddShow = table.Column<bool>(nullable: false),
                    SearchShow = table.Column<bool>(nullable: false),
                    AdvancedSearchShow = table.Column<bool>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MenuURL = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbPreferenceLeftMenuGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbPreferenceLeftMenuGetAvailableMenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MainController = table.Column<string>(nullable: true),
                    MainAction = table.Column<string>(nullable: true),
                    AddController = table.Column<string>(nullable: true),
                    AddAction = table.Column<string>(nullable: true),
                    HasMenu = table.Column<bool>(nullable: false),
                    HasAdd = table.Column<bool>(nullable: false),
                    HasSearch = table.Column<bool>(nullable: false),
                    HasAdvancedSearch = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MainName = table.Column<string>(nullable: true),
                    MainMouseOver = table.Column<string>(nullable: true),
                    AddName = table.Column<string>(nullable: true),
                    AddMouseOver = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbPreferenceLeftMenuGetAvailableMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbProcessTemplateFlowConditionEditGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateConditionTypeId = table.Column<int>(nullable: false),
                    ComparisonOperatorId = table.Column<int>(nullable: true),
                    ProcessTemplateFieldId = table.Column<int>(nullable: true),
                    DataTypeId = table.Column<int>(nullable: true),
                    LId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProcessTemplateFlowConditionDate = table.Column<DateTime>(nullable: false),
                    ProcessTemplateFlowConditionInt = table.Column<int>(nullable: true),
                    ProcessTemplateFlowConditionString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbProcessTemplateFlowConditionEditGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZDbSecurityLevelList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZDbSecurityLevelList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZDbStatusList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZDbStatusList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbSuFrontPageViewGetClassificationValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ValueName = table.Column<string>(nullable: true),
                    ClassificationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbSuFrontPageViewGetClassificationValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbSuFrontProcessTodoEditGet",
                columns: table => new
                {
                    PTFId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    FId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    StringValue = table.Column<string>(nullable: true),
                    IntValue = table.Column<int>(nullable: false),
                    DateTimeValue = table.Column<DateTime>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    FieldDataTypeId = table.Column<int>(nullable: false),
                    FieldMasterListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbSuFrontProcessTodoEditGet", x => x.PTFId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbSuFrontProcessTodoIndexGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbSuFrontProcessTodoIndexGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbSuFrontUserUserDashboardGetRelation",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    MouseOver = table.Column<string>(nullable: false),
                    MenuName = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbSuFrontUserUserDashboardGetRelation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbSuProcessTemplateFieldEditGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    ProcessTemplateFieldTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbSuProcessTemplateFieldEditGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbTermLanguageCreateGetWith",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageId = table.Column<int>(nullable: false),
                    Customization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbTermLanguageCreateGetWith", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbTopMenu1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuName = table.Column<string>(nullable: true),
                    MenuController = table.Column<string>(nullable: true),
                    MenuAction = table.Column<string>(nullable: true),
                    MenuDestinationId = table.Column<int>(nullable: false),
                    IconCss = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbTopMenu1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbTopMenu2",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Menu1MenuTypeId = table.Column<int>(nullable: false),
                    Menu2MenuTypeId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MenuController = table.Column<string>(nullable: true),
                    MenuAction = table.Column<string>(nullable: true),
                    MenuDestinationId = table.Column<int>(nullable: false),
                    IconCss = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbTopMenu2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZDbTypeList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZDbTypeList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZDbUITermLanguageEditGet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Customization = table.Column<string>(nullable: true),
                    TermId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    LanguageName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZDbUITermLanguageEditGet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZDbUITermList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZDbUITermList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdbUserRelationTypeIndexGet",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromIsOfToName = table.Column<string>(nullable: true),
                    ToIsOfFromName = table.Column<string>(nullable: true),
                    FromIsOfToDescription = table.Column<string>(nullable: true),
                    ToIsOfFromDescription = table.Column<string>(nullable: true),
                    FromIsOfToMouseOver = table.Column<string>(nullable: true),
                    ToIsOfFromMouseOver = table.Column<string>(nullable: true),
                    FromIsOfToMenuName = table.Column<string>(nullable: true),
                    ToIsOfFromMenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbUserRelationTypeIndexGet", x => x.OId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbUserRelationTypeLanguageDeleteGet",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromIsOfToName = table.Column<string>(nullable: true),
                    ToIsOfFromName = table.Column<string>(nullable: true),
                    FromIsOfToDescription = table.Column<string>(nullable: false),
                    ToIsOfFromDescription = table.Column<string>(nullable: false),
                    FromIsOfToMouseOver = table.Column<string>(nullable: true),
                    ToIsOfFromMouseOver = table.Column<string>(nullable: false),
                    FromIsOfToMenuName = table.Column<string>(nullable: false),
                    ToIsOfFromMenuName = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbUserRelationTypeLanguageDeleteGet", x => x.LId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbUserRelationTypeLanguageEditGet",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OId = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    FromIsOfToName = table.Column<string>(nullable: true),
                    ToIsOfFromName = table.Column<string>(nullable: true),
                    FromIsOfToDescription = table.Column<string>(nullable: false),
                    ToIsOfFromDescription = table.Column<string>(nullable: false),
                    FromIsOfToMouseOver = table.Column<string>(nullable: true),
                    ToIsOfFromMouseOver = table.Column<string>(nullable: false),
                    FromIsOfToMenuName = table.Column<string>(nullable: false),
                    ToIsOfFromMenuName = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbUserRelationTypeLanguageEditGet", x => x.LId);
                });

            migrationBuilder.CreateTable(
                name: "ZdbUserRelationTypeLanguageIndexGet",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OId = table.Column<int>(nullable: false),
                    FromIsOfToName = table.Column<string>(nullable: true),
                    ToIsOfFromName = table.Column<string>(nullable: true),
                    FromIsOfToDescription = table.Column<string>(nullable: false),
                    ToIsOfFromDescription = table.Column<string>(nullable: false),
                    FromIsOfToMouseOver = table.Column<string>(nullable: true),
                    ToIsOfFromMouseOver = table.Column<string>(nullable: false),
                    FromIsOfToMenuName = table.Column<string>(nullable: false),
                    ToIsOfFromMenuName = table.Column<string>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    LanguageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbUserRelationTypeLanguageIndexGet", x => x.LId);
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
                name: "DbClassification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationStatusId = table.Column<int>(nullable: false),
                    DefaultClassificationPageId = table.Column<int>(nullable: false),
                    HasDropDown = table.Column<bool>(nullable: false),
                    DropDownSequence = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbClassification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbClassification_DbClassificationStatus_ClassificationStatusId",
                        column: x => x.ClassificationStatusId,
                        principalTable: "DbClassificationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbContentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeGroupId = table.Column<int>(nullable: false),
                    ProcessTemplateId = table.Column<int>(nullable: false),
                    SecurityLevel = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbContentType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbContentType_DbContentTypeGroup_ContentTypeGroupId",
                        column: x => x.ContentTypeGroupId,
                        principalTable: "DbContentTypeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbContentTypeClassificationStatusLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeClassificationStatusId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbContentTypeClassificationStatusLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbContentTypeClassificationStatusLanguage_dbContentTypeClassificationStatus_ContentTypeClassificationStatusId",
                        column: x => x.ContentTypeClassificationStatusId,
                        principalTable: "dbContentTypeClassificationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbContentTypeClassificationStatusLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbContentTypeGroupLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeGroupId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbContentTypeGroupLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbContentTypeGroupLanguage_DbContentTypeGroup_ContentTypeGroupId",
                        column: x => x.ContentTypeGroupId,
                        principalTable: "DbContentTypeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbContentTypeGroupLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbLeftMenuLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeftMenuId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MainName = table.Column<string>(maxLength: 50, nullable: true),
                    MainMouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    AddName = table.Column<string>(maxLength: 50, nullable: true),
                    AddMouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbLeftMenuLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbLeftMenuLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbLeftMenuLanguage_dbLeftMenu_LeftMenuId",
                        column: x => x.LeftMenuId,
                        principalTable: "dbLeftMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbLeftMenuUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeftMenuId = table.Column<int>(nullable: false),
                    MenuShow = table.Column<bool>(nullable: false),
                    MenuAddShow = table.Column<bool>(nullable: false),
                    SearchShow = table.Column<bool>(nullable: false),
                    AdvancedSearchShow = table.Column<bool>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MenuURL = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbLeftMenuUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbLeftMenuUser_dbLeftMenu_LeftMenuId",
                        column: x => x.LeftMenuId,
                        principalTable: "dbLeftMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbMenu1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuTypeId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false),
                    Controller = table.Column<string>(maxLength: 20, nullable: true),
                    Action = table.Column<string>(maxLength: 20, nullable: true),
                    DestinationId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbMenu1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbMenu1_dbMenuType_MenuTypeId",
                        column: x => x.MenuTypeId,
                        principalTable: "dbMenuType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbOrganization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentOrganizationId = table.Column<int>(nullable: true),
                    OrganizationStatusId = table.Column<int>(nullable: false),
                    OrganizationTypeId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbOrganization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbOrganization_DbOrganizationStatus_OrganizationStatusId",
                        column: x => x.OrganizationStatusId,
                        principalTable: "DbOrganizationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbOrganization_DbOrganizationType_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "DbOrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbOrganization_DbOrganization_ParentOrganizationId",
                        column: x => x.ParentOrganizationId,
                        principalTable: "DbOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbOrganizationTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbOrganizationTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbOrganizationTypeLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbOrganizationTypeLanguage_DbOrganizationType_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "DbOrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbPageSectionTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageSectionTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    PageTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPageSectionTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbPageSectionTypeLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbPageSectionTypeLanguage_DbPageSectionType_PageTypeId",
                        column: x => x.PageTypeId,
                        principalTable: "DbPageSectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbPage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageStatusId = table.Column<int>(nullable: false),
                    PageTypeId = table.Column<int>(nullable: false),
                    ShowTitleName = table.Column<bool>(nullable: false),
                    ShowTitleDescription = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbPage_DbPageStatus_PageStatusId",
                        column: x => x.PageStatusId,
                        principalTable: "DbPageStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbPage_DbPageType_PageTypeId",
                        column: x => x.PageTypeId,
                        principalTable: "DbPageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbPageTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPageTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbPageTypeLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbPageTypeLanguage_DbPageType_PageTypeId",
                        column: x => x.PageTypeId,
                        principalTable: "DbPageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateFieldTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FieldTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateFieldTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateFieldTypeLanguage_DbProcessTemplateFieldType_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "DbProcessTemplateFieldType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateFieldTypeLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateGroupId = table.Column<int>(nullable: false),
                    ShowInPersonalCalendar = table.Column<bool>(nullable: false),
                    ShowInEventCalendar = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplate_DbProcessTemplateGroup_ProcessTemplateGroupId",
                        column: x => x.ProcessTemplateGroupId,
                        principalTable: "DbProcessTemplateGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateGroupLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateGroupId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateGroupLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateGroupLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateGroupLanguage_DbProcessTemplateGroup_ProcessTemplateGroupId",
                        column: x => x.ProcessTemplateGroupId,
                        principalTable: "DbProcessTemplateGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ProcessTemplateGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateLanguage_DbProcessTemplateGroup_ProcessTemplateGroupId",
                        column: x => x.ProcessTemplateGroupId,
                        principalTable: "DbProcessTemplateGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbProcessTemplateStepTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StepTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbProcessTemplateStepTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateStepTypeLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbProcessTemplateStepTypeLanguage_dbProcessTemplateStepType_StepTypeId",
                        column: x => x.StepTypeId,
                        principalTable: "dbProcessTemplateStepType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbProject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentProjectId = table.Column<int>(nullable: true),
                    ProjectStatusId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProject_DbProjectStatus_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "DbProjectStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbUITermLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TermId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Customization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUITermLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbUITermLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbUITermLanguage_DbUITerm_TermId",
                        column: x => x.TermId,
                        principalTable: "DbUITerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbUITermScreen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TermId = table.Column<int>(nullable: false),
                    ScreenId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUITermScreen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbUITermScreen_DbUIScreen_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "DbUIScreen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbUITermScreen_DbUITerm_TermId",
                        column: x => x.TermId,
                        principalTable: "DbUITerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbUserOrganizationTypeLanguage",
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
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUserOrganizationTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbUserOrganizationTypeLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbUserOrganizationTypeLanguage_DbUserOrganizationType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DbUserOrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbUserProjectTypeLanguage",
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
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUserProjectTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbUserProjectTypeLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbUserProjectTypeLanguage_DbUserProjectType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DbUserProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbUserRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromUserId = table.Column<string>(maxLength: 450, nullable: true),
                    ToUserId = table.Column<string>(maxLength: 450, nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUserRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbUserRelation_AspNetUsers_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbUserRelation_AspNetUsers_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbUserRelation_DbUserRelationType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DbUserRelationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbUserRelationTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    FromIsOfToName = table.Column<string>(maxLength: 50, nullable: true),
                    ToIsOfFromName = table.Column<string>(maxLength: 50, nullable: true),
                    FromIsOfToDescription = table.Column<string>(nullable: true),
                    ToIsOfFromDescription = table.Column<string>(nullable: true),
                    FromIsOfToMenuName = table.Column<string>(maxLength: 50, nullable: true),
                    ToIsOfFromMenuName = table.Column<string>(maxLength: 50, nullable: true),
                    FromIsOfToMouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    ToIsOfFromMouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUserRelationTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbUserRelationTypeLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbUserRelationTypeLanguage_DbUserRelationType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DbUserRelationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ZdbExternalPageSection",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    OneTwoColumns = table.Column<int>(nullable: false),
                    ShowSectionTitleName = table.Column<bool>(nullable: false),
                    ShowSectionTitleDescription = table.Column<bool>(nullable: false),
                    ShowContentTypeTitle = table.Column<bool>(nullable: false),
                    ShowContentTypeDescription = table.Column<bool>(nullable: false),
                    ContentTitleName = table.Column<string>(nullable: true),
                    ContentTitleDescription = table.Column<string>(nullable: true),
                    MaxContent = table.Column<int>(nullable: false),
                    HasPaging = table.Column<bool>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbExternalPageSection", x => x.OId);
                    table.ForeignKey(
                        name: "FK_ZdbExternalPageSection_ZdbExternalPage_PId",
                        column: x => x.PId,
                        principalTable: "ZdbExternalPage",
                        principalColumn: "OId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontPageSection",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    OneTwoColumns = table.Column<int>(nullable: false),
                    ShowSectionTitleName = table.Column<bool>(nullable: false),
                    ShowSectionTitleDescription = table.Column<bool>(nullable: false),
                    ShowContentTypeTitle = table.Column<bool>(nullable: false),
                    ShowContentTypeDescription = table.Column<bool>(nullable: false),
                    ContentTitleName = table.Column<string>(nullable: true),
                    ContentTitleDescription = table.Column<string>(nullable: true),
                    MaxContent = table.Column<int>(nullable: false),
                    HasPaging = table.Column<bool>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontPageSection", x => x.OId);
                    table.ForeignKey(
                        name: "FK_ZdbFrontPageSection_ZdbFrontPage_PId",
                        column: x => x.PId,
                        principalTable: "ZdbFrontPage",
                        principalColumn: "OId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontProcessCreateGetField",
                columns: table => new
                {
                    FieldId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OId = table.Column<int>(nullable: false),
                    PId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    ProcessTemplateFieldTypeId = table.Column<int>(nullable: false),
                    StringValue = table.Column<string>(nullable: true),
                    IntValue = table.Column<int>(nullable: false),
                    DateTimeValue = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontProcessCreateGetField", x => x.FieldId);
                    table.ForeignKey(
                        name: "FK_ZdbFrontProcessCreateGetField_ZdbFrontProcessCreateGet_PId",
                        column: x => x.PId,
                        principalTable: "ZdbFrontProcessCreateGet",
                        principalColumn: "OId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontProcessIndexGetTemplate",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontProcessIndexGetTemplate", x => x.OId);
                    table.ForeignKey(
                        name: "FK_ZdbFrontProcessIndexGetTemplate_ZdbFrontProcessIndexGetTemplateGroup_PId",
                        column: x => x.PId,
                        principalTable: "ZdbFrontProcessIndexGetTemplateGroup",
                        principalColumn: "OId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ZdbHomeIndexAdminGetNoOfRecordsAndPerLanguage",
                columns: table => new
                {
                    LanguageName = table.Column<string>(nullable: false),
                    TableDescription = table.Column<string>(nullable: true),
                    NoOfRecords = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbHomeIndexAdminGetNoOfRecordsAndPerLanguage", x => x.LanguageName);
                    table.ForeignKey(
                        name: "FK_ZdbHomeIndexAdminGetNoOfRecordsAndPerLanguage_ZdbHomeIndexAdminGetTableName_TableDescription",
                        column: x => x.TableDescription,
                        principalTable: "ZdbHomeIndexAdminGetTableName",
                        principalColumn: "TableDescription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu2",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    DestinationURL = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu2", x => x.OId);
                    table.ForeignKey(
                        name: "FK_ZdbMenu2_ZdbMenu1_PId",
                        column: x => x.PId,
                        principalTable: "ZdbMenu1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbClassificationLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbClassificationLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbClassificationLanguage_DbClassification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "DbClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbClassificationLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbClassificationLevel",
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
                    InMenu = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbClassificationLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbClassificationLevel_DbClassification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "DbClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbClassificationPage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    ShowTitleName = table.Column<bool>(nullable: false),
                    ShowTitleDescription = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbClassificationPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbClassificationPage_DbClassification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "DbClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbClassificationValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationId = table.Column<int>(nullable: false),
                    ParentValueId = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTimeOffset>(nullable: true),
                    DateTo = table.Column<DateTimeOffset>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbClassificationValue", x => x.Id);
                    table.ForeignKey(
                        name: "FKClassificationValues",
                        column: x => x.ClassificationId,
                        principalTable: "DbClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbContentTypeClassification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeId = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbContentTypeClassification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbContentTypeClassification_DbClassification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "DbClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbContentTypeClassification_DbContentType_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "DbContentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbContentTypeClassification_dbContentTypeClassificationStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "dbContentTypeClassificationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbContentTypeLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentTypeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    TitleDescription = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbContentTypeLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbContentTypeLanguage_DbContentType_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "DbContentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbContentTypeLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbMenu1Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Menu1Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(maxLength: 20, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbMenu1Language", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbMenu1Language_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbMenu1Language_dbMenu1_Menu1Id",
                        column: x => x.Menu1Id,
                        principalTable: "dbMenu1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbMenu2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Menu1Id = table.Column<int>(nullable: false),
                    MenuTypeId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false),
                    Controller = table.Column<string>(maxLength: 20, nullable: true),
                    Action = table.Column<string>(maxLength: 20, nullable: true),
                    DestinationId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbMenu2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbMenu2_dbMenu1_Menu1Id",
                        column: x => x.Menu1Id,
                        principalTable: "dbMenu1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbMenu2_dbMenuType_MenuTypeId",
                        column: x => x.MenuTypeId,
                        principalTable: "dbMenuType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbOrganizationLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbOrganizationLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbOrganizationLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbOrganizationLanguage_DbOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "DbOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbUserOrganization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(maxLength: 450, nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUserOrganization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbUserOrganization_DbOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "DbOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbUserOrganization_DbUserOrganizationType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DbUserOrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbUserOrganization_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbPageLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    TitleName = table.Column<string>(maxLength: 50, nullable: true),
                    TitleDescription = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPageLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbPageLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbPageLanguage_DbPage_PageId",
                        column: x => x.PageId,
                        principalTable: "DbPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbPageSection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    PageSectionTypeId = table.Column<int>(nullable: false),
                    ShowSectionTitleName = table.Column<bool>(maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_DbPageSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbPageSection_DbContentType_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "DbContentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbPageSection_DbPage_PageId",
                        column: x => x.PageId,
                        principalTable: "DbPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbPageSection_DbPageSectionType_PageSectionTypeId",
                        column: x => x.PageSectionTypeId,
                        principalTable: "DbPageSectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbProcess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateId = table.Column<int>(nullable: false),
                    StepId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    SuProcessMultiModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcess_DbProcessTemplate_ProcessTemplateId",
                        column: x => x.ProcessTemplateId,
                        principalTable: "DbProcessTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcess_dbProcessMulti_SuProcessMultiModelId",
                        column: x => x.SuProcessMultiModelId,
                        principalTable: "dbProcessMulti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateFlow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateId = table.Column<int>(nullable: false),
                    ProcessTemplateFromStepId = table.Column<int>(nullable: false),
                    ProcessTemplateToStepId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateFlow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateFlow_DbProcessTemplate_ProcessTemplateId",
                        column: x => x.ProcessTemplateId,
                        principalTable: "DbProcessTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateStep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateId = table.Column<int>(nullable: false),
                    ProcessTemplateStepTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateStep_DbProcessTemplate_ProcessTemplateId",
                        column: x => x.ProcessTemplateId,
                        principalTable: "DbProcessTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateStep_dbProcessTemplateStepType_ProcessTemplateStepTypeId",
                        column: x => x.ProcessTemplateStepTypeId,
                        principalTable: "dbProcessTemplateStepType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbContent",
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
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ProcessId = table.Column<int>(nullable: false),
                    SuProcessTemplateStepFieldStatusModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbContent_DbContentStatus_ContentStatusId",
                        column: x => x.ContentStatusId,
                        principalTable: "DbContentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbContent_DbContentType_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "DbContentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbContent_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbContent_DbOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "DbOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbContent_DbProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DbProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbContent_DbSecurityLevel_SecurityLevel",
                        column: x => x.SecurityLevel,
                        principalTable: "DbSecurityLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbContent_DbProcessTemplateStepFieldStatus_SuProcessTemplateStepFieldStatusModelId",
                        column: x => x.SuProcessTemplateStepFieldStatusModelId,
                        principalTable: "DbProcessTemplateStepFieldStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbProjectLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProjectLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProjectLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProjectLanguage_DbProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DbProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbUserProject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(maxLength: 450, nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUserProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbUserProject_DbProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "DbProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbUserProject_DbUserProjectType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DbUserProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbUserProject_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZdbExternalContent",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbExternalContent", x => x.OId);
                    table.ForeignKey(
                        name: "FK_ZdbExternalContent_ZdbExternalPageSection_PId",
                        column: x => x.PId,
                        principalTable: "ZdbExternalPageSection",
                        principalColumn: "OId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ZdbFrontContent",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbFrontContent", x => x.OId);
                    table.ForeignKey(
                        name: "FK_ZdbFrontContent_ZdbFrontPageSection_PId",
                        column: x => x.PId,
                        principalTable: "ZdbFrontPageSection",
                        principalColumn: "OId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ZdbMenu3",
                columns: table => new
                {
                    OId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PId = table.Column<int>(nullable: false),
                    PPId = table.Column<int>(nullable: false),
                    DestinationURL = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdbMenu3", x => x.OId);
                    table.ForeignKey(
                        name: "FK_ZdbMenu3_ZdbMenu2_PId",
                        column: x => x.PId,
                        principalTable: "ZdbMenu2",
                        principalColumn: "OId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbClassificationLevelLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationLevelId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbClassificationLevelLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbClassificationLevelLanguage_DbClassificationLevel_ClassificationLevelId",
                        column: x => x.ClassificationLevelId,
                        principalTable: "DbClassificationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbClassificationLevelLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbClassificationPageLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationPageId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    TitleName = table.Column<string>(maxLength: 50, nullable: true),
                    TitleDescription = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbClassificationPageLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbClassificationPageLanguage_DbClassificationPage_ClassificationPageId",
                        column: x => x.ClassificationPageId,
                        principalTable: "DbClassificationPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbClassificationPageLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbClassificationPageSection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationPageId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    SectionTypeId = table.Column<int>(nullable: false),
                    ShowSectionTitleName = table.Column<bool>(nullable: false),
                    ShowSectionTitleDescription = table.Column<bool>(nullable: false),
                    ShowContentTypeTitleName = table.Column<bool>(nullable: false),
                    ShowContentTypeTitleDescription = table.Column<bool>(nullable: false),
                    OneTwoColumns = table.Column<int>(nullable: false),
                    ContentTypeId = table.Column<int>(nullable: true),
                    SortById = table.Column<int>(nullable: false),
                    MaxContent = table.Column<int>(nullable: false),
                    HasPaging = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbClassificationPageSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbClassificationPageSection_DbClassificationPage_ClassificationPageId",
                        column: x => x.ClassificationPageId,
                        principalTable: "DbClassificationPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbClassificationPageSection_DbContentType_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "DbContentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbClassificationPageSection_DbPageSectionType_SectionTypeId",
                        column: x => x.SectionTypeId,
                        principalTable: "DbPageSectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbClassificationValueLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassificationValueId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    DropDownName = table.Column<string>(nullable: true),
                    PageName = table.Column<string>(nullable: true),
                    PageDescription = table.Column<string>(nullable: true),
                    HeaderName = table.Column<string>(nullable: true),
                    HeaderDescription = table.Column<string>(nullable: true),
                    TopicName = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbClassificationValueLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbClassificationValueLanguage_DbClassificationValue_ClassificationValueId",
                        column: x => x.ClassificationValueId,
                        principalTable: "DbClassificationValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbClassificationValueLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbMenu2Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Menu2Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(maxLength: 20, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Menu1Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbMenu2Language", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbMenu2Language_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbMenu2Language_dbMenu2_Menu1Id",
                        column: x => x.Menu1Id,
                        principalTable: "dbMenu2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbMenu3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Menu2Id = table.Column<int>(nullable: false),
                    MenuTypeId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false),
                    Controller = table.Column<string>(maxLength: 20, nullable: true),
                    Action = table.Column<string>(maxLength: 20, nullable: true),
                    DestinationId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbMenu3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbMenu3_dbMenu2_Menu2Id",
                        column: x => x.Menu2Id,
                        principalTable: "dbMenu2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbMenu3_dbMenuType_MenuTypeId",
                        column: x => x.MenuTypeId,
                        principalTable: "dbMenuType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbPageSectionLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageSectionId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    TitleName = table.Column<string>(maxLength: 50, nullable: true),
                    TitleDescription = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPageSectionLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbPageSectionLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbPageSectionLanguage_DbPageSection_PageSectionId",
                        column: x => x.PageSectionId,
                        principalTable: "DbPageSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateField",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateId = table.Column<int>(nullable: false),
                    ProcessTemplateFieldTypeId = table.Column<int>(nullable: false),
                    SuProcessModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateField_DbProcessTemplateFieldType_ProcessTemplateFieldTypeId",
                        column: x => x.ProcessTemplateFieldTypeId,
                        principalTable: "DbProcessTemplateFieldType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateField_DbProcessTemplate_ProcessTemplateId",
                        column: x => x.ProcessTemplateId,
                        principalTable: "DbProcessTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateField_DbProcess_SuProcessModelId",
                        column: x => x.SuProcessModelId,
                        principalTable: "DbProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateFlowCondition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateFlowId = table.Column<int>(nullable: false),
                    ProcessTemplateConditionTypeId = table.Column<int>(nullable: false),
                    ProcessTemplateFieldId = table.Column<int>(nullable: true),
                    ComparisonOperatorId = table.Column<int>(nullable: true),
                    DataTypeId = table.Column<int>(nullable: true),
                    ProcessTemplateFlowConditionString = table.Column<string>(nullable: true),
                    ProcessTemplateFlowConditionInt = table.Column<int>(nullable: true),
                    ProcessTemplateFlowConditionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateFlowCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateFlowCondition_DbProcessTemplateFlowConditionType_ProcessTemplateConditionTypeId",
                        column: x => x.ProcessTemplateConditionTypeId,
                        principalTable: "DbProcessTemplateFlowConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateFlowCondition_DbProcessTemplateFlow_ProcessTemplateFlowId",
                        column: x => x.ProcessTemplateFlowId,
                        principalTable: "DbProcessTemplateFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateFlowLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlowId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateFlowLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateFlowLanguage_DbProcessTemplateFlow_FlowId",
                        column: x => x.FlowId,
                        principalTable: "DbProcessTemplateFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateFlowLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateStepLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StepId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateStepLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateStepLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateStepLanguage_DbProcessTemplateStep_StepId",
                        column: x => x.StepId,
                        principalTable: "DbProcessTemplateStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbContentClassificationValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentId = table.Column<int>(nullable: false),
                    ClassificationValueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbContentClassificationValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbContentClassificationValue_DbClassificationValue_ClassificationValueId",
                        column: x => x.ClassificationValueId,
                        principalTable: "DbClassificationValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbContentClassificationValue_DbContent_ContentId",
                        column: x => x.ContentId,
                        principalTable: "DbContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbClassificationPageSectionLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageSectionId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    TitleName = table.Column<string>(maxLength: 50, nullable: true),
                    TitleDescription = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(maxLength: 50, nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbClassificationPageSectionLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbClassificationPageSectionLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbClassificationPageSectionLanguage_DbClassificationPageSection_PageSectionId",
                        column: x => x.PageSectionId,
                        principalTable: "DbClassificationPageSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dbMenu3Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Menu3Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(maxLength: 20, nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Menu1Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbMenu3Language", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbMenu3Language_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_dbMenu3Language_dbMenu3_Menu1Id",
                        column: x => x.Menu1Id,
                        principalTable: "dbMenu3",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessField",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessId = table.Column<int>(nullable: false),
                    ProcessTemplateFieldId = table.Column<int>(nullable: false),
                    StringValue = table.Column<string>(nullable: true),
                    IntValue = table.Column<int>(nullable: false),
                    DateTimeValue = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessField_DbProcess_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "DbProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessField_DbProcessTemplateField_ProcessTemplateFieldId",
                        column: x => x.ProcessTemplateFieldId,
                        principalTable: "DbProcessTemplateField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateFieldLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessTemplateFieldId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateFieldLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateFieldLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateFieldLanguage_DbProcessTemplateField_ProcessTemplateFieldId",
                        column: x => x.ProcessTemplateFieldId,
                        principalTable: "DbProcessTemplateField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateStepField",
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
                    table.PrimaryKey("PK_DbProcessTemplateStepField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateStepField_DbProcessTemplateField_FieldId",
                        column: x => x.FieldId,
                        principalTable: "DbProcessTemplateField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateStepField_DbProcessTemplateStepFieldStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "DbProcessTemplateStepFieldStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateStepField_DbProcessTemplateStep_StepId",
                        column: x => x.StepId,
                        principalTable: "DbProcessTemplateStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DbProcessTemplateFlowConditionLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlowConditionId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MouseOver = table.Column<string>(maxLength: 50, nullable: true),
                    MenuName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ModifierId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbProcessTemplateFlowConditionLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateFlowConditionLanguage_DbProcessTemplateFlowCondition_FlowConditionId",
                        column: x => x.FlowConditionId,
                        principalTable: "DbProcessTemplateFlowCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DbProcessTemplateFlowConditionLanguage_DbLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "DbLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d409b39f-40cd-42b9-bb8d-fcb7288f6938", "4dc35a90-dabc-4525-b987-950c1a5a1452", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84af8d2c-1196-473e-b819-37815fdbcf0d", "0ed11f91-9230-4791-ae8e-0b7608e7d4a3", "Super admin", "SUPER ADMIN" });

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
                name: "IX_DbClassification_ClassificationStatusId",
                table: "DbClassification",
                column: "ClassificationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationLanguage_ClassificationId",
                table: "DbClassificationLanguage",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationLanguage_LanguageId",
                table: "DbClassificationLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationLevel_ClassificationId",
                table: "DbClassificationLevel",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationLevelLanguage_ClassificationLevelId",
                table: "DbClassificationLevelLanguage",
                column: "ClassificationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationLevelLanguage_LanguageId",
                table: "DbClassificationLevelLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationPage_ClassificationId",
                table: "DbClassificationPage",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationPageLanguage_ClassificationPageId",
                table: "DbClassificationPageLanguage",
                column: "ClassificationPageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationPageLanguage_LanguageId",
                table: "DbClassificationPageLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationPageSection_ClassificationPageId",
                table: "DbClassificationPageSection",
                column: "ClassificationPageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationPageSection_ContentTypeId",
                table: "DbClassificationPageSection",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationPageSection_SectionTypeId",
                table: "DbClassificationPageSection",
                column: "SectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationPageSectionLanguage_LanguageId",
                table: "DbClassificationPageSectionLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationPageSectionLanguage_PageSectionId",
                table: "DbClassificationPageSectionLanguage",
                column: "PageSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationValue_ClassificationId",
                table: "DbClassificationValue",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationValueLanguage_ClassificationValueId",
                table: "DbClassificationValueLanguage",
                column: "ClassificationValueId");

            migrationBuilder.CreateIndex(
                name: "IX_DbClassificationValueLanguage_LanguageId",
                table: "DbClassificationValueLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContent_ContentStatusId",
                table: "DbContent",
                column: "ContentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContent_ContentTypeId",
                table: "DbContent",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContent_LanguageId",
                table: "DbContent",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContent_OrganizationId",
                table: "DbContent",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContent_ProjectId",
                table: "DbContent",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContent_SecurityLevel",
                table: "DbContent",
                column: "SecurityLevel");

            migrationBuilder.CreateIndex(
                name: "IX_DbContent_SuProcessTemplateStepFieldStatusModelId",
                table: "DbContent",
                column: "SuProcessTemplateStepFieldStatusModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContentClassificationValue_ClassificationValueId",
                table: "DbContentClassificationValue",
                column: "ClassificationValueId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContentClassificationValue_ContentId",
                table: "DbContentClassificationValue",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContentType_ContentTypeGroupId",
                table: "DbContentType",
                column: "ContentTypeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeClassification_ClassificationId",
                table: "dbContentTypeClassification",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeClassification_ContentTypeId",
                table: "dbContentTypeClassification",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeClassification_StatusId",
                table: "dbContentTypeClassification",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeClassificationStatusLanguage_ContentTypeClassificationStatusId",
                table: "dbContentTypeClassificationStatusLanguage",
                column: "ContentTypeClassificationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dbContentTypeClassificationStatusLanguage_LanguageId",
                table: "dbContentTypeClassificationStatusLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContentTypeGroupLanguage_ContentTypeGroupId",
                table: "DbContentTypeGroupLanguage",
                column: "ContentTypeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContentTypeGroupLanguage_LanguageId",
                table: "DbContentTypeGroupLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContentTypeLanguage_ContentTypeId",
                table: "DbContentTypeLanguage",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbContentTypeLanguage_LanguageId",
                table: "DbContentTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbLeftMenuLanguage_LanguageId",
                table: "dbLeftMenuLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbLeftMenuLanguage_LeftMenuId",
                table: "dbLeftMenuLanguage",
                column: "LeftMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_dbLeftMenuUser_LeftMenuId",
                table: "dbLeftMenuUser",
                column: "LeftMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_dbMenu1_MenuTypeId",
                table: "dbMenu1",
                column: "MenuTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbMenu1Language_LanguageId",
                table: "dbMenu1Language",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbMenu1Language_Menu1Id",
                table: "dbMenu1Language",
                column: "Menu1Id");

            migrationBuilder.CreateIndex(
                name: "IX_dbMenu2_Menu1Id",
                table: "dbMenu2",
                column: "Menu1Id");

            migrationBuilder.CreateIndex(
                name: "IX_dbMenu2_MenuTypeId",
                table: "dbMenu2",
                column: "MenuTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbMenu2Language_LanguageId",
                table: "dbMenu2Language",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbMenu2Language_Menu1Id",
                table: "dbMenu2Language",
                column: "Menu1Id");

            migrationBuilder.CreateIndex(
                name: "IX_dbMenu3_Menu2Id",
                table: "dbMenu3",
                column: "Menu2Id");

            migrationBuilder.CreateIndex(
                name: "IX_dbMenu3_MenuTypeId",
                table: "dbMenu3",
                column: "MenuTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbMenu3Language_LanguageId",
                table: "dbMenu3Language",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbMenu3Language_Menu1Id",
                table: "dbMenu3Language",
                column: "Menu1Id");

            migrationBuilder.CreateIndex(
                name: "IX_DbOrganization_OrganizationStatusId",
                table: "DbOrganization",
                column: "OrganizationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DbOrganization_OrganizationTypeId",
                table: "DbOrganization",
                column: "OrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbOrganization_ParentOrganizationId",
                table: "DbOrganization",
                column: "ParentOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DbOrganizationLanguage_LanguageId",
                table: "DbOrganizationLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbOrganizationLanguage_OrganizationId",
                table: "DbOrganizationLanguage",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DbOrganizationTypeLanguage_LanguageId",
                table: "DbOrganizationTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbOrganizationTypeLanguage_OrganizationTypeId",
                table: "DbOrganizationTypeLanguage",
                column: "OrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPage_PageStatusId",
                table: "DbPage",
                column: "PageStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPage_PageTypeId",
                table: "DbPage",
                column: "PageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPageLanguage_LanguageId",
                table: "DbPageLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPageLanguage_PageId",
                table: "DbPageLanguage",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPageSection_ContentTypeId",
                table: "DbPageSection",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPageSection_PageId",
                table: "DbPageSection",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPageSection_PageSectionTypeId",
                table: "DbPageSection",
                column: "PageSectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPageSectionLanguage_LanguageId",
                table: "DbPageSectionLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPageSectionLanguage_PageSectionId",
                table: "DbPageSectionLanguage",
                column: "PageSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPageSectionTypeLanguage_LanguageId",
                table: "DbPageSectionTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPageSectionTypeLanguage_PageTypeId",
                table: "DbPageSectionTypeLanguage",
                column: "PageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPageTypeLanguage_LanguageId",
                table: "DbPageTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbPageTypeLanguage_PageTypeId",
                table: "DbPageTypeLanguage",
                column: "PageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcess_ProcessTemplateId",
                table: "DbProcess",
                column: "ProcessTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcess_SuProcessMultiModelId",
                table: "DbProcess",
                column: "SuProcessMultiModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessField_ProcessId",
                table: "DbProcessField",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessField_ProcessTemplateFieldId",
                table: "DbProcessField",
                column: "ProcessTemplateFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplate_ProcessTemplateGroupId",
                table: "DbProcessTemplate",
                column: "ProcessTemplateGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateField_ProcessTemplateFieldTypeId",
                table: "DbProcessTemplateField",
                column: "ProcessTemplateFieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateField_ProcessTemplateId",
                table: "DbProcessTemplateField",
                column: "ProcessTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateField_SuProcessModelId",
                table: "DbProcessTemplateField",
                column: "SuProcessModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateFieldLanguage_LanguageId",
                table: "DbProcessTemplateFieldLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateFieldLanguage_ProcessTemplateFieldId",
                table: "DbProcessTemplateFieldLanguage",
                column: "ProcessTemplateFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateFieldTypeLanguage_FieldTypeId",
                table: "DbProcessTemplateFieldTypeLanguage",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateFieldTypeLanguage_LanguageId",
                table: "DbProcessTemplateFieldTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateFlow_ProcessTemplateId",
                table: "DbProcessTemplateFlow",
                column: "ProcessTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateFlowCondition_ProcessTemplateConditionTypeId",
                table: "DbProcessTemplateFlowCondition",
                column: "ProcessTemplateConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateFlowCondition_ProcessTemplateFlowId",
                table: "DbProcessTemplateFlowCondition",
                column: "ProcessTemplateFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateFlowConditionLanguage_FlowConditionId",
                table: "DbProcessTemplateFlowConditionLanguage",
                column: "FlowConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateFlowConditionLanguage_LanguageId",
                table: "DbProcessTemplateFlowConditionLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateFlowLanguage_FlowId",
                table: "DbProcessTemplateFlowLanguage",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateFlowLanguage_LanguageId",
                table: "DbProcessTemplateFlowLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateGroupLanguage_LanguageId",
                table: "DbProcessTemplateGroupLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateGroupLanguage_ProcessTemplateGroupId",
                table: "DbProcessTemplateGroupLanguage",
                column: "ProcessTemplateGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateLanguage_LanguageId",
                table: "DbProcessTemplateLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateLanguage_ProcessTemplateGroupId",
                table: "DbProcessTemplateLanguage",
                column: "ProcessTemplateGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateStep_ProcessTemplateId",
                table: "DbProcessTemplateStep",
                column: "ProcessTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateStep_ProcessTemplateStepTypeId",
                table: "DbProcessTemplateStep",
                column: "ProcessTemplateStepTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateStepField_FieldId",
                table: "DbProcessTemplateStepField",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateStepField_StatusId",
                table: "DbProcessTemplateStepField",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateStepField_StepId",
                table: "DbProcessTemplateStepField",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateStepLanguage_LanguageId",
                table: "DbProcessTemplateStepLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProcessTemplateStepLanguage_StepId",
                table: "DbProcessTemplateStepLanguage",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepTypeLanguage_LanguageId",
                table: "dbProcessTemplateStepTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_dbProcessTemplateStepTypeLanguage_StepTypeId",
                table: "dbProcessTemplateStepTypeLanguage",
                column: "StepTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProject_ProjectStatusId",
                table: "DbProject",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProjectLanguage_LanguageId",
                table: "DbProjectLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbProjectLanguage_ProjectId",
                table: "DbProjectLanguage",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUITermLanguage_LanguageId",
                table: "DbUITermLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUITermLanguage_TermId",
                table: "DbUITermLanguage",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUITermScreen_ScreenId",
                table: "DbUITermScreen",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUITermScreen_TermId",
                table: "DbUITermScreen",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserOrganization_OrganizationId",
                table: "DbUserOrganization",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserOrganization_TypeId",
                table: "DbUserOrganization",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserOrganization_UserId",
                table: "DbUserOrganization",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserOrganizationTypeLanguage_LanguageId",
                table: "DbUserOrganizationTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserOrganizationTypeLanguage_TypeId",
                table: "DbUserOrganizationTypeLanguage",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserProject_ProjectId",
                table: "DbUserProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserProject_TypeId",
                table: "DbUserProject",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserProject_UserId",
                table: "DbUserProject",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserProjectTypeLanguage_LanguageId",
                table: "DbUserProjectTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserProjectTypeLanguage_TypeId",
                table: "DbUserProjectTypeLanguage",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserRelation_FromUserId",
                table: "DbUserRelation",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserRelation_ToUserId",
                table: "DbUserRelation",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserRelation_TypeId",
                table: "DbUserRelation",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserRelationTypeLanguage_LanguageId",
                table: "DbUserRelationTypeLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DbUserRelationTypeLanguage_TypeId",
                table: "DbUserRelationTypeLanguage",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdbExternalContent_PId",
                table: "ZdbExternalContent",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdbExternalPageSection_PId",
                table: "ZdbExternalPageSection",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdbFrontContent_PId",
                table: "ZdbFrontContent",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdbFrontPageSection_PId",
                table: "ZdbFrontPageSection",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdbFrontProcessCreateGetField_PId",
                table: "ZdbFrontProcessCreateGetField",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdbFrontProcessIndexGetTemplate_PId",
                table: "ZdbFrontProcessIndexGetTemplate",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdbHomeIndexAdminGetNoOfRecordsAndPerLanguage_TableDescription",
                table: "ZdbHomeIndexAdminGetNoOfRecordsAndPerLanguage",
                column: "TableDescription");

            migrationBuilder.CreateIndex(
                name: "IX_ZdbMenu2_PId",
                table: "ZdbMenu2",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_ZdbMenu3_PId",
                table: "ZdbMenu3",
                column: "PId");
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
                name: "DbClaim");

            migrationBuilder.DropTable(
                name: "DbClassificationLanguage");

            migrationBuilder.DropTable(
                name: "DbClassificationLevelLanguage");

            migrationBuilder.DropTable(
                name: "DbClassificationPageLanguage");

            migrationBuilder.DropTable(
                name: "DbClassificationPageSectionLanguage");

            migrationBuilder.DropTable(
                name: "DbClassificationValueLanguage");

            migrationBuilder.DropTable(
                name: "DbComparison");

            migrationBuilder.DropTable(
                name: "DbContentClassificationValue");

            migrationBuilder.DropTable(
                name: "dbContentTypeClassification");

            migrationBuilder.DropTable(
                name: "dbContentTypeClassificationStatusLanguage");

            migrationBuilder.DropTable(
                name: "DbContentTypeGroupLanguage");

            migrationBuilder.DropTable(
                name: "DbContentTypeLanguage");

            migrationBuilder.DropTable(
                name: "DbCountry");

            migrationBuilder.DropTable(
                name: "DbDataType");

            migrationBuilder.DropTable(
                name: "DbIdWithStrings");

            migrationBuilder.DropTable(
                name: "dbLeftMenuLanguage");

            migrationBuilder.DropTable(
                name: "dbLeftMenuUser");

            migrationBuilder.DropTable(
                name: "dbMenu1Language");

            migrationBuilder.DropTable(
                name: "dbMenu2Language");

            migrationBuilder.DropTable(
                name: "dbMenu3Language");

            migrationBuilder.DropTable(
                name: "DbObject");

            migrationBuilder.DropTable(
                name: "DbObjectVM");

            migrationBuilder.DropTable(
                name: "DbOrganizationLanguage");

            migrationBuilder.DropTable(
                name: "DbOrganizationTypeLanguage");

            migrationBuilder.DropTable(
                name: "DbPageLanguage");

            migrationBuilder.DropTable(
                name: "DbPageSectionLanguage");

            migrationBuilder.DropTable(
                name: "DbPageSectionsViewModel");

            migrationBuilder.DropTable(
                name: "DbPageSectionTypeLanguage");

            migrationBuilder.DropTable(
                name: "DbPageTypeLanguage");

            migrationBuilder.DropTable(
                name: "DbProcessField");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateFieldLanguage");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateFieldTypeLanguage");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateFlowConditionLanguage");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateFlowLanguage");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateGroupLanguage");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateLanguage");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateStepField");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateStepLanguage");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateStepTypeLanguage");

            migrationBuilder.DropTable(
                name: "DbProjectLanguage");

            migrationBuilder.DropTable(
                name: "DbSetting");

            migrationBuilder.DropTable(
                name: "dbTableName");

            migrationBuilder.DropTable(
                name: "DbUITermLanguage");

            migrationBuilder.DropTable(
                name: "DbUITermScreen");

            migrationBuilder.DropTable(
                name: "DbUserOrganization");

            migrationBuilder.DropTable(
                name: "DbUserOrganizationTypeLanguage");

            migrationBuilder.DropTable(
                name: "DbUserProject");

            migrationBuilder.DropTable(
                name: "DbUserProjectTypeLanguage");

            migrationBuilder.DropTable(
                name: "DbUserRelation");

            migrationBuilder.DropTable(
                name: "DbUserRelationTypeLanguage");

            migrationBuilder.DropTable(
                name: "DbValueList");

            migrationBuilder.DropTable(
                name: "ZdbClassificationDeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbClassificationEditGet");

            migrationBuilder.DropTable(
                name: "ZdbClassificationLevelDeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbClassificationLevelEditGet");

            migrationBuilder.DropTable(
                name: "ZdbClassificationLevelIndexGet");

            migrationBuilder.DropTable(
                name: "ZdbClassificationPageDeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbClassificationPageEditGet");

            migrationBuilder.DropTable(
                name: "ZdbClassificationPageLanguageEditGet");

            migrationBuilder.DropTable(
                name: "ZdbClassificationPageSectionDeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbClassificationPageSectionEditGet");

            migrationBuilder.DropTable(
                name: "ZdbClassificationPageSectionLanguageEditGet");

            migrationBuilder.DropTable(
                name: "ZdbClassificationValueEditGet");

            migrationBuilder.DropTable(
                name: "ZdbClassificationValueEditGetLevel");

            migrationBuilder.DropTable(
                name: "ZdbClassificationValueIndexGet");

            migrationBuilder.DropTable(
                name: "ZdbContentCreate2GetClassifications");

            migrationBuilder.DropTable(
                name: "ZdbContentEditGetClassificationValues");

            migrationBuilder.DropTable(
                name: "ZdbContentEditGetContent");

            migrationBuilder.DropTable(
                name: "ZdbContentTypeClassificationEditGet");

            migrationBuilder.DropTable(
                name: "ZdbContentTypeClassificationEditGetStatusList");

            migrationBuilder.DropTable(
                name: "ZdbContentTypeClassificationIndexGet");

            migrationBuilder.DropTable(
                name: "ZDbContentTypeDeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbContentTypeEditGet");

            migrationBuilder.DropTable(
                name: "ZdbContentTypeGroupEditGet");

            migrationBuilder.DropTable(
                name: "ZDbCountryList");

            migrationBuilder.DropTable(
                name: "ZdbExternalContent");

            migrationBuilder.DropTable(
                name: "ZdbExternalPageMyContentGet");

            migrationBuilder.DropTable(
                name: "ZdbExternalPageViewGet");

            migrationBuilder.DropTable(
                name: "ZdbFrontCalendarEventCalendar");

            migrationBuilder.DropTable(
                name: "ZdbFrontContent");

            migrationBuilder.DropTable(
                name: "ZdbFrontOrganizationDashboardGetContent");

            migrationBuilder.DropTable(
                name: "ZdbFrontOrganizationDashboardGetOrganization");

            migrationBuilder.DropTable(
                name: "ZdbFrontOrganizationDashboardGetUsers");

            migrationBuilder.DropTable(
                name: "ZdbFrontOrganizationMyOrganizationGet");

            migrationBuilder.DropTable(
                name: "ZdbFrontPageMyContentGet");

            migrationBuilder.DropTable(
                name: "ZdbFrontPageViewGet");

            migrationBuilder.DropTable(
                name: "ZdbFrontProcessCreateGetField");

            migrationBuilder.DropTable(
                name: "ZdbFrontProcessIndexGetTemplate");

            migrationBuilder.DropTable(
                name: "ZdbFrontProcessIndexGetTemplateFlowCondition");

            migrationBuilder.DropTable(
                name: "ZdbFrontProcessToDoIndex2Get");

            migrationBuilder.DropTable(
                name: "ZdbFrontProcessToDoIndex2GetForAndOr");

            migrationBuilder.DropTable(
                name: "ZdbFrontProjectMyProjectGet");

            migrationBuilder.DropTable(
                name: "ZdbFrontRelationMyRelationGet");

            migrationBuilder.DropTable(
                name: "ZdbFrontUserIndexGet");

            migrationBuilder.DropTable(
                name: "ZDbGetProjectStructure");

            migrationBuilder.DropTable(
                name: "ZdbHomeIndexAdminGetLanguages");

            migrationBuilder.DropTable(
                name: "ZdbHomeIndexAdminGetNoOfRecordsAndPerLanguage");

            migrationBuilder.DropTable(
                name: "ZdbInt");

            migrationBuilder.DropTable(
                name: "ZdbInt2");

            migrationBuilder.DropTable(
                name: "ZdbLanguageCreateGetLanguageList");

            migrationBuilder.DropTable(
                name: "ZDbLanguageList");

            migrationBuilder.DropTable(
                name: "ZdbLayoutTermList");

            migrationBuilder.DropTable(
                name: "ZdbLeftMenu");

            migrationBuilder.DropTable(
                name: "ZDbMasterList");

            migrationBuilder.DropTable(
                name: "ZdbMenu1DeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbMenu1EditGet");

            migrationBuilder.DropTable(
                name: "ZdbMenu1IndexGet");

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

            migrationBuilder.DropTable(
                name: "ZdbObjectIndexGet");

            migrationBuilder.DropTable(
                name: "ZdbObjectIndexGet2");

            migrationBuilder.DropTable(
                name: "ZdbObjectLanguageCreateGet");

            migrationBuilder.DropTable(
                name: "ZdbObjectLanguageEditGet");

            migrationBuilder.DropTable(
                name: "ZdbObjectLanguageIndexGet");

            migrationBuilder.DropTable(
                name: "ZDbOrganizationDeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbOrganizationEditGet");

            migrationBuilder.DropTable(
                name: "ZdbOrganizationIndexGet");

            migrationBuilder.DropTable(
                name: "ZDbOrganizationTypeDeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbOrganizationTypeEditGet");

            migrationBuilder.DropTable(
                name: "ZDbPageDeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbPageLanguageEditGet");

            migrationBuilder.DropTable(
                name: "ZDbPageSectionDeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbPageSectionEditGet");

            migrationBuilder.DropTable(
                name: "ZdbPageSectionTypeEditGet");

            migrationBuilder.DropTable(
                name: "ZdbPageTypeEditGet");

            migrationBuilder.DropTable(
                name: "ZdbPreferenceIndexGet");

            migrationBuilder.DropTable(
                name: "ZdbPreferenceLeftMenuEditGet");

            migrationBuilder.DropTable(
                name: "ZdbPreferenceLeftMenuGet");

            migrationBuilder.DropTable(
                name: "ZdbPreferenceLeftMenuGetAvailableMenus");

            migrationBuilder.DropTable(
                name: "ZdbProcessTemplateFlowConditionEditGet");

            migrationBuilder.DropTable(
                name: "ZDbSecurityLevelList");

            migrationBuilder.DropTable(
                name: "ZDbStatusList");

            migrationBuilder.DropTable(
                name: "ZdbSuFrontPageViewGetClassificationValues");

            migrationBuilder.DropTable(
                name: "ZdbSuFrontProcessTodoEditGet");

            migrationBuilder.DropTable(
                name: "ZdbSuFrontProcessTodoIndexGet");

            migrationBuilder.DropTable(
                name: "ZdbSuFrontUserUserDashboardGetRelation");

            migrationBuilder.DropTable(
                name: "ZdbSuProcessTemplateFieldEditGet");

            migrationBuilder.DropTable(
                name: "ZdbTermLanguageCreateGetWith");

            migrationBuilder.DropTable(
                name: "ZdbTopMenu1");

            migrationBuilder.DropTable(
                name: "ZdbTopMenu2");

            migrationBuilder.DropTable(
                name: "ZDbTypeList");

            migrationBuilder.DropTable(
                name: "ZDbUITermLanguageEditGet");

            migrationBuilder.DropTable(
                name: "ZDbUITermList");

            migrationBuilder.DropTable(
                name: "ZdbUserRelationTypeIndexGet");

            migrationBuilder.DropTable(
                name: "ZdbUserRelationTypeLanguageDeleteGet");

            migrationBuilder.DropTable(
                name: "ZdbUserRelationTypeLanguageEditGet");

            migrationBuilder.DropTable(
                name: "ZdbUserRelationTypeLanguageIndexGet");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DbClassificationLevel");

            migrationBuilder.DropTable(
                name: "DbClassificationPageSection");

            migrationBuilder.DropTable(
                name: "DbClassificationValue");

            migrationBuilder.DropTable(
                name: "DbContent");

            migrationBuilder.DropTable(
                name: "dbContentTypeClassificationStatus");

            migrationBuilder.DropTable(
                name: "dbLeftMenu");

            migrationBuilder.DropTable(
                name: "dbMenu3");

            migrationBuilder.DropTable(
                name: "DbPageSection");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateFlowCondition");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateField");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateStep");

            migrationBuilder.DropTable(
                name: "DbUIScreen");

            migrationBuilder.DropTable(
                name: "DbUITerm");

            migrationBuilder.DropTable(
                name: "DbUserOrganizationType");

            migrationBuilder.DropTable(
                name: "DbUserProjectType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DbUserRelationType");

            migrationBuilder.DropTable(
                name: "ZdbExternalPageSection");

            migrationBuilder.DropTable(
                name: "ZdbFrontPageSection");

            migrationBuilder.DropTable(
                name: "ZdbFrontProcessCreateGet");

            migrationBuilder.DropTable(
                name: "ZdbFrontProcessIndexGetTemplateGroup");

            migrationBuilder.DropTable(
                name: "ZdbHomeIndexAdminGetTableName");

            migrationBuilder.DropTable(
                name: "ZdbMenu2");

            migrationBuilder.DropTable(
                name: "DbClassificationPage");

            migrationBuilder.DropTable(
                name: "DbContentStatus");

            migrationBuilder.DropTable(
                name: "DbLanguage");

            migrationBuilder.DropTable(
                name: "DbOrganization");

            migrationBuilder.DropTable(
                name: "DbProject");

            migrationBuilder.DropTable(
                name: "DbSecurityLevel");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateStepFieldStatus");

            migrationBuilder.DropTable(
                name: "dbMenu2");

            migrationBuilder.DropTable(
                name: "DbContentType");

            migrationBuilder.DropTable(
                name: "DbPage");

            migrationBuilder.DropTable(
                name: "DbPageSectionType");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateFlowConditionType");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateFlow");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateFieldType");

            migrationBuilder.DropTable(
                name: "DbProcess");

            migrationBuilder.DropTable(
                name: "dbProcessTemplateStepType");

            migrationBuilder.DropTable(
                name: "ZdbExternalPage");

            migrationBuilder.DropTable(
                name: "ZdbFrontPage");

            migrationBuilder.DropTable(
                name: "ZdbMenu1");

            migrationBuilder.DropTable(
                name: "DbClassification");

            migrationBuilder.DropTable(
                name: "DbOrganizationStatus");

            migrationBuilder.DropTable(
                name: "DbOrganizationType");

            migrationBuilder.DropTable(
                name: "DbProjectStatus");

            migrationBuilder.DropTable(
                name: "dbMenu1");

            migrationBuilder.DropTable(
                name: "DbContentTypeGroup");

            migrationBuilder.DropTable(
                name: "DbPageStatus");

            migrationBuilder.DropTable(
                name: "DbPageType");

            migrationBuilder.DropTable(
                name: "DbProcessTemplate");

            migrationBuilder.DropTable(
                name: "dbProcessMulti");

            migrationBuilder.DropTable(
                name: "DbClassificationStatus");

            migrationBuilder.DropTable(
                name: "dbMenuType");

            migrationBuilder.DropTable(
                name: "DbProcessTemplateGroup");
        }
    }
}

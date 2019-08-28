﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentUnion0105.Data;

namespace StudentUnion0105.Migrations
{
    [DbContext(typeof(SuDbContext))]
    [Migration("20190827142013_test2")]
    partial class test2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Claim");

                    b.Property<string>("ClaimGroup");

                    b.HasKey("Id");

                    b.ToTable("dbClaim");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Claim = "Classification",
                            ClaimGroup = "Classification"
                        },
                        new
                        {
                            Id = 3,
                            Claim = "ClassificationPage",
                            ClaimGroup = "Classification"
                        },
                        new
                        {
                            Id = 4,
                            Claim = "Roles",
                            ClaimGroup = "Administration"
                        },
                        new
                        {
                            Id = 2,
                            Claim = "ClassificationLevel",
                            ClaimGroup = "Classification"
                        });
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClassificationLanguageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassificationId");

                    b.Property<string>("ClassificationMenuName");

                    b.Property<string>("ClassificationMouseOver");

                    b.Property<string>("ClassificationName");

                    b.Property<int>("LanguageId");

                    b.HasKey("Id");

                    b.HasIndex("ClassificationId");

                    b.HasIndex("LanguageId");

                    b.ToTable("dbClassificationLanguage");
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClassificationLevelLanguageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassificationLevelId");

                    b.Property<string>("ClassificationLevelMenuName");

                    b.Property<string>("ClassificationLevelMouseOver");

                    b.Property<string>("ClassificationLevelName");

                    b.Property<int>("LanguageId");

                    b.HasKey("Id");

                    b.HasIndex("ClassificationLevelId");

                    b.HasIndex("LanguageId");

                    b.ToTable("dbClassificationLevelLanguage");
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClassificationLevelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Alphabetically");

                    b.Property<bool>("CanLink");

                    b.Property<int>("ClassificationId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("CreatorId");

                    b.Property<bool>("DateLevel");

                    b.Property<bool>("InDropDown");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<Guid>("ModifierId");

                    b.Property<bool>("OnTheFly");

                    b.Property<int>("Sequence");

                    b.HasKey("Id");

                    b.HasIndex("ClassificationId");

                    b.ToTable("dbClassificationLevel");
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClassificationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassificationStatusId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("CreatorId");

                    b.Property<int>("DefailClassificationPageId");

                    b.Property<int>("DropDownSequence");

                    b.Property<bool>("HasDropDown");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<Guid>("ModifierId");

                    b.HasKey("Id");

                    b.HasIndex("ClassificationStatusId");

                    b.ToTable("dbClassification");
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClassificationStatusModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassificationStatusName");

                    b.HasKey("Id");

                    b.ToTable("dbClassificationStatus");
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClassificationValueLanguageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassificationValueDescription");

                    b.Property<string>("ClassificationValueDropDownName");

                    b.Property<string>("ClassificationValueHeaderDescription");

                    b.Property<string>("ClassificationValueHeaderName");

                    b.Property<int>("ClassificationValueId");

                    b.Property<string>("ClassificationValueMenuName");

                    b.Property<string>("ClassificationValueMouseOver");

                    b.Property<string>("ClassificationValueName");

                    b.Property<string>("ClassificationValuePageDescription");

                    b.Property<string>("ClassificationValuePageName");

                    b.Property<string>("ClassificationValueTopicName");

                    b.Property<int>("LanguageId");

                    b.HasKey("Id");

                    b.HasIndex("ClassificationValueId");

                    b.HasIndex("LanguageId");

                    b.ToTable("dbClassificationValueLanguage");
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClassificationValueModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassificationLevelId");

                    b.Property<DateTimeOffset>("DateFrom");

                    b.Property<DateTimeOffset>("DateTo");

                    b.Property<int>("ParentValueId");

                    b.HasKey("Id");

                    b.HasIndex("ClassificationLevelId");

                    b.ToTable("dbClassificationValue");
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuLanguageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("dbLanguage");
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("DefaultLangauge");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StudentUnion0105.Models.SuUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StudentUnion0105.Models.SuUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentUnion0105.Models.SuUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StudentUnion0105.Models.SuUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClassificationLanguageModel", b =>
                {
                    b.HasOne("StudentUnion0105.Models.SuClassificationModel", "Classification")
                        .WithMany("ClassificationLanguages")
                        .HasForeignKey("ClassificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentUnion0105.Models.SuLanguageModel", "Language")
                        .WithMany("ClassificationLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClassificationLevelLanguageModel", b =>
                {
                    b.HasOne("StudentUnion0105.Models.SuClassificationLevelModel", "ClassificationLevel")
                        .WithMany("ClassificationLevelLanguages")
                        .HasForeignKey("ClassificationLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentUnion0105.Models.SuLanguageModel", "Language")
                        .WithMany("ClassificationLevelLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClassificationLevelModel", b =>
                {
                    b.HasOne("StudentUnion0105.Models.SuClassificationModel", "Classification")
                        .WithMany("ClassificationLevels")
                        .HasForeignKey("ClassificationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClassificationModel", b =>
                {
                    b.HasOne("StudentUnion0105.Models.SuClassificationStatusModel", "ClassificationStatus")
                        .WithMany("Classifications")
                        .HasForeignKey("ClassificationStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClassificationValueLanguageModel", b =>
                {
                    b.HasOne("StudentUnion0105.Models.SuClassificationValueModel", "ClassificationValue")
                        .WithMany("ClassificationValueLanguages")
                        .HasForeignKey("ClassificationValueId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("StudentUnion0105.Models.SuLanguageModel", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentUnion0105.Models.SuClassificationValueModel", b =>
                {
                    b.HasOne("StudentUnion0105.Models.SuClassificationLevelModel", "ClassificationLevel")
                        .WithMany("ClassificationValues")
                        .HasForeignKey("ClassificationLevelId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

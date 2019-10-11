using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Models;
using StudentUnion0105.SPModel;
using StudentUnion0105.ViewModels;
using static StudentUnion0105.SPModel.GetProjectStructure;

namespace StudentUnion0105.Data
{

    public class SuDbContext : IdentityDbContext<SuUserModel>
    {


        public SuDbContext(DbContextOptions<SuDbContext> options) : base(options)
        {

        }
        public DbSet<SuClassificationModel> dbClassification { get; set; }
        public DbSet<SuClassificationStatusModel> dbClassificationStatus { get; set; }
        public DbSet<SuClassificationLanguageModel> dbClassificationLanguage { get; set; }
        public DbSet<SuClassificationLevelModel> dbClassificationLevel { get; set; }
        public DbSet<SuClassificationLevelLanguageModel> dbClassificationLevelLanguage { get; set; }
        public DbSet<SuClassificationValueModel> dbClassificationValue { get; set; }
        public DbSet<SuClassificationValueLanguageModel> dbClassificationValueLanguage { get; set; }
        public DbSet<SuContentTypeLanguageModel> dbContentTypeLanguage { get; set; }
        public DbSet<SuOrganizationLanguageModel> dbOrganizationLanguage { get; set; }
        public DbSet<SuOrganizationModel> dbOrganization { get; set; }
        public DbSet<SuOrganizationStatusModel> dbOrganizationStatus { get; set; }
        public DbSet<SuOrganizationTypeLanguageModel> dbOrganizationTypeLanguage { get; set; }
        public DbSet<SuOrganizationTypeModel> dbOrganizationType { get; set; }
        public DbSet<SuProjectLanguageModel> dbProjectLanguage { get; set; }
        public DbSet<SuProjectModel> dbProject { get; set; }
        public DbSet<SuProjectStatusModel> dbProjectStatus { get; set; }
        public DbSet<SuContentTypeModel> dbContentType { get; set; }
        public DbSet<SuLanguageModel> dbLanguage { get; set; }
        public DbSet<SuCountryModel> dbCountry { get; set; }
        public DbSet<SuSettingModel> dbSetting { get; set; }
        public DbSet<SuPageLanguageModel> dbPageLanguage { get; set; }
        public DbSet<SuPageModel> dbPage { get; set; }
        public DbSet<SuPageStatusModel> dbPageStatus { get; set; }
        public DbSet<SuPageTypeLanguageModel> dbPageTypeLanguage { get; set; }
        public DbSet<SuPageTypeModel> dbPageType { get; set; }
        public DbSet<SuPageSectionModel> dbPageSection { get; set; }
        public DbSet<SuPageSectionLanguageModel> dbPageSectionLanguage { get; set; }
        public DbSet<SuPageSectionTypeModel> dbPageSectionType { get; set; }
        public DbSet<SuPageSectionTypeLanguageModel> dbPageSectionTypeLanguage { get; set; }
        public DbSet<SuContentModel> dbContent { get; set; }
        public DbSet<SuContentClassificationValueModel> dbContentClassificationValue { get; set; }
        public DbSet<SuContentStatusModel> dbContentStatus { get; set; }
        public DbSet<SuProcessTemplateFieldLanguageModel> dbProcessTemplateFieldLanguage { get; set; }
        public DbSet<SuProcessTemplateFieldModel> dbProcessTemplateField { get; set; }
        public DbSet<SuProcessTemplateFieldTypeLanguageModel> dbProcessTemplateFieldTypeLanguage { get; set; }
        public DbSet<SuProcessTemplateFieldTypeModel> dbProcessTemplateFieldType { get; set; }
        public DbSet<SuProcessTemplateFlowConditionTypeModel> dbProcessTemplateFlowConditionType { get; set; }
        public DbSet<SuProcessTemplateFlowConditionLanguageModel> dbProcessTemplateFlowConditionLanguage { get; set; }
        public DbSet<SuProcessTemplateFlowConditionModel> dbProcessTemplateFlowCondition { get; set; }
        public DbSet<SuProcessTemplateFlowModel> dbProcessTemplateFlow { get; set; }
        public DbSet<SuProcessTemplateFlowLanguageModel> dbProcessTemplateFlowLanguage { get; set; }
        public DbSet<SuProcessTemplateGroupLanguageModel> dbProcessTemplateGroupLanguage { get; set; }
        public DbSet<SuProcessTemplateGroupModel> dbProcessTemplateGroup { get; set; }
        public DbSet<SuProcessTemplateLanguageModel> dbProcessTemplateLanguage { get; set; }
        public DbSet<SuProcessTemplateModel> dbProcessTemplate { get; set; }
        public DbSet<SuProcessTemplateStepFieldModel> dbProcessTemplateStepField { get; set; }
        public DbSet<SuProcessTemplateStepFieldStatusModel> dbProcessTemplateStepFieldStatus { get; set; }
        public DbSet<SuProcessTemplateStepLanguageModel> dbProcessTemplateStepLanguage { get; set; }
        public DbSet<SuProcessTemplateStepModel> dbProcessTemplateStep { get; set; }
        public DbSet<SuUserOrganizationModel> dbUserOrganization { get; set; }
        public DbSet<SuUserOrganizationTypeModel> dbUserOrganizationType { get; set; }
        public DbSet<SuUserOrganizationTypeLanguageModel> dbUserOrganizationTypeLanguage { get; set; }
        public DbSet<SuUserProjectModel> dbUserProject { get; set; }
        public DbSet<SuUserProjectTypeModel> dbUserProjectType { get; set; }
        public DbSet<SuUserProjectTypeLanguageModel> dbUserProjectTypeLanguage { get; set; }
        public DbSet<SuUserRelationModel> dbUserRelation { get; set; }
        public DbSet<SuUserRelationTypeModel> dbUserRelationType { get; set; }
        public DbSet<SuUserRelationTypeLanguageModel> dbUserRelationTypeLanguage { get; set; }
        public DbSet<SuMasterListModel> dbMasterList { get; set; }
        public DbSet<SuDataTypeModel> dbDataType { get; set; }
        public DbSet<SuSecurityLevelModel> dbSecurityLevel { get; set; }
        public DbSet<SuStatusList> dbStatusList { get; set; }
        public DbSet<SuSecurityLevelList> dbSecurityLevelList { get; set; }
        public DbSet<SuLanguageList> dbLanguageList { get; set; }
        public DbSet<SuCountryList> dbCountryList { get; set; }
        public DbSet<SuTypeList> dbTypeList { get; set; }
        public DbSet<SuValueList> dbValueList { get; set; }

        public DbSet<SuUIScreenModel> dbUIScreen { get; set; }
        public DbSet<SuUITermLanguageModel> dbUITermLanguage { get; set; }
        public DbSet<SuUITermModel> dbUITerm { get; set; }
        public DbSet<SuUITermScreenModel> dbUITermScreen { get; set; }


        public DbSet<SuGetOrganizationStructure> dbGetOrganizationStructure { get; set; }
        public DbSet<SuGetClassificationValueStructure> dbGetClassificationValueStructure { get; set; }
        public DbSet<SuGetProjectStructure> dbGetProjectStructure { get; set; }
        public DbSet<SuPageSectionsViewModel> dbPageSectionsViewModel { get; set; }
        public DbSet<SuObjectVM> dbObjectVM { get; set; }
        public DbSet<SuIdWithStrings> dbIdWithStrings { get; set; }

        public DbSet<SuClaim> dbClaim { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Super admin", NormalizedName = "Super admin".ToUpper() });

            modelBuilder.Entity<SuClassificationModel>()
                .HasMany(b => b.ClassificationValues)
                .WithOne(a => a.Classification)
                .HasConstraintName("FKClassificationValues")//.Metadata.DeleteBehavior = DeleteBehavior.Restrict;
                .HasForeignKey(b => b.ClassificationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict)
                ;

            //        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            //.SelectMany(t => t.GetForeignKeys())
            //.Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            //        foreach (var fk in cascadeFKs)
            //            fk.DeleteBehavior = DeleteBehavior.Restrict;

            //        base.OnModelCreating(modelBuilder);

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            modelBuilder.Entity<SuClassificationModel>()
                .HasOne(u => u.ClassificationStatus)
                .WithMany(u => u.Classifications) //.Metadata.DeleteBehavior = DeleteBehavior.Restrict;
                .HasForeignKey(u => u.ClassificationStatusId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SuClassificationLevelModel>()
                .HasOne(u => u.Classification)
                .WithMany(u => u.ClassificationLevels) //.Metadata.DeleteBehavior = DeleteBehavior.Restrict;
                .HasForeignKey(u => u.ClassificationId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SuClassificationLevelLanguageModel>()
                .HasOne(u => u.ClassificationLevel)
                .WithMany(u => u.ClassificationLevelLanguages) //.Metadata.DeleteBehavior = DeleteBehavior.Restrict;
                .HasForeignKey(u => u.ClassificationLevelId)
                .OnDelete(DeleteBehavior.Restrict);



            //modelBuilder.Entity<SuClassificationValueModel>()
            //    .HasOne(u => u.ClassificationLevel)
            //    .WithMany(u => u.ClassificationValues)//.Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            //    .HasForeignKey(u => u.ClassificationLevelId)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SuClassificationValueLanguageModel>()
                .HasOne(u => u.ClassificationValue)
                .WithMany(u => u.ClassificationValueLanguages)//.Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            .HasForeignKey(u => u.ClassificationValueId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SuClassificationLanguageModel>()
                .HasOne(u => u.Classification)
                .WithMany(u => u.ClassificationLanguages)
                .HasForeignKey(u => u.ClassificationId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<SuClaim>().HasData(
            //    new SuClaim { Id = 1, ClaimGroup = "Classification", Claim = "Classification", ClaimType="Menu" },
            //    new SuClaim { Id = 2, ClaimGroup = "Classification", Claim = "ClassificationPage", ClaimType = "Menu" },
            //    new SuClaim { Id = 3, ClaimGroup = "Administration", Claim = "Role", ClaimType = "Menu" },
            //    new SuClaim { Id = 4, ClaimGroup = "Classification", Claim = "ClassificationLevel", ClaimType = "Menu" },
            //    new SuClaim { Id = 5, ClaimGroup = "Type", Claim = "ContentType", ClaimType = "Menu" },
            //    new SuClaim { Id = 6, ClaimGroup = "Type", Claim = "OrganizationType", ClaimType = "Menu" },
            //    new SuClaim { Id = 7, ClaimGroup = "Type", Claim = "PageType", ClaimType = "Menu" },
            //    new SuClaim { Id = 8, ClaimGroup = "Page", Claim = "Page", ClaimType = "Menu" },
            //    new SuClaim { Id = 9, ClaimGroup = "Project", Claim = "Project", ClaimType = "Menu" },
            //    new SuClaim { Id = 10, ClaimGroup = "Type", Claim = "Type", ClaimType = "Menu" }
            //    );
            //modelBuilder.Entity<SuClassificationPageStatusModel>().Property(m => m.Id).ValueGeneratedNever();
            //modelBuilder.Entity<SuClassificationStatusModel>().Property(m => m.Id).ValueGeneratedNever();
            //modelBuilder.Entity<SuContentStatusModel>().Property(m => m.Id).ValueGeneratedNever();
            //modelBuilder.Entity<SuOrganizationStatusModel>().Property(m => m.Id).ValueGeneratedNever();
            //modelBuilder.Entity<SuPageStatusModel>().Property(m => m.Id).ValueGeneratedNever();
            //modelBuilder.Entity<SuProjectStatusModel>().Property(m => m.Id).ValueGeneratedNever();
            //modelBuilder.Entity<SuSecurityLevelModel>().Property(m => m.Id).ValueGeneratedNever();
            //modelBuilder.Entity<SuClaim>().Property(m => m.Id).ValueGeneratedNever();
            //modelBuilder.Entity<SuSettingModel>().Property(m => m.Id).ValueGeneratedNever();

            //modelBuilder.Entity<SuSecurityLevelModel>().HasData(
            //    new SuSecurityLevelModel { Id = 1, Name = "1" },
            //    new SuSecurityLevelModel { Id = 2, Name = "2" },
            //    new SuSecurityLevelModel { Id = 3, Name = "3" },
            //    new SuSecurityLevelModel { Id = 4, Name = "4" },
            //    new SuSecurityLevelModel { Id = 5, Name = "5" },
            //    new SuSecurityLevelModel { Id = 6, Name = "6" },
            //    new SuSecurityLevelModel { Id = 7, Name = "7" },
            //    new SuSecurityLevelModel { Id = 8, Name = "8" },
            //    new SuSecurityLevelModel { Id = 9, Name = "9" },
            //    new SuSecurityLevelModel { Id = 10, Name = "10" });

            //modelBuilder.Entity<SuSettingModel>().HasData(
            //    new SuSettingModel { Id = 1, IntValue = 41, SettingName = "Dedault language" },
            //                    new SuSettingModel { Id = 2, IntValue = 2, SettingName = "Home page" }
            //    );

            //modelBuilder.Entity<SuClassificationStatusModel>().HasData(
            //    new SuClassificationStatusModel { Id = 1, ClassificationStatusName = "Active" },
            //    new SuClassificationStatusModel { Id = 2, ClassificationStatusName = "Inactive" }
            //    );
            //modelBuilder.Entity<SuOrganizationStatusModel>().HasData(
            //    new SuOrganizationStatusModel { Id = 1, OrganizationStatusName = "Active" },
            //    new SuOrganizationStatusModel { Id = 2, OrganizationStatusName = "Inactive" }
            //    );
            //modelBuilder.Entity<SuProjectStatusModel>().HasData(
            //    new SuProjectStatusModel { Id = 1, ProjectStatusName = "Active" },
            //    new SuProjectStatusModel { Id = 2, ProjectStatusName = "Inactive" }
            //    );
            //modelBuilder.Entity<SuPageStatusModel>().HasData(
            //    new SuPageStatusModel { Id = 1, PageStatusName = "Active" },
            //    new SuPageStatusModel { Id = 2, PageStatusName = "Inactive" }
            //    );
            //modelBuilder.Entity<SuContentStatusModel>().HasData(
            //    new SuContentStatusModel { Id = 1, ContentStatusName = "Active" },
            //    new SuContentStatusModel { Id = 2, ContentStatusName = "Inactive" }
            //    );

            //modelBuilder.Entity<SuUser>().HasData(new SuUser
            //{
            //    UserName = "eplegrand@gmail.com",
            //    NormalizedUserName = "EPLEGRAND@GMAIL.COM",
            //    Email = "eplegrand@gmail.com",
            //    DefaultLangauge = 41,
            //    PasswordHash = "AQAAAAEAACcQAAAAENz3TKYdkSJi2eMWVeD3pglKKn//AllniYlKqPYFvar4NYg6l6QBeLCeLhGuBRL4VQ=="
            //});





            //modelBuilder.Entity<SuLanguageModel>().HasData(
            //new SuLanguageModel { Id = 1, LanguageName = "Abkhazian", ForeignName = "", Active = false, ISO6391 = "ab", ISO6392 = "abk" },
            //new SuLanguageModel { Id = 2, LanguageName = "Afar", ForeignName = "", Active = false, ISO6391 = "aa", ISO6392 = "aar" },
            //new SuLanguageModel { Id = 3, LanguageName = "Afrikaans", ForeignName = "", Active = false, ISO6391 = "af", ISO6392 = "afr" },
            //new SuLanguageModel { Id = 4, LanguageName = "Akan", ForeignName = "", Active = false, ISO6391 = "ak", ISO6392 = "aka" },
            //new SuLanguageModel { Id = 5, LanguageName = "Albanian", ForeignName = "", Active = false, ISO6391 = "sq", ISO6392 = "sqi" },
            //new SuLanguageModel { Id = 6, LanguageName = "Amharic", ForeignName = "", Active = false, ISO6391 = "am", ISO6392 = "amh" },
            //new SuLanguageModel { Id = 7, LanguageName = "Arabic", ForeignName = "", Active = false, ISO6391 = "ar", ISO6392 = "ara" },
            //new SuLanguageModel { Id = 8, LanguageName = "Aragonese", ForeignName = "", Active = false, ISO6391 = "an", ISO6392 = "arg" },
            //new SuLanguageModel { Id = 9, LanguageName = "Armenian", ForeignName = "", Active = false, ISO6391 = "hy", ISO6392 = "hye" },
            //new SuLanguageModel { Id = 10, LanguageName = "Assamese", ForeignName = "", Active = false, ISO6391 = "as", ISO6392 = "asm" },
            //new SuLanguageModel { Id = 11, LanguageName = "Avaric", ForeignName = "", Active = false, ISO6391 = "av", ISO6392 = "ava" },
            //new SuLanguageModel { Id = 12, LanguageName = "Avestan", ForeignName = "", Active = false, ISO6391 = "ae", ISO6392 = "ave" },
            //new SuLanguageModel { Id = 13, LanguageName = "Aymara", ForeignName = "", Active = false, ISO6391 = "ay", ISO6392 = "aym" },
            //new SuLanguageModel { Id = 14, LanguageName = "Azerbaijani", ForeignName = "", Active = false, ISO6391 = "az", ISO6392 = "aze" },
            //new SuLanguageModel { Id = 15, LanguageName = "Bambara", ForeignName = "", Active = false, ISO6391 = "bm", ISO6392 = "bam" },
            //new SuLanguageModel { Id = 16, LanguageName = "Bashkir", ForeignName = "", Active = false, ISO6391 = "ba", ISO6392 = "bak" },
            //new SuLanguageModel { Id = 17, LanguageName = "Basque", ForeignName = "", Active = false, ISO6391 = "eu", ISO6392 = "eus" },
            //new SuLanguageModel { Id = 18, LanguageName = "Belarusian", ForeignName = "", Active = false, ISO6391 = "be", ISO6392 = "bel" },
            //new SuLanguageModel { Id = 19, LanguageName = "Bengali", ForeignName = "", Active = false, ISO6391 = "bn", ISO6392 = "ben" },
            //new SuLanguageModel { Id = 20, LanguageName = "Bihari languages", ForeignName = "", Active = false, ISO6391 = "bh", ISO6392 = "bih" },
            //new SuLanguageModel { Id = 21, LanguageName = "Bislama", ForeignName = "", Active = false, ISO6391 = "bi", ISO6392 = "bis" },
            //new SuLanguageModel { Id = 22, LanguageName = "Bosnian", ForeignName = "", Active = false, ISO6391 = "bs", ISO6392 = "bos" },
            //new SuLanguageModel { Id = 23, LanguageName = "Breton", ForeignName = "", Active = false, ISO6391 = "br", ISO6392 = "bre" },
            //new SuLanguageModel { Id = 24, LanguageName = "Bulgarian", ForeignName = "", Active = false, ISO6391 = "bg", ISO6392 = "bul" },
            //new SuLanguageModel { Id = 25, LanguageName = "Burmese", ForeignName = "", Active = false, ISO6391 = "my", ISO6392 = "mya" },
            //new SuLanguageModel { Id = 26, LanguageName = "Catalan, Valencian", ForeignName = "", Active = false, ISO6391 = "ca", ISO6392 = "cat" },
            //new SuLanguageModel { Id = 27, LanguageName = "Chamorro", ForeignName = "", Active = false, ISO6391 = "ch", ISO6392 = "cha" },
            //new SuLanguageModel { Id = 28, LanguageName = "Chechen", ForeignName = "", Active = false, ISO6391 = "ce", ISO6392 = "che" },
            //new SuLanguageModel { Id = 29, LanguageName = "Chichewa, Chewa, Nyanja", ForeignName = "", Active = false, ISO6391 = "ny", ISO6392 = "nya" },
            //new SuLanguageModel { Id = 30, LanguageName = "Chinese", ForeignName = "", Active = false, ISO6391 = "zh", ISO6392 = "zho" },
            //new SuLanguageModel { Id = 31, LanguageName = "Chuvash", ForeignName = "", Active = false, ISO6391 = "cv", ISO6392 = "chv" },
            //new SuLanguageModel { Id = 32, LanguageName = "Cornish", ForeignName = "", Active = false, ISO6391 = "kw", ISO6392 = "cor" },
            //new SuLanguageModel { Id = 33, LanguageName = "Corsican", ForeignName = "", Active = false, ISO6391 = "co", ISO6392 = "cos" },
            //new SuLanguageModel { Id = 34, LanguageName = "Cree", ForeignName = "", Active = false, ISO6391 = "cr", ISO6392 = "cre" },
            //new SuLanguageModel { Id = 35, LanguageName = "Croatian", ForeignName = "", Active = false, ISO6391 = "hr", ISO6392 = "hrv" },
            //new SuLanguageModel { Id = 36, LanguageName = "Czech", ForeignName = "", Active = false, ISO6391 = "cs", ISO6392 = "ces" },
            //new SuLanguageModel { Id = 37, LanguageName = "Danish", ForeignName = "", Active = false, ISO6391 = "da", ISO6392 = "dan" },
            //new SuLanguageModel { Id = 38, LanguageName = "Divehi, Dhivehi, Maldivian", ForeignName = "", Active = false, ISO6391 = "dv", ISO6392 = "div" },
            //new SuLanguageModel { Id = 39, LanguageName = "Dutch, Flemish", ForeignName = "", Active = true, ISO6391 = "nl", ISO6392 = "nld" },
            //new SuLanguageModel { Id = 40, LanguageName = "Dzongkha", ForeignName = "", Active = false, ISO6391 = "dz", ISO6392 = "dzo" },
            //new SuLanguageModel { Id = 41, LanguageName = "English", ForeignName = "", Active = true, ISO6391 = "en", ISO6392 = "eng" },
            //new SuLanguageModel { Id = 42, LanguageName = "Esperanto", ForeignName = "", Active = false, ISO6391 = "eo", ISO6392 = "epo" },
            //new SuLanguageModel { Id = 43, LanguageName = "Estonian", ForeignName = "", Active = false, ISO6391 = "et", ISO6392 = "est" },
            //new SuLanguageModel { Id = 44, LanguageName = "Ewe", ForeignName = "", Active = false, ISO6391 = "ee", ISO6392 = "ewe" },
            //new SuLanguageModel { Id = 45, LanguageName = "Faroese", ForeignName = "", Active = false, ISO6391 = "fo", ISO6392 = "fao" },
            //new SuLanguageModel { Id = 46, LanguageName = "Fijian", ForeignName = "", Active = false, ISO6391 = "fj", ISO6392 = "fij" },
            //new SuLanguageModel { Id = 47, LanguageName = "Finnish", ForeignName = "", Active = false, ISO6391 = "fi", ISO6392 = "fin" },
            //new SuLanguageModel { Id = 48, LanguageName = "French", ForeignName = "", Active = false, ISO6391 = "fr", ISO6392 = "fra" },
            //new SuLanguageModel { Id = 49, LanguageName = "Fulah", ForeignName = "", Active = false, ISO6391 = "ff", ISO6392 = "ful" },
            //new SuLanguageModel { Id = 50, LanguageName = "Galician", ForeignName = "", Active = false, ISO6391 = "gl", ISO6392 = "glg" },
            //new SuLanguageModel { Id = 51, LanguageName = "Georgian", ForeignName = "", Active = false, ISO6391 = "ka", ISO6392 = "kat" },
            //new SuLanguageModel { Id = 52, LanguageName = "German", ForeignName = "", Active = false, ISO6391 = "de", ISO6392 = "deu" },
            //new SuLanguageModel { Id = 53, LanguageName = "Greek, Modern (1453-)", ForeignName = "", Active = false, ISO6391 = "el", ISO6392 = "ell" },
            //new SuLanguageModel { Id = 54, LanguageName = "Guarani", ForeignName = "", Active = false, ISO6391 = "gn", ISO6392 = "grn" },
            //new SuLanguageModel { Id = 55, LanguageName = "Gujarati", ForeignName = "", Active = false, ISO6391 = "gu", ISO6392 = "guj" },
            //new SuLanguageModel { Id = 56, LanguageName = "Haitian, Haitian Creole", ForeignName = "", Active = false, ISO6391 = "ht", ISO6392 = "hat" },
            //new SuLanguageModel { Id = 57, LanguageName = "Hausa", ForeignName = "", Active = false, ISO6391 = "ha", ISO6392 = "hau" },
            //new SuLanguageModel { Id = 58, LanguageName = "Hebrew", ForeignName = "", Active = false, ISO6391 = "he", ISO6392 = "heb" },
            //new SuLanguageModel { Id = 59, LanguageName = "Herero", ForeignName = "", Active = false, ISO6391 = "hz", ISO6392 = "her" },
            //new SuLanguageModel { Id = 60, LanguageName = "Hindi", ForeignName = "", Active = false, ISO6391 = "hi", ISO6392 = "hin" },
            //new SuLanguageModel { Id = 61, LanguageName = "Hiri Motu", ForeignName = "", Active = false, ISO6391 = "ho", ISO6392 = "hmo" },
            //new SuLanguageModel { Id = 62, LanguageName = "Hungarian", ForeignName = "", Active = false, ISO6391 = "hu", ISO6392 = "hun" },
            //new SuLanguageModel { Id = 63, LanguageName = "Interlingua", ForeignName = "", Active = false, ISO6391 = "ia", ISO6392 = "ina" },
            //new SuLanguageModel { Id = 64, LanguageName = "Indonesian", ForeignName = "", Active = false, ISO6391 = "id", ISO6392 = "ind" },
            //new SuLanguageModel { Id = 65, LanguageName = "Interlingue, Occidental", ForeignName = "", Active = false, ISO6391 = "ie", ISO6392 = "ile" },
            //new SuLanguageModel { Id = 66, LanguageName = "Irish", ForeignName = "", Active = false, ISO6391 = "ga", ISO6392 = "gle" },
            //new SuLanguageModel { Id = 67, LanguageName = "Igbo", ForeignName = "", Active = false, ISO6391 = "ig", ISO6392 = "ibo" },
            //new SuLanguageModel { Id = 68, LanguageName = "Inupiaq", ForeignName = "", Active = false, ISO6391 = "ik", ISO6392 = "ipk" },
            //new SuLanguageModel { Id = 69, LanguageName = "Ido", ForeignName = "", Active = false, ISO6391 = "io", ISO6392 = "ido" },
            //new SuLanguageModel { Id = 70, LanguageName = "Icelandic", ForeignName = "", Active = false, ISO6391 = "is", ISO6392 = "isl" },
            //new SuLanguageModel { Id = 71, LanguageName = "Italian", ForeignName = "", Active = false, ISO6391 = "it", ISO6392 = "ita" },
            //new SuLanguageModel { Id = 72, LanguageName = "Inuktitut", ForeignName = "", Active = false, ISO6391 = "iu", ISO6392 = "iku" },
            //new SuLanguageModel { Id = 73, LanguageName = "Japanese", ForeignName = "", Active = false, ISO6391 = "ja", ISO6392 = "jpn" },
            //new SuLanguageModel { Id = 74, LanguageName = "Javanese", ForeignName = "", Active = false, ISO6391 = "jv", ISO6392 = "jav" },
            //new SuLanguageModel { Id = 75, LanguageName = "Kalaallisut, Greenlandic", ForeignName = "", Active = false, ISO6391 = "kl", ISO6392 = "kal" },
            //new SuLanguageModel { Id = 76, LanguageName = "Kannada", ForeignName = "", Active = false, ISO6391 = "kn", ISO6392 = "kan" },
            //new SuLanguageModel { Id = 77, LanguageName = "Kanuri", ForeignName = "", Active = false, ISO6391 = "kr", ISO6392 = "kau" },
            //new SuLanguageModel { Id = 78, LanguageName = "Kashmiri", ForeignName = "", Active = false, ISO6391 = "ks", ISO6392 = "kas" },
            //new SuLanguageModel { Id = 79, LanguageName = "Kazakh", ForeignName = "", Active = false, ISO6391 = "kk", ISO6392 = "kaz" },
            //new SuLanguageModel { Id = 80, LanguageName = "Central Khmer", ForeignName = "", Active = false, ISO6391 = "km", ISO6392 = "khm" },
            //new SuLanguageModel { Id = 81, LanguageName = "Kikuyu, Gikuyu", ForeignName = "", Active = false, ISO6391 = "ki", ISO6392 = "kik" },
            //new SuLanguageModel { Id = 82, LanguageName = "Kinyarwanda", ForeignName = "", Active = false, ISO6391 = "rw", ISO6392 = "kin" },
            //new SuLanguageModel { Id = 83, LanguageName = "Kirghiz, Kyrgyz", ForeignName = "", Active = false, ISO6391 = "ky", ISO6392 = "kir" },
            //new SuLanguageModel { Id = 84, LanguageName = "Komi", ForeignName = "", Active = false, ISO6391 = "kv", ISO6392 = "kom" },
            //new SuLanguageModel { Id = 85, LanguageName = "Kongo", ForeignName = "", Active = false, ISO6391 = "kg", ISO6392 = "kon" },
            //new SuLanguageModel { Id = 86, LanguageName = "Korean", ForeignName = "", Active = false, ISO6391 = "ko", ISO6392 = "kor" },
            //new SuLanguageModel { Id = 87, LanguageName = "Kurdish", ForeignName = "", Active = false, ISO6391 = "ku", ISO6392 = "kur" },
            //new SuLanguageModel { Id = 88, LanguageName = "Kuanyama, Kwanyama", ForeignName = "", Active = false, ISO6391 = "kj", ISO6392 = "kua" },
            //new SuLanguageModel { Id = 89, LanguageName = "Latin", ForeignName = "", Active = false, ISO6391 = "la", ISO6392 = "lat" },
            //new SuLanguageModel { Id = 90, LanguageName = "Luxembourgish, Letzeburgesch", ForeignName = "", Active = false, ISO6391 = "lb", ISO6392 = "ltz" },
            //new SuLanguageModel { Id = 91, LanguageName = "Ganda", ForeignName = "", Active = false, ISO6391 = "lg", ISO6392 = "lug" },
            //new SuLanguageModel { Id = 92, LanguageName = "Limburgan, Limburger, Limburgish", ForeignName = "", Active = false, ISO6391 = "li", ISO6392 = "lim" },
            //new SuLanguageModel { Id = 93, LanguageName = "Lingala", ForeignName = "", Active = false, ISO6391 = "ln", ISO6392 = "lin" },
            //new SuLanguageModel { Id = 94, LanguageName = "Lao", ForeignName = "", Active = false, ISO6391 = "lo", ISO6392 = "lao" },
            //new SuLanguageModel { Id = 95, LanguageName = "Lithuanian", ForeignName = "", Active = false, ISO6391 = "lt", ISO6392 = "lit" },
            //new SuLanguageModel { Id = 96, LanguageName = "Luba-Katanga", ForeignName = "", Active = false, ISO6391 = "lu", ISO6392 = "lub" },
            //new SuLanguageModel { Id = 97, LanguageName = "Latvian", ForeignName = "", Active = false, ISO6391 = "lv", ISO6392 = "lav" },
            //new SuLanguageModel { Id = 98, LanguageName = "Manx", ForeignName = "", Active = false, ISO6391 = "gv", ISO6392 = "glv" },
            //new SuLanguageModel { Id = 99, LanguageName = "Macedonian", ForeignName = "", Active = false, ISO6391 = "mk", ISO6392 = "mkd" },
            //new SuLanguageModel { Id = 100, LanguageName = "Malagasy", ForeignName = "", Active = false, ISO6391 = "mg", ISO6392 = "mlg" },
            //new SuLanguageModel { Id = 101, LanguageName = "Malay", ForeignName = "", Active = false, ISO6391 = "ms", ISO6392 = "msa" },
            //new SuLanguageModel { Id = 102, LanguageName = "Malayalam", ForeignName = "", Active = false, ISO6391 = "ml", ISO6392 = "mal" },
            //new SuLanguageModel { Id = 103, LanguageName = "Maltese", ForeignName = "", Active = false, ISO6391 = "mt", ISO6392 = "mlt" },
            //new SuLanguageModel { Id = 104, LanguageName = "Maori", ForeignName = "", Active = false, ISO6391 = "mi", ISO6392 = "mri" },
            //new SuLanguageModel { Id = 105, LanguageName = "Marathi", ForeignName = "", Active = false, ISO6391 = "mr", ISO6392 = "mar" },
            //new SuLanguageModel { Id = 106, LanguageName = "Marshallese", ForeignName = "", Active = false, ISO6391 = "mh", ISO6392 = "mah" },
            //new SuLanguageModel { Id = 107, LanguageName = "Mongolian", ForeignName = "", Active = false, ISO6391 = "mn", ISO6392 = "mon" },
            //new SuLanguageModel { Id = 108, LanguageName = "Nauru", ForeignName = "", Active = false, ISO6391 = "na", ISO6392 = "nau" },
            //new SuLanguageModel { Id = 109, LanguageName = "Navajo, Navaho", ForeignName = "", Active = false, ISO6391 = "nv", ISO6392 = "nav" },
            //new SuLanguageModel { Id = 110, LanguageName = "North Ndebele", ForeignName = "", Active = false, ISO6391 = "nd", ISO6392 = "nde" },
            //new SuLanguageModel { Id = 111, LanguageName = "Nepali", ForeignName = "", Active = false, ISO6391 = "ne", ISO6392 = "nep" },
            //new SuLanguageModel { Id = 112, LanguageName = "Ndonga", ForeignName = "", Active = false, ISO6391 = "ng", ISO6392 = "ndo" },
            //new SuLanguageModel { Id = 113, LanguageName = "Norwegian Bokmål", ForeignName = "", Active = false, ISO6391 = "nb", ISO6392 = "nob" },
            //new SuLanguageModel { Id = 114, LanguageName = "Norwegian Nynorsk", ForeignName = "", Active = false, ISO6391 = "nn", ISO6392 = "nno" },
            //new SuLanguageModel { Id = 115, LanguageName = "Norwegian", ForeignName = "", Active = false, ISO6391 = "no", ISO6392 = "nor" },
            //new SuLanguageModel { Id = 116, LanguageName = "Sichuan Yi, Nuosu", ForeignName = "", Active = false, ISO6391 = "ii", ISO6392 = "iii" },
            //new SuLanguageModel { Id = 117, LanguageName = "South Ndebele", ForeignName = "", Active = false, ISO6391 = "nr", ISO6392 = "nbl" },
            //new SuLanguageModel { Id = 118, LanguageName = "Occitan", ForeignName = "", Active = false, ISO6391 = "oc", ISO6392 = "oci" },
            //new SuLanguageModel { Id = 119, LanguageName = "Ojibwa", ForeignName = "", Active = false, ISO6391 = "oj", ISO6392 = "oji" },
            //new SuLanguageModel { Id = 120, LanguageName = "Old Slavonic, Old Bulgarian", ForeignName = "", Active = false, ISO6391 = "cu", ISO6392 = "chu" },
            //new SuLanguageModel { Id = 121, LanguageName = "Oromo", ForeignName = "", Active = false, ISO6391 = "om", ISO6392 = "orm" },
            //new SuLanguageModel { Id = 122, LanguageName = "Oriya", ForeignName = "", Active = false, ISO6391 = "or", ISO6392 = "ori" },
            //new SuLanguageModel { Id = 123, LanguageName = "Ossetian, Ossetic", ForeignName = "", Active = false, ISO6391 = "os", ISO6392 = "oss" },
            //new SuLanguageModel { Id = 124, LanguageName = "Punjabi, Panjabi", ForeignName = "", Active = false, ISO6391 = "pa", ISO6392 = "pan" },
            //new SuLanguageModel { Id = 125, LanguageName = "Pali", ForeignName = "", Active = false, ISO6391 = "pi", ISO6392 = "pli" },
            //new SuLanguageModel { Id = 126, LanguageName = "Persian", ForeignName = "", Active = false, ISO6391 = "fa", ISO6392 = "fas" },
            //new SuLanguageModel { Id = 127, LanguageName = "Polish", ForeignName = "", Active = false, ISO6391 = "pl", ISO6392 = "pol" },
            //new SuLanguageModel { Id = 128, LanguageName = "Pashto, Pushto", ForeignName = "", Active = false, ISO6391 = "ps", ISO6392 = "pus" },
            //new SuLanguageModel { Id = 129, LanguageName = "Portuguese", ForeignName = "", Active = false, ISO6391 = "pt", ISO6392 = "por" },
            //new SuLanguageModel { Id = 130, LanguageName = "Quechua", ForeignName = "", Active = false, ISO6391 = "qu", ISO6392 = "que" },
            //new SuLanguageModel { Id = 131, LanguageName = "Romansh", ForeignName = "", Active = false, ISO6391 = "rm", ISO6392 = "roh" },
            //new SuLanguageModel { Id = 132, LanguageName = "Rundi", ForeignName = "", Active = false, ISO6391 = "rn", ISO6392 = "run" },
            //new SuLanguageModel { Id = 133, LanguageName = "Romanian, Moldavian, Moldovan", ForeignName = "", Active = false, ISO6391 = "ro", ISO6392 = "ron" },
            //new SuLanguageModel { Id = 134, LanguageName = "Russian", ForeignName = "", Active = false, ISO6391 = "ru", ISO6392 = "rus" },
            //new SuLanguageModel { Id = 135, LanguageName = "Sanskrit", ForeignName = "", Active = false, ISO6391 = "sa", ISO6392 = "san" },
            //new SuLanguageModel { Id = 136, LanguageName = "Sardinian", ForeignName = "", Active = false, ISO6391 = "sc", ISO6392 = "srd" },
            //new SuLanguageModel { Id = 137, LanguageName = "Sindhi", ForeignName = "", Active = false, ISO6391 = "sd", ISO6392 = "snd" },
            //new SuLanguageModel { Id = 138, LanguageName = "Northern Sami", ForeignName = "", Active = false, ISO6391 = "se", ISO6392 = "sme" },
            //new SuLanguageModel { Id = 139, LanguageName = "Samoan", ForeignName = "", Active = false, ISO6391 = "sm", ISO6392 = "smo" },
            //new SuLanguageModel { Id = 140, LanguageName = "Sango", ForeignName = "", Active = false, ISO6391 = "sg", ISO6392 = "sag" },
            //new SuLanguageModel { Id = 141, LanguageName = "Serbian", ForeignName = "", Active = false, ISO6391 = "sr", ISO6392 = "srp" },
            //new SuLanguageModel { Id = 142, LanguageName = "Gaelic, Scottish Gaelic", ForeignName = "", Active = false, ISO6391 = "gd", ISO6392 = "gla" },
            //new SuLanguageModel { Id = 143, LanguageName = "Shona", ForeignName = "", Active = false, ISO6391 = "sn", ISO6392 = "sna" },
            //new SuLanguageModel { Id = 144, LanguageName = "Sinhala, Sinhalese", ForeignName = "", Active = false, ISO6391 = "si", ISO6392 = "sin" },
            //new SuLanguageModel { Id = 145, LanguageName = "Slovak", ForeignName = "", Active = false, ISO6391 = "sk", ISO6392 = "slk" },
            //new SuLanguageModel { Id = 146, LanguageName = "Slovenian", ForeignName = "", Active = false, ISO6391 = "sl", ISO6392 = "slv" },
            //new SuLanguageModel { Id = 147, LanguageName = "Somali", ForeignName = "", Active = false, ISO6391 = "so", ISO6392 = "som" },
            //new SuLanguageModel { Id = 148, LanguageName = "Southern Sotho", ForeignName = "", Active = false, ISO6391 = "st", ISO6392 = "sot" },
            //new SuLanguageModel { Id = 149, LanguageName = "Spanish, Castilian", ForeignName = "", Active = false, ISO6391 = "es", ISO6392 = "spa" },
            //new SuLanguageModel { Id = 150, LanguageName = "Sundanese", ForeignName = "", Active = false, ISO6391 = "su", ISO6392 = "sun" },
            //new SuLanguageModel { Id = 151, LanguageName = "Swahili", ForeignName = "", Active = false, ISO6391 = "sw", ISO6392 = "swa" },
            //new SuLanguageModel { Id = 152, LanguageName = "Swati", ForeignName = "", Active = false, ISO6391 = "ss", ISO6392 = "ssw" },
            //new SuLanguageModel { Id = 153, LanguageName = "Swedish", ForeignName = "", Active = false, ISO6391 = "sv", ISO6392 = "swe" },
            //new SuLanguageModel { Id = 154, LanguageName = "Tamil", ForeignName = "", Active = false, ISO6391 = "ta", ISO6392 = "tam" },
            //new SuLanguageModel { Id = 155, LanguageName = "Telugu", ForeignName = "", Active = false, ISO6391 = "te", ISO6392 = "tel" },
            //new SuLanguageModel { Id = 156, LanguageName = "Tajik", ForeignName = "", Active = false, ISO6391 = "tg", ISO6392 = "tgk" },
            //new SuLanguageModel { Id = 157, LanguageName = "Thai", ForeignName = "", Active = true, ISO6391 = "th", ISO6392 = "tha" },
            //new SuLanguageModel { Id = 158, LanguageName = "Tigrinya", ForeignName = "", Active = false, ISO6391 = "ti", ISO6392 = "tir" },
            //new SuLanguageModel { Id = 159, LanguageName = "Tibetan", ForeignName = "", Active = false, ISO6391 = "bo", ISO6392 = "bod" },
            //new SuLanguageModel { Id = 160, LanguageName = "Turkmen", ForeignName = "", Active = false, ISO6391 = "tk", ISO6392 = "tuk" },
            //new SuLanguageModel { Id = 161, LanguageName = "Tagalog", ForeignName = "", Active = false, ISO6391 = "tl", ISO6392 = "tgl" },
            //new SuLanguageModel { Id = 162, LanguageName = "Tswana", ForeignName = "", Active = false, ISO6391 = "tn", ISO6392 = "tsn" },
            //new SuLanguageModel { Id = 163, LanguageName = "Tonga (Tonga Islands)", ForeignName = "", Active = false, ISO6391 = "to", ISO6392 = "ton" },
            //new SuLanguageModel { Id = 164, LanguageName = "Turkish", ForeignName = "", Active = false, ISO6391 = "tr", ISO6392 = "tur" },
            //new SuLanguageModel { Id = 165, LanguageName = "Tsonga", ForeignName = "", Active = false, ISO6391 = "ts", ISO6392 = "tso" },
            //new SuLanguageModel { Id = 166, LanguageName = "Tatar", ForeignName = "", Active = false, ISO6391 = "tt", ISO6392 = "tat" },
            //new SuLanguageModel { Id = 167, LanguageName = "Twi", ForeignName = "", Active = false, ISO6391 = "tw", ISO6392 = "twi" },
            //new SuLanguageModel { Id = 168, LanguageName = "Tahitian", ForeignName = "", Active = false, ISO6391 = "ty", ISO6392 = "tah" },
            //new SuLanguageModel { Id = 169, LanguageName = "Uighur, Uyghur", ForeignName = "", Active = false, ISO6391 = "ug", ISO6392 = "uig" },
            //new SuLanguageModel { Id = 170, LanguageName = "Ukrainian", ForeignName = "", Active = false, ISO6391 = "uk", ISO6392 = "ukr" },
            //new SuLanguageModel { Id = 171, LanguageName = "Urdu", ForeignName = "", Active = false, ISO6391 = "ur", ISO6392 = "urd" },
            //new SuLanguageModel { Id = 172, LanguageName = "Uzbek", ForeignName = "", Active = false, ISO6391 = "uz", ISO6392 = "uzb" },
            //new SuLanguageModel { Id = 173, LanguageName = "Venda", ForeignName = "", Active = false, ISO6391 = "ve", ISO6392 = "ven" },
            //new SuLanguageModel { Id = 174, LanguageName = "Vietnamese", ForeignName = "", Active = false, ISO6391 = "vi", ISO6392 = "vie" },
            //new SuLanguageModel { Id = 175, LanguageName = "Volapük", ForeignName = "", Active = false, ISO6391 = "vo", ISO6392 = "vol" },
            //new SuLanguageModel { Id = 176, LanguageName = "Walloon", ForeignName = "", Active = false, ISO6391 = "wa", ISO6392 = "wln" },
            //new SuLanguageModel { Id = 177, LanguageName = "Welsh", ForeignName = "", Active = false, ISO6391 = "cy", ISO6392 = "cym" },
            //new SuLanguageModel { Id = 178, LanguageName = "Wolof", ForeignName = "", Active = false, ISO6391 = "wo", ISO6392 = "wol" },
            //new SuLanguageModel { Id = 179, LanguageName = "Western Frisian", ForeignName = "", Active = false, ISO6391 = "fy", ISO6392 = "fry" },
            //new SuLanguageModel { Id = 180, LanguageName = "Xhosa", ForeignName = "", Active = false, ISO6391 = "xh", ISO6392 = "xho" },
            //new SuLanguageModel { Id = 181, LanguageName = "Yiddish", ForeignName = "", Active = false, ISO6391 = "yi", ISO6392 = "yid" },
            //new SuLanguageModel { Id = 182, LanguageName = "Yoruba", ForeignName = "", Active = false, ISO6391 = "yo", ISO6392 = "yor" },
            //new SuLanguageModel { Id = 183, LanguageName = "Zhuang, Chuang", ForeignName = "", Active = false, ISO6391 = "za", ISO6392 = "zha" },
            //new SuLanguageModel { Id = 184, LanguageName = "Zulu", ForeignName = "", Active = false, ISO6391 = "zu", ISO6392 = "zul" }


            //);

        }
    }
}

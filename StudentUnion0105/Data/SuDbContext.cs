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
        public DbSet<SuClassificationStatusModel> dbClassificationStatus { get; set; }
        //Classification
        public DbSet<SuClassificationModel> dbClassification { get; set; }
        public DbSet<SuClassificationDeleteGetModel> ZdbClassificationDeleteGet { get; set; }
        public DbSet<SuClassificationEditGetModel> ZdbClassificationEditGet { get; set; }
        public DbSet<SuClassificationIndexGetModel> ZdbClassificationIndexGet { get; set; }
        public DbSet<SuClassificationLanguageModel> dbClassificationLanguage { get; set; }
        //ClassificationLevel
        public DbSet<SuClassificationLevelModel> dbClassificationLevel { get; set; }
        public DbSet<SuClassificationLevelDeleteGetModel> ZdbClassificationLevelDeleteGet { get; set; }
        public DbSet<SuClassificationLevelEditGetModel> ZdbClassificationLevelEditGet { get; set; }
        public DbSet<SuClassificationLevelIndexGetModel> ZdbClassificationLevelIndexGet { get; set; }
        public DbSet<SuClassificationLevelLanguageModel> dbClassificationLevelLanguage { get; set; }
        //ClassificationValue
        public DbSet<SuClassificationValueModel> dbClassificationValue { get; set; }
        public DbSet<SuClassificationValueLanguageModel> dbClassificationValueLanguage { get; set; }
        public DbSet<SuClassificationValueIndexGet> ZdbClassificationValueIndexGet { get; set; }
        public DbSet<SuContentTypeLanguageModel> dbContentTypeLanguage { get; set; }
        public DbSet<SuContentTypeDeleteGetModel> dbContentTypeDeleteGet { get; set; }
        public DbSet<SuOrganizationLanguageModel> dbOrganizationLanguage { get; set; }
        public DbSet<SuOrganizationModel> dbOrganization { get; set; }
        public DbSet<SuOrganizationTypeDeleteGetModel> dbOrganizationTypeDeleteGet { get; set; }
        public DbSet<SuPageDeleteGetModel> dbPageDeleteGet { get; set; }
        public DbSet<SuPageSectionDeleteGetModel> dbPageSectionDeleteGet { get; set; }
        public DbSet<SuOrganizationDeleteGetModel> dbOrganizationDeleteGet { get; set; }
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
        //        public DbSet<SuObjectLanguageEditGet> dbObjectLanguage { get; set; }
        public DbSet<SuObjectIndexGetModel> ZdbObjectIndexGet { get; set; }
        public DbSet<SuObjectLanguageCreateGetModel> ZdbObjectLanguageCreateGet { get; set; }
        public DbSet<SuObjectLanguageEditGetModel> ZdbObjectLanguageEditGet { get; set; }
        public DbSet<SuPageLanguageEditGetModel> ZdbPageLanguageEditGet { get; set; }
        public DbSet<SuObjectLanguageIndexGetModel> ZdbObjectLanguageIndexGet { get; set; }

        public DbSet<SuUIScreenModel> dbUIScreen { get; set; }
        public DbSet<SuUITermLanguageModel> dbUITermLanguage { get; set; }
        public DbSet<SuUITermModel> dbUITerm { get; set; }
        public DbSet<SuUITermScreenModel> dbUITermScreen { get; set; }


        public DbSet<SuOrganizationIndexGet> ZdbOrganizationIndexGet { get; set; }
        public DbSet<SuGetProjectStructure> dbGetProjectStructure { get; set; }
        public DbSet<SuPageSectionsViewModel> dbPageSectionsViewModel { get; set; }
        public DbSet<SuObjectVM> dbObjectVM { get; set; }
        public DbSet<SuObject> dbObject { get; set; }
        public DbSet<SuIdWithStrings> dbIdWithStrings { get; set; }

        public DbSet<SuClaim> dbClaim { get; set; }
        public DbSet<SuInt> ZdbInt { get; set; }

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

        }
    }
}

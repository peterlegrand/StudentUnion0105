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
        //FrontPage
        public DbSet<SuPreferenceLeftMenuGetModel> ZdbPreferenceLeftMenuGet { get; set; }
        public DbSet<SuPreferenceLeftMenuEditGetModel> ZdbPreferenceLeftMenuEditGet { get; set; }
        public DbSet<SuPreferenceLeftMenuGetAvailableMenusModel> ZdbPreferenceLeftMenuGetAvailableMenus { get; set; }
        public DbSet<SuProcessTemplateStepTypeModel> dbProcessTemplateStepType { get; set; }
        public DbSet<SuProcessTemplateStepTypeLanguageModel> dbProcessTemplateStepTypeLanguage { get; set; }
        public DbSet<SuLeftMenuModel> dbLeftMenu { get; set; }
        public DbSet<SuFrontCalendarEventCalendarModel> ZdbFrontCalendarEventCalendar { get; set; }
        public DbSet<SuLeftMenuLanguageModel> dbLeftMenuLanguage { get; set; }
        public DbSet<SuLeftMenuUserModel> dbLeftMenuUser { get; set; }
        public DbSet<SuExternalPageMyContentGetModel> ZdbExternalPageMyContentGet { get; set; }
        public DbSet<SuFrontPageMyContentGetModel> ZdbFrontPageMyContentGet { get; set; }
        public DbSet<SuFrontOrganizationMyOrganizationGetModel> ZdbFrontOrganizationMyOrganizationGet { get; set; }
        public DbSet<SuFrontProjectMyFrontProjectGetModel> ZdbFrontProjectMyProjectGet { get; set; }
        public DbSet<SuFrontRelationMyFrontRelationGetModel> ZdbFrontRelationMyRelationGet { get; set; }
        public DbSet<SuFrontOrganizationDashboardGetOrganizationModel> ZdbFrontOrganizationDashboardGetOrganization { get; set; }
        public DbSet<SuFrontOrganizationDashboardGetContentModel> ZdbFrontOrganizationDashboardGetContent { get; set; }
        public DbSet<SuFrontOrganizationDashboardGetUsersModel> ZdbFrontOrganizationDashboardGetUsers { get; set; }
        public DbSet<Menu1> ZdbMenu1 { get; set; }
        public DbSet<TopMenu1> ZdbTopMenu1 { get; set; }
        public DbSet<TopMenu2> ZdbTopMenu2 { get; set; }
        public DbSet<LeftMenu> ZdbLeftMenu { get; set; }
        public DbSet<SuMenu1IndexGetModel> ZdbMenu1IndexGet { get; set; }
        public DbSet<SuMenu1DeleteGetModel> ZdbMenu1DeleteGet { get; set; }
        public DbSet<SuMenu1EditGetModel> ZdbMenu1EditGet { get; set; }
        public DbSet<Menu2> ZdbMenu2 { get; set; }
        public DbSet<SuMenu2IndexGetModel> ZdbMenu2IndexGet { get; set; }
        public DbSet<SuMenu2DeleteGetModel> ZdbMenu2DeleteGet { get; set; }
        public DbSet<SuMenu2EditGetModel> ZdbMenu2EditGet { get; set; }
        public DbSet<Menu3> ZdbMenu3 { get; set; }
        public DbSet<SuMenu3IndexGetModel> ZdbMenu3IndexGet { get; set; }
        public DbSet<SuMenu3DeleteGetModel> ZdbMenu3DeleteGet { get; set; }
        public DbSet<SuMenu3EditGetModel> ZdbMenu3EditGet { get; set; }
        public DbSet<SuFrontPageModel> ZdbFrontPage { get; set; }
        public DbSet<SuExternalPageModel> ZdbExternalPage { get; set; }
        public DbSet<SuFrontProcessToDoIndex2GetForAndOrModel> ZdbFrontProcessToDoIndex2GetForAndOr { get; set; }
        public DbSet<SuFrontProcessToDoIndex2GetModel> ZdbFrontProcessToDoIndex2Get { get; set; }
        public DbSet<SuProcessTemplateFieldEditGetModel> ZdbSuProcessTemplateFieldEditGet { get; set; }
        public DbSet<SuFrontProcessTodoIndexGetModel> ZdbSuFrontProcessTodoIndexGet { get; set; }
        public DbSet<SuFrontProcessTodoEditGetModel> ZdbSuFrontProcessTodoEditGet { get; set; }
        public DbSet<SuUserRelationTypeLanguageDeleteGetModel> ZdbUserRelationTypeLanguageDeleteGet { get; set; }
        public DbSet<SuUserRelationTypeLanguageEditGetModel> ZdbUserRelationTypeLanguageEditGet { get; set; }
        public DbSet<SuUserRelationTypeLanguageIndexGetModel> ZdbUserRelationTypeLanguageIndexGet { get; set; }
        public DbSet<SuOrganizationEditGetModel> ZdbOrganizationEditGet { get; set; }
        public DbSet<SuUserRelationTypeIndexGetModel> ZdbUserRelationTypeIndexGet { get; set; }
        public DbSet<SuPageSectionEditGetModel> ZdbPageSectionEditGet { get; set; }
        public DbSet<SuMenu1Model> dbMenu1 { get; set; }
        public DbSet<SuMenu2Model> dbMenu2 { get; set; }
        public DbSet<SuMenu3Model> dbMenu3 { get; set; }
        public DbSet<SuMenu1LanguageModel> dbMenu1Language { get; set; }
        public DbSet<SuMenu2LanguageModel> dbMenu2Language { get; set; }
        public DbSet<SuMenu3LanguageModel> dbMenu3Language { get; set; }
        public DbSet<SuMenuTypeModel> dbMenuType { get; set; }
        public DbSet<SuClassificationPageLanguageEditGetModel> ZdbClassificationPageLanguageEditGet { get; set; }
        public DbSet<SuClassificationPageSectionLanguageEditGetModel> ZdbClassificationPageSectionLanguageEditGet { get; set; }
        public DbSet<SuClassificationPageSectionEditGetModel> ZdbClassificationPageSectionEditGet { get; set; }
        public DbSet<SuClassificationPageDeleteGetModel> ZdbClassificationPageDeleteGet { get; set; }
        public DbSet<SuClassificationPageSectionDeleteGetModel> ZdbClassificationPageSectionDeleteGet { get; set; }
        public DbSet<SuContentTypeEditGetModel> ZdbContentTypeEditGet { get; set; }
        public DbSet<SuOrganizationTypeEditGetModel> ZdbOrganizationTypeEditGet { get; set; }
        public DbSet<SuPageTypeEditGetModel> ZdbPageTypeEditGet { get; set; }
        public DbSet<SuPageSectionTypeEditGetModel> ZdbPageSectionTypeEditGet { get; set; }
        public DbSet<SuFrontPageViewGetModel> ZdbFrontPageViewGet { get; set; }
        public DbSet<SuExternalPageViewGetModel> ZdbExternalPageViewGet { get; set; }
        public DbSet<SuLayoutTermList> ZdbLayoutTermList { get; set; }
        public DbSet<SuFrontPageSectionModel> ZdbFrontPageSection { get; set; }
        public DbSet<SuExternalPageSectionModel> ZdbExternalPageSection { get; set; }
        public DbSet<SuFrontContentModel> ZdbFrontContent { get; set; }
        public DbSet<SuExternalContentModel> ZdbExternalContent { get; set; }
        public DbSet<SuClassificationStatusModel> DbClassificationStatus { get; set; }
        public DbSet<SuClassificationPageModel> DbClassificationPage { get; set; }
        public DbSet<SuClassificationPageEditGetModel> ZdbClassificationPageEditGet  { get; set; }
        public DbSet<SuClassificationPageLanguageModel> DbClassificationPageLanguage { get; set; }
        public DbSet<SuClassificationPageSectionModel> DbClassificationPageSection { get; set; }
        public DbSet<SuClassificationPageSectionLanguageModel> DbClassificationPageSectionLanguage { get; set; }
        //FrontProcess
        public DbSet<SuFrontProcessIndexGetTemplateGroupModel> ZdbFrontProcessIndexGetTemplateGroup { get; set; }
        public DbSet<SuFrontProcessIndexGetTemplateModel> ZdbFrontProcessIndexGetTemplate { get; set; }
        public DbSet<SuFrontProcessIndexGetTemplateFlowConditionModel> ZdbFrontProcessIndexGetTemplateFlowCondition { get; set; }
        public DbSet<SuFrontProcessCreateGetModel> ZdbFrontProcessCreateGet { get; set; }
        public DbSet<SuFrontProcessCreateGetFieldModel> ZdbFrontProcessCreateGetField { get; set; }
        public DbSet<SuPreferenceIndexGetModel> ZdbPreferenceIndexGet { get; set; }

        //Process
        public DbSet<SuProcessModel> DbProcess { get; set; }
        public DbSet<SuProcessFieldModel> DbProcessField { get; set; }

        //Classification
        public DbSet<SuClassificationModel> DbClassification { get; set; }
        public DbSet<SuClassificationDeleteGetModel> ZdbClassificationDeleteGet { get; set; }
        public DbSet<SuClassificationEditGetModel> ZdbClassificationEditGet { get; set; }
//        public DbSet<SuClassificationIndexGetModel> ZdbClassificationIndexGet { get; set; }
        public DbSet<SuTermLanguageCreateGetModel> ZdbTermLanguageCreateGetWith { get; set; }
        public DbSet<SuClassificationLanguageModel> DbClassificationLanguage { get; set; }
        //ClassificationLevel
        public DbSet<SuClassificationLevelModel> DbClassificationLevel { get; set; }
        public DbSet<SuClassificationLevelDeleteGetModel> ZdbClassificationLevelDeleteGet { get; set; }
        public DbSet<SuClassificationLevelEditGetModel> ZdbClassificationLevelEditGet { get; set; }
        public DbSet<SuClassificationLevelIndexGetModel> ZdbClassificationLevelIndexGet { get; set; }
        public DbSet<SuClassificationLevelLanguageModel> DbClassificationLevelLanguage { get; set; }
        //ClassificationValue
        public DbSet<SuClassificationValueModel> DbClassificationValue { get; set; }
        public DbSet<SuClassificationValueEditGetModel> ZdbClassificationValueEditGet { get; set; }
        public DbSet<SuClassificationValueEditGetLevelModel> ZdbClassificationValueEditGetLevel { get; set; }
        public DbSet<SuClassificationValueLanguageModel> DbClassificationValueLanguage { get; set; }
        public DbSet<SuClassificationValueIndexGet> ZdbClassificationValueIndexGet { get; set; }
        public DbSet<SuContentTypeLanguageModel> DbContentTypeLanguage { get; set; }
        public DbSet<SuContentTypeDeleteGetModel> DbContentTypeDeleteGet { get; set; }
        public DbSet<SuOrganizationLanguageModel> DbOrganizationLanguage { get; set; }
        public DbSet<SuOrganizationModel> DbOrganization { get; set; }
        public DbSet<SuOrganizationTypeDeleteGetModel> DbOrganizationTypeDeleteGet { get; set; }
        public DbSet<SuPageDeleteGetModel> DbPageDeleteGet { get; set; }
        public DbSet<SuPageSectionDeleteGetModel> DbPageSectionDeleteGet { get; set; }
        public DbSet<SuOrganizationDeleteGetModel> DbOrganizationDeleteGet { get; set; }
        public DbSet<SuOrganizationStatusModel> DbOrganizationStatus { get; set; }
        public DbSet<SuOrganizationTypeLanguageModel> DbOrganizationTypeLanguage { get; set; }
        public DbSet<SuOrganizationTypeModel> DbOrganizationType { get; set; }
        public DbSet<SuProjectLanguageModel> DbProjectLanguage { get; set; }
        public DbSet<SuProjectModel> DbProject { get; set; }
        public DbSet<SuProjectStatusModel> DbProjectStatus { get; set; }
        public DbSet<SuContentTypeModel> DbContentType { get; set; }
        public DbSet<SuLanguageModel> DbLanguage { get; set; }
        public DbSet<SuCountryModel> DbCountry { get; set; }
        public DbSet<SuSettingModel> DbSetting { get; set; }
        public DbSet<SuPageLanguageModel> DbPageLanguage { get; set; }
        public DbSet<SuPageModel> DbPage { get; set; }
        public DbSet<SuPageStatusModel> DbPageStatus { get; set; }
        public DbSet<SuPageTypeLanguageModel> DbPageTypeLanguage { get; set; }
        public DbSet<SuPageTypeModel> DbPageType { get; set; }
        public DbSet<SuPageSectionModel> DbPageSection { get; set; }
        public DbSet<SuPageSectionLanguageModel> DbPageSectionLanguage { get; set; }
        public DbSet<SuPageSectionTypeModel> DbPageSectionType { get; set; }
        public DbSet<SuPageSectionTypeLanguageModel> DbPageSectionTypeLanguage { get; set; }
        public DbSet<SuContentModel> DbContent { get; set; }
        public DbSet<SuContentClassificationValueModel> DbContentClassificationValue { get; set; }
        public DbSet<SuContentStatusModel> DbContentStatus { get; set; }
        public DbSet<SuProcessTemplateFieldLanguageModel> DbProcessTemplateFieldLanguage { get; set; }
        public DbSet<SuProcessTemplateFieldModel> DbProcessTemplateField { get; set; }
        public DbSet<SuProcessTemplateFieldTypeLanguageModel> DbProcessTemplateFieldTypeLanguage { get; set; }
        public DbSet<SuProcessTemplateFieldTypeModel> DbProcessTemplateFieldType { get; set; }
        public DbSet<SuProcessTemplateFlowConditionTypeModel> DbProcessTemplateFlowConditionType { get; set; }
        public DbSet<SuProcessTemplateFlowConditionLanguageModel> DbProcessTemplateFlowConditionLanguage { get; set; }
        public DbSet<SuProcessTemplateFlowConditionModel> DbProcessTemplateFlowCondition { get; set; }
        public DbSet<SuProcessTemplateFlowModel> DbProcessTemplateFlow { get; set; }
        public DbSet<SuProcessTemplateFlowLanguageModel> DbProcessTemplateFlowLanguage { get; set; }
        public DbSet<SuProcessTemplateGroupLanguageModel> DbProcessTemplateGroupLanguage { get; set; }
        public DbSet<SuProcessTemplateGroupModel> DbProcessTemplateGroup { get; set; }
        public DbSet<SuProcessTemplateLanguageModel> DbProcessTemplateLanguage { get; set; }
        public DbSet<SuProcessTemplateModel> DbProcessTemplate { get; set; }
        public DbSet<SuProcessTemplateStepFieldModel> DbProcessTemplateStepField { get; set; }
        public DbSet<SuProcessTemplateStepFieldStatusModel> DbProcessTemplateStepFieldStatus { get; set; }
        public DbSet<SuProcessTemplateStepLanguageModel> DbProcessTemplateStepLanguage { get; set; }
        public DbSet<SuProcessTemplateStepModel> DbProcessTemplateStep { get; set; }
        public DbSet<SuUserOrganizationModel> DbUserOrganization { get; set; }
        public DbSet<SuUserOrganizationTypeModel> DbUserOrganizationType { get; set; }
        public DbSet<SuUserOrganizationTypeLanguageModel> DbUserOrganizationTypeLanguage { get; set; }
        public DbSet<SuUserProjectModel> DbUserProject { get; set; }
        public DbSet<SuUserProjectTypeModel> DbUserProjectType { get; set; }
        public DbSet<SuUserProjectTypeLanguageModel> DbUserProjectTypeLanguage { get; set; }
        public DbSet<SuUserRelationModel> DbUserRelation { get; set; }
        public DbSet<SuUserRelationTypeModel> DbUserRelationType { get; set; }
        public DbSet<SuUserRelationTypeLanguageModel> DbUserRelationTypeLanguage { get; set; }
        public DbSet<SuComparisonModel> DbComparison { get; set; }
        public DbSet<SuMasterListModel> DbMasterList { get; set; }
        public DbSet<SuDataTypeModel> DbDataType { get; set; }
        public DbSet<SuSecurityLevelModel> DbSecurityLevel { get; set; }
        public DbSet<SuLanguageList> ZDbLanguageList { get; set; }
        public DbSet<SuStatusList> ZDbStatusList { get; set; }
        public DbSet<SuUITermList> ZDbUITermList { get; set; }
        public DbSet<SuSecurityLevelList> DbSecurityLevelList { get; set; }
        public DbSet<SuUITermLanguageEditGetModel> ZDbUITermLanguageEditGet { get; set; }
        public DbSet<SuCountryList> DbCountryList { get; set; }
        public DbSet<SuTypeList> ZDbTypeList { get; set; }
        public DbSet<SuValueList> DbValueList { get; set; }
        //        public DbSet<SuObjectLanguageEditGet> dbObjectLanguage { get; set; }
        public DbSet<SuObjectIndexGetModel> ZdbObjectIndexGet { get; set; }
        public DbSet<SuObjectLanguageCreateGetModel> ZdbObjectLanguageCreateGet { get; set; }
        public DbSet<SuObjectLanguageEditGetModel> ZdbObjectLanguageEditGet { get; set; }
        public DbSet<SuPageLanguageEditGetModel> ZdbPageLanguageEditGet { get; set; }
        public DbSet<SuObjectLanguageIndexGetModel> ZdbObjectLanguageIndexGet { get; set; }
        public DbSet<SuProcessTemplateFlowConditionEditGetModel> ZdbProcessTemplateFlowConditionEditGet { get; set; }

        public DbSet<SuUIScreenModel> DbUIScreen { get; set; }
        public DbSet<SuUITermLanguageModel> DbUITermLanguage { get; set; }
        public DbSet<SuUITermModel> DbUITerm { get; set; }
        public DbSet<SuUITermScreenModel> DbUITermScreen { get; set; }


        public DbSet<SuOrganizationIndexGet> ZdbOrganizationIndexGet { get; set; }
        public DbSet<SuGetProjectStructure> DbGetProjectStructure { get; set; }
        public DbSet<SuPageSectionsViewModel> DbPageSectionsViewModel { get; set; }
        public DbSet<SuObjectVM> DbObjectVM { get; set; }
        public DbSet<SuObject> DbObject { get; set; }
        public DbSet<SuIdWithStrings> DbIdWithStrings { get; set; }

        public DbSet<SuClaim> DbClaim { get; set; }
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

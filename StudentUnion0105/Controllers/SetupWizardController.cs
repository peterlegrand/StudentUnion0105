using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using System.IO;
using System.Threading.Tasks;


namespace StudentUnion0105.Controllers
{
    [AllowAnonymous]
    public class SetupWizardController : Controller
    {
        private readonly UserManager<SuUserModel> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHostingEnvironment _env;
        private readonly SuDbContext _context;

        public SetupWizardController(UserManager<SuUserModel> userManager
            , RoleManager<IdentityRole> roleManager
            , IHostingEnvironment env
            , SuDbContext context
            )
        {

            _userManager = userManager;
            _roleManager = roleManager;
            _env = env;
            _context = context;
        }

        public IActionResult Index()
        { return View(); }
        public async Task<IActionResult> MasterData()
        {
            var x = await _userManager.FindByEmailAsync("peter@energimeuniversity.org");
            if (x == null)
            {
                SuUserModel  user1 = new SuUserModel()
                {
                    UserName = "peter@energimeuniversity.org",
                    Email = "peter@energimeuniversity.org",
                    DefaultLanguageId = 41
                };

                await _userManager.CreateAsync(user1, "Pipo!9165");

            }

            if (_env.IsDevelopment())

            {
                if (_userManager.FindByEmailAsync("pipo@gmail.com").Result == null)
                {
                    SuUserModel  user1 = new SuUserModel()
                    {
                        UserName = "pipo@gmail.com",
                        Email = "pipo@gmail.com",
                        DefaultLanguageId = 41
                    };

                    await _userManager.CreateAsync(user1, "Xipo!9165");
                }
            }

            var user = await _userManager.FindByEmailAsync("peter@energimeuniversity.org");

            foreach (var a in await _userManager.GetRolesAsync(user))
            { await _userManager.RemoveFromRoleAsync(user, a); }
            await _userManager.AddToRoleAsync(user, "Admin");
            await _userManager.AddToRoleAsync(user, "Super admin");



            var SuperAdmin = await _roleManager.FindByNameAsync("Super admin");
            await _roleManager.GetClaimsAsync(SuperAdmin);
            foreach (var claim in await _roleManager.GetClaimsAsync(SuperAdmin))
            {
                await _roleManager.RemoveClaimAsync(SuperAdmin, claim);
            }
            await _roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Role"));
            await _roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Classification"));
            await _roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Page"));
            await _roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Project"));
            await _roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Type"));

            string[] StoredProcedures;
            StoredProcedures = new string[]{
"ClassificationCreatePost.sql"
, "ClassificationDeleteGet.sql"
, "ClassificationDeletePost.sql"
, "ClassificationEditGet.sql"
, "ClassificationEditPost.sql"
, "ClassificationIndexGet.sql"
, "ClassificationLanguageCreateGetLanguages.sql"
, "ClassificationLanguageCreatePost.sql"
, "ClassificationLanguageDeletePost.sql"
, "ClassificationLanguageEditGet.sql"
, "ClassificationLanguageEditPost.sql"
, "ClassificationLanguageIndexGet.sql"
, "ClassificationLevelCreateGetExistingLevels.sql"
, "ClassificationLevelCreatePost.sql"
, "ClassificationLevelDeleteGet.sql"
, "ClassificationLevelDeletePost.sql"
, "ClassificationLevelEditGet.sql"
, "ClassificationLevelEditGetExistingLevels.sql"
, "ClassificationLevelEditPost.sql"
, "ClassificationLevelIndexGet.sql"
, "ClassificationLevelLanguageCreateGetLanguages.sql"
, "ClassificationLevelLanguageCreatePost.sql"
, "ClassificationLevelLanguageDeletePost.sql"
, "ClassificationLevelLanguageEditGet.sql"
, "ClassificationLevelLanguageEditPost.sql"
, "ClassificationLevelLanguageIndexGet.sql"
, "ClassificationPageCreatePost.sql"
, "ClassificationPageDeleteGet.sql"
, "ClassificationPageDeletePost.sql"
, "ClassificationPageEditGet.sql"
, "ClassificationPageEditPost.sql"
, "ClassificationPageIndexGet.sql"
, "ClassificationPageLanguageCreateGetLanguages.sql"
, "ClassificationPageLanguageCreatePost.sql"
, "ClassificationPageLanguageDeletePost.sql"
, "ClassificationPageLanguageEditGet.sql"
, "ClassificationPageLanguageEditPost.sql"
, "ClassificationPageLanguageIndexGet.sql"
, "ClassificationPageSectionCreatePost.sql"
, "ClassificationPageSectionDeleteGet.sql"
, "ClassificationPageSectionDeletePost.sql"
, "ClassificationPageSectionEditGet.sql"
, "ClassificationPageSectionEditPost.sql"
, "ClassificationPageSectionIndexGet.sql"
, "ClassificationPageSectionLanguageCreateGetLanguages.sql"
, "ClassificationPageSectionLanguageCreatePost.sql"
, "ClassificationPageSectionLanguageDeletePost.sql"
, "ClassificationPageSectionLanguageEditGet.sql"
, "ClassificationPageSectionLanguageEditPost.sql"
, "ClassificationPageSectionLanguageIndexGet.sql"
, "ClassificationStatusList.sql"
, "ClassificationValueCreateGetLevel.sql"
, "ClassificationValueCreatePost.sql"
, "ClassificationValueDeleteGet.sql"
, "ClassificationValueDeletePost.sql"
, "ClassificationValueEditGet.sql"
, "ClassificationValueEditGetLevel.sql"
, "ClassificationValueEditPost.sql"
, "ClassificationValueIndexGet.sql"
, "ClassificationValueIndexGetCurrentLevel.sql"
, "ClassificationValueIndexGetMaxLevel.sql"
, "ClassificationValueLanguageCreateGetLanguageList.sql"
, "ClassificationValueLanguageCreatePost.sql"
, "ClassificationValueLanguageDeletePost.sql"
, "ClassificationValueLanguageEditGet.sql"
, "ClassificationValueLanguageEditPost.sql"
, "ClassificationValueLanguageIndexGet.sql"
, "ClassificationValueStructureValues.sql"
, "ContentCreate.sql"
, "ContentInsert.sql"
, "ContentStatusSelectAll.sql"
, "ContentTypeClassificationEditGet.sql"
, "ContentTypeClassificationEditGetStatusList.sql"
, "ContentTypeClassificationEditPost.sql"
, "ContentTypeClassificationIndexGet.sql"
, "ContentTypeCreatePost.sql"
, "ContentTypeDeleteGet.sql"
, "ContentTypeDeletePost.sql"
, "ContentTypeEditGet.sql"
, "ContentTypeEditPost.sql"
, "ContentTypeIndexGet.sql"
, "ContentTypeLanguageCreateGetLanguageList.sql"
, "ContentTypeLanguageCreatePost.sql"
, "ContentTypeLanguageDeletePost.sql"
, "ContentTypeLanguageEditGet.sql"
, "ContentTypeLanguageEditPost.sql"
, "ContentTypeLanguageIndexGet.sql"
, "ContentTypeSelectAllForLanguage.sql"
, "ContentUpdate.sql"
, "ContentValueCreate.sql"
, "CountryDD.sql"
, "CountrySelectAll.sql"
, "DataTypeSelectAll.sql"
, "ExternalPageGetContent.sql"
, "ExternalPageGetPage.sql"
, "ExternalPageGetPageSection.sql"
, "FrontCalendarEventCalendarGet.sql"
, "FrontCalendarMyCalendarGet.sql"
, "FrontOrganizationDashboardGetContent.sql"
, "FrontOrganizationDashboardGetOrganization.sql"
, "FrontOrganizationDashboardGetUsers.sql"
, "FrontOrganizationMyOrganizationGet.sql"
, "FrontPageGetContent.sql"
, "FrontPageGetPage.sql"
, "FrontPageMyContentGet.sql"
, "FrontPageGetPageSection.sql"
, "FrontPageViewGet.sql"
, "FrontPageViewGetClassificationValues.sql"
, "FrontProcessCreateGet.sql"
, "FrontProcessCreateGetField.sql"
, "FrontProcessIndexGetTemplate.sql"
, "FrontProcessIndexGetTemplateFlowCondition.sql"
, "FrontProcessIndexGetTemplateGroup.sql"
, "FrontProcessToDoEditGet.sql"
, "FrontProcessToDoIndex2GetFlowId.sql"
, "FrontProcessToDoIndex2GetForAndOr.sql"
, "FrontProcessToDoIndexGet.sql"
, "FrontProjectMyProjectGet.sql"
, "FrontRelationMyRelationGet.sql"
, "GetMasterList.sql"
, "GetProcessTemplateFlowConditionCreateGetFields.sql"
, "GetProcessTemplateGroup.sql"
, "HomeIndexAdminGetTables.sql"
, "HomeIndexAdminGetLanguages.sql"
//, "IndexAdminGetNoOfRecords.sql"
, "HomeIndexAdminGetNoOfRecordsAndPerLanguage.sql"
, "LanguageIndexGet.sql"
, "LanguageSelectActive.sql"
, "LanguageSelectAll.sql"
, "Menu123EditGetClassificationList.sql"
, "Menu1.sql"
, "Menu1CreatePost.sql"
, "Menu1IndexGet.sql"
, "Menu1DeleteGet.sql"
, "Menu1DeletePost.sql"
, "Menu1EditGet.sql"
, "Menu1EditPost.sql"
, "Menu1LanguageCreateGetLanguages.sql"
, "Menu1LanguageCreatePost.sql"
, "Menu1LanguageDeletePost.sql"
, "Menu1LanguageEditGet.sql"
, "Menu1LanguageEditPost.sql"
, "Menu1LanguageIndexGet.sql"
, "Menu2.sql"
, "Menu2CreatePost.sql"
, "Menu2IndexGet.sql"
, "Menu2DeleteGet.sql"
, "Menu2DeletePost.sql"
, "Menu2EditGet.sql"
, "Menu2EditPost.sql"
, "Menu2LanguageCreateGetLanguages.sql"
, "Menu2LanguageCreatePost.sql"
, "Menu2LanguageDeletePost.sql"
, "Menu2LanguageEditGet.sql"
, "Menu2LanguageEditPost.sql"
, "Menu2LanguageIndexGet.sql"
, "Menu3.sql"
, "Menu3CreatePost.sql"
, "Menu3IndexGet.sql"
, "Menu3DeleteGet.sql"
, "Menu3DeletePost.sql"
, "Menu3EditGet.sql"
, "Menu3EditPost.sql"
, "Menu3LanguageCreateGetLanguages.sql"
, "Menu3LanguageCreatePost.sql"
, "Menu3LanguageDeletePost.sql"
, "Menu3LanguageEditGet.sql"
, "Menu3LanguageEditPost.sql"
, "Menu3LanguageIndexGet.sql"
, "MenuTypeList.sql"
, "OrganizationDeleteGet.sql"
, "OrganizationDeletePost.sql"
, "OrganizationEditGet.sql"
, "OrganizationLanguageEditPost.sql"
, "OrganizationIndexGet.sql"
, "OrganizationLanguageCreateGetLanguageList.sql"
, "OrganizationTypeLanguageCreateGetLanguageList.sql"
, "OrganizationLanguageCreatePost.sql"
, "OrganizationLanguageDeletePost.sql"
, "OrganizationLanguageEditGet.sql"
, "OrganizationLanguageIndexGet.sql"
, "OrganizationTypeCreatePost.sql"
, "OrganizationTypeDeleteGet.sql"
, "OrganizationTypeDeletePost.sql"
, "OrganizationTypeEditGet.sql"
, "OrganizationTypeIndexGet.sql"
, "OrganizationTypeLanguageCreatePost.sql"
, "OrganizationTypeLanguageDeletePost.sql"
, "OrganizationTypeLanguageEditGet.sql"
, "OrganizationTypeLanguageEditPost.sql"
, "OrganizationTypeLanguageIndexGet.sql"
, "OrgStructure.sql"
, "PageCreatePost.sql"
, "PageDeleteGet.sql"
, "PageDeletePost.sql"
, "PageEditGet.sql"
, "PageIndexGet.sql"
, "PageLanguageCreateGetLanguageList.sql"
, "PageLanguageCreatePost.sql"
, "PageLanguageDeletePost.sql"
, "PageLanguageEditGet.sql"
, "PageLanguageEditPost.sql"
, "PageLanguageIndexGet.sql"
, "PageSectionDeleteGet.sql"
, "PageSectionDeletePost.sql"
, "PageSectionEditGet.sql"
, "PageSectionIndexGet.sql"
, "PageSectionLanguageCreateGetLanguageList.sql"
, "PageSectionLanguageCreatePost.sql"
, "PageSectionLanguageDeletePost.sql"
, "PageSectionLanguageEditGet.sql"
, "PageSectionLanguageEditPost.sql"
, "PageSectionLanguageIndexGet.sql"
, "PageSectionTypeCreatePost.sql"
, "PageSectionTypeDeleteGet.sql"
, "PageSectionTypeDeletePost.sql"
, "PageSectionTypeEditGet.sql"
, "PageSectionTypeEditPost.sql"
, "PageSectionTypeIndexGet.sql"
, "PageSectionTypeLanguageCreateGetLanguageList.sql"
, "PageSectionTypeLanguageCreatePost.sql"
, "PageSectionTypeLanguageDeletePost.sql"
, "PageSectionTypeLanguageEditGet.sql"
, "PageSectionTypeLanguageEditPost.sql"
, "PageSectionTypeLanguageIndexGet.sql"
, "PageSectionTypeSelectAllForLanguage.sql"
, "PageSectionUpdate.sql"
, "PageStatusSelectAll.sql"
, "PageTypeCreatePost.sql"
, "PageTypeDeleteGet.sql"
, "PageTypeDeletePost.sql"
, "PageTypeEditGet.sql"
, "PageTypeIndexGet.sql"
, "PageTypeLanguageCreateGetLanguageList.sql"
, "PageTypeLanguageCreatePost.sql"
, "PageTypeLanguageDeletePost.sql"
, "PageTypeLanguageEditGet.sql"
, "PageTypeLanguageEditPost.sql"
, "PageTypeLanguageIndexGet.sql"
, "PartialLeftMenu.sql"
, "PartialTopMenu1.sql"
, "PartialTopMenu2.sql"
, "PreferenceIndexGet.sql"
, "PreferenceIndexPost.sql"
, "PreferenceLeftMenuEditGet.sql"
, "PreferenceLeftMenuEditGetOtherMenus.sql"
, "PreferenceLeftMenuEditPost.sql"
, "PreferenceLeftMenuGet.sql"
, "PreferenceLeftMenuGetAvailableMenus.sql"
, "ProjectLanguageCreateGetLanguageList.sql"
, "ProcessTemplateCreatePost.sql"
, "ProcessTemplateDeleteGet.sql"
, "ProcessTemplateDeletePost.sql"
, "ProcessTemplateEditGet.sql"
, "ProcessTemplateFieldCreate.sql"
, "ProcessTemplateFieldCreatePost.sql"
, "ProcessTemplateFieldDeleteGet.sql"
, "ProcessTemplateFieldDeletePost.sql"
, "ProcessTemplateFieldEditGet.sql"
, "ProcessTemplateFieldEditPost.sql"
, "ProcessTemplateFieldIndexGet.sql"
, "ProcessTemplateFieldLanguageCreateGetLanguageList.sql"
, "ProcessTemplateFieldLanguageCreatePost.sql"
, "ProcessTemplateFieldLanguageDeletePost.sql"
, "ProcessTemplateFieldLanguageEditGet.sql"
, "ProcessTemplateFieldLanguageEditPost.sql"
, "ProcessTemplateFieldLanguageIndexGet.sql"
//, "ProcessTemplateFieldTypeDeleteGet.sql"
//, "ProcessTemplateFieldTypeDeletePost.sql"
, "ProcessTemplateFieldTypeIndexGet.sql"
, "ProcessTemplateFieldTypeLanguageCreateGetLanguageList.sql"
, "ProcessTemplateFieldTypeLanguageCreatePost.sql"
, "ProcessTemplateFieldTypeLanguageDeletePost.sql"
, "ProcessTemplateFieldTypeLanguageEditGet.sql"
, "ProcessTemplateFieldTypeLanguageEditPost.sql"
, "ProcessTemplateFieldTypeLanguageIndexGet.sql"
, "ProcessTemplateFieldTypeSelectAllForLanguage.sql"
, "ProcessTemplateFieldUpdate.sql"
, "ProcessTemplateFlowConditionCreate.sql"
, "ProcessTemplateFlowConditionCreateGetComparison.sql"
, "ProcessTemplateFlowConditionCreateGetFields.sql"
, "ProcessTemplateFlowConditionCreateGetType.sql"
, "ProcessTemplateFlowConditionDeleteGet.sql"
, "ProcessTemplateFlowConditionDeletePost.sql"
, "ProcessTemplateFlowConditionEditGet.sql"
, "ProcessTemplateFlowConditionEditGetTypes.sql"
, "ProcessTemplateFlowConditionEditPost.sql"
, "ProcessTemplateFlowConditionIndexGet.sql"
, "ProcessTemplateFlowConditionLanguageCreatePost.sql"
, "ProcessTemplateFlowConditionLanguageDeletePost.sql"
, "ProcessTemplateFlowConditionLanguageEditGet.sql"
, "ProcessTemplateFlowConditionLanguageEditPost.sql"
, "ProcessTemplateFlowConditionLanguageIndexGet.sql"
, "ProcessTemplateFlowConditionUpdate.sql"
, "ProcessTemplateFlowCreate.sql"
, "ProcessTemplateFlowDeleteGet.sql"
, "ProcessTemplateFlowDeletePost.sql"
, "ProcessTemplateFlowEditGet.sql"
, "ProcessTemplateFlowIndexGet.sql"
, "ProcessTemplateFlowLanguageCreateGetLanguageList.sql"
, "ProcessTemplateFlowLanguageCreatePost.sql"
, "ProcessTemplateFlowLanguageDeletePost.sql"
, "ProcessTemplateFlowLanguageEditGet.sql"
, "ProcessTemplateFlowLanguageEditPost.sql"
, "ProcessTemplateFlowLanguageIndexGet.sql"
, "ProcessTemplateFlowUpdate.sql"
, "ProcessTemplateGroupDeleteGet.sql"
, "ProcessTemplateGroupDeletePost.sql"
, "ProcessTemplateGroupEditGet.sql"
, "ProcessTemplateGroupIndexGet.sql"
, "ProcessTemplateGroupLanguageCreateGetLanguageList.sql"
, "ProcessTemplateGroupLanguageCreatePost.sql"
, "ProcessTemplateGroupLanguageDeletePost.sql"
, "ProcessTemplateGroupLanguageEditGet.sql"
, "ProcessTemplateGroupLanguageEditPost.sql"
, "ProcessTemplateGroupLanguageIndexGet.sql"
, "ProcessTemplateIndexGet.sql"
, "ProcessTemplateLanguageCreateGetLanguageList.sql"
, "ProcessTemplateLanguageCreatePost.sql"
, "ProcessTemplateLanguageDeletePost.sql"
, "ProcessTemplateLanguageEditGet.sql"
, "ProcessTemplateLanguageIndexGet.sql"
, "ProcessTemplateStepCreate.sql"
, "ProcessTemplateStepDeleteGet.sql"
, "ProcessTemplateStepDeletePost.sql"
, "ProcessTemplateStepEditGet.sql"
, "ProcessTemplateStepFieldsIndexGet.sql"
, "ProcessTemplateStepFieldUpdate.sql"
, "ProcessTemplateStepIndexGet.sql"
, "ProcessTemplateStepLanguageCreateGetLanguageList.sql"
, "ProcessTemplateStepLanguageDeletePost.sql"
, "ProcessTemplateStepLanguageEditGet.sql"
, "ProcessTemplateStepLanguageIndexGet.sql"
, "ProcessTemplateStepUpdate.sql"
, "ProjectDeleteGet.sql"
, "ProjectDeletePost.sql"
, "ProjectEditGet.sql"
, "ProjectIndexGet.sql"
, "ProjectLanguageCreatePost.sql"
, "ProjectLanguageDeletePost.sql"
, "ProjectLanguageEditGet.sql"
, "ProjectLanguageEditPost.sql"
, "ProjectLanguageIndexGet.sql"
, "ProjectTypeEditGet.sql"
, "ProjStructure.sql"
, "SecurityLevelSelectAll.sql"
, "ShowContent.sql"
, "ShowPage.sql"
, "ShowPageSection.sql"
, "UITermLanguageCreateGetLanguages.sql"
, "UITermLanguageCreatePost.sql"
, "UITermLanguageEditGet.sql"
, "UITermLanguageEditPost.sql"
, "UITermLanguageSelect.sql"
, "UITermLanguageSelectForUpdate.sql"
, "UITermLanguagesSelectForOneTerm.sql"
, "UITermLanguageUpdate.sql"
, "UITermSelectAll.sql"
, "UserOrganizationCreate.sql"
, "UserOrganizationSelectAll.sql"
, "UserOrganizationSelectBasedOnUser.sql"
, "UserOrganizationTypeIndexGet.sql"
, "UserOrganizationTypeLanguageCreateGetLanguages.sql"
, "UserOrganizationTypeLanguageCreatePost.sql"
, "UserOrganizationTypeLanguageEditGet.sql"
, "UserOrganizationTypeLanguageEditPost.sql"
, "UserOrganizationTypeLanguageIndexGet.sql"
, "UserOrganizationTypeSelectAll.sql"
, "UserOrganizationTypeSelectAllLanguages.sql"
, "UserProjectCreate.sql"
, "UserProjectSelectAll.sql"
, "UserProjectSelectBasedOnUser.sql"
, "UserProjectTypeLanguageCreateGetLanguages.sql"
, "UserProjectTypeLanguageCreatePost.sql"
, "UserProjectTypeLanguageEditGet.sql"
, "UserProjectTypeLanguageEditPost.sql"
, "UserProjectTypeLanguageIndexGet.sql"
, "UserProjectTypeSelectAll.sql"
, "UserRelationTypeIndexGet.sql"
, "UserRelationTypeLanguageCreateGetLanguages.sql"
, "UserRelationTypeLanguageCreatePost.sql"
, "UserRelationTypeLanguageDeleteGet.sql"
, "UserRelationTypeLanguageDeletePost.sql"
, "UserRelationTypeLanguageEditGet.sql"
, "UserRelationTypeLanguageEditPost.sql"
, "UserRelationTypeLanguageIndexGet.sql"




            };

            foreach (string StoredProcedure in StoredProcedures)
            {
                using (StreamReader sr = new StreamReader("MasterDataScripts\\StoredProcedures\\" +StoredProcedure, System.Text.Encoding.UTF8))
                {
                    string line = sr.ReadToEnd();
                    _context.Database.ExecuteSqlCommand(line);
                }
            }

            string[] MasterDataScripts;
            MasterDataScripts = new string[]{ "MasterData.sql", "UIScreens.sql","UITerms.sql", "UITermScreen.sql"
};

            foreach (string MasterDataScript in MasterDataScripts)
            {
                using (StreamReader sr = new StreamReader("MasterDataScripts\\" + MasterDataScript, System.Text.Encoding.UTF8))
                {
                    string line = sr.ReadToEnd();
                    _context.Database.ExecuteSqlCommand(line);
                }
            }
            return View();
        }
        public IActionResult DemoData()
        {
            string[] StoredProcedures;
            StoredProcedures = new string[] { "DemoData.sql" };

            foreach (string StoredProcedure in StoredProcedures)
            {
                using (StreamReader sr = new StreamReader("DemoDataScripts\\" + StoredProcedure, System.Text.Encoding.UTF8))
                {
                    string line = sr.ReadToEnd();
                    _context.Database.ExecuteSqlCommand(line);
                }
            }


            return View();
        }
        public IActionResult DemoDataNL()
        {
            string[] StoredProcedures;
            StoredProcedures = new string[] { "DemoDutch.sql" };

            foreach (string StoredProcedure in StoredProcedures)
            {
                using (StreamReader sr = new StreamReader("DemoDataScripts\\" + StoredProcedure, System.Text.Encoding.UTF8))
                {
                    string line = sr.ReadToEnd();
                    _context.Database.ExecuteSqlCommand(line);
                }
            }


            return View();
        }
    }
}
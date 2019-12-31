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
        private readonly UserManager<SuUserModel> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHostingEnvironment env;
        private readonly SuDbContext _context;

        public SetupWizardController(UserManager<SuUserModel> userManager
            , RoleManager<IdentityRole> roleManager
            , IHostingEnvironment env
            , SuDbContext context
            )
        {

            this.userManager = userManager;
            this.roleManager = roleManager;
            this.env = env;
            _context = context;
        }

        public IActionResult Index()
        { return View(); }
        public async Task<IActionResult> MasterData()
        {
            var x = await userManager.FindByEmailAsync("eplegrand@gmail.com");
            if (x == null)
            {
                SuUserModel  user1 = new SuUserModel()
                {
                    UserName = "eplegrand@gmail.com",
                    Email = "eplegrand@gmail.com",
                    DefaultLanguageId = 41
                };

                await userManager.CreateAsync(user1, "Pipo!9165");

            }

            if (env.IsDevelopment())

            {
                if (userManager.FindByEmailAsync("pipo@gmail.com").Result == null)
                {
                    SuUserModel  user1 = new SuUserModel()
                    {
                        UserName = "pipo@gmail.com",
                        Email = "pipo@gmail.com",
                        DefaultLanguageId = 41
                    };

                    await userManager.CreateAsync(user1, "Xipo!9165");
                }
            }

            var user = await userManager.FindByEmailAsync("eplegrand@gmail.com");

            foreach (var a in await userManager.GetRolesAsync(user))
            { await userManager.RemoveFromRoleAsync(user, a); }
            await userManager.AddToRoleAsync(user, "Admin");
            await userManager.AddToRoleAsync(user, "Super admin");



            var SuperAdmin = await roleManager.FindByNameAsync("Super admin");
            await roleManager.GetClaimsAsync(SuperAdmin);
            foreach (var claim in await roleManager.GetClaimsAsync(SuperAdmin))
            {
                await roleManager.RemoveClaimAsync(SuperAdmin, claim);
            }
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Role"));
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Classification"));
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Page"));
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Project"));
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Type"));

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
, "ClassificationPageSectionLanguageEditGet.sql"
, "ClassificationPageSectionLanguageEditPost.sql"
, "ClassificationPageSectionLanguageIndexGet.sql"
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
, "ClassificationValueLanguageCreatePost.sql"
, "ClassificationValueLanguageDeletePost.sql"
, "ClassificationValueLanguageEditGet.sql"
, "ClassificationValueLanguageEditPost.sql"
, "ClassificationValueLanguageIndexGet.sql"
, "ClassificationValueStructureValues.sql"
, "ContentCreate.sql"
, "ContentInsert.sql"
, "ContentStatusSelectAll.sql"
, "ContentTypeDeleteGet.sql"
, "ContentTypeCreatePost.sql"
, "ContentTypeDeletePost.sql"
, "ContentTypeEditGet.sql"
, "ContentTypeEditPost.sql"
, "ContentTypeIndexGet.sql"
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
, "FrontPageGetContent.sql"
, "FrontPageGetPage.sql"
, "FrontPageGetPageSection.sql"
, "FrontPageViewGet.sql"
, "FrontProcessCreateGet.sql"
, "FrontProcessCreateGetField.sql"
, "FrontProcessIndexGetTemplate.sql"
, "FrontProcessIndexGetTemplateFlowCondition.sql"
, "FrontProcessIndexGetTemplateGroup.sql"
, "FrontProcessToDoEditGet.sql"
, "FrontProcessToDoIndex2GetFlowId.sql"
, "FrontProcessToDoIndex2GetForAndOr.sql"
, "FrontProcessToDoIndexGet.sql"
, "GetMasterList.sql"
, "GetProcessTemplateFlowConditionCreateGetFields.sql"
, "GetProcessTemplateGroup.sql"
, "LanguageIndexGet.sql"
, "LanguageSelectActive.sql"
, "LanguageSelectAll.sql"
, "OrganizationDeleteGet.sql"
, "OrganizationDeletePost.sql"
, "OrganizationEditGet.sql"
, "OrganizationLanguageEditPost.sql"
, "OrganizationIndexGet.sql"
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
, "PageLanguageCreatePost.sql"
, "PageLanguageDeletePost.sql"
, "PageLanguageEditGet.sql"
, "PageLanguageEditPost.sql"
, "PageLanguageIndexGet.sql"
, "PageSectionDeleteGet.sql"
, "PageSectionDeletePost.sql"
, "PageSectionEditGet.sql"
, "PageSectionIndexGet.sql"
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
, "PageTypeLanguageCreatePost.sql"
, "PageTypeLanguageDeletePost.sql"
, "PageTypeLanguageEditGet.sql"
, "PageTypeLanguageEditPost.sql"
, "PageTypeLanguageIndexGet.sql"
, "PreferenceIndexGet.sql"
, "PreferenceIndexPost.sql"
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
, "ProcessTemplateFieldLanguageCreatePost.sql"
, "ProcessTemplateFieldLanguageDeletePost.sql"
, "ProcessTemplateFieldLanguageEditGet.sql"
, "ProcessTemplateFieldLanguageEditPost.sql"
, "ProcessTemplateFieldLanguageIndexGet.sql"
//, "ProcessTemplateFieldTypeDeleteGet.sql"
//, "ProcessTemplateFieldTypeDeletePost.sql"
, "ProcessTemplateFieldTypeIndexGet.sql"
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
, "ProcessTemplateGroupLanguageCreatePost.sql"
, "ProcessTemplateGroupLanguageDeletePost.sql"
, "ProcessTemplateGroupLanguageEditGet.sql"
, "ProcessTemplateGroupLanguageEditPost.sql"
, "ProcessTemplateGroupLanguageIndexGet.sql"
, "ProcessTemplateIndexGet.sql"
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
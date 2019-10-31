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
                //CAN BE DELETED "ClassificationAndLanguageUpdate.sql"
                //CAN BE DELETED "ClassificationIndexSelect.sql"
                //CAN BE DELETED, "ClassificationLevelDeleteSelect.sql"
                //CAN BE DELETED, "ClassificationSelectOne.sql"
                 "ClassificationValueStructure.sql"
                , "ClassificationValueStructureValues.sql"
                , "ContentCreate.sql"
                , "ContentInsert.sql"
                , "ContentStatusSelectAll.sql"
                , "ContentTypeIndexSelect.sql"
                , "ContentTypeSelectAllForLanguage.sql"
                , "ContentUpdate.sql"
                , "ContentValueCreate.sql"
                , "ClassificationValueDeleteGet.sql"
                , "CountrySelectAll.sql"
                , "DataTypeSelectAll.sql"
                , "GetMasterList.sql"
                , "GetProcessTemplateFieldsForFlow.sql"
                , "GetProcessTemplateFlowConditionType.sql"
                , "GetProcessTemplateGroup.sql"
                , "LanguageSelectAll.sql"
                , "OrganizationIndexSelect.sql"
                , "OrganizationTypeIndexSelect.sql"
                , "OrgStructure.sql"
                , "PageSectionUpdate.sql"
                , "ProcessTemplateFieldCreate.sql"
                , "ProcessTemplateFieldSelect.sql"
                , "ProcessTemplateFieldUpdate.sql"
                , "ProcessTemplateFlowConditionCreate.sql"
                , "ProcessTemplateFlowConditionUpdate.sql"
                , "ProcessTemplateFlowCreate.sql"
                , "ProcessTemplateFlowUpdate.sql"
                , "ProcessTemplateStepCreate.sql"
                , "ProcessTemplateStepFieldUpdate.sql"
                , "ProcessTemplateStepUpdate.sql"
                , "ProjStructure.sql"
                , "SecurityLevelSelectAll.sql"
                , "ShowContent.sql"
                , "ShowPage.sql"
                , "ShowPageSection.sql"
                , "UITermLanguageSelect.sql"
                , "UITermLanguageSelectForUpdate.sql"
                , "UITermLanguagesSelectForOneTerm.sql"
                , "UITermLanguageUpdate.sql"
                , "UITermSelectAll.sql"
                , "UserOrganizationCreate.sql"
                , "UserOrganizationNewOrganizationsSelect.sql"
                , "UserOrganizationSelectAll.sql"
                , "UserOrganizationSelectBasedOnUser.sql"
                , "UserOrganizationTypeSelectAll.sql"
                , "UserOrganizationTypeSelectAllLanguages.sql"
                , "UserOrganizationTypeSelectLanguage.sql"
                , "UserProjectCreate.sql"
                , "UserProjectNewProjectsSelect.sql"
                , "UserProjectSelectAll.sql"
                , "UserProjectSelectBasedOnUser.sql"
                , "UserProjectTypeSelectAll.sql"

                , "ClassificationIndexGet.sql"
                , "ClassificationLevelIndexGet.sql"
                , "ContentTypeIndexGet.sql"
                , "LanguageIndexGet.sql"
                , "OrganizationIndexGet.sql"
                , "OrganizationTypeIndexGet.sql"
                , "PageSectionIndexGet.sql"
                , "PageSectionTypeIndexGet.sql"

////, "ClassificationValueIndexSelect.sql"
////, "HomeIndexSelect.sql"
////, "ClassificationValueIndexGet.sql"
////, "HomeIndexGet.sql"
////, "PageIndexGet.sql"
, "PageCreatePost.sql"
, "PageTypeIndexGet.sql"
//, "PageViewIndexGet.sql"
, "ProcessTemplateIndexGet.sql"
, "ProcessTemplateFieldIndexGet.sql"
//, "ProcessTemplateFieldStepsIndexGet.sql"
, "ProcessTemplateFieldTypeIndexGet.sql"
, "ProcessTemplateFlowIndexGet.sql"
, "ProcessTemplateFlowConditionIndexGet.sql"
, "ProcessTemplateGroupIndexGet.sql"
, "ProcessTemplateStepIndexGet.sql"
, "ProcessTemplateStepFieldsIndexGet.sql"
, "ProjectIndexGet.sql"
//, "RoleIndexGet.sql"
//, "SettingIndexGet.sql"
//, "SetupWizardIndexGet.sql"
//, "UserIndexGet.sql"
//, "UserProjectIndexGet.sql"
, "UserOrganizationTypeIndexGet.sql"

, "ClassificationLanguageIndexGet.sql"
, "ClassificationLevelLanguageIndexGet.sql"
, "ClassificationValueLanguageIndexGet.sql"
, "ContentTypeLanguageIndexGet.sql"
, "OrganizationLanguageIndexGet.sql"
, "OrganizationTypeLanguageIndexGet.sql"
, "PageLanguageIndexGet.sql"
, "PageSectionLanguageIndexGet.sql"
, "PageSectionTypeLanguageIndexGet.sql"
, "PageTypeLanguageIndexGet.sql"
, "ProcessTemplateLanguageIndexGet.sql"
, "ProcessTemplateFieldLanguageIndexGet.sql"
//, "ProcessTemplateFieldStepsLanguageIndexGet.sql"
, "ProcessTemplateFieldTypeLanguageIndexGet.sql"
, "ProcessTemplateFlowLanguageIndexGet.sql"
, "ProcessTemplateFlowConditionLanguageIndexGet.sql"
, "ProcessTemplateGroupLanguageIndexGet.sql"
, "ProcessTemplateStepLanguageIndexGet.sql"
, "ProjectLanguageIndexGet.sql"
, "UserOrganizationTypeLanguageIndexGet.sql"

//PETER Maybe no need for this
//, "ClassificationCreateGet.sql"
//, "ClassificationLevelCreateGet.sql"
//, "ClassificationValueCreateGet.sql"
//, "ContentCreateGet.sql"
//, "ContentTypeCreateGet.sql"
//, "OrganizationCreateGet.sql"
//, "OrganizationTypeCreateGet.sql"
//, "PageCreateGet.sql"
//, "PageSectionCreateGet.sql"
//, "PageSectionTypeCreateGet.sql"
//, "PageTypeCreateGet.sql"
//, "ProcessTemplateCreateGet.sql"
//, "ProcessTemplateFieldCreateGet.sql"
//, "ProcessTemplateFieldTypeCreateGet.sql"
//, "ProcessTemplateFlowCreateGet.sql"
//, "ProcessTemplateFlowConditionCreateGet.sql"
//, "ProcessTemplateGroupCreateGet.sql"
//, "ProcessTemplateStepCreateGet.sql"
//, "ProjectCreateGet.sql"
//, "RoleCreateGet.sql"
//, "UserCreateGet.sql"
//, "UserProjectCreateGet.sql"


, "ClassificationEditGet.sql"
, "ClassificationLevelEditGet.sql"
, "ClassificationValueEditGet.sql"
//, "ContentTypeEditGet.sql"
//, "LanguageEditGet.sql"
//, "OrganizationEditGet.sql"
, "OrganizationTypeEditGet.sql"
, "PageEditGet.sql"
, "PageSectionEditGet.sql"
, "PageSectionTypeEditGet.sql"
, "PageTypeEditGet.sql"
, "ProcessTemplateEditGet.sql"
, "ProcessTemplateFieldEditGet.sql"
//, "ProcessTemplateFieldStepsEditGet.sql"
//, "ProcessTemplateFieldTypeEditGet.sql"
, "ProcessTemplateFlowEditGet.sql"
, "ProcessTemplateFlowConditionEditGet.sql"
, "ProcessTemplateGroupEditGet.sql"
, "ProcessTemplateStepEditGet.sql"
//, "ProcessTemplateStepFieldsEditGet.sql"
, "ProjectEditGet.sql"
//, "RoleEditGet.sql"
//, "SettingEditGet.sql"
//, "UserEditGet.sql"

, "ClassificationDeleteGet.sql"
, "ClassificationLevelDeleteGet.sql"
, "ContentTypeDeleteGet.sql"
, "OrganizationDeleteGet.sql"
, "OrganizationTypeDeleteGet.sql"
, "PageDeleteGet.sql"
, "PageSectionDeleteGet.sql"
, "PageSectionTypeDeleteGet.sql"
, "PageTypeDeleteGet.sql"
, "ProcessTemplateDeleteGet.sql"
, "ProcessTemplateFieldDeleteGet.sql"
, "ProcessTemplateFieldTypeDeleteGet.sql"
, "ProcessTemplateFlowDeleteGet.sql"
, "ProcessTemplateFlowConditionDeleteGet.sql"
, "ProcessTemplateGroupDeleteGet.sql"
, "ProcessTemplateStepDeleteGet.sql"
, "ProjectDeleteGet.sql"


//, "ClassificationLanguageCreateGet.sql"
//, "ClassificationLevelLanguageCreateGet.sql"
//, "ClassificationValueLanguageCreateGet.sql"
//, "ContentTypeLanguageCreateGet.sql"
//, "OrganizationLanguageCreateGet.sql"
//, "OrganizationTypeLanguageCreateGet.sql"
//, "PageLanguageCreateGet.sql"
//, "PageSectionLanguageCreateGet.sql"
//, "PageSectionTypeLanguageCreateGet.sql"
//, "PageTypeLanguageCreateGet.sql"
//, "ProcessTemplateLanguageCreateGet.sql"
//, "ProcessTemplateFieldLanguageCreateGet.sql"
//, "ProcessTemplateFieldTypeLanguageCreateGet.sql"
//, "ProcessTemplateFlowLanguageCreateGet.sql"
//, "ProcessTemplateFlowConditionLanguageCreateGet.sql"
//, "ProcessTemplateGroupLanguageCreateGet.sql"
//, "ProcessTemplateStepLanguageCreateGet.sql"
//, "ProjectLanguageCreateGet.sql"
//, "ProcessTemplateFieldStepsLanguageCreateGet.sql"

, "ClassificationLanguageEditGet.sql"
, "ClassificationLevelLanguageEditGet.sql"
, "ClassificationValueLanguageEditGet.sql"
, "ContentTypeLanguageEditGet.sql"
, "OrganizationLanguageEditGet.sql"
, "OrganizationTypeLanguageEditGet.sql"
, "PageLanguageEditGet.sql"
, "PageSectionLanguageEditGet.sql"
, "PageSectionTypeLanguageEditGet.sql"
, "PageTypeLanguageEditGet.sql"
, "ProcessTemplateLanguageEditGet.sql"
, "ProcessTemplateFieldLanguageEditGet.sql"
, "ProcessTemplateFieldTypeLanguageEditGet.sql"
, "ProcessTemplateFlowLanguageEditGet.sql"
, "ProcessTemplateFlowConditionLanguageEditGet.sql"
, "ProcessTemplateGroupLanguageEditGet.sql"
, "ProcessTemplateStepLanguageEditGet.sql"
, "ProjectLanguageEditGet.sql"
//, "ProcessTemplateFieldStepsLanguageEditGet.sql"
//, "UserOrganizationTypeLanguageEditGet.sql"

                //PETER this can be the same as LanguageEdit
//, "ClassificationLanguageDeleteGet.sql"
//, "ClassificationLevelLanguageDeleteGet.sql"
//, "ClassificationValueLanguageDeleteGet.sql"
//, "ContentTypeLanguageDeleteGet.sql"
//, "OrganizationLanguageDeleteGet.sql"
//, "OrganizationTypeLanguageDeleteGet.sql"
//, "PageLanguageDeleteGet.sql"
//, "PageSectionLanguageDeleteGet.sql"
//, "PageSectionTypeLanguageDeleteGet.sql"
//, "PageTypeLanguageDeleteGet.sql"
//, "ProcessTemplateLanguageDeleteGet.sql"
//, "ProcessTemplateFieldLanguageDeleteGet.sql"
//, "ProcessTemplateFieldTypeLanguageDeleteGet.sql"
//, "ProcessTemplateFlowLanguageDeleteGet.sql"
//, "ProcessTemplateFlowConditionLanguageDeleteGet.sql"
//, "ProcessTemplateGroupLanguageDeleteGet.sql"
//, "ProcessTemplateStepLanguageDeleteGet.sql"
//, "ProjectLanguageDeleteGet.sql"


, "ClassificationCreatePost.sql"
, "ClassificationLevelCreatePost.sql"
//, "ClassificationValueCreatePost.sql"
//, "ContentCreatePost.sql"
//, "ContentTypeCreatePost.sql"
//, "OrganizationCreatePost.sql"
//, "OrganizationTypeCreatePost.sql"
//, "PageCreatePost.sql"
//, "PageSectionCreatePost.sql"
//, "PageSectionTypeCreatePost.sql"
//, "PageTypeCreatePost.sql"
//, "ProcessTemplateCreatePost.sql"
//, "ProcessTemplateFieldCreatePost.sql"
//, "ProcessTemplateFieldTypeCreatePost.sql"
//, "ProcessTemplateFlowCreatePost.sql"
//, "ProcessTemplateFlowConditionCreatePost.sql"
//, "ProcessTemplateGroupCreatePost.sql"
//, "ProcessTemplateStepCreatePost.sql"
//, "ProjectCreatePost.sql"
//, "RoleCreatePost.sql"
//, "UserCreatePost.sql"
//, "UserProjectCreatePost.sql"


, "ClassificationEditPost.sql"
, "ClassificationLevelEditPost.sql"
//, "ClassificationValueEditPost.sql"
//, "ContentTypeEditPost.sql"
//, "LanguageEditPost.sql"
//, "OrganizationEditPost.sql"
//, "OrganizationTypeEditPost.sql"
//, "PageEditPost.sql"
//, "PageSectionEditPost.sql"
//, "PageSectionTypeEditPost.sql"
//, "PageTypeEditPost.sql"
//, "ProcessTemplateEditPost.sql"
//, "ProcessTemplateFieldEditPost.sql"
//, "ProcessTemplateFieldStepsEditPost.sql"
//, "ProcessTemplateFieldTypeEditPost.sql"
//, "ProcessTemplateFlowEditPost.sql"
//, "ProcessTemplateFlowConditionEditPost.sql"
//, "ProcessTemplateGroupEditPost.sql"
//, "ProcessTemplateStepEditPost.sql"
//, "ProcessTemplateStepFieldsEditPost.sql"
//, "ProjectEditPost.sql"
//, "RoleEditPost.sql"
//, "SettingEditPost.sql"
//, "UserEditPost.sql"


, "ClassificationDeletePost.sql"
, "ClassificationLevelDeletePost.sql"
, "ClassificationValueDeletePost.sql"
, "ContentTypeDeletePost.sql"
, "OrganizationDeletePost.sql"
, "OrganizationTypeDeletePost.sql"
, "PageDeletePost.sql"
, "PageSectionDeletePost.sql"
, "PageSectionTypeDeletePost.sql"
, "PageTypeDeletePost.sql"
, "ProcessTemplateDeletePost.sql"
, "ProcessTemplateFieldDeletePost.sql"
, "ProcessTemplateFieldTypeDeletePost.sql"
, "ProcessTemplateFlowDeletePost.sql"
, "ProcessTemplateFlowConditionDeletePost.sql"
, "ProcessTemplateGroupDeletePost.sql"
, "ProcessTemplateStepDeletePost.sql"
, "ProjectDeletePost.sql"


, "ClassificationLanguageCreatePost.sql"
, "ClassificationLevelLanguageCreatePost.sql"
//, "ClassificationValueLanguageCreatePost.sql"
//, "ContentTypeLanguageCreatePost.sql"
//, "OrganizationLanguageCreatePost.sql"
//, "OrganizationTypeLanguageCreatePost.sql"
//, "PageLanguageCreatePost.sql"
//, "PageSectionLanguageCreatePost.sql"
//, "PageSectionTypeLanguageCreatePost.sql"
//, "PageTypeLanguageCreatePost.sql"
//, "ProcessTemplateLanguageCreatePost.sql"
//, "ProcessTemplateFieldLanguageCreatePost.sql"
//, "ProcessTemplateFieldTypeLanguageCreatePost.sql"
//, "ProcessTemplateFlowLanguageCreatePost.sql"
//, "ProcessTemplateFlowConditionLanguageCreatePost.sql"
//, "ProcessTemplateGroupLanguageCreatePost.sql"
//, "ProcessTemplateStepLanguageCreatePost.sql"
//, "ProjectLanguageCreatePost.sql"
//, "ProcessTemplateFieldStepsLanguageCreatePost.sql"

, "ClassificationLanguageEditPost.sql"
, "ClassificationLevelLanguageEditPost.sql"
//, "ClassificationValueLanguageEditPost.sql"
//, "ContentTypeLanguageEditPost.sql"
//, "OrganizationLanguageEditPost.sql"
//, "OrganizationTypeLanguageEditPost.sql"
//, "PageLanguageEditPost.sql"
//, "PageSectionLanguageEditPost.sql"
//, "PageSectionTypeLanguageEditPost.sql"
//, "PageTypeLanguageEditPost.sql"
//, "ProcessTemplateLanguageEditPost.sql"
//, "ProcessTemplateFieldLanguageEditPost.sql"
//, "ProcessTemplateFieldTypeLanguageEditPost.sql"
//, "ProcessTemplateFlowLanguageEditPost.sql"
//, "ProcessTemplateFlowConditionLanguageEditPost.sql"
//, "ProcessTemplateGroupLanguageEditPost.sql"
//, "ProcessTemplateStepLanguageEditPost.sql"
//, "ProjectLanguageEditPost.sql"
//, "ProcessTemplateFieldStepsLanguageEditPost.sql"
//, "UserOrganizationTypeLanguageEditPost.sql"


, "ClassificationLanguageDeletePost.sql"
, "ClassificationLevelLanguageDeletePost.sql"
, "ClassificationValueLanguageDeletePost.sql"
, "ContentTypeLanguageDeletePost.sql"
, "OrganizationLanguageDeletePost.sql"
, "OrganizationTypeLanguageDeletePost.sql"
, "PageLanguageDeletePost.sql"
, "PageSectionLanguageDeletePost.sql"
, "PageSectionTypeLanguageDeletePost.sql"
, "PageTypeLanguageDeletePost.sql"
, "ProcessTemplateLanguageDeletePost.sql"
, "ProcessTemplateFieldLanguageDeletePost.sql"
, "ProcessTemplateFieldTypeLanguageDeletePost.sql"
, "ProcessTemplateFlowLanguageDeletePost.sql"
, "ProcessTemplateFlowConditionLanguageDeletePost.sql"
, "ProcessTemplateGroupLanguageDeletePost.sql"
, "ProcessTemplateStepLanguageDeletePost.sql"
, "ProjectLanguageDeletePost.sql"




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
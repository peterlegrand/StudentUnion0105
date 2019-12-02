﻿using Microsoft.AspNetCore.Authorization;
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
, "ClassificationValueCreatePost.sql"
, "ClassificationValueDeleteGet.sql"
, "ClassificationValueDeletePost.sql"
, "ClassificationValueEditGet.sql"
, "ClassificationValueEditGetLevel.sql"
, "ClassificationValueEditPost.sql"
, "ClassificationValueIndexGet.sql"
, "ClassificationValueIndexGetCurrentLevel.sql"
, "ClassificationValueIndexGetMaxLevel.sql"
, "ClassificationValueLanguageDeletePost.sql"
, "ClassificationValueLanguageEditGet.sql"
, "ClassificationValueLanguageIndexGet.sql"
, "ClassificationValueStructureValues.sql"
, "ContentCreate.sql"
, "ContentInsert.sql"
, "ContentStatusSelectAll.sql"
, "ContentTypeDeleteGet.sql"
, "ContentTypeDeletePost.sql"
, "ContentTypeEditPost.sql"
, "ContentTypeIndexGet.sql"
, "ContentTypeLanguageDeletePost.sql"
, "ContentTypeLanguageEditGet.sql"
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
, "GetMasterList.sql"
, "GetProcessTemplateFlowConditionCreateGetFields.sql"
, "GetProcessTemplateGroup.sql"
, "LanguageIndexGet.sql"
, "LanguageSelectActive.sql"
, "LanguageSelectAll.sql"
, "OrganizationDeleteGet.sql"
, "OrganizationDeletePost.sql"
, "OrganizationEditGet.sql"
, "OrganizationIndexGet.sql"
, "OrganizationLanguageDeletePost.sql"
, "OrganizationLanguageEditGet.sql"
, "OrganizationLanguageIndexGet.sql"
, "OrganizationTypeDeleteGet.sql"
, "OrganizationTypeDeletePost.sql"
, "OrganizationTypeEditGet.sql"
, "OrganizationTypeIndexGet.sql"
, "OrganizationTypeLanguageDeletePost.sql"
, "OrganizationTypeLanguageEditGet.sql"
, "OrganizationTypeLanguageIndexGet.sql"
, "OrgStructure.sql"
, "PageCreatePost.sql"
, "PageDeleteGet.sql"
, "PageDeletePost.sql"
, "PageEditGet.sql"
, "PageIndexGet.sql"
, "PageLanguageDeletePost.sql"
, "PageLanguageEditGet.sql"
, "PageLanguageIndexGet.sql"
, "PageSectionDeleteGet.sql"
, "PageSectionDeletePost.sql"
, "PageSectionEditGet.sql"
, "PageSectionIndexGet.sql"
, "PageSectionLanguageDeletePost.sql"
, "PageSectionLanguageEditGet.sql"
, "PageSectionLanguageIndexGet.sql"
, "PageSectionTypeDeleteGet.sql"
, "PageSectionTypeDeletePost.sql"
, "PageSectionTypeEditGet.sql"
, "PageSectionTypeIndexGet.sql"
, "PageSectionTypeLanguageDeletePost.sql"
, "PageSectionTypeLanguageEditGet.sql"
, "PageSectionTypeLanguageIndexGet.sql"
, "PageSectionUpdate.sql"
, "PageTypeDeleteGet.sql"
, "PageTypeDeletePost.sql"
, "PageTypeEditGet.sql"
, "PageTypeIndexGet.sql"
, "PageTypeLanguageDeletePost.sql"
, "PageTypeLanguageEditGet.sql"
, "PageTypeLanguageIndexGet.sql"
, "PreferenceIndexGet.sql"
, "PreferenceIndexPost.sql"
, "ProcessTemplateDeleteGet.sql"
, "ProcessTemplateDeletePost.sql"
, "ProcessTemplateEditGet.sql"
, "ProcessTemplateFieldCreate.sql"
, "ProcessTemplateFieldDeleteGet.sql"
, "ProcessTemplateFieldDeletePost.sql"
, "ProcessTemplateFieldEditGet.sql"
, "ProcessTemplateFieldIndexGet.sql"
, "ProcessTemplateFieldLanguageDeletePost.sql"
, "ProcessTemplateFieldLanguageEditGet.sql"
, "ProcessTemplateFieldLanguageIndexGet.sql"
, "ProcessTemplateFieldTypeDeleteGet.sql"
, "ProcessTemplateFieldTypeDeletePost.sql"
, "ProcessTemplateFieldTypeIndexGet.sql"
, "ProcessTemplateFieldTypeLanguageDeletePost.sql"
, "ProcessTemplateFieldTypeLanguageEditGet.sql"
, "ProcessTemplateFieldTypeLanguageIndexGet.sql"
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
, "ProcessTemplateFlowConditionLanguageDeletePost.sql"
, "ProcessTemplateFlowConditionLanguageEditGet.sql"
, "ProcessTemplateFlowConditionLanguageIndexGet.sql"
, "ProcessTemplateFlowConditionUpdate.sql"
, "ProcessTemplateFlowCreate.sql"
, "ProcessTemplateFlowDeleteGet.sql"
, "ProcessTemplateFlowDeletePost.sql"
, "ProcessTemplateFlowEditGet.sql"
, "ProcessTemplateFlowIndexGet.sql"
, "ProcessTemplateFlowLanguageDeletePost.sql"
, "ProcessTemplateFlowLanguageEditGet.sql"
, "ProcessTemplateFlowLanguageIndexGet.sql"
, "ProcessTemplateFlowUpdate.sql"
, "ProcessTemplateGroupDeleteGet.sql"
, "ProcessTemplateGroupDeletePost.sql"
, "ProcessTemplateGroupEditGet.sql"
, "ProcessTemplateGroupIndexGet.sql"
, "ProcessTemplateGroupLanguageDeletePost.sql"
, "ProcessTemplateGroupLanguageEditGet.sql"
, "ProcessTemplateGroupLanguageIndexGet.sql"
, "ProcessTemplateIndexGet.sql"
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
, "ProjectLanguageDeletePost.sql"
, "ProjectLanguageEditGet.sql"
, "ProjectLanguageIndexGet.sql"
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
, "UserOrganizationTypeLanguageIndexGet.sql"
, "UserOrganizationTypeSelectAll.sql"
, "UserOrganizationTypeSelectAllLanguages.sql"
, "UserProjectCreate.sql"
, "UserProjectSelectAll.sql"
, "UserProjectSelectBasedOnUser.sql"
, "UserProjectTypeSelectAll.sql"




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
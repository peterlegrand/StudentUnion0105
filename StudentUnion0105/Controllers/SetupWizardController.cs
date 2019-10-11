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
            StoredProcedures = new string[]{ "ClassificationAndLanguageUpdate.sql"
                                            , "ClassificationValueStructure.sql"
                                            , "ClassificationValueStructureValues.sql"
            , "ContentCreate.sql"
            , "ContentInsert.sql"
            , "ContentStatusSelectAll.sql"
            , "ContentTypeSelectAllForLanguage.sql"
            , "ContentUpdate.sql"
            , "ContentValueCreate.sql"
            , "CountrySelectAll.sql"
            , "DataTypeSelectAll.sql"
            , "GetMasterList.sql"
            , "GetProcessTemplateFieldsForFlow.sql"
            , "GetProcessTemplateFlowConditionType.sql"
            , "GetProcessTemplateGroup.sql"
            , "LanguageSelectAll.sql"
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
            };

            foreach (string StoredProcedure in StoredProcedures)
            {
                using (StreamReader sr = new StreamReader("StoredProcedures\\" +StoredProcedure, System.Text.Encoding.UTF8))
                {
                    string line = sr.ReadToEnd();
                    _context.Database.ExecuteSqlCommand(line);
                }
            }

            string[] MasterDataScripts;
            MasterDataScripts = new string[]{ "MasterData.sql"
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
            StoredProcedures = new string[]{ "DemoData.sql", "DemoDutch.sql"};

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
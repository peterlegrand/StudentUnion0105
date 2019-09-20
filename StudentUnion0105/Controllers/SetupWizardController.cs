using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Models;


namespace StudentUnion0105.Controllers
{
    [AllowAnonymous]
    public class SetupWizardController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHostingEnvironment env;

        public SetupWizardController(UserManager<SuUser> userManager, RoleManager<IdentityRole> roleManager, IHostingEnvironment env)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.env = env;
        }
        public async Task<IActionResult> Index()
        {
            var x = await userManager.FindByEmailAsync("eplegrand@gmail.com");
            if ( x == null)
            {
                SuUser user1 = new SuUser()
                {
                    UserName = "eplegrand@gmail.com",
                    Email = "eplegrand@gmail.com",
                    DefaultLangauge = 41
                };

                IdentityResult result = userManager.CreateAsync(user1, "Pipo!9165").Result;

            }

            if (env.IsDevelopment())
                
            { 
            if (userManager.FindByEmailAsync("pipo@gmail.com").Result == null)
            {
                SuUser user1 = new SuUser()
                {
                    UserName = "pipo@gmail.com",
                    Email = "pipo@gmail.com",
                    DefaultLangauge = 41
                };
                
                IdentityResult result = userManager.CreateAsync(user1, "Xipo!9165").Result;
                }
            }

            var user = await userManager.FindByEmailAsync("eplegrand@gmail.com");

            foreach (var a in await userManager.GetRolesAsync(user))
            { await userManager.RemoveFromRoleAsync(user, a); }
            userManager.AddToRoleAsync(user, "Admin").Wait();
            userManager.AddToRoleAsync(user, "Super admin").Wait();



            var SuperAdmin = await roleManager.FindByNameAsync("Super admin");
            var checkroles = await roleManager.GetClaimsAsync(SuperAdmin);
            foreach (var claim in await roleManager.GetClaimsAsync(SuperAdmin))
            {
                await roleManager.RemoveClaimAsync(SuperAdmin, claim);
            }
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Role"));
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Classification"));
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Page"));
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Project"));
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Type"));

            return View();
        }
    }
}
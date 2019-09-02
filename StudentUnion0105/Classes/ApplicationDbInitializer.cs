using Microsoft.AspNetCore.Identity;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Classes
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<SuUser> userManager)
        {
            if (userManager.FindByEmailAsync("eplegrand@gmail.com").Result == null)
            {
                SuUser user = new SuUser
                {
                    UserName = "eplegrand@gmail.com",
                    Email = "eplegrand@gmail.com",
                    DefaultLangauge = 41
                };

                IdentityResult result = userManager.CreateAsync(user, "Pipo!9165").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}

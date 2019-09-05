using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Classes
{
    public class ApplicationDbInitializer
    {
        private readonly UserManager<SuUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public ApplicationDbInitializer(UserManager<SuUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        //public ApplicationDbInitializer(UserManager<SuUser> userManager, RoleManager<IdentityRole> roleManager)
        //{

        //}

        public  async void SeedUsers()
        {
            //using (IServiceScope serviceScope = ServiceProviderServiceExtensions.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //{
            //    var userManager = serviceScope.ServiceProvider.GetService<UserManager<SuUser>>();
            //    var RoleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            //}
           

        }
    }
    
}

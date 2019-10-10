using Microsoft.AspNetCore.Identity;
using StudentUnion0105.Models;

namespace StudentUnion0105.Classes
{
    public class ApplicationDbInitializer
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public ApplicationDbInitializer(UserManager<SuUserModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        //public ApplicationDbInitializer(UserManager<SuUserModel> userManager, RoleManager<IdentityRole> roleManager)
        //{

        //}

        public async void SeedUsers()
        {
            //using (IServiceScope serviceScope = ServiceProviderServiceExtensions.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //{
            //    var userManager = serviceScope.ServiceProvider.GetService<UserManager<SuUserModel>>();
            //    var RoleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            //}


        }
    }

}

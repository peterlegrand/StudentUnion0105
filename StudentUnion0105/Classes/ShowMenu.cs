﻿using Microsoft.AspNetCore.Identity;
using StudentUnion0105.Models;
using System.Threading.Tasks;

namespace StudentUnion0105.Classes
{
    public class ShowMenu

    {

        public async Task<bool> ShowMenuBasedOnClaim(System.Security.Claims.ClaimsPrincipal User,
            string ClaimType, string ClaimValue,
            UserManager<SuUserModel> userManager
            , RoleManager<IdentityRole> roleManager)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            if (!User.Identity.IsAuthenticated)
            { return false; }
            var roles = await userManager.GetRolesAsync(CurrentUser);
            foreach (var rolename in roles)
            {
                var role = await roleManager.FindByNameAsync(rolename);
                var claims = await roleManager.GetClaimsAsync(role);
                foreach (var claim in claims)
                {
                    if (claim.Type == ClaimType && claim.Value == ClaimValue)
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        //public IEnumerable<SelectListItem> GetClassificationStatusList()
        //{

        //    {
        //        var classificationStatusL = classificationStatus.GetAllClassificationStatus();
        //        List<SelectListItem> a = 
        //        .OrderBy(n => n.Name)
        //                  .Select(n =>
        //                  new SelectListItem
        //                  {
        //                      Value = n.Id.ToString(),
        //                      Text = n.Name
        //                  }).ToList();
        //    var ClassificationStatusTip = new SelectListItem()
        //    {
        //        Value = null,
        //        Text = "--- select status ---"
        //    };
        //    classificationStatus.Insert(0, ClassificationStatusTip);
        //    return new SelectList(classificationStatus, "Value", "Text");
        //}

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.IdentityViewModels;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    [Authorize("Roles")]

    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<SuUser> userManager;
        private readonly IClaimRepository _claim;

        public AdministrationController(RoleManager<IdentityRole> roleManager
                                        , UserManager<SuUser> userManager, IClaimRepository Claim)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _claim = Claim;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole irole = new IdentityRole
                { Name = model.RoleName };
                IdentityResult iresult = await roleManager.CreateAsync(irole);
                if (iresult.Succeeded)
                {
                    return RedirectToAction("RoleList", "Administration");
                }
                foreach (IdentityError e in iresult.Errors)
                {
                    ModelState.AddModelError("", e.Description);
                }
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult RoleList()
        {
            var roles = roleManager.Roles;

            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)

            {
                ViewBag.ErrorMessage = "User not found";
                return View("NotFound");
            }
            var Model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
                Claims = new List<Claim>()
            };
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    Model.Users.Add(user.UserName);
                }

            }
            var ClaimList = await roleManager.GetClaimsAsync(role);
            //            Claim Claim1 = new Claim();
            if (ClaimList.Count > 0)
            {
                foreach (var Claim1 in ClaimList)
                {
                    Model.Claims.Add(Claim1);
                }
            }



            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null)

            {
                ViewBag.ErrorMessage = "Role not found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);

            }

        }
        [HttpGet]
        public async Task<IActionResult> AddRightsToRole(string roleId)
        {
            //List<string> NewClaims = new List<string>();
            var NewClaims = new List<AddRightsToRoleViewModel>();
            var AllClaimList = _claim.GetAllClaims();
            var role = await roleManager.FindByIdAsync(roleId);
            var AssignedClaims = await roleManager.GetClaimsAsync(role);
            //if (AssignedClaims.Count > 0)
            //{
            foreach (var AllClaim in AllClaimList)

            {
                bool AlreadyHave = false;
                foreach (var AssignedClaim in AssignedClaims)
                {
                    if (AllClaim.Claim == AssignedClaim.Value)
                    {
                        AlreadyHave = true;
                    }
                }
                var NewClaim = new AddRightsToRoleViewModel
                {
                    RoleID = roleId
                ,
                    ClaimType = "Menu"
                ,
                    ClaimValue = AllClaim.Claim
                };
                if (!AlreadyHave)
                {
                    NewClaim.IsSelected = false;
                }
                else
                {
                    NewClaim.IsSelected = true;
                }
                NewClaims.Add(NewClaim);

            }
            ViewBag.roleId = roleId;

            return View(NewClaims);
        }

        [HttpPost]
        public async Task<IActionResult> AddRightsToRole(List<AddRightsToRoleViewModel> ClaimUpdates, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            var claims = await roleManager.GetClaimsAsync(role);
            foreach (var u in ClaimUpdates)
            {
                bool CheckedClaim = u.IsSelected;

                bool HaveClaim = false;

                foreach (var x in claims)
                {
                    if (u.ClaimValue == x.Value)
                    {
                        HaveClaim = true;

                    }

                }
                if (CheckedClaim && !HaveClaim)
                {
                    await roleManager.AddClaimAsync(role, new Claim("Menu", u.ClaimValue));
                }
                if (!CheckedClaim && HaveClaim)
                {
                    var results =  await roleManager.RemoveClaimAsync(role, new Claim("Menu", u.ClaimValue));
                    
                }
            }
            return RedirectToAction("EditRole",new { Id = roleId });
        }
    }


}



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.IdentityViewModels;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    [Authorize("Role")]

    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<SuUser> userManager;
        private readonly IClaimRepository _claim;

        public RoleController(RoleManager<IdentityRole> roleManager
                                        , UserManager<SuUser> userManager, IClaimRepository Claim)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _claim = Claim;
        }
        [HttpGet]
        public IActionResult Create()
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
        public IActionResult Index()
        {
            var roles = roleManager.Roles;

            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
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
            //if(Model.Users.Count()>1)
            //            Model.Users.Sort();
            var ClaimList = await roleManager.GetClaimsAsync(role);
            //            Claim Claim1 = new Claim();
            if (ClaimList.Count > 0)
            {
                foreach (var Claim1 in ClaimList)
                {
                    Model.Claims.Add(Claim1);
                }
            }
            //if(Model.Claims.Count()>1)
            //Model.Claims.Sort();


            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRoleViewModel model)
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
        public async Task<IActionResult> Users(string Id)
        {
            var NewUsers = new List<AddUsersToRoleViewModel>();
            var AllUserList = userManager.Users;
            var role = await roleManager.FindByIdAsync(Id);
            var AssignedUsers = await userManager.GetUsersInRoleAsync(role.Name);

            foreach (var user in AllUserList)

            {
                bool AlreadyHave = false;
                foreach (var AssignedUser in AssignedUsers)
                {
                    if (user == AssignedUser)
                    {
                        AlreadyHave = true;
                    }
                }
                var NewUser = new AddUsersToRoleViewModel
                {
                    RoleId = Id
                ,
                    UserName = user.UserName
                };
                if (!AlreadyHave)
                {
                    NewUser.IsSelected = false;
                }
                else
                {
                    NewUser.IsSelected = true;
                }
                NewUsers.Add(NewUser);

            }
            ViewBag.Id = Id;

            return View(NewUsers);

        }

        [HttpPost]
        public async Task<IActionResult> Users(List<AddUsersToRoleViewModel> UserUpdates, string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            //Users currently assigned.
            var AssignedUsers = await userManager.GetUsersInRoleAsync(role.Name);
            //New assigned
            foreach (var u in UserUpdates)
            {
                //New assigned or not
                bool CheckedUser = u.IsSelected;

                bool HaveUser = false;
                SuUser AssignedUser = new SuUser();

                foreach (var x in AssignedUsers)
                {
                    if (u.UserName == x.UserName)
                    {
                        HaveUser = true;
                        AssignedUser = x;
                    }


                }
                if (CheckedUser && !HaveUser)
                {
                    var us = await userManager.FindByEmailAsync(u.UserName);
                    await userManager.AddToRoleAsync(us, role.Name);//   ..AddClaimAsync(role, new Claim("Menu", u.ClaimValue));
                }
                if (!CheckedUser && HaveUser)
                {
                    var results = await userManager.RemoveFromRoleAsync(AssignedUser, role.Name);// roleManager.RemoveClaimAsync(role, new Claim("Menu", u.ClaimValue));

                }
            }
            return RedirectToAction("Edit", new { Id = Id });
        }



        [HttpGet]
        public async Task<IActionResult> Rights(string Id)
        {
            //List<string> NewClaims = new List<string>();
            var NewClaims = new List<AddRightsToRoleViewModel>();
            //All rights assigned and not assigned.
            var AllClaimList = _claim.GetAllClaims();
            var role = await roleManager.FindByIdAsync(Id);
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
                    RoleID = Id
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
            ViewBag.Id = Id;

            return View(NewClaims);
        }

        [HttpPost]
        public async Task<IActionResult> Rights(List<AddRightsToRoleViewModel> ClaimUpdates, string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            //Claims is currently assigned.
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
                    var results = await roleManager.RemoveClaimAsync(role, new Claim("Menu", u.ClaimValue));

                }
            }
            return RedirectToAction("Edit", new { Id = Id });
        }
    }


}



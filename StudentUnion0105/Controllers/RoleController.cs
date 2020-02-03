using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
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

public class RoleController : PortalController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IClaimRepository _claim;
                private readonly SuDbContext _context;

        public RoleController(RoleManager<IdentityRole> roleManager
                                        , UserManager<SuUserModel> userManager
            , IClaimRepository Claim
            , ILanguageRepository language
            , SuDbContext context) : base(userManager, language)
        {
            _roleManager = roleManager;
            _claim = Claim;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole irole = new IdentityRole
                { Name = model.RoleName, NormalizedName = model.RoleName.ToUpper() };
                IdentityResult iresult = await _roleManager.CreateAsync(irole);
                if (iresult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (IdentityError e in iresult.Errors)
                {
                    ModelState.AddModelError("", e.Description);
                }
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var roles = _roleManager.Roles;

            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var role = await _roleManager.FindByIdAsync(id);
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
            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    Model.Users.Add(user.UserName);
                }

            }
            var ClaimList = await _roleManager.GetClaimsAsync(role);
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
        public async Task<IActionResult> Edit(EditRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)

            {
                ViewBag.ErrorMessage = "Role not found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var NewUsers = new List<AddUsersToRoleViewModel>();
            var AllUserList = _userManager.Users;
            var role = await _roleManager.FindByIdAsync(Id);
            var AssignedUsers = await _userManager.GetUsersInRoleAsync(role.Name);

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
            var role = await _roleManager.FindByIdAsync(Id);
            //Users currently assigned.
            var AssignedUsers = await _userManager.GetUsersInRoleAsync(role.Name);
            //New assigned
            foreach (var u in UserUpdates)
            {
                //New assigned or not
                bool CheckedUser = u.IsSelected;

                bool HaveUser = false;
                SuUserModel  AssignedUser = new SuUserModel();

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
                    var us = await _userManager.FindByEmailAsync(u.UserName);
                    await _userManager.AddToRoleAsync(us, role.Name);
                }
                if (!CheckedUser && HaveUser)
                {
                    await _userManager.RemoveFromRoleAsync(AssignedUser, role.Name);

                }
            }
            return RedirectToAction("Edit", new { Id });
        }



        [HttpGet]
        public async Task<IActionResult> Rights(string Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var NewClaims = new List<AddRightsToRoleViewModel>();
            var AllClaimList = _claim.GetAllClaims();
            var role = await _roleManager.FindByIdAsync(Id);
            var AssignedClaims = await _roleManager.GetClaimsAsync(role);
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
            var role = await _roleManager.FindByIdAsync(Id);
            var claims = await _roleManager.GetClaimsAsync(role);
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
                    await _roleManager.AddClaimAsync(role, new Claim("Menu", u.ClaimValue));
                }
                if (!CheckedClaim && HaveClaim)
                {
                    await _roleManager.RemoveClaimAsync(role, new Claim("Menu", u.ClaimValue));

                }
            }
            return RedirectToAction("Edit", new { Id });
        }
    }


}



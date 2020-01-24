using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.IdentityViewModels;
using StudentUnion0105.Models;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly SuDbContext _context;

        public UserController(UserManager<SuUserModel> userManager, SignInManager<SuUserModel> signInManager, SuDbContext Context)
        {
            this.userManager = userManager;
            SignInManager = signInManager;
            _context = Context;
        }

        public SignInManager<SuUserModel> SignInManager { get; }

        public async Task<IActionResult> Index()
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var AllUsers = await userManager.Users.ToListAsync();
            List<SuObjectVM> UserList = new List<SuObjectVM>();
            foreach(var a in AllUsers)
                {
            UserList.Add(new SuObjectVM
                {
                    Description2 = a.Id
                             ,
                    Name = a.UserName
                    , Description = a.Email
                });
            }

            return View(UserList);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var UserFromDb = await userManager.FindByIdAsync(Id);
            CreateUserViewModel UserToForm = new CreateUserViewModel
            {
                Id = UserFromDb.Id,
                UserName = UserFromDb.UserName,
                Email = UserFromDb.Email,
                DefaultLanguageId = UserFromDb.DefaultLanguageId,
                CountryId = UserFromDb.CountryId
            };

            var LanguageList = new List<SelectListItem>();
            var LanguagesFromDb = _context.ZDbLanguageList.FromSql("LanguageSelectAll").ToList();
            foreach (var LanguageFromDb in LanguagesFromDb)
            {
                LanguageList.Add(new SelectListItem
                {
                    Text = LanguageFromDb.Name,
                    Value = LanguageFromDb.Id.ToString()
                });
            }

            var CountryList = new List<SelectListItem>();
            var CountriesFromDb = _context.DbCountryList.FromSql("CountrySelectAll").ToList();
            foreach (var CountryFromDb in CountriesFromDb)
            {
                CountryList.Add(new SelectListItem
                {
                    Text = CountryFromDb.Name,
                    Value = CountryFromDb.Id.ToString()
                });
            }
         
            SuUserAndLists UserAndLists = new SuUserAndLists { User = UserToForm, Countries = CountryList , Languages= LanguageList };

                        return View(UserAndLists);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuUserAndLists FromForm)
        {
           // SuUserModel UpdateUser = new SuUserModel();
            var UserFromDb = await userManager.FindByIdAsync(FromForm.User.Id);

            UserFromDb.Email = FromForm.User.Email;
            UserFromDb.NormalizedEmail = FromForm.User.Email.ToUpper();
            UserFromDb.UserName = FromForm.User.UserName;
            UserFromDb.NormalizedUserName = FromForm.User.UserName.ToUpper();
            UserFromDb.DefaultLanguageId = FromForm.User.DefaultLanguageId;
            UserFromDb.CountryId = FromForm.User.CountryId;
            //  FromForm.User.SecurityStamp = UserFromDb;
            await userManager.UpdateAsync(UserFromDb);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var LanguageList = new List<SelectListItem>();
            var LanguagesFromDb = _context.ZDbLanguageList.FromSql("LanguageSelectAll").ToList();
            foreach (var LanguageFromDb in LanguagesFromDb)
            {
                LanguageList.Add(new SelectListItem
                {
                    Text = LanguageFromDb.Name,
                    Value = LanguageFromDb.Id.ToString()
                });
            }

            var CountryList = new List<SelectListItem>();
            var CountriesFromDb = _context.DbCountryList.FromSql("CountrySelectAll").ToList();
            foreach (var CountryFromDb in CountriesFromDb)
            {
                CountryList.Add(new SelectListItem
                {
                    Text = CountryFromDb.Name,
                    Value = CountryFromDb.Id.ToString()
                });
            }
            CreateUserViewModel UserToForm = new CreateUserViewModel();
            SuUserAndLists UserAndLists = new SuUserAndLists { User = UserToForm, Countries = CountryList, Languages = LanguageList };

            return View(UserAndLists);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuUserAndLists FromForm)
        {
            // SuUserModel UpdateUser = new SuUserModel();
            SuUserModel NewUser = new SuUserModel { Email = FromForm.User.Email, UserName = FromForm.User.UserName, DefaultLanguageId = FromForm.User.DefaultLanguageId, CountryId = FromForm.User.CountryId};

            NewUser.Email = FromForm.User.Email;
            NewUser.UserName = FromForm.User.UserName;
            NewUser.NormalizedEmail= FromForm.User.Email.ToUpper();
            NewUser.NormalizedUserName = FromForm.User.UserName.ToUpper();
            NewUser.DefaultLanguageId = FromForm.User.DefaultLanguageId;
            NewUser.CountryId = FromForm.User.CountryId;
            NewUser.SecurityLevel = 5;
            await userManager.CreateAsync(NewUser, FromForm.User.Password);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new SuUserModel { UserName = registerViewModel.Email, Email = registerViewModel.Email };
                var result = await userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(registerViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Logout()
        {

            await SignInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "FrontPage");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt");

            }

            return View(loginViewModel);
        }

    }
}
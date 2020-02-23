using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    [Authorize("Classification")]
    public class PreferenceController : PortalController
    {

        private readonly SuDbContext _context;

        public PreferenceController(UserManager<SuUserModel> userManager
                                                , ILanguageRepository language
                                                , SuDbContext context
            ) : base(userManager, language)
        {
            _context = context;
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


            var parameter = new SqlParameter("@Id", CurrentUser.Id);

            SuPreferenceIndexGetModel preference = _context.ZdbPreferenceIndexGet.FromSql("PreferenceIndexGet @Id", parameter).First();
            SuPreferenceIndexGetWithListsModel preferenceWithList = new SuPreferenceIndexGetWithListsModel
            {
                Preference = preference
            };
            List<SuCountryList> countryList = _context.ZDbCountryList.FromSql("CountrySelectAll").ToList();
            List<SuLanguageList> languageList = _context.ZDbLanguageList.FromSql("LanguageSelectActive").ToList();
            List<SelectListItem> countries = new List<SelectListItem>();
            List<SelectListItem> languages = new List<SelectListItem>();
            foreach (var countryitem in countryList)
            {
                countries.Add(new SelectListItem(countryitem.Name, countryitem.Id.ToString()));
            }
            preferenceWithList.Countries = countries;
            foreach (var Languageitem in languageList)
            {
                languages.Add(new SelectListItem(Languageitem.Name, Languageitem.Id.ToString()));
            }
            preferenceWithList.Languages = languages;
            return View(preferenceWithList);
        }
        [HttpPost]
        public IActionResult Index(SuPreferenceIndexGetWithListsModel FromForm)
        {
            SqlParameter[] parameters =
                    {
                    new SqlParameter("@UserId", FromForm.Preference.Id),
                    new SqlParameter("@LanguageId", FromForm.Preference.DefaultLanguageId),
                    new SqlParameter("@CountryId", FromForm.Preference.CountryId)
                    };
            _context.Database.ExecuteSqlCommand("PreferenceIndexPost " +
                        "@UserId" +
                        ", @LanguageId" +
                        ", @CountryId" , parameters);
            return RedirectToAction("Index", "Home");
    }
    [HttpGet]
    public async Task<IActionResult> LeftMenu()
    {
        var CurrentUser = await _userManager.GetUserAsync(User);
        
        var UICustomizationArray = new UICustomization(_context);
        ViewBag.Terms = await  UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), CurrentUser.DefaultLanguageId);

        var parameter = new SqlParameter("@CurrentUser", CurrentUser.Id);

            List<SuPreferenceLeftMenuGetModel> CurrentLeftMenu = _context.ZdbPreferenceLeftMenuGet.FromSql("PreferenceLeftMenuGet @CurrentUser", parameter).ToList();
           // List<SuPreferenceLeftMenuGetAvailableMenusModel> AvailableLeftMenu = _context.ZdbPreferenceLeftMenuGetAvailableMenus.FromSql("PreferenceLeftMenuGetAvailableMenus @CurrentUser", parameter).ToList();

//            SuPreferenceLeftMenuGetBothMenusModel BothMenus = new SuPreferenceLeftMenuGetBothMenusModel();
  //          BothMenus.AvailableMenus = AvailableLeftMenu;
        //    BothMenus.CurrentMenus = CurrentLeftMenu;

        return View(CurrentLeftMenu);
    }

        [HttpGet]
        public async Task<IActionResult> LeftMenuEdit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@Id", Id),
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    };

            SqlParameter[] parameters2 =
                {
                    new SqlParameter("@CurrentUser", CurrentUser.Id),
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    };

            SuPreferenceLeftMenuEditGetModel MenuEditGet = _context.ZdbPreferenceLeftMenuEditGet.FromSql("PreferenceLeftMenuEditGet @Id, @LanguageId", parameters).First();
            List<SuTypeList> OtherMenus = _context.ZDbTypeList.FromSql("PreferenceLeftMenuEditGetOtherMenus @CurrentUser, @LanguageId", parameters2).ToList();

            var MenuList = new List<SelectListItem>();
            foreach (var OtherMenu in OtherMenus)
            {
                MenuList.Add(new SelectListItem
                {
                    Text = OtherMenu.Name,
                    Value = OtherMenu.Id.ToString()
                });
            }
            SuPreferenceLeftMenuEditGetModelWithList MenuWithList = new SuPreferenceLeftMenuEditGetModelWithList
            {
                MenuEdit = MenuEditGet,
                OtherMenus = MenuList
            };

            return View(MenuWithList);
        }

        [HttpPost]
        public async Task<IActionResult> LeftMenuEdit(SuPreferenceLeftMenuEditGetModelWithList FromForm)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
    
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.MenuEdit.UserMenuId),
                    new SqlParameter("@MenuShow", FromForm.MenuEdit.MenuShow),
                    new SqlParameter("@MenuAddShow", FromForm.MenuEdit.MenuAddShow),
                    new SqlParameter("@SearchShow", FromForm.MenuEdit.SearchShow),
                    new SqlParameter("@AdvancedSearchShow", FromForm.MenuEdit.AdvancedSearchShow),
                    new SqlParameter("@MenuName", FromForm.MenuEdit.MenuName ?? ""),
                    new SqlParameter("@MenuURL", FromForm.MenuEdit.MenuURL ?? ""),
                    new SqlParameter("@Sequence", FromForm.MenuEdit.Sequence) ,
                    new SqlParameter("@UserId", CurrentUser.Id ) //,
                    };
                _context.Database.ExecuteSqlCommand("PreferenceLeftMenuEditPost " +
                            "@Id" +
                            ", @MenuShow" +
                            ", @MenuAddShow" +
                            ", @SearchShow" +
                            ", @AdvancedSearchShow" +
                            ", @MenuName" +
                            ", @MenuURL" +
                            ", @Sequence" +
                            ", @UserId" , parameters);
            }
            return RedirectToAction("LeftMenu");
        }


        [HttpGet]
        public async Task<IActionResult> LeftMenuCreate()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


            var parameter = new SqlParameter("@CurrentUser", CurrentUser.Id);

            List<SuTypeList> AvailableMenus = _context.ZDbTypeList.FromSql("PreferenceLeftMenuCreateGetAvailableMenus @CurrentUser", parameter).ToList();
if(AvailableMenus.Count()==0)
            {
                return RedirectToAction("LeftMenu");
            }
            var AvailableMenuList = new List<SelectListItem>();
            foreach (var AvailableMenu in AvailableMenus)
            {
                AvailableMenuList.Add(new SelectListItem
                {
                    Text = AvailableMenu.Name,
                    Value = AvailableMenu.Id.ToString()
                });
            }
            List<SuStatusList> ExistingMenus = _context.ZDbStatusList.FromSql("PreferenceLeftMenuCreateGetExistingMenus @CurrentUser", parameter).ToList();

            var ExistingMenuList = new List<SelectListItem>();
            var maxlevel = 0;
            foreach (var ExistingMenu in ExistingMenus)
            {
                if (maxlevel < ExistingMenu.Id)
                { maxlevel = ExistingMenu.Id; }
                ExistingMenuList.Add(new SelectListItem
                {
                    Text = ExistingMenu.Name,
                    Value = ExistingMenu.Id.ToString()
                });
                maxlevel++;
            }
            ExistingMenuList.Add(new SelectListItem { Text = "add at bottom", Value = maxlevel.ToString() });


            SuPreferenceLeftMenuCreateGetModel BothMenuLists = new SuPreferenceLeftMenuCreateGetModel();
            BothMenuLists.AvailableMenus = AvailableMenuList;
            BothMenuLists.ExistingMenus = ExistingMenuList;

            return View(BothMenuLists);
        }

        [HttpPost]
        public async Task<IActionResult> LeftMenuCreate(SuPreferenceLeftMenuCreateGetModel FromForm)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);

            SqlParameter[] parameters =
                    {
                    new SqlParameter("@LeftMenuId", FromForm.CreateMenuUser.LeftMenuId),
                    new SqlParameter("@MenuShow", FromForm.CreateMenuUser.MenuShow),
                    new SqlParameter("@MenuAddShow", FromForm.CreateMenuUser.MenuAddShow),
                    new SqlParameter("@SearchShow", FromForm.CreateMenuUser.SearchShow),
                    new SqlParameter("@AdvancedSearchShow", FromForm.CreateMenuUser.AdvancedSearchShow),
                    new SqlParameter("@MenuName", FromForm.CreateMenuUser.MenuName ?? ""),
                    new SqlParameter("@MenuURL", FromForm.CreateMenuUser.MenuURL ?? ""),
                    new SqlParameter("@Sequence", FromForm.CreateMenuUser.Sequence),
                    new SqlParameter("@UserId",CurrentUser.Id ),
                    };
                _context.Database.ExecuteSqlCommand("PreferenceLeftMenuCreatePost " +
                            "@LeftMenuId" +
                            ", @MenuShow" +
                            ", @MenuAddShow" +
                            ", @SearchShow" +
                            ", @AdvancedSearchShow" +
                            ", @MenuName" +
                            ", @MenuURL" +
                            ", @Sequence" +
                            ", @UserId", parameters);
            
            return RedirectToAction("LeftMenu");
        }
    }
}

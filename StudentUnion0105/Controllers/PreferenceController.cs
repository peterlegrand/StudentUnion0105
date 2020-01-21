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
    public class PreferenceController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;


        public PreferenceController(UserManager<SuUserModel> userManager
                                                , ILanguageRepository language
                                                , SuDbContext context
            )
        {
            this.userManager = userManager;
            _language = language;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@Id", CurrentUser.Id);

            SuPreferenceIndexGetModel preference = _context.ZdbPreferenceIndexGet.FromSql("PreferenceIndexGet @Id", parameter).First();
            SuPreferenceIndexGetWithListsModel preferenceWithList = new SuPreferenceIndexGetWithListsModel
            {
                Preference = preference
            };
            List<SuCountryList> countryList = _context.DbCountryList.FromSql("CountrySelectAll").ToList();
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
            var b = _context.Database.ExecuteSqlCommand("PreferenceIndexPost " +
                        "@UserId" +
                        ", @LanguageId" +
                        ", @CountryId" , parameters);
            return RedirectToAction("Index", "Home");
    }
    [HttpGet]
    public async Task<IActionResult> LeftMenu()
    {
        var CurrentUser = await userManager.GetUserAsync(User);
        var DefaultLanguageID = CurrentUser.DefaultLanguageId;

        var UICustomizationArray = new UICustomization(_context);
        ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

        var parameter = new SqlParameter("@CurrentUser", CurrentUser.Id);

            List<SuPreferenceLeftMenuGetModel> CurrentLeftMenu = _context.ZdbPreferenceLeftMenuGet.FromSql("PreferenceLeftMenuGet @CurrentUser", parameter).ToList();
            List<SuPreferenceLeftMenuGetAvailableMenusModel> AvailableLeftMenu = _context.ZdbPreferenceLeftMenuGetAvailableMenus.FromSql("PreferenceLeftMenuGetAvailableMenus @CurrentUser", parameter).ToList();

            SuPreferenceLeftMenuGetBothMenusModel BothMenus = new SuPreferenceLeftMenuGetBothMenusModel();
            BothMenus.AvailableMenus = AvailableLeftMenu;
            BothMenus.CurrentMenus = CurrentLeftMenu;

        return View(BothMenus);
    }
}
}

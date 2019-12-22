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
//    [Authorize("Classification")]
    public class FrontProcessTodoController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IClassificationStatusRepository _classificationStatus;
        private readonly IClassificationRepository _classification;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;


        public FrontProcessTodoController(UserManager<SuUserModel> userManager
                                                , IClassificationStatusRepository classificationStatus
                                                , IClassificationRepository classification
                                                , IClassificationLanguageRepository classificationLanguage
                                                , ILanguageRepository language
                                                , SuDbContext context
            )
        {
            this.userManager = userManager;
            _classificationStatus = classificationStatus;
            _classification = classification;
            _classificationLanguage = classificationLanguage;
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

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@CurrentUser", CurrentUser.Id)
                };

            var ToDo = _context.ZdbSuFrontProcessTodoIndexGet.FromSql("FrontProcessToDoIndexGet @LanguageId, @CurrentUser", parameters).ToList();
            return View(ToDo);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@PId",Id)
                };

            List< SuFrontProcessTodoEditGetModel> ToDo = _context.ZdbSuFrontProcessTodoEditGet.FromSql("FrontProcessToDoEditGet @LanguageId, @PId", parameters).ToList();

            return View(ToDo);
        }

        public ActionResult CountryDD()
        {
            var CountryList = new List<SelectListItem>();

            var CountriesFromDb = _context.ZDbStatusList.FromSql("CountryDD").ToList();


            foreach (var CountryFromDb in CountriesFromDb)
            {
                CountryList.Add(new SelectListItem
                {
                    Text = CountryFromDb.Name,
                    Value = CountryFromDb.Id.ToString()
                });
            }
            return View();

        }

    }
}

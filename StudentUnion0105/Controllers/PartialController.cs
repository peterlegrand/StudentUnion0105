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
using Syncfusion.EJ2.Navigations;

namespace StudentUnion0105.Controllers
{

    public class PartialController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IClassificationStatusRepository _classificationStatus;
        private readonly IClassificationRepository _classification;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;


        public PartialController(UserManager<SuUserModel> userManager
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

   
        public async Task<IActionResult> Menu()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var parameter = new SqlParameter("@LanguageId", DefaultLanguageID);

            var Menu1 = _context.ZdbMenu1.FromSql("Menu1 @LanguageId", parameter).ToList();
            var Menu2 = _context.ZdbMenu2.FromSql("Menu2 @LanguageId", parameter).ToList();
            var Menu3 = _context.ZdbMenu3.FromSql("Menu3 @LanguageId", parameter).ToList();
                foreach (var item2 in Menu2)
                {
                    foreach (var item3 in Menu3)
                    {
                        if (item2.OId == item3.PId)
                        {
                            item2.Menu3.Add(item3);
                        }
                    }
                }
            foreach (var item1 in Menu1)
            {
                foreach (var item2 in Menu2)
                {
                    if (item1.Id == item2.PId)
                    {
                        item1.Menu2.Add(item2);
                    }
                }
            }           

            return PartialView(Menu1);
        }
        //public static List<Menu1> GetLocalData()
        public ActionResult RetrieveMenu()
        {

            // For MenuFieldSettings type, include Syncfusion.EJ2.Navigations in the using directive section.
            MenuFieldSettings menuFields = new MenuFieldSettings()
            {
                Text = new string[] { "Menu1", "Menu2", "Menu3" },
                Children = new string[] { "Menus2", "Menus3" }
            };
            // Assign Local data from Model to ViewBag.menuItems
            //ViewBag.menuItems = Model.GetLocalData();
            ViewBag.menuFields = menuFields;
            return View();
        }
    }
}


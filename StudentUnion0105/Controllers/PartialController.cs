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

    public class PartialController : PortalController
    {
        private readonly IClassificationStatusRepository _classificationStatus;
        private readonly IClassificationRepository _classification;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly SuDbContext _context;


        public PartialController(UserManager<SuUserModel> userManager
                                                , IClassificationStatusRepository classificationStatus
                                                , IClassificationRepository classification
                                                , IClassificationLanguageRepository classificationLanguage
                                                , ILanguageRepository language
                                                , SuDbContext context
            ) : base(userManager, language)
        {
            _classificationStatus = classificationStatus;
            _classification = classification;
            _classificationLanguage = classificationLanguage;
            _context = context;
        }


        public async Task<IActionResult> Menu()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);


            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);

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


        public async Task<IActionResult> LeftMenu()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            var parameter = new SqlParameter("@CurrentUserId", CurrentUser.Id);

            var LeftMenu = _context.ZdbLeftMenu.FromSql("PartialLeftMenu @CurrentUserId", parameter).ToList();


            return PartialView(LeftMenu);
        }

        public async Task<IActionResult> TopMenu()
        {

            var CurrentUser = await _userManager.GetUserAsync(User);



            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);

            var TopMenu1List = _context.ZdbTopMenu1.FromSql("PartialTopMenu1 @LanguageId", parameter).ToList();


            List<MenuItem> menuItem1List = new List<MenuItem>();
            foreach (var TopMenu1 in TopMenu1List)
            {
                menuItem1List.Add(new MenuItem
                {
                    Text = TopMenu1.MenuName,
                    IconCss = TopMenu1.IconCss,
                    Url = TopMenu1.MenuController,
                    Items = new List<MenuItem>()
                {
                    new MenuItem { Text= "Open", IconCss= "em-icons e-open", Url= "Home/Open" },
                    new MenuItem { Text= "Save", IconCss= "e-icons e-save", Url= "Home/Save" },
                    new MenuItem { Separator= true },
                    new MenuItem { Text= "Exit", Url= "Home/Exit" }
                }
                });



            }
            ViewBag.menuItems2 = menuItem1List;
            return PartialView();
        }
    }
}

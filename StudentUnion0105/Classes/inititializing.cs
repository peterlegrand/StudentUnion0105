using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.EJ2.Navigations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace StudentUnion0105.Classes
{
    public class MenusEtc : Controller
    {
        private readonly SuDbContext _context;
                protected readonly UserManager<SuUserModel> _userManager;

        public MenusEtc(UserManager<SuUserModel> userManager,SuDbContext context)
        {
            _context = context;
                    _userManager = userManager;
}

        public async void Initializing()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = a.TopMenu(DefaultLanguageID);
            return;
        }
    }
}

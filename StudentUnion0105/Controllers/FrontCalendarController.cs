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
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
//    [Authorize("Classification")]
    public class FrontCalendarController : PortalController
    {
        private readonly SuDbContext _context;

        public FrontCalendarController(UserManager<SuUserModel> userManager
                                                , ILanguageRepository language
                                                , SuDbContext context
            ) : base(userManager, language)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> EventCalendar()
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus x = new Menus(_context);
            ViewBag.menuItems = await x.TopMenu(DefaultLanguageID);


            SqlParameter[] parameters =
                {
                    new SqlParameter("@Month",DateTime.Now.Month )
                    , new SqlParameter("@Year",DateTime.Now.Year )
                };

            SuFrontCalendarEventCalendarModelWithAdditionalInfo FrontCalendarWithInfo = new SuFrontCalendarEventCalendarModelWithAdditionalInfo();

            List<SuFrontCalendarEventCalendarModel> FrontCalendar = _context.ZdbFrontCalendarEventCalendar.FromSql("FrontCalendarEventCalendarGet @Month, @Year", parameters).ToList();


            FrontCalendarWithInfo.Events = FrontCalendar;
            FrontCalendarWithInfo.Month = DateTime.Now.Month;
            FrontCalendarWithInfo.MonthName = DateTime.Now.ToString("MMM", CultureInfo.InvariantCulture);
            FrontCalendarWithInfo.Year = DateTime.Now.Year;
            DateTime FirstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            FrontCalendarWithInfo.StartDay = (int)FirstDay.DayOfWeek;
            FrontCalendarWithInfo.EndDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);



            return View(FrontCalendarWithInfo);
        }
        [HttpGet]
        public async Task<IActionResult> MyCalendar()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);
            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);



            SqlParameter[] parameters =
                {
                    new SqlParameter("@CurrentUser",CurrentUser.Id )
                    , new SqlParameter("@Month",DateTime.Now.Month )
                    , new SqlParameter("@Year",DateTime.Now.Year )
                };

            SuFrontCalendarEventCalendarModelWithAdditionalInfo FrontCalendarWithInfo = new SuFrontCalendarEventCalendarModelWithAdditionalInfo();

            List<SuFrontCalendarEventCalendarModel> FrontCalendar = _context.ZdbFrontCalendarEventCalendar.FromSql("FrontCalendarMyCalendarGet @CurrentUser, @Month, @Year", parameters).ToList();


            FrontCalendarWithInfo.Events = FrontCalendar;
            FrontCalendarWithInfo.Month = DateTime.Now.Month;
            FrontCalendarWithInfo.MonthName = DateTime.Now.ToString("MMM", CultureInfo.InvariantCulture);
            FrontCalendarWithInfo.Year = DateTime.Now.Year;
            DateTime FirstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            FrontCalendarWithInfo.StartDay = (int)FirstDay.DayOfWeek;
            FrontCalendarWithInfo.EndDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
//            int DayOfTheMonth = 1;



            return View(FrontCalendarWithInfo);
        }
    }
}

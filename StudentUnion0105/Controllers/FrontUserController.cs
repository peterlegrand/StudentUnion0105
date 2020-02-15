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
    public class FrontUserController : PortalController
    {
        private readonly SuDbContext _context;

        public FrontUserController(UserManager<SuUserModel> userManager
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

            List<SuFrontUserIndexGetModel> UserList = _context.ZdbFrontUserIndexGet.FromSql("FrontUserIndexGet").ToList();

            return View(UserList);
        }
        [HttpGet]
        public async Task<IActionResult> UserDashboard(string Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);
            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


            var parameter = new SqlParameter("@UserId", Id);

            SuFrontUserIndexGetModel UserDetail = _context.ZdbFrontUserIndexGet.FromSql("FrontUserUserDashboardGet @UserId" , parameter).First();


            SqlParameter[] parameters =
                {
                    new SqlParameter("@User", Id)
                    , new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                };

            List<SuObjectIndexGetModel> UserProjectFromDb = _context.ZdbObjectIndexGet.FromSql("UserProjectSelectAll @User, @LanguageId", parameters).ToList();

            List<SuObjectIndexGetModel2> UserOrganizationFromDb = _context.ZdbObjectIndexGet2.FromSql("UserOrganizationSelectAll @User, @LanguageId", parameters).ToList();
            List<SuFrontUserUserDashboardGetRelationModel> UserRelationFromDb = _context.ZdbSuFrontUserUserDashboardGetRelation.FromSql("UserRelationSelectAll @User, @LanguageId", parameters).ToList();


            SuFrontUserUserDashboardGetModel UserWithList = new SuFrontUserUserDashboardGetModel();
            UserWithList.User = UserDetail;
            UserWithList.Projects = UserProjectFromDb;
            UserWithList.Organizations = UserOrganizationFromDb;
            UserWithList.Relations = UserRelationFromDb;
            return View(UserWithList);
        }


    }
}

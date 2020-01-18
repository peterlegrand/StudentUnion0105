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
    public class FrontOrganizationController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;


        public FrontOrganizationController(UserManager<SuUserModel> userManager
                                                , ILanguageRepository language
                                                , SuDbContext context
            )
        {
            this.userManager = userManager;
            _language = language;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> MyOrganization()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameterPage = new SqlParameter("@CurrentUser", CurrentUser.Id);


            List<SuFrontOrganizationMyOrganizationGetModel> FrontOrganizationMyOrganization = _context.ZdbFrontOrganizationMyOrganizationGet.FromSql("FrontOrganizationMyOrganizationGet @CurrentUser", parameterPage).ToList();

            return View(FrontOrganizationMyOrganization);
        }
        [HttpGet]
        public async Task<IActionResult> Dashboard(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@OrganizationId", Id)
                    , new SqlParameter("@LanguageId", DefaultLanguageID)
                };
            SqlParameter[] parametersContent =
                {
                    new SqlParameter("@OrganizationId", Id)
                    , new SqlParameter("@CurrentUser", CurrentUser.Id)
                };


            SuFrontOrganizationDashboardGetOrganizationModel FrontOrganizationDashboardGetOrganization = _context.ZdbFrontOrganizationDashboardGetOrganization.FromSql("FrontOrganizationDashboardGetOrganization @OrganizationId, @LanguageId", parameters).First();

            List<SuFrontOrganizationDashboardGetContentModel> FrontOrganizationDashboardGetContent = _context.ZdbFrontOrganizationDashboardGetContent.FromSql("FrontOrganizationDashboardGetContent @OrganizationId, @CurrentUser", parametersContent).ToList();
            List<SuFrontOrganizationDashboardGetUsersModel> FrontOrganizationDashboardGetUsers = _context.ZdbFrontOrganizationDashboardGetUsers.FromSql("FrontOrganizationDashboardGetUsers @OrganizationId, @LanguageId", parameters).ToList();

            SuFrontOrganizationDashboardGetModel OrganizationDashboard = new SuFrontOrganizationDashboardGetModel();
            OrganizationDashboard.Organization = FrontOrganizationDashboardGetOrganization;
            OrganizationDashboard.Content = FrontOrganizationDashboardGetContent;
            OrganizationDashboard.Users = FrontOrganizationDashboardGetUsers;
            return View(OrganizationDashboard);
        }


    }
}

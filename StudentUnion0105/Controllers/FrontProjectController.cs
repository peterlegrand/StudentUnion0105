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
    public class FrontProjectController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;


        public FrontProjectController(UserManager<SuUserModel> userManager
                                                , ILanguageRepository language
                                                , SuDbContext context
            )
        {
            this.userManager = userManager;
            _language = language;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> MyProject()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameterPage = new SqlParameter("@CurrentUser", CurrentUser.Id);


            List<SuFrontProjectMyFrontProjectGetModel> FrontProjectMyFrontProject = _context.ZdbFrontProjectMyProjectGet.FromSql("FrontProjectMyProjectGet @CurrentUser", parameterPage).ToList();

            return View(FrontProjectMyFrontProject);
        }


    }
}

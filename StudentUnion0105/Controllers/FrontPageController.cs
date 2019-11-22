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
    public class FrontPageController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IClassificationStatusRepository _classificationStatus;
        private readonly IClassificationRepository _classification;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;


        public FrontPageController(UserManager<SuUserModel> userManager
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

            var parameterPage = new SqlParameter("@LanguageId", DefaultLanguageID);


            SuFrontPageModel FrontPage = _context.ZdbFrontPage.FromSql("FrontPageGetPage @LanguageId", parameterPage).First();


            List<SuFrontPageSectionModel> FrontPageSections = _context.ZdbFrontPageSection.FromSql("FrontPageGetPageSection @LanguageId", parameterPage).ToList();
            FrontPage.FrontPageSections = FrontPageSections;
            //int NoOfSections = FrontPage.FrontPageSections.Count();
            //int i = 0;
            //while(i<NoOfSections)
            //{ 
                foreach( var SingleSection in FrontPage.FrontPageSections)
            { 
            SqlParameter[] parameterContent =
                {
                    new SqlParameter("@LanguageId", DefaultLanguageID.ToString())
                    , new SqlParameter("@PageSectionId", SingleSection.OId.ToString())
                    , new SqlParameter("@SecurityLevel", CurrentUser.SecurityLevel.ToString())
                    , new SqlParameter("@PagingId", "0")
                };
                List<SuFrontContentModel> FrontContent = 
                        _context.ZdbFrontContent.FromSql("FrontPageGetContent " +
                        "@LanguageId" +
                        ", @PageSectionId" +
                        ", @SecurityLevel" +
                        ", @PagingId"
                        , parameterContent).ToList();
                SingleSection.FrontContent = FrontContent;
 //               i++;
            }
            return View(FrontPage);
        }

    }
}

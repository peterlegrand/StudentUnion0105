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
    [AllowAnonymous]
    public class ExternalPageController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IClassificationStatusRepository _classificationStatus;
        private readonly IClassificationRepository _classification;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;


        public ExternalPageController(UserManager<SuUserModel> userManager
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
        public  IActionResult Index()
        {
            SuExternalPageModel ExternalPage = _context.ZdbExternalPage.FromSql("ExternalPageGetPage").First();


            List<SuExternalPageSectionModel> ExternalPageSections = _context.ZdbExternalPageSection.FromSql("ExternalPageGetPageSection").ToList();
            ExternalPage.ExternalPageSections = ExternalPageSections;

            foreach( var SingleSection in ExternalPage.ExternalPageSections)
            { 
            SqlParameter[] parameterContent =
                {
                    new SqlParameter("@PageSectionId", SingleSection.OId.ToString())
                    , new SqlParameter("@PagingId", "0")
                };
                List<SuExternalContentModel> ExternalContent = 
                        _context.ZdbExternalContent.FromSql("ExternalPageGetContent " +
                        " @PageSectionId" +
                        ", @PagingId"
                        , parameterContent).ToList();
                SingleSection.ExternalContent = ExternalContent;
 //               i++;
            }
            return View(ExternalPage);
        }
        public IActionResult View(int Id)
        {

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), 41);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", 41)
                    , new SqlParameter("@Id", Id)
                };

            var ExternalPageContent = _context.ZdbExternalPageViewGet.FromSql("ExternalPageViewGet @LanguageId, @Id", parameters).First();

            return View(ExternalPageContent);
        }
 


    }
}

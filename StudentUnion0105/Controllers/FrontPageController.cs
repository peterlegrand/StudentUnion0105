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
    public class FrontPageController : PortalController
    {
        public FrontPageController(UserManager<SuUserModel> userManager
                                                , ILanguageRepository language
                                                , SuDbContext context
            ) : base (userManager, language, context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            
            base.Initializing();

            var parameterPage = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);


            SuFrontPageModel FrontPage = _context.ZdbFrontPage.FromSql("FrontPageGetPage @LanguageId", parameterPage).First();


            List<SuFrontPageSectionModel> FrontPageSections = _context.ZdbFrontPageSection.FromSql("FrontPageGetPageSection @LanguageId", parameterPage).ToList();
            FrontPage.FrontPageSections = FrontPageSections;

            foreach( var SingleSection in FrontPage.FrontPageSections)
            { 
            SqlParameter[] parameterContent =
                {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@PageSectionId", SingleSection.OId)
                    , new SqlParameter("@SecurityLevel", CurrentUser.SecurityLevel)
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

            }
            return View(FrontPage);
        }

        public async Task<IActionResult> View(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);

            base.Initializing();

            SqlParameter[] parameters =
                {
                    new SqlParameter("@Id", Id)
                    , new SqlParameter("@CurrentUser", CurrentUser.Id)
                };

            var FrontPageContent = _context.ZdbFrontPageViewGet.FromSql("FrontPageViewGet @Id, @CurrentUser", parameters).First();
            var FrontPageContentClassificationValues = _context.ZdbSuFrontPageViewGetClassificationValues.FromSql("FrontPageViewGetClassificationValues @Id, @CurrentUser", parameters).ToList();

            SuFrontPageViewGetWithValuesModel ContentWithValues = new SuFrontPageViewGetWithValuesModel();

            ContentWithValues.Content = FrontPageContent;
            ContentWithValues.Values = FrontPageContentClassificationValues;
            return View(ContentWithValues);
        }
        [HttpGet]
        public async Task<IActionResult> MyContent()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);

            base.Initializing();
            var parameterPage = new SqlParameter("@CurrentUser", CurrentUser.Id);

            List< SuFrontPageMyContentGetModel> FrontPageMyContent = _context.ZdbFrontPageMyContentGet.FromSql("FrontPageMyContentGet @CurrentUser", parameterPage).ToList();
            
            return View(FrontPageMyContent);
        }


    }
}

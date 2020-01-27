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
    public class FrontContentController : PortalController
    {
        public FrontContentController(UserManager<SuUserModel> userManager
                                                , ILanguageRepository language
                                                , SuDbContext context
            ) : base (userManager, language, context)
        {
        }

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var CurrentUser = await _userManager.GetUserAsync(User);
            
        //    base.Initializing();

        //    var parameterContent = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);


        //    SuFrontContentModel FrontContent = _context.ZdbFrontContent.FromSql("FrontContentGetContent @LanguageId", parameterContent).First();


        //    List<SuFrontContentSectionModel> FrontContentSections = _context.ZdbFrontContentSection.FromSql("FrontContentGetContentSection @LanguageId", parameterContent).ToList();
        //    FrontContent.FrontContentSections = FrontContentSections;

        //    foreach( var SingleSection in FrontContent.FrontContentSections)
        //    { 
        //    SqlParameter[] parameterContent =
        //        {
        //            new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
        //            , new SqlParameter("@ContentSectionId", SingleSection.OId)
        //            , new SqlParameter("@SecurityLevel", CurrentUser.SecurityLevel)
        //            , new SqlParameter("@PagingId", "0")
        //        };
        //        List<SuFrontContentModel> FrontContent = 
        //                _context.ZdbFrontContent.FromSql("FrontContentGetContent " +
        //                "@LanguageId" +
        //                ", @ContentSectionId" +
        //                ", @SecurityLevel" +
        //                ", @PagingId"
        //                , parameterContent).ToList();
        //        SingleSection.FrontContent = FrontContent;

        //    }
        //    return View(FrontContent);
        //}

        //public async Task<IActionResult> View(int Id)
        //{
        //    var CurrentUser = await _userManager.GetUserAsync(User);

        //    base.Initializing();

        //    SqlParameter[] parameters =
        //        {
        //            new SqlParameter("@Id", Id)
        //            , new SqlParameter("@CurrentUser", CurrentUser.Id)
        //        };

        //    var FrontContentContent = _context.ZdbFrontContentViewGet.FromSql("FrontContentViewGet @Id, @CurrentUser", parameters).First();
        //    var FrontContentContentClassificationValues = _context.ZdbSuFrontContentViewGetClassificationValues.FromSql("FrontContentViewGetClassificationValues @Id, @CurrentUser", parameters).ToList();

        //    SuFrontContentViewGetWithValuesModel ContentWithValues = new SuFrontContentViewGetWithValuesModel();

        //    ContentWithValues.Content = FrontContentContent;
        //    ContentWithValues.Values = FrontContentContentClassificationValues;
        //    return View(ContentWithValues);
        //}
        //[HttpGet]
        //public async Task<IActionResult> MyContent()
        //{
        //    var CurrentUser = await _userManager.GetUserAsync(User);

        //    base.Initializing();
        //    var parameterContent = new SqlParameter("@CurrentUser", CurrentUser.Id);

        //    List< SuFrontContentMyContentGetModel> FrontContentMyContent = _context.ZdbFrontContentMyContentGet.FromSql("FrontContentMyContentGet @CurrentUser", parameterContent).ToList();
            
        //    return View(FrontContentMyContent);
        //}


    }
}

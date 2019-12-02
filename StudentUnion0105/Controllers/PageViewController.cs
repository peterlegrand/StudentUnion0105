using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class PageViewController : Controller
    {
        private readonly SuDbContext _context;
        private readonly UserManager<SuUserModel> userManager;

        public PageViewController(SuDbContext context
            , UserManager<SuUserModel> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            int Id = 2;

            SqlParameter[] parameters =
    {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@Id", Id)
                };

            var Sections = _context.DbPageSectionsViewModel.FromSql("ShowPageSection @LanguageId, @Id", parameters).ToList();
            int NoOfSections = Sections.Count();
            List<SuContentModel>[] Contents = new List<SuContentModel>[NoOfSections];
            int SectionCount = 0;
            foreach (var Section in Sections)
            {
                var parameter = new SqlParameter("@Id", Section.ContentTypeId);

                Contents[SectionCount] = _context.DbContent.FromSql("ShowContent @Id", parameter).ToList();
                SectionCount++;
            }
            SuPageViewModel ToForm = new SuPageViewModel { PageSections = Sections, ContentViews = Contents };
            return View(ToForm);
        }
    }
}
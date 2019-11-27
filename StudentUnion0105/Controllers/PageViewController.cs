using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using System.Collections.Generic;
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
            var Sections = _context.DbPageSectionsViewModel.FromSql($"ShowPageSection {Id}, {DefaultLanguageID}").ToList();
            int NoOfSections = Sections.Count();
            List<SuContentModel>[] Contents = new List<SuContentModel>[NoOfSections];
            int SectionCount = 0;
            foreach (var Section in Sections)
            {

                Contents[SectionCount] = _context.DbContent.FromSql($"ShowContent {Section.ContentTypeId}").ToList();
                SectionCount++;
            }
            SuPageViewModel ToForm = new SuPageViewModel { PageSections = Sections, ContentViews = Contents };
            return View(ToForm);
        }
    }
}
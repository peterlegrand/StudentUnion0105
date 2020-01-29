using StudentUnion0105.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Classes;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public LanguageController(
                                                 ILanguageRepository language                                                
                                                , SuDbContext context
)
        {
            _language = language;
            _context = context;
        }
        public IActionResult Index()
        {
            var AllLanguages = _language.GetAllLanguages();
            return View(AllLanguages);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var Language = _language.GetLanguage(Id);

            return View(Language);


        }


        [HttpPost]
        public IActionResult Edit(SuLanguageModel Language)
        {
            if (ModelState.IsValid)
            {

                _language.UpdateLanguage(Language);

            }
            return RedirectToAction("Index");



        }
    }
}
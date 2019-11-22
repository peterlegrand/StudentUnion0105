using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class LanguageController : Controller
    {
        private readonly UserManager<SuUserModel> _userManager;
        private readonly ILanguageRepository _language;

        public LanguageController(UserManager<SuUserModel> userManager
                                                , ILanguageRepository language)
        {
            _userManager = userManager;
            _language = language;
        }
        public IActionResult Index()
        {
            var AllLanguages = _language.GetAllLanguages();
            return View(AllLanguages);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var Language = _language.GetLanguage(Id);

            return View(Language);


        }


        [HttpPost]
        public async Task<IActionResult> Edit(SuLanguageModel Language)
        {
            if (ModelState.IsValid)
            {

                _language.UpdateLanguage(Language);

            }
            return RedirectToAction("Index");



        }
    }
}
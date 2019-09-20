using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;

namespace StudentUnion0105.Controllers
{
    public class LanguageController : Controller
    {
        private readonly UserManager<SuUser> _userManager;
        private readonly ILanguageRepository _language;

        public LanguageController(UserManager<SuUser> userManager
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
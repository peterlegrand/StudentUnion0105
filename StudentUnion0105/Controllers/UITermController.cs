using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{
    public class UITermController : Controller
    {
        private readonly IUITermRepository _uITerm;
        private readonly IUIScreenRepository _uIScreen;
        private readonly IUITermLanguageRepository _termLanguage;
        private readonly IUITermScreenRepository _termScreen;
        private readonly SuDbContext _context;

        public UITermController( IUITermRepository UITerm
                                , IUIScreenRepository UIScreen
                                , IUITermLanguageRepository TermLanguage
                                , IUITermScreenRepository TermScreen
                                , SuDbContext context)
        {
            _uITerm = UITerm;
            _uIScreen = UIScreen;
            _termLanguage = TermLanguage;
            _termScreen = TermScreen;
            _context = context;
        }
        public IActionResult Index()
        {
            //            var CurrentUser = await _userManager.GetUserAsync(User);
            //          var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var TermList = _context.DbStatusList.FromSql($"UITermSelectAll").ToList();

         //   var TermList = _uITerm.GetAllTerms();
                
            return View(TermList);
        }

        public IActionResult LanguageIndex(int Id)
        {

            var TermLanguageList = _context.DbIdWithStrings.FromSql("UITermLanguagesSelectForOneTerm @p0",
                 parameters: new[] {             //0
                                        Id.ToString()
                    }).ToList();
            ViewBag.Id = Id;
            
            return View(TermLanguageList);
        }


        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var TermLanguage = _context.DbUITermLanguage.FromSql($"UITermLanguageSelectForUpdate @p0",
                 parameters: new[] {             //0
                                        Id.ToString()
                    }).First();

            return View(TermLanguage); //SuUITermLanguage


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuUITermLanguageModel FromForm)
        {
            if (ModelState.IsValid)
            {
                _context.Database.ExecuteSqlCommand($"UITermLanguageUpdate @P0, @P1",
                 parameters: new[] {             //0
                                       FromForm.Id.ToString()
                                       , FromForm.Customization
                    });
            }
            //            return  RedirectToRoute("EditRole" + "/"+FromForm.Classification.ClassificationId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = FromForm.TermId.ToString() });



        }



        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {

            var Languages = _context.DbStatusList.FromSql($"UITermLanguageSelectForCreate @p0",
                         parameters: new[] {             //0
                                        Id.ToString()
                    }).ToList();


            if (Languages.Count() == 0)
            {
                return RedirectToAction("LanguageIndex", new { Id = Id });
            }
            List<SelectListItem> LanguageList = new List<SelectListItem>();

            foreach(var x in Languages)
            {
                LanguageList.Add(new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            }
            SuObjectVM SuObject = new SuObjectVM();
            SuObject.ObjectId = Id;
            ViewBag.Id = Id.ToString();
            var ClassificationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = LanguageList
            };
            return View(ClassificationAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                //                var CurrentUser = await userManager.GetUserAsync(User);
                //                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                //               Guid guid = new Guid(CurrentUser.Id);
                 _context.Database.ExecuteSqlCommand($"UITermLanguageCreate @P0, @P1, @P2",
                 parameters: new[] {             //0
                                       FromForm.SuObject.ObjectId.ToString()
                                       , FromForm.SuObject.LanguageId.ToString()
                                       , FromForm.SuObject.Name
                    });



            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }
        [HttpGet]
        public IActionResult LanguageDelete(int Id)
        {
            var TermLanguage = _context.DbUITermLanguage.FromSql($"UITermLanguageSelectForUpdate @p0",
                parameters: new[] {             //0
                                        Id.ToString()
                   }).First();

            return View(TermLanguage); //SuUITermLanguage
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuUITermLanguageModel FromForm)
        {
            if (ModelState.IsValid)
            {

                _termLanguage.DeleteTermLanguage(FromForm.Id);
            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.TermId });

        }
    }
}
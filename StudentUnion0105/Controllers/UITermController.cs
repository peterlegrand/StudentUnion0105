using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
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
            var TermList = _context.ZDbStatusList.FromSql("UITermSelectAll").ToList();

         //   var TermList = _uITerm.GetAllTerms();
                
            return View(TermList);
        }

        public IActionResult LanguageIndex(int Id)
        {
            var parameter = new SqlParameter("@TermId", Id);

            var TermLanguageList = _context.DbIdWithStrings.FromSql("UITermLanguagesSelectForOneTerm @TermId", parameter).ToList();
            ViewBag.Id = Id;
            
            return View(TermLanguageList);
        }


        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var parameter = new SqlParameter("@Id", Id);
            SuUITermLanguageEditGetModel TermLanguage = _context.ZDbUITermLanguageEditGet.FromSql("UITermLanguageEditGet @Id", parameter).First();

            return View(TermLanguage); //SuUITermLanguage


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuUITermLanguageEditGetModel FromForm)
        {

            SqlParameter[] parameters =
    {
                    new SqlParameter("@Id", FromForm.Id)
                    , new SqlParameter("@Customization", FromForm.Customization)
                };

            _context.Database.ExecuteSqlCommand("UITermLanguageEditPost @Id, @Customization",
                 parameters);
            
     
            return RedirectToAction("LanguageIndex", new { Id = FromForm.TermId.ToString() });



        }



        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
            SqlParameter CountryList = new SqlParameter("@Id", Id);

            var Languages = _context.ZDbLanguageList.FromSql("UITermLanguageCreateGetLanguages @Id",
                         CountryList
                    ).ToList();


            if (Languages.Count() == 0)
            {
                return RedirectToAction("Index", new { Id });
            }
            List<SelectListItem> LanguageList = new List<SelectListItem>();

            foreach(var x in Languages)
            {
                LanguageList.Add(new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            }
            SuTermLanguageCreateGetModel TermLanguage = new SuTermLanguageCreateGetModel
            {
                Id = Id
            };
            ViewBag.Id = Id.ToString();
            var TermLanguageWithList = new SuTermLanguageCreateGetWithListModel
            {
                TermLanguage = TermLanguage
                ,
                LanguageList = LanguageList
            };
            return View(TermLanguageWithList);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuTermLanguageCreateGetWithListModel FromForm)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("@Id", FromForm.TermLanguage.Id)
                    , new SqlParameter("@LanguageId", FromForm.TermLanguage.LanguageId)
                    , new SqlParameter("@Customization", FromForm.TermLanguage.Customization)

                };

            _context.Database.ExecuteSqlCommand("UITermLanguageCreatePost @Id, @LanguageId, @Customization", parameters);


            return RedirectToAction("LanguageIndex", new { Id = FromForm.TermLanguage.Id.ToString() });
        }

        [HttpGet]
        public IActionResult LanguageDelete(int Id)
        {
            var parameter = new SqlParameter("@Id", Id);

            var TermLanguage = _context.DbUITermLanguage.FromSql("UITermLanguageSelectForUpdate @Id", parameter).First();

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
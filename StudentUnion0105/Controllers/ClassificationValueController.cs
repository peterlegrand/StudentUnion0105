using Microsoft.AspNetCore.Identity;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentUnion0105.Controllers
{
    public class ClassificationValueController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IClassificationValueRepository _classificationValue;
        private readonly IClassificationValueLanguageRepository _classificationValueLanguage;
        private readonly SuDbContext _context;
        private readonly IClassificationLevelRepository _classificationLevel;
        private readonly ILanguageRepository _language;

        public ClassificationValueController(UserManager<SuUser> userManager
            , IClassificationValueRepository classificationValue
            , IClassificationValueLanguageRepository classificationValueLanguage
           , SuDbContext context
            , IClassificationLevelRepository classificationLevel
            , ILanguageRepository language)
        {
            this.userManager = userManager;
            _classificationValue = classificationValue;
            _classificationValueLanguage = classificationValueLanguage;
            _context = context;
            _classificationLevel = classificationLevel;
            _language = language;
        }

        public async Task<IActionResult> Index(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;

            var checklevels = _classificationLevel.GetAllClassificationLevels();
            int MaxConfigLevel = 0;
            foreach (var z in checklevels)
            {
                if (z.Sequence > MaxConfigLevel && z.ClassificationId == Id)
                {
                    MaxConfigLevel = z.Sequence;
                }
            }

            var a = _context.dbGetClassificationValueStructure.FromSql($"ClassificationValueStructure {DefaultLanguageID}, {Id}").ToList(); 

            //if (a.Count != 0)
            //{
            int maxLevel = 0;
            foreach (var Value in a)
            {
                if (Value.Level > maxLevel)
                {
                    maxLevel = Value.Level;
                }
            }
            ViewBag.CId = Id.ToString();
            var c = new ValueStructureWithDepth { MaxLevel = maxLevel, ValueStructure = a, MaxConfigLevel = MaxConfigLevel };
            return View(c);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;

            SuObjectVM CValue = new SuObjectVM()
            {
                NullId = Id,
                ObjectId = Convert.ToInt32(HttpContext.Request.Query["CId"]),
            };
            if (Id == 0)
            {
                CValue.Level = 1;
            }
            else
            {
                var x = new SuClassificationValueModel();
                int? Parent = Id;
                while (Parent != null)
                {
                    CValue.Level++;

                    x = _classificationValue.GetClassificationValue(Parent ?? 0);
                    Parent = x.ParentValueId;

                }
            }

            var test1 = (from s in _classificationLevel.GetAllClassificationLevels()
                         where s.ClassificationId == Convert.ToInt32(HttpContext.Request.Query["CId"]) && s.Sequence == CValue.Level
                         select new SuObjectVM
                         {
                             DateLevel = s.DateLevel
                            ,
                             Alphabetically = s.Alphabetically
                            ,
                             InDropDown = s.InDropDown

                         }).First();
            CValue.DateLevel = test1.DateLevel;
            CValue.Alphabetically = test1.Alphabetically;
            CValue.InDropDown = test1.InDropDown;

            //            var x = _classificationLevel.get.ClassificationLevel()
            ViewBag.CId = HttpContext.Request.Query["CId"];
            return View(CValue);


        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var ClassificationValue = new SuClassificationValueModel();
                ClassificationValue.ModifiedDate = DateTime.Now;
                ClassificationValue.CreatedDate = DateTime.Now;
                ClassificationValue.ClassificationId = FromForm.ObjectId;

                if (FromForm.NullId != 0)
                { ClassificationValue.ParentValueId = FromForm.NullId; }
                var NewClassificationValue = _classificationValue.AddClassificationValue(ClassificationValue);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var ClassificationValueLanguage = new SuClassificationValueLanguageModel();

                ClassificationValueLanguage.ClassificationValueName = FromForm.Name;
                ClassificationValueLanguage.ClassificationValueDescription = FromForm.Description;
                ClassificationValueLanguage.ClassificationValueDropDownName = FromForm.DropDownName;
                ClassificationValueLanguage.ClassificationValueMenuName = FromForm.MenuName;
                ClassificationValueLanguage.ClassificationValueMouseOver = FromForm.MouseOver;
                ClassificationValueLanguage.ClassificationValuePageName = FromForm.PageName;
                ClassificationValueLanguage.ClassificationValuePageDescription = FromForm.PageDescription;
                ClassificationValueLanguage.ClassificationValueHeaderName = FromForm.HeaderName;
                ClassificationValueLanguage.ClassificationValueHeaderDescription = FromForm.HeaderDescription;
                ClassificationValueLanguage.ClassificationValueTopicName = FromForm.TopicName;

                ClassificationValueLanguage.ClassificationValueId = NewClassificationValue.Id;
                ClassificationValueLanguage.LanguageId = DefaultLanguageID;
                _classificationValueLanguage.AddClassificationValueLanguage(ClassificationValueLanguage);

            }
            return RedirectToAction("Index", new { Id = FromForm.ObjectId.ToString() });



        }
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;

            var ClassificationValue = (from v in _classificationValue.GetAllClassifcationValues()
                                       join l in _classificationValueLanguage.GetAllClassificationValueLanguages()
                                       on v.Id equals l.ClassificationValueId
                                       where l.LanguageId == DefaultLanguageID && v.Id == Id
                                       select new SuObjectVM
                                       {
                                           Name = l.ClassificationValueName
                          ,
                                           Description = l.ClassificationValueDescription
                          ,
                                           DropDownName = l.ClassificationValueDropDownName
                          ,
                                           MenuName = l.ClassificationValueMenuName
                          ,
                                           MouseOver = l.ClassificationValueMouseOver
                          ,
                                           PageName = l.ClassificationValuePageName
                          ,
                                           PageDescription = l.ClassificationValuePageDescription
                          ,
                                           HeaderName = l.ClassificationValueHeaderName
                          ,
                                           HeaderDescription = l.ClassificationValueHeaderDescription
                          ,
                                           TopicName = l.ClassificationValueTopicName
                          ,
                                           DateFrom = v.DateFrom
                          ,
                                           DateTo = v.DateTo
                          ,
                                           NullId = v.ParentValueId
                          ,
                                           ObjectId = v.Id
                          ,
                                           ObjectLanguageId = l.Id
                          ,
                                           Id = v.ClassificationId
                                       }).First();

            int Level = 1;
            var x = new SuClassificationValueModel();
            int? Parent = ClassificationValue.NullId;
            while (Parent != null)
            {
                Level++;

                x = _classificationValue.GetClassificationValue(Parent ?? 0);
                Parent = x.ParentValueId;

            }
            //          var ClassificationList = new List<SelectListItem>();
            //string a;
            //a = test1.Description;

            ClassificationValue.Level = Level;
            var test1 = (from s in _classificationLevel.GetAllClassificationLevels()
                         where s.ClassificationId == Convert.ToInt32(HttpContext.Request.Query["CId"]) && s.Sequence == ClassificationValue.Level
                         select new SuObjectVM
                         {
                             DateLevel = s.DateLevel
                            ,
                             Alphabetically = s.Alphabetically
                            ,
                             InDropDown = s.InDropDown

                         }).First();
            ClassificationValue.DateLevel = test1.DateLevel;
            ClassificationValue.Alphabetically = test1.Alphabetically;
            ClassificationValue.InDropDown = test1.InDropDown;


            //            var ClassificationAndStatus = new SuObjectAndStatusViewModel { SuObject = test1, SomeKindINumSelectListItem = ClassificationList }; //, Description = a};
            return View(ClassificationValue);


        }


        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var ClassificationValue = _classificationValue.GetClassificationValue(FromForm.Id);
                ClassificationValue.DateFrom = FromForm.DateFrom;
                ClassificationValue.DateTo = FromForm.DateTo;
                _classificationValue.UpdateClassificationValue(ClassificationValue);

                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var ClassificationValueLanguage = _classificationValueLanguage.GetClassificationValueLanguage(FromForm.ObjectLanguageId);
                ClassificationValueLanguage.ClassificationValueName = FromForm.Name;
                ClassificationValueLanguage.ClassificationValueDescription = FromForm.Description;
                ClassificationValueLanguage.ClassificationValueDropDownName = FromForm.DropDownName;
                ClassificationValueLanguage.ClassificationValueMenuName = FromForm.MenuName;
                ClassificationValueLanguage.ClassificationValueMouseOver = FromForm.MouseOver;
                ClassificationValueLanguage.ClassificationValuePageName = FromForm.PageName;
                ClassificationValueLanguage.ClassificationValuePageDescription = FromForm.PageDescription;
                ClassificationValueLanguage.ClassificationValueHeaderName = FromForm.HeaderName;
                ClassificationValueLanguage.ClassificationValueHeaderDescription = FromForm.HeaderDescription;
                ClassificationValueLanguage.ClassificationValueTopicName = FromForm.TopicName;

                _classificationValueLanguage.UpdateClassificationValueLanguage(ClassificationValueLanguage);

            }
            return RedirectToAction("Index", new { Id = FromForm.Id.ToString() });



        }

        public IActionResult LanguageIndex(int Id)
        {

            var ClassificationLanguage = (from c in _classificationValueLanguage.GetAllClassificationValueLanguages()
                                          join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                                          where c.ClassificationValueId == Id
                                          select new SuObjectVM
                                          {
                                              Id = c.Id
                                          ,
                                              Name = c.ClassificationValueName
                                          ,
                                              Language = l.LanguageName
                                          }).ToList();
            ViewBag.Id = Id;
            ViewBag.CId = HttpContext.Request.Query["CId"];

            return View(ClassificationLanguage);
        }

        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _classificationValueLanguage.GetAllClassificationValueLanguages()
                                where c.ClassificationValueId == Id
                                select c.LanguageId).ToList();


            var SuLanguage = (from l in _language.GetAllLanguages()
                              where !LanguagesAlready.Contains(l.Id)
                              && l.Active == true
                              select new SelectListItem
                              {
                                  Value = l.Id.ToString()
                              ,
                                  Text = l.LanguageName
                              }).ToList();

            if (SuLanguage.Count() == 0)
            {
                return RedirectToAction("LanguageIndex", new { Id = Id });
            }
            SuObjectVM SuObject = new SuObjectVM();
            SuObject.ObjectId = Id;
            //------
            var xyz = _classificationValue.GetClassificationValue(Id);
           // ClassificationValue.NullId = xyz.ParentValueId;
            int Level = 1;
            var x = new SuClassificationValueModel();
            int? Parent = xyz.ParentValueId;
            while (Parent != null)
            {
                Level++;

                x = _classificationValue.GetClassificationValue(Parent ?? 0);
                Parent = x.ParentValueId;

            }
            //          var ClassificationList = new List<SelectListItem>();
            //string a;
            //a = test1.Description;

            //ClassificationValue.Level = Level;
            var test1 = (from s in _classificationLevel.GetAllClassificationLevels()
                         where s.ClassificationId == Convert.ToInt32(HttpContext.Request.Query["CId"]) && s.Sequence == Level
                         select new SuObjectVM
                         {
                             DateLevel = s.DateLevel
                            ,
                             Alphabetically = s.Alphabetically
                            ,
                             InDropDown = s.InDropDown

                         }).First();
            //------
            ViewBag.Id = Id.ToString();
            var ClassificationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
                
            };

            ViewBag.ShowInDropDown = test1.InDropDown;
            return View(ClassificationAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var ClassificationValueLanguage = new SuClassificationValueLanguageModel();
                ClassificationValueLanguage.ClassificationValueName = FromForm.SuObject.Name;
                ClassificationValueLanguage.ClassificationValueDescription = FromForm.SuObject.Description;
                ClassificationValueLanguage.ClassificationValueDropDownName = FromForm.SuObject.DropDownName;
                ClassificationValueLanguage.ClassificationValueMenuName = FromForm.SuObject.MenuName;
                ClassificationValueLanguage.ClassificationValueMouseOver = FromForm.SuObject.MouseOver;
                ClassificationValueLanguage.ClassificationValuePageName = FromForm.SuObject.PageName;
                ClassificationValueLanguage.ClassificationValuePageDescription = FromForm.SuObject.PageDescription;
                ClassificationValueLanguage.ClassificationValueHeaderName = FromForm.SuObject.HeaderName;
                ClassificationValueLanguage.ClassificationValueHeaderDescription = FromForm.SuObject.HeaderDescription;
                ClassificationValueLanguage.ClassificationValueTopicName = FromForm.SuObject.TopicName;

                ClassificationValueLanguage.ClassificationValueId = FromForm.SuObject.ObjectId;
                ClassificationValueLanguage.LanguageId = FromForm.SuObject.LanguageId;


                var NewClassificationValue = _classificationValueLanguage.AddClassificationValueLanguage(ClassificationValueLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });





        }
    }
}
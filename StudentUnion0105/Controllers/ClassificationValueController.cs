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
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class ClassificationValueController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IClassificationValueRepository _classificationValue;
        private readonly IClassificationValueLanguageRepository _classificationValueLanguage;
        private readonly SuDbContext _context;
        private readonly IClassificationLevelRepository _classificationLevel;
        private readonly ILanguageRepository _language;

        public ClassificationValueController(UserManager<SuUserModel> userManager
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

            SuUserModel CurrentUser = await userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SuInt MaxLevel = new SuInt();
            MaxLevel.intValue = 0;

            try
            {
                MaxLevel = _context.ZdbInt.FromSql($"ClassificationValueIndexGetMaxLevel {Id}").First();
            }
            catch { }

            SuInt CurrentLevel = new SuInt();
            CurrentLevel.intValue = 0;
            try
            {
                CurrentLevel = _context.ZdbInt.FromSql($"ClassificationValueIndexGetCurrentLevel {Id}").First();//? null : new SuInt { intValue = 0 };
            }
            catch { }

            var ValueStructure = _context.ZdbClassificationValueIndexGet.FromSql($"ClassificationValueIndexGet {DefaultLanguageID}, {Id}").ToList();
            ViewBag.CId = Id.ToString();
            var c = new ValueStructureWithDepth { MaxLevel = MaxLevel.intValue, ValueStructure = ValueStructure, MaxConfigLevel = CurrentLevel.intValue };
            return View(c);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

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

            var ToForm = (from s in _classificationLevel.GetAllClassificationLevels()
                         where s.ClassificationId == Convert.ToInt32(HttpContext.Request.Query["CId"]) && s.Sequence == CValue.Level
                         select new SuObjectVM
                         {
                             DateLevel = s.DateLevel
                            ,
                             Alphabetically = s.Alphabetically
                            ,
                             InDropDown = s.InDropDown

                         }).First();
            CValue.DateLevel = ToForm.DateLevel;
            CValue.Alphabetically = ToForm.Alphabetically;
            CValue.InDropDown = ToForm.InDropDown;

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
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var ClassificationValueLanguage = new SuClassificationValueLanguageModel();

                ClassificationValueLanguage.Name = FromForm.Name;
                ClassificationValueLanguage.Description = FromForm.Description;
                ClassificationValueLanguage.DropDownName = FromForm.DropDownName;
                ClassificationValueLanguage.MenuName = FromForm.MenuName;
                ClassificationValueLanguage.MouseOver = FromForm.MouseOver;
                ClassificationValueLanguage.PageName = FromForm.Title;
                ClassificationValueLanguage.PageDescription = FromForm.PageDescription;
                ClassificationValueLanguage.HeaderName = FromForm.HeaderName;
                ClassificationValueLanguage.HeaderDescription = FromForm.HeaderDescription;
                ClassificationValueLanguage.TopicName = FromForm.TopicName;

                ClassificationValueLanguage.ClassificationValueId = NewClassificationValue.Id;
                ClassificationValueLanguage.LanguageId = DefaultLanguageID;
                _classificationValueLanguage.AddClassificationValueLanguage(ClassificationValueLanguage);

            }
            return RedirectToAction("Index", new { Id = FromForm.ObjectId.ToString() });



        }
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ClassificationValue = (from v in _classificationValue.GetAllClassifcationValues()
                                       join l in _classificationValueLanguage.GetAllClassificationValueLanguages()
                                       on v.Id equals l.ClassificationValueId
                                       where l.LanguageId == DefaultLanguageID && v.Id == Id
                                       select new SuObjectVM
                                       {
                                           Name = l.Name
                          ,
                                           Description = l.Description
                          ,
                                           DropDownName = l.DropDownName
                          ,
                                           MenuName = l.MenuName
                          ,
                                           MouseOver = l.MouseOver
                          ,
                                          Title = l.PageName
                          ,
                                           PageDescription = l.PageDescription
                          ,
                                           HeaderName = l.HeaderName
                          ,
                                           HeaderDescription = l.HeaderDescription
                          ,
                                           TopicName = l.TopicName
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
            var y = new SuClassificationValueModel();
            int? Parent = ClassificationValue.NullId;
            while (Parent != null)
            {
                Level++;

                y = _classificationValue.GetClassificationValue(Parent ?? 0);
                Parent = y.ParentValueId;

            }
            //          var ClassificationList = new List<SelectListItem>();
            //string a;
            //a = ToForm.Description;

            ClassificationValue.Level = Level;
            var ToForm = (from s in _classificationLevel.GetAllClassificationLevels()
                         where s.ClassificationId == Convert.ToInt32(HttpContext.Request.Query["CId"]) && s.Sequence == ClassificationValue.Level
                         select new SuObjectVM
                         {
                             DateLevel = s.DateLevel
                            ,
                             Alphabetically = s.Alphabetically
                            ,
                             InDropDown = s.InDropDown

                         }).First();
            ClassificationValue.DateLevel = ToForm.DateLevel;
            ClassificationValue.Alphabetically = ToForm.Alphabetically;
            ClassificationValue.InDropDown = ToForm.InDropDown;


            //            var ClassificationAndStatus = new SuObjectAndStatusViewModel { SuObject = ToForm, SomeKindINumSelectListItem = ClassificationList }; //, Description = a};
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
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var ClassificationValueLanguage = _classificationValueLanguage.GetClassificationValueLanguage(FromForm.ObjectLanguageId);
                ClassificationValueLanguage.Name = FromForm.Name;
                ClassificationValueLanguage.Description = FromForm.Description;
                ClassificationValueLanguage.DropDownName = FromForm.DropDownName;
                ClassificationValueLanguage.MenuName = FromForm.MenuName;
                ClassificationValueLanguage.MouseOver = FromForm.MouseOver;
                ClassificationValueLanguage.PageName = FromForm.Title;
                ClassificationValueLanguage.PageDescription = FromForm.PageDescription;
                ClassificationValueLanguage.HeaderName = FromForm.HeaderName;
                ClassificationValueLanguage.HeaderDescription = FromForm.HeaderDescription;
                ClassificationValueLanguage.TopicName = FromForm.TopicName;

                _classificationValueLanguage.UpdateClassificationValueLanguage(ClassificationValueLanguage);

            }
            return RedirectToAction("Index", new { Id = FromForm.Id.ToString() });



        }

        public async  Task<IActionResult> LanguageIndex(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            //var ClassificationLanguage = (from c in _classificationValueLanguage.GetAllClassificationValueLanguages()
            //                              join l in _language.GetAllLanguages()
            //             on c.LanguageId equals l.Id
            //                              where c.ClassificationValueId == Id
            //                              select new SuObjectVM
            //                              {
            //                                  Id = c.Id
            //                              ,
            //                                  Name = c.Name
            //                              ,
            //                                  Language = l.LanguageName
            //                              }).ToList();
            //ViewBag.Id = Id;
            //ViewBag.CId = HttpContext.Request.Query["CId"];

            //return View(ClassificationLanguage);
            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql($"ClassificationValueLanguageIndexGet {Id}").ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

        }

        [HttpGet]
        public async  Task<IActionResult> LanguageCreate(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
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
            //a = ToForm.Description;

            //ClassificationValue.Level = Level;
            var ToForm = (from s in _classificationLevel.GetAllClassificationLevels()
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

            ViewBag.ShowInDropDown = ToForm.InDropDown;
            return View(ClassificationAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var ClassificationValueLanguage = new SuClassificationValueLanguageModel();
                ClassificationValueLanguage.Name = FromForm.SuObject.Name;
                ClassificationValueLanguage.Description = FromForm.SuObject.Description;
                ClassificationValueLanguage.DropDownName = FromForm.SuObject.DropDownName;
                ClassificationValueLanguage.MenuName = FromForm.SuObject.MenuName;
                ClassificationValueLanguage.MouseOver = FromForm.SuObject.MouseOver;
                ClassificationValueLanguage.MouseOver = FromForm.SuObject.MouseOver;
                ClassificationValueLanguage.PageDescription = FromForm.SuObject.PageDescription;
                ClassificationValueLanguage.HeaderName = FromForm.SuObject.HeaderName;
                ClassificationValueLanguage.HeaderDescription = FromForm.SuObject.HeaderDescription;
                ClassificationValueLanguage.TopicName = FromForm.SuObject.TopicName;

                ClassificationValueLanguage.ClassificationValueId = FromForm.SuObject.ObjectId;
                ClassificationValueLanguage.LanguageId = FromForm.SuObject.LanguageId;


                var NewClassificationValue = _classificationValueLanguage.AddClassificationValueLanguage(ClassificationValueLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });
        }

        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql($"ClassificationValueLanguageEditGet {Id}").First();
            return View(ObjectLanguage);

        }
        }
    }
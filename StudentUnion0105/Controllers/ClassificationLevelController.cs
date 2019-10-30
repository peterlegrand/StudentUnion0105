using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Models.ViewModels;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class ClassificationLevelController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly IClassificationLevelRepository _classificationLevel;
        private readonly IClassificationLevelLanguageRepository _classificationLevelLanguage;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public ClassificationLevelController(UserManager<SuUserModel> userManager
            , IClassificationLanguageRepository classificationLanguage
            , IClassificationLevelRepository classificationLevel
            , IClassificationLevelLanguageRepository classificationLevelLanguage
            , ILanguageRepository language
            , SuDbContext context
            )
        {
            this.userManager = userManager;
            _classificationLanguage = classificationLanguage;
            _classificationLevel = classificationLevel;
            _classificationLevelLanguage = classificationLevelLanguage;
            _language = language;
            _context = context;
        }
        public async Task<IActionResult> Index(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            //var Classification = _context.ZdbClassificationLevelIndexGet.FromSql($"ClassificationLevelIndexGet {DefaultLanguageID}").ToList();
            //return View(Classification);


            var ClassificationLevel = (from c in _classificationLevel.GetAllClassificationLevels()
                                       join l in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
                      on c.Id equals l.ClassificationLevelId
                                       where c.ClassificationId == Id
                                       && l.LanguageId == DefaultLanguageID
                                       orderby c.Sequence
                                       select new SuObjectVM
                                       {
                                           Id = c.Id
                                       ,
                                           Name = l.Name
                                       ,
                                           ObjectId = c.ClassificationId
                                           , MouseOver = l.MouseOver
                                           , MenuName = l.MenuName
                                       }).ToList();
            ViewBag.ObjectId = Id.ToString();
            //PETER TODO add a classification label so you know to which classification the levels belong.
            return View(ClassificationLevel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var Level = (from c in _classificationLevel.GetAllClassificationLevels()
                         join l in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
                         on c.Id equals l.ClassificationLevelId
                         where c.Id == Id
                         select new SuObjectVM
                         {
                             Id = c.Id
                            ,
                             Alphabetically = c.Alphabetically
                            ,
                             CanLink = c.CanLink
                            ,
                             DateLevel = c.DateLevel
                            ,
                             InDropDown = c.InDropDown
                            ,
                             Description = l.Description
                            ,
                             OnTheFly = c.OnTheFly
                            ,
                             Sequence = c.Sequence
                            ,
                             ObjectLanguageId = l.Id
                            ,
                             MenuName = l.MenuName
                            ,
                             MouseOver = l.MouseOver
                            ,
                             Name = l.Name
                             , ObjectId = c.ClassificationId
                         }).First();

            var DateType = new List<SelectListItem>();
            DateType.Add(new SelectListItem { Value = "0", Text = "No date" });
            DateType.Add(new SelectListItem { Value = "1", Text = "Date" });
            DateType.Add(new SelectListItem { Value = "2", Text = "Date range" });
            DateType.Add(new SelectListItem { Value = "3", Text = "Date time" });
            DateType.Add(new SelectListItem { Value = "4", Text = "Date time range" });

            var suObjectAndStatusView = new SuObjectAndStatusViewModel
            {

                SuObject = Level , ProbablyTypeListItem = DateType //, a = ClassificationList 
            };
            return View(suObjectAndStatusView);


        }

        [HttpPost]
        public IActionResult Edit(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var ClassificationLevel = _classificationLevel.GetClassificationLevel(test3.SuObject.Id);
                ClassificationLevel.Alphabetically = test3.SuObject.Alphabetically;
                ClassificationLevel.CanLink = test3.SuObject.CanLink;
                ClassificationLevel.DateLevel = test3.SuObject.DateLevel;
                ClassificationLevel.InDropDown = test3.SuObject.InDropDown;
                ClassificationLevel.OnTheFly = test3.SuObject.OnTheFly;
                _classificationLevel.UpdateClassificationLevel(ClassificationLevel);

                var ClassificationLevelLanguage = _classificationLevelLanguage.GetClassificationLevelLanguage(test3.SuObject.ObjectLanguageId);
                ClassificationLevelLanguage.Name = test3.SuObject.Name;
                ClassificationLevelLanguage.MenuName = test3.SuObject.MenuName;
                ClassificationLevelLanguage.Description = test3.SuObject.Description;
                _classificationLevelLanguage.UpdateClassificationLevelLanguage(ClassificationLevelLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("Index", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SuObjectVM SuObject = new SuObjectVM();
            SuObject.ObjectId = Id;


            List<SelectListItem> ExistingLevels = (from c in _classificationLevel.GetAllClassificationLevels()
                                                   join l in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
                                                   on c.Id equals l.ClassificationLevelId
                                                   where c.ClassificationId == Id
                                                   && l.LanguageId == DefaultLanguageID
                                                   orderby c.Sequence
                                                   select new SelectListItem
                                                   {
                                                       Value = c.Sequence.ToString()
                                                   ,
                                                       Text = l.Name
                                                   }).ToList();
            var TestForNull = (from c in _classificationLevel.GetAllClassificationLevels()
                               join l in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
                               on c.Id equals l.ClassificationLevelId
                               where c.Id == Id
                               && l.LanguageId == DefaultLanguageID
                               select c.Sequence).ToList();

            int MaxLevelSequence;

            if (TestForNull.Count() == 0)
            { MaxLevelSequence = 1; }
            else
            {
                MaxLevelSequence = (from c in _classificationLevel.GetAllClassificationLevels()
                                    join l in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
                                    on c.Id equals l.ClassificationLevelId
                                    where c.Id == Id
                                    && l.LanguageId == DefaultLanguageID
                                    select c.Sequence).Max();

                MaxLevelSequence++;
            }
            var DateType = new List<SelectListItem>();
            DateType.Add(new SelectListItem { Value = "0", Text = "No date" });
            DateType.Add(new SelectListItem { Value = "1", Text = "Date" });
            DateType.Add(new SelectListItem { Value = "2", Text = "Date range" });
            DateType.Add(new SelectListItem { Value = "3", Text = "Date time" });
            DateType.Add(new SelectListItem { Value = "4", Text = "Date time range" });

            ExistingLevels.Add(new SelectListItem { Text = "add at bottom", Value = MaxLevelSequence.ToString() });

            var ClassificationAndStatus = new SuObjectAndStatusViewModel { SuObject = SuObject, SomeKindINumSelectListItem = ExistingLevels, ProbablyTypeListItem = DateType };
            return View(ClassificationAndStatus);

        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectAndStatusViewModel NewLevel)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;

                var TestForNull = (

                    from l in _classificationLevel.GetAllClassificationLevels()
                    where l.Id == NewLevel.SuObject.ObjectId
                    select l.Sequence).Count();

                int MaxLevelSequence;

                if (TestForNull == 0)
                { MaxLevelSequence = 1; }
                else
                {
                    MaxLevelSequence = (

                        from c in _classificationLevel.GetAllClassificationLevels()
                        where c.ClassificationId == NewLevel.SuObject.ObjectId
                        select c.Sequence).Max();
                    MaxLevelSequence++;
                }

                if (NewLevel.SuObject.Sequence != MaxLevelSequence)
                {

                    //Here need to update other levels to make sequence correct
                    //https://stackoverflow.com/questions/812630/how-can-i-reorder-rows-in-sql-database

                    List<IdAndSequence> ExistingLevels = (from c in _classificationLevel.GetAllClassificationLevels()
                                                          where c.ClassificationId == NewLevel.SuObject.ObjectId
                                                          && c.Sequence >= NewLevel.SuObject.Sequence
                                                          select new IdAndSequence
                                                          {
                                                              Id = c.Id
                                                          ,
                                                              Sequence = c.Sequence
                                                          }).ToList();


                    int x = 0;
                    while (x < ExistingLevels.Count())
                    {
                        SuClassificationLevelModel u = new SuClassificationLevelModel();
                        u = _classificationLevel.GetClassificationLevel(ExistingLevels[x].Id);


                        u.Sequence = ++ExistingLevels[x].Sequence;

                        _classificationLevel.UpdateClassificationLevel(u);
                        x++;

                    }
                }
                var ClassificationLevel = new SuClassificationLevelModel();
                ClassificationLevel.Sequence = NewLevel.SuObject.Sequence;
                ClassificationLevel.InDropDown = NewLevel.SuObject.InDropDown;
                ClassificationLevel.Alphabetically = NewLevel.SuObject.Alphabetically;
                ClassificationLevel.CanLink = NewLevel.SuObject.CanLink;
                ClassificationLevel.ClassificationId = NewLevel.SuObject.ObjectId;
                ClassificationLevel.DateLevel = NewLevel.SuObject.DateLevel;
                ClassificationLevel.OnTheFly = NewLevel.SuObject.OnTheFly;



                var NewClassificationLevel = _classificationLevel.AddClassificationLevel(ClassificationLevel);


                var ClassificationLevelLanguage = new SuClassificationLevelLanguageModel();

                ClassificationLevelLanguage.Name = NewLevel.SuObject.Name;
                ClassificationLevelLanguage.MenuName = NewLevel.SuObject.MenuName;
                ClassificationLevelLanguage.Description = NewLevel.SuObject.Description;
                ClassificationLevelLanguage.MouseOver = NewLevel.SuObject.MouseOver;
                ClassificationLevelLanguage.ClassificationLevelId = NewClassificationLevel.Id;
                ClassificationLevelLanguage.LanguageId = DefaultLanguageID;
                _classificationLevelLanguage.AddClassificationLevelLanguage(ClassificationLevelLanguage);

            }


            return RedirectToAction("Index", new { Id = NewLevel.SuObject.ObjectId.ToString() });

        }
        public async Task<IActionResult> LanguageIndex(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            //var ClassificationLanguage = (from c in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
            //                              join l in _language.GetAllLanguages()
            //             on c.LanguageId equals l.Id
            //                              join x in _classificationLevel.GetAllClassificationLevels()
            //                              on c.ClassificationLevelId equals x.Id
            //                              where c.ClassificationLevelId == Id
            //                              select new SuObjectVM
            //                              {
            //                                  Id = c.Id
            //                              ,
            //                                  Name = c.Name
            //                              ,
            //                                  Language = l.LanguageName
            //                              ,
            //                                  MenuName = c.MenuName
            //                              ,
            //                                  MouseOver = c.MouseOver
            //                              ,
            //                                  ObjectId = c.ClassificationLevelId
            //                                  , NotNullId = x.ClassificationId
            //                              }).ToList();
            //ViewBag.Id = Id;

            //return View(ClassificationLanguage);
            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql($"ClassificationLevelLanguageIndexGet {Id}").ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

        }

        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql($"ClassificationLevelLanguageEditGet {Id}").First();
            return View(ObjectLanguage);

            //var ToForm = (from c in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
            //             join l in _language.GetAllLanguages()
            //             on c.LanguageId equals l.Id
            //             where c.Id == Id
            //             select new SuObjectVM
            //             {
            //                 Id = c.Id
            //                ,
            //                 Name = c.Name
            //                ,
            //                 MenuName = c.MenuName
            //                 ,
            //                 Description = c.Description
            //                ,
            //                 MouseOver = c.MouseOver
            //                ,
            //                 Language = l.LanguageName
            //                ,
            //                 ObjectId = c.ClassificationLevelId

            //             }).First();

            //var ClassificationAndStatus = new SuObjectAndStatusViewModel
            //{
            //    SuObject = ToForm //, a = ClassificationList
            //};
            //return View(ClassificationAndStatus);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var ClassificationLevelLanguage = _classificationLevelLanguage.GetClassificationLevelLanguage(test3.SuObject.Id);
                ClassificationLevelLanguage.Name = test3.SuObject.Name;
                ClassificationLevelLanguage.MenuName = test3.SuObject.MenuName;
                ClassificationLevelLanguage.Description = test3.SuObject.Description;

                ClassificationLevelLanguage.MouseOver = test3.SuObject.MouseOver;
                _classificationLevelLanguage.UpdateClassificationLevelLanguage(ClassificationLevelLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
                                where c.ClassificationLevelId == Id
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
            ViewBag.Id = Id.ToString();
            var ClassificationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(ClassificationAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var ClassificationLevelLanguage = new SuClassificationLevelLanguageModel();
                ClassificationLevelLanguage.Name = test3.SuObject.Name;
                ClassificationLevelLanguage.MenuName = test3.SuObject.MenuName;
                ClassificationLevelLanguage.Description = test3.SuObject.Description;
                ClassificationLevelLanguage.MouseOver = test3.SuObject.MouseOver;
                ClassificationLevelLanguage.ClassificationLevelId = test3.SuObject.ObjectId;
                ClassificationLevelLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewClassificationLevel = _classificationLevelLanguage.AddClassificationLevelLanguage(ClassificationLevelLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> LanguageDelete(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ClassificationLevelLanguage = _context.ZdbObjectLanguageEditGet.FromSql($"ClassificationLevelEditGet {Id}").First();


            return View(ClassificationLevelLanguage);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectLanguageEditGetModel FromForm)
        {
            if (ModelState.IsValid)
            {

                _classificationLevelLanguage.DeleteClassificationLevelLanguage(FromForm.LId);
                return RedirectToAction("LanguageIndex", new { Id = FromForm.OId });
            }
            return RedirectToAction("LanguageIndex");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var Classification = _context.dbObject.FromSql($"ClassificationLevelDeleteSelect {Id}, {DefaultLanguageID}").First();



            return View(Classification);
        }

        [HttpPost]
        public IActionResult Delete(SuObjectVM a)
        {


             _classificationLevel.DeleteClassificationLevel(a.Id);
            return RedirectToAction("Index", new { Id = a.ObjectId });
            
        }


        //[HttpPost]
        //public IActionResult LanguageDelete(SuObjectLanguageEditGet FromForm)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        _classificationLevelLanguage.DeleteClassificationLevelLanguage(FromForm.LId);
        //        return RedirectToAction("LanguageIndex", new { Id = FromForm.Id });
        //    }
        //    return RedirectToAction("LanguageIndex");

        //}


    }



}
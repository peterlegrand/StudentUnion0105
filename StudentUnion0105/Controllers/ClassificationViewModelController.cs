using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Models;
using StudentUnion0105.ViewModels;
using StudentUnion0105.Repositories;
using StudentUnion0105.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentUnion0105.Models.ViewModels;
using StudentUnion0105.Data;

namespace StudentUnion0105.Controllers
{
    [Authorize("Classification")]
    public class ClassificationViewModelController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IClassificationVMRepository _classificationVMRepository;
        private readonly IClassificationStatusRepository _classificationStatus;
        private readonly IClassificationRepository _classification;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly ILanguageRepository _language;
        private readonly IClassificationLevelVMRepository _classificationLevelVMRepository;
        private readonly IClassificationLevelLanguageRepository _classificationLevelLanguage;
        private readonly IClassificationLevelRepository _classificationLevel;

        public ClassificationViewModelController(UserManager<SuUser> userManager
                                                , IClassificationVMRepository classificationVMRepository
                                                , IClassificationStatusRepository classificationStatus
                                                , IClassificationRepository classification
                                                , IClassificationLanguageRepository classificationLanguage
                                                , ILanguageRepository language
                                                , IClassificationLevelVMRepository classificationLevelVMRepository
                                            , IClassificationLevelLanguageRepository classificationLevelLanguage
                                                , IClassificationLevelRepository classificationLevel)
        {
            this.userManager = userManager;
            _classificationVMRepository = classificationVMRepository;
            _classificationStatus = classificationStatus;
            _classification = classification;
            _classificationLanguage = classificationLanguage;
            _language = language;
            _classificationLevelVMRepository = classificationLevelVMRepository;
            _classificationLevelLanguage = classificationLevelLanguage;
            _classificationLevel = classificationLevel;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var test1 =  (

                from l in _classificationLanguage.GetAllClassificationLanguages()
                
                where l.LanguageId == DefaultLanguageID
                select new SuObjectVM

                //from c in _classificationVMRepository.GetAllClassifications()
                //join l in _classificationVMRepository.GetAllClassificationLanguages()
                //on c.Id equals l.Classification.Id
                //where l.LanguageId == DefaultLanguageID
                //select new SuObjectVM

                {
                    Id = l.ClassificationId
                             ,
                             Name = l.ClassificationName
                         }).ToList();
            return View(test1);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var test1 = (from s in _classificationVMRepository.GetAllClassifications()
                         join t in _classificationVMRepository.GetAllClassificationLanguages()
                         on s.Id equals t.ClassificationId
                         where t.LanguageId == DefaultLanguageID && s.Id == Id
                         select new SuObjectVM
                         {
                             Id = s.Id
                            ,
                             Name = t.ClassificationName
                            ,
                             HasDropDown = s.HasDropDown
                            ,
                             Status = s.ClassificationStatusId
                            ,
                             ObjectLanguageId = t.Id
                            ,
                             MenuName = t.ClassificationMenuName
                            ,
                             MouseOver = t.ClassificationMouseOver
                         }).First();
            var ClassificationList = new List<SelectListItem>();

            foreach (var ClassificationFromDb in _classificationStatus.GetAllClassificationStatus())
            {
                ClassificationList.Add(new SelectListItem
                {
                    Text = ClassificationFromDb.ClassificationStatusName,
                    Value = ClassificationFromDb.Id.ToString()
                });
            }
            var ClassificationAndStatus = new SuObjectAndStatusViewModel { SuObject = test1, SomeKindINumSelectListItem = ClassificationList };
            return View(ClassificationAndStatus);


        }


        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var Classification = _classification.GetClassification(test3.SuObject.Id);
                Classification.HasDropDown = test3.SuObject.HasDropDown;
                Classification.ClassificationStatusId = test3.SuObject.Status;
                _classification.UpdateClassification(Classification);

                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var ClassificationLanguage = _classificationLanguage.GetClassificationLanguage(test3.SuObject.ObjectLanguageId);
                ClassificationLanguage.ClassificationName = test3.SuObject.Name;
                ClassificationLanguage.ClassificationMenuName = test3.SuObject.MenuName;
                ClassificationLanguage.ClassificationMouseOver = test3.SuObject.MouseOver;
                _classificationLanguage.UpdateClassificationLanguage(ClassificationLanguage);

            }
            return RedirectToAction("Index");



        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var ClassificationList = new List<SelectListItem>();

            foreach (var ClassificationFromDb in _classificationStatus.GetAllClassificationStatus())
            {
                ClassificationList.Add(new SelectListItem
                {
                    Text = ClassificationFromDb.ClassificationStatusName,
                    Value = ClassificationFromDb.Id.ToString()
                });
            }
            var ClassificationAndStatus = new SuObjectAndStatusViewModel { SomeKindINumSelectListItem = ClassificationList };
            return View(ClassificationAndStatus);
        }


        [HttpPost]
        public async Task<IActionResult> Create(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var Classification = new SuClassificationModel();
                Classification.HasDropDown = test3.SuObject.HasDropDown;
                Classification.ClassificationStatusId = test3.SuObject.Status;
                var NewClassification = _classification.AddClassification(Classification);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var ClassificationLanguage = new SuClassificationLanguageModel();

                ClassificationLanguage.ClassificationName = test3.SuObject.Name;
                ClassificationLanguage.ClassificationMenuName = test3.SuObject.MenuName;
                ClassificationLanguage.ClassificationMouseOver = test3.SuObject.MouseOver;
                ClassificationLanguage.ClassificationId = NewClassification.Id;
                ClassificationLanguage.LanguageId = DefaultLanguageID;
                _classificationLanguage.AddClassificationLanguage(ClassificationLanguage);

            }
            return RedirectToAction("Index");



        }


        public IActionResult LanguageIndex(int Id)
        {

            var ClassificationLanguage = (from c in _classificationVMRepository.GetAllClassificationLanguages()
                                          join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                                          where c.ClassificationId == Id
                                          select new SuObjectVM
                                          {
                                              Id = c.Id
                                          ,
                                              Name = c.ClassificationName
                                          ,
                                              Language = l.LanguageName
                                          ,
                                              MenuName = c.ClassificationMenuName
                                          ,
                                              MouseOver = c.ClassificationMouseOver
                                          ,
                                              ObjectId = c.ClassificationId
                                          }).ToList();
            ViewBag.Id = Id;

            return View(ClassificationLanguage);
        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var test1 = (from c in _classificationVMRepository.GetAllClassificationLanguages()
                         join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                         where c.Id == Id
                         select new SuObjectVM
                         {
                             Id = c.Id
                            ,
                             Name = c.ClassificationName
                            ,
                             MenuName = c.ClassificationMenuName
                            ,
                             MouseOver = c.ClassificationMouseOver
                            ,
                             Language = l.LanguageName
                            ,
                             ObjectId = c.ClassificationId

                         }).First();

            var ClassificationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = test1 //, a = ClassificationList
            };
            return View(ClassificationAndStatus);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var ClassificationLanguage = _classificationLanguage.GetClassificationLanguage(test3.SuObject.Id);
                ClassificationLanguage.ClassificationName = test3.SuObject.Name;
                ClassificationLanguage.ClassificationMenuName = test3.SuObject.MenuName;
                ClassificationLanguage.ClassificationMouseOver = test3.SuObject.MouseOver;
                _classificationLanguage.UpdateClassificationLanguage(ClassificationLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        public async Task<IActionResult> LevelIndex(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;

            var ClassificationLevel = (from c in _classificationLevelVMRepository.GetAllClassificationLevels()
                                       join l in _classificationLevelVMRepository.GetAllClassificationLevelLanguages()
                      on c.Id equals l.ClassificationLevelId
                                       where c.ClassificationId == Id
                                       && l.LanguageId == DefaultLanguageID
                                       orderby c.Sequence
                                       select new SuObjectVM
                                       {
                                           Id = c.Id
                                       ,
                                           Name = l.ClassificationLevelName
                                       ,
                                           ObjectId = c.ClassificationId
                                       }).ToList();
            ViewBag.ObjectId = Id.ToString();
            //PETER TODO add a classification label so you know to which classification the levels belong.
            return View(ClassificationLevel);
        }

        [HttpGet]
        public async Task<IActionResult> LevelCreate(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            SuObjectVM SuObject = new SuObjectVM();
            SuObject.ObjectId = Id;

            List<SelectListItem> ExistingLevels = (from c in _classificationLevelVMRepository.GetAllClassificationLevels()
                                                   join l in _classificationLevelVMRepository.GetAllClassificationLevelLanguages()
                                                   on c.Id equals l.ClassificationLevelId
                                                   where c.ClassificationId == Id
                                                   && l.LanguageId == DefaultLanguageID
                                                   orderby c.Sequence
                                                   select new SelectListItem
                                                   {
                                                       Value = c.Sequence.ToString()
                                                   ,
                                                       Text = l.ClassificationLevelName
                                                   }).ToList();
            var TestForNull = (from c in _classificationLevelVMRepository.GetAllClassificationLevels()
             join l in _classificationLevelVMRepository.GetAllClassificationLevelLanguages()
             on c.Id equals l.ClassificationLevelId
             where c.Id == Id
             && l.LanguageId == DefaultLanguageID
             select c.Sequence).ToList();

            int MaxLevelSequence;

            if (TestForNull.Count() ==0)
            { MaxLevelSequence = 1; }
            else
            {
                MaxLevelSequence = (from c in _classificationLevelVMRepository.GetAllClassificationLevels()
                                    join l in _classificationLevelVMRepository.GetAllClassificationLevelLanguages()
                                    on c.Id equals l.ClassificationLevelId
                                    where c.Id == Id
                                    && l.LanguageId == DefaultLanguageID
                                    select c.Sequence).Max();

                MaxLevelSequence++; }


            ExistingLevels.Add(new SelectListItem { Text = "add at bottom", Value = MaxLevelSequence.ToString() });

            var ClassificationAndStatus = new SuObjectAndStatusViewModel { SuObject = SuObject, SomeKindINumSelectListItem = ExistingLevels };
            return View(ClassificationAndStatus);

        }


        [HttpPost]
        public async Task<IActionResult> LevelCreate(SuObjectAndStatusViewModel NewLevel)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;

                var TestForNull = (
                    
                    from  l in _classificationLevel.GetAllClassificationLevels()
                                   where l.Id == NewLevel.SuObject.ObjectId
                                   select l.Sequence).Count();

                //from c in _classificationLevel.GetAllClassificationLevels()
                //join l in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
                //on c.Id equals l.ClassificationLevelId
                //where c.ClassificationId == NewLevel.SuObject.ObjectId
                //&& l.LanguageId == DefaultLanguageID
                //select c.Sequence).Count();

                int MaxLevelSequence;

                if (TestForNull == 0)
                { MaxLevelSequence = 1; }
                else
                {
                    MaxLevelSequence = (
                        
                        from c in _classificationLevel.GetAllClassificationLevels()
                                        where c.ClassificationId == NewLevel.SuObject.ObjectId
                                        select c.Sequence).Max();
                    //from c in _classificationLevel.GetAllClassificationLevels()
                    //join l in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
                    //on c.Id equals l.ClassificationLevelId
                    //where c.ClassificationId == NewLevel.SuObject.ObjectId
                    //&& l.LanguageId == DefaultLanguageID
                    //select c.Sequence).Max();
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

                        //SuDbContext.Entry(u).State = Microsoft.EntityFrameworkCore.EntityState.

                        //Microsoft.EntityFrameworkCore.EntityState.
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

                    ClassificationLevelLanguage.ClassificationLevelName = NewLevel.SuObject.Name;
                    ClassificationLevelLanguage.ClassificationLevelMenuName = NewLevel.SuObject.MenuName;
                    ClassificationLevelLanguage.ClassificationLevelMouseOver = NewLevel.SuObject.MouseOver;
                    ClassificationLevelLanguage.ClassificationLevelId = NewClassificationLevel.Id;
                    ClassificationLevelLanguage.LanguageId = DefaultLanguageID;
                    _classificationLevelLanguage.AddClassificationLevelLanguage(ClassificationLevelLanguage);

                }
            

            return RedirectToAction("LevelIndex", new { Id = NewLevel.SuObject.ObjectId.ToString() });

        }

        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _classificationLanguage.GetAllClassificationLanguages()
                                where c.ClassificationId == Id
                                select c.LanguageId).ToList();


            var SuLanguage = (from l in _language.GetAllLanguages()
                              where !LanguagesAlready.Contains(l.Id)
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
        public async Task<IActionResult> LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var ClassificationLanguage = new SuClassificationLanguageModel();
                ClassificationLanguage.ClassificationName = test3.SuObject.Name;
                ClassificationLanguage.ClassificationMenuName = test3.SuObject.MenuName;
                ClassificationLanguage.ClassificationMouseOver = test3.SuObject.MouseOver;
                ClassificationLanguage.ClassificationId = test3.SuObject.ObjectId;
                ClassificationLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewClassification = _classificationLanguage.AddClassificationLanguage(ClassificationLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LevelEdit(int Id)
        {
            var Level = (from c in _classificationLevelVMRepository.GetAllClassificationLevels()
                         join l in _classificationLevelVMRepository.GetAllClassificationLevelLanguages()
                         on c.Id equals l.ClassificationLevelId
                         where c.Id == Id
                         select new SuObjectVM
                         {
                             ObjectId = c.Id
                            ,
                             Alphabetically = c.Alphabetically
                            ,
                             CanLink = c.CanLink
                            ,
                             DateLevel = c.DateLevel
                            ,
                             InDropDown = c.InDropDown
                            ,
                             OnTheFly = c.OnTheFly
                            ,
                             Sequence = c.Sequence
                            ,
                             ObjectLanguageId = l.Id
                            ,
                             MenuName = l.ClassificationLevelMenuName
                            ,
                             MouseOver = l.ClassificationLevelMouseOver
                            ,
                             Name = l.ClassificationLevelName
                         }).First();

            var suObjectAndStatusView = new SuObjectAndStatusViewModel
            {

                SuObject = Level //, a = ClassificationList
            };
            return View(suObjectAndStatusView);


        }

        [HttpPost]
        public IActionResult LevelEdit(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var ClassificationLanguage = _classificationLanguage.GetClassificationLanguage(test3.SuObject.Id);
                ClassificationLanguage.ClassificationName = test3.SuObject.Name;
                ClassificationLanguage.ClassificationMenuName = test3.SuObject.MenuName;
                ClassificationLanguage.ClassificationMouseOver = test3.SuObject.MouseOver;
                _classificationLanguage.UpdateClassificationLanguage(ClassificationLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageDelete(int Id)
        {
           var ClassifationLanguage = _classificationLanguage.GetClassificationLanguage(Id);
            return View(ClassifationLanguage);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuClassificationLanguageModel suClassificationLanguageModel)
        {
            var ClassificationId = suClassificationLanguageModel.ClassificationId;
            _classificationLanguage.DeleteClassificationLanguage(suClassificationLanguageModel.Id);
            return RedirectToAction("LanguageIndex", new { Id = ClassificationId });
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentUnion0105.Models;
using StudentUnion0105.Models.ViewModels;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{
    public class ClassificationLevelController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IClassificationLevelVMRepository _classificationLevelVMRepository;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly IClassificationLevelRepository _classificationLevel;
        private readonly IClassificationLevelLanguageRepository _classificationLevelLanguage;
        private readonly ILanguageRepository _language;

        public ClassificationLevelController(UserManager<SuUser> userManager
            , IClassificationLevelVMRepository classificationLevelVMRepository
            , IClassificationLanguageRepository classificationLanguage
            , IClassificationLevelRepository classificationLevel
            , IClassificationLevelLanguageRepository classificationLevelLanguage
            , ILanguageRepository language)
        {
            this.userManager = userManager;
            _classificationLevelVMRepository = classificationLevelVMRepository;
            _classificationLanguage = classificationLanguage;
            _classificationLevel = classificationLevel;
            _classificationLevelLanguage = classificationLevelLanguage;
            _language = language;
        }
        public async Task<IActionResult> Index(int Id)
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
        public IActionResult Edit(int Id)
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
        public IActionResult Edit(SuObjectAndStatusViewModel test3)
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
        public async Task<IActionResult> Create(int Id)
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

            if (TestForNull.Count() == 0)
            { MaxLevelSequence = 1; }
            else
            {
                MaxLevelSequence = (from c in _classificationLevelVMRepository.GetAllClassificationLevels()
                                    join l in _classificationLevelVMRepository.GetAllClassificationLevelLanguages()
                                    on c.Id equals l.ClassificationLevelId
                                    where c.Id == Id
                                    && l.LanguageId == DefaultLanguageID
                                    select c.Sequence).Max();

                MaxLevelSequence++;
            }


            ExistingLevels.Add(new SelectListItem { Text = "add at bottom", Value = MaxLevelSequence.ToString() });

            var ClassificationAndStatus = new SuObjectAndStatusViewModel { SuObject = SuObject, SomeKindINumSelectListItem = ExistingLevels };
            return View(ClassificationAndStatus);

        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectAndStatusViewModel NewLevel)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;

                var TestForNull = (

                    from l in _classificationLevel.GetAllClassificationLevels()
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


            return RedirectToAction("Index", new { Id = NewLevel.SuObject.ObjectId.ToString() });

        }

    }

}
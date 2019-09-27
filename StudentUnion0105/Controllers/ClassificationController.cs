using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    [Authorize("Classification")]
    public class ClassificationController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IClassificationVMRepository _classificationVMRepository;
        private readonly IClassificationStatusRepository _classificationStatus;
        private readonly IClassificationRepository _classification;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly ILanguageRepository _language;
        //        private readonly IClassificationLevelVMRepository _classificationLevelVMRepository;
        //        private readonly IClassificationLevelLanguageRepository _classificationLevelLanguage;
        //        private readonly IClassificationLevelRepository _classificationLevel;

        public ClassificationController(UserManager<SuUser> userManager
                                                , IClassificationVMRepository classificationVMRepository
                                                , IClassificationStatusRepository classificationStatus
                                                , IClassificationRepository classification
                                                , IClassificationLanguageRepository classificationLanguage
                                                , ILanguageRepository language
            //                                , IClassificationLevelVMRepository classificationLevelVMRepository
            //                                  , IClassificationLevelLanguageRepository classificationLevelLanguage
            //                                    , IClassificationLevelRepository classificationLevel
            )
        {
            this.userManager = userManager;
            _classificationVMRepository = classificationVMRepository;
            _classificationStatus = classificationStatus;
            _classification = classification;
            _classificationLanguage = classificationLanguage;
            _language = language;
            //_classificationLevelVMRepository = classificationLevelVMRepository;
            //_classificationLevelLanguage = classificationLevelLanguage;
            //_classificationLevel = classificationLevel;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //            ViewBag.CID = 
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var test1 = (

                from l in _classificationLanguage.GetAllClassificationLanguages()

                where l.LanguageId == DefaultLanguageID
                select new SuObjectVM


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
                             Description = t.ClassificationDescription
                            ,
                             MouseOver = t.ClassificationMouseOver
                         }).First();
            var ClassificationList = new List<SelectListItem>();
            //string a;
            //a = test1.Description;

            foreach (var ClassificationFromDb in _classificationStatus.GetAllClassificationStatus())
            {
                ClassificationList.Add(new SelectListItem
                {
                    Text = ClassificationFromDb.ClassificationStatusName,
                    Value = ClassificationFromDb.Id.ToString()
                });
            }
            var ClassificationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = test1,
                SomeKindINumSelectListItem = ClassificationList
            }; //, Description = a};
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
                ClassificationLanguage.ClassificationDescription = test3.SuObject.Description;
                //                ClassificationLanguage.ClassificationDescription = test3.SuObject.Description;
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
                                              MouseOver = c.ClassificationMouseOver,

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
                             Description = c.ClassificationDescription
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
                ClassificationLanguage.ClassificationDescription = test3.SuObject.Description;

                ClassificationLanguage.ClassificationMouseOver = test3.SuObject.MouseOver;
                _classificationLanguage.UpdateClassificationLanguage(ClassificationLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



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
                var ClassificationLanguage = new SuClassificationLanguageModel();
                ClassificationLanguage.ClassificationName = test3.SuObject.Name;
                ClassificationLanguage.ClassificationMenuName = test3.SuObject.MenuName;
                ClassificationLanguage.ClassificationDescription = test3.SuObject.Description;
                ClassificationLanguage.ClassificationMouseOver = test3.SuObject.MouseOver;
                ClassificationLanguage.ClassificationId = test3.SuObject.ObjectId;
                ClassificationLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewClassification = _classificationLanguage.AddClassificationLanguage(ClassificationLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageDelete(int Id)
        {
            var ClassifationLanguage = _classificationLanguage.GetClassificationLanguage(Id);
            var a = new SuObjectVM();
            a.Id = ClassifationLanguage.Id;
            a.Name = ClassifationLanguage.ClassificationName;
            a.MenuName = ClassifationLanguage.ClassificationMenuName;
            a.MouseOver = ClassifationLanguage.ClassificationMouseOver;
            a.LanguageId = ClassifationLanguage.LanguageId;
            a.ObjectId = ClassifationLanguage.ClassificationId;
            return View(a);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectVM a)
        {
            if (ModelState.IsValid)
            {

                _classificationLanguage.DeleteClassificationLanguage(a.Id);
                return RedirectToAction("LanguageIndex", new { Id = a.ObjectId });
            }
            return RedirectToAction("LanguageIndex");

        }
    }


}

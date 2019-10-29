﻿using Microsoft.AspNetCore.Authorization;
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
    [Authorize("Classification")]
    public class ClassificationController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IClassificationVMRepository _classificationVMRepository;
        private readonly IClassificationStatusRepository _classificationStatus;
        private readonly IClassificationRepository _classification;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        //        private readonly IClassificationLevelVMRepository _classificationLevelVMRepository;
        //        private readonly IClassificationLevelLanguageRepository _classificationLevelLanguage;
        //        private readonly IClassificationLevelRepository _classificationLevel;

        public ClassificationController(UserManager<SuUserModel> userManager
                                                , IClassificationVMRepository classificationVMRepository
                                                , IClassificationStatusRepository classificationStatus
                                                , IClassificationRepository classification
                                                , IClassificationLanguageRepository classificationLanguage
                                                , ILanguageRepository language
            , SuDbContext context
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
            _context = context;
            //_classificationLevelVMRepository = classificationLevelVMRepository;
            //_classificationLevelLanguage = classificationLevelLanguage;
            //_classificationLevel = classificationLevel;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            //            ViewBag.CID = 
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var Classification = _context.ZdbClassificationIndexGet.FromSql($"ClassificationIndexGet {DefaultLanguageID}").ToList();
            return View(Classification);

            //var ToForm = (

            //    from l in _classificationLanguage.GetAllClassificationLanguages()

            //    where l.LanguageId == DefaultLanguageID
            //    select new SuObjectVM


            //    {
            //        Id = l.ClassificationId
            //                 ,
            //        Name = l.Name
            //                                                   ,
            //        MouseOver = l.MouseOver
            //                               ,
            //        MenuName = l.MenuName

            //    }).ToList();
            //return View(ToForm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ToForm = (from s in _classificationVMRepository.GetAllClassifications()
                         join t in _classificationVMRepository.GetAllClassificationLanguages()
                         on s.Id equals t.ClassificationId
                         where t.LanguageId == DefaultLanguageID && s.Id == Id
                         select new SuObjectVM
                         {
                             Id = s.Id
                            ,
                             Name = t.Name
                            ,
                             HasDropDown = s.HasDropDown
                            ,
                             Status = s.ClassificationStatusId
                            ,
                             ObjectLanguageId = t.Id
                            ,
                             MenuName = t.MenuName
                            ,
                             Description = t.Description
                            ,
                             MouseOver = t.MouseOver
                         }).First();
            var ClassificationList = new List<SelectListItem>();
            //string a;
            //a = ToForm.Description;

            foreach (var ClassificationFromDb in _classificationStatus.GetAllClassificationStatus())
            {
                ClassificationList.Add(new SelectListItem
                {
                    Text = ClassificationFromDb.Name,
                    Value = ClassificationFromDb.Id.ToString()
                });
            }
            var ClassificationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = ToForm,
                SomeKindINumSelectListItem = ClassificationList
            }; //, Description = a};
            return View(ClassificationAndStatus);


        }


        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                Guid guid = new Guid(CurrentUser.Id);

                var Classification = _classification.GetClassification(FromForm.SuObject.Id);
                Classification.HasDropDown = FromForm.SuObject.HasDropDown;
                Classification.ClassificationStatusId = FromForm.SuObject.Status;
                Classification.ModifierId = guid;
                _classification.UpdateClassification(Classification);

                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var ClassificationLanguage = _classificationLanguage.GetClassificationLanguage(FromForm.SuObject.ObjectLanguageId);
                ClassificationLanguage.Name = FromForm.SuObject.Name;
                ClassificationLanguage.MenuName = FromForm.SuObject.MenuName;
                ClassificationLanguage.Description = FromForm.SuObject.Description;
                ClassificationLanguage.ModifierId = guid;
                //                ClassificationLanguage.Description = FromForm.SuObject.Description;
                ClassificationLanguage.MouseOver = FromForm.SuObject.MouseOver;
                _classificationLanguage.UpdateClassificationLanguage(ClassificationLanguage);

            }
            return RedirectToAction("Index");



        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var ClassificationList = new List<SelectListItem>();

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            foreach (var ClassificationFromDb in _classificationStatus.GetAllClassificationStatus())
            {
                ClassificationList.Add(new SelectListItem
                {
                    Text = ClassificationFromDb.Name,
                    Value = ClassificationFromDb.Id.ToString()
                });
            }
            var ClassificationAndStatus = new SuObjectAndStatusViewModel { SomeKindINumSelectListItem = ClassificationList };
            return View(ClassificationAndStatus);
        }


        [HttpPost]
        public async Task<IActionResult> Create(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                Guid guid = new Guid(CurrentUser.Id);

                var Classification = new SuClassificationModel();
                Classification.HasDropDown = FromForm.SuObject.HasDropDown;
                Classification.ClassificationStatusId = FromForm.SuObject.Status;
                Classification.CreatorId = guid;
                Classification.ModifierId = guid;
                var NewClassification = _classification.AddClassification(Classification);



                var ClassificationLanguage = new SuClassificationLanguageModel();

                ClassificationLanguage.Name = FromForm.SuObject.Name;
                ClassificationLanguage.MenuName = FromForm.SuObject.MenuName;
                ClassificationLanguage.MouseOver = FromForm.SuObject.MouseOver;
                ClassificationLanguage.ClassificationId = NewClassification.Id;
                ClassificationLanguage.LanguageId = DefaultLanguageID;
                ClassificationLanguage.CreatorId = guid;
                ClassificationLanguage.ModifierId = guid;
                _classificationLanguage.AddClassificationLanguage(ClassificationLanguage);

            }
            return RedirectToAction("Index");



        }


        public async Task<IActionResult> LanguageIndex(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql($"ClassificationLanguageIndexGet {Id}").ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

            var ClassificationLanguage = (from c in _classificationVMRepository.GetAllClassificationLanguages()
                                          join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                                          where c.ClassificationId == Id
                                          select new SuObjectVM
                                          {
                                              Id = c.Id
                                          ,
                                              Name = c.Name
                                          ,
                                              Language = l.LanguageName
                                          ,
                                              MenuName = c.MenuName
                                          ,
                                              MouseOver = c.MouseOver,

                                              ObjectId = c.ClassificationId
                                          }).ToList();
            ViewBag.Id = Id;

            return View(ClassificationLanguage);
        }

        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ToForm = (from c in _classificationVMRepository.GetAllClassificationLanguages()
                         join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                         where c.Id == Id
                         select new SuObjectVM
                         {
                             Id = c.Id
                            ,
                             Name = c.Name
                            ,
                             MenuName = c.MenuName
                             ,
                             Description = c.Description
                            ,
                             MouseOver = c.MouseOver
                            ,
                             Language = l.LanguageName
                            ,
                             ObjectId = c.ClassificationId

                         }).First();

            var ClassificationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = ToForm //, a = ClassificationList
            };
            return View(ClassificationAndStatus);


        }

        [HttpPost]
        public async Task<IActionResult> LanguageEdit(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                Guid guid = new Guid(CurrentUser.Id);

                var ClassificationLanguage = _classificationLanguage.GetClassificationLanguage(FromForm.SuObject.Id);
                ClassificationLanguage.Name = FromForm.SuObject.Name;
                ClassificationLanguage.MenuName = FromForm.SuObject.MenuName;
                ClassificationLanguage.Description = FromForm.SuObject.Description;
                ClassificationLanguage.ModifierId = guid;

                ClassificationLanguage.MouseOver = FromForm.SuObject.MouseOver;
                _classificationLanguage.UpdateClassificationLanguage(ClassificationLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+FromForm.Classification.ClassificationId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }



        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

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
        public async Task<IActionResult> LanguageCreate(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                Guid guid = new Guid(CurrentUser.Id);
                var ClassificationLanguage = new SuClassificationLanguageModel();
                ClassificationLanguage.Name = FromForm.SuObject.Name;
                ClassificationLanguage.MenuName = FromForm.SuObject.MenuName;
                ClassificationLanguage.Description = FromForm.SuObject.Description;
                ClassificationLanguage.MouseOver = FromForm.SuObject.MouseOver;
                ClassificationLanguage.ClassificationId = FromForm.SuObject.ObjectId;
                ClassificationLanguage.LanguageId = FromForm.SuObject.LanguageId;
                ClassificationLanguage.ModifierId = guid;
                ClassificationLanguage.CreatorId = guid;

                var NewClassification = _classificationLanguage.AddClassificationLanguage(ClassificationLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var Classification = _context.dbObject.FromSql($"ClassificationSelectOne {Id}, {DefaultLanguageID}").First();

            
           
            return View(Classification);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectVM a)
        {


                _classificationLanguage.DeleteClassificationLanguage(a.Id);
                return RedirectToAction("LanguageIndex", new { Id = a.ObjectId });
            return RedirectToAction("LanguageIndex");

        }
        [HttpGet]
        public async Task<IActionResult> LanguageDelete(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ClassifationLanguage = _classificationLanguage.GetClassificationLanguage(Id);
            var a = new SuObjectVM();
            a.Id = ClassifationLanguage.Id;
            a.Name = ClassifationLanguage.Name;
            a.MenuName = ClassifationLanguage.MenuName;
            a.MouseOver = ClassifationLanguage.MouseOver;
            a.LanguageId = ClassifationLanguage.LanguageId;
            a.ObjectId = ClassifationLanguage.ClassificationId;
            return View(a);
        }

        [HttpPost]
        public IActionResult Delete(SuObjectVM FromForm)
        {
                var b = _context.Database.ExecuteSqlCommand($"ClassificationDelete {FromForm.Id}");

            return RedirectToAction("Index");

        }



    }


}

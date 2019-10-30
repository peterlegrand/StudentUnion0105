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
using System.Data.SqlClient;
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


        public ClassificationController(UserManager<SuUserModel> userManager
                                                , IClassificationVMRepository classificationVMRepository
                                                , IClassificationStatusRepository classificationStatus
                                                , IClassificationRepository classification
                                                , IClassificationLanguageRepository classificationLanguage
                                                , ILanguageRepository language
                                                , SuDbContext context
            )
        {
            this.userManager = userManager;
            _classificationVMRepository = classificationVMRepository;
            _classificationStatus = classificationStatus;
            _classification = classification;
            _classificationLanguage = classificationLanguage;
            _language = language;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var Classification = _context.ZdbClassificationIndexGet.FromSql($"ClassificationIndexGet {DefaultLanguageID}").ToList();
            return View(Classification);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ClassificationEditGet = _context.ZdbClassificationEditGet.FromSql($"ClassificationEditGet {DefaultLanguageID}, {Id}").First();
            
            var ClassificationList = new List<SelectListItem>();
            foreach (var ClassificationFromDb in _classificationStatus.GetAllClassificationStatus())
            {
                ClassificationList.Add(new SelectListItem
                {
                    Text = ClassificationFromDb.Name,
                    Value = ClassificationFromDb.Id.ToString()
                });
            }
            SuClassificationEditGetWithListModel ClassificationWithList  = new SuClassificationEditGetWithListModel();

            ClassificationWithList.Classification = ClassificationEditGet;
            ClassificationWithList.StatusList = ClassificationList;

            return View(ClassificationWithList);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuClassificationEditGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.Classification.Id),
                    new SqlParameter("@LanguageId", DefaultLanguageID),
                    new SqlParameter("@ClassificationStatusId", FromForm.Classification.ClassificationStatusId),
                    new SqlParameter("@DefaultClassificationPageId", FromForm.Classification.DefaultClassificationPageId),
                    new SqlParameter("@HasDropDown", FromForm.Classification.HasDropDown),
                    new SqlParameter("@DropDownSequence", FromForm.Classification.DropDownSequence),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.Classification.Name),
                    new SqlParameter("@Description", FromForm.Classification.Description),
                    new SqlParameter("@MouseOver", FromForm.Classification.MouseOver),
                    new SqlParameter("@MenuName", FromForm.Classification.MenuName)
                    };
                var b = _context.Database.ExecuteSqlCommand("ClassificationEditPost " +
                            "@Id" +
                            ", @LanguageId" +
                            ", @ClassificationStatusId" +
                            ", @DefaultClassificationPageId" +
                            ", @HasDropDown" +
                            ", @DropDownSequence" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName", parameters);
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
            var ClassificationAndStatus = new SuClassificationEditGetWithListModel {  StatusList = ClassificationList };
            return View(ClassificationAndStatus);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(SuClassificationEditGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;

                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.Classification.Id),
                    new SqlParameter("@LanguageId", DefaultLanguageID),
                    new SqlParameter("@ClassificationStatusId", FromForm.Classification.ClassificationStatusId),
                    new SqlParameter("@DefaultClassificationPageId", FromForm.Classification.DefaultClassificationPageId),
                    new SqlParameter("@HasDropDown", FromForm.Classification.HasDropDown),
                    new SqlParameter("@DropDownSequence", FromForm.Classification.DropDownSequence),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.Classification.Name),
                    new SqlParameter("@Description", FromForm.Classification.Description),
                    new SqlParameter("@MouseOver", FromForm.Classification.MouseOver),
                    new SqlParameter("@MenuName", FromForm.Classification.MenuName)
                    };

                var b = _context.Database.ExecuteSqlCommand("ClassificationCreatePost " +
                            "@Id" +
                            ", @LanguageId" +
                            ", @ClassificationStatusId" +
                            ", @DefaultClassificationPageId" +
                            ", @HasDropDown" +
                            ", @DropDownSequence" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName", parameters);
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
        }

        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql($"ClassificationLanguageEditGet {Id}").First();
            return View(ObjectLanguage);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageEdit(SuObjectLanguageEditGetModel FromForm)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            if (ModelState.IsValid)
            {

                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.LId),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.Name),
                    new SqlParameter("@Description", FromForm.Description),
                    new SqlParameter("@MouseOver", FromForm.MouseOver),
                    new SqlParameter("@MenuName", FromForm.MenuName)
                    };

                var b = _context.Database.ExecuteSqlCommand("ClassificationLanguageEditPost " +
                            "@Id" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName", parameters);
                return RedirectToAction("LanguageIndex", new { Id = FromForm.OId.ToString() });
            }
            return View();
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
            SuObjectLanguageCreateGetModel Classification = new SuObjectLanguageCreateGetModel();
            Classification.OId= Id;
            ViewBag.Id = Id.ToString();
            var ClassificationAndStatus = new SuObjectLanguageCreateGetWithListModel
            {
                ObjectLanguage = Classification
                
                ,LanguageList  = SuLanguage
            };
            return View(ClassificationAndStatus);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageCreate(SuObjectLanguageCreateGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                Guid guid = new Guid(CurrentUser.Id);

                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.ObjectLanguage.OId),
                    new SqlParameter("@LanguageId", FromForm.ObjectLanguage.LanguageId),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.ObjectLanguage.Name),
                    new SqlParameter("@Description", FromForm.ObjectLanguage.Description),
                    new SqlParameter("@MouseOver", FromForm.ObjectLanguage.MouseOver),
                    new SqlParameter("@MenuName", FromForm.ObjectLanguage.MenuName)
                    };

                var b = _context.Database.ExecuteSqlCommand("ClassificationLanguageCreatePost " +
                            "@Id" +
                            ", @LanguageId" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName", parameters);
            }
        return RedirectToAction("LanguageIndex", new { Id = FromForm.ObjectLanguage.OId.ToString() });
        }

        [HttpGet]
        public async Task<IActionResult> LanguageDelete(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql($"ClassificationLanguageEditGet {Id}").First();
            return View(ObjectLanguage);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectLanguageEditGetModel FromForm)
        {
                _classificationLanguage.DeleteClassificationLanguage(FromForm.LId);
                return RedirectToAction("LanguageIndex", new { Id = FromForm.OId });
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
        public IActionResult Delete(SuObjectVM FromForm)
        {
            var b = _context.Database.ExecuteSqlCommand($"ClassificationDeletePost {FromForm.Id}");

            return RedirectToAction("Index");

        }

    }
}

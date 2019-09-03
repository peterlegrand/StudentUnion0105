﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{
    public class PageTypeController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IPageTypeLanguageRepository _PageTypeLanguage;
        private readonly IPageTypeRepository _PageType;
        private readonly ILanguageRepository _language;

        public PageTypeController(UserManager<SuUser> userManager
            , IPageTypeLanguageRepository PageTypeLanguage
            , IPageTypeRepository PageType
            , ILanguageRepository language)
        {
            this.userManager = userManager;
            _PageTypeLanguage = PageTypeLanguage;
            _PageType = PageType;
            _language = language;
        }
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var PageTypes = (

                from l in _PageTypeLanguage.GetAllPageTypeLanguages()

                where l.LanguageId == DefaultLanguageID
                select new SuObjectVM


                {
                    Id = l.PageTypeId
                             ,
                    Name = l.Name
                }).ToList();
            return View(PageTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var PageType = new SuObjectVM();
            return View(PageType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var PageType = new SuPageTypeModel();
                PageType.ModifiedDate = DateTime.Now;
                PageType.CreatedDate = DateTime.Now;
                var NewPageType = _PageType.AddPageType(PageType);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var PageTypeLanguage = new SuPageTypeLanguageModel();

                PageTypeLanguage.Name = FromForm.Name;
                PageTypeLanguage.Description = FromForm.MenuName;
                PageTypeLanguage.MouseOver = FromForm.MouseOver;
                PageTypeLanguage.PageTypeId = NewPageType.Id;
                PageTypeLanguage.LanguageId = DefaultLanguageID;
                _PageTypeLanguage.AddPageTypeLanguage(PageTypeLanguage);

            }
            return RedirectToAction("Index");



        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var test1 = (from s in _PageType.GetAllPageTypes()
                         join t in _PageTypeLanguage.GetAllPageTypeLanguages()
                         on s.Id equals t.PageTypeId
                         where t.LanguageId == DefaultLanguageID && s.Id == Id
                         select new SuObjectVM
                         {
                             Id = s.Id
                            ,
                             Name = t.Name
                            ,
                             ObjectLanguageId = t.Id
                            ,
                             Description = t.Description
                            ,
                             MouseOver = t.MouseOver
                         }).First();

            return View(test1);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var PageType = _PageType.GetPageType(test3.Id);
                var CurrentUser = await userManager.GetUserAsync(User);

                PageType.ModifiedDate = DateTime.Now;
                PageType.ModifierId = new Guid(CurrentUser.Id);
                _PageType.UpdatePageType(PageType);

                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var PageTypeLanguage = _PageTypeLanguage.GetPageTypeLanguage(test3.ObjectLanguageId);
                PageTypeLanguage.Name = test3.Name;
                PageTypeLanguage.Description = test3.Description;
                PageTypeLanguage.MouseOver = test3.MouseOver;
                PageTypeLanguage.ModifiedDate = DateTime.Now;
                PageTypeLanguage.ModifierId = new Guid(CurrentUser.Id);
                _PageTypeLanguage.UpdatePageTypeLanguage(PageTypeLanguage);

            }
            return RedirectToAction("Index");



        }


        public IActionResult LanguageIndex(int Id)
        {

            var PageLanguage = (from c in _PageTypeLanguage.GetAllPageTypeLanguages()
                                   join l in _language.GetAllLanguages()
                  on c.LanguageId equals l.Id
                                   where c.PageTypeId == Id
                                   select new SuObjectVM
                                   {
                                       Id = c.Id
                                   ,
                                       Name = c.Name
                                   ,
                                       Language = l.LanguageName
                                   ,
                                       Description = c.Description
                                   ,
                                       MouseOver = c.MouseOver
                                   ,
                                       ObjectId = c.PageTypeId
                                   }).ToList();
            ViewBag.Id = Id;

            return View(PageLanguage);
        }

        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _PageTypeLanguage.GetAllPageTypeLanguages()
                                where c.PageTypeId == Id
                                select c.LanguageId).ToList();


            var SuLanguage = (from l in _language.GetAllLanguages()
                              where !LanguagesAlready.Contains(l.Id)
                              && l.Active
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
            var PageTypeAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(PageTypeAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var PageTypeLanguage = new SuPageTypeLanguageModel();
                PageTypeLanguage.Name = test3.SuObject.Name;
                PageTypeLanguage.Description = test3.SuObject.Description;
                PageTypeLanguage.MouseOver = test3.SuObject.MouseOver;
                PageTypeLanguage.PageTypeId = test3.SuObject.ObjectId;
                PageTypeLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewPageTypeLanguage = _PageTypeLanguage.AddPageTypeLanguage(PageTypeLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var test1 = (from c in _PageTypeLanguage.GetAllPageTypeLanguages()
                         join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                         where c.Id == Id
                         select new SuObjectVM
                         {
                             Id = c.Id
                            ,
                             Name = c.Name
                            ,
                             Description = c.Description
                            ,
                             MouseOver = c.MouseOver
                            ,
                             Language = l.LanguageName
                            ,
                             ObjectId = c.PageTypeId

                         }).First();

            var PageTypeAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = test1 //, a = PageTypeList
            };
            return View(test1);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var PageTypeLanguage = _PageTypeLanguage.GetPageTypeLanguage(test3.Id);
                PageTypeLanguage.Name = test3.Name;
                PageTypeLanguage.Description = test3.Description;
                PageTypeLanguage.MouseOver = test3.MouseOver;
                _PageTypeLanguage.UpdatePageTypeLanguage(PageTypeLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.PageType.PageTypeId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.ObjectId.ToString() });
        }
        [HttpGet]
        public IActionResult LanguageDelete(int Id)
        {
            var PageTypeLanguage = _PageTypeLanguage.DeletePageTypeLanguage(Id);
            var a = new SuObjectVM();
            a.Id = PageTypeLanguage.Id;
            a.Name = PageTypeLanguage.Name;
            a.Description = PageTypeLanguage.Description;
            a.MouseOver = PageTypeLanguage.MouseOver;
            a.LanguageId = PageTypeLanguage.LanguageId;
            a.ObjectId = PageTypeLanguage.PageTypeId;
            return View(a);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectVM a)
        {
            if (ModelState.IsValid)
            {

                _PageTypeLanguage.DeletePageTypeLanguage(a.Id);
                return RedirectToAction("LanguageIndex", new { Id = a.ObjectId });
            }
            return RedirectToAction("Index");

        }
    }
}
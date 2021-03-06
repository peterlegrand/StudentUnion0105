﻿using Microsoft.AspNetCore.Identity;
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
    public class PageController : PortalController
    {
        private readonly IPageLanguageRepository _PageLanguage;
        private readonly IPageRepository _Page;
        private readonly IPageLanguageRepository _pageLanguage;
        private readonly IPageStatusRepository _PageStatus;
        private readonly IPageTypeRepository _PageType;
        private readonly IPageTypeLanguageRepository _PageTypeLanguage;
        private readonly SuDbContext _context;

        public PageController(UserManager<SuUserModel> userManager
            , IPageLanguageRepository PageLanguage
            , IPageRepository Page
            , ILanguageRepository language
            , IPageLanguageRepository pageLanguage
            , IPageStatusRepository PageStatus
            , IPageTypeRepository PageType
            , IPageTypeLanguageRepository PageTypeLanguage
            , SuDbContext context) : base(userManager, language)
        {
            _PageLanguage = PageLanguage;
            _Page = Page;
            _pageLanguage = pageLanguage;
            _PageStatus = PageStatus;
            _PageType = PageType;
            _PageTypeLanguage = PageTypeLanguage;
            _context = context;
            //            _PageStructure = PageStructure;
        }

       
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);

            var Page = _context.ZdbObjectIndexGet.FromSql("PageIndexGet @LanguageId", parameter).ToList();
            return View(Page);


            //var Pages = (

            //    from l in _PageLanguage.GetAllPageLanguages()

            //    where l.LanguageId == DefaultLanguageID
            //    select new SuObjectVM


            //    {
            //        Id = l.PageId
            //                 ,
            //        Name = l.Name
            //    }).ToList();
            //return View(Pages);
        }


        public async Task<IActionResult> Index2()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);

            var Pages = (

                from l in _PageLanguage.GetAllPageLanguages()

                where l.LanguageId == CurrentUser.DefaultLanguageId
                select new SuObjectVM


                {
                    Id = l.PageId
                             ,
                    Name = l.Name
                }).ToList();
            return View(Pages);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);


            //var ParentPage = _Page.GetPage(Id);

            var StatusList = new List<SelectListItem>();

            foreach (var StatusFromDb in _PageStatus.GetAllPageStatus())
            {
                StatusList.Add(new SelectListItem
                {
                    Text = StatusFromDb.Name,
                    Value = StatusFromDb.Id.ToString()
                });
            }

            //wwwwwwwwwwwwwwwwwwwwwwwwww
            var ToForm = (from o in _PageType.GetAllPageTypes()
                         join l in _PageTypeLanguage.GetAllPageTypeLanguages()
                         on o.Id equals l.PageTypeId
                         where l.LanguageId == CurrentUser.DefaultLanguageId
                          select new SuObjectVM
                         {
                             Id = o.Id
                            ,
                             Name = l.Name
                         }).ToList();

            var TypeList = new List<SelectListItem>();
            foreach (var TypeFromDb in ToForm)
            {
                TypeList.Add(new SelectListItem
                {
                    Text = TypeFromDb.Name,
                    Value = TypeFromDb.Id.ToString()
                });
            }
            //wwwwwwwwwwwwwwwwwwwwwwww

            //SuObjectVM Parent = new SuObjectVM()
            //{
            //    NullId = ParentPage == null ? 0 : ParentPage.Id,
            //    LanguageId = DefaultLanguageID

            //};
            var Page = new SuPageEditGetModel();
            var PageAndLists = new SuPageEditGetWithListModel { Page = Page, StatusList= StatusList, TypeList= TypeList };
            return View(PageAndLists);
        }



        [HttpPost]
        public async Task<IActionResult> Create(SuPageEditGetWithListModel FromForm)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);

            var UserId = CurrentUser.Id;
            if (ModelState.IsValid)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@PageStatusId", FromForm.Page.PageStatusId ),
                new SqlParameter("@PageTypeId", FromForm.Page.PageTypeId),
                new SqlParameter("@ShowTitle", FromForm.Page.ShowTitleName),
                new SqlParameter("@ShowDescription", FromForm.Page.ShowTitleDescription),
                new SqlParameter("@UserId", UserId ),
                new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId),
                new SqlParameter("@Name", FromForm.Page.Name ?? ""),
                new SqlParameter("@Description", FromForm.Page.Description ?? ""),
                new SqlParameter("@MouseOver", FromForm.Page.MouseOver ?? ""),
                new SqlParameter("@MenuName", FromForm.Page.MenuName ?? ""),
                new SqlParameter("@Title", FromForm.Page.TitleName ?? ""),
                new SqlParameter("@PageDescription", FromForm.Page.TitleDescription ?? ""),
            };

                _context.Database.ExecuteSqlCommand("PageCreatePost @PageStatusId, @PageTypeId, @ShowTitle, @ShowDescription, @UserId, @LanguageId, @Name, @Description, @MouseOver, @MenuName, @Title, @PageDescription", parameters);


            }
            return RedirectToAction("Index");



        }



        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);


            var PageDetails = (from s in _Page.GetAllPages()
                               join t in _PageLanguage.GetAllPageLanguages()
                               on s.Id equals t.PageId
                               where t.LanguageId == CurrentUser.DefaultLanguageId && s.Id == Id
                               select new SuObjectVM
                               {
                                   Id = s.Id
                                  ,
                                   Name = t.Name
                                  ,
                                   Status = s.PageStatusId
                                  ,
                                   ObjectLanguageId = t.Id
                                  ,
                                   Description = t.Description
                                  ,
                                   MouseOver = t.MouseOver
                                   ,
                                   PageDescription = t.TitleDescription
//                                   ,
//                                   MouseOver = t.Title
                               }).First();

            var PageList = new List<SelectListItem>();

            foreach (var PageFromDb in _PageStatus.GetAllPageStatus())
            {
                PageList.Add(new SelectListItem
                {
                    Text = PageFromDb.Name,
                    Value = PageFromDb.Id.ToString()
                });
            }

            //wwwwwwwwwwwwwwwwwwwwwwwwww
            var TypeList = (from o in _PageType.GetAllPageTypes()
                            join l in _PageTypeLanguage.GetAllPageTypeLanguages()
                            on o.Id equals l.PageTypeId
                            where l.LanguageId == CurrentUser.DefaultLanguageId
                            select new SuObjectVM
                            {
                                Id = o.Id
                               ,
                                Name = l.Name
                            }).ToList();

            var TypeListItem = new List<SelectListItem>();
            foreach (var TypeFromDb in TypeList)
            {
                TypeListItem.Add(new SelectListItem
                {
                    Text = TypeFromDb.Name,
                    Value = TypeFromDb.Id.ToString()
                });
            }
            //wwwwwwwwwwwwwwwwwwwwwwww

            var PageAndStatus = new SuObjectAndStatusViewModel { SuObject = PageDetails, SomeKindINumSelectListItem = PageList, ProbablyTypeListItem = TypeListItem };
            return View(PageAndStatus);



        }



        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var Page = _Page.GetPage(FromForm.SuObject.Id);
                var CurrentUser = await _userManager.GetUserAsync(User);

                Page.ModifiedDate = DateTime.Now;
                Page.ModifierId = CurrentUser.Id;
                _Page.UpdatePage(Page);

    
                var PageLanguage = _PageLanguage.GetPageLanguage(FromForm.SuObject.ObjectLanguageId);
                PageLanguage.Name = FromForm.SuObject.Name;
                PageLanguage.Description = FromForm.SuObject.Description;
                PageLanguage.MouseOver = FromForm.SuObject.MouseOver;
                PageLanguage.TitleName = FromForm.SuObject.MouseOver;
                PageLanguage.TitleDescription = FromForm.SuObject.PageDescription;
                PageLanguage.ModifiedDate = DateTime.Now;
                PageLanguage.ModifierId = CurrentUser.Id;
                _PageLanguage.UpdatePageLanguage(PageLanguage);

            }
            return RedirectToAction("Index");



        }


        public async Task<IActionResult> LanguageIndex(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("PageLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);


        }



        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@Id", Id);
            var LanguageList = _context.ZdbLanguageCreateGetLanguageList.FromSql("PageLanguageCreateGetLanguageList @Id", parameter).ToList();

            List<SelectListItem> LList = new List<SelectListItem>();
            foreach (var Language in LanguageList)
            {
                LList.Add(new SelectListItem { Value = Language.Value, Text = Language.Text });
            }

            if (LList.Count() == 0)
            {
                return RedirectToAction("LanguageIndex", new { Id });
            }
            SuObjectLanguageEditGetModel Page = new SuObjectLanguageEditGetModel
            {
                OId = Id
            };
            ViewBag.Id = Id.ToString();
            var PageAndStatus = new SuObjectLanguageEditGetWitLanguageListModel
            {
                SuObject = Page
                ,
                LanguageList = LList
            };
            return View(PageAndStatus);

            //List<int> LanguagesAlready = new List<int>();
            //LanguagesAlready = (from c in _PageLanguage.GetAllPageLanguages()
            //                    where c.PageId == Id
            //                    select c.LanguageId).ToList();


            //var SuLanguage = (from l in _language.GetAllLanguages()
            //                  where !LanguagesAlready.Contains(l.Id)
            //                  && l.Active
            //                  select new SelectListItem
            //                  {
            //                      Value = l.Id.ToString()
            //                  ,
            //                      Text = l.LanguageName
            //                  }).ToList();

            //if (SuLanguage.Count() == 0)
            //{
            //    return RedirectToAction("LanguageIndex", new { Id });
            //}
            //SuObjectVM SuObject = new SuObjectVM
            //{
            //    ObjectId = Id
            //};
            //ViewBag.Id = Id.ToString();
            //var PageAndStatus = new SuObjectAndStatusViewModel
            //{
            //    SuObject = SuObject
            //    ,
            //    SomeKindINumSelectListItem = SuLanguage
            //};
            //return View(PageAndStatus);
        }



        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var PageLanguage = new SuPageLanguageModel
                {
                    Name = FromForm.SuObject.Name,
                    Description = FromForm.SuObject.Description,
                    MouseOver = FromForm.SuObject.MouseOver
                };
                PageLanguage.MouseOver = FromForm.SuObject.MouseOver;
                PageLanguage.MenuName = FromForm.SuObject.MenuName;
                PageLanguage.TitleName = FromForm.SuObject.Title;
                PageLanguage.TitleDescription = FromForm.SuObject.PageDescription;
                PageLanguage.PageId = FromForm.SuObject.ObjectId;
                PageLanguage.LanguageId = FromForm.SuObject.LanguageId;

                _PageLanguage.AddPageLanguage(PageLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }



        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@Id", Id);

            var PageLanguage = _context.ZdbPageLanguageEditGet.FromSql("PageLanguageEditGet @Id", parameter).First();
            return View(PageLanguage);


            //            var ToForm = (from c in _PageLanguage.GetAllPageLanguages()
            //                         join l in _language.GetAllLanguages()
            //                         on c.LanguageId equals l.Id
            //                         where c.Id == Id
            //                         select new SuObjectVM
            //                         {
            //                             Id = c.Id
            //                            ,
            //                             Name = c.Name
            //                            ,
            //                             Description = c.Description
            //                            ,
            //                             MouseOver = c.MouseOver
            //                            ,
            //                             Language = l.LanguageName
            ////,
            //// MenuName = l.Title
            //,
            //                             PageDescription = c.TitleDescription
            //                            ,
            //                             ObjectId = c.PageId

            //                         }).First();

            //            var PageAndStatus = new SuObjectAndStatusViewModel
            //            {
            //                SuObject = ToForm //, a = PageList
            //            };
            //            return View(ToForm);


        }



        [HttpPost]
        public IActionResult LanguageEdit(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var PageLanguage = _PageLanguage.GetPageLanguage(FromForm.Id);
                PageLanguage.Name = FromForm.Name;
                PageLanguage.Description = FromForm.Description;
                PageLanguage.TitleName = FromForm.MouseOver;
                PageLanguage.TitleDescription = FromForm.PageDescription;
                PageLanguage.MouseOver = FromForm.MouseOver;
                _PageLanguage.UpdatePageLanguage(PageLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+FromForm.Page.PageId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = FromForm.ObjectId.ToString() });
        }



        [HttpGet]
        public async Task<IActionResult> LanguageDelete(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus x = new Menus(_context);
            ViewBag.menuItems = await x.TopMenu(DefaultLanguageID);


            var PageLanguage = _pageLanguage.DeletePageLanguage(Id);
            var a = new SuObjectVM
            {
                Id = PageLanguage.Id,
                Name = PageLanguage.Name,
                Description = PageLanguage.Description,
                MouseOver = PageLanguage.MouseOver,
                LanguageId = PageLanguage.LanguageId,
                ObjectId = PageLanguage.PageId
            };
            return View(a);
        }



        [HttpPost]
        public IActionResult LanguageDelete(SuObjectVM a)
        {
            if (ModelState.IsValid)
            {

                _pageLanguage.DeletePageLanguage(a.Id);
                return RedirectToAction("LanguageIndex", new { Id = a.ObjectId });
            }
            return RedirectToAction("Index");

        }



        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);


            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@Id", Id)
                };

            var Page = _context.ZDbPageDeleteGet.FromSql("PageDeleteGet @LanguageId, @Id", parameters).First();

            return View(Page);
        }
        [HttpPost]
        public IActionResult Delete(SuPageDeleteGetModel FromForm)
        {
            _context.Database.ExecuteSqlCommand($"PageDeletePost {FromForm.Id}");

            return RedirectToAction("Index");

        }

    }
}
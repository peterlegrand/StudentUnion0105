﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Models.ViewModels;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class PageSectionController : PortalController
    {
        private readonly IPageSectionRepository _pageSection;
        private readonly IPageSectionLanguageRepository _pageSectionLanguage;
        private readonly IPageSectionTypeRepository _pageSectionType;
        private readonly IPageSectionTypeLanguageRepository _pageSectionTypeLanguage;
        private readonly IContentTypeRepository _contentType;
        private readonly IContentTypeLanguageRepository _contentTypeLanguage;
        private readonly SuDbContext _context;

        public PageSectionController(UserManager<SuUserModel> userManager
            , IPageSectionRepository PageSection
            , IPageSectionLanguageRepository PageSectionLanguage
            , ILanguageRepository language
            , IPageSectionTypeRepository pageSectionType
            , IPageSectionTypeLanguageRepository pageSectionTypeLanguage
            , IContentTypeRepository contentType
            , IContentTypeLanguageRepository contentTypeLanguage
            , SuDbContext context) : base(userManager, language)
        {
            _pageSection = PageSection;
            _pageSectionLanguage = PageSectionLanguage;
            _pageSectionType = pageSectionType;
            _pageSectionTypeLanguage = pageSectionTypeLanguage;
            _contentType = contentType;
            _contentTypeLanguage = contentTypeLanguage;
            _context = context;
        }
        
        
        public async Task<IActionResult> Index(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


            SqlParameter[] parameters =
    {
                    new SqlParameter("@Id", Id)
                    , new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                };

            var SectionType = _context.ZdbObjectIndexGet.FromSql("PageSectionIndexGet @Id, @LanguageId", parameters).ToList();
            ViewBag.ObjectId = Id.ToString();
            return View(SectionType);

        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);


            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@Id", Id)
                };

            var PageSectionEditGet = _context.ZdbPageSectionEditGet.FromSql("PageSectionEditGet @LanguageId, @Id", parameters).First();


            var PageSection = (from c in _pageSection.GetAllPageSections()
                               join l in _pageSectionLanguage.GetAllPageSectionLanguages()
                               on c.Id equals l.PageSectionId
                               where c.Id == Id && l.LanguageId == CurrentUser.DefaultLanguageId
                               orderby c.Sequence
                               select new SuObjectVMPageSection
                               {
                                   Id = c.PageId
                                   ,
                                   ObjectId = c.Id
                                   ,
                                   LanguageId = l.LanguageId
                                   ,
                                   ObjectLanguageId = l.Id
                                   ,
                                   Type = c.PageSectionTypeId
                                   ,
                                   ShowSectionTitle = c.ShowSectionTitleName
                                   ,
                                   ShowSectionDescription = c.ShowSectionTitleDescription
                                   ,
                                   ShowContentTypeTitle = c.ShowContentTypeTitle
                                   ,
                                   ShowContentTypeTitleDescription = c.ShowContentTypeDescription
                                   ,
                                   OneTwoColumns = c.OneTwoColumns
                                   ,
                                   ContentTypeId = c.ContentTypeId
                                   ,
                                   SortById = c.SortById
                                   ,
                                   MaxContent = c.MaxContent
                                   ,
                                   HasPaging = c.HasPaging
                                   ,
                                   Sequence = c.Sequence
                                   ,
                                   Name = l.Name
                                   ,
                                   Description = l.Description
                                   ,
                                   Title = l.TitleName
                                   ,
                                   TitleDescription = l.TitleDescription
                                   ,
                                   MouseOver = l.MouseOver
                               }).First();

            //Existing levels
            List<SelectListItem> ExistingLevels = (from c in _pageSection.GetAllPageSections()
                                                   join l in _pageSectionLanguage.GetAllPageSectionLanguages()
                                                   on c.Id equals l.PageSectionId
                                                   where c.PageId == PageSection.Id
                                                   && l.LanguageId == CurrentUser.DefaultLanguageId
                                                   orderby c.Sequence
                                                   select new SelectListItem
                                                   {
                                                       Value = c.Sequence.ToString()
                                                   ,
                                                       Text = l.Name
                                                   }).ToList();
            var TestForNull = (from c in _pageSection.GetAllPageSections()
                               join l in _pageSectionLanguage.GetAllPageSectionLanguages()
                               on c.Id equals l.PageSectionId
                               where c.Id == Id
                               && l.LanguageId == CurrentUser.DefaultLanguageId
                               select c.Sequence).ToList();

            int MaxLevelSequence;

            if (TestForNull.Count() == 0)
            { MaxLevelSequence = 1; }
            else
            {
                MaxLevelSequence = (from c in _pageSection.GetAllPageSections()
                                    join l in _pageSectionLanguage.GetAllPageSectionLanguages()
                                    on c.Id equals l.PageSectionId
                                    where c.Id == Id
                                    && l.LanguageId == CurrentUser.DefaultLanguageId
                                    select c.Sequence).Max();

                MaxLevelSequence++;
            }


            ExistingLevels.Add(new SelectListItem { Text = "add at bottom", Value = MaxLevelSequence.ToString() });

            //Existing levels

            //PageSectionTypes
            var ToForm = (from o in _pageSectionType.GetAllPageSectionTypes()
                         join l in _pageSectionTypeLanguage.GetAllPageSectionTypeLanguages()
                         on o.Id equals l.PageSectionTypeId
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

            //PageSectionTypes

            //ContentType
            var ContentTypes = (from o in _contentType.GetAllContentTypes()
                                join l in _contentTypeLanguage.GetAllContentTypeLanguages()
                                on o.Id equals l.ContentTypeId
                                where l.LanguageId == CurrentUser.DefaultLanguageId
                                select new SuObjectVM
                                {
                                    Id = o.Id
                                   ,
                                    Name = l.Name
                                }).ToList();

            var ContentTypeList = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "No type" }
            };
            foreach (var TypeFromDb in ContentTypes)
            {
                ContentTypeList.Add(new SelectListItem
                {
                    Text = TypeFromDb.Name,
                    Value = TypeFromDb.Id.ToString()
                });
            }

            //ContentType


            var ClassificationAndStatus = new PageSectionAndStatusViewModel { SuObject = PageSection, SomeKindINumSelectListItem = ExistingLevels, ProbablyTypeListItem = TypeList, ProbablyTypeListItem2 = ContentTypeList };
            return View(ClassificationAndStatus);

        }

        [HttpPost]
        public IActionResult Edit(PageSectionAndStatusViewModel UpdatedPageSection)
        {

            if (ModelState.IsValid)
            {
    
                _context.Database.ExecuteSqlCommand("PageSectionUpdate @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, " +
                    "@p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18, @p19, @p20",
                    parameters: new[] { UpdatedPageSection.SuObject.ObjectId.ToString()           //0
                                        ,UpdatedPageSection.SuObject.Sequence.ToString()    //1
                    , UpdatedPageSection.SuObject.ContentTypeId.ToString()                  //2
                    , UpdatedPageSection.SuObject.HasPaging.ToString()                      //3
                    , UpdatedPageSection.SuObject.MaxContent.ToString()                     //4
                    , UpdatedPageSection.SuObject.OneTwoColumns.ToString()                  //5
                    , UpdatedPageSection.SuObject.Type.ToString()                           //6
                    , UpdatedPageSection.SuObject.ShowContentTypeTitle.ToString()           //7
                    , UpdatedPageSection.SuObject.ShowContentTypeTitleDescription.ToString()//8
                    , UpdatedPageSection.SuObject.ShowContentTypeTitle.ToString()           //9
                    , UpdatedPageSection.SuObject.ShowContentTypeTitleDescription.ToString()//10
                    , UpdatedPageSection.SuObject.SortById.ToString()                       //11
                    , UpdatedPageSection.SuObject.LanguageId.ToString()                     //12
                    , UpdatedPageSection.SuObject.Name                                      //13
                    , UpdatedPageSection.SuObject.Description                               //14
                    , UpdatedPageSection.SuObject.Title                          //15
                    , UpdatedPageSection.SuObject.TitleDescription               //16
                    , UpdatedPageSection.SuObject.MouseOver                                 //17
                    , DateTimeOffset.Now.ToString()                                         //18
                    , UpdatedPageSection.SuObject.ObjectLanguageId.ToString()               //19
                    , UpdatedPageSection.SuObject.Id.ToString()                             //20

                    });


            }

            return RedirectToAction("Index", new { Id = UpdatedPageSection.SuObject.Id.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);


            SuObjectVMPageSection SuObject = new SuObjectVMPageSection
            {
                ObjectId = Id
            };

            List<SelectListItem> ExistingLevels = (from c in _pageSection.GetAllPageSections()
                                                   join l in _pageSectionLanguage.GetAllPageSectionLanguages()
                                                   on c.Id equals l.PageSectionId
                                                   where c.PageId == Id
                                                   && l.LanguageId == CurrentUser.DefaultLanguageId
                                                   orderby c.Sequence
                                                   select new SelectListItem
                                                   {
                                                       Value = c.Sequence.ToString()
                                                   ,
                                                       Text = l.Name
                                                   }).ToList();
            var TestForNull = (from c in _pageSection.GetAllPageSections()
                               join l in _pageSectionLanguage.GetAllPageSectionLanguages()
                               on c.Id equals l.PageSectionId
                               where c.Id == Id
                               && l.LanguageId == CurrentUser.DefaultLanguageId
                               select c.Sequence).ToList();

            int MaxLevelSequence;

            if (TestForNull.Count() == 0)
            { MaxLevelSequence = 1; }
            else
            {
                MaxLevelSequence = (from c in _pageSection.GetAllPageSections()
                                    join l in _pageSectionLanguage.GetAllPageSectionLanguages()
                                    on c.Id equals l.PageSectionId
                                    where c.Id == Id
                                    && l.LanguageId == CurrentUser.DefaultLanguageId
                                    select c.Sequence).Max();

                MaxLevelSequence++;
            }


            ExistingLevels.Add(new SelectListItem { Text = "add at bottom", Value = MaxLevelSequence.ToString() });

            //PageSectionTypes
            var ToForm = (from o in _pageSectionType.GetAllPageSectionTypes()
                         join l in _pageSectionTypeLanguage.GetAllPageSectionTypeLanguages()
                         on o.Id equals l.PageSectionTypeId
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

            //PageSectionTypes

            //ContentType
            var ContentTypes = (from o in _contentType.GetAllContentTypes()
                                join l in _contentTypeLanguage.GetAllContentTypeLanguages()
                                on o.Id equals l.ContentTypeId
                                where l.LanguageId == CurrentUser.DefaultLanguageId
                                select new SuObjectVM
                                {
                                    Id = o.Id
                                   ,
                                    Name = l.Name
                                }).ToList();

            var ContentTypeList = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "No type" }
            };
            foreach (var TypeFromDb in ContentTypes)
            {
                ContentTypeList.Add(new SelectListItem
                {
                    Text = TypeFromDb.Name,
                    Value = TypeFromDb.Id.ToString()
                });
            }

            //ContentType


            var ClassificationAndStatus = new PageSectionAndStatusViewModel { SuObject = SuObject, SomeKindINumSelectListItem = ExistingLevels, ProbablyTypeListItem = TypeList, ProbablyTypeListItem2 = ContentTypeList };
            return View(ClassificationAndStatus);

        }

        [HttpPost]
        public async Task<IActionResult> Create(PageSectionAndStatusViewModel NewLevel)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
    

                var TestForNull = (

                    from l in _pageSection.GetAllPageSections()
                    where l.Id == NewLevel.SuObject.ObjectId
                    select l.Sequence).Count();

                int MaxLevelSequence;

                if (TestForNull == 0)
                { MaxLevelSequence = 1; }
                else
                {
                    MaxLevelSequence = (

                        from c in _pageSection.GetAllPageSections()
                        where c.PageId == NewLevel.SuObject.ObjectId
                        select c.Sequence).Max();
                    MaxLevelSequence++;
                }

                if (NewLevel.SuObject.Sequence != MaxLevelSequence)
                {

                    //Here need to update other levels to make sequence correct
                    //https://stackoverflow.com/questions/812630/how-can-i-reorder-rows-in-sql-database

                    List<IdAndSequence> ExistingLevels = (from c in _pageSection.GetAllPageSections()
                                                          where c.PageId == NewLevel.SuObject.ObjectId
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
                        SuPageSectionModel u = new SuPageSectionModel();
                        u = _pageSection.GetPageSection(ExistingLevels[x].Id);


                        u.Sequence = ++ExistingLevels[x].Sequence;

                        _pageSection.UpdatePageSection(u);
                        x++;

                    }
                }
                var PageSection = new SuPageSectionModel
                {
                    Sequence = NewLevel.SuObject.Sequence,
                    PageId = NewLevel.SuObject.ObjectId,
                    PageSectionTypeId = NewLevel.SuObject.Type,
                    ShowSectionTitleName = NewLevel.SuObject.ShowSectionTitle,
                    ShowSectionTitleDescription = NewLevel.SuObject.ShowSectionDescription,
                    ShowContentTypeTitle = NewLevel.SuObject.ShowContentTypeTitle,
                    ShowContentTypeDescription = NewLevel.SuObject.ShowContentTypeTitleDescription,
                    OneTwoColumns = NewLevel.SuObject.OneTwoColumns
                };
                if (NewLevel.SuObject.ContentTypeId != 0)
                    PageSection.ContentTypeId = NewLevel.SuObject.ContentTypeId;
                PageSection.SortById = NewLevel.SuObject.SortById;
                PageSection.MaxContent = NewLevel.SuObject.MaxContent;
                PageSection.HasPaging = NewLevel.SuObject.HasPaging;

                var NewPageSection = _pageSection.AddPageSection(PageSection);

                var PageSectionLanguage = new SuPageSectionLanguageModel
                {
                    Name = NewLevel.SuObject.Name,
                    Description = NewLevel.SuObject.Description,
                    TitleName = NewLevel.SuObject.Title,
                    TitleDescription = NewLevel.SuObject.TitleDescription,
                    MouseOver = NewLevel.SuObject.MouseOver,
                    PageSectionId = NewPageSection.Id,
                    LanguageId = CurrentUser.DefaultLanguageId
                };
                _pageSectionLanguage.AddPageSectionLanguage(PageSectionLanguage);

            }


            return RedirectToAction("Index", new { Id = NewLevel.SuObject.ObjectId.ToString() });

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

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("PageSectionLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);


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

            //PETER the Zdb for page and page section are the same.

            var parameter = new SqlParameter("@Id", Id);

            var PageSectionLanguage = _context.ZdbPageLanguageEditGet.FromSql("PageSectionLanguageEditGet @Id", parameter).First();
            return View(PageSectionLanguage);



        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var PageSectionLanguage = _pageSectionLanguage.GetPageSectionLanguage(test3.SuObject.Id);
                PageSectionLanguage.Name = test3.SuObject.Name;
                PageSectionLanguage.Description = test3.SuObject.Description;

                PageSectionLanguage.MouseOver = test3.SuObject.MouseOver;
                _pageSectionLanguage.UpdatePageSectionLanguage(PageSectionLanguage);


            }

            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



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

            var LanguageList = _context.ZdbLanguageCreateGetLanguageList.FromSql("PageSectionLanguageCreateGetLanguageList @Id", parameter).ToList();

            List<SelectListItem> LList = new List<SelectListItem>();
            foreach (var Language in LanguageList)
            {
                LList.Add(new SelectListItem { Value = Language.Value, Text = Language.Text });
            }

            if (LList.Count() == 0)
            {
                return RedirectToAction("LanguageIndex", new { Id });
            }
            SuObjectLanguageEditGetModel PageSection = new SuObjectLanguageEditGetModel
            {
                OId = Id
            };
            ViewBag.Id = Id.ToString();
            var PageSectionAndStatus = new SuObjectLanguageEditGetWitLanguageListModel
            {
                SuObject = PageSection
                ,
                LanguageList = LList
            };
            return View(PageSectionAndStatus);

            //List<int> LanguagesAlready = new List<int>();
            //LanguagesAlready = (from c in _pageSectionLanguage.GetAllPageSectionLanguages()
            //                    where c.PageSectionId == Id
            //                    select c.LanguageId).ToList();


            //var SuLanguage = (from l in _language.GetAllLanguages()
            //                  where !LanguagesAlready.Contains(l.Id)
            //                  && l.Active == true
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
            //var ClassificationAndStatus = new SuObjectAndStatusViewModel
            //{
            //    SuObject = SuObject
            //    ,
            //    SomeKindINumSelectListItem = SuLanguage
            //};
            //return View(ClassificationAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var PageSectionLanguage = new SuPageSectionLanguageModel
                {
                    Name = test3.SuObject.Name,
                    Description = test3.SuObject.Description,
                    MouseOver = test3.SuObject.MouseOver,
                    PageSectionId = test3.SuObject.ObjectId,
                    LanguageId = test3.SuObject.LanguageId
                };

                _pageSectionLanguage.AddPageSectionLanguage(PageSectionLanguage);
            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });
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

            var Page = _context.ZDbPageSectionDeleteGet.FromSql("PageSectionDeleteGet @LanguageId, @Id", parameters).First();

            return View(Page);
        }
        [HttpPost]
        public IActionResult Delete(SuPageDeleteGetModel FromForm)
        {
            _context.Database.ExecuteSqlCommand($"PageSectionDeletePost {FromForm.Id}");

            return RedirectToAction("Index");

        }



    }
}
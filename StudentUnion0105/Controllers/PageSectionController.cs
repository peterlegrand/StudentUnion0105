using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Models.ViewModels;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class PageSectionController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IPageSectionRepository _pageSection;
        private readonly IPageSectionLanguageRepository _pageSectionLanguage;
        private readonly ILanguageRepository _language;
        private readonly IPageSectionTypeRepository _pageSectionType;
        private readonly IPageSectionTypeLanguageRepository _pageSectionTypeLanguage;
        private readonly IContentTypeRepository _contentType;
        private readonly IContentTypeLanguageRepository _contentTypeLanguage;
        private readonly SuDbContext _context;

        public PageSectionController(UserManager<SuUser> userManager
            , IPageSectionRepository PageSection
            , IPageSectionLanguageRepository PageSectionLanguage
            , ILanguageRepository language
            , IPageSectionTypeRepository pageSectionType
            , IPageSectionTypeLanguageRepository pageSectionTypeLanguage
            , IContentTypeRepository contentType
            , IContentTypeLanguageRepository contentTypeLanguage
            , SuDbContext context)
        {
            this.userManager = userManager;
            _pageSection = PageSection;
            _pageSectionLanguage = PageSectionLanguage;
            _language = language;
            _pageSectionType = pageSectionType;
            _pageSectionTypeLanguage = pageSectionTypeLanguage;
            _contentType = contentType;
            _contentTypeLanguage = contentTypeLanguage;
            _context = context;
        }
        public async Task<IActionResult> Index(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;

            var pageSection = (from c in _pageSection.GetAllPageSections()
                               join l in _pageSectionLanguage.GetAllPageSectionLanguages()
                      on c.Id equals l.PageSectionId
                               where c.PageId == Id
                               && l.LanguageId == DefaultLanguageID
                               orderby c.Sequence
                               select new SuObjectVM
                               {
                                   Id = c.Id
                               ,
                                   Name = l.PageSectionName
                               ,
                                   ObjectId = c.PageId
                               }).ToList();
            ViewBag.ObjectId = Id.ToString();
            //PETER TODO add a classification label so you know to which classification the levels belong.
            return View(pageSection);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var PageSection = (from c in _pageSection.GetAllPageSections()
                               join l in _pageSectionLanguage.GetAllPageSectionLanguages()
                               on c.Id equals l.PageSectionId
                               where c.Id == Id && l.LanguageId == DefaultLanguageID
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
                                   ShowSectionTitle = c.ShowSectionTitle
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
                                   Name = l.PageSectionName
                                   ,
                                   Description = l.PageSectionDescription
                                   ,
                                   PageSectionTitle = l.PageSectionTitle
                                   ,
                                   PageSectionTitleDescription = l.PageSectionTitleDescription
                                   ,
                                   MouseOver = l.PageSectionMouseOver
                               }).First();

            //Existing levels
            List<SelectListItem> ExistingLevels = (from c in _pageSection.GetAllPageSections()
                                                   join l in _pageSectionLanguage.GetAllPageSectionLanguages()
                                                   on c.Id equals l.PageSectionId
                                                   where c.PageId == PageSection.Id
                                                   && l.LanguageId == DefaultLanguageID
                                                   orderby c.Sequence
                                                   select new SelectListItem
                                                   {
                                                       Value = c.Sequence.ToString()
                                                   ,
                                                       Text = l.PageSectionName
                                                   }).ToList();
            var TestForNull = (from c in _pageSection.GetAllPageSections()
                               join l in _pageSectionLanguage.GetAllPageSectionLanguages()
                               on c.Id equals l.PageSectionId
                               where c.Id == Id
                               && l.LanguageId == DefaultLanguageID
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
                                    && l.LanguageId == DefaultLanguageID
                                    select c.Sequence).Max();

                MaxLevelSequence++;
            }


            ExistingLevels.Add(new SelectListItem { Text = "add at bottom", Value = MaxLevelSequence.ToString() });

            //Existing levels

            //PageSectionTypes
            var ToForm = (from o in _pageSectionType.GetAllPageSectionTypes()
                         join l in _pageSectionTypeLanguage.GetAllPageSectionTypeLanguages()
                         on o.Id equals l.PageSectionTypeId
                         where l.LanguageId == DefaultLanguageID
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
                                where l.LanguageId == DefaultLanguageID
                                select new SuObjectVM
                                {
                                    Id = o.Id
                                   ,
                                    Name = l.Name
                                }).ToList();

            var ContentTypeList = new List<SelectListItem>();
            ContentTypeList.Add(new SelectListItem { Value = "0", Text = "No type" });
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
            //var suObjectAndStatusView = new SuObjectAndStatusViewModel
            //{

            //    SuObject = Level //, a = ClassificationList
            //};
            //return View(suObjectAndStatusView);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(PageSectionAndStatusViewModel UpdatedPageSection)
        {

            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var a = _context.Database.ExecuteSqlCommand("PageSectionUpdate @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, " +
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
                    , UpdatedPageSection.SuObject.PageSectionTitle                          //15
                    , UpdatedPageSection.SuObject.PageSectionTitleDescription               //16
                    , UpdatedPageSection.SuObject.MouseOver                                 //17
                    , DateTimeOffset.Now.ToString()                                         //18
                    , UpdatedPageSection.SuObject.ObjectLanguageId.ToString()               //19
                    , UpdatedPageSection.SuObject.Id.ToString()                             //20

                    });


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("Index", new { Id = UpdatedPageSection.SuObject.Id.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            SuObjectVMPageSection SuObject = new SuObjectVMPageSection();
            SuObject.ObjectId = Id;

            List<SelectListItem> ExistingLevels = (from c in _pageSection.GetAllPageSections()
                                                   join l in _pageSectionLanguage.GetAllPageSectionLanguages()
                                                   on c.Id equals l.PageSectionId
                                                   where c.PageId == Id
                                                   && l.LanguageId == DefaultLanguageID
                                                   orderby c.Sequence
                                                   select new SelectListItem
                                                   {
                                                       Value = c.Sequence.ToString()
                                                   ,
                                                       Text = l.PageSectionName
                                                   }).ToList();
            var TestForNull = (from c in _pageSection.GetAllPageSections()
                               join l in _pageSectionLanguage.GetAllPageSectionLanguages()
                               on c.Id equals l.PageSectionId
                               where c.Id == Id
                               && l.LanguageId == DefaultLanguageID
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
                                    && l.LanguageId == DefaultLanguageID
                                    select c.Sequence).Max();

                MaxLevelSequence++;
            }


            ExistingLevels.Add(new SelectListItem { Text = "add at bottom", Value = MaxLevelSequence.ToString() });

            //PageSectionTypes
            var ToForm = (from o in _pageSectionType.GetAllPageSectionTypes()
                         join l in _pageSectionTypeLanguage.GetAllPageSectionTypeLanguages()
                         on o.Id equals l.PageSectionTypeId
                         where l.LanguageId == DefaultLanguageID
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
                                where l.LanguageId == DefaultLanguageID
                                select new SuObjectVM
                                {
                                    Id = o.Id
                                   ,
                                    Name = l.Name
                                }).ToList();

            var ContentTypeList = new List<SelectListItem>();
            ContentTypeList.Add(new SelectListItem { Value = "0", Text = "No type" });
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
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;

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
                var PageSection = new SuPageSectionModel();
                PageSection.Sequence = NewLevel.SuObject.Sequence;
                PageSection.PageId = NewLevel.SuObject.ObjectId;
                PageSection.PageSectionTypeId = NewLevel.SuObject.Type;
                PageSection.ShowSectionTitle = NewLevel.SuObject.ShowSectionTitle;
                PageSection.ShowSectionTitleDescription = NewLevel.SuObject.ShowSectionDescription;
                PageSection.ShowContentTypeTitle = NewLevel.SuObject.ShowContentTypeTitle;
                PageSection.ShowContentTypeDescription = NewLevel.SuObject.ShowContentTypeTitleDescription;
                PageSection.OneTwoColumns = NewLevel.SuObject.OneTwoColumns;
                if (NewLevel.SuObject.ContentTypeId != 0)
                    PageSection.ContentTypeId = NewLevel.SuObject.ContentTypeId;
                PageSection.SortById = NewLevel.SuObject.SortById;
                PageSection.MaxContent = NewLevel.SuObject.MaxContent;
                PageSection.HasPaging = NewLevel.SuObject.HasPaging;

                var NewPageSection = _pageSection.AddPageSection(PageSection);

                var PageSectionLanguage = new SuPageSectionLanguageModel();

                PageSectionLanguage.PageSectionName = NewLevel.SuObject.Name;
                PageSectionLanguage.PageSectionDescription = NewLevel.SuObject.Description;
                PageSectionLanguage.PageSectionTitle = NewLevel.SuObject.PageSectionTitle;
                PageSectionLanguage.PageSectionTitleDescription = NewLevel.SuObject.PageSectionTitleDescription;
                PageSectionLanguage.PageSectionMouseOver = NewLevel.SuObject.MouseOver;
                PageSectionLanguage.PageSectionId = NewPageSection.Id;
                PageSectionLanguage.LanguageId = DefaultLanguageID;
                _pageSectionLanguage.AddPageSectionLanguage(PageSectionLanguage);

            }


            return RedirectToAction("Index", new { Id = NewLevel.SuObject.ObjectId.ToString() });

        }
        public IActionResult LanguageIndex(int Id)
        {

            var ClassificationLanguage = (from c in _pageSectionLanguage.GetAllPageSectionLanguages()
                                          join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                                          where c.PageSectionId == Id
                                          select new SuObjectVM
                                          {
                                              Id = c.Id
                                          ,
                                              Name = c.PageSectionName
                                          ,
                                              Language = l.LanguageName
                                          ,
                                              MouseOver = c.PageSectionMouseOver
                                          ,
                                              ObjectId = c.PageSectionId
                                          }).ToList();
            ViewBag.Id = Id;

            return View(ClassificationLanguage);
        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var ToForm = (from c in _pageSectionLanguage.GetAllPageSectionLanguages()
                         join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                         where c.Id == Id
                         select new SuObjectVM
                         {
                             Id = c.Id
                            ,
                             Name = c.PageSectionName
                            ,
                             Description = c.PageSectionDescription
                            ,
                             MouseOver = c.PageSectionMouseOver
                            ,
                             Language = l.LanguageName
                            ,
                             ObjectId = c.PageSectionId

                         }).First();

            var ClassificationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = ToForm //, a = ClassificationList
            };
            return View(ClassificationAndStatus);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var PageSectionLanguage = _pageSectionLanguage.GetPageSectionLanguage(test3.SuObject.Id);
                PageSectionLanguage.PageSectionName = test3.SuObject.Name;
                PageSectionLanguage.PageSectionDescription = test3.SuObject.Description;

                PageSectionLanguage.PageSectionMouseOver = test3.SuObject.MouseOver;
                _pageSectionLanguage.UpdatePageSectionLanguage(PageSectionLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _pageSectionLanguage.GetAllPageSectionLanguages()
                                where c.PageSectionId == Id
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
                var PageSectionLanguage = new SuPageSectionLanguageModel();
                PageSectionLanguage.PageSectionName = test3.SuObject.Name;
                PageSectionLanguage.PageSectionDescription = test3.SuObject.Description;
                PageSectionLanguage.PageSectionMouseOver = test3.SuObject.MouseOver;
                PageSectionLanguage.PageSectionId = test3.SuObject.ObjectId;
                PageSectionLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewPageSection = _pageSectionLanguage.AddPageSectionLanguage(PageSectionLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }


    }
}
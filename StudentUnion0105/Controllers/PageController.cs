using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{
    public class PageController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IPageLanguageRepository _PageLanguage;
        private readonly IPageRepository _Page;
        private readonly ILanguageRepository _language;
        private readonly IPageStatusRepository _PageStatus;
        private readonly IPageTypeRepository _PageType;
        private readonly IPageTypeLanguageRepository _PageTypeLanguage;
        private readonly SuDbContext _context;
        //      private readonly IGetPageStructureRepository _PageStructure;

        public PageController(UserManager<SuUser> userManager
            , IPageLanguageRepository PageLanguage
            , IPageRepository Page
            , ILanguageRepository language
            , IPageStatusRepository PageStatus
            , IPageTypeRepository PageType
            , IPageTypeLanguageRepository PageTypeLanguage
            //, IGetPageStructureRepository PageStructure
            , SuDbContext context)
        {
            this.userManager = userManager;
            _PageLanguage = PageLanguage;
            _Page = Page;
            _language = language;
            _PageStatus = PageStatus;
            _PageType = PageType;
            _PageTypeLanguage = PageTypeLanguage;
            _context = context;
            //            _PageStructure = PageStructure;
        }

        //PETER probably can be deleted
        //public async Task<IActionResult> OrgStructure2()
        //{
        //    var CurrentUser = await userManager.GetUserAsync(User);
        //    var DefaultLanguageID = CurrentUser.DefaultLangauge;
        //    var a = _context.dbGetPageStructure.FromSql($"PageStructure {DefaultLanguageID}").ToList();

        //    return View(a);
        //}
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var Pages = (

                from l in  _PageLanguage.GetAllPageLanguages()

                where l.LanguageId == DefaultLanguageID
                select new SuObjectVM


                {
                    Id = l.PageId
                             ,
                    Name = l.Name
                }).ToList();
            return View(Pages);
        }
        public async Task<IActionResult> Index2()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var Pages = (

                from l in _PageLanguage.GetAllPageLanguages()

                where l.LanguageId == DefaultLanguageID
                select new SuObjectVM


                {
                    Id = l.PageId
                             ,
                    Name = l.Name
                }).ToList();
            return View(Pages);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var ParentPage = _Page.GetPage(Id);

            var StatusList = new List<SelectListItem>();

            foreach (var StatusFromDb in _PageStatus.GetAllPageStatus())
            {
                StatusList.Add(new SelectListItem
                {
                    Text = StatusFromDb.PageStatusName,
                    Value = StatusFromDb.Id.ToString()
                });
            }

            //wwwwwwwwwwwwwwwwwwwwwwwwww
            var test1 = (from o in _PageType.GetAllPageTypes()
                         join l in _PageTypeLanguage.GetAllPageTypeLanguages()
                         on o.Id equals l.PageTypeId
                         where l.LanguageId == DefaultLanguageID
                         select new SuObjectVM
                         {
                             Id = o.Id
                            ,
                             Name = l.Name
                         }).ToList();

            var TypeList = new List<SelectListItem>();
            foreach (var TypeFromDb in test1)
            {
                TypeList.Add(new SelectListItem
                {
                    Text = TypeFromDb.Name,
                    Value = TypeFromDb.Id.ToString()
                });
            }
            //wwwwwwwwwwwwwwwwwwwwwwww

            SuObjectVM Parent = new SuObjectVM()
            {
                NullId = ParentPage == null ? 0 : ParentPage.Id
            };
            var PageAndStatus = new SuObjectAndStatusViewModel { SuObject = Parent, SomeKindINumSelectListItem = StatusList, ProbablyTypeListItem = TypeList };
            return View(PageAndStatus);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var Page = new SuPageModel();
                Page.ModifiedDate = DateTime.Now;
                Page.CreatedDate = DateTime.Now;
                Page.PageStatusId = FromForm.SuObject.Status;
                Page.PageTypeId = FromForm.SuObject.Type;
                var NewPage = _Page.AddPage(Page);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var PageLanguage = new SuPageLanguageModel();

                PageLanguage.Name = FromForm.SuObject.Name;
                PageLanguage.Description = FromForm.SuObject.Description;
                PageLanguage.MouseOver = FromForm.SuObject.MouseOver;
                PageLanguage.PageTitle = FromForm.SuObject.Title;
                PageLanguage.PageDescription = FromForm.SuObject.Description2;
                PageLanguage.PageId = NewPage.Id;
                PageLanguage.LanguageId = DefaultLanguageID;
                _PageLanguage.AddPageLanguage(PageLanguage);

            }
            return RedirectToAction("Index");



        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var test1 = (from s in _Page.GetAllPages()
                         join t in _PageLanguage.GetAllPageLanguages()
                         on s.Id equals t.PageId
                         where t.LanguageId == DefaultLanguageID && s.Id == Id
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
                             Title = t.PageTitle
                             ,
                             Description2 = t.PageDescription
                         }).First();

            var PageList = new List<SelectListItem>();

            foreach (var PageFromDb in _PageStatus.GetAllPageStatus())
            {
                PageList.Add(new SelectListItem
                {
                    Text = PageFromDb.PageStatusName,
                    Value = PageFromDb.Id.ToString()
                });
            }
            var PageAndStatus = new SuObjectAndStatusViewModel { SuObject = test1, SomeKindINumSelectListItem = PageList };
            return View(PageAndStatus);




        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var Page = _Page.GetPage(test3.Id);
                var CurrentUser = await userManager.GetUserAsync(User);

                Page.ModifiedDate = DateTime.Now;
                Page.ModifierId = new Guid(CurrentUser.Id);
                _Page.UpdatePage(Page);

                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var PageLanguage = _PageLanguage.GetPageLanguage(test3.ObjectLanguageId);
                PageLanguage.Name = test3.Name;
                PageLanguage.Description = test3.Description;
                PageLanguage.MouseOver = test3.MouseOver;
                PageLanguage.PageTitle = test3.Title;
                PageLanguage.PageDescription = test3.Description2;
                PageLanguage.ModifiedDate = DateTime.Now;
                PageLanguage.ModifierId = new Guid(CurrentUser.Id);
                _PageLanguage.UpdatePageLanguage(PageLanguage);

            }
            return RedirectToAction("Index");



        }


        public IActionResult LanguageIndex(int Id)
        {

            var ContentLanguage = (from c in _PageLanguage.GetAllPageLanguages()
                                   join l in _language.GetAllLanguages()
                  on c.LanguageId equals l.Id
                                   where c.PageId == Id
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
                                       Title = c.PageTitle
,
                                       Description2 = c.PageDescription
                                   ,
                                       ObjectId = c.PageId
                                   }).ToList();
            ViewBag.Id = Id;

            return View(ContentLanguage);
        }

        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _PageLanguage.GetAllPageLanguages()
                                where c.PageId == Id
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
            var PageAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(PageAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var PageLanguage = new SuPageLanguageModel();
                PageLanguage.Name = test3.SuObject.Name;
                PageLanguage.Description = test3.SuObject.Description;
                PageLanguage.MouseOver = test3.SuObject.MouseOver;
                PageLanguage.PageTitle = test3.SuObject.Title;
                PageLanguage.PageDescription = test3.SuObject.Description2;
                PageLanguage.PageId = test3.SuObject.ObjectId;
                PageLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewPageLanguage = _PageLanguage.AddPageLanguage(PageLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var test1 = (from c in _PageLanguage.GetAllPageLanguages()
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
                             Title = c.PageTitle
,
                             Description2 = c.PageDescription
                            ,
                             ObjectId = c.PageId

                         }).First();

            var PageAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = test1 //, a = PageList
            };
            return View(test1);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var PageLanguage = _PageLanguage.GetPageLanguage(test3.Id);
                PageLanguage.Name = test3.Name;
                PageLanguage.Description = test3.Description;
                PageLanguage.MouseOver = test3.MouseOver;
                _PageLanguage.UpdatePageLanguage(PageLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Page.PageId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.ObjectId.ToString() });
        }

    }
}
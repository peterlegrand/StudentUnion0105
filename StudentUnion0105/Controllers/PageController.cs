using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class PageController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IPageLanguageRepository _PageLanguage;
        private readonly IPageRepository _Page;
        private readonly ILanguageRepository _language;
        private readonly IPageLanguageRepository _pageLanguage;
        private readonly IPageStatusRepository _PageStatus;
        private readonly IPageTypeRepository _PageType;
        private readonly IPageTypeLanguageRepository _PageTypeLanguage;
        private readonly SuDbContext _context;
        //      private readonly IGetPageStructureRepository _PageStructure;

        public PageController(UserManager<SuUserModel> userManager
            , IPageLanguageRepository PageLanguage
            , IPageRepository Page
            , ILanguageRepository language
            , IPageLanguageRepository pageLanguage
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
            _pageLanguage = pageLanguage;
            _PageStatus = PageStatus;
            _PageType = PageType;
            _PageTypeLanguage = PageTypeLanguage;
            _context = context;
            //            _PageStructure = PageStructure;
        }

       
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

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
        public async Task<IActionResult> Index2()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
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
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var ParentPage = _Page.GetPage(Id);

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
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var PageLanguage = new SuPageLanguageModel();

                PageLanguage.Name = FromForm.SuObject.Name;
                PageLanguage.Description = FromForm.SuObject.Description;
                PageLanguage.MouseOver = FromForm.SuObject.MouseOver;
                PageLanguage.Title = FromForm.SuObject.MouseOver;
                PageLanguage.PageDescription = FromForm.SuObject.PageDescription;
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
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var PageDetails = (from s in _Page.GetAllPages()
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
                                   PageDescription = t.PageDescription
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
                            where l.LanguageId == DefaultLanguageID
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
                var CurrentUser = await userManager.GetUserAsync(User);

                Page.ModifiedDate = DateTime.Now;
                Page.ModifierId = new Guid(CurrentUser.Id);
                _Page.UpdatePage(Page);

                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var PageLanguage = _PageLanguage.GetPageLanguage(FromForm.SuObject.ObjectLanguageId);
                PageLanguage.Name = FromForm.SuObject.Name;
                PageLanguage.Description = FromForm.SuObject.Description;
                PageLanguage.MouseOver = FromForm.SuObject.MouseOver;
                PageLanguage.Title = FromForm.SuObject.MouseOver;
                PageLanguage.PageDescription = FromForm.SuObject.PageDescription;
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
                                       Title = c.Title
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
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var PageLanguage = new SuPageLanguageModel();
                PageLanguage.Name = FromForm.SuObject.Name;
                PageLanguage.Description = FromForm.SuObject.Description;
                PageLanguage.MouseOver = FromForm.SuObject.MouseOver;
                PageLanguage.Title = FromForm.SuObject.MouseOver;
                PageLanguage.PageDescription = FromForm.SuObject.PageDescription;
                PageLanguage.PageId = FromForm.SuObject.ObjectId;
                PageLanguage.LanguageId = FromForm.SuObject.LanguageId;

                var NewPageLanguage = _PageLanguage.AddPageLanguage(PageLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var ToForm = (from c in _PageLanguage.GetAllPageLanguages()
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
//                             MouseOver = c.Title
//,
                             PageDescription = c.PageDescription
                            ,
                             ObjectId = c.PageId

                         }).First();

            var PageAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = ToForm //, a = PageList
            };
            return View(ToForm);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var PageLanguage = _PageLanguage.GetPageLanguage(FromForm.Id);
                PageLanguage.Name = FromForm.Name;
                PageLanguage.Description = FromForm.Description;
                PageLanguage.Title = FromForm.MouseOver;
                PageLanguage.PageDescription = FromForm.PageDescription;
                PageLanguage.MouseOver = FromForm.MouseOver;
                _PageLanguage.UpdatePageLanguage(PageLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+FromForm.Page.PageId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = FromForm.ObjectId.ToString() });
        }



    }
}
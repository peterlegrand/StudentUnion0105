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
    public class PageSectionTypeController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IPageSectionTypeLanguageRepository _PageSectionTypeLanguage;
        private readonly IPageSectionTypeRepository _PageSectionType;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public PageSectionTypeController(UserManager<SuUserModel> userManager
            , IPageSectionTypeLanguageRepository PageSectionTypeLanguage
            , IPageSectionTypeRepository PageSectionType
            , ILanguageRepository language
            , SuDbContext context)
        {
            this.userManager = userManager;
            _PageSectionTypeLanguage = PageSectionTypeLanguage;
            _PageSectionType = PageSectionType;
            _language = language;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);


            var parameter = new SqlParameter("@LanguageId", DefaultLanguageID);

            var PageSectionType = _context.ZdbObjectIndexGet.FromSql("PageSectionTypeIndexGet @LanguageId", parameter).ToList();
            return View(PageSectionType);


            //var CurrentUser = await userManager.GetUserAsync(User);
            //var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            //var PageSectionTypes = (

            //    from l in _PageSectionTypeLanguage.GetAllPageSectionTypeLanguages()

            //    where l.LanguageId == DefaultLanguageID
            //    select new SuObjectVM


            //    {
            //        Id = l.PageSectionTypeId
            //                 ,
            //        Name = l.Name
            //    }).ToList();
            //return View(PageSectionTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var PageSectionType = new SuObjectVM();
            return View(PageSectionType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var PageSectionType = new SuPageSectionTypeModel();
                PageSectionType.ModifiedDate = DateTime.Now;
                PageSectionType.CreatedDate = DateTime.Now;
                PageSectionType.IndexSection = FromForm.IndexSection;
                var NewPageSectionType = _PageSectionType.AddPageSectionType(PageSectionType);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var PageSectionTypeLanguage = new SuPageSectionTypeLanguageModel();

                PageSectionTypeLanguage.Name = FromForm.Name;
                PageSectionTypeLanguage.Description = FromForm.MenuName;
                PageSectionTypeLanguage.MouseOver = FromForm.MouseOver;
                PageSectionTypeLanguage.PageSectionTypeId = NewPageSectionType.Id;
                PageSectionTypeLanguage.LanguageId = DefaultLanguageID;
                _PageSectionTypeLanguage.AddPageSectionTypeLanguage(PageSectionTypeLanguage);

            }
            return RedirectToAction("Index");



        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var ToForm = (from s in _PageSectionType.GetAllPageSectionTypes()
                         join t in _PageSectionTypeLanguage.GetAllPageSectionTypeLanguages()
                         on s.Id equals t.PageSectionTypeId
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
                             ,
                             IndexSection = s.IndexSection
                         }).First();

            return View(ToForm);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var PageSectionType = _PageSectionType.GetPageSectionType(test3.Id);
                var CurrentUser = await userManager.GetUserAsync(User);

                PageSectionType.ModifiedDate = DateTime.Now;
                PageSectionType.ModifierId = new Guid(CurrentUser.Id);
                PageSectionType.IndexSection = test3.IndexSection;
                _PageSectionType.UpdatePageSectionType(PageSectionType);

                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var PageSectionTypeLanguage = _PageSectionTypeLanguage.GetPageSectionTypeLanguage(test3.ObjectLanguageId);
                PageSectionTypeLanguage.Name = test3.Name;
                PageSectionTypeLanguage.Description = test3.Description;
                PageSectionTypeLanguage.MouseOver = test3.MouseOver;
                PageSectionTypeLanguage.ModifiedDate = DateTime.Now;
                PageSectionTypeLanguage.ModifierId = new Guid(CurrentUser.Id);
                _PageSectionTypeLanguage.UpdatePageSectionTypeLanguage(PageSectionTypeLanguage);

            }
            return RedirectToAction("Index");



        }


        public async Task<IActionResult> LanguageIndex(int Id)
        {

            //var PageLanguage = (from c in _PageSectionTypeLanguage.GetAllPageSectionTypeLanguages()
            //                    join l in _language.GetAllLanguages()
            //   on c.LanguageId equals l.Id
            //                    where c.PageSectionTypeId == Id
            //                    select new SuObjectVM
            //                    {
            //                        Id = c.Id
            //                    ,
            //                        Name = c.Name
            //                    ,
            //                        Language = l.LanguageName
            //                    ,
            //                        Description = c.Description
            //                    ,
            //                        MouseOver = c.MouseOver
            //                    ,
            //                        ObjectId = c.PageSectionTypeId
            //                    }).ToList();
            //ViewBag.Id = Id;

            //return View(PageLanguage);
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql($"PageSectionLanguageIndexGet {Id}").ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);


        }

        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _PageSectionTypeLanguage.GetAllPageSectionTypeLanguages()
                                where c.PageSectionTypeId == Id
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
            var PageSectionTypeAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(PageSectionTypeAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var PageSectionTypeLanguage = new SuPageSectionTypeLanguageModel();
                PageSectionTypeLanguage.Name = test3.SuObject.Name;
                PageSectionTypeLanguage.Description = test3.SuObject.Description;
                PageSectionTypeLanguage.MouseOver = test3.SuObject.MouseOver;
                PageSectionTypeLanguage.PageSectionTypeId = test3.SuObject.ObjectId;
                PageSectionTypeLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewPageSectionTypeLanguage = _PageSectionTypeLanguage.AddPageSectionTypeLanguage(PageSectionTypeLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql($"PageSectionTypeLanguageEditGet {Id}").First();
            return View(ObjectLanguage);

            //var ToForm = (from c in _PageSectionTypeLanguage.GetAllPageSectionTypeLanguages()
            //             join l in _language.GetAllLanguages()
            //             on c.LanguageId equals l.Id
            //             where c.Id == Id
            //             select new SuObjectVM
            //             {
            //                 Id = c.Id
            //                ,
            //                 Name = c.Name
            //                ,
            //                 Description = c.Description
            //                ,
            //                 MouseOver = c.MouseOver
            //                ,
            //                 Language = l.LanguageName
            //                ,
            //                 ObjectId = c.PageSectionTypeId

            //             }).First();

            //var PageSectionTypeAndStatus = new SuObjectAndStatusViewModel
            //{
            //    SuObject = ToForm //, a = PageSectionTypeList
            //};
            //return View(ToForm);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var PageSectionTypeLanguage = _PageSectionTypeLanguage.GetPageSectionTypeLanguage(test3.Id);
                PageSectionTypeLanguage.Name = test3.Name;
                PageSectionTypeLanguage.Description = test3.Description;
                PageSectionTypeLanguage.MouseOver = test3.MouseOver;
                _PageSectionTypeLanguage.UpdatePageSectionTypeLanguage(PageSectionTypeLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.PageSectionType.PageSectionTypeId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.ObjectId.ToString() });
        }
        [HttpGet]
        public IActionResult LanguageDelete(int Id)
        {
            var PageSectionTypeLanguage = _PageSectionTypeLanguage.DeletePageSectionTypeLanguage(Id);
            var a = new SuObjectVM();
            a.Id = PageSectionTypeLanguage.Id;
            a.Name = PageSectionTypeLanguage.Name;
            a.Description = PageSectionTypeLanguage.Description;
            a.MouseOver = PageSectionTypeLanguage.MouseOver;
            a.LanguageId = PageSectionTypeLanguage.LanguageId;
            a.ObjectId = PageSectionTypeLanguage.PageSectionTypeId;
            return View(a);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectVM a)
        {
            if (ModelState.IsValid)
            {

                _PageSectionTypeLanguage.DeletePageSectionTypeLanguage(a.Id);
                return RedirectToAction("LanguageIndex", new { Id = a.ObjectId });
            }
            return RedirectToAction("Index");

        }
    }
}
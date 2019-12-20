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
    public class PageTypeController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IPageTypeLanguageRepository _PageTypeLanguage;
        private readonly IPageTypeRepository _PageType;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public PageTypeController(UserManager<SuUserModel> userManager
            , IPageTypeLanguageRepository PageTypeLanguage
            , IPageTypeRepository PageType
            , ILanguageRepository language
            , SuDbContext context)
        {
            this.userManager = userManager;
            _PageTypeLanguage = PageTypeLanguage;
            _PageType = PageType;
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

            var PageType = _context.ZdbObjectIndexGet.FromSql("PageTypeIndexGet @LanguageId", parameter).ToList();
            return View(PageType);

        }

        [HttpGet]
        public async  Task<IActionResult> Create()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);


            var PageType = new SuPageTypeEditGetModel();
            return View(PageType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuPageTypeEditGetModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;

                SqlParameter[] parameters =
                    {
                    new SqlParameter("@LanguageId", DefaultLanguageID),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.Name),
                    new SqlParameter("@Description", FromForm.Description),
                    new SqlParameter("@MouseOver", FromForm.MouseOver),
                    new SqlParameter("@MenuName", FromForm.MenuName)
                    };

                _context.Database.ExecuteSqlCommand("PageTypeCreatePost " +
                            ", @LanguageId" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName"
                            , parameters);
            }

            return RedirectToAction("Index");


        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
               {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@Id", Id)
                };

            var PageTypeEditGet = _context.ZdbPageTypeEditGet.FromSql("PageTypeEditGet @LanguageId, @Id", parameters).First();


            return View(PageTypeEditGet);

            //var CurrentUser = await userManager.GetUserAsync(User);
            //var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            //var ToForm = (from s in _PageType.GetAllPageTypes()
            //             join t in _PageTypeLanguage.GetAllPageTypeLanguages()
            //             on s.Id equals t.PageTypeId
            //             where t.LanguageId == DefaultLanguageID && s.Id == Id
            //             select new SuObjectVM
            //             {
            //                 Id = s.Id
            //                ,
            //                 Name = t.Name
            //                ,
            //                 ObjectLanguageId = t.Id
            //                ,
            //                 Description = t.Description
            //                ,
            //                 MouseOver = t.MouseOver
            //             }).First();

            //return View(ToForm);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var PageType = _PageType.GetPageType(test3.Id);
                var CurrentUser = await userManager.GetUserAsync(User);

                PageType.ModifiedDate = DateTime.Now;
                PageType.ModifierId = CurrentUser.Id;
                _PageType.UpdatePageType(PageType);

                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var PageTypeLanguage = _PageTypeLanguage.GetPageTypeLanguage(test3.ObjectLanguageId);
                PageTypeLanguage.Name = test3.Name;
                PageTypeLanguage.Description = test3.Description;
                PageTypeLanguage.MouseOver = test3.MouseOver;
                PageTypeLanguage.ModifiedDate = DateTime.Now;
                PageTypeLanguage.ModifierId = CurrentUser.Id;
                _PageTypeLanguage.UpdatePageTypeLanguage(PageTypeLanguage);

            }
            return RedirectToAction("Index");



        }


        public async Task<IActionResult> LanguageIndex(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("PageTypeLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);


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
        public async Task<IActionResult> LanguageEdit(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@Id", Id);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("PageTypeLanguageEditGet @Id", parameter).First();
            return View(ObjectLanguage);


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
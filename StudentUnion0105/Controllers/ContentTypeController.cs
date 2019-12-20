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
    public class ContentTypeController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IContentTypeLanguageRepository _contentTypeLanguage;
        private readonly IContentTypeRepository _contentType;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public ContentTypeController(UserManager<SuUserModel> userManager
            , IContentTypeLanguageRepository ContentTypeLanguage
            , IContentTypeRepository contentType
            , ILanguageRepository language
                        , SuDbContext context
)
        {
            this.userManager = userManager;
            _contentTypeLanguage = ContentTypeLanguage;
            _contentType = contentType;
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

            List<SuObjectIndexGetModel> ContentType = _context.ZdbObjectIndexGet.FromSql("ContentTypeIndexGet @LanguageId", parameter).ToList();
            return View(ContentType);


            //var ContentTypes = (

            //    from l in _contentTypeLanguage.GetAllContentTypeLanguages()

            //    where l.LanguageId == DefaultLanguageID
            //    select new SuObjectVM


            //    {
            //        Id = l.ContentTypeId
            //                 ,
            //        Name = l.Name,
            //        Description = l.Description
            //    }).ToList();
            //return View(ContentTypes);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ContentType = new SuContentTypeEditGetModel();
            return View(ContentType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuContentTypeEditGetModel FromForm)
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
                    new SqlParameter("@MenuName", FromForm.MenuName),
                    new SqlParameter("@TitleName", FromForm.TitleName),
                    new SqlParameter("@TitleDescription", FromForm.TitleDescription)
                    };

                _context.Database.ExecuteSqlCommand("ContentTypeCreatePost " +
                            ", @LanguageId" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName" +
                            ", @TitleName" +
                            ", @TitleDescription" 
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

            var ContentTypeEditGet = _context.ZdbContentTypeEditGet.FromSql("ContentTypeEditGet @LanguageId, @Id", parameters).First();


            return View(ContentTypeEditGet);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuContentTypeEditGetModel FromForm)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            SqlParameter[] parameters =
                {
                    new SqlParameter("@OId", FromForm.Id),
                    new SqlParameter("@LId", FromForm.Lid),
                    new SqlParameter("@Name", FromForm.Name ?? ""),
                    new SqlParameter("@Description", FromForm.Description ?? ""),
                    new SqlParameter("@MouseOver", FromForm.MouseOver ?? ""),
                    new SqlParameter("@MenuName", FromForm.MenuName ?? ""),
                    new SqlParameter("@ModifierId", CurrentUser.Id)
                    };
            var b = _context.Database.ExecuteSqlCommand("ContentTypeEditPost " +
                        "@OId" +
                        ", @LId" +
                        ", @Name" +
                        ", @Description" +
                        ", @MouseOver" +
                        ", @MenuName" +
                        ", @ModifierId", parameters);
        
            return RedirectToAction("Index");

    }


        public async Task<IActionResult> LanguageIndex(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ContentTypeLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

        }

        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);


            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _contentTypeLanguage.GetAllContentTypeLanguages()
                                where c.ContentTypeId == Id
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
            var ContentTypeAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(ContentTypeAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var ContentTypeLanguage = new SuContentTypeLanguageModel();
                ContentTypeLanguage.Name = test3.SuObject.Name;
                ContentTypeLanguage.Description = test3.SuObject.Description;
                ContentTypeLanguage.MouseOver = test3.SuObject.MouseOver;
                ContentTypeLanguage.ContentTypeId = test3.SuObject.ObjectId;
                ContentTypeLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewContentTypeLanguage = _contentTypeLanguage.AddContentTypeLanguage(ContentTypeLanguage);


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

            SuObjectLanguageEditGetModel ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ContentTypeLanguageEditGet @Id", parameter).First();
            return View(ObjectLanguage);
        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectLanguageEditGetModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var ContentTypeLanguage = _contentTypeLanguage.GetContentTypeLanguage(FromForm.LId);
                ContentTypeLanguage.Name = FromForm.Name;
                ContentTypeLanguage.Description = FromForm.Description;
                ContentTypeLanguage.MouseOver = FromForm.MouseOver;
                _contentTypeLanguage.UpdateContentTypeLanguage(ContentTypeLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.ContentType.ContentTypeId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = FromForm.LId.ToString() });



        }
        [HttpGet]
        public IActionResult LanguageDelete(int Id)
        {
            var ContentTypeLanguage = _contentTypeLanguage.DeleteContentTypeLanguage(Id);
            var a = new SuObjectVM();
            a.Id = ContentTypeLanguage.Id;
            a.Name = ContentTypeLanguage.Name;
            a.Description = ContentTypeLanguage.Description;
            a.MouseOver = ContentTypeLanguage.MouseOver;
            a.LanguageId = ContentTypeLanguage.LanguageId;
            a.ObjectId = ContentTypeLanguage.ContentTypeId;
            return View(a);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectVM a)
        {
            if (ModelState.IsValid)
            {

                _contentTypeLanguage.DeleteContentTypeLanguage(a.Id);
                return RedirectToAction("LanguageIndex", new { Id = a.ObjectId });
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
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

            var Classification = _context.DbContentTypeDeleteGet.FromSql($"ContentTypeDeleteGet @LanguageId, @Id", parameters).First();

            return View(Classification);
        }
        [HttpPost]
        public IActionResult Delete(SuContentTypeDeleteGetModel FromForm)
        {
            var b = _context.Database.ExecuteSqlCommand($"ContentTypeDeletePost {FromForm.Id}");

            return RedirectToAction("Index");

        }


    }
}
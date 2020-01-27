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
    public class ContentTypeController : PortalController
    {
        private readonly IContentTypeLanguageRepository _contentTypeLanguage;
        private readonly IContentTypeRepository _contentType;

        public ContentTypeController(UserManager<SuUserModel> userManager
            , IContentTypeLanguageRepository ContentTypeLanguage
            , IContentTypeRepository contentType
            , ILanguageRepository language
                        , SuDbContext context
) : base(userManager, language, context)
        {
            _contentTypeLanguage = ContentTypeLanguage;
            _contentType = contentType;
        }
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();

            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);

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
        public IActionResult Create()
        {
             base.Initializing();

            var ContentType = new SuContentTypeEditGetModel();
            return View(ContentType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuContentTypeEditGetModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
    

                SqlParameter[] parameters =
                    {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId),
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
            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();

            SqlParameter[] parameters =
               {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@Id", Id)
                };

            var ContentTypeEditGet = _context.ZdbContentTypeEditGet.FromSql("ContentTypeEditGet @LanguageId, @Id", parameters).First();


            return View(ContentTypeEditGet);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuContentTypeEditGetModel FromForm)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);

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
            _context.Database.ExecuteSqlCommand("ContentTypeEditPost " +
                        "@OId" +
                        ", @LId" +
                        ", @Name" +
                        ", @Description" +
                        ", @MouseOver" +
                        ", @MenuName" +
                        ", @ModifierId", parameters);
        
            return RedirectToAction("Index");

    }


        public IActionResult LanguageIndex(int Id)
        {
           
            base.Initializing();

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ContentTypeLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

        }

        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);


            base.Initializing();


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
                return RedirectToAction("LanguageIndex", new { Id });
            }
            SuObjectVM SuObject = new SuObjectVM
            {
                ObjectId = Id
            };
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
                var ContentTypeLanguage = new SuContentTypeLanguageModel
                {
                    Name = test3.SuObject.Name,
                    Description = test3.SuObject.Description,
                    MouseOver = test3.SuObject.MouseOver,
                    ContentTypeId = test3.SuObject.ObjectId,
                    LanguageId = test3.SuObject.LanguageId
                };

                 _contentTypeLanguage.AddContentTypeLanguage(ContentTypeLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
           

            base.Initializing();

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
            var a = new SuObjectVM
            {
                Id = ContentTypeLanguage.Id,
                Name = ContentTypeLanguage.Name,
                Description = ContentTypeLanguage.Description,
                MouseOver = ContentTypeLanguage.MouseOver,
                LanguageId = ContentTypeLanguage.LanguageId,
                ObjectId = ContentTypeLanguage.ContentTypeId
            };
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
            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();

            SqlParameter[] parameters =
    {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@Id", Id)
                };

            var Classification = _context.DbContentTypeDeleteGet.FromSql($"ContentTypeDeleteGet @LanguageId, @Id", parameters).First();

            return View(Classification);
        }
        [HttpPost]
        public IActionResult Delete(SuContentTypeDeleteGetModel FromForm)
        {
            _context.Database.ExecuteSqlCommand($"ContentTypeDeletePost {FromForm.Id}");

            return RedirectToAction("Index");

        }


    }

    public class ContentTypeClassificationController : PortalController
    {
        //private readonly IContentTypeLanguageRepository _contentTypeLanguage;
        //private readonly IContentTypeRepository _contentType;

        public ContentTypeClassificationController(UserManager<SuUserModel> userManager
            //, IContentTypeLanguageRepository ContentTypeLanguage
            //, IContentTypeRepository contentType
            , ILanguageRepository language
                        , SuDbContext context
                ) : base(userManager, language, context)
        {
            //_contentTypeLanguage = ContentTypeLanguage;
            //_contentType = contentType;
        }
        public async Task<IActionResult> Index(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@Id", Id)
                };

            List<SuContentTypeClassificationIndexGetModel> ContentTypeClassification = _context.ZdbContentTypeClassificationIndexGet.FromSql("ContentTypeClassificationIndexGet @LanguageId, @Id", parameters).ToList();
            return View(ContentTypeClassification);


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

        //    [HttpGet]
        //    public IActionResult Create()
        //    {
        //        base.Initializing();

        //        var ContentType = new SuContentTypeEditGetModel();
        //        return View(ContentType);
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> Create(SuContentTypeEditGetModel FromForm)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var CurrentUser = await _userManager.GetUserAsync(User);


        //            SqlParameter[] parameters =
        //                {
        //                new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId),
        //                new SqlParameter("@ModifierId", CurrentUser.Id),
        //                new SqlParameter("@Name", FromForm.Name),
        //                new SqlParameter("@Description", FromForm.Description),
        //                new SqlParameter("@MouseOver", FromForm.MouseOver),
        //                new SqlParameter("@MenuName", FromForm.MenuName),
        //                new SqlParameter("@TitleName", FromForm.TitleName),
        //                new SqlParameter("@TitleDescription", FromForm.TitleDescription)
        //                };

        //            _context.Database.ExecuteSqlCommand("ContentTypeCreatePost " +
        //                        ", @LanguageId" +
        //                        ", @ModifierId" +
        //                        ", @Name" +
        //                        ", @Description" +
        //                        ", @MouseOver" +
        //                        ", @MenuName" +
        //                        ", @TitleName" +
        //                        ", @TitleDescription"
        //                        , parameters);
        //        }

        //        return RedirectToAction("Index");

        //    }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);

            base.Initializing();

            SqlParameter[] parameters =
               {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@Id", Id)
                };

            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);

            var ContentTypeClassificationEditGet = _context.ZdbContentTypeClassificationEditGet.FromSql("ContentTypeClassificationEditGet @LanguageId, @Id", parameters).First();
            var ContentTypeClassificationEditGetStatusList = _context.ZdbContentTypeClassificationEditGetStatusList.FromSql("ContentTypeClassificationEditGetStatusList @LanguageId", parameter).ToList();
            var TypeClassList = new List<SelectListItem>();
            foreach (var ContentTypeClassificationEditGetStatus in ContentTypeClassificationEditGetStatusList)
            {
                TypeClassList.Add(new SelectListItem
                {
                    Text = ContentTypeClassificationEditGetStatus.Name,
                    Value = ContentTypeClassificationEditGetStatus.Id.ToString()
                });
            }
            SuContentTypeClassificationEditGetModelWithListModel ContentTypeClassificationWithList = new SuContentTypeClassificationEditGetModelWithListModel();

            ContentTypeClassificationWithList.Classification = ContentTypeClassificationEditGet;
            ContentTypeClassificationWithList.StatusList = TypeClassList;

            return View(ContentTypeClassificationWithList);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuContentTypeEditGetModel FromForm)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);

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
            _context.Database.ExecuteSqlCommand("ContentTypeEditPost " +
                        "@OId" +
                        ", @LId" +
                        ", @Name" +
                        ", @Description" +
                        ", @MouseOver" +
                        ", @MenuName" +
                        ", @ModifierId", parameters);

            return RedirectToAction("Index");

        }


        //    public IActionResult LanguageIndex(int Id)
        //    {

        //        base.Initializing();

        //        var parameter = new SqlParameter("@OId", Id);

        //        var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ContentTypeLanguageIndexGet @OId", parameter).ToList();
        //        ViewBag.Id = Id;

        //        return View(LanguageIndex);

        //    }

        //    [HttpGet]
        //    public async Task<IActionResult> LanguageCreate(int Id)
        //    {

        //        var CurrentUser = await _userManager.GetUserAsync(User);


        //        base.Initializing();


        //        List<int> LanguagesAlready = new List<int>();
        //        LanguagesAlready = (from c in _contentTypeLanguage.GetAllContentTypeLanguages()
        //                            where c.ContentTypeId == Id
        //                            select c.LanguageId).ToList();


        //        var SuLanguage = (from l in _language.GetAllLanguages()
        //                          where !LanguagesAlready.Contains(l.Id)
        //                          && l.Active
        //                          select new SelectListItem
        //                          {
        //                              Value = l.Id.ToString()
        //                          ,
        //                              Text = l.LanguageName
        //                          }).ToList();

        //        if (SuLanguage.Count() == 0)
        //        {
        //            return RedirectToAction("LanguageIndex", new { Id });
        //        }
        //        SuObjectVM SuObject = new SuObjectVM
        //        {
        //            ObjectId = Id
        //        };
        //        ViewBag.Id = Id.ToString();
        //        var ContentTypeAndStatus = new SuObjectAndStatusViewModel
        //        {
        //            SuObject = SuObject
        //            ,
        //            SomeKindINumSelectListItem = SuLanguage
        //        };
        //        return View(ContentTypeAndStatus);
        //    }

        //    [HttpPost]
        //    public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var ContentTypeLanguage = new SuContentTypeLanguageModel
        //            {
        //                Name = test3.SuObject.Name,
        //                Description = test3.SuObject.Description,
        //                MouseOver = test3.SuObject.MouseOver,
        //                ContentTypeId = test3.SuObject.ObjectId,
        //                LanguageId = test3.SuObject.LanguageId
        //            };

        //            _contentTypeLanguage.AddContentTypeLanguage(ContentTypeLanguage);


        //        }
        //        return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        //    }

        //    [HttpGet]
        //    public IActionResult LanguageEdit(int Id)
        //    {


        //        base.Initializing();

        //        var parameter = new SqlParameter("@Id", Id);

        //        SuObjectLanguageEditGetModel ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ContentTypeLanguageEditGet @Id", parameter).First();
        //        return View(ObjectLanguage);
        //    }

        //    [HttpPost]
        //    public IActionResult LanguageEdit(SuObjectLanguageEditGetModel FromForm)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var ContentTypeLanguage = _contentTypeLanguage.GetContentTypeLanguage(FromForm.LId);
        //            ContentTypeLanguage.Name = FromForm.Name;
        //            ContentTypeLanguage.Description = FromForm.Description;
        //            ContentTypeLanguage.MouseOver = FromForm.MouseOver;
        //            _contentTypeLanguage.UpdateContentTypeLanguage(ContentTypeLanguage);


        //        }
        //        //            return  RedirectToRoute("EditRole" + "/"+test3.ContentType.ContentTypeId.ToString() );

        //        return RedirectToAction("LanguageIndex", new { Id = FromForm.LId.ToString() });



        //    }
        //    [HttpGet]
        //    public IActionResult LanguageDelete(int Id)
        //    {
        //        var ContentTypeLanguage = _contentTypeLanguage.DeleteContentTypeLanguage(Id);
        //        var a = new SuObjectVM
        //        {
        //            Id = ContentTypeLanguage.Id,
        //            Name = ContentTypeLanguage.Name,
        //            Description = ContentTypeLanguage.Description,
        //            MouseOver = ContentTypeLanguage.MouseOver,
        //            LanguageId = ContentTypeLanguage.LanguageId,
        //            ObjectId = ContentTypeLanguage.ContentTypeId
        //        };
        //        return View(a);
        //    }

        //    [HttpPost]
        //    public IActionResult LanguageDelete(SuObjectVM a)
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            _contentTypeLanguage.DeleteContentTypeLanguage(a.Id);
        //            return RedirectToAction("LanguageIndex", new { Id = a.ObjectId });
        //        }
        //        return RedirectToAction("Index");

        //    }

        //    [HttpGet]
        //    public async Task<IActionResult> Delete(int Id)
        //    {
        //        var CurrentUser = await _userManager.GetUserAsync(User);



        //        base.Initializing();

        //        SqlParameter[] parameters =
        //{
        //                new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
        //                , new SqlParameter("@Id", Id)
        //            };

        //        var Classification = _context.DbContentTypeDeleteGet.FromSql($"ContentTypeDeleteGet @LanguageId, @Id", parameters).First();

        //        return View(Classification);
        //    }
        //    [HttpPost]
        //    public IActionResult Delete(SuContentTypeDeleteGetModel FromForm)
        //    {
        //        _context.Database.ExecuteSqlCommand($"ContentTypeDeletePost {FromForm.Id}");

        //        return RedirectToAction("Index");

        //    }


    }

}
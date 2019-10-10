using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
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

        public ContentTypeController(UserManager<SuUserModel> userManager
            , IContentTypeLanguageRepository ContentTypeLanguage
            , IContentTypeRepository contentType
            , ILanguageRepository language)
        {
            this.userManager = userManager;
            _contentTypeLanguage = ContentTypeLanguage;
            _contentType = contentType;
            _language = language;
        }
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var ContentTypes = (

                from l in _contentTypeLanguage.GetAllContentTypeLanguages()

                where l.LanguageId == DefaultLanguageID
                select new SuObjectVM


                {
                    Id = l.ContentTypeId
                             ,
                    Name = l.Name,
                    Description = l.Description
                }).ToList();
            return View(ContentTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var ContentType = new SuObjectVM();
            return View(ContentType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var ContentType = new SuContentTypeModel();
                ContentType.ModifiedDate = DateTime.Now;
                ContentType.CreatedDate = DateTime.Now;
                var NewContentType = _contentType.AddContentType(ContentType);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var ContentTypeLanguage = new SuContentTypeLanguageModel();

                ContentTypeLanguage.Name = FromForm.Name;
                ContentTypeLanguage.Description = FromForm.Description;
                ContentTypeLanguage.MouseOver = FromForm.MouseOver;
                ContentTypeLanguage.ContentTypeId = NewContentType.Id;
                ContentTypeLanguage.LanguageId = DefaultLanguageID;
                _contentTypeLanguage.AddContentTypeLanguage(ContentTypeLanguage);

            }
            return RedirectToAction("Index");



        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var ToForm = (from s in _contentType.GetAllContentTypes()
                         join t in _contentTypeLanguage.GetAllContentTypeLanguages()
                         on s.Id equals t.ContentTypeId
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

            return View(ToForm);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var ContentType = _contentType.GetContentType(test3.Id);
                var CurrentUser = await userManager.GetUserAsync(User);

                ContentType.ModifiedDate = DateTime.Now;
                ContentType.ModifierId = new Guid(CurrentUser.Id);
                _contentType.UpdateContentType(ContentType);

                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var ContentTypeLanguage = _contentTypeLanguage.GetContentTypeLanguage(test3.ObjectLanguageId);
                ContentTypeLanguage.Name = test3.Name;
                ContentTypeLanguage.Description = test3.Description;
                ContentTypeLanguage.MouseOver = test3.MouseOver;
                ContentTypeLanguage.ModifiedDate = DateTime.Now;
                ContentTypeLanguage.ModifierId = new Guid(CurrentUser.Id);
                _contentTypeLanguage.UpdateContentTypeLanguage(ContentTypeLanguage);

            }
            return RedirectToAction("Index");



        }


        public IActionResult LanguageIndex(int Id)
        {

            var ContentLanguage = (from c in _contentTypeLanguage.GetAllContentTypeLanguages()
                                   join l in _language.GetAllLanguages()
                  on c.LanguageId equals l.Id
                                   where c.ContentTypeId == Id
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
                                       ObjectId = c.ContentTypeId
                                   }).ToList();
            ViewBag.Id = Id;

            return View(ContentLanguage);
        }

        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
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
        public IActionResult LanguageEdit(int Id)
        {
            var ToForm = (from c in _contentTypeLanguage.GetAllContentTypeLanguages()
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
                             ObjectId = c.ContentTypeId

                         }).First();

            var ContentTypeAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = ToForm //, a = ContentTypeList
            };
            return View(ToForm);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var ContentTypeLanguage = _contentTypeLanguage.GetContentTypeLanguage(test3.Id);
                ContentTypeLanguage.Name = test3.Name;
                ContentTypeLanguage.Description = test3.Description;
                ContentTypeLanguage.MouseOver = test3.MouseOver;
                _contentTypeLanguage.UpdateContentTypeLanguage(ContentTypeLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.ContentType.ContentTypeId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.ObjectId.ToString() });



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
    }
}
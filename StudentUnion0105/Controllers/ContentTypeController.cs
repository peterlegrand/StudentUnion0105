using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{
    public class ContentTypeController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IContentTypeLanguageRepository _contentTypeLanguage;
        private readonly IContentTypeRepository _contentType;
        private readonly ILanguageRepository _language;

        public ContentTypeController(UserManager<SuUser> userManager
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
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var ContentTypes = (

                from l in _contentTypeLanguage.GetAllContentTypeLanguages()

                where l.LanguageId == DefaultLanguageID
                select new SuObjectVM


                {
                    Id = l.ContentTypeId
                             ,
                    Name = l.Name
                }).ToList();
            return View(ContentTypes);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
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
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var ContentTypeLanguage = new SuContentTypeLanguageModel();

                ContentTypeLanguage.Name = FromForm.Name;
                ContentTypeLanguage.Description = FromForm.MenuName;
                ContentTypeLanguage.MouseOver = FromForm.MouseOver;
                ContentTypeLanguage.ContentTypeId = NewContentType.Id;
                ContentTypeLanguage.LanguageId = DefaultLanguageID;
                _contentTypeLanguage.AddContentTypeLanguage(ContentTypeLanguage);

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
                                          ,   Name = c.Name
                                          ,   Language = l.LanguageName
                                          ,   Description = c.Description
                                          ,   MouseOver = c.MouseOver
                                          ,   ObjectId = c.ContentTypeId
                                          }).ToList();
            ViewBag.Id = Id;

            return View(ContentLanguage);
        }


    }
}
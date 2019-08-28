using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{
    public class ContentTypeController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IContentTypeLanguageRepository _contentTypeLanguage;

        public ContentTypeController(UserManager<SuUser> userManager
            , IContentTypeLanguageRepository ContentTypeLanguage)
        {
            this.userManager = userManager;
            _contentTypeLanguage = ContentTypeLanguage;
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
    }
}
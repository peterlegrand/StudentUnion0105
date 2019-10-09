using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    public class ProcessTemplateController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IProcessTemplateLanguageRepository _processTemplateLanguage;
        private readonly IProcessTemplateRepository _processTemplate;
        private readonly IProcessTemplateGroupRepository _processTemplateGroup;
        private readonly IProcessTemplateGroupLanguageRepository _processTemplateGroupLanguage;
        private readonly SuDbContext _context;
        private readonly ILanguageRepository _language;

        public ProcessTemplateController(UserManager<SuUser> userManager
                , IProcessTemplateLanguageRepository ProcessTemplateLanguage
                , IProcessTemplateRepository ProcessTemplate
                , IProcessTemplateGroupRepository processTemplateGroup
                , IProcessTemplateGroupLanguageRepository processTemplateGroupLanguage
                , SuDbContext context
                , ILanguageRepository language
            )
        {
            this.userManager = userManager;
            _processTemplateLanguage = ProcessTemplateLanguage;
            _processTemplate = ProcessTemplate;
            _processTemplateGroup = processTemplateGroup;
            _processTemplateGroupLanguage = processTemplateGroupLanguage;
            _context = context;
            _language = language;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var ProcessTemplateList = (

                from l in _processTemplateLanguage.GetAllProcessTemplateLanguages()

                where l.LanguageId == DefaultLanguageID
                select new SuObjectVM


                {
                    Id = l.ProcessTemplateId
                             ,
                    Name = l.ProcessTemplateName
                }).ToList();
            return View(ProcessTemplateList);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var ProcessTemplateGroupList = new List<SelectListItem>();

            var ProcessTemplateGroupFromDb = _context.dbTypeList.FromSql($"GetProcessTemplateGroup {DefaultLanguageID}").ToList();

            foreach (var ProcessTemplateGroup in ProcessTemplateGroupFromDb)
            {
                ProcessTemplateGroupList.Add(new SelectListItem
                {
                    Text = ProcessTemplateGroup.Name,
                    Value = ProcessTemplateGroup.Id.ToString()
                });
            }



            var ProcessTemplateAndGroup = new SuObjectAndStatusViewModel { SomeKindINumSelectListItem = ProcessTemplateGroupList };
            return View(ProcessTemplateAndGroup);
        }


        [HttpPost]
        public async Task<IActionResult> Create(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplate = new SuProcessTemplateModel();
                ProcessTemplate.ProcessTemplateGroupId = FromForm.SuObject.NotNullId;
                var NewProcessTemplate = _processTemplate.AddProcessTemplate(ProcessTemplate);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                Guid guid = new Guid(CurrentUser.Id);

                var ProcessTemplateLanguage = new SuProcessTemplateLanguageModel();

                ProcessTemplateLanguage.ProcessTemplateName = FromForm.SuObject.Name;
                ProcessTemplateLanguage.ProcessTemplateDescription = FromForm.SuObject.Description;
                ProcessTemplateLanguage.ProcessTemplateMouseOver = FromForm.SuObject.MouseOver;
                ProcessTemplateLanguage.ProcessTemplateId = NewProcessTemplate.Id;
                ProcessTemplateLanguage.LanguageId = DefaultLanguageID;
                ProcessTemplateLanguage.ModifierId = guid;
                ProcessTemplateLanguage.CreatorId = guid;
                _processTemplateLanguage.AddProcessTemplateLanguage(ProcessTemplateLanguage);

            }
            return RedirectToAction("Index");



        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;

            var ProcessTemplateToForm = (from s in _processTemplate.GetAllProcessTemplates()
                         join t in _processTemplateLanguage.GetAllProcessTemplateLanguages()
                         on s.Id equals t.ProcessTemplateId
                         where t.LanguageId == DefaultLanguageID && s.Id == Id
                         select new SuObjectVM
                         {
                             Id = s.Id
                            ,
                             Name = t.ProcessTemplateName
                            ,
                             NotNullId = s.ProcessTemplateGroupId
                            ,
                             ObjectLanguageId = t.Id
                            ,
                             Description = t.ProcessTemplateDescription
                            ,
                             MouseOver = t.ProcessTemplateMouseOver
                         }).First();
            var ClassificationList = new List<SelectListItem>();
            //string a;
            //a = test1.Description;
            var ProcessTemplateGroupList = new List<SelectListItem>();
            var ProcessTemplateGroupFromDb = _context.dbTypeList.FromSql($"GetProcessTemplateGroup {DefaultLanguageID}").ToList();

            foreach (var ProcessTemplateGroup in ProcessTemplateGroupFromDb)
            {
                ProcessTemplateGroupList.Add(new SelectListItem
                {
                    Text = ProcessTemplateGroup.Name,
                    Value = ProcessTemplateGroup.Id.ToString()
                });
            }

                var ProcessTemplateAndGroup = new SuObjectAndStatusViewModel { SuObject= ProcessTemplateToForm, SomeKindINumSelectListItem = ProcessTemplateGroupList };
                return View(ProcessTemplateAndGroup);

            }


        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplate = _processTemplate.GetProcessTemplate(FromForm.SuObject.Id);
                ProcessTemplate.ProcessTemplateGroupId = FromForm.SuObject.NotNullId;
                _processTemplate.UpdateProcessTemplate(ProcessTemplate);

                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                Guid guid = new Guid(CurrentUser.Id);
                var ProcessTemplateLanguage = _processTemplateLanguage.GetProcessTemplateLanguage(FromForm.SuObject.ObjectLanguageId);
                ProcessTemplateLanguage.ProcessTemplateName = FromForm.SuObject.Name;
                ProcessTemplateLanguage.ProcessTemplateDescription = FromForm.SuObject.Description;
                ProcessTemplateLanguage.ProcessTemplateMouseOver = FromForm.SuObject.MouseOver;
                ProcessTemplateLanguage.ModifierId = guid;
                _processTemplateLanguage.UpdateProcessTemplateLanguage(ProcessTemplateLanguage);

            }
            return RedirectToAction("Index");

        }
        public IActionResult LanguageIndex(int Id)
        {

            var ProcessTemplateLanguage = (from c in _processTemplateLanguage.GetAllProcessTemplateLanguages()
                                          join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                                          where c.ProcessTemplateId == Id
                                          select new SuObjectVM
                                          {
                                              Id = c.Id
                                          ,
                                              Name = c.ProcessTemplateName
                                          ,
                                              Language = l.LanguageName
                                          ,
                                              MouseOver = c.ProcessTemplateMouseOver,

                                              ObjectId = c.ProcessTemplateId
                                          }).ToList();
            ViewBag.Id = Id;

            return View(ProcessTemplateLanguage);
        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var test1 = (from c in _processTemplateLanguage.GetAllProcessTemplateLanguages()
                         join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                         where c.Id == Id
                         select new SuObjectVM
                         {
                             Id = c.Id
                            ,
                             Name = c.ProcessTemplateName
                            ,
                             Description = c.ProcessTemplateDescription
                            ,
                             MouseOver = c.ProcessTemplateMouseOver
                            ,
                             Language = l.LanguageName
                            ,
                             ObjectId = c.ProcessTemplateId

                         }).First();

            var ProcessTemplateAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = test1 //, a = ProcessTemplateList
            };
            return View(ProcessTemplateAndStatus);


        }

        [HttpPost]
        public async Task<IActionResult> LanguageEdit(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                Guid guid = new Guid(CurrentUser.Id);

                var ProcessTemplateLanguage = _processTemplateLanguage.GetProcessTemplateLanguage(FromForm.SuObject.Id);
                ProcessTemplateLanguage.ProcessTemplateName = FromForm.SuObject.Name;
                ProcessTemplateLanguage.ProcessTemplateDescription = FromForm.SuObject.Description;
                ProcessTemplateLanguage.ProcessTemplateMouseOver = FromForm.SuObject.MouseOver;
                ProcessTemplateLanguage.ModifierId = guid;
                _processTemplateLanguage.UpdateProcessTemplateLanguage(ProcessTemplateLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+FromForm.ProcessTemplate.ProcessTemplateId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }



        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _processTemplateLanguage.GetAllProcessTemplateLanguages()
                                where c.ProcessTemplateId == Id
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
            var ProcessTemplateAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(ProcessTemplateAndStatus);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageCreate(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                Guid guid = new Guid(CurrentUser.Id);

                var ProcessTemplateLanguage = new SuProcessTemplateLanguageModel();
                ProcessTemplateLanguage.ProcessTemplateName = FromForm.SuObject.Name;
                ProcessTemplateLanguage.ProcessTemplateDescription = FromForm.SuObject.Description;
                ProcessTemplateLanguage.ProcessTemplateMouseOver = FromForm.SuObject.MouseOver;
                ProcessTemplateLanguage.ProcessTemplateId = FromForm.SuObject.ObjectId;
                ProcessTemplateLanguage.LanguageId = FromForm.SuObject.LanguageId;
                ProcessTemplateLanguage.ModifierId = guid;

                var NewProcessTemplate = _processTemplateLanguage.AddProcessTemplateLanguage(ProcessTemplateLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageDelete(int Id)
        {
            var ClassifationLanguage = _processTemplateLanguage.GetProcessTemplateLanguage(Id);
            var a = new SuObjectVM();
            a.Id = ClassifationLanguage.Id;
            a.Name = ClassifationLanguage.ProcessTemplateName;
            a.MouseOver = ClassifationLanguage.ProcessTemplateMouseOver;
            a.LanguageId = ClassifationLanguage.LanguageId;
            a.ObjectId = ClassifationLanguage.ProcessTemplateId;
            return View(a);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectVM a)
        {
            if (ModelState.IsValid)
            {

                _processTemplateLanguage.DeleteProcessTemplateLanguage(a.Id);
                return RedirectToAction("LanguageIndex", new { Id = a.ObjectId });
            }
            return RedirectToAction("LanguageIndex");

        }
    }
}
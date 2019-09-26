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
    public class ProcessTemplateGroupController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IProcessTemplateGroupLanguageRepository _ProcessTemplateGroupLanguage;
        private readonly IProcessTemplateGroupRepository _ProcessTemplateGroup;
        private readonly ILanguageRepository _language;

        public ProcessTemplateGroupController(UserManager<SuUser> userManager
            , IProcessTemplateGroupLanguageRepository ProcessTemplateGroupLanguage
            , IProcessTemplateGroupRepository ProcessTemplateGroup
            , ILanguageRepository language)
        {
            this.userManager = userManager;
            _ProcessTemplateGroupLanguage = ProcessTemplateGroupLanguage;
            _ProcessTemplateGroup = ProcessTemplateGroup;
            _language = language;
        }
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var ProcessTemplateGroups = (

                from l in _ProcessTemplateGroupLanguage.GetAllProcessTemplateGroupLanguages()

                where l.LanguageId == DefaultLanguageID
                select new SuObjectVM


                {
                    Id = l.ProcessTemplateGroupId
                             ,
                    Name = l.ProcessTemplateGroupName,
                    Description = l.ProcessTemplateGroupDescription
                }).ToList();
            return View(ProcessTemplateGroups);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var ProcessTemplateGroup = new SuObjectVM();
            return View(ProcessTemplateGroup);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateGroup = new SuProcessTemplateGroupModel();
                ProcessTemplateGroup.ModifiedDate = DateTime.Now;
                ProcessTemplateGroup.CreatedDate = DateTime.Now;
                var NewProcessTemplateGroup = _ProcessTemplateGroup.AddProcessTemplateGroup(ProcessTemplateGroup);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var ProcessTemplateGroupLanguage = new SuProcessTemplateGroupLanguageModel();

                ProcessTemplateGroupLanguage.ProcessTemplateGroupName = FromForm.Name;
                ProcessTemplateGroupLanguage.ProcessTemplateGroupDescription= FromForm.Description;
                ProcessTemplateGroupLanguage.ProcessTemplateGroupMouseOver = FromForm.MouseOver;
                ProcessTemplateGroupLanguage.ProcessTemplateGroupId = NewProcessTemplateGroup.Id;
                ProcessTemplateGroupLanguage.LanguageId = DefaultLanguageID;
                _ProcessTemplateGroupLanguage.AddProcessTemplateGroupLanguage(ProcessTemplateGroupLanguage);

            }
            return RedirectToAction("Index");



        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var test1 = (from s in _ProcessTemplateGroup.GetAllProcessTemplateGroups()
                         join t in _ProcessTemplateGroupLanguage.GetAllProcessTemplateGroupLanguages()
                         on s.Id equals t.ProcessTemplateGroupId
                         where t.LanguageId == DefaultLanguageID && s.Id == Id
                         select new SuObjectVM
                         {
                             Id = s.Id
                            ,
                             Name = t.ProcessTemplateGroupName
                            ,
                             ObjectLanguageId = t.Id
                            ,
                             Description = t.ProcessTemplateGroupDescription
                            ,
                             MouseOver = t.ProcessTemplateGroupMouseOver
                         }).First();

            return View(test1);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateGroup = _ProcessTemplateGroup.GetProcessTemplateGroup(test3.Id);
                var CurrentUser = await userManager.GetUserAsync(User);

                ProcessTemplateGroup.ModifiedDate = DateTime.Now;
                ProcessTemplateGroup.ModifierId = new Guid(CurrentUser.Id);
                _ProcessTemplateGroup.UpdateProcessTemplateGroup(ProcessTemplateGroup);

                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var ProcessTemplateGroupLanguage = _ProcessTemplateGroupLanguage.GetProcessTemplateGroupLanguage(test3.ObjectLanguageId);
                ProcessTemplateGroupLanguage.ProcessTemplateGroupName = test3.Name;
                ProcessTemplateGroupLanguage.ProcessTemplateGroupDescription = test3.Description;
                ProcessTemplateGroupLanguage.ProcessTemplateGroupMouseOver = test3.MouseOver;
                ProcessTemplateGroupLanguage.ModifiedDate = DateTime.Now;
                ProcessTemplateGroupLanguage.ModifierId = new Guid(CurrentUser.Id);
                _ProcessTemplateGroupLanguage.UpdateProcessTemplateGroupLanguage(ProcessTemplateGroupLanguage);

            }
            return RedirectToAction("Index");



        }


        public IActionResult LanguageIndex(int Id)
        {

            var ContentLanguage = (from c in _ProcessTemplateGroupLanguage.GetAllProcessTemplateGroupLanguages()
                                   join l in _language.GetAllLanguages()
                  on c.LanguageId equals l.Id
                                   where c.ProcessTemplateGroupId == Id
                                   select new SuObjectVM
                                   {
                                       Id = c.Id
                                   ,
                                       Name = c.ProcessTemplateGroupName
                                   ,
                                       Language = l.LanguageName
                                   ,
                                       Description = c.ProcessTemplateGroupDescription
                                   ,
                                       MouseOver = c.ProcessTemplateGroupMouseOver
                                   ,
                                       ObjectId = c.ProcessTemplateGroupId
                                   }).ToList();
            ViewBag.Id = Id;

            return View(ContentLanguage);
        }

        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _ProcessTemplateGroupLanguage.GetAllProcessTemplateGroupLanguages()
                                where c.ProcessTemplateGroupId == Id
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
            var ProcessTemplateGroupAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(ProcessTemplateGroupAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateGroupLanguage = new SuProcessTemplateGroupLanguageModel();
                ProcessTemplateGroupLanguage.ProcessTemplateGroupName = test3.SuObject.Name;
                ProcessTemplateGroupLanguage.ProcessTemplateGroupDescription = test3.SuObject.Description;
                ProcessTemplateGroupLanguage.ProcessTemplateGroupMouseOver = test3.SuObject.MouseOver;
                ProcessTemplateGroupLanguage.ProcessTemplateGroupId = test3.SuObject.ObjectId;
                ProcessTemplateGroupLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewProcessTemplateGroupLanguage = _ProcessTemplateGroupLanguage.AddProcessTemplateGroupLanguage(ProcessTemplateGroupLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var test1 = (from c in _ProcessTemplateGroupLanguage.GetAllProcessTemplateGroupLanguages()
                         join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                         where c.Id == Id
                         select new SuObjectVM
                         {
                             Id = c.Id
                            ,
                             Name = c.ProcessTemplateGroupName
                            ,
                             Description = c.ProcessTemplateGroupDescription
                            ,
                             MouseOver = c.ProcessTemplateGroupMouseOver
                            ,
                             Language = l.LanguageName
                            ,
                             ObjectId = c.ProcessTemplateGroupId

                         }).First();

            var ProcessTemplateGroupAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = test1 //, a = ProcessTemplateGroupList
            };
            return View(test1);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateGroupLanguage = _ProcessTemplateGroupLanguage.GetProcessTemplateGroupLanguage(test3.Id);
                ProcessTemplateGroupLanguage.ProcessTemplateGroupName = test3.Name;
                ProcessTemplateGroupLanguage.ProcessTemplateGroupDescription = test3.Description;
                ProcessTemplateGroupLanguage.ProcessTemplateGroupMouseOver = test3.MouseOver;
                _ProcessTemplateGroupLanguage.UpdateProcessTemplateGroupLanguage(ProcessTemplateGroupLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.ProcessTemplateGroup.ProcessTemplateGroupId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.ObjectId.ToString() });



        }
        [HttpGet]
        public IActionResult LanguageDelete(int Id)
        {
            var ProcessTemplateGroupLanguage = _ProcessTemplateGroupLanguage.DeleteProcessTemplateGroupLanguage(Id);
            var a = new SuObjectVM();
            a.Id = ProcessTemplateGroupLanguage.Id;
            a.Name = ProcessTemplateGroupLanguage.ProcessTemplateGroupName;
            a.Description = ProcessTemplateGroupLanguage.ProcessTemplateGroupDescription;
            a.MouseOver = ProcessTemplateGroupLanguage.ProcessTemplateGroupMouseOver;
            a.LanguageId = ProcessTemplateGroupLanguage.LanguageId;
            a.ObjectId = ProcessTemplateGroupLanguage.ProcessTemplateGroupId;
            return View(a);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectVM a)
        {
            if (ModelState.IsValid)
            {

                _ProcessTemplateGroupLanguage.DeleteProcessTemplateGroupLanguage(a.Id);
                return RedirectToAction("LanguageIndex", new { Id = a.ObjectId });
            }
            return RedirectToAction("Index");

        }
    }
}
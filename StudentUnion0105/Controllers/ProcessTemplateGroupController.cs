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
    public class ProcessTemplateGroupController : PortalController
    {
        private readonly IProcessTemplateGroupLanguageRepository _ProcessTemplateGroupLanguage;
        private readonly IProcessTemplateGroupRepository _ProcessTemplateGroup;
        private readonly SuDbContext _context;
        
        public ProcessTemplateGroupController(UserManager<SuUserModel> userManager
            , IProcessTemplateGroupLanguageRepository ProcessTemplateGroupLanguage
            , IProcessTemplateGroupRepository ProcessTemplateGroup
            , ILanguageRepository language
            , SuDbContext context) : base(userManager, language)
        {
            _ProcessTemplateGroupLanguage = ProcessTemplateGroupLanguage;
            _ProcessTemplateGroup = ProcessTemplateGroup;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            // MenusEtc.Initializing();

            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);

            var ProcessTemplateGroup = _context.ZdbObjectIndexGet.FromSql("ProcessTemplateGroupIndexGet @LanguageId", parameter).ToList();
            return View(ProcessTemplateGroup);


            //var ProcessTemplateGroups = (

            //    from l in _ProcessTemplateGroupLanguage.GetAllProcessTemplateGroupLanguages()

            //    where l.LanguageId == DefaultLanguageID
            //    select new SuObjectVM


            //    {
            //        Id = l.ProcessTemplateGroupId
            //                 ,
            //        Name = l.Name,
            //        Description = l.Description
            //    }).ToList();
            //return View(ProcessTemplateGroups);
        }

        [HttpGet]
        public IActionResult Create()
        {

            // MenusEtc.Initializing();

            var ProcessTemplateGroup = new SuObjectVM();
            return View(ProcessTemplateGroup);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateGroup = new SuProcessTemplateGroupModel
                {
                    ModifiedDate = DateTime.Now,
                    CreatedDate = DateTime.Now
                };
                var NewProcessTemplateGroup = _ProcessTemplateGroup.AddProcessTemplateGroup(ProcessTemplateGroup);


                var CurrentUser = await _userManager.GetUserAsync(User);

                var ProcessTemplateGroupLanguage = new SuProcessTemplateGroupLanguageModel
                {
                    Name = FromForm.Name,
                    Description = FromForm.Description,
                    MouseOver = FromForm.MouseOver,
                    ProcessTemplateGroupId = NewProcessTemplateGroup.Id,
                    LanguageId = CurrentUser.DefaultLanguageId
                };
                _ProcessTemplateGroupLanguage.AddProcessTemplateGroupLanguage(ProcessTemplateGroupLanguage);

            }
            return RedirectToAction("Index");



        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            // MenusEtc.Initializing();

            var ToForm = (from s in _ProcessTemplateGroup.GetAllProcessTemplateGroups()
                         join t in _ProcessTemplateGroupLanguage.GetAllProcessTemplateGroupLanguages()
                         on s.Id equals t.ProcessTemplateGroupId
                         where t.LanguageId == CurrentUser.DefaultLanguageId && s.Id == Id
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
                var ProcessTemplateGroup = _ProcessTemplateGroup.GetProcessTemplateGroup(test3.Id);
                var CurrentUser = await _userManager.GetUserAsync(User);

                ProcessTemplateGroup.ModifiedDate = DateTime.Now;
                ProcessTemplateGroup.ModifierId = CurrentUser.Id;
                _ProcessTemplateGroup.UpdateProcessTemplateGroup(ProcessTemplateGroup);

    
                var ProcessTemplateGroupLanguage = _ProcessTemplateGroupLanguage.GetProcessTemplateGroupLanguage(test3.ObjectLanguageId);
                ProcessTemplateGroupLanguage.Name = test3.Name;
                ProcessTemplateGroupLanguage.Description = test3.Description;
                ProcessTemplateGroupLanguage.MouseOver = test3.MouseOver;
                ProcessTemplateGroupLanguage.ModifiedDate = DateTime.Now;
                ProcessTemplateGroupLanguage.ModifierId = CurrentUser.Id;
                _ProcessTemplateGroupLanguage.UpdateProcessTemplateGroupLanguage(ProcessTemplateGroupLanguage);

            }
            return RedirectToAction("Index");



        }


        public IActionResult LanguageIndex(int Id)
        {

            // MenusEtc.Initializing();


            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ProcessTemplateGroupLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

        }

        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);



            // MenusEtc.Initializing();

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
                return RedirectToAction("LanguageIndex", new { Id });
            }
            SuObjectVM SuObject = new SuObjectVM
            {
                ObjectId = Id
            };
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
                SuProcessTemplateGroupLanguageModel ProcessTemplateGroupLanguage = new SuProcessTemplateGroupLanguageModel
                {
                    Name = test3.SuObject.Name,
                    Description = test3.SuObject.Description,
                    MouseOver = test3.SuObject.MouseOver,
                    ProcessTemplateGroupId = test3.SuObject.ObjectId,
                    LanguageId = test3.SuObject.LanguageId
                };

                _ProcessTemplateGroupLanguage.AddProcessTemplateGroupLanguage(ProcessTemplateGroupLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {

            // MenusEtc.Initializing();

            var parameter = new SqlParameter("@Id", Id);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ProcessTemplateGroupLanguageEditGet @Id", parameter).First();
            return View(ObjectLanguage);

            //var ToForm = (from c in _ProcessTemplateGroupLanguage.GetAllProcessTemplateGroupLanguages()
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
            //                 ObjectId = c.ProcessTemplateGroupId

            //             }).First();

            //var ProcessTemplateGroupAndStatus = new SuObjectAndStatusViewModel
            //{
            //    SuObject = ToForm //, a = ProcessTemplateGroupList
            //};
            //return View(ToForm);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateGroupLanguage = _ProcessTemplateGroupLanguage.GetProcessTemplateGroupLanguage(test3.Id);
                ProcessTemplateGroupLanguage.Name = test3.Name;
                ProcessTemplateGroupLanguage.Description = test3.Description;
                ProcessTemplateGroupLanguage.MouseOver = test3.MouseOver;
                _ProcessTemplateGroupLanguage.UpdateProcessTemplateGroupLanguage(ProcessTemplateGroupLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.ProcessTemplateGroup.ProcessTemplateGroupId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.ObjectId.ToString() });



        }
        [HttpGet]
        public IActionResult LanguageDelete(int Id)
        {

            // MenusEtc.Initializing();

            var ProcessTemplateGroupLanguage = _ProcessTemplateGroupLanguage.DeleteProcessTemplateGroupLanguage(Id);
            var a = new SuObjectVM
            {
                Id = ProcessTemplateGroupLanguage.Id,
                Name = ProcessTemplateGroupLanguage.Name,
                Description = ProcessTemplateGroupLanguage.Description,
                MouseOver = ProcessTemplateGroupLanguage.MouseOver,
                LanguageId = ProcessTemplateGroupLanguage.LanguageId,
                ObjectId = ProcessTemplateGroupLanguage.ProcessTemplateGroupId
            };
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
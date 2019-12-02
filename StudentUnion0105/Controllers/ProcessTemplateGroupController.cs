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
    public class ProcessTemplateGroupController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IProcessTemplateGroupLanguageRepository _ProcessTemplateGroupLanguage;
        private readonly IProcessTemplateGroupRepository _ProcessTemplateGroup;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public ProcessTemplateGroupController(UserManager<SuUserModel> userManager
            , IProcessTemplateGroupLanguageRepository ProcessTemplateGroupLanguage
            , IProcessTemplateGroupRepository ProcessTemplateGroup
            , ILanguageRepository language
            , SuDbContext context)
        {
            this.userManager = userManager;
            _ProcessTemplateGroupLanguage = ProcessTemplateGroupLanguage;
            _ProcessTemplateGroup = ProcessTemplateGroup;
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
        public async Task<IActionResult> Create()
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

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
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var ProcessTemplateGroupLanguage = new SuProcessTemplateGroupLanguageModel();

                ProcessTemplateGroupLanguage.Name = FromForm.Name;
                ProcessTemplateGroupLanguage.Description = FromForm.Description;
                ProcessTemplateGroupLanguage.MouseOver = FromForm.MouseOver;
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
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ToForm = (from s in _ProcessTemplateGroup.GetAllProcessTemplateGroups()
                         join t in _ProcessTemplateGroupLanguage.GetAllProcessTemplateGroupLanguages()
                         on s.Id equals t.ProcessTemplateGroupId
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
                var ProcessTemplateGroup = _ProcessTemplateGroup.GetProcessTemplateGroup(test3.Id);
                var CurrentUser = await userManager.GetUserAsync(User);

                ProcessTemplateGroup.ModifiedDate = DateTime.Now;
                ProcessTemplateGroup.ModifierId = new Guid(CurrentUser.Id);
                _ProcessTemplateGroup.UpdateProcessTemplateGroup(ProcessTemplateGroup);

                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var ProcessTemplateGroupLanguage = _ProcessTemplateGroupLanguage.GetProcessTemplateGroupLanguage(test3.ObjectLanguageId);
                ProcessTemplateGroupLanguage.Name = test3.Name;
                ProcessTemplateGroupLanguage.Description = test3.Description;
                ProcessTemplateGroupLanguage.MouseOver = test3.MouseOver;
                ProcessTemplateGroupLanguage.ModifiedDate = DateTime.Now;
                ProcessTemplateGroupLanguage.ModifierId = new Guid(CurrentUser.Id);
                _ProcessTemplateGroupLanguage.UpdateProcessTemplateGroupLanguage(ProcessTemplateGroupLanguage);

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

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ProcessTemplateGroupLanguageIndexGet @OId", parameter).ToList();
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
                ProcessTemplateGroupLanguage.Name = test3.SuObject.Name;
                ProcessTemplateGroupLanguage.Description = test3.SuObject.Description;
                ProcessTemplateGroupLanguage.MouseOver = test3.SuObject.MouseOver;
                ProcessTemplateGroupLanguage.ProcessTemplateGroupId = test3.SuObject.ObjectId;
                ProcessTemplateGroupLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewProcessTemplateGroupLanguage = _ProcessTemplateGroupLanguage.AddProcessTemplateGroupLanguage(ProcessTemplateGroupLanguage);


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
        public async Task<IActionResult> LanguageDelete(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ProcessTemplateGroupLanguage = _ProcessTemplateGroupLanguage.DeleteProcessTemplateGroupLanguage(Id);
            var a = new SuObjectVM();
            a.Id = ProcessTemplateGroupLanguage.Id;
            a.Name = ProcessTemplateGroupLanguage.Name;
            a.Description = ProcessTemplateGroupLanguage.Description;
            a.MouseOver = ProcessTemplateGroupLanguage.MouseOver;
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
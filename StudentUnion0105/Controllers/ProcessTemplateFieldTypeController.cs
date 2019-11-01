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
    public class ProcessTemplateFieldTypeController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IProcessTemplateFieldTypeLanguageRepository _ProcessTemplateFieldTypeLanguage;
        private readonly IProcessTemplateFieldTypeRepository _ProcessTemplateFieldType;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public ProcessTemplateFieldTypeController(UserManager<SuUserModel> userManager
            , IProcessTemplateFieldTypeLanguageRepository ProcessTemplateFieldTypeLanguage
            , IProcessTemplateFieldTypeRepository ProcessTemplateFieldType
            , ILanguageRepository language
            , SuDbContext context)
        {
            this.userManager = userManager;
            _ProcessTemplateFieldTypeLanguage = ProcessTemplateFieldTypeLanguage;
            _ProcessTemplateFieldType = ProcessTemplateFieldType;
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

            var ProcessTemplateFieldType = _context.ZdbObjectIndexGet.FromSql("ProcessTemplateFieldTypeIndexGet @LanguageId", parameter).ToList();
            return View(ProcessTemplateFieldType);

            //var ProcessTemplateFieldTypes = (

            //    from l in _ProcessTemplateFieldTypeLanguage.GetAllProcessTemplateFieldTypeLanguages()

            //    where l.LanguageId == DefaultLanguageID
            //    select new SuObjectVM


            //    {
            //        Id = l.FieldTypeId
            //                 ,
            //        Name = l.Name
            //    }).ToList();
            //return View(ProcessTemplateFieldTypes);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ProcessTemplateFieldType = new SuObjectVM();
            return View(ProcessTemplateFieldType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateFieldType = new SuProcessTemplateFieldTypeModel();
                ProcessTemplateFieldType.ModifiedDate = DateTime.Now;
                ProcessTemplateFieldType.CreatedDate = DateTime.Now;
                var NewProcessTemplateFieldType = _ProcessTemplateFieldType.AddProcessTemplateFieldType(ProcessTemplateFieldType);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var ProcessTemplateFieldTypeLanguage = new SuProcessTemplateFieldTypeLanguageModel();

                ProcessTemplateFieldTypeLanguage.Name = FromForm.Name;
                ProcessTemplateFieldTypeLanguage.Description = FromForm.Description;
                ProcessTemplateFieldTypeLanguage.MouseOver = FromForm.MouseOver;
                ProcessTemplateFieldTypeLanguage.FieldTypeId = NewProcessTemplateFieldType.Id;
                ProcessTemplateFieldTypeLanguage.LanguageId = DefaultLanguageID;
                _ProcessTemplateFieldTypeLanguage.AddProcessTemplateFieldTypeLanguage(ProcessTemplateFieldTypeLanguage);

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

            var ToForm = (from s in _ProcessTemplateFieldType.GetAllProcessTemplateFieldTypes()
                         join t in _ProcessTemplateFieldTypeLanguage.GetAllProcessTemplateFieldTypeLanguages()
                         on s.Id equals t.FieldTypeId
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
                var ProcessTemplateFieldType = _ProcessTemplateFieldType.GetProcessTemplateFieldType(test3.Id);
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;

                var UICustomizationArray = new UICustomization(_context);
                ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);


                ProcessTemplateFieldType.ModifiedDate = DateTime.Now;
                ProcessTemplateFieldType.ModifierId = new Guid(CurrentUser.Id);
                _ProcessTemplateFieldType.UpdateProcessTemplateFieldType(ProcessTemplateFieldType);

                var ProcessTemplateFieldTypeLanguage = _ProcessTemplateFieldTypeLanguage.GetProcessTemplateFieldTypeLanguage(test3.ObjectLanguageId);
                ProcessTemplateFieldTypeLanguage.Name = test3.Name;
                ProcessTemplateFieldTypeLanguage.Description = test3.Description;
                ProcessTemplateFieldTypeLanguage.MouseOver = test3.MouseOver;
                ProcessTemplateFieldTypeLanguage.ModifiedDate = DateTime.Now;
                ProcessTemplateFieldTypeLanguage.ModifierId = new Guid(CurrentUser.Id);
                _ProcessTemplateFieldTypeLanguage.UpdateProcessTemplateFieldTypeLanguage(ProcessTemplateFieldTypeLanguage);

            }
            return RedirectToAction("Index");



        }


        public async Task<IActionResult> LanguageIndex(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            //var ProcessTemplateFieldLanguage = (from c in _ProcessTemplateFieldTypeLanguage.GetAllProcessTemplateFieldTypeLanguages()
            //                            join l in _language.GetAllLanguages()
            //           on c.LanguageId equals l.Id
            //                            where c.FieldTypeId == Id
            //                            select new SuObjectVM
            //                            {
            //                                Id = c.Id
            //                            ,
            //                                Name = c.Name
            //                            ,
            //                                Language = l.LanguageName
            //                            ,
            //                                Description = c.Description
            //                            ,
            //                                MouseOver = c.MouseOver
            //                            ,
            //                                ObjectId = c.FieldTypeId
            //                            }).ToList();
            //ViewBag.Id = Id;

            //return View(ProcessTemplateFieldLanguage);
            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql($"ProcessTemplateFieldTypeLanguageIndexGet {Id}").ToList();
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
            LanguagesAlready = (from c in _ProcessTemplateFieldTypeLanguage.GetAllProcessTemplateFieldTypeLanguages()
                                where c.FieldTypeId == Id
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
            var ProcessTemplateFieldTypeAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(ProcessTemplateFieldTypeAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateFieldTypeLanguage = new SuProcessTemplateFieldTypeLanguageModel();
                ProcessTemplateFieldTypeLanguage.Name = test3.SuObject.Name;
                ProcessTemplateFieldTypeLanguage.Description = test3.SuObject.Description;
                ProcessTemplateFieldTypeLanguage.MouseOver = test3.SuObject.MouseOver;
                ProcessTemplateFieldTypeLanguage.FieldTypeId = test3.SuObject.ObjectId;
                ProcessTemplateFieldTypeLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewProcessTemplateFieldTypeLanguage = _ProcessTemplateFieldTypeLanguage.AddProcessTemplateFieldTypeLanguage(ProcessTemplateFieldTypeLanguage);


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

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql($"ProcessTemplateFieldTypeLanguageEditGet {Id}").First();
            return View(ObjectLanguage);

            //var ToForm = (from c in _ProcessTemplateFieldTypeLanguage.GetAllProcessTemplateFieldTypeLanguages()
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
            //                 ObjectId = c.FieldTypeId

            //             }).First();

            //var ProcessTemplateFieldTypeAndStatus = new SuObjectAndStatusViewModel
            //{
            //    SuObject = ToForm //, a = ProcessTemplateFieldTypeList
            //};
            //return View(ToForm);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateFieldTypeLanguage = _ProcessTemplateFieldTypeLanguage.GetProcessTemplateFieldTypeLanguage(test3.Id);
                ProcessTemplateFieldTypeLanguage.Name = test3.Name;
                ProcessTemplateFieldTypeLanguage.Description = test3.Description;
                ProcessTemplateFieldTypeLanguage.MouseOver = test3.MouseOver;
                _ProcessTemplateFieldTypeLanguage.UpdateProcessTemplateFieldTypeLanguage(ProcessTemplateFieldTypeLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.ProcessTemplateFieldType.ProcessTemplateFieldTypeId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.ObjectId.ToString() });
        }
        [HttpGet]
        public IActionResult LanguageDelete(int Id)
        {
            var ProcessTemplateFieldTypeLanguage = _ProcessTemplateFieldTypeLanguage.DeleteProcessTemplateFieldTypeLanguage(Id);
            var a = new SuObjectVM();
            a.Id = ProcessTemplateFieldTypeLanguage.Id;
            a.Name = ProcessTemplateFieldTypeLanguage.Name;
            a.Description = ProcessTemplateFieldTypeLanguage.Description;
            a.MouseOver = ProcessTemplateFieldTypeLanguage.MouseOver;
            a.LanguageId = ProcessTemplateFieldTypeLanguage.LanguageId;
            a.ObjectId = ProcessTemplateFieldTypeLanguage.FieldTypeId;
            return View(a);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectVM a)
        {
            if (ModelState.IsValid)
            {

                _ProcessTemplateFieldTypeLanguage.DeleteProcessTemplateFieldTypeLanguage(a.Id);
                return RedirectToAction("LanguageIndex", new { Id = a.ObjectId });
            }
            return RedirectToAction("Index");

        }
    }
}
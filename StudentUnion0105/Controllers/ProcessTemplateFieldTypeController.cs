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
    public class ProcessTemplateFieldTypeController : PortalController
    {
        private readonly IProcessTemplateFieldTypeLanguageRepository _ProcessTemplateFieldTypeLanguage;
        private readonly IProcessTemplateFieldTypeRepository _ProcessTemplateFieldType;
        private readonly SuDbContext _context;

        public ProcessTemplateFieldTypeController(UserManager<SuUserModel> userManager
            , IProcessTemplateFieldTypeLanguageRepository ProcessTemplateFieldTypeLanguage
            , IProcessTemplateFieldTypeRepository ProcessTemplateFieldType
            , ILanguageRepository language
            , SuDbContext context) : base(userManager, language)
        {
            _ProcessTemplateFieldTypeLanguage = ProcessTemplateFieldTypeLanguage;
            _ProcessTemplateFieldType = ProcessTemplateFieldType;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);


            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);

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

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var ProcessTemplateFieldType = new SuProcessTemplateFieldTypeEditGetModel();
            return View(ProcessTemplateFieldType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuProcessTemplateFieldTypeEditGetModel FromForm)
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
                    new SqlParameter("@MenuName", FromForm.MenuName)
                    };

                    _context.Database.ExecuteSqlCommand("ProcessTemplateFieldTypeCreatePost " +
                                "@LanguageId" +
                                ", @ModifierId" +
                                ", @Name" +
                                ", @Description" +
                                ", @MouseOver" +
                                ", @MenuName", parameters);
                }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);


            var ToForm = (from s in _ProcessTemplateFieldType.GetAllProcessTemplateFieldTypes()
                         join t in _ProcessTemplateFieldTypeLanguage.GetAllProcessTemplateFieldTypeLanguages()
                         on s.Id equals t.FieldTypeId
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

        //[HttpPost]
        //public async Task<IActionResult> Edit(SuObjectVM test3)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var ProcessTemplateFieldType = _ProcessTemplateFieldType.GetProcessTemplateFieldType(test3.Id);
        //        var CurrentUser = await _userManager.GetUserAsync(User);
        //        var DefaultLanguageID = CurrentUser.DefaultLanguageId;

        //        var UICustomizationArray = new UICustomization(_context);
        //        ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), CurrentUser.DefaultLanguageId);


        //        ProcessTemplateFieldType.ModifiedDate = DateTime.Now;
        //        ProcessTemplateFieldType.ModifierId = CurrentUser.Id;
        //        _ProcessTemplateFieldType.UpdateProcessTemplateFieldType(ProcessTemplateFieldType);

        //        var ProcessTemplateFieldTypeLanguage = _ProcessTemplateFieldTypeLanguage.GetProcessTemplateFieldTypeLanguage(test3.ObjectLanguageId);
        //        ProcessTemplateFieldTypeLanguage.Name = test3.Name;
        //        ProcessTemplateFieldTypeLanguage.Description = test3.Description;
        //        ProcessTemplateFieldTypeLanguage.MouseOver = test3.MouseOver;
        //        ProcessTemplateFieldTypeLanguage.ModifiedDate = DateTime.Now;
        //        ProcessTemplateFieldTypeLanguage.ModifierId =  CurrentUser.Id;
        //        _ProcessTemplateFieldTypeLanguage.UpdateProcessTemplateFieldTypeLanguage(ProcessTemplateFieldTypeLanguage);

        //    }
        //    return RedirectToAction("Index");



        //}


        public async Task<IActionResult> LanguageIndex(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql($"ProcessTemplateFieldTypeLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

        }

        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);



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
                return NewMethod(Id);
            SuObjectVM SuObject = new SuObjectVM
            {
                ObjectId = Id
            };
            ViewBag.Id = Id.ToString();
            var ProcessTemplateFieldTypeAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(ProcessTemplateFieldTypeAndStatus);
        }

        private IActionResult NewMethod(int Id)
        {
            return RedirectToAction("LanguageIndex", new { Id });
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateFieldTypeLanguage = new SuProcessTemplateFieldTypeLanguageModel
                {
                    Name = test3.SuObject.Name,
                    Description = test3.SuObject.Description,
                    MouseOver = test3.SuObject.MouseOver,
                    FieldTypeId = test3.SuObject.ObjectId,
                    LanguageId = test3.SuObject.LanguageId
                };

                _ProcessTemplateFieldTypeLanguage.AddProcessTemplateFieldTypeLanguage(ProcessTemplateFieldTypeLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@Id", Id);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ProcessTemplateFieldTypeLanguageEditGet @Id",parameter).First();
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
            var a = new SuObjectVM
            {
                Id = ProcessTemplateFieldTypeLanguage.Id,
                Name = ProcessTemplateFieldTypeLanguage.Name,
                Description = ProcessTemplateFieldTypeLanguage.Description,
                MouseOver = ProcessTemplateFieldTypeLanguage.MouseOver,
                LanguageId = ProcessTemplateFieldTypeLanguage.LanguageId,
                ObjectId = ProcessTemplateFieldTypeLanguage.FieldTypeId
            };
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
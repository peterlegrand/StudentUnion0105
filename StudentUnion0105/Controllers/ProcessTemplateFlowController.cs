using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{

    public class ProcessTemplateFlowController : PortalController
    {
        private readonly IProcessTemplateFlowRepository _processTemplateFlow;
        private readonly IProcessTemplateFlowLanguageRepository _processTemplateFlowLanguage;
        private readonly IProcessTemplateStepRepository _processTemplateStep;
        private readonly IProcessTemplateStepLanguageRepository _processTemplateStepLanguage;
        private readonly SuDbContext _context;

        public ProcessTemplateFlowController(UserManager<SuUserModel> userManager
            , ILanguageRepository language
            , IProcessTemplateFlowRepository processTemplateFlow
            , IProcessTemplateFlowLanguageRepository processTemplateFlowLanguage
            , IProcessTemplateStepRepository processTemplateStep
            , IProcessTemplateStepLanguageRepository processTemplateStepLanguage
            , SuDbContext context) : base(userManager, language)
        {
            _processTemplateFlow = processTemplateFlow;
            _processTemplateFlowLanguage = processTemplateFlowLanguage;
            _processTemplateStep = processTemplateStep;
            _processTemplateStepLanguage = processTemplateStepLanguage;
            _context = context;
        }
        public async Task<IActionResult> Index(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var ProcessTemplateFlow = (from p in _processTemplateFlow.GetAllProcessTemplateFlows()
                                       join l in _processTemplateFlowLanguage.GetAllProcessTemplateFlowLanguages()
                              on p.Id equals l.FlowId
                                       where p.ProcessTemplateId == Id
                                       && l.LanguageId == CurrentUser.DefaultLanguageId
                                       orderby l.Name
                                       select new SuObjectVM
                                       {
                                           Id = p.Id
                                       ,
                                           Name = l.Name
                                       ,
                                           ObjectId = p.ProcessTemplateId
                                           ,
                                           Description = p.ProcessTemplateFromStepId == 0 ? "Start" : ""
,
                                           Description2 = p.ProcessTemplateToStepId == 0 ? "End" : ""


                                       }).ToList();
            ViewBag.ObjectId = Id.ToString();


            return View(ProcessTemplateFlow);
        }
        /////////
        ///

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var Flow = (from f in _processTemplateFlow.GetAllProcessTemplateFlows()
                        join l in _processTemplateFlowLanguage.GetAllProcessTemplateFlowLanguages()
                        on f.Id equals l.FlowId
                        where f.Id == Id && l.LanguageId == CurrentUser.DefaultLanguageId
                        orderby l.Name
                        select new SuObjectVMPageSection
                        {
                            Id = f.ProcessTemplateId
                            ,
                            ObjectId = f.Id
                            ,
                            LanguageId = l.LanguageId
                            ,
                            ObjectLanguageId = l.Id
                            ,
                            Name = l.Name
                            ,
                            Description = l.Description
                            ,
                            MouseOver = l.MouseOver
                            ,
                            NotNullId = f.ProcessTemplateFromStepId
                            ,
                            NotNullId2 = f.ProcessTemplateToStepId
                        }).First();

            //Existing levels
            List<SelectListItem> StepList = (from s in _processTemplateStep.GetAllProcessTemplateSteps()
                                             join l in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                                             on s.Id equals l.StepId
                                             where l.LanguageId == CurrentUser.DefaultLanguageId
                                             && s.ProcessTemplateId == Flow.Id
                                             orderby l.Name
                                             select new SelectListItem
                                             {
                                                 Value = s.Id.ToString()
                                             ,
                                                 Text = l.Name
                                             }).ToList();



            StepList.Add(new SelectListItem { Text = "No selection", Value = "0" });


            var ClassificationAndStatus = new PageSectionAndStatusViewModel { SuObject = Flow, SomeKindINumSelectListItem = StepList };
            return View(ClassificationAndStatus);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(PageSectionAndStatusViewModel UpdatedFlow)
        {

            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);

                _context.Database.ExecuteSqlCommand("ProcessTemplateFlowUpdate @p0, @p1, @p2, @p3, @p4, @p5, @p6",
                    parameters: new[] { UpdatedFlow.SuObject.ObjectId.ToString()           //0
                                        ,UpdatedFlow.SuObject.NotNullId.ToString()    //1
                                        ,UpdatedFlow.SuObject.NotNullId2.ToString()    //1
                                        , CurrentUser.DefaultLanguageId.ToString()
                                        ,UpdatedFlow.SuObject.Name    //1
                                        ,UpdatedFlow.SuObject.Description    //1
                                        ,UpdatedFlow.SuObject.MouseOver
                                        , UpdatedFlow.SuObject.HeaderDescription//1
                    });



            }

            return RedirectToAction("Index", new { Id = UpdatedFlow.SuObject.Id.ToString() });
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            SuObjectVMPageSection SuObject = new SuObjectVMPageSection
            {
                ObjectId = Id
            };

            //Existing levels
            List<SelectListItem> StepList = (from s in _processTemplateStep.GetAllProcessTemplateSteps()
                                             join l in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                                             on s.Id equals l.StepId
                                             where l.LanguageId == CurrentUser.DefaultLanguageId
                                             && s.ProcessTemplateId == Id
                                             orderby l.Name
                                             select new SelectListItem
                                             {
                                                 Value = s.Id.ToString()
                                             ,
                                                 Text = l.Name
                                             }).ToList();



            StepList.Add(new SelectListItem { Text = "No selection", Value = "0" });



            var ClassificationAndStatus = new PageSectionAndStatusViewModel { SuObject = SuObject, SomeKindINumSelectListItem = StepList };
            return View(ClassificationAndStatus);

        }

        [HttpPost]
        public async Task<IActionResult> Create(PageSectionAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);


                _context.Database.ExecuteSqlCommand("ProcessTemplateFlowCreate @p0, @p1, @p2, @p3, @p4, @p5, @p6",
                   parameters: new[] { FromForm.SuObject.ObjectId.ToString()           //0
                                       , FromForm.SuObject.NotNullId.ToString()           //0
                                       , FromForm.SuObject.NotNullId2.ToString()           //0
                                       , CurrentUser.DefaultLanguageId.ToString()           //0
                                       , FromForm.SuObject.Name           //0
                                       , FromForm.SuObject.Description           //0
                                       , FromForm.SuObject.MouseOver           //0
                   });



            }

            return RedirectToAction("Index", new { Id = FromForm.SuObject.ObjectId.ToString() });


        }


        public async Task<IActionResult> LanguageIndex(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ProcessTemplateFlowLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

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

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ProcessTemplateFlowLanguageEditGet @Id", parameter).First();
            return View(ObjectLanguage);

            //var FlowLanguage = (from f in _processTemplateFlowLanguage.GetAllProcessTemplateFlowLanguages()
            //             join l in _language.GetAllLanguages()
            //             on f.LanguageId equals l.Id
            //             where f.Id == Id
            //             select new SuObjectVM
            //             {
            //                 Id = f.Id
            //                ,
            //                 Name = f.Name
            //                ,
            //                 Description = f.Description
            //                ,
            //                 MouseOver = f.MouseOver
            //                ,
            //                 Language = l.LanguageName
            //                ,
            //                 ObjectId = f.FlowId

            //             }).First();

            //return View(FlowLanguage);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var FlowLanguage = _processTemplateFlowLanguage.GetProcessTemplateFlowLanguage(FromForm.Id);
                FlowLanguage.Name = FromForm.Name;
                FlowLanguage.Description = FromForm.Description;
                FlowLanguage.MouseOver = FromForm.MouseOver;
                _processTemplateFlowLanguage.UpdateProcessTemplateFlowLanguage(FlowLanguage);
            }

            return RedirectToAction("LanguageIndex", new { Id = FromForm.ObjectId.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


            var parameter = new SqlParameter("@Id", Id);

            var LanguageList = _context.ZdbLanguageCreateGetLanguageList.FromSql("ProcessTemplateFlowLanguageCreateGetLanguageList @Id", parameter).ToList();

            List<SelectListItem> LList = new List<SelectListItem>();
            foreach (var Language in LanguageList)
            {
                LList.Add(new SelectListItem { Value = Language.Value, Text = Language.Text });
            }

            if (LList.Count() == 0)
            {
                return RedirectToAction("LanguageIndex", new { Id });
            }
            SuObjectLanguageEditGetModel ProcessTemplateFlow = new SuObjectLanguageEditGetModel
            {
                OId = Id
            };
            ViewBag.Id = Id.ToString();
            var ProcessTemplateFlowAndStatus = new SuObjectLanguageEditGetWitLanguageListModel
            {
                SuObject = ProcessTemplateFlow
                ,
                LanguageList = LList
            };
            return View(ProcessTemplateFlowAndStatus);
        }



        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var FlowLanguage = new SuProcessTemplateFlowLanguageModel
                {
                    Name = FromForm.SuObject.Name,
                    Description = FromForm.SuObject.Description,
                    MouseOver = FromForm.SuObject.MouseOver,
                    FlowId = FromForm.SuObject.ObjectId,
                    LanguageId = FromForm.SuObject.LanguageId
                };

                _processTemplateFlowLanguage.AddProcessTemplateFlowLanguage(FlowLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }




    }
}

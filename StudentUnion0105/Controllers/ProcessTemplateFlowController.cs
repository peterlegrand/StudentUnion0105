using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{

    public class ProcessTemplateFlowController : Controller
    {
        private readonly UserManager<SuUserModel> _userManager;
        private readonly ILanguageRepository _language;
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
            , SuDbContext context)
        {
            _userManager = userManager;
            _language = language;
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

            var ProcessTemplateFlow = (from p in _processTemplateFlow.GetAllProcessTemplateFlows()
                                        join l in _processTemplateFlowLanguage.GetAllProcessTemplateFlowLanguages()
                               on p.Id equals l.FlowId
                                        where p.ProcessTemplateId == Id
                                        && l.LanguageId == DefaultLanguageID
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
            var Flow = (from f in _processTemplateFlow.GetAllProcessTemplateFlows()
                               join l in _processTemplateFlowLanguage.GetAllProcessTemplateFlowLanguages()
                               on f.Id equals l.FlowId
                               where f.Id == Id && l.LanguageId == DefaultLanguageID
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
                                   , Description = l.Description
                                   , MouseOver = l.MouseOver
                                   , NotNullId = f.ProcessTemplateFromStepId
                                   , NotNullId2 = f.ProcessTemplateToStepId
                                   ,
                                   HeaderDescription = f.ConditionRelation
                               }).First();

            //Existing levels
            List<SelectListItem> StepList = (from s in _processTemplateStep.GetAllProcessTemplateSteps()
                                             join l in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                                             on s.Id equals l.StepId
                                                   where l.LanguageId == DefaultLanguageID
                                                   && s.ProcessTemplateId == Flow.Id
                                                   orderby l.ProcessTemplateStepName
                                                   select new SelectListItem
                                                   {
                                                       Value = s.Id.ToString()
                                                   ,
                                                       Text = l.ProcessTemplateStepName
                                                   }).ToList();



            StepList.Add(new SelectListItem { Text = "No selection", Value = "0" });

            
            var ClassificationAndStatus = new PageSectionAndStatusViewModel { SuObject = Flow, SomeKindINumSelectListItem = StepList};
            return View(ClassificationAndStatus);
           

        }

        [HttpPost]
        public async Task<IActionResult> Edit(PageSectionAndStatusViewModel UpdatedFlow)
        {

            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var a = _context.Database.ExecuteSqlCommand("ProcessTemplateFlowUpdate @p0, @p1, @p2, @p3, @p4, @p5, @p6",
                    parameters: new[] { UpdatedFlow.SuObject.ObjectId.ToString()           //0
                                        ,UpdatedFlow.SuObject.NotNullId.ToString()    //1
                                        ,UpdatedFlow.SuObject.NotNullId2.ToString()    //1
                                        , DefaultLanguageID.ToString()
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
            SuObjectVMPageSection SuObject = new SuObjectVMPageSection();
            SuObject.ObjectId = Id;

            //Existing levels
            List<SelectListItem> StepList = (from s in _processTemplateStep.GetAllProcessTemplateSteps()
                                             join l in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                                             on s.Id equals l.StepId
                                             where l.LanguageId == DefaultLanguageID
                                             && s.ProcessTemplateId ==Id
                                             orderby l.ProcessTemplateStepName
                                             select new SelectListItem
                                             {
                                                 Value = s.Id.ToString()
                                             ,
                                                 Text = l.ProcessTemplateStepName
                                             }).ToList();



            StepList.Add(new SelectListItem { Text = "No selection", Value = "0" });



            var ClassificationAndStatus = new PageSectionAndStatusViewModel { SuObject = SuObject, SomeKindINumSelectListItem = StepList};
            return View(ClassificationAndStatus);

        }

        [HttpPost]
        public async Task<IActionResult> Create(PageSectionAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;

                var a = _context.Database.ExecuteSqlCommand("ProcessTemplateFlowCreate @p0, @p1, @p2, @p3, @p4, @p5, @p6",
                   parameters: new[] { FromForm.SuObject.ObjectId.ToString()           //0
                                       , FromForm.SuObject.NotNullId.ToString()           //0
                                       , FromForm.SuObject.NotNullId2.ToString()           //0
                                       , DefaultLanguageID.ToString()           //0
                                       , FromForm.SuObject.Name           //0
                                       , FromForm.SuObject.Description           //0
                                       , FromForm.SuObject.MouseOver           //0
                   });



            }

            return RedirectToAction("Index", new { Id = FromForm.SuObject.ObjectId.ToString() });


            }


        public IActionResult LanguageIndex(int Id)
        {

            var FlowLanguage = (from f in _processTemplateFlowLanguage.GetAllProcessTemplateFlowLanguages()
                                          join l in _language.GetAllLanguages()
                         on f.LanguageId equals l.Id
                                          where f.FlowId == Id
                                          select new SuObjectVM
                                          {
                                              Id = f.Id
                                          ,
                                              Name = f.Name
                                          ,
                                              Language = l.LanguageName
                                          ,
                                              MouseOver = f.MouseOver
,                                              Description = f.Description
                                          ,
                                              ObjectId = f.FlowId
                                          }).ToList();
            ViewBag.Id = Id;

            return View(FlowLanguage);
        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var FlowLanguage = (from f in _processTemplateFlowLanguage.GetAllProcessTemplateFlowLanguages()
                         join l in _language.GetAllLanguages()
                         on f.LanguageId equals l.Id
                         where f.Id == Id
                         select new SuObjectVM
                         {
                             Id = f.Id
                            ,
                             Name = f.Name
                            ,
                             Description = f.Description
                            ,
                             MouseOver = f.MouseOver
                            ,
                             Language = l.LanguageName
                            ,
                             ObjectId = f.FlowId

                         }).First();

            return View(FlowLanguage);


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
        public IActionResult LanguageCreate(int Id)
        {
            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from f in _processTemplateFlowLanguage.GetAllProcessTemplateFlowLanguages()
                                where f.FlowId == Id
                                select f.LanguageId).ToList();


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
            var FlowAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(FlowAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var FlowLanguage = new SuProcessTemplateFlowLanguageModel();
                FlowLanguage.Name = FromForm.SuObject.Name;
                FlowLanguage.Description = FromForm.SuObject.Description;
                FlowLanguage.MouseOver = FromForm.SuObject.MouseOver;
                FlowLanguage.FlowId = FromForm.SuObject.ObjectId;
                FlowLanguage.LanguageId = FromForm.SuObject.LanguageId;

                var NewFlowLanguage =_processTemplateFlowLanguage.AddProcessTemplateFlowLanguage(FlowLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }




    }
}
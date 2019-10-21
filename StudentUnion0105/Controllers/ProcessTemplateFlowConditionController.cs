using System;
using System.Collections.Generic;
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
    public class ProcessTemplateFlowConditionController : Controller
    {
        private readonly UserManager<SuUserModel> _userManager;
        private readonly IProcessTemplateFlowConditionRepository _processTemplateFlowCondition;
        private readonly IProcessTemplateFlowConditionLanguageRepository _processTemplateFlowConditionLanguageRepository;
        private readonly ILanguageRepository _language;
        private readonly IPageSectionTypeRepository _pageSectionType;
        private readonly SuDbContext _context;

        public ProcessTemplateFlowConditionController(UserManager<SuUserModel> userManager
            , IProcessTemplateFlowConditionRepository processTemplateFlowCondition
            , IProcessTemplateFlowConditionLanguageRepository templateFlowConditionLanguageRepository
            , ILanguageRepository language
            , IPageSectionTypeRepository pageSectionType
            , SuDbContext context)
        {
            _userManager = userManager;
            _processTemplateFlowCondition = processTemplateFlowCondition;
            _processTemplateFlowConditionLanguageRepository = templateFlowConditionLanguageRepository;
            _language = language;
            _pageSectionType = pageSectionType;
            _context = context;
        }
        public async Task<IActionResult> Index(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);


            var pageSection = (from c in _processTemplateFlowCondition.GetAllProcessTemplateFlowConditions()
                               join l in _processTemplateFlowConditionLanguageRepository.GetAllProcessTemplateFlowConditionLanguages()
                      on c.Id equals l.FlowConditionId
                               where c.ProcessTemplateFlowId == Id
                               && l.LanguageId == DefaultLanguageID
                               orderby c.ConditionCharacter
                               select new SuObjectVM
                               {
                                   Id = c.Id
                               , Name = l.Name
                               , Description = c.ConditionCharacter
                               }).ToList();
            ViewBag.ObjectId = Id.ToString();
            //PETER TODO add a classification label so you know to which classification the levels belong.
            return View(pageSection);
        }
    [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var FlowCondition = (from c in _processTemplateFlowCondition.GetAllProcessTemplateFlowConditions()
                               join l in _processTemplateFlowConditionLanguageRepository.GetAllProcessTemplateFlowConditionLanguages()
                               on c.Id equals l.FlowConditionId
                               where c.Id == Id && l.LanguageId == DefaultLanguageID
                               orderby c.ConditionCharacter
                               select new SuObjectVMPageSection
                               {
                                   Id = c.ProcessTemplateFlowId
                                   ,
                                   ObjectId = c.Id
                                   ,
                                   LanguageId = l.LanguageId
                                   ,
                                   ObjectLanguageId = c.Id
                                   ,
                                   Type = c.ProcessTemplateConditionTypeId
                                   ,
                                   NullId = c.ProcessTemplateFieldId
                                   ,
                                   Description2 = c.ProcessTemplateFlowConditionString
                                   ,NullId2 = c.ProcessTemplateFlowConditionInt
                                   , DateFrom = c.ProcessTemplateFlowConditionDate
                                   ,Name = l.Name
                                   ,
                                   Description = l.Description
                                   ,
                                   MouseOver = l.MouseOver
                                   , HeaderDescription = c.ComparisonOperator
                               }).First();

            var ProcessTemplateFlowConditionTypesFromDb = _context.dbTypeList.FromSql($"GetProcessTemplateFlowConditionType").ToList();

            var ProcessTemplateFlowConditionTypeList = new List<SelectListItem>(); 

            foreach (var ProcessTemplateFlowConditionTypeFromDb in ProcessTemplateFlowConditionTypesFromDb)
            {
                ProcessTemplateFlowConditionTypeList.Add(new SelectListItem
                {
                    Text = ProcessTemplateFlowConditionTypeFromDb.Name,
                    Value = ProcessTemplateFlowConditionTypeFromDb.Id.ToString()
                });
            }

            var ProcessTemplateFlowFieldsFromDb = _context.dbStatusList.FromSql($"GetProcessTemplateFieldsForFlow @p0, @p1",
                    parameters: new[] {            //0
                                        DefaultLanguageID.ToString()
                    , Id.ToString()} ).ToList();

            var ProcessTemplateFlowFieldList = new List<SelectListItem>();
            ProcessTemplateFlowFieldList.Add(new SelectListItem
            {
                Text = "No field",
                Value = "0"
            });
            foreach (var ProcessTemplateFlowFieldFromDb in ProcessTemplateFlowFieldsFromDb)
            {
                ProcessTemplateFlowFieldList.Add(new SelectListItem
                {
                    Text = ProcessTemplateFlowFieldFromDb.Name,
                    Value = ProcessTemplateFlowFieldFromDb.Id.ToString()
                });
            }


            var ComparisonOperator = new List<SelectListItem>();
            ComparisonOperator.Add(new SelectListItem() { Text = "Equal", Value = "EQ" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Larger", Value = "LA" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Smaller", Value = "SM" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Larger or equal", Value = "LQ" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Smaller or equal", Value = "SQ" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Not equal", Value = "NE" });

            var ClassificationAndStatus = new PageSectionAndStatusViewModel { SuObject = FlowCondition, SomeKindINumSelectListItem = ComparisonOperator, ProbablyTypeListItem = ProcessTemplateFlowConditionTypeList , ProbablyTypeListItem2 = ProcessTemplateFlowFieldList  };
            return View(ClassificationAndStatus);
            

        }

        [HttpPost]
        public async Task<IActionResult> Edit(PageSectionAndStatusViewModel FromForm)
        {

            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
//                var FieldId 
                var a = _context.Database.ExecuteSqlCommand("ProcessTemplateFlowConditionUpdate @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, " +
                    "@p8, @p9, @p10",
                    parameters: new[] { FromForm.SuObject.ObjectId.ToString()           //0
                                        ,FromForm.SuObject.LanguageId.ToString()    //1
                    , FromForm.SuObject.Name                  //2
                    , FromForm.SuObject.Description                      //3
                    , FromForm.SuObject.MouseOver                     //4
                    , FromForm.SuObject.Type.ToString()                  //5
                    , FromForm.SuObject.NullId.ToString()                           //6
                    , FromForm.SuObject.Description2           //7
                    , FromForm.SuObject.NullId2.ToString() //8
                    , FromForm.SuObject.DateFrom.ToString()           //9
                   , FromForm.SuObject.HeaderDescription

                    });

             
            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("Index", new { Id = FromForm.SuObject.Id.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            SuObjectVMPageSection ToForm = new SuObjectVMPageSection();
            ToForm.Id = Id;

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            ToForm.LanguageId= DefaultLanguageID;
            var ProcessTemplateFlowConditionTypesFromDb = _context.dbTypeList.FromSql($"GetProcessTemplateFlowConditionType").ToList();

            var ProcessTemplateFlowConditionTypeList = new List<SelectListItem>();

            foreach (var ProcessTemplateFlowConditionTypeFromDb in ProcessTemplateFlowConditionTypesFromDb)
            {
                ProcessTemplateFlowConditionTypeList.Add(new SelectListItem
                {
                    Text = ProcessTemplateFlowConditionTypeFromDb.Name,
                    Value = ProcessTemplateFlowConditionTypeFromDb.Id.ToString()
                });
            }

            var ProcessTemplateFlowFieldsFromDb = _context.dbStatusList.FromSql($"GetProcessTemplateFieldsForFlow @p0, @p1",
                    parameters: new[] {            //0
                                        DefaultLanguageID.ToString()
                    , Id.ToString()}).ToList();

            var ProcessTemplateFlowFieldList = new List<SelectListItem>();
            ProcessTemplateFlowFieldList.Add(new SelectListItem
            {
                Text = "No field",
                Value = "0"
            });
            foreach (var ProcessTemplateFlowFieldFromDb in ProcessTemplateFlowFieldsFromDb)
            {
                ProcessTemplateFlowFieldList.Add(new SelectListItem
                {
                    Text = ProcessTemplateFlowFieldFromDb.Name,
                    Value = ProcessTemplateFlowFieldFromDb.Id.ToString()
                });
            }


            var ComparisonOperator = new List<SelectListItem>();
            ComparisonOperator.Add(new SelectListItem() { Text = "Equal", Value = "EQ" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Larger", Value = "LA" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Smaller", Value = "SM" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Larger or equal", Value = "LQ" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Smaller or equal", Value = "SQ" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Not equal", Value = "NE" });

            var ClassificationAndStatus = new PageSectionAndStatusViewModel { SuObject = ToForm, SomeKindINumSelectListItem = ComparisonOperator, ProbablyTypeListItem = ProcessTemplateFlowConditionTypeList, ProbablyTypeListItem2 = ProcessTemplateFlowFieldList };
            return View(ClassificationAndStatus);


        }

        [HttpPost]
        public async Task<IActionResult> Create(PageSectionAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                //                var FieldId 
                var a = _context.Database.ExecuteSqlCommand("ProcessTemplateFlowConditionCreate @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, " +
                    "@p8, @p9, @p10",
                    parameters: new[] { FromForm.SuObject.Id.ToString()           //0
                                        ,FromForm.SuObject.LanguageId.ToString()    //1
                    , FromForm.SuObject.Name                  //2
                    , FromForm.SuObject.Description                      //3
                    , FromForm.SuObject.MouseOver                     //4
                    , FromForm.SuObject.Type.ToString()                  //5
                    , FromForm.SuObject.NullId.ToString()                           //6
                    , FromForm.SuObject.Description2           //7
                    , FromForm.SuObject.NullId2.ToString() //8
                    , FromForm.SuObject.DateFrom.ToString()           //9
                   , FromForm.SuObject.HeaderDescription

                    });


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("Index", new { Id = FromForm.SuObject.Id.ToString() });


        }

    }
}
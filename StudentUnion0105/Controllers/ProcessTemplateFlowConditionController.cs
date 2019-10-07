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
    public class ProcessTemplateFlowConditionController : Controller
    {
        private readonly UserManager<SuUser> _userManager;
        private readonly IProcessTemplateFlowConditionRepository _processTemplateFlowCondition;
        private readonly IProcessTemplateFlowConditionLanguageRepository _processTemplateFlowConditionLanguageRepository;
        private readonly ILanguageRepository _language;
        private readonly IPageSectionTypeRepository _pageSectionType;
        private readonly SuDbContext _context;

        public ProcessTemplateFlowConditionController(UserManager<SuUser> userManager
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
            var DefaultLanguageID = CurrentUser.DefaultLangauge;

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
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var PageSection = (from c in _processTemplateFlowCondition.GetAllProcessTemplateFlowConditions()
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
                                   ObjectLanguageId = l.Id
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

            var ComparisonOperator = new List<SelectListItem>();
            ComparisonOperator.Add(new SelectListItem() { Text = "Equal", Value = "EQ" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Larger", Value = "LA" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Smaller", Value = "SM" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Larger or equal", Value = "LQ" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Smaller or equal", Value = "SQ" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Not equal", Value = "NE" });

            var ClassificationAndStatus = new PageSectionAndStatusViewModel { SuObject = PageSection, SomeKindINumSelectListItem = ComparisonOperator, ProbablyTypeListItem = ProcessTemplateFlowConditionTypeList };//, ProbablyTypeListItem2 = ContentTypeList };
            return View(ClassificationAndStatus);
            

        }

    
    }
}
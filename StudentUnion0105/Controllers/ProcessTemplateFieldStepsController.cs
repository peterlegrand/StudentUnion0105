﻿using System;
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
    public class ProcessTemplateFieldStepsController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IProcessTemplateStepFieldRepository _processTemplateStepField;
        private readonly IProcessTemplateStepLanguageRepository _processTemplateStepLanguage;
        private readonly IProcessTemplateFieldLanguageRepository _processTemplateFieldLanguage;
        private readonly IProcessTemplateFieldRepository _processTemplateField;
        private readonly IProcessTemplateStepFieldStatusRepository _processTemplateStepFieldStatus;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public ProcessTemplateFieldStepsController(UserManager<SuUser> userManager
            , IProcessTemplateStepFieldRepository processTemplateStepField
            , IProcessTemplateStepLanguageRepository processTemplateStepLanguage
            , IProcessTemplateFieldLanguageRepository processTemplateFieldLanguage
            , IProcessTemplateFieldRepository processTemplateField
            , IProcessTemplateStepFieldStatusRepository processTemplateStepFieldStatus
            , ILanguageRepository language
            , SuDbContext context)
        {
            this.userManager = userManager;
            _processTemplateStepField = processTemplateStepField;
            _processTemplateStepLanguage = processTemplateStepLanguage;
            _processTemplateFieldLanguage = processTemplateFieldLanguage;
            _processTemplateField = processTemplateField;
            _processTemplateStepFieldStatus = processTemplateStepFieldStatus;
            _language = language;
            _context = context;
        }
        public async Task<IActionResult> Index(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;

            var Steps = (from sf in _processTemplateStepField.GetAllProcessTemplateStepFields()
                                       join s in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                                       on sf.StepId equals s.StepId
                                       join f in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
                                       on sf.FieldId equals f.ProcessTemplateFieldId
                                       where sf.FieldId == Id
                                       && s.LanguageId == DefaultLanguageID
                                       && f.LanguageId == DefaultLanguageID
                         orderby sf.Sequence
                                       select new SuObjectVM
                                       {
                                           Id = sf.Id
                                       ,
                                           Name = s.ProcessTemplateStepName,
                                           Description= f.ProcessTemplateFieldName

                                       ,
                                           ObjectId =sf.StepId
                                           
                                       }).ToList();
            ViewBag.ObjectId = Id.ToString();
            //PETER TODO add a classification label so you know to which classification the levels belong.
            return View(Steps);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var StepField = (from sf in _processTemplateStepField.GetAllProcessTemplateStepFields()
                               join s in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                               on sf.StepId equals s.StepId
                               join f in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
                               on sf.FieldId equals f.ProcessTemplateFieldId
                               where sf.Id == Id
                               && s.LanguageId == DefaultLanguageID
                               && f.LanguageId == DefaultLanguageID
                               select new SuObjectVMPageSection
                               {
                                   Id = sf.Id
                                   ,
                                   Status = sf.StatusId
                                   , Sequence = sf.Sequence
                                   , 
                                   Name = s.ProcessTemplateStepName
                                   ,
                                   Description = f.ProcessTemplateFieldName
                                   , NotNullId = s.Id
                                   , NotNullId2 = f.ProcessTemplateFieldId
                               }).First();

            //dropdown for sequence
            List<SelectListItem> StepFieldList = (from sf in _processTemplateStepField.GetAllProcessTemplateStepFields()
                                                   join f in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
                                                   on sf.FieldId equals f.ProcessTemplateFieldId
                                                   where sf.StepId == StepField.NotNullId
                                                   && f.LanguageId == DefaultLanguageID
                                                   orderby sf.Sequence
                                                   select new SelectListItem
                                                   {
                                                       Value = sf.Sequence.ToString()
                                                   ,
                                                       Text = f.ProcessTemplateFieldName
                                                   }).ToList();

            int MaxFields;

            {
                MaxFields = (from sf in _processTemplateStepField.GetAllProcessTemplateStepFields()
                                    where sf.StepId == StepField.NotNullId
                                    select sf.Sequence).Max();

                MaxFields++;
            }


            StepFieldList.Add(new SelectListItem { Text = "add at bottom", Value = MaxFields.ToString() });

            //Existing levels

            //PageSectionTypes
            var StatussFromDB = (from s in _processTemplateStepFieldStatus.GetAllProcessTemplateStepFieldStatus()
                         select new SuObjectVM
                         {
                             Id = s.Id
                            ,
                             Name = s.StatusName
                         }).ToList();

            var StatusList = new List<SelectListItem>();
            foreach (var StatusFromDb in StatussFromDB)
            {
                StatusList.Add(new SelectListItem
                {
                    Text = StatusFromDb.Name,
                    Value = StatusFromDb.Id.ToString()
                });
            }

            //PageSectionTypes

            var ProcessTemplateStepFieldAndStatus = new PageSectionAndStatusViewModel { SuObject = StepField, SomeKindINumSelectListItem = StepFieldList, ProbablyTypeListItem =StatusList };
            return View(ProcessTemplateStepFieldAndStatus);



        }

        [HttpPost]
        public async Task<IActionResult> Edit(PageSectionAndStatusViewModel UpdatedStepField)
        {

            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var a = _context.Database.ExecuteSqlCommand("ProcessTemplateStepFieldUpdate @p0, @p1, @p2",
                    parameters: new[] { UpdatedStepField.SuObject.Id.ToString()           //0
                                        ,UpdatedStepField.SuObject.Status.ToString()    //1
                                        ,UpdatedStepField.SuObject.Sequence.ToString()    //2
                    });

            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("Index", new { Id = UpdatedStepField.SuObject.NotNullId2.ToString() });



        }

    }
}
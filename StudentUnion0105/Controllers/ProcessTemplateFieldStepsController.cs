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
    public class ProcessTemplateFieldStepsController : PortalController
    {
        private readonly IProcessTemplateStepFieldRepository _processTemplateStepField;
        private readonly IProcessTemplateStepLanguageRepository _processTemplateStepLanguage;
        private readonly IProcessTemplateFieldLanguageRepository _processTemplateFieldLanguage;
        private readonly IProcessTemplateFieldRepository _processTemplateField;
        private readonly IProcessTemplateStepFieldStatusRepository _processTemplateStepFieldStatus;
        private readonly SuDbContext _context;

        public ProcessTemplateFieldStepsController(UserManager<SuUserModel> userManager
            , IProcessTemplateStepFieldRepository processTemplateStepField
            , IProcessTemplateStepLanguageRepository processTemplateStepLanguage
            , IProcessTemplateFieldLanguageRepository processTemplateFieldLanguage
            , IProcessTemplateFieldRepository processTemplateField
            , IProcessTemplateStepFieldStatusRepository processTemplateStepFieldStatus
            , ILanguageRepository language
            , SuDbContext context) : base(userManager, language)
        {
            _processTemplateStepField = processTemplateStepField;
            _processTemplateStepLanguage = processTemplateStepLanguage;
            _processTemplateFieldLanguage = processTemplateFieldLanguage;
            _processTemplateField = processTemplateField;
            _processTemplateStepFieldStatus = processTemplateStepFieldStatus;
            _context = context;
        }
        public async Task<IActionResult> Index(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);



            var Steps = (from sf in _processTemplateStepField.GetAllProcessTemplateStepFields()
                                       join s in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                                       on sf.StepId equals s.StepId
                                       join f in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
                                       on sf.FieldId equals f.ProcessTemplateFieldId
                                       where sf.FieldId == Id
                                       && s.LanguageId == CurrentUser.DefaultLanguageId
                                       && f.LanguageId == CurrentUser.DefaultLanguageId
                         orderby sf.Sequence
                                       select new SuObjectVM
                                       {
                                           Id = sf.Id
                                       ,
                                           Name = s.Name,
                                           Description= f.Name

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
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);



            var StepField = (from sf in _processTemplateStepField.GetAllProcessTemplateStepFields()
                               join s in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                               on sf.StepId equals s.StepId
                               join f in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
                               on sf.FieldId equals f.ProcessTemplateFieldId
                               where sf.Id == Id
                               && s.LanguageId == CurrentUser.DefaultLanguageId
                               && f.LanguageId == CurrentUser.DefaultLanguageId
                             select new SuObjectVMPageSection
                               {
                                   Id = sf.Id
                                   ,
                                   Status = sf.StatusId
                                   , Sequence = sf.Sequence
                                   , 
                                   Name = s.Name
                                   ,
                                   Description = f.Name
                                   , NotNullId = s.Id
                                   , NotNullId2 = f.ProcessTemplateFieldId
                               }).First();

            //dropdown for sequence
            List<SelectListItem> StepFieldList = (from sf in _processTemplateStepField.GetAllProcessTemplateStepFields()
                                                   join f in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
                                                   on sf.FieldId equals f.ProcessTemplateFieldId
                                                   where sf.StepId == StepField.NotNullId
                                                   && f.LanguageId == CurrentUser.DefaultLanguageId
                                                  orderby sf.Sequence
                                                   select new SelectListItem
                                                   {
                                                       Value = sf.Sequence.ToString()
                                                   ,
                                                       Text = f.Name
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
                             Name = s.Name
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
        public IActionResult Edit(PageSectionAndStatusViewModel UpdatedStepField)
        {

            if (ModelState.IsValid)
            {
    
                _context.Database.ExecuteSqlCommand("ProcessTemplateStepFieldUpdate @p0, @p1, @p2",
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
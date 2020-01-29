using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{
    public class ProcessTemplateStepFieldsController : PortalController
    {
        private readonly IProcessTemplateStepFieldRepository _processTemplateStepField;
        private readonly IProcessTemplateFieldLanguageRepository _processTemplateFieldLanguage;
        private readonly IProcessTemplateStepLanguageRepository _processTemplateStepLanguage;
        private readonly SuDbContext _context;

        public ProcessTemplateStepFieldsController(UserManager<SuUserModel> userManager
            , IProcessTemplateStepFieldRepository processTemplateStepField
            , IProcessTemplateFieldLanguageRepository processTemplateFieldLanguage
            , IProcessTemplateStepLanguageRepository processTemplateStepLanguage
            , ILanguageRepository language
            , SuDbContext context) : base(userManager, language)
        {
            _processTemplateStepField = processTemplateStepField;
            _processTemplateFieldLanguage = processTemplateFieldLanguage;
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


            var Steps = (from sf in _processTemplateStepField.GetAllProcessTemplateStepFields()
                         join f in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
                         on sf.FieldId equals f.ProcessTemplateFieldId
                         join s in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                         on sf.StepId equals s.StepId
                         where sf.FieldId == Id
                         && f.LanguageId == CurrentUser.DefaultLanguageId
                         && s.LanguageId == CurrentUser.DefaultLanguageId
                         orderby sf.Sequence
                         select new SuObjectVM
                         {
                             Id = sf.Id
                         ,
                             Name = f.Name
                             , Description = s.Name

                         ,
                             ObjectId = s.StepId

                         }).ToList();
            ViewBag.ObjectId = Id.ToString();
            //PETER TODO add a classification label so you know to which classification the levels belong.
            return View(Steps);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{
    public class ProcessTemplateStepFieldsController : Controller
    {
        private readonly UserManager<SuUser> _userManager;
        private readonly IProcessTemplateStepFieldRepository _processTemplateStepField;
        private readonly IProcessTemplateFieldLanguageRepository _processTemplateFieldLanguage;
        private readonly IProcessTemplateStepLanguageRepository _processTemplateStepLanguage;
        private readonly ILanguageRepository _language;

        public ProcessTemplateStepFieldsController(UserManager<SuUser> userManager
            , IProcessTemplateStepFieldRepository processTemplateStepField
            , IProcessTemplateFieldLanguageRepository processTemplateFieldLanguage
            , IProcessTemplateStepLanguageRepository processTemplateStepLanguage
            , ILanguageRepository language)
        {
            _userManager = userManager;
            _processTemplateStepField = processTemplateStepField;
            _processTemplateFieldLanguage = processTemplateFieldLanguage;
            _processTemplateStepLanguage = processTemplateStepLanguage;
            _language = language;
        }


        public async Task<IActionResult> Index(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;

            var Steps = (from sf in _processTemplateStepField.GetAllProcessTemplateStepFields()
                         join f in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
                         on sf.FieldId equals f.ProcessTemplateFieldId
                         join s in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                         on sf.StepId equals s.StepId
                         where sf.FieldId == Id
                         && f.LanguageId == DefaultLanguageID
                         && s.LanguageId == DefaultLanguageID
                         orderby sf.Sequence
                         select new SuObjectVM
                         {
                             Id = sf.Id
                         ,
                             Name = f.ProcessTemplateFieldName
                             , Description = s.ProcessTemplateStepName

                         ,
                             ObjectId = s.StepId

                         }).ToList();
            ViewBag.ObjectId = Id.ToString();
            //PETER TODO add a classification label so you know to which classification the levels belong.
            return View(Steps);
        }
    }
}
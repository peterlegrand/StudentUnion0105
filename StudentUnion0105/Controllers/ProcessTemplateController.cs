using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class ProcessTemplateController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IProcessTemplateLanguageRepository _processTemplateLanguage;
        private readonly IProcessTemplateRepository _processTemplate;
        private readonly IProcessTemplateGroupRepository _processTemplateGroup;
        private readonly IProcessTemplateGroupLanguageRepository _processTemplateGroupLanguage;
        private readonly SuDbContext _context;

        public ProcessTemplateController(UserManager<SuUser> userManager
                , IProcessTemplateLanguageRepository ProcessTemplateLanguage
                , IProcessTemplateRepository ProcessTemplate
                , IProcessTemplateGroupRepository processTemplateGroup
                , IProcessTemplateGroupLanguageRepository processTemplateGroupLanguage
            , SuDbContext context
                )
        {
            this.userManager = userManager;
            _processTemplateLanguage = ProcessTemplateLanguage;
            _processTemplate = ProcessTemplate;
            _processTemplateGroup = processTemplateGroup;
            _processTemplateGroupLanguage = processTemplateGroupLanguage;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var ProcessTemplateList = (

                from l in _processTemplateLanguage.GetAllProcessTemplateLanguages()

                where l.LanguageId == DefaultLanguageID
                select new SuObjectVM


                {
                    Id = l.ProcessTemplateId
                             ,
                    Name = l.ProcessTemplateName
                }).ToList();
            return View(ProcessTemplateList);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var ProcessTemplateGroupList = new List<SelectListItem>();

            var ProcessTemplateGroupFromDb = _context.dbTypeList.FromSql($"GetProcessTemplateGroup {DefaultLanguageID}").ToList();

            foreach (var ProcessTemplateGroup in ProcessTemplateGroupFromDb)
            {
                ProcessTemplateGroupList.Add(new SelectListItem
                {
                    Text = ProcessTemplateGroup.Name,
                    Value = ProcessTemplateGroup.Id.ToString()
                });
            }



            var ProcessTemplateAndGroup = new SuObjectAndStatusViewModel { SomeKindINumSelectListItem = ProcessTemplateGroupList };
            return View(ProcessTemplateAndGroup);
        }


        [HttpPost]
        public async Task<IActionResult> Create(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplate = new SuProcessTemplateModel();
                ProcessTemplate.ProcessTemplateGroupId = FromForm.SuObject.NotNullId;
                var NewProcessTemplate = _processTemplate.AddProcessTemplate(ProcessTemplate);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var ProcessTemplateLanguage = new SuProcessTemplateLanguageModel();

                ProcessTemplateLanguage.ProcessTemplateName = FromForm.SuObject.Name;
                ProcessTemplateLanguage.ProcessTemplateDescription = FromForm.SuObject.Description;
                ProcessTemplateLanguage.ProcessTemplateMouseOver = FromForm.SuObject.MouseOver;
                ProcessTemplateLanguage.ProcessTemplateId = NewProcessTemplate.Id;
                ProcessTemplateLanguage.LanguageId = DefaultLanguageID;
                _processTemplateLanguage.AddProcessTemplateLanguage(ProcessTemplateLanguage);

            }
            return RedirectToAction("Index");



        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{
    public class ProjectController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IProjectLanguageRepository _ProjectLanguage;
        private readonly IProjectRepository _Project;
        private readonly ILanguageRepository _language;
        private readonly IProjectStatusRepository _projectStatus;

        public ProjectController(UserManager<SuUser> userManager
            , IProjectLanguageRepository ProjectLanguage
            , IProjectRepository Project
            , ILanguageRepository language
            , IProjectStatusRepository projectStatus)
        {
            this.userManager = userManager;
            _ProjectLanguage = ProjectLanguage;
            _Project = Project;
            _language = language;
            _projectStatus = projectStatus;
        }
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var Projects = (

                from l in _ProjectLanguage.GetAllProjectLanguages()

                where l.LanguageId == DefaultLanguageID
                select new SuObjectVM


                {
                    Id = l.ProjectId
                             ,
                    Name = l.Name
                }).ToList();
            return View(Projects);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var ProjectList = new List<SelectListItem>();

            foreach (var ProjectFromDb in _projectStatus.GetAllProjectStatus())
            {
                ProjectList.Add(new SelectListItem
                {
                    Text = ProjectFromDb.ProjectStatusName,
                    Value = ProjectFromDb.Id.ToString()
                });
            }
            var ProjectAndStatus = new SuObjectAndStatusViewModel { SomeKindINumSelectListItem = ProjectList };
            return View(ProjectAndStatus);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var Project = new SuProjectModel();
                Project.ModifiedDate = DateTime.Now;
                Project.CreatedDate = DateTime.Now;
                Project.ProjectStatusId = FromForm.SuObject.Status;
                var NewProject = _Project.AddProject(Project);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var ProjectLanguage = new SuProjectLanguageModel();

                ProjectLanguage.Name = FromForm.SuObject.Name;
                ProjectLanguage.Description = FromForm.SuObject.Description;
                ProjectLanguage.MouseOver = FromForm.SuObject.MouseOver;
                ProjectLanguage.ProjectId = NewProject.Id;
                ProjectLanguage.LanguageId = DefaultLanguageID;
                _ProjectLanguage.AddProjectLanguage(ProjectLanguage);

            }
            return RedirectToAction("Index");



        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var test1 = (from s in _Project.GetAllProjects()
                         join t in _ProjectLanguage.GetAllProjectLanguages()
                         on s.Id equals t.ProjectId
                         where t.LanguageId == DefaultLanguageID && s.Id == Id
                         select new SuObjectVM
                         {
                             Id = s.Id
                            , Name = t.Name
                            , Status = s.ProjectStatusId
                            , ObjectLanguageId = t.Id
                            , Description = t.Description
                            , MouseOver = t.MouseOver
                         }).First();

            var ProjectList = new List<SelectListItem>();

            foreach (var ProjectFromDb in _projectStatus.GetAllProjectStatus())
            {
                ProjectList.Add(new SelectListItem
                {
                    Text = ProjectFromDb.ProjectStatusName,
                    Value = ProjectFromDb.Id.ToString()
                });
            }
            var ProjectAndStatus = new SuObjectAndStatusViewModel { SuObject = test1, SomeKindINumSelectListItem = ProjectList };
            return View(ProjectAndStatus);




        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var Project = _Project.GetProject(test3.Id);
                var CurrentUser = await userManager.GetUserAsync(User);

                Project.ModifiedDate = DateTime.Now;
                Project.ModifierId = new Guid(CurrentUser.Id);
                _Project.UpdateProject(Project);

                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var ProjectLanguage = _ProjectLanguage.GetProjectLanguage(test3.ObjectLanguageId);
                ProjectLanguage.Name = test3.Name;
                ProjectLanguage.Description = test3.Description;
                ProjectLanguage.MouseOver = test3.MouseOver;
                ProjectLanguage.ModifiedDate = DateTime.Now;
                ProjectLanguage.ModifierId = new Guid(CurrentUser.Id);
                _ProjectLanguage.UpdateProjectLanguage(ProjectLanguage);

            }
            return RedirectToAction("Index");



        }


        public IActionResult LanguageIndex(int Id)
        {

            var ContentLanguage = (from c in _ProjectLanguage.GetAllProjectLanguages()
                                   join l in _language.GetAllLanguages()
                  on c.LanguageId equals l.Id
                                   where c.ProjectId == Id
                                   select new SuObjectVM
                                   {
                                       Id = c.Id
                                   ,
                                       Name = c.Name
                                   ,
                                       Language = l.LanguageName
                                   ,
                                       Description = c.Description
                                   ,
                                       MouseOver = c.MouseOver
                                   ,
                                       ObjectId = c.ProjectId
                                   }).ToList();
            ViewBag.Id = Id;

            return View(ContentLanguage);
        }

        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _ProjectLanguage.GetAllProjectLanguages()
                                where c.ProjectId == Id
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
            {
                return RedirectToAction("LanguageIndex", new { Id = Id });
            }
            SuObjectVM SuObject = new SuObjectVM();
            SuObject.ObjectId = Id;
            ViewBag.Id = Id.ToString();
            var ProjectAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(ProjectAndStatus);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var ProjectLanguage = new SuProjectLanguageModel();
                ProjectLanguage.Name = test3.SuObject.Name;
                ProjectLanguage.Description = test3.SuObject.Description;
                ProjectLanguage.MouseOver = test3.SuObject.MouseOver;
                ProjectLanguage.ProjectId = test3.SuObject.ObjectId;
                ProjectLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewProjectLanguage = _ProjectLanguage.AddProjectLanguage(ProjectLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var test1 = (from c in _ProjectLanguage.GetAllProjectLanguages()
                         join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                         where c.Id == Id
                         select new SuObjectVM
                         {
                             Id = c.Id
                            ,
                             Name = c.Name
                            ,
                             Description = c.Description
                            ,
                             MouseOver = c.MouseOver
                            ,
                             Language = l.LanguageName
                            ,
                             ObjectId = c.ProjectId

                         }).First();

            var ProjectAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = test1 //, a = ProjectList
            };
            return View(test1);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var ProjectLanguage = _ProjectLanguage.GetProjectLanguage(test3.Id);
                ProjectLanguage.Name = test3.Name;
                ProjectLanguage.Description = test3.Description;
                ProjectLanguage.MouseOver = test3.MouseOver;
                _ProjectLanguage.UpdateProjectLanguage(ProjectLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Project.ProjectId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.ObjectId.ToString() });
        }

    }
}
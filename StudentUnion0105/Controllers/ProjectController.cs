using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class ProjectController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IProjectLanguageRepository _ProjectLanguage;
        private readonly IProjectRepository _Project;
        private readonly ILanguageRepository _language;
        private readonly IProjectStatusRepository _projectStatus;
        private readonly SuDbContext _context;

        public ProjectController(UserManager<SuUser> userManager
            , IProjectLanguageRepository ProjectLanguage
            , IProjectRepository Project
            , ILanguageRepository language
            , IProjectStatusRepository projectStatus
            , SuDbContext context)
        {
            this.userManager = userManager;
            _ProjectLanguage = ProjectLanguage;
            _Project = Project;
            _language = language;
            _projectStatus = projectStatus;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var a = _context.dbGetProjectStructure.FromSql($"ProjStructure {DefaultLanguageID}").ToList();

            //if (a.Count != 0)
            //{
            int maxLevel = 0;
            foreach (var Org in a)
            {
                if (Org.Level > maxLevel)
                {
                    maxLevel = Org.Level;
                }
            }

            var c = new ProjStructureWithDepth { MaxLevel = maxLevel, ProjStructure = a };
            return View(c);
        }
        public async Task<IActionResult> Indexw()
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
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var ParentProject = _Project.GetProject(Id);

            var ProjectList = new List<SelectListItem>();

            foreach (var ProjectFromDb in _projectStatus.GetAllProjectStatus())
            {
                ProjectList.Add(new SelectListItem
                {
                    Text = ProjectFromDb.ProjectStatusName,
                    Value = ProjectFromDb.Id.ToString()
                });
            }

            SuObjectVM Parent = new SuObjectVM()
            {
                NullId = ParentProject == null ? 0 : ParentProject.Id
            };

            var ProjectAndStatus = new SuObjectAndStatusViewModel { SuObject = Parent, SomeKindINumSelectListItem = ProjectList };
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
                if (FromForm.SuObject.NullId != 0)
                { Project.ParentProjectId = FromForm.SuObject.NullId; }
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
            var ToForm = (from s in _Project.GetAllProjects()
                         join t in _ProjectLanguage.GetAllProjectLanguages()
                         on s.Id equals t.ProjectId
                         where t.LanguageId == DefaultLanguageID && s.Id == Id
                         select new SuObjectVM
                         {
                             Id = s.Id
                            ,
                             Name = t.Name
                            ,
                             Status = s.ProjectStatusId
                            ,
                             ObjectLanguageId = t.Id
                            ,
                             Description = t.Description
                            ,
                             MouseOver = t.MouseOver

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
            var ProjectAndStatus = new SuObjectAndStatusViewModel { SuObject = ToForm, SomeKindINumSelectListItem = ProjectList };
            return View(ProjectAndStatus);




        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var Project = _Project.GetProject(FromForm.SuObject.Id);
                var CurrentUser = await userManager.GetUserAsync(User);

                Project.ModifiedDate = DateTime.Now;
                Project.ModifierId = new Guid(CurrentUser.Id);
                _Project.UpdateProject(Project);

                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var ProjectLanguage = _ProjectLanguage.GetProjectLanguage(FromForm.SuObject.ObjectLanguageId);
                ProjectLanguage.Name = FromForm.SuObject.Name;
                ProjectLanguage.Description = FromForm.SuObject.Description;
                ProjectLanguage.MouseOver = FromForm.SuObject.MouseOver;
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
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var ProjectLanguage = new SuProjectLanguageModel();
                ProjectLanguage.Name = FromForm.SuObject.Name;
                ProjectLanguage.Description = FromForm.SuObject.Description;
                ProjectLanguage.MouseOver = FromForm.SuObject.MouseOver;
                ProjectLanguage.ProjectId = FromForm.SuObject.ObjectId;
                ProjectLanguage.LanguageId = FromForm.SuObject.LanguageId;

                var NewProjectLanguage = _ProjectLanguage.AddProjectLanguage(ProjectLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var ToForm = (from c in _ProjectLanguage.GetAllProjectLanguages()
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
                SuObject = ToForm //, a = ProjectList
            };
            return View(ToForm);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var ProjectLanguage = _ProjectLanguage.GetProjectLanguage(FromForm.Id);
                ProjectLanguage.Name = FromForm.Name;
                ProjectLanguage.Description = FromForm.Description;
                ProjectLanguage.MouseOver = FromForm.MouseOver;
                _ProjectLanguage.UpdateProjectLanguage(ProjectLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+FromForm.Project.ProjectId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = FromForm.ObjectId.ToString() });
        }

    }
}
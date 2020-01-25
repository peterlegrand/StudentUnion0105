using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class ProjectController : PortalController
    {
        private readonly IProjectLanguageRepository _ProjectLanguage;
        private readonly IProjectRepository _Project;
        private readonly IProjectStatusRepository _projectStatus;
     
        public ProjectController(UserManager<SuUserModel> userManager
            , IProjectLanguageRepository ProjectLanguage
            , IProjectRepository Project
            , ILanguageRepository language
            , IProjectStatusRepository projectStatus
            , SuDbContext context) : base(userManager, language, context)
        {
            _ProjectLanguage = ProjectLanguage;
            _Project = Project;
            _projectStatus = projectStatus;
        }

        public async Task<IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();

            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);

            var a = _context.DbGetProjectStructure.FromSql("ProjStructure @LanguageId", parameter).ToList();

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
            var CurrentUser = await _userManager.GetUserAsync(User);

            var Projects = (

                from l in _ProjectLanguage.GetAllProjectLanguages()

                where l.LanguageId == CurrentUser.DefaultLanguageId
                select new SuObjectVM


                {
                    Id = l.ProjectId
                             ,
                    Name = l.Name
                }).ToList();
            return View(Projects);
        }

        [HttpGet]
        public IActionResult Create(int Id)
        {

            base.Initializing();

            var ParentProject = _Project.GetProject(Id);

            var ProjectList = new List<SelectListItem>();

            foreach (var ProjectFromDb in _projectStatus.GetAllProjectStatus())
            {
                ProjectList.Add(new SelectListItem
                {
                    Text = ProjectFromDb.Name,
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
                var Project = new SuProjectModel
                {
                    ModifiedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    ProjectStatusId = FromForm.SuObject.Status
                };
                if (FromForm.SuObject.NullId != 0)
                { Project.ParentProjectId = FromForm.SuObject.NullId; }
                var NewProject = _Project.AddProject(Project);


                var CurrentUser = await _userManager.GetUserAsync(User);

                var ProjectLanguage = new SuProjectLanguageModel
                {
                    Name = FromForm.SuObject.Name,
                    Description = FromForm.SuObject.Description,
                    MouseOver = FromForm.SuObject.MouseOver,
                    ProjectId = NewProject.Id,
                    LanguageId = CurrentUser.DefaultLanguageId
                };
                _ProjectLanguage.AddProjectLanguage(ProjectLanguage);

            }
            return RedirectToAction("Index");



        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();

            var ToForm = (from s in _Project.GetAllProjects()
                         join t in _ProjectLanguage.GetAllProjectLanguages()
                         on s.Id equals t.ProjectId
                         where t.LanguageId == CurrentUser.DefaultLanguageId && s.Id == Id
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
                    Text = ProjectFromDb.Name,
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
                var CurrentUser = await _userManager.GetUserAsync(User);

                Project.ModifiedDate = DateTime.Now;
                Project.ModifierId = CurrentUser.Id;
                _Project.UpdateProject(Project);

    
                var ProjectLanguage = _ProjectLanguage.GetProjectLanguage(FromForm.SuObject.ObjectLanguageId);
                ProjectLanguage.Name = FromForm.SuObject.Name;
                ProjectLanguage.Description = FromForm.SuObject.Description;
                ProjectLanguage.MouseOver = FromForm.SuObject.MouseOver;
                ProjectLanguage.ModifiedDate = DateTime.Now;
                ProjectLanguage.ModifierId = CurrentUser.Id;
                _ProjectLanguage.UpdateProjectLanguage(ProjectLanguage);

            }
            return RedirectToAction("Index");



        }


        public IActionResult LanguageIndex(int Id)
        {
            base.Initializing();

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ProjectLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

        }

        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();

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
                return RedirectToAction("LanguageIndex", new { Id });
            }
            SuObjectVM SuObject = new SuObjectVM
            {
                ObjectId = Id
            };
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
                var ProjectLanguage = new SuProjectLanguageModel
                {
                    Name = FromForm.SuObject.Name,
                    Description = FromForm.SuObject.Description,
                    MouseOver = FromForm.SuObject.MouseOver,
                    ProjectId = FromForm.SuObject.ObjectId,
                    LanguageId = FromForm.SuObject.LanguageId
                };

                _ProjectLanguage.AddProjectLanguage(ProjectLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {


            base.Initializing();

            var parameter = new SqlParameter("@Id", Id);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ProjectLanguageEditGet @Id", parameter).First();
            return View(ObjectLanguage);


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
﻿using Microsoft.AspNetCore.Identity;
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
    public class ProjectController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IProjectLanguageRepository _ProjectLanguage;
        private readonly IProjectRepository _Project;
        private readonly ILanguageRepository _language;
        private readonly IProjectStatusRepository _projectStatus;
        private readonly SuDbContext _context;

        public ProjectController(UserManager<SuUserModel> userManager
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
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@LanguageId", DefaultLanguageID);

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
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
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
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

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
                var Project = new SuProjectModel();
                Project.ModifiedDate = DateTime.Now;
                Project.CreatedDate = DateTime.Now;
                Project.ProjectStatusId = FromForm.SuObject.Status;
                if (FromForm.SuObject.NullId != 0)
                { Project.ParentProjectId = FromForm.SuObject.NullId; }
                var NewProject = _Project.AddProject(Project);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
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
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

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
                var CurrentUser = await userManager.GetUserAsync(User);

                Project.ModifiedDate = DateTime.Now;
                Project.ModifierId = new Guid(CurrentUser.Id);
                _Project.UpdateProject(Project);

                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
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


        public async Task<IActionResult> LanguageIndex(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ProjectLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

        }

        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

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
        public async Task<IActionResult> LanguageEdit(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

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
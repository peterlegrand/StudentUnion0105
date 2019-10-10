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
    public class UserProjectController : Controller
    {
        private readonly UserManager<SuUserModel> _userManager;
        private readonly SuDbContext _context;
        private readonly IUserProjectRepository _userProject;

        public UserProjectController(UserManager<SuUserModel> userManager, SuDbContext context, IUserProjectRepository  UserProject)
        {
            _userManager = userManager;
            _context = context;
            _userProject = UserProject;
        }
        public async Task<IActionResult> Index(string Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            //TO DO, should also show the type in the grid. But then I have to do all kind of things.
            //List<SuStatusList> UserProjectFromDb = new List<SuStatusList>();
            List<SuIdWithStrings> UserProjectFromDb = new List<SuIdWithStrings>();
            //           if (_context.dbStatusList.FromSql($"UserProjectSelectAll @P0, @P1",
            //                    parameters: new[] {           Id, //0
            //                                        DefaultLanguageID.ToString()
            //}).Count() == 0) {

            UserProjectFromDb = _context.dbIdWithStrings.FromSql($"UserProjectSelectAll @P0, @P1",
                                    parameters: new[] {           Id, //0
                                        DefaultLanguageID.ToString()
                }).ToList();
            //}

            ViewBag.ObjectId = Id;


            return View(UserProjectFromDb);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            SuObjectVM UserProjectFromDb = _context.dbObjectVM.FromSql($"UserProjectSelectBasedOnUser @P0, @P1",
                   parameters: new[] {           Id.ToString(), //0
                                        DefaultLanguageID.ToString()
}).First();
            return View(UserProjectFromDb);
        }

        [HttpPost]
        public IActionResult Delete(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {

               _userProject.DeleteUserProject(FromForm.Id);
                return RedirectToAction("Index", new { Id = FromForm.Description });
            }
            return RedirectToAction("Index", new { Id = FromForm.Description });

        }
        [HttpGet]
        public async Task<IActionResult> Create(string Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var ProjectList = new List<SelectListItem>();
            var TypeList = new List<SelectListItem>();

            var ProjectsFromDB = _context.dbStatusList.FromSql($"UserProjectNewProjectsSelect @P0, @P1",
                    parameters: new[] {           Id, //0
                                        DefaultLanguageID.ToString()
                                    }).ToList();

            foreach (var ProjectFromDB in ProjectsFromDB)
            {
                ProjectList.Add(new SelectListItem
                {
                    Value = ProjectFromDB.Id.ToString(),
                    Text = ProjectFromDB.Name
                });
            }

            var TypesFromDB = _context.dbTypeList.FromSql($"UserProjectTypeSelectAll @P0",
                    parameters: new[] {           
                                        DefaultLanguageID.ToString()
                                    }).ToList();

            foreach (var TypeFromDB in TypesFromDB)
            {
                TypeList.Add(new SelectListItem
                {
                    Value = TypeFromDB.Id.ToString(),
                    Text = TypeFromDB.Name
                });
            }

            SuObjectVM NewUserProject = new SuObjectVM();
            NewUserProject.Description = Id;
            var ClassificationAndStatus = new SuObjectAndStatusViewModel { SuObject = NewUserProject, SomeKindINumSelectListItem = ProjectList, ProbablyTypeListItem = TypeList };
            return View(ClassificationAndStatus);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;

                var a = _context.Database.ExecuteSqlCommand("UserProjectCreate @p0, @p1, @p2, @p3",
                    parameters: new[] { FromForm.SuObject.Description           //0
                                           , FromForm.SuObject.Status.ToString()
                                           , FromForm.SuObject.Type.ToString()
                                           , CurrentUser.Id


                    });

            }
            return RedirectToAction("Index", new { Id = FromForm.SuObject.Description });

        }

    }
}
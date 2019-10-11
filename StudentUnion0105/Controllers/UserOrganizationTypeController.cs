﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{
    public class UserOrganizationTypeController : Controller
    {
        private readonly UserManager<SuUserModel> _userManager;
        private readonly IUserOrganizationTypeRepository _userOrganizationType;
        private readonly IUserOrganizationTypeLanguageRepository _userOrganizationTypeLanguage;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public UserOrganizationTypeController(UserManager<SuUserModel> userManager
            , IUserOrganizationTypeRepository userOrganizationType
            , IUserOrganizationTypeLanguageRepository UserOrganizationTypeLanguage
            , ILanguageRepository language
            , SuDbContext context)
        {
            _userManager = userManager;
            _userOrganizationType = userOrganizationType;
            _userOrganizationTypeLanguage = UserOrganizationTypeLanguage;
            _language = language;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray("UserOrganizationType", "Index", DefaultLanguageID);

            var ToForm = (

                from u in _userOrganizationType.GetAllUserOrganizationTypes()

                select new SuObjectVM


                {
                    Id = u.Id
                             ,
                    Name = u.Name
                             ,
                    Description = u.Description
                }).ToList();
            return View(ToForm);
        }
        public async Task<IActionResult> LanguageIndex(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray("UserOrganizationType", "LanguageIndex", DefaultLanguageID);

            var UserOrganizationLanguageList = _context.dbIdWithStrings.FromSql("UserOrganizationTypeSelectAllLanguages @p0",
     parameters: new[] {             //0
                                        Id.ToString()
        }).ToList();
            ViewBag.Id = Id;

            return View(UserOrganizationLanguageList);
        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var UserOrganizationType =  _context.dbUserOrganizationTypeLanguage.FromSql($"UserOrganizationTypeSelectLanguage @p0",
                 parameters: new[] {             //0
                                        Id.ToString()
                    }).First();

            return View(UserOrganizationType); //SuUITermLanguage


        }

        [HttpPost]
        public async Task<IActionResult> LanguageEdit(SuUserOrganizationTypeLanguageModel FromForm)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var CurrentUserId = CurrentUser.Id;

            if (ModelState.IsValid)
            {
                var c = _context.Database.ExecuteSqlCommand($"UserOrganizationTypeUpdate @P0, @P1, @P2, @P3, @P4, @P5",
                 parameters: new[] {             //0
                                       FromForm.Id.ToString()
                                       , FromForm.Name
                                       , FromForm.Description
                                       , FromForm.MenuName
                                       , FromForm.MouseOver
                                       , CurrentUserId
                    });
            }
            //            return  RedirectToRoute("EditRole" + "/"+FromForm.Classification.ClassificationId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = FromForm.TypeId.ToString() });



        }


    }
}
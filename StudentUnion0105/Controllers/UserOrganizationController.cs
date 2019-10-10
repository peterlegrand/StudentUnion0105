using System;
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
    public class UserOrganizationController : Controller
    {
        private readonly UserManager<SuUserModel> _userManager;
        private readonly SuDbContext _context;
        private readonly IUserOrganizationRepository _userOrganization;

        public UserOrganizationController(UserManager<SuUserModel> userManager, SuDbContext context, IUserOrganizationRepository  UserOrganization)
        {
            _userManager = userManager;
            _context = context;
            _userOrganization = UserOrganization;
        }
        public async Task<IActionResult> Index(string Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            //TO DO, should also show the type in the grid. But then I have to do all kind of things.
            //List<SuStatusList> UserOrganizationFromDb = new List<SuStatusList>();
            List<SuIdWithStrings> UserOrganizationFromDb = new List<SuIdWithStrings>();
            //           if (_context.dbStatusList.FromSql($"UserOrganizationSelectAll @P0, @P1",
            //                    parameters: new[] {           Id, //0
            //                                        DefaultLanguageID.ToString()
            //}).Count() == 0) {

            UserOrganizationFromDb = _context.dbIdWithStrings.FromSql($"UserOrganizationSelectAll @P0, @P1",
                                    parameters: new[] {           Id, //0
                                        DefaultLanguageID.ToString()
                }).ToList();
            //}

            ViewBag.ObjectId = Id;


            return View(UserOrganizationFromDb);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            SuObjectVM UserOrganizationFromDb = _context.dbObjectVM.FromSql($"UserOrganizationSelectBasedOnUser @P0, @P1",
                   parameters: new[] {           Id.ToString(), //0
                                        DefaultLanguageID.ToString()
}).First();
            return View(UserOrganizationFromDb);
        }

        [HttpPost]
        public IActionResult Delete(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {

               _userOrganization.DeleteUserOrganization(FromForm.Id);
                return RedirectToAction("Index", new { Id = FromForm.Description });
            }
            return RedirectToAction("Index", new { Id = FromForm.Description });

        }
        [HttpGet]
        public async Task<IActionResult> Create(string Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var OrganizationList = new List<SelectListItem>();
            var TypeList = new List<SelectListItem>();

            var OrganizationsFromDB = _context.dbStatusList.FromSql($"UserOrganizationNewOrganizationsSelect @P0, @P1",
                    parameters: new[] {           Id, //0
                                        DefaultLanguageID.ToString()
                                    }).ToList();

            foreach (var OrganizationFromDB in OrganizationsFromDB)
            {
                OrganizationList.Add(new SelectListItem
                {
                    Value = OrganizationFromDB.Id.ToString(),
                    Text = OrganizationFromDB.Name
                });
            }

            var TypesFromDB = _context.dbTypeList.FromSql($"UserOrganizationTypeSelectAll @P0",
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

            SuObjectVM NewUserOrganization = new SuObjectVM();
            NewUserOrganization.Description = Id;
            var ClassificationAndStatus = new SuObjectAndStatusViewModel { SuObject = NewUserOrganization, SomeKindINumSelectListItem = OrganizationList, ProbablyTypeListItem = TypeList };
            return View(ClassificationAndStatus);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;

                var a = _context.Database.ExecuteSqlCommand("UserOrganizationCreate @p0, @p1, @p2, @p3",
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
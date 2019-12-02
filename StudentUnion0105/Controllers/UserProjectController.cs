using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
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

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            List<SuIdWithStrings> UserProjectFromDb = new List<SuIdWithStrings>();

            SqlParameter[] parameters =
                {
                    new SqlParameter("@User", Id)
                    , new SqlParameter("@LanguageId", DefaultLanguageID)
                };

            UserProjectFromDb = _context.DbIdWithStrings.FromSql($"UserProjectSelectAll @User, @LanguageId", parameters).ToList();

            ViewBag.ObjectId = Id;


            return View(UserProjectFromDb);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
    {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@Id", Id)
                };

            SuObjectVM UserProjectFromDb = _context.DbObjectVM.FromSql("UserProjectSelectBasedOnUser @LanguageId, @Id", parameters).First();
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

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ProjectList = new List<SelectListItem>();
            var TypeList = new List<SelectListItem>();
            SqlParameter[] parameters =
    {
                    new SqlParameter("@User", Id)
                    , new SqlParameter("@LanguageId", DefaultLanguageID)
                };

            var ProjectsFromDB = _context.ZDbStatusList.FromSql("UserProjectNewProjectsSelect @User, @LanguageId", parameters).ToList();

            foreach (var ProjectFromDB in ProjectsFromDB)
            {
                ProjectList.Add(new SelectListItem
                {
                    Value = ProjectFromDB.Id.ToString(),
                    Text = ProjectFromDB.Name
                });
            }

            var parameter = new SqlParameter("@LanguageId", DefaultLanguageID);

            var TypesFromDB = _context.DbTypeList.FromSql($"UserProjectTypeSelectAll @LanguageId", parameter).ToList();

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
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

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
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("UserOrganizationTypeLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);
        }

        [HttpGet]
        public async  Task<IActionResult> LanguageEdit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@Id", Id);
            //PETER this SP is missing
            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("UserOrganizationTypeLanguageEditGet @Id", parameter).First();
            return View(ObjectLanguage);



        }

        [HttpPost]
        public async Task<IActionResult> LanguageEdit(SuUserOrganizationTypeLanguageModel FromForm)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var CurrentUserId = CurrentUser.Id;

            if (ModelState.IsValid)
            {

                SqlParameter[] parameters =
                {
                    new SqlParameter("@LId", FromForm.Id)
                    , new SqlParameter("@Name", FromForm.Name)
                    , new SqlParameter("@Description", FromForm.Description)
                    , new SqlParameter("@MouseOver", FromForm.MouseOver)
                    , new SqlParameter("@MenuName", FromForm.MenuName)
                    , new SqlParameter("@Modifier", CurrentUserId)
                };

                var c = _context.Database.ExecuteSqlCommand("UserOrganizationTypeLanguageEditPost @PLId, @Name, @Description, @MouseOver, @MenuName, @Modifier",
                 parameters);
            }

            return RedirectToAction("LanguageIndex", new { Id = FromForm.TypeId.ToString() });



        }


    }
}
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
        public async Task<IActionResult> LanguageEdit(SuObjectLanguageEditGetModel FromForm)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var CurrentUserId = CurrentUser.Id;

            if (ModelState.IsValid)
            {

                SqlParameter[] parameters =
                {
                    new SqlParameter("@LId", FromForm.LId)
                    , new SqlParameter("@Name", FromForm.Name)
                    , new SqlParameter("@Description", FromForm.Description)
                    , new SqlParameter("@MouseOver", FromForm.MouseOver)
                    , new SqlParameter("@MenuName", FromForm.MenuName)
                    , new SqlParameter("@Modifier", CurrentUserId)
                };

                var c = _context.Database.ExecuteSqlCommand("UserOrganizationTypeLanguageEditPost @LId, @Name, @Description, @MouseOver, @MenuName, @Modifier",
                 parameters);
            }

            return RedirectToAction("LanguageIndex", new { Id = FromForm.OId.ToString() });



        }

        //
        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            AvailableObjectLanguages AvailableLanguages = new AvailableObjectLanguages(_context);
            var SuLanguage = AvailableLanguages.ReturnFreeLanguages(this.ControllerContext.RouteData.Values["controller"].ToString(), parameter);
            Int32 NoOfLanguages = SuLanguage.Count();
            if (NoOfLanguages == 0)
            { return RedirectToAction("LanguageIndex", new { Id = Id }); }

            SuObjectLanguageCreateGetModel UserOrganizationType = new SuObjectLanguageCreateGetModel();
            UserOrganizationType.OId = Id;
            ViewBag.Id = Id.ToString();
            var UserOrganizationTypeAndLanguages = new SuObjectLanguageCreateGetWithListModel
            {
                ObjectLanguage = UserOrganizationType

                ,
                LanguageList = SuLanguage
            };
            return View(UserOrganizationTypeAndLanguages);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageCreate(SuObjectLanguageCreateGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);

                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.ObjectLanguage.OId),
                    new SqlParameter("@LanguageId", FromForm.ObjectLanguage.LanguageId),
                    new SqlParameter("@Name", FromForm.ObjectLanguage.Name),
                    new SqlParameter("@Description", FromForm.ObjectLanguage.Description),
                    new SqlParameter("@MouseOver", FromForm.ObjectLanguage.MouseOver),
                    new SqlParameter("@MenuName", FromForm.ObjectLanguage.MenuName),
                    new SqlParameter("@ModifierId", CurrentUser.Id)
                    };

                _context.Database.ExecuteSqlCommand("UserOrganizationTypeLanguageCreatePost " +
                            "@Id" +
                            ", @LanguageId" +
                            ", @MenuName" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @ModifierId", parameters);
            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.ObjectLanguage.OId.ToString() });
        }

        //


    }
}
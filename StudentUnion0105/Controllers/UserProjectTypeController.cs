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
    public class UserProjectTypeController : Controller
    {
        private readonly UserManager<SuUserModel> _userManager;
        private readonly IUserProjectTypeRepository _userProjectType;
        private readonly IUserProjectTypeLanguageRepository _userProjectTypeLanguage;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public UserProjectTypeController(UserManager<SuUserModel> userManager
            , IUserProjectTypeRepository userProjectType
            , IUserProjectTypeLanguageRepository UserProjectTypeLanguage
            , ILanguageRepository language
            , SuDbContext context)
        {
            _userManager = userManager;
            _userProjectType = userProjectType;
            _userProjectTypeLanguage = UserProjectTypeLanguage;
            _language = language;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);


            var parameter = new SqlParameter("@LanguageId", DefaultLanguageID);
            //PETER cannot be generic object
            var UserProjectTypes = _context.ZdbObjectIndexGet.FromSql("UserProjectTypeIndexGet @LanguageId", parameter).ToList();

            return View(UserProjectTypes);
        }
        public async Task<IActionResult> LanguageIndex(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("UserProjectTypeLanguageIndexGet @OId", parameter).ToList();
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
            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("UserProjectTypeLanguageEditGet @Id", parameter).First();
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

                var c = _context.Database.ExecuteSqlCommand("UserProjectTypeLanguageEditPost @LId, @Name, @Description, @MouseOver, @MenuName, @Modifier",
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

            SuObjectLanguageCreateGetModel UserProjectType = new SuObjectLanguageCreateGetModel();
            UserProjectType.OId = Id;
            ViewBag.Id = Id.ToString();
            var UserProjectTypeAndLanguages = new SuObjectLanguageCreateGetWithListModel
            {
                ObjectLanguage = UserProjectType

                ,
                LanguageList = SuLanguage
            };
            return View(UserProjectTypeAndLanguages);
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

                _context.Database.ExecuteSqlCommand("UserProjectTypeLanguageCreatePost " +
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
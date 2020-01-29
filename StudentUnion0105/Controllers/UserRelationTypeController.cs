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
    public class UserRelationTypeController : PortalController
    {
        private readonly IUserRelationTypeRepository _userRelationType;
        private readonly IUserRelationTypeLanguageRepository _userRelationTypeLanguage;
        private readonly SuDbContext _context;

        public UserRelationTypeController(UserManager<SuUserModel> userManager
            , IUserRelationTypeRepository userRelationType
            , IUserRelationTypeLanguageRepository UserRelationTypeLanguage
            , ILanguageRepository language
            , SuDbContext context) : base(userManager, language)
        {
            _userRelationType = userRelationType;
            _userRelationTypeLanguage = UserRelationTypeLanguage;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);
            //PETER cannot be generic object
            List< SuUserRelationTypeIndexGetModel> UserRelationTypes = _context.ZdbUserRelationTypeIndexGet.FromSql("UserRelationTypeIndexGet @LanguageId", parameter).ToList();

            return View(UserRelationTypes);
        }
        public async Task<IActionResult> LanguageIndex(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@LanguageId", Id);

            var LanguageIndex = _context.ZdbUserRelationTypeLanguageIndexGet.FromSql("UserRelationTypeLanguageIndexGet @LanguageId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);
        }

        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@Id", Id);
            //PETER this SP is missing
            var UserRelationTypeLanguage = _context.ZdbUserRelationTypeLanguageEditGet.FromSql("UserRelationTypeLanguageEditGet @Id", parameter).First();
            return View(UserRelationTypeLanguage);



        }

        [HttpPost]
        public async Task<IActionResult> LanguageEdit(SuUserRelationTypeLanguageEditGetModel FromForm)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);

            var CurrentUserId = CurrentUser.Id;

            if (ModelState.IsValid)
            {

                SqlParameter[] parameters =
                {
                    new SqlParameter("@LId", FromForm.LId),
                    new SqlParameter("@FromIsOfToName", FromForm.FromIsOfToName),
                    new SqlParameter("@ToIsOfFromName", FromForm.ToIsOfFromName),
                    new SqlParameter("@FromIsOfToDescription", FromForm.FromIsOfToDescription),
                    new SqlParameter("@ToIsOfFromDescription", FromForm.ToIsOfFromDescription),
                    new SqlParameter("@FromIsOfToMouseOver", FromForm.FromIsOfToMouseOver),
                    new SqlParameter("@ToIsOfFromMouseOver", FromForm.ToIsOfFromMouseOver),
                    new SqlParameter("@FromIsOfToMenuName", FromForm.FromIsOfToMenuName),
                    new SqlParameter("@ToIsOfFromMenuName", FromForm.ToIsOfFromMenuName),
                    new SqlParameter("@Modifier", CurrentUserId)
                };

                _context.Database.ExecuteSqlCommand("UserRelationTypeLanguageEditPost " +
                    "@LId" +
                    ", @FromIsOfToName" +
                    ", @ToIsOfFromName" +
                    ", @FromIsOfToDescription" +
                    ", @ToIsOfFromDescription" +
                    ", @FromIsOfToMouseOver" +
                    ", @ToIsOfFromMouseOver" +
                    ", @FromIsOfToMenuName" +
                    ", @ToIsOfFromMenuName" +
                    ", @Modifier",
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
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            AvailableObjectLanguages AvailableLanguages = new AvailableObjectLanguages(_context);
            var SuLanguage = AvailableLanguages.ReturnFreeLanguages(this.ControllerContext.RouteData.Values["controller"].ToString(), parameter);
            Int32 NoOfLanguages = SuLanguage.Count();
            if (NoOfLanguages == 0)
            { return RedirectToAction("LanguageIndex", new { Id }); }

            SuUserRelationTypeLanguageCreateGetModel UserRelationType = new SuUserRelationTypeLanguageCreateGetModel
            {
                OId = Id
            };
            ViewBag.Id = Id.ToString();
            var UserRelationTypeAndLanguages = new SuUserRelationTypeLanguageCreateGetWithListModel
            {
                UserRelationType = UserRelationType

                ,
                LanguageList = SuLanguage
            };
            return View(UserRelationTypeAndLanguages);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageCreate(SuUserRelationTypeLanguageCreateGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);

                SqlParameter[] parameters =
                    {
                    new SqlParameter("@OId", FromForm.UserRelationType.OId),
                    new SqlParameter("@LanguageId", FromForm.UserRelationType.LanguageId),
                    new SqlParameter("@FromIsOfToName", FromForm.UserRelationType.FromIsOfToName),
                    new SqlParameter("@ToIsOfFromName", FromForm.UserRelationType.ToIsOfFromName),
                    new SqlParameter("@FromIsOfToDescription", FromForm.UserRelationType.FromIsOfToDescription),
                    new SqlParameter("@ToIsOfFromDescription", FromForm.UserRelationType.ToIsOfFromDescription),
                    new SqlParameter("@FromIsOfToMouseOver", FromForm.UserRelationType.FromIsOfToMouseOver),
                    new SqlParameter("@ToIsOfFromMouseOver", FromForm.UserRelationType.ToIsOfFromMouseOver),
                    new SqlParameter("@FromIsOfToMenuName", FromForm.UserRelationType.FromIsOfToMenuName),
                    new SqlParameter("@ToIsOfFromMenuName", FromForm.UserRelationType.ToIsOfFromMenuName),
                    new SqlParameter("@ModifierId", CurrentUser.Id)
                    };

                _context.Database.ExecuteSqlCommand("UserRelationTypeLanguageCreatePost " +
                            "@OId" +
                            ", @LanguageId" +
                            ", @FromIsOfToName" +
                            ", @ToIsOfFromName" +
                            ", @FromIsOfToDescription" +
                            ", @ToIsOfFromDescription" +
                            ", @FromIsOfToMouseOver" +
                            ", @ToIsOfFromMouseOver" +
                            ", @FromIsOfToMenuName" +
                            ", @ToIsOfFromMenuName" +
                            ", @ModifierId", parameters);
            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.UserRelationType.OId.ToString() });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@Id", Id)
                };

            var UserRelationType = _context.ZdbUserRelationTypeLanguageDeleteGet.FromSql("SuUserRelationTypeLanguageDeleteGetModel @LanguageId, @Id", parameters).First();

            return View(UserRelationType);
        }
        [HttpPost]
        public IActionResult Delete(SuUserRelationTypeLanguageDeleteGetModel FromForm)
        {
            SqlParameter parameter = new SqlParameter("@Id", FromForm.LId);
            _context.Database.ExecuteSqlCommand("UserRelationTypeDeletePost @Id", parameter);

            return RedirectToAction("Index");

        }

    }
}
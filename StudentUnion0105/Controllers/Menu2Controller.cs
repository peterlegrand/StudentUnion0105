using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Models.ViewModels;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class Menu2Controller : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public Menu2Controller(UserManager<SuUserModel> userManager
            , ILanguageRepository language
            , SuDbContext context)
        {
            this.userManager = userManager;
            _language = language;
            _context = context;
        }
        
        
        public async Task<IActionResult> Index(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
    {
                    new SqlParameter("@Id", Id)
                    , new SqlParameter("@LanguageId", DefaultLanguageID)
                };

            var Menu2 = _context.ZdbMenu2IndexGet.FromSql("Menu2IndexGet @Id, @LanguageId", parameters).ToList();
            ViewBag.ObjectId = Id.ToString();
            return View(Menu2);

        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);


            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@Id", Id)
                };

            var Menu2EditGet = _context.ZdbMenu2EditGet.FromSql("Menu2EditGet @LanguageId, @Id", parameters).First();

            var parameter = new SqlParameter("@LanguageId", DefaultLanguageID);

            var Classifications = _context.ZDbTypeList.FromSql("Menu123EditGetClassificationList @LanguageId", parameter).ToList();

            var ClassificationList = new List<SelectListItem>();
            foreach (var Classification in Classifications)
            {
                ClassificationList.Add(new SelectListItem
                {
                    Text = Classification.Name,
                    Value = Classification.Id.ToString()
                });
            }
            var MenuTypes = _context.ZDbTypeList.FromSql("MenuTypeList").ToList();

            var MenuTypeList = new List<SelectListItem>();
            foreach (var MenuType in MenuTypes)
            {
                MenuTypeList.Add(new SelectListItem
                {
                    Text = MenuType.Name,
                    Value = MenuType.Id.ToString()
                });
            }

            SuMenu2EditGetWithListModel Menu2WithList = new SuMenu2EditGetWithListModel();

            Menu2WithList.Menu2 = Menu2EditGet;
            Menu2WithList.ClassificationList = ClassificationList;
            Menu2WithList.MenuTypeList = MenuTypeList;
            return View(Menu2WithList);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuMenu2EditGetWithListModel FromForm)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            SqlParameter[] parameters =
                {
                    new SqlParameter("@Id", FromForm.Menu2.Id),
                    new SqlParameter("@LanguageId", DefaultLanguageID),
                    new SqlParameter("@Sequence", FromForm.Menu2.Sequence),
                    new SqlParameter("@ClassificationId", FromForm.Menu2.ClassificationId),
                    new SqlParameter("@FeatureId", FromForm.Menu2.FeatureId),
                    new SqlParameter("@Controller", FromForm.Menu2.Controller ??""),
                    new SqlParameter("@Action", FromForm.Menu2.Action ??""),
                    new SqlParameter("@DestinationId", FromForm.Menu2.DestinationId),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@MenuName", FromForm.Menu2.MenuName),
                    new SqlParameter("@MouseOver", FromForm.Menu2.MouseOver)
                    };
            var b = _context.Database.ExecuteSqlCommand("Menu2EditPost " +
                        "@Id" +
                        ", @LanguageId" +
                        ", @Sequence" +
                        ", @ClassificationId" +
                        ", @FeatureId" +
                        ", @Controller" +
                        ", @Action" +
                        ", @DestinationId" +
                        ", @ModifierId" +
                        ", @MenuName" +
                        ", @MouseOver", parameters);
        
            return RedirectToAction("Index");
    }

    [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@LanguageId", DefaultLanguageID);
            var Classifications = _context.ZDbStatusList.FromSql("Menu123EditGetClassificationList @LanguageId", parameter).ToList();

            var ClassificationList = new List<SelectListItem>();
            foreach (var Classification in Classifications)
            {
                ClassificationList.Add(new SelectListItem
                {
                    Text = Classification.Name,
                    Value = Classification.Id.ToString()
                });
            }

            var MenuTypes = _context.ZDbTypeList.FromSql("MenuTypeList").ToList();

            var MenuTypeList = new List<SelectListItem>();
            foreach (var MenuType in MenuTypes)
            {
                MenuTypeList.Add(new SelectListItem
                {
                    Text = MenuType.Name,
                    Value = MenuType.Id.ToString()
                });
            }

            var Menu2AndList = new SuMenu2EditGetWithListModel { ClassificationList = ClassificationList, MenuTypeList = MenuTypeList };
            Menu2AndList.Menu2.Menu1Id = Id;
            return View(Menu2AndList);

        }

        [HttpPost]
        public async Task<IActionResult> Create(SuMenu2EditGetWithListModel FromForm)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            SqlParameter[] parameters =
                {
                    new SqlParameter("@Menu1Id", FromForm.Menu2.Menu1Id),
                    new SqlParameter("@MenuTypeId", FromForm.Menu2.MenuTypeId),
                    new SqlParameter("@Sequence", FromForm.Menu2.Sequence),
                    new SqlParameter("@ClassificationId", FromForm.Menu2.ClassificationId),
                    new SqlParameter("@FeatureId", FromForm.Menu2.FeatureId),
                    new SqlParameter("@Controller", FromForm.Menu2.Controller),
                    new SqlParameter("@Action", FromForm.Menu2.Action),
                    new SqlParameter("@DestinationId", FromForm.Menu2.DestinationId),
                    new SqlParameter("@LanguageId", DefaultLanguageID),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@MenuName", FromForm.Menu2.MenuName),
                    new SqlParameter("@MouseOver", FromForm.Menu2.MouseOver)
                    };

            _context.Database.ExecuteSqlCommand("Menu2CreatePost " +
                        "@Menu1Id" +
                        "@MenuTypeId" +
                        ", @Sequence" +
                        ", @ClassificationId" +
                        ", @FeatureId" +
                        ", @Controller" +
                        ", @Action" +
                        ", @DestinationId" +
                        ", @LanguageId" +
                        ", @ModifierId" +
                        ", @MenuName" +
                        ", @MouseOver", parameters);
            return RedirectToAction("Index", new { Id = FromForm.Menu2.Menu1Id.ToString() });
        }


        public async Task<IActionResult> LanguageIndex(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("Menu2LanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);
        }

        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@LId", Id);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("Menu2LanguageEditGet @LId", parameter).First();
            return View(ObjectLanguage);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageEdit(SuObjectLanguageEditGetModel FromForm)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            if (ModelState.IsValid)
            {

                SqlParameter[] parameters =
                    {
                    new SqlParameter("@LId", FromForm.LId),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@MenuName", FromForm.MenuName),
                    new SqlParameter("@MouseOver", FromForm.MouseOver)
                    };

                _context.Database.ExecuteSqlCommand("Menu2LanguageEditPost " +
                            "@LId" +
                            ", @ModifierId" +
                            ", @MenuName" +
                            ", @MouseOver", parameters);
                return RedirectToAction("LanguageIndex", new { Id = FromForm.OId.ToString() });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            AvailableObjectLanguages AvailableLanguages = new AvailableObjectLanguages(_context);
            var SuLanguage = AvailableLanguages.ReturnFreeLanguages(this.ControllerContext.RouteData.Values["controller"].ToString(), parameter);
            Int32 NoOfLanguages = SuLanguage.Count();
            if (NoOfLanguages == 0)
            { return RedirectToAction("LanguageIndex", new { Id = Id }); }

            SuObjectLanguageCreateGetModel Menu2 = new SuObjectLanguageCreateGetModel();
            Menu2.OId = Id;
            ViewBag.Id = Id.ToString();
            var Menu2AndLanguages = new SuObjectLanguageCreateGetWithListModel
            {
                ObjectLanguage = Menu2

                ,
                LanguageList = SuLanguage
            };
            return View(Menu2AndLanguages);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageCreate(SuObjectLanguageCreateGetWithListModel FromForm)
        {

            var CurrentUser = await userManager.GetUserAsync(User);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@Id", FromForm.ObjectLanguage.OId),
                    new SqlParameter("@LanguageId", FromForm.ObjectLanguage.LanguageId),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@MenuName", FromForm.ObjectLanguage.MenuName),
                    new SqlParameter("@MouseOver", FromForm.ObjectLanguage.MouseOver)
                    };

            _context.Database.ExecuteSqlCommand("Menu2LanguageCreatePost " +
                        "@Id" +
                        ", @LanguageId" +
                        ", @ModifierId" +
                        ", @MenuName" +
                        ", @MouseOver", parameters);

            return RedirectToAction("LanguageIndex", new { Id = FromForm.ObjectLanguage.OId.ToString() });
        }

        [HttpGet]
        public async Task<IActionResult> LanguageDelete(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@LId", Id);
            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("Menu2LanguageEditGet @LId", parameter).First();
            return View(ObjectLanguage);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectLanguageEditGetModel FromForm)
        {
            var parameter = new SqlParameter("@Id", FromForm.LId);
            var b = _context.Database.ExecuteSqlCommand("Menu2LanguageDeletePost @Id", parameter);

            return RedirectToAction("LanguageIndex", new { Id = FromForm.OId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
    {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@Id", Id)
                };

            SuMenu2DeleteGetModel Menu2 = _context.ZdbMenu2DeleteGet.FromSql("Menu2DeleteGet @LanguageId, @Id", parameters).First();



            return View(Menu2);
        }

        [HttpPost]
        public IActionResult Delete(SuMenu2DeleteGetModel FromForm)
        {
            var parameter = new SqlParameter("@OId", FromForm.OId);
            var b = _context.Database.ExecuteSqlCommand($"Menu2DeletePost @OId", parameter);

            return RedirectToAction("Index");

        }

    }
}

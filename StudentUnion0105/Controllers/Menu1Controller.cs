using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Authorize("Menu1")]
    public class Menu1Controller : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;


        public Menu1Controller(UserManager<SuUserModel> userManager
                                                , ILanguageRepository language
                                                , SuDbContext context
            )
        {
            this.userManager = userManager;
            _language = language;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@LanguageId", DefaultLanguageID);

            var Menu1 = _context.ZdbMenu1IndexGet.FromSql("Menu1IndexGet @LanguageId", parameter).ToList();
            
            return View(Menu1);
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

            var Menu1EditGet = _context.ZdbMenu1EditGet.FromSql("Menu1EditGet @LanguageId, @Id", parameters).First();

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
            SuMenu1EditGetWithListModel Menu1WithList  = new SuMenu1EditGetWithListModel();

            Menu1WithList.Menu1 = Menu1EditGet;
            Menu1WithList.ClassificationList = ClassificationList;

            return View(Menu1WithList);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuMenu1EditGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.Menu1.Id),
                    new SqlParameter("@LanguageId", DefaultLanguageID),
                    new SqlParameter("@Sequence", FromForm.Menu1.Sequence),
                    new SqlParameter("@ClassificationId", FromForm.Menu1.ClassificationId),
                    new SqlParameter("@FeatureId", FromForm.Menu1.FeatureId),
                    new SqlParameter("@Controller", FromForm.Menu1.Controller),
                    new SqlParameter("@Action", FromForm.Menu1.Action),
                    new SqlParameter("@DestinationId", FromForm.Menu1.DestinationId),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@MenuName", FromForm.Menu1.MenuName),
                    new SqlParameter("@MouseOver", FromForm.Menu1.MouseOver)
                    };
                var b = _context.Database.ExecuteSqlCommand("Menu1EditPost " +
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
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

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

            var Menu1AndList = new SuMenu1EditGetWithListModel { ClassificationList = ClassificationList};
            return View(Menu1AndList);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(SuMenu1EditGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;

                SqlParameter[] parameters =
                    {
                    new SqlParameter("@MenuTypeId", FromForm.Menu1.MenuTypeId),
                    new SqlParameter("@Sequence", FromForm.Menu1.Sequence),
                    new SqlParameter("@ClassificationId", FromForm.Menu1.ClassificationId),
                    new SqlParameter("@FeatureId", FromForm.Menu1.FeatureId),
                    new SqlParameter("@Controller", FromForm.Menu1.Controller),
                    new SqlParameter("@Action", FromForm.Menu1.Action),
                    new SqlParameter("@DestinationId", FromForm.Menu1.DestinationId),
                    new SqlParameter("@LanguageId", FromForm.Menu1.LanguageId),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@MenuName", FromForm.Menu1.MenuName),
                    new SqlParameter("@MouseOver", FromForm.Menu1.MouseOver)
                    };

                _context.Database.ExecuteSqlCommand("Menu1CreatePost " +
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

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("Menu1LanguageIndexGet @OId", parameter).ToList();
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

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("Menu1LanguageEditGet @LId", parameter).First();
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

                _context.Database.ExecuteSqlCommand("Menu1LanguageEditPost " +
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

            SuObjectLanguageCreateGetModel Menu1 = new SuObjectLanguageCreateGetModel();
            Menu1.OId= Id;
            ViewBag.Id = Id.ToString();
            var Menu1AndLanguages = new SuObjectLanguageCreateGetWithListModel
            {
                ObjectLanguage = Menu1
                
                ,LanguageList  = SuLanguage 
            };
            return View(Menu1AndLanguages);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageCreate(SuObjectLanguageCreateGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
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

                _context.Database.ExecuteSqlCommand("Menu1LanguageCreatePost " +
                            "@Id" +
                            ", @LanguageId" +
                            ", @ModifierId" +
                            ", @MenuName" +
                            ", @MouseOver", parameters);
            }
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
            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("Menu1LanguageEditGet @LId" , parameter).First();
            return View(ObjectLanguage);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectLanguageEditGetModel FromForm)
        {
            var parameter = new SqlParameter("@Id", FromForm.LId);
            var b = _context.Database.ExecuteSqlCommand("Menu1LanguageDeletePost @Id", parameter);

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

            SuMenu1DeleteGetModel Menu1 = _context.ZdbMenu1DeleteGet.FromSql("Menu1DeleteGet @LanguageId, @Id", parameters).First();



            return View(Menu1);
        }

        [HttpPost]
        public IActionResult Delete(SuMenu1DeleteGetModel FromForm)
        {
            var parameter = new SqlParameter("@OId", FromForm.OId);
            var b = _context.Database.ExecuteSqlCommand($"Menu1DeletePost @OId", parameter);

            return RedirectToAction("Index");

        }

    }
}

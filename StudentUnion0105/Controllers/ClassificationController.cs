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
    [Authorize("Classification")]
    public class ClassificationController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IClassificationStatusRepository _classificationStatus;
        private readonly IClassificationRepository _classification;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;


        public ClassificationController(UserManager<SuUserModel> userManager
                                                , IClassificationStatusRepository classificationStatus
                                                , IClassificationRepository classification
                                                , IClassificationLanguageRepository classificationLanguage
                                                , ILanguageRepository language
                                                , SuDbContext context
            )
        {
            this.userManager = userManager;
            _classificationStatus = classificationStatus;
            _classification = classification;
            _classificationLanguage = classificationLanguage;
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

            var Classification = _context.ZdbObjectIndexGet.FromSql("ClassificationIndexGet @LanguageId", parameter).ToList();
            
            return View(Classification);
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

            var ClassificationEditGet = _context.ZdbClassificationEditGet.FromSql("ClassificationEditGet @LanguageId, @Id", parameters).First();
            
            var ClassificationStatusList = new List<SelectListItem>();
            foreach (var ClassificationStatusFromDb in _classificationStatus.GetAllClassificationStatus())
            {
                ClassificationStatusList.Add(new SelectListItem
                {
                    Text = ClassificationStatusFromDb.Name,
                    Value = ClassificationStatusFromDb.Id.ToString()
                });
            }
            SuClassificationEditGetWithListModel ClassificationWithList  = new SuClassificationEditGetWithListModel();

            ClassificationWithList.Classification = ClassificationEditGet;
            ClassificationWithList.StatusList = ClassificationStatusList;

            return View(ClassificationWithList);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuClassificationEditGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.Classification.Id),
                    new SqlParameter("@LanguageId", DefaultLanguageID),
                    new SqlParameter("@ClassificationStatusId", FromForm.Classification.ClassificationStatusId),
                    new SqlParameter("@DefaultClassificationPageId", FromForm.Classification.DefaultClassificationPageId),
                    new SqlParameter("@HasDropDown", FromForm.Classification.HasDropDown),
                    new SqlParameter("@DropDownSequence", FromForm.Classification.DropDownSequence),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.Classification.Name),
                    new SqlParameter("@Description", FromForm.Classification.Description),
                    new SqlParameter("@MouseOver", FromForm.Classification.MouseOver),
                    new SqlParameter("@MenuName", FromForm.Classification.MenuName)
                    };
                var b = _context.Database.ExecuteSqlCommand("ClassificationEditPost " +
                            "@Id" +
                            ", @LanguageId" +
                            ", @ClassificationStatusId" +
                            ", @DefaultClassificationPageId" +
                            ", @HasDropDown" +
                            ", @DropDownSequence" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName", parameters);
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

            var ClassificationStatusList = new List<SelectListItem>();

            foreach (var ClassificationStatusFromDb in _classificationStatus.GetAllClassificationStatus())
            {
                ClassificationStatusList.Add(new SelectListItem
                {
                    Text = ClassificationStatusFromDb.Name,
                    Value = ClassificationStatusFromDb.Id.ToString()
                });
            }
            var ClassificationAndStatus = new SuClassificationEditGetWithListModel {  StatusList = ClassificationStatusList };
            return View(ClassificationAndStatus);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(SuClassificationEditGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;

                SqlParameter[] parameters =
                    {
                    new SqlParameter("@LanguageId", DefaultLanguageID),
                    new SqlParameter("@ClassificationStatusId", FromForm.Classification.ClassificationStatusId),
                    new SqlParameter("@DefaultClassificationPageId", FromForm.Classification.DefaultClassificationPageId),
                    new SqlParameter("@HasDropDown", FromForm.Classification.HasDropDown),
                    new SqlParameter("@DropDownSequence", FromForm.Classification.DropDownSequence),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.Classification.Name),
                    new SqlParameter("@Description", FromForm.Classification.Description),
                    new SqlParameter("@MouseOver", FromForm.Classification.MouseOver),
                    new SqlParameter("@MenuName", FromForm.Classification.MenuName)
                    };

                _context.Database.ExecuteSqlCommand("ClassificationCreatePost " +
                            "@LanguageId" +
                            ", @ClassificationStatusId" +
                            ", @DefaultClassificationPageId" +
                            ", @HasDropDown" +
                            ", @DropDownSequence" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName", parameters);
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

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ClassificationLanguageIndexGet @OId", parameter).ToList();
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

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ClassificationLanguageEditGet @LId", parameter).First();
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
                    new SqlParameter("@Name", FromForm.Name),
                    new SqlParameter("@Description", FromForm.Description),
                    new SqlParameter("@MouseOver", FromForm.MouseOver),
                    new SqlParameter("@MenuName", FromForm.MenuName)
                    };

                _context.Database.ExecuteSqlCommand("ClassificationLanguageEditPost " +
                            "@LId" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName", parameters);
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

            SuObjectLanguageCreateGetModel Classification = new SuObjectLanguageCreateGetModel();
            Classification.OId= Id;
            ViewBag.Id = Id.ToString();
            var ClassificationAndLanguages = new SuObjectLanguageCreateGetWithListModel
            {
                ObjectLanguage = Classification
                
                ,LanguageList  = SuLanguage 
            };
            return View(ClassificationAndLanguages);
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
                    new SqlParameter("@Name", FromForm.ObjectLanguage.Name),
                    new SqlParameter("@Description", FromForm.ObjectLanguage.Description),
                    new SqlParameter("@MouseOver", FromForm.ObjectLanguage.MouseOver),
                    new SqlParameter("@MenuName", FromForm.ObjectLanguage.MenuName)
                    };

                _context.Database.ExecuteSqlCommand("ClassificationLanguageCreatePost " +
                            "@Id" +
                            ", @LanguageId" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName", parameters);
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
            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ClassificationLanguageEditGet @LId" , parameter).First();
            return View(ObjectLanguage);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectLanguageEditGetModel FromForm)
        {
                _classificationLanguage.DeleteClassificationLanguage(FromForm.LId);
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

            SuClassificationDeleteGetModel Classification = _context.ZdbClassificationDeleteGet.FromSql("ClassificationDeleteGet @LanguageId, @Id", parameters).First();



            return View(Classification);
        }

        [HttpPost]
        public IActionResult Delete(SuClassificationDeleteGetModel FromForm)
        {
            var parameter = new SqlParameter("@OId", FromForm.OId);
            var b = _context.Database.ExecuteSqlCommand($"ClassificationDeletePost @OId", parameter);

            return RedirectToAction("Index");

        }

    }
}

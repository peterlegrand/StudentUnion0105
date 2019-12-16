using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class ClassificationLevelController : Controller
    {
        private readonly UserManager<SuUserModel> _userManager;
        private readonly SuDbContext _context;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly IClassificationLevelRepository _classificationLevel;
        private readonly IClassificationLevelLanguageRepository _classificationLevelLanguage;
        private readonly ILanguageRepository _language;
        
        public ClassificationLevelController(UserManager<SuUserModel> userManager
            , IClassificationLanguageRepository classificationLanguage
            , IClassificationLevelRepository classificationLevel
            , IClassificationLevelLanguageRepository classificationLevelLanguage
            , ILanguageRepository language
            , SuDbContext context
            )
        {
            _userManager = userManager;
            _classificationLanguage = classificationLanguage;
            _classificationLevel = classificationLevel;
            _classificationLevelLanguage = classificationLevelLanguage;
            _language = language;
            _context = context;
        }

        public async Task<IActionResult> Index(int Id)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@Id", Id)
                };
            var ClassificationLevel = _context.ZdbObjectIndexGet.FromSql("ClassificationLevelIndexGet @Id, @LanguageId", parameters).ToList();
           //PETER Why do I need this viewbag
            ViewBag.PId = Id;
            return View(ClassificationLevel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;
        
            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
    {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@OId", Id)
                };

           SuClassificationLevelEditGetModel ClassificationLevelEditGet = _context.ZdbClassificationLevelEditGet.FromSql("ClassificationLevelEditGet @LanguageId, @OId", parameters).First();
            //PETER Consider to put this in a table
            List<SelectListItem> DateType = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "No date" },
                new SelectListItem { Value = "1", Text = "Date" },
                new SelectListItem { Value = "2", Text = "Date range" },
                new SelectListItem { Value = "3", Text = "Date time" },
                new SelectListItem { Value = "4", Text = "Date time range" }
            };

            var ExistingLevels = _context.ZDbTypeList.FromSql("ClassificationLevelEditGetExistingLevels @LanguageId, @Id", parameters).ToList();
            int MaxLevelSequence = 0;
            List<SelectListItem> ExistingLevelList = new List<SelectListItem>();
            foreach (var ExistingLevel in ExistingLevels)
            {
                ExistingLevelList.Add(new SelectListItem { Value = ExistingLevel.Id.ToString(), Text = ExistingLevel.Name });
                if (ExistingLevel.Id > MaxLevelSequence)
                { MaxLevelSequence = ExistingLevel.Id; }
            }
            MaxLevelSequence++;

            SuClassificationLevelEditGetWithListModel ClassificationLevelWithList = new SuClassificationLevelEditGetWithListModel
            {
                ClassificationLevel = ClassificationLevelEditGet,  DateTypeList = DateType, SequenceList = ExistingLevelList 
            };
            return View(ClassificationLevelWithList);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuClassificationLevelEditGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
                int DefaultLanguageID = CurrentUser.DefaultLanguageId;
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.ClassificationLevel.OId),
                    new SqlParameter("@LanguageId", DefaultLanguageID),
                    new SqlParameter("@Alphabetically", FromForm.ClassificationLevel.Alphabetically),
                    new SqlParameter("@CanLink", FromForm.ClassificationLevel.CanLink),
                    new SqlParameter("@InDropDown", FromForm.ClassificationLevel.InDropDown),
                    new SqlParameter("@InMenu", FromForm.ClassificationLevel.InMenu),
                    new SqlParameter("@OnTheFly", FromForm.ClassificationLevel.OnTheFly),
                    new SqlParameter("@Sequence", FromForm.ClassificationLevel.Sequence),
                    new SqlParameter("@DateLevel", FromForm.ClassificationLevel.DateLevel),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.ClassificationLevel.Name),
                    new SqlParameter("@Description", FromForm.ClassificationLevel.Description),
                    new SqlParameter("@MouseOver", FromForm.ClassificationLevel.MouseOver),
                    new SqlParameter("@MenuName", FromForm.ClassificationLevel.MenuName)
                    };
                _context.Database.ExecuteSqlCommand("ClassificationLevelEditPost " +
                            "@Id" +
                            ", @LanguageId" +
                            ", @Alphabetically" +
                            ", @CanLink" +
                            ", @InDropDown" +
                            ", @InMenu" +
                            ", @OnTheFly" +
                            ", @Sequence" +
                            ", @DateLevel" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName", parameters);
            }
            return RedirectToAction("Index", new { Id =FromForm.ClassificationLevel.PId});
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", DefaultLanguageID),
                    new SqlParameter("@PId", Id),
                    };

            var ExistingLevels = _context.ZDbTypeList.FromSql("ClassificationLevelCreateGetExistingLevels @LanguageId, @PId", parameters).ToList();
            int MaxLevelSequence = 0;
            List<SelectListItem> ExistingLevelList = new List<SelectListItem>();
            foreach (var ExistingLevel in ExistingLevels)
            {
                ExistingLevelList.Add(new SelectListItem { Value = ExistingLevel.Id.ToString(), Text = ExistingLevel.Name });
                if (ExistingLevel.Id > MaxLevelSequence)
                { MaxLevelSequence = ExistingLevel.Id; }
            }
            MaxLevelSequence++;
            

            ExistingLevelList.Add(new SelectListItem { Text = "add at bottom", Value = MaxLevelSequence.ToString() });

            List<SelectListItem> DateType = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "No date" },
                new SelectListItem { Value = "1", Text = "Date" },
                new SelectListItem { Value = "2", Text = "Date range" },
                new SelectListItem { Value = "3", Text = "Date time" },
                new SelectListItem { Value = "4", Text = "Date time range" }
            };


            SuClassificationLevelEditGetModel ClassificationLevel = new SuClassificationLevelEditGetModel
            {
                PId = Id
            };
            SuClassificationLevelEditGetWithListModel ClassificationAndDateAndSequenceList = new SuClassificationLevelEditGetWithListModel { ClassificationLevel = ClassificationLevel, DateTypeList = DateType , SequenceList = ExistingLevelList };
            return View(ClassificationAndDateAndSequenceList);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuClassificationLevelEditGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;

                SqlParameter[] parameters =
                    {
                    new SqlParameter("@PId", FromForm.ClassificationLevel.PId)
                    , new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@Sequence", FromForm.ClassificationLevel.Sequence)
                    , new SqlParameter("@DateLevel", FromForm.ClassificationLevel.DateLevel)
                    , new SqlParameter("@OnTheFly", FromForm.ClassificationLevel.OnTheFly)
                    , new SqlParameter("@Alphabetically", FromForm.ClassificationLevel.Alphabetically)
                    , new SqlParameter("@CanLink", FromForm.ClassificationLevel.CanLink)
                    , new SqlParameter("@InDropDown", FromForm.ClassificationLevel.InDropDown)
                    , new SqlParameter("@InMenu", FromForm.ClassificationLevel.InMenu)
                    , new SqlParameter("@ModifierId", CurrentUser.Id)
                    , new SqlParameter("@Name", FromForm.ClassificationLevel.Name)
                    , new SqlParameter("@Description", FromForm.ClassificationLevel.Description)
                    , new SqlParameter("@MouseOver", FromForm.ClassificationLevel.MouseOver)
                    , new SqlParameter("@MenuName", FromForm.ClassificationLevel.MenuName)
                    };

                 _context.Database.ExecuteSqlCommand("ClassificationLevelCreatePost " +
                            "@PId" +
                            ", @LanguageId" +
                            ", @Sequence" +
                            ", @DateLevel" +
                            ", @OnTheFly" +
                            ", @Alphabetically" +
                            ", @CanLink" +
                            ", @InDropDown" +
                            ", @InMenu" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName", parameters);
            }
            return RedirectToAction("Index", new { Id = FromForm.ClassificationLevel.PId.ToString() });
        }
        
        public async Task<IActionResult> LanguageIndex(int Id)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter parameter = new SqlParameter("@OId", Id);

            List<SuObjectLanguageIndexGetModel> LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ClassificationLevelLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);
        }

        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter parameter = new SqlParameter("@LId", Id);

            SuObjectLanguageEditGetModel ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ClassificationLevelLanguageEditGet @LId", parameter).First();
            return View(ObjectLanguage);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageEdit(SuObjectLanguageEditGetModel FromForm)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
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

                 _context.Database.ExecuteSqlCommand("ClassificationLevelLanguageEditPost " +
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
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;
            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            AvailableObjectLanguages AvailableLanguages = new AvailableObjectLanguages(_context);
            var SuLanguage = AvailableLanguages.ReturnFreeLanguages(this.ControllerContext.RouteData.Values["controller"].ToString(), Id);
            Int32 NoOfLanguages = SuLanguage.Count();
            if (NoOfLanguages == 0)
                { return RedirectToAction("LanguageIndex", new { Id }); }
            SuObjectLanguageCreateGetModel SuObject = new SuObjectLanguageCreateGetModel
            {
                OId = Id
            };
            ViewBag.Id = Id.ToString();
            SuObjectLanguageCreateGetWithListModel ClassificationLevelAndLanguages = new SuObjectLanguageCreateGetWithListModel
            {
                ObjectLanguage = SuObject
                ,
                 LanguageList = SuLanguage
            };
            return View(ClassificationLevelAndLanguages);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageCreate(SuObjectLanguageCreateGetWithListModel FromForm)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);


                SqlParameter[] parameters =
                    {
                    new SqlParameter("@OId", FromForm.ObjectLanguage.OId),
                    new SqlParameter("@LanguageId", FromForm.ObjectLanguage.LanguageId),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.ObjectLanguage.Name ?? ""),
                    new SqlParameter("@Description", FromForm.ObjectLanguage.Description ?? ""),
                    new SqlParameter("@MouseOver", FromForm.ObjectLanguage.MouseOver ?? ""),
                    new SqlParameter("@MenuName", FromForm.ObjectLanguage.MenuName ?? "")
                    };

                 _context.Database.ExecuteSqlCommand("ClassificationLevelLanguageCreatePost " +
                            "@OId" +
                            ", @LanguageId" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName", parameters);
            return RedirectToAction("LanguageIndex", new { Id = FromForm.ObjectLanguage.OId.ToString() });
        }

        [HttpGet]
        public async Task<IActionResult> LanguageDelete(int Id)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter parameter = new SqlParameter("@LId", Id);
            SuObjectLanguageEditGetModel ClassificationLevelLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ClassificationLevelLanguageEditGet @LId", parameter).First();

            return View(ClassificationLevelLanguage);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectLanguageEditGetModel FromForm)
        {
                _classificationLevelLanguage.DeleteClassificationLevelLanguage(FromForm.LId);
                return RedirectToAction("LanguageIndex", new { Id = FromForm.OId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@OId", Id)
                    , new SqlParameter("@LanguageId", DefaultLanguageID)
                };

            SuClassificationLevelDeleteGetModel ClassificationLevel = _context.ZdbClassificationLevelDeleteGet.FromSql("ClassificationLevelDeleteGet @OId, @LanguageId", parameters).First();

            return View(ClassificationLevel);
        }

        [HttpPost]
        public IActionResult Delete(SuClassificationLevelDeleteGetModel FromForm)
        {

            var parameter = new SqlParameter("@OId", FromForm.OId);
             _context.Database.ExecuteSqlCommand("ClassificationLevelDeletePost @OId", parameter);

            return RedirectToAction("Index", new { Id = FromForm.PId });
        }

    }

}
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
    public class ClassificationLevelController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly IClassificationLevelRepository _classificationLevel;
        private readonly IClassificationLevelLanguageRepository _classificationLevelLanguage;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public ClassificationLevelController(UserManager<SuUserModel> userManager
            , IClassificationLanguageRepository classificationLanguage
            , IClassificationLevelRepository classificationLevel
            , IClassificationLevelLanguageRepository classificationLevelLanguage
            , ILanguageRepository language
            , SuDbContext context
            )
        {
            this.userManager = userManager;
            _classificationLanguage = classificationLanguage;
            _classificationLevel = classificationLevel;
            _classificationLevelLanguage = classificationLevelLanguage;
            _language = language;
            _context = context;
        }

        public async Task<IActionResult> Index(int Id)
        {
            SuUserModel CurrentUser = await userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@Id", Id)
                };
            List<SuClassificationLevelIndexGetModel> ClassificationLevel = _context.ZdbClassificationLevelIndexGet.FromSql($"ClassificationLevelIndexGet @Id, @LanguageId", parameters).ToList();
            ViewBag.PId = Id;
            return View(ClassificationLevel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            SuUserModel CurrentUser = await userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;
        
            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
    {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@Id", Id)
                };

           SuClassificationLevelEditGetModel ClassificationEditGet = _context.ZdbClassificationLevelEditGet.FromSql("ClassificationLevelEditGet @LanguageId, @Id", parameters).First();
            //PETER Consider to put this in a table
            List<SelectListItem> DateType = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "No date" },
                new SelectListItem { Value = "1", Text = "Date" },
                new SelectListItem { Value = "2", Text = "Date range" },
                new SelectListItem { Value = "3", Text = "Date time" },
                new SelectListItem { Value = "4", Text = "Date time range" }
            };

            var ExistingLevels = _context.DbTypeList.FromSql("ClassificationLevelEditGetExistingLevels @LanguageId, @Id", parameters).ToList();
            int MaxLevelSequence = 0;
            List<SelectListItem> ExistingLevelList = new List<SelectListItem>();
            foreach (var ExistingLevel in ExistingLevels)
            {
                ExistingLevelList.Add(new SelectListItem { Value = ExistingLevel.Id.ToString(), Text = ExistingLevel.Name });
                if (ExistingLevel.Id > MaxLevelSequence)
                { MaxLevelSequence = ExistingLevel.Id; }
            }
            MaxLevelSequence++;
//            ExistingLevelList.Add(new SelectListItem { Text = "add at bottom", Value = MaxLevelSequence.ToString() });

            SuClassificationLevelEditGetWithListModel ClassificationLevelWithList = new SuClassificationLevelEditGetWithListModel
            {
                ClassificationLevel = ClassificationEditGet,  DateTypeList = DateType, SequenceList = ExistingLevelList //, a = ClassificationList 
            };
            return View(ClassificationLevelWithList);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuClassificationLevelEditGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                SuUserModel CurrentUser = await userManager.GetUserAsync(User);
                int DefaultLanguageID = CurrentUser.DefaultLanguageId;
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.ClassificationLevel.OId),
                    new SqlParameter("@LanguageId", DefaultLanguageID),
                    new SqlParameter("@Alphabetically", FromForm.ClassificationLevel.Alphabetically),
                    new SqlParameter("@CanLink", FromForm.ClassificationLevel.CanLink),
                    new SqlParameter("@InDropDown", FromForm.ClassificationLevel.InDropDown),
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
            SuUserModel CurrentUser = await userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", DefaultLanguageID),
                    new SqlParameter("@PId", Id),
                    };

            var ExistingLevels = _context.DbTypeList.FromSql("ClassificationLevelCreateGetExistingLevels @LanguageId, @PId", parameters).ToList();
            int MaxLevelSequence = 0;
            List<SelectListItem> ExistingLevelList = new List<SelectListItem>();
            foreach (var ExistingLevel in ExistingLevels)
            {
                ExistingLevelList.Add(new SelectListItem { Value = ExistingLevel.Id.ToString(), Text = ExistingLevel.Name });
                if (ExistingLevel.Id > MaxLevelSequence)
                { MaxLevelSequence = ExistingLevel.Id; }
            }
            MaxLevelSequence++;
            //List<SelectListItem> ExistingLevels = (from c in _classificationLevel.GetAllClassificationLevels()
            //                                       join l in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
            //                                       on c.Id equals l.ClassificationLevelId
            //                                       where c.ClassificationId == Id
            //                                       && l.LanguageId == DefaultLanguageID
            //                                       orderby c.Sequence
            //                                       select new SelectListItem
            //                                       {
            //                                           Value = c.Sequence.ToString()
            //                                       ,
            //                                           Text = l.Name
            //                                       }).ToList();
            //List<int> TestForNull = (from c in _classificationLevel.GetAllClassificationLevels()
            //                   join l in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
            //                   on c.Id equals l.ClassificationLevelId
            //                   where c.Id == Id
            //                   && l.LanguageId == DefaultLanguageID
            //                   select c.Sequence).ToList();

            //if (TestForNull.Count() == 0)
            //{ MaxLevelSequence = 1; }
            //else
            //{
            //    MaxLevelSequence = (from c in _classificationLevel.GetAllClassificationLevels()
            //                        join l in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
            //                        on c.Id equals l.ClassificationLevelId
            //                        where c.Id == Id
            //                        && l.LanguageId == DefaultLanguageID
            //                        select c.Sequence).Max();

            //    MaxLevelSequence++;
            //}

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
                var CurrentUser = await userManager.GetUserAsync(User);
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
            SuUserModel CurrentUser = await userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter parameter = new SqlParameter("@Id", Id);

            List<SuObjectLanguageIndexGetModel> LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql($"ClassificationLevelLanguageIndexGet @Id", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);
        }

        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {
            SuUserModel CurrentUser = await userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter parameter = new SqlParameter("@Id", Id);

            SuObjectLanguageEditGetModel ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql($"ClassificationLevelLanguageEditGet @Id", parameter).First();
            return View(ObjectLanguage);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageEdit(SuObjectLanguageEditGetModel FromForm)
        {
            SuUserModel CurrentUser = await userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            if (ModelState.IsValid)
            {
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.LId),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.Name),
                    new SqlParameter("@Description", FromForm.Description),
                    new SqlParameter("@MouseOver", FromForm.MouseOver),
                    new SqlParameter("@MenuName", FromForm.MenuName)
                    };

                 _context.Database.ExecuteSqlCommand("ClassificationLevelLanguageEditPost " +
                            "@Id" +
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
            SuUserModel CurrentUser = await userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;
            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            AvailableObjectLanguages AvailableLanguages = new AvailableObjectLanguages(_context);
            var SuLanguage = AvailableLanguages.ReturnFreeLanguages(this.ControllerContext.RouteData.Values["controller"].ToString(), Id);
            Int32 NoOfLanguages = SuLanguage.Count();
            if (NoOfLanguages == 0)
                { return RedirectToAction("LanguageIndex", new { Id }); }
            //List<int> LanguagesAlready = new List<int>();
            //LanguagesAlready = (from c in _classificationLevelLanguage.GetAllClassificationLevelLanguages()
            //                    where c.ClassificationLevelId == Id
            //                    select c.LanguageId).ToList();


            //List< SelectListItem> SuLanguage = (from l in _language.GetAllLanguages()
            //                  where !LanguagesAlready.Contains(l.Id)
            //                  && l.Active == true
            //                  select new SelectListItem
            //                  {
            //                      Value = l.Id.ToString()
            //                  ,
            //                      Text = l.LanguageName
            //                  }).ToList();

            //if (SuLanguage.Count() == 0)
            //{
            //    return RedirectToAction("LanguageIndex", new { Id = Id });
            //}
            SuObjectLanguageCreateGetModel SuObject = new SuObjectLanguageCreateGetModel
            {
                OId = Id
            };
            ViewBag.Id = Id.ToString();
            SuObjectLanguageCreateGetWithListModel ClassificationAndStatus = new SuObjectLanguageCreateGetWithListModel
            {
                ObjectLanguage = SuObject
                ,
                 LanguageList = SuLanguage
            };
            return View(ClassificationAndStatus);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageCreate(SuObjectLanguageCreateGetWithListModel FromForm)
        {
            SuUserModel CurrentUser = await userManager.GetUserAsync(User);


                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.ObjectLanguage.OId),
                    new SqlParameter("@LanguageId", FromForm.ObjectLanguage.LanguageId),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.ObjectLanguage.Name ?? ""),
                    new SqlParameter("@Description", FromForm.ObjectLanguage.Description ?? ""),
                    new SqlParameter("@MouseOver", FromForm.ObjectLanguage.MouseOver ?? ""),
                    new SqlParameter("@MenuName", FromForm.ObjectLanguage.MenuName ?? "")
                    };

                 _context.Database.ExecuteSqlCommand("ClassificationLevelLanguageCreatePost " +
                            "@Id" +
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
            SuUserModel CurrentUser = await userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter parameter = new SqlParameter("@Id", Id);
            SuObjectLanguageEditGetModel ClassificationLevelLanguage = _context.ZdbObjectLanguageEditGet.FromSql($"ClassificationLevelLanguageEditGet @Id", parameter).First();

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
            SuUserModel CurrentUser = await userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@Id", Id)
                    , new SqlParameter("@LanguageId", DefaultLanguageID)
                };

            SuClassificationLevelDeleteGetModel Classification = _context.ZdbClassificationLevelDeleteGet.FromSql($"ClassificationLevelDeleteGet @Id, @LanguageId", parameters).First();

            return View(Classification);
        }

        [HttpPost]
        public IActionResult Delete(SuClassificationLevelDeleteGetModel FromForm)
        {

            var parameter = new SqlParameter("@LanguageId", FromForm.OId);
             _context.Database.ExecuteSqlCommand($"ClassificationDeletePost @Id", parameter);

            return RedirectToAction("Index", new { Id = FromForm.PId });
        }

    }

}
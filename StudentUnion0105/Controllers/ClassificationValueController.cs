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
    public class ClassificationValueController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IClassificationValueRepository _classificationValue;
        private readonly IClassificationValueLanguageRepository _classificationValueLanguage;
        private readonly SuDbContext _context;
        private readonly IClassificationLevelRepository _classificationLevel;
        private readonly ILanguageRepository _language;

        public ClassificationValueController(UserManager<SuUserModel> userManager
            , IClassificationValueRepository classificationValue
            , IClassificationValueLanguageRepository classificationValueLanguage
           , SuDbContext context
            , IClassificationLevelRepository classificationLevel
            , ILanguageRepository language)
        {
            this.userManager = userManager;
            _classificationValue = classificationValue;
            _classificationValueLanguage = classificationValueLanguage;
            _context = context;
            _classificationLevel = classificationLevel;
            _language = language;
        }

        public async Task<IActionResult> Index(int Id)
        {

            SuUserModel CurrentUser = await userManager.GetUserAsync(User);
            int DefaultLanguageID = CurrentUser.DefaultLanguageId;

            UICustomization UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SuInt MaxLevel = new SuInt
            {
                intValue = 0
            };

            try
            {
                MaxLevel = _context.ZdbInt.FromSql($"ClassificationValueIndexGetMaxLevel {Id}").First();
            }
            catch { }

            SuInt CurrentLevel = new SuInt
            {
                intValue = 0
            };
            try
            {
                CurrentLevel = _context.ZdbInt.FromSql($"ClassificationValueIndexGetCurrentLevel {Id}").First();//? null : new SuInt { intValue = 0 };
            }
            catch { }

            var ValueStructure = _context.ZdbClassificationValueIndexGet.FromSql($"ClassificationValueIndexGet {DefaultLanguageID}, {Id}").ToList();
            ViewBag.CId = Id.ToString();
            var c = new ValueStructureWithDepth { MaxLevel = MaxLevel.intValue, ValueStructure = ValueStructure, MaxConfigLevel = CurrentLevel.intValue };
            return View(c);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SuClassificationValueEditGetModel NewValue = new SuClassificationValueEditGetModel
            {
                //ClassificationId
                PId = Convert.ToInt32(HttpContext.Request.Query["CId"]),
                //ParentValueId
                ParentId = Id
            };

            SqlParameter parameter = new SqlParameter("@Id", Id);
            SuClassificationValueEditGetLevelModel ClassificationValueEditGetLevel = _context.ZdbClassificationValueEditGetLevel.FromSql("ClassificationValueEditGetLevel @Id", parameter).First();


            SuObjectVM CValue = new SuObjectVM()
            {
                NullId = Id,
                ObjectId = Convert.ToInt32(HttpContext.Request.Query["CId"]),
            };
            if (Id == 0)
            {
                CValue.Level = 1;
            }
            else
            {
                var x = new SuClassificationValueModel();
                int? Parent = Id;
                while (Parent != null)
                {
                    CValue.Level++;

                    x = _classificationValue.GetClassificationValue(Parent ?? 0);
                    Parent = x.ParentValueId;

                }
            }

            var ToForm = (from s in _classificationLevel.GetAllClassificationLevels()
                         where s.ClassificationId == Convert.ToInt32(HttpContext.Request.Query["CId"]) && s.Sequence == CValue.Level
                         select new SuObjectVM
                         {
                             DateLevel = s.DateLevel
                            ,
                             Alphabetically = s.Alphabetically
                            ,
                             InDropDown = s.InDropDown

                         }).First();
            CValue.DateLevel = ToForm.DateLevel;
            CValue.Alphabetically = ToForm.Alphabetically;
            CValue.InDropDown = ToForm.InDropDown;

            //            var x = _classificationLevel.get.ClassificationLevel()
            ViewBag.CId = HttpContext.Request.Query["CId"];
            return View(CValue);


        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var ClassificationValue = new SuClassificationValueModel
                {
                    ModifiedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    ClassificationId = FromForm.ObjectId
                };

                if (FromForm.NullId != 0)
                { ClassificationValue.ParentValueId = FromForm.NullId; }
                var NewClassificationValue = _classificationValue.AddClassificationValue(ClassificationValue);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var ClassificationValueLanguage = new SuClassificationValueLanguageModel
                {
                    Name = FromForm.Name,
                    Description = FromForm.Description,
                    DropDownName = FromForm.DropDownName,
                    MenuName = FromForm.MenuName,
                    MouseOver = FromForm.MouseOver,
                    PageName = FromForm.Title,
                    PageDescription = FromForm.PageDescription,
                    HeaderName = FromForm.HeaderName,
                    HeaderDescription = FromForm.HeaderDescription,
                    TopicName = FromForm.TopicName,

                    ClassificationValueId = NewClassificationValue.Id,
                    LanguageId = DefaultLanguageID
                };
                _classificationValueLanguage.AddClassificationValueLanguage(ClassificationValueLanguage);

            }
            return RedirectToAction("Index", new { Id = FromForm.ObjectId.ToString() });



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
            SqlParameter parameter = new SqlParameter("@Id", Id);
            SuClassificationValueEditGetModel ClassificationValueEditGet = _context.ZdbClassificationValueEditGet.FromSql("ClassificationValueEditGet @LanguageId, @Id", parameters).First();
            SuClassificationValueEditGetLevelModel ClassificationValueEditGetLevel = _context.ZdbClassificationValueEditGetLevel.FromSql("ClassificationValueEditGetLevel @Id", parameter).First();
            ClassificationValueEditGet.DateLevel = ClassificationValueEditGetLevel.DateLevel;
            ClassificationValueEditGet.InDropDown = ClassificationValueEditGetLevel.InDropDown;

            return View(ClassificationValueEditGet);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuClassificationValueEditGetModel FromForm)
        {
            if (ModelState.IsValid)
            {
                SuUserModel CurrentUser = await userManager.GetUserAsync(User);
                int DefaultLanguageID = CurrentUser.DefaultLanguageId;
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@OId", FromForm.OId),
                    new SqlParameter("@LanguageId", DefaultLanguageID),
                    new SqlParameter("@FromDate", FromForm.FromDate),
                    new SqlParameter("@ToDate", FromForm.ToDate),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.Name),
                    new SqlParameter("@Description", FromForm.Description),
                    new SqlParameter("@MouseOver", FromForm.MouseOver),
                    new SqlParameter("@MenuName", FromForm.MenuName),
                    new SqlParameter("@DropDownName", FromForm.MenuName),
                    new SqlParameter("@PageName", FromForm.MenuName),
                    new SqlParameter("@PageDescription", FromForm.MenuName),
                    new SqlParameter("@HeaderName", FromForm.MenuName),
                    new SqlParameter("@HeaderDescription", FromForm.MenuName),
                    new SqlParameter("@TopicName", FromForm.MenuName)

                    };
                 _context.Database.ExecuteSqlCommand("ClassificationValueEditPost " +
                            "@OId" +
                            ", @LanguageId" +
                            ", @FromDate" +
                            ", @ToDate" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName" +
                            ", @DropDownName" +
                            ", @PageName" +
                            ", @PageDescription" +
                            ", @HeaderName" +
                            ", @HeaderDescription" +
                            ", @TopicName", parameters);
            }
            return RedirectToAction("Index", new { Id = FromForm.PId });
        }

        public async  Task<IActionResult> LanguageIndex(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            //var ClassificationLanguage = (from c in _classificationValueLanguage.GetAllClassificationValueLanguages()
            //                              join l in _language.GetAllLanguages()
            //             on c.LanguageId equals l.Id
            //                              where c.ClassificationValueId == Id
            //                              select new SuObjectVM
            //                              {
            //                                  Id = c.Id
            //                              ,
            //                                  Name = c.Name
            //                              ,
            //                                  Language = l.LanguageName
            //                              }).ToList();
            //ViewBag.Id = Id;
            //ViewBag.CId = HttpContext.Request.Query["CId"];

            //return View(ClassificationLanguage);
            SqlParameter parameter = new SqlParameter("@OId", Id);
            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ClassificationValueLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

        }

        [HttpGet]
        public async  Task<IActionResult> LanguageCreate(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _classificationValueLanguage.GetAllClassificationValueLanguages()
                                where c.ClassificationValueId == Id
                                select c.LanguageId).ToList();


            var SuLanguage = (from l in _language.GetAllLanguages()
                              where !LanguagesAlready.Contains(l.Id)
                              && l.Active == true
                              select new SelectListItem
                              {
                                  Value = l.Id.ToString()
                              ,
                                  Text = l.LanguageName
                              }).ToList();

            if (SuLanguage.Count() == 0)
            {
                return RedirectToAction("LanguageIndex", new { Id });
            }
            SuObjectVM SuObject = new SuObjectVM
            {
                ObjectId = Id
            };
            //------
            var xyz = _classificationValue.GetClassificationValue(Id);
            // ClassificationValue.NullId = xyz.ParentValueId;
            int Level = 1;
            var x = new SuClassificationValueModel();
            int? Parent = xyz.ParentValueId;
            while (Parent != null)
            {
                Level++;

                x = _classificationValue.GetClassificationValue(Parent ?? 0);
                Parent = x.ParentValueId;

            }
            //          var ClassificationList = new List<SelectListItem>();
            //string a;
            //a = ToForm.Description;

            //ClassificationValue.Level = Level;
            var ToForm = (from s in _classificationLevel.GetAllClassificationLevels()
                         where s.ClassificationId == Convert.ToInt32(HttpContext.Request.Query["CId"]) && s.Sequence == Level
                         select new SuObjectVM
                         {
                             DateLevel = s.DateLevel
                            ,
                             Alphabetically = s.Alphabetically
                            ,
                             InDropDown = s.InDropDown

                         }).First();
            //------
            ViewBag.Id = Id.ToString();
            var ClassificationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage

            };

            ViewBag.ShowInDropDown = ToForm.InDropDown;
            return View(ClassificationAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var ClassificationValueLanguage = new SuClassificationValueLanguageModel
                {
                    Name = FromForm.SuObject.Name,
                    Description = FromForm.SuObject.Description,
                    DropDownName = FromForm.SuObject.DropDownName,
                    MenuName = FromForm.SuObject.MenuName,
                    MouseOver = FromForm.SuObject.MouseOver
                };
                ClassificationValueLanguage.MouseOver = FromForm.SuObject.MouseOver;
                ClassificationValueLanguage.PageDescription = FromForm.SuObject.PageDescription;
                ClassificationValueLanguage.HeaderName = FromForm.SuObject.HeaderName;
                ClassificationValueLanguage.HeaderDescription = FromForm.SuObject.HeaderDescription;
                ClassificationValueLanguage.TopicName = FromForm.SuObject.TopicName;

                ClassificationValueLanguage.ClassificationValueId = FromForm.SuObject.ObjectId;
                ClassificationValueLanguage.LanguageId = FromForm.SuObject.LanguageId;


               _classificationValueLanguage.AddClassificationValueLanguage(ClassificationValueLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });
        }

        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql($"ClassificationValueLanguageEditGet {Id}").First();
            return View(ObjectLanguage);

        }
        }
    }
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
    public class ClassificationValueController : PortalController
    {
        private readonly IClassificationValueRepository _classificationValue;
        private readonly IClassificationValueLanguageRepository _classificationValueLanguage;
        private readonly IClassificationLevelRepository _classificationLevel;
                private readonly SuDbContext _context;

        public ClassificationValueController(UserManager<SuUserModel> userManager
            , IClassificationValueRepository classificationValue
            , IClassificationValueLanguageRepository classificationValueLanguage
           , SuDbContext context
            , IClassificationLevelRepository classificationLevel
            , ILanguageRepository language) : base(userManager, language)
        {
            _classificationValue = classificationValue;
            _classificationValueLanguage = classificationValueLanguage;
            _classificationLevel = classificationLevel;
                    _context = context;
}

        public async Task<IActionResult> Index(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);
            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);



            SuInt MaxLevel = new SuInt
            {
                intValue = 0
            };

            var parameter = new SqlParameter("@Id", Id);

            try
            {

                MaxLevel = _context.ZdbInt.FromSql("ClassificationValueIndexGetMaxLevel @Id", parameter).First();
            }
            catch { }

            SuInt CurrentLevel = new SuInt
            {
                intValue = 0
            };
            try
            {
                CurrentLevel = _context.ZdbInt.FromSql("ClassificationValueIndexGetCurrentLevel @Id", parameter).First();//? null : new SuInt { intValue = 0 };
            }
            catch { }

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@Id", Id)
                };

            var ValueStructure = _context.ZdbClassificationValueIndexGet.FromSql("ClassificationValueIndexGet @LanguageId, @Id", parameters).ToList();
            ViewBag.CId = Id.ToString();
            new ValueStructureWithDepth { MaxLevel = MaxLevel.intValue, ValueStructure = ValueStructure, MaxConfigLevel = CurrentLevel.intValue };
            var c = new ValueStructureWithDepth { MaxLevel = MaxLevel.intValue, ValueStructure = ValueStructure, MaxConfigLevel = CurrentLevel.intValue };
            return View(c);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);
            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


            SuClassificationValueEditGetModel NewValue = new SuClassificationValueEditGetModel
            {
                //ClassificationId
                PId = Convert.ToInt32(HttpContext.Request.Query["CId"]),
                //ParentValueId
                ParentId = Id
            };
            SqlParameter[] parameters =
{
                    new SqlParameter("@ParentId", NewValue.ParentId)
                    , new SqlParameter("@PId", NewValue.PId)
                };

            SuClassificationValueEditGetLevelModel ClassificationValueEditGetLevel = _context.ZdbClassificationValueEditGetLevel.FromSql("ClassificationValueCreateGetLevel @ParentId, @PId", parameters).First();

            NewValue.InDropDown = ClassificationValueEditGetLevel.InDropDown;
            NewValue.DateLevel = ClassificationValueEditGetLevel.DateLevel;


            return View(NewValue);

        }

        [HttpPost]
        public async Task<IActionResult> Create(SuClassificationValueEditGetModel FromForm)
        {
            

                var CurrentUser = await _userManager.GetUserAsync(User);
    


                SqlParameter[] parameters =
                    {
//                    new SqlParameter("@Id", FromForm.Classification.Id),
                    new SqlParameter("@PId", FromForm.PId),
                    new SqlParameter("@ParentId", FromForm.ParentId),
                    new SqlParameter("@FromDate", FromForm.FromDate),
                    new SqlParameter("@ToDate", FromForm.ToDate ),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId),
                    new SqlParameter("@Name", FromForm.Name ?? ""),
                    new SqlParameter("@Description", FromForm.Description ?? ""),
                    new SqlParameter("@MouseOver", FromForm.MouseOver ?? ""),
                    new SqlParameter("@MenuName", FromForm.MenuName ?? ""), 
                    new SqlParameter("@DropDownName", FromForm.DropDownName ?? ""),
                    new SqlParameter("@PageName", FromForm.PageName ?? ""),
                    new SqlParameter("@PageDescription", FromForm.PageDescription ?? ""),
                    new SqlParameter("@HeaderName", FromForm.HeaderName ?? ""),
                    new SqlParameter("@HeaderDescription", FromForm.HeaderDescription ?? ""),
                    new SqlParameter("@TopicName", FromForm.TopicName ?? "")
                    };

               _context.Database.ExecuteSqlCommand("ClassificationValueCreatePost " +
                            "@PId" +
                            ", @ParentId" +
                            ", @FromDate" +
                            ", @ToDate" +
                            ", @ModifierId" +
                            ", @LanguageId" +
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
            
        
            return RedirectToAction("Index", new { Id = FromForm.PId.ToString() });



        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
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
          
                SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@OId", FromForm.OId),
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId),
                    new SqlParameter("@FromDate", FromForm.FromDate),
                    new SqlParameter("@ToDate", FromForm.ToDate),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.Name ?? ""),
                    new SqlParameter("@Description", FromForm.Description ?? ""),
                    new SqlParameter("@MouseOver", FromForm.MouseOver ?? ""),
                    new SqlParameter("@MenuName", FromForm.MenuName ?? ""),
                    new SqlParameter("@DropDownName", FromForm.MenuName ?? ""),
                    new SqlParameter("@PageName", FromForm.MenuName ?? ""),
                    new SqlParameter("@PageDescription", FromForm.MenuName ?? ""),
                    new SqlParameter("@HeaderName", FromForm.MenuName ?? ""),
                    new SqlParameter("@HeaderDescription", FromForm.MenuName ?? ""),
                    new SqlParameter("@TopicName", FromForm.MenuName ?? "")

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
      
            return RedirectToAction("Index", new { Id = FromForm.PId });
        }

        public async Task<IActionResult> LanguageIndex(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);
            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


            SqlParameter parameter = new SqlParameter("@OId", Id);
            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ClassificationValueLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

        }

        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);
            
            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@Id", Id);

            var LanguageList = _context.ZdbLanguageCreateGetLanguageList.FromSql("ClassificationValueLanguageCreateGetLanguageList @Id", parameter).ToList();

            List<SelectListItem> LList = new List<SelectListItem>();
            foreach (var Language in LanguageList)
            {
                LList.Add(new SelectListItem { Value = Language.Value, Text = Language.Text });
            }

            if (LList.Count() == 0)
            {
                return RedirectToAction("LanguageIndex", new { Id });
            }
            SuObjectLanguageEditGetModel ClassificationValue = new SuObjectLanguageEditGetModel
            {
                OId = Id
            };
            ViewBag.Id = Id.ToString();
            var ClassificationValueAndStatus = new SuObjectLanguageEditGetWitLanguageListModel
            {
                 SuObject = ClassificationValue
                ,
                LanguageList = LList
            };
            return View(ClassificationValueAndStatus);



            //List<int> LanguagesAlready = new List<int>();
            //LanguagesAlready = (from c in _classificationValueLanguage.GetAllClassificationValueLanguages()
            //                    where c.ClassificationValueId == Id
            //                    select c.LanguageId).ToList();


            //var SuLanguage = (from l in _language.GetAllLanguages()
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
            //    return RedirectToAction("LanguageIndex", new { Id });
            //}
            //SuObjectVM SuObject = new SuObjectVM
            //{
            //    ObjectId = Id
            //};
            ////------
            //var xyz = _classificationValue.GetClassificationValue(Id);
            //// ClassificationValue.NullId = xyz.ParentValueId;
            //int Level = 1;
            //var x = new SuClassificationValueModel();
            //int? Parent = xyz.ParentValueId;
            //while (Parent != null)
            //{
            //    Level++;

            //    x = _classificationValue.GetClassificationValue(Parent ?? 0);
            //    Parent = x.ParentValueId;

            //}
            ////          var ClassificationList = new List<SelectListItem>();
            ////string a;
            ////a = ToForm.Description;

            ////ClassificationValue.Level = Level;
            //var ToForm = (from s in _classificationLevel.GetAllClassificationLevels()
            //             where s.ClassificationId == Convert.ToInt32(HttpContext.Request.Query["CId"]) && s.Sequence == Level
            //             select new SuObjectVM
            //             {
            //                 DateLevel = s.DateLevel
            //                ,
            //                 Alphabetically = s.Alphabetically
            //                ,
            //                 InDropDown = s.InDropDown

            //             }).First();
            ////------
            //ViewBag.Id = Id.ToString();
            //var ClassificationAndStatus = new SuObjectAndStatusViewModel
            //{
            //    SuObject = SuObject
            //    ,
            //    SomeKindINumSelectListItem = SuLanguage

            //};

            //ViewBag.ShowInDropDown = ToForm.InDropDown;
            //return View(ClassificationAndStatus);
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


            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);
            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


            var parameter = new SqlParameter("@Id", Id);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ClassificationValueLanguageEditGet @Id", parameter).First();
            return View(ObjectLanguage);

        }
        }
    }
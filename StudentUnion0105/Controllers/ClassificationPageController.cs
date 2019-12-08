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
    public class ClassificationPageController : Controller
    {
        private readonly UserManager<SuUserModel> _userManager;
        private readonly SuDbContext _context;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        //private readonly IClassificationPageRepository _classificationPage;
        //private readonly IClassificationPageLanguageRepository _classificationPageLanguage;
        private readonly ILanguageRepository _language;
        
        public ClassificationPageController(UserManager<SuUserModel> userManager
            , IClassificationLanguageRepository classificationLanguage
            //, IClassificationPageRepository classificationPage
            //, IClassificationPageLanguageRepository classificationPageLanguage
            , ILanguageRepository language
            , SuDbContext context
            )
        {
            _userManager = userManager;
            _classificationLanguage = classificationLanguage;
            //_classificationPage = classificationPage;
            //_classificationPageLanguage = classificationPageLanguage;
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
            var ClassificationPage = _context.ZdbObjectIndexGet.FromSql("ClassificationPageIndexGet @Id, @LanguageId", parameters).ToList();
           //PETER Why do I need this viewbag
            ViewBag.PId = Id;
            return View(ClassificationPage);
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

            SuClassificationPageEditGetModel ClassificationPageEditGet = _context.ZdbClassificationPageEditGet.FromSql("ClassificationPageEditGet @LanguageId, @OId", parameters).First();

            var StatusList = new List<SelectListItem>();

            var ContentStatusFromDb = _context.ZDbStatusList.FromSql("PageStatusSelectAll").ToList();

            foreach (var StatusFromDb in ContentStatusFromDb)
            {
                StatusList.Add(new SelectListItem
                {
                    Text = StatusFromDb.Name,
                    Value = StatusFromDb.Id.ToString()
                });
            }

            SuClassificationPageEditGetWithListModel ClassificationPageWithList = new SuClassificationPageEditGetWithListModel
            {
                ClassificationPage = ClassificationPageEditGet
                , StatusList = StatusList
            };
            return View(ClassificationPageWithList);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuClassificationPageEditGetWithListModel FromForm)
        {
                SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
                int DefaultLanguageID = CurrentUser.DefaultLanguageId;
                SqlParameter[] parameters =
                    {
                        new SqlParameter("@OId", FromForm.ClassificationPage.OId),
                        new SqlParameter("@LanguageId", DefaultLanguageID),
                        new SqlParameter("@StatusId", FromForm.ClassificationPage.ClassificationPageStatusId),
                        new SqlParameter("@ShowClassificationTitleName", FromForm.ClassificationPage.ShowClassificationTitleName),
                        new SqlParameter("@ShowClassificationTitleDescription", FromForm.ClassificationPage.ShowClassificationTitleDescription),
                        new SqlParameter("@ModifierId", CurrentUser.Id),
                        new SqlParameter("@Name", FromForm.ClassificationPage.Name),
                        new SqlParameter("@Description", FromForm.ClassificationPage.Description),
                        new SqlParameter("@MouseOver", FromForm.ClassificationPage.MouseOver),
                        new SqlParameter("@MenuName", FromForm.ClassificationPage.MenuName),
                        new SqlParameter("@TitleName", FromForm.ClassificationPage.TitleName),
                        new SqlParameter("@TitleDescription", FromForm.ClassificationPage.TitleDescription)
                        };
                _context.Database.ExecuteSqlCommand("ClassificationPageEditPost " +
                            "@OId" +
                            ", @LanguageId" +
                            ", @StatusId" +
                            ", @ShowClassificationTitleName" +
                            ", @ShowClassificationTitleDescription" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName" +
                            ", @TitleName" +
                            ", @TitleDescription", parameters);
            return RedirectToAction("Index", new { Id = FromForm.ClassificationPage.PId });
        }

        //    [HttpGet]
        //    public async Task<IActionResult> Create(int Id)
        //    {
        //        SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
        //        int DefaultLanguageID = CurrentUser.DefaultLanguageId;

        //        UICustomization UICustomizationArray = new UICustomization(_context);
        //        ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

        //        SqlParameter[] parameters =
        //            {
        //                new SqlParameter("@LanguageId", DefaultLanguageID),
        //                new SqlParameter("@PId", Id),
        //                };

        //        var ExistingPages = _context.ZDbTypeList.FromSql("ClassificationPageCreateGetExistingPages @LanguageId, @PId", parameters).ToList();
        //        int MaxPageSequence = 0;
        //        List<SelectListItem> ExistingPageList = new List<SelectListItem>();
        //        foreach (var ExistingPage in ExistingPages)
        //        {
        //            ExistingPageList.Add(new SelectListItem { Value = ExistingPage.Id.ToString(), Text = ExistingPage.Name });
        //            if (ExistingPage.Id > MaxPageSequence)
        //            { MaxPageSequence = ExistingPage.Id; }
        //        }
        //        MaxPageSequence++;


        //        ExistingPageList.Add(new SelectListItem { Text = "add at bottom", Value = MaxPageSequence.ToString() });

        //        List<SelectListItem> DateType = new List<SelectListItem>
        //        {
        //            new SelectListItem { Value = "0", Text = "No date" },
        //            new SelectListItem { Value = "1", Text = "Date" },
        //            new SelectListItem { Value = "2", Text = "Date range" },
        //            new SelectListItem { Value = "3", Text = "Date time" },
        //            new SelectListItem { Value = "4", Text = "Date time range" }
        //        };


        //        SuClassificationPageEditGetModel ClassificationPage = new SuClassificationPageEditGetModel
        //        {
        //            PId = Id
        //        };
        //        SuClassificationPageEditGetWithListModel ClassificationAndDateAndSequenceList = new SuClassificationPageEditGetWithListModel { ClassificationPage = ClassificationPage, DateTypeList = DateType , SequenceList = ExistingPageList };
        //        return View(ClassificationAndDateAndSequenceList);
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> Create(SuClassificationPageEditGetWithListModel FromForm)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var CurrentUser = await _userManager.GetUserAsync(User);
        //            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

        //            SqlParameter[] parameters =
        //                {
        //                new SqlParameter("@PId", FromForm.ClassificationPage.PId)
        //                , new SqlParameter("@LanguageId", DefaultLanguageID)
        //                , new SqlParameter("@Sequence", FromForm.ClassificationPage.Sequence)
        //                , new SqlParameter("@DatePage", FromForm.ClassificationPage.DatePage)
        //                , new SqlParameter("@OnTheFly", FromForm.ClassificationPage.OnTheFly)
        //                , new SqlParameter("@Alphabetically", FromForm.ClassificationPage.Alphabetically)
        //                , new SqlParameter("@CanLink", FromForm.ClassificationPage.CanLink)
        //                , new SqlParameter("@InDropDown", FromForm.ClassificationPage.InDropDown)
        //                , new SqlParameter("@ModifierId", CurrentUser.Id)
        //                , new SqlParameter("@Name", FromForm.ClassificationPage.Name)
        //                , new SqlParameter("@Description", FromForm.ClassificationPage.Description)
        //                , new SqlParameter("@MouseOver", FromForm.ClassificationPage.MouseOver)
        //                , new SqlParameter("@MenuName", FromForm.ClassificationPage.MenuName)
        //                };

        //             _context.Database.ExecuteSqlCommand("ClassificationPageCreatePost " +
        //                        "@PId" +
        //                        ", @LanguageId" +
        //                        ", @Sequence" +
        //                        ", @DatePage" +
        //                        ", @OnTheFly" +
        //                        ", @Alphabetically" +
        //                        ", @CanLink" +
        //                        ", @InDropDown" +
        //                        ", @ModifierId" +
        //                        ", @Name" +
        //                        ", @Description" +
        //                        ", @MouseOver" +
        //                        ", @MenuName", parameters);
        //        }
        //        return RedirectToAction("Index", new { Id = FromForm.ClassificationPage.PId.ToString() });
        //    }

        //    public async Task<IActionResult> LanguageIndex(int Id)
        //    {
        //        SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
        //        int DefaultLanguageID = CurrentUser.DefaultLanguageId;

        //        UICustomization UICustomizationArray = new UICustomization(_context);
        //        ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

        //        SqlParameter parameter = new SqlParameter("@OId", Id);

        //        List<SuObjectLanguageIndexGetModel> LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ClassificationPageLanguageIndexGet @OId", parameter).ToList();
        //        ViewBag.Id = Id;

        //        return View(LanguageIndex);
        //    }

        //    [HttpGet]
        //    public async Task<IActionResult> LanguageEdit(int Id)
        //    {
        //        SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
        //        int DefaultLanguageID = CurrentUser.DefaultLanguageId;

        //        UICustomization UICustomizationArray = new UICustomization(_context);
        //        ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

        //        SqlParameter parameter = new SqlParameter("@LId", Id);

        //        SuObjectLanguageEditGetModel ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ClassificationPageLanguageEditGet @LId", parameter).First();
        //        return View(ObjectLanguage);
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> LanguageEdit(SuObjectLanguageEditGetModel FromForm)
        //    {
        //        SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
        //        int DefaultLanguageID = CurrentUser.DefaultLanguageId;

        //        UICustomization UICustomizationArray = new UICustomization(_context);
        //        ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
        //        if (ModelState.IsValid)
        //        {
        //            SqlParameter[] parameters =
        //                {
        //                new SqlParameter("@LId", FromForm.LId),
        //                new SqlParameter("@ModifierId", CurrentUser.Id),
        //                new SqlParameter("@Name", FromForm.Name),
        //                new SqlParameter("@Description", FromForm.Description),
        //                new SqlParameter("@MouseOver", FromForm.MouseOver),
        //                new SqlParameter("@MenuName", FromForm.MenuName)
        //                };

        //             _context.Database.ExecuteSqlCommand("ClassificationPageLanguageEditPost " +
        //                        "@LId" +
        //                        ", @ModifierId" +
        //                        ", @Name" +
        //                        ", @Description" +
        //                        ", @MouseOver" +
        //                        ", @MenuName", parameters);
        //            return RedirectToAction("LanguageIndex", new { Id = FromForm.OId.ToString() });
        //         }
        //        return View();
        //    }

        //    [HttpGet]
        //    public async Task<IActionResult> LanguageCreate(int Id)
        //    {
        //        SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
        //        int DefaultLanguageID = CurrentUser.DefaultLanguageId;
        //        UICustomization UICustomizationArray = new UICustomization(_context);
        //        ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

        //        AvailableObjectLanguages AvailableLanguages = new AvailableObjectLanguages(_context);
        //        var SuLanguage = AvailableLanguages.ReturnFreeLanguages(this.ControllerContext.RouteData.Values["controller"].ToString(), Id);
        //        Int32 NoOfLanguages = SuLanguage.Count();
        //        if (NoOfLanguages == 0)
        //            { return RedirectToAction("LanguageIndex", new { Id }); }
        //        SuObjectLanguageCreateGetModel SuObject = new SuObjectLanguageCreateGetModel
        //        {
        //            OId = Id
        //        };
        //        ViewBag.Id = Id.ToString();
        //        SuObjectLanguageCreateGetWithListModel ClassificationPageAndLanguages = new SuObjectLanguageCreateGetWithListModel
        //        {
        //            ObjectLanguage = SuObject
        //            ,
        //             LanguageList = SuLanguage
        //        };
        //        return View(ClassificationPageAndLanguages);
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> LanguageCreate(SuObjectLanguageCreateGetWithListModel FromForm)
        //    {
        //        SuUserModel CurrentUser = await _userManager.GetUserAsync(User);


        //            SqlParameter[] parameters =
        //                {
        //                new SqlParameter("@OId", FromForm.ObjectLanguage.OId),
        //                new SqlParameter("@LanguageId", FromForm.ObjectLanguage.LanguageId),
        //                new SqlParameter("@ModifierId", CurrentUser.Id),
        //                new SqlParameter("@Name", FromForm.ObjectLanguage.Name ?? ""),
        //                new SqlParameter("@Description", FromForm.ObjectLanguage.Description ?? ""),
        //                new SqlParameter("@MouseOver", FromForm.ObjectLanguage.MouseOver ?? ""),
        //                new SqlParameter("@MenuName", FromForm.ObjectLanguage.MenuName ?? "")
        //                };

        //             _context.Database.ExecuteSqlCommand("ClassificationPageLanguageCreatePost " +
        //                        "@OId" +
        //                        ", @LanguageId" +
        //                        ", @ModifierId" +
        //                        ", @Name" +
        //                        ", @Description" +
        //                        ", @MouseOver" +
        //                        ", @MenuName", parameters);
        //        return RedirectToAction("LanguageIndex", new { Id = FromForm.ObjectLanguage.OId.ToString() });
        //    }

        //    [HttpGet]
        //    public async Task<IActionResult> LanguageDelete(int Id)
        //    {
        //        SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
        //        int DefaultLanguageID = CurrentUser.DefaultLanguageId;

        //        UICustomization UICustomizationArray = new UICustomization(_context);
        //        ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

        //        SqlParameter parameter = new SqlParameter("@LId", Id);
        //        SuObjectLanguageEditGetModel ClassificationPageLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ClassificationPageLanguageEditGet @LId", parameter).First();

        //        return View(ClassificationPageLanguage);
        //    }

        //    [HttpPost]
        //    public IActionResult LanguageDelete(SuObjectLanguageEditGetModel FromForm)
        //    {
        //            _classificationPageLanguage.DeleteClassificationPageLanguage(FromForm.LId);
        //            return RedirectToAction("LanguageIndex", new { Id = FromForm.OId });
        //    }

        //    [HttpGet]
        //    public async Task<IActionResult> Delete(int Id)
        //    {
        //        SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
        //        int DefaultLanguageID = CurrentUser.DefaultLanguageId;

        //        UICustomization UICustomizationArray = new UICustomization(_context);
        //        ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

        //        SqlParameter[] parameters =
        //            {
        //                new SqlParameter("@OId", Id)
        //                , new SqlParameter("@LanguageId", DefaultLanguageID)
        //            };

        //        SuClassificationPageDeleteGetModel ClassificationPage = _context.ZdbClassificationPageDeleteGet.FromSql("ClassificationPageDeleteGet @OId, @LanguageId", parameters).First();

        //        return View(ClassificationPage);
        //    }

        //    [HttpPost]
        //    public IActionResult Delete(SuClassificationPageDeleteGetModel FromForm)
        //    {

        //        var parameter = new SqlParameter("@OId", FromForm.OId);
        //         _context.Database.ExecuteSqlCommand("ClassificationPageDeletePost @OId", parameter);

        //        return RedirectToAction("Index", new { Id = FromForm.PId });
        //    }

    }

}
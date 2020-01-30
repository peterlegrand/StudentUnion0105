using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http.Features;
using Syncfusion.EJ2.Navigations;

namespace StudentUnion0105.Controllers
{
    [Authorize("Classification")]
    public class ClassificationController : PortalController
    {
        
        //private readonly IClassificationStatusRepository _classificationStatus;
        //private readonly IClassificationRepository _classification;
        //private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly SuDbContext _context;
        private readonly IHostingEnvironment _hostingEnv;

        public ClassificationController(UserManager<SuUserModel> userManager
                                                //, IClassificationStatusRepository classificationStatus
                                                //, IClassificationRepository classification
                                                //, IClassificationLanguageRepository classificationLanguage
                                                , ILanguageRepository language
                                                , SuDbContext context
            , IHostingEnvironment hostingEnv
            ) : base(userManager, language)
        {
            //_classificationStatus = classificationStatus;
            //_classification = classification;
            //_classificationLanguage = classificationLanguage;
            _context = context;
            _hostingEnv = hostingEnv;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);

            var Classification = _context.ZdbObjectIndexGet.FromSql("ClassificationIndexGet @LanguageId", parameter).ToList();
            
            return View(Classification);
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

            var ClassificationEditGet = _context.ZdbClassificationEditGet.FromSql("ClassificationEditGet @LanguageId, @Id", parameters).First();
            
            var ClassificationStatusList = new List<SelectListItem>();
            var StatusList = _context.ZDbStatusList.FromSql("ClassificationGetStatusList").ToList();

            foreach (var Status in StatusList)
            {
                ClassificationStatusList.Add(new SelectListItem
                {
                    Text = Status.Name,
                    Value = Status.Id.ToString()
                });
            }
            SuClassificationEditGetWithListModel ClassificationWithList = new SuClassificationEditGetWithListModel
            {
                Classification = ClassificationEditGet,
                StatusList = ClassificationStatusList
            };

            return View(ClassificationWithList);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuClassificationEditGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.Classification.Id),
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId),
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
                _context.Database.ExecuteSqlCommand("ClassificationEditPost " +
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


            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var ClassificationStatusList = new List<SelectListItem>();

            var StatusList = await _context.ZDbStatusList.FromSql("ClassificationStatusList").ToListAsync();


            foreach (var Status in StatusList)
            {
                ClassificationStatusList.Add(new SelectListItem
                {
                    Text = Status.Name,
                    Value = Status.Id.ToString()
                });
            }
            var Classification = new SuClassificationEditGetModel { Description = "x" };
            var ClassificationAndStatus = new SuClassificationEditGetWithListModel { Classification= Classification, StatusList = ClassificationStatusList };

            ViewBag.tools = new[] {
        "Bold", "Italic", "Underline", "StrikeThrough",
        "FontName", "FontSize", "FontColor", "BackgroundColor",
        "LowerCase", "UpperCase", "|",
        "Formats", "Alignments", "OrderedList", "UnorderedList",
        "Outdent", "Indent", "|",
        "CreateLink", "Image", "CreateTable", "|", "ClearFormat", "Print",
        "SourceCode", "FullScreen", "|", "Undo", "Redo"
            };
            return View(ClassificationAndStatus);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(SuClassificationEditGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);

                SqlParameter[] parameters =
                    {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId),
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

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ClassificationLanguageIndexGet @OId", parameter).ToList();
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

            var parameter = new SqlParameter("@LId", Id);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ClassificationLanguageEditGet @LId", parameter).First();
            return View(ObjectLanguage);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageEdit(SuObjectLanguageEditGetModel FromForm)
        {
            

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);
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

            SuObjectLanguageCreateGetModel Classification = new SuObjectLanguageCreateGetModel
            {
                OId = Id
            };
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
                var CurrentUser = await _userManager.GetUserAsync(User);

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
        public async  Task<IActionResult> LanguageDelete(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@LId", Id);
            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ClassificationLanguageEditGet @LId" , parameter).First();
            return View(ObjectLanguage);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectLanguageEditGetModel FromForm)
        {
            var parameter = new SqlParameter("@Id", FromForm.LId);
            _context.Database.ExecuteSqlCommand("ClassificationLanguageDeletePost @Id", parameter);

            return RedirectToAction("LanguageIndex", new { Id = FromForm.OId });
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

            SuClassificationDeleteGetModel Classification = _context.ZdbClassificationDeleteGet.FromSql("ClassificationDeleteGet @LanguageId, @Id", parameters).First();



            return View(Classification);
        }

        [HttpPost]
        public IActionResult Delete(SuClassificationDeleteGetModel FromForm)
        {
            var parameter = new SqlParameter("@OId", FromForm.OId);
            _context.Database.ExecuteSqlCommand($"ClassificationDeletePost @OId", parameter);

            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult SaveImage(IList<IFormFile> UploadFiles)
        {
            try
            {
                foreach (IFormFile file in UploadFiles)
                {
                    if (UploadFiles != null)
                    {
                        string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        Guid g = Guid.NewGuid();
                        string GuidString = Convert.ToBase64String(g.ToByteArray());
                        GuidString = GuidString.Replace("=", "");
                        GuidString = GuidString.Replace("+", "");
                        string onlyfilename = GuidString + $@"{filename}";
                        filename = _hostingEnv.ContentRootPath + "\\wwwroot\\Images\\Content\\" + GuidString + $@"{filename}";
                        if (!System.IO.File.Exists(filename))
                        {
                            Response.ContentType = "application/json; charset=utf-8";
                            Response.Headers.Add("name", onlyfilename);
                            //Response.Clear();
                            Response.StatusCode = 204;
                            
                            using (FileStream fs = System.IO.File.Create(filename))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }
                            //Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File already exists.";
                        }
                        else
                        {
                            Response.ContentType = "application/json; charset=utf-8";
                            Response.Headers.Add("name", onlyfilename);
                            Response.Clear();
                            Response.StatusCode = 204;
                            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File already exists.";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "No Content";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
            return Content("");
        }
    }

}


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using Syncfusion.EJ2.Navigations;
using Microsoft.AspNetCore.Identity;
using StudentUnion0105.Repositories;
using StudentUnion0105.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using StudentUnion0105.Classes;

namespace StudentUnion0105.Controllers
{
    [AllowAnonymous]
    public class HomeController : PortalController
    {
        private readonly IHostingEnvironment hostingEnv;
        private readonly SuDbContext _context;

        public HomeController(IHostingEnvironment env, UserManager<SuUserModel> userManager
                                                            , ILanguageRepository language
                                                , SuDbContext context
) : base(userManager, language)
        {
            hostingEnv = env;
            _context = context;
        }
        [HttpGet]
        public ActionResult Index()
        {
            //    ViewBag.tools = new[] {
            //"Bold", "Italic", "Underline", "StrikeThrough",
            //"FontName", "FontSize", "FontColor", "BackgroundColor",
            //"LowerCase", "UpperCase", "|",
            //"Formats", "Alignments", "OrderedList", "UnorderedList",
            //"Outdent", "Indent", "|",
            //"CreateLink", "Image", "CreateTable", "|", "ClearFormat", "Print",
            //"SourceCode", "FullScreen", "|", "Undo", "Redo"
            //    };



            return View();
        }
        [HttpGet]
        public ActionResult Index2()
        {
            //    ViewBag.tools = new[] {
            //"Bold", "Italic", "Underline", "StrikeThrough",
            //"FontName", "FontSize", "FontColor", "BackgroundColor",
            //"LowerCase", "UpperCase", "|",
            //"Formats", "Alignments", "OrderedList", "UnorderedList",
            //"Outdent", "Indent", "|",
            //"CreateLink", "Image", "CreateTable", "|", "ClearFormat", "Print",
            //"SourceCode", "FullScreen", "|", "Undo", "Redo"
            //    };

            List<object> menuItems = new List<object>
            {
                new
                {
                    text = "File",
                    items = new List<object>()
                    {
                        new { text = "Open" },
                        new { text = "Save" },
                        new { text = "Exit" }
                    }
                },
                new
                {
                    text = "Edit",
                    items = new List<object>()
                    {
                        new { text = "Cut" },
                        new { text = "Copy" },
                        new { text = "Paste" }
                    }
                },
                new
                {
                    text = "View",
                    items = new List<object>()
                    {
                        new { text = "Toolbar" },
                        new { text = "Sidebar" },
                        new { text = "Fullscreen" }
                    }
                },
                new
                {
                    text = "Tools",
                    items = new List<object>()
                    {
                        new { text = "Spelling & Grammar" },
                        new { text = "Customize" },
                        new { text = "Options" }
                    }
                },
                new
                {
                    text = "Go"
                },
                new
                {
                    text = "Help"
                }
            };

            ViewBag.menuItems = menuItems;

     //       TopMenu();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> IndexAdmin()
        {

            var CurrentUser = await _userManager.GetUserAsync(User);

            // MenusEtc.Initializing();

            var Languages = await _context.ZdbHomeIndexAdminGetLanguages.FromSql("HomeIndexAdminGetLanguages").ToListAsync();
            var TableNames = await _context.ZdbHomeIndexAdminGetTableName.FromSql("HomeIndexAdminGetTables").ToListAsync();

            SuHomeIndexAdminGetModel Matrix = new SuHomeIndexAdminGetModel();
            Matrix.languages = Languages;
            for (int i = 0; i < TableNames.Count; i++)
            {
                var parameter = new SqlParameter("@TableName", TableNames[i].TableDescription);
                var a = await  _context.ZdbHomeIndexAdminGetNoOfRecordsAndPerLanguage.FromSql("HomeIndexAdminGetNoOfRecordsAndPerLanguage @TableName", parameter).ToListAsync();
                TableNames[i].SetOfNoOfRecords = a;

            }
            Matrix.Tables = TableNames;

            return View(Matrix);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Index(IList<IFormFile> UploadFiles)
        {
            try
            {
                foreach (IFormFile file in UploadFiles)
                {
                    if (UploadFiles != null)
                    {
                        string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        filename = hostingEnv.WebRootPath + "\\Images" + $@"\{filename}";
                        if (!System.IO.File.Exists(filename))
                        {
                            using (FileStream fs = System.IO.File.Create(filename))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }
                        }
                        else
                        {
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
    //public async Task<string> TopMenu()
    //{

    //    var CurrentUser = await _userManager.GetUserAsync(User);
    //    var DefaultLanguageID = CurrentUser.DefaultLanguageId;


    //    var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);

    //    var TopMenu1List = _context.ZdbTopMenu1.FromSql("PartialTopMenu1 @LanguageId", parameter).ToList();


    //    List<MenuItem> menuItem1List = new List<MenuItem>();
    //    foreach (var TopMenu1 in TopMenu1List)
    //    {
    //        menuItem1List.Add(new MenuItem
    //        {
    //            Text = TopMenu1.MenuName,
    //            IconCss = TopMenu1.IconCss,
    //            Url = TopMenu1.MenuController,
    //            Items = new List<MenuItem>()
    //            {
    //                new MenuItem { Text= "Open", IconCss= "em-icons e-open", Url= "Home/Open" },
    //                new MenuItem { Text= "Save", IconCss= "e-icons e-save", Url= "Home/Save" },
    //                new MenuItem { Separator= true },
    //                new MenuItem { Text= "Exit", Url= "Home/Exit" }
    //            }
    //        });



    //    }
    //        ViewBag.menuItems2 = menuItem1List;
    //    return ("");
    }


}

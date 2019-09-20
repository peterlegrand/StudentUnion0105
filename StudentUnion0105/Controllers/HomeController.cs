using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Models;


namespace StudentUnion0105.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment hostingEnv;

        public HomeController(IHostingEnvironment env)
        {
            hostingEnv = env;
        }
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.tools = new[] {
        "Bold", "Italic", "Underline", "StrikeThrough",
        "FontName", "FontSize", "FontColor", "BackgroundColor",
        "LowerCase", "UpperCase", "|",
        "Formats", "Alignments", "OrderedList", "UnorderedList",
        "Outdent", "Indent", "|",
        "CreateLink", "Image", "CreateTable", "|", "ClearFormat", "Print",
        "SourceCode", "FullScreen", "|", "Undo", "Redo"
            };

            List<object> menuItems = new List<object>();
            menuItems.Add(new
            {
                text = "File",
                items = new List<object>()
                    {
                        new { text = "Open" },
                        new { text = "Save" },
                        new { text = "Exit" }
                    }
            });
            menuItems.Add(new
            {
                text = "Edit",
                items = new List<object>()
                    {
                        new { text = "Cut" },
                        new { text = "Copy" },
                        new { text = "Paste" }
                    }
            });
            menuItems.Add(new
            {
                text = "View",
                items = new List<object>()
                    {
                        new { text = "Toolbar" },
                        new { text = "Sidebar" },
                        new { text = "Fullscreen" }
                    }
            });
            menuItems.Add(new
            {
                text = "Tools",
                items = new List<object>()
                    {
                        new { text = "Spelling & Grammar" },
                        new { text = "Customize" },
                        new { text = "Options" }
                    }
            });
            menuItems.Add(new
            {
                text = "Go"
            });
            menuItems.Add(new
            {
                text = "Help"
            });

            ViewBag.menuItems = menuItems;
            

            return View();
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
    }
}

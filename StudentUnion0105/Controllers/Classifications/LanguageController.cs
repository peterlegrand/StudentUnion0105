using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentUnion0105.Controllers.Classifications
{
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
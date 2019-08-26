using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Models;

namespace StudentUnion0105.Controllers

{
    public class MainController : Controller
    {
        public MainController(UserManager<SuUser> userManager
            )
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
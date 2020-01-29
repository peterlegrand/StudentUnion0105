using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Classes
{
    public abstract class PortalController  : Controller
    {
        protected readonly UserManager<SuUserModel> _userManager;
        protected readonly ILanguageRepository _language;
    //    protected readonly SuDbContext _context;

        public  PortalController(UserManager<SuUserModel> userManager
                                                , ILanguageRepository language
//                                                , SuDbContext context
            )
        {
            _userManager = userManager;
            _language = language;
  //          _context = context;
        }

    }
}

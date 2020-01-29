﻿using Microsoft.AspNetCore.Authorization;
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
//    [Authorize("Classification")]
    public class FrontRelationController : PortalController
    {
        private readonly SuDbContext _context;

        public FrontRelationController(UserManager<SuUserModel> userManager
                                                , ILanguageRepository language
                                                , SuDbContext context
            ) : base(userManager, language)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> MyRelation()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            // MenusEtc.Initializing();

            var parameterPage = new SqlParameter("@CurrentUser", CurrentUser.Id);


            List<SuFrontRelationMyFrontRelationGetModel> FrontRelationMyFrontRelation = _context.ZdbFrontRelationMyRelationGet.FromSql("FrontRelationMyRelationGet @CurrentUser", parameterPage).ToList();

            return View(FrontRelationMyFrontRelation);
        }


    }
}

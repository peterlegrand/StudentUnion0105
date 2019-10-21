using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<SuUserModel> _userManager;
        private readonly ISettingRepository _setting;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public SettingController(UserManager<SuUserModel> userManager
                                                , ISettingRepository setting
                                                , ILanguageRepository language
            , SuDbContext context)
        {
            _userManager = userManager;
            _setting = setting;
            _language = language;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ToForm = (

                from l in _setting.GetAllSettings()

                select new SuObjectVM


                {
                    Id = l.Id
                             ,
                    Name = l.SettingName
                    , NullId = l.IntValue
                    , Description2 = l.StringValue
                    , DateFrom = l.DateTimeValue
                    

                }).ToList();
            return View(ToForm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var ToForm = (

                from l in _setting.GetAllSettings()
    where l.Id == Id
                select new SuObjectVM


                {
                    Id = l.Id
                             ,
                    Name = l.SettingName
                    ,
                    NullId = l.IntValue
                    ,
                    Description2 = l.StringValue
                    ,
                    DateFrom = l.DateTimeValue
                    , Description = l.SettingDescription


                }).First();
            return View(ToForm);


        }


        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var Setting = _setting.GetSetting(FromForm.Id);
                Setting.IntValue = FromForm.NullId;
                Setting.StringValue = FromForm.Description2;
//PETER here we stil need to update the date setting
                _setting.UpdateSetting(Setting);


            }
            return RedirectToAction("Index");



        }

    }
}
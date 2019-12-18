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
    public class OrganizationTypeController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IOrganizationTypeLanguageRepository _OrganizationTypeLanguage;
        private readonly IOrganizationTypeRepository _OrganizationType;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;

        public OrganizationTypeController(UserManager<SuUserModel> userManager
            , IOrganizationTypeLanguageRepository OrganizationTypeLanguage
            , IOrganizationTypeRepository OrganizationType
            , ILanguageRepository language
            , SuDbContext context)
        {
            this.userManager = userManager;
            _OrganizationTypeLanguage = OrganizationTypeLanguage;
            _OrganizationType = OrganizationType;
            _language = language;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);


            var parameter = new SqlParameter("@LanguageId", DefaultLanguageID);

            var OrganizationType = _context.ZdbObjectIndexGet.FromSql("OrganizationTypeIndexGet @LanguageId", parameter).ToList();
            return View(OrganizationType);

            //var OrganizationTypes = (

            //    from l in _OrganizationTypeLanguage.GetAllOrganizationTypeLanguages()

            //    where l.LanguageId == DefaultLanguageID
            //    select new SuObjectVM


            //    {
            //        Id = l.OrganizationTypeId
            //                 ,
            //        Name = l.Name
            //    }).ToList();
            //return View(OrganizationTypes);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var OrganizationType = new SuObjectVM();
            return View(OrganizationType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var OrganizationType = new SuOrganizationTypeModel();
                OrganizationType.ModifiedDate = DateTime.Now;
                OrganizationType.CreatedDate = DateTime.Now;
                var NewOrganizationType = _OrganizationType.AddOrganizationType(OrganizationType);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var OrganizationTypeLanguage = new SuOrganizationTypeLanguageModel();

                OrganizationTypeLanguage.Name = FromForm.Name;
                OrganizationTypeLanguage.Description = FromForm.Description;
                OrganizationTypeLanguage.MouseOver = FromForm.MouseOver;
                OrganizationTypeLanguage.OrganizationTypeId = NewOrganizationType.Id;
                OrganizationTypeLanguage.LanguageId = DefaultLanguageID;
                _OrganizationTypeLanguage.AddOrganizationTypeLanguage(OrganizationTypeLanguage);

            }
            return RedirectToAction("Index");



        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);


            var ToForm = (from s in _OrganizationType.GetAllOrganizationTypes()
                         join t in _OrganizationTypeLanguage.GetAllOrganizationTypeLanguages()
                         on s.Id equals t.OrganizationTypeId
                         where t.LanguageId == DefaultLanguageID && s.Id == Id
                         select new SuObjectVM
                         {
                             Id = s.Id
                            ,
                             Name = t.Name
                            ,
                             ObjectLanguageId = t.Id
                            ,
                             Description = t.Description
                            ,
                             MouseOver = t.MouseOver
                         }).First();

            return View(ToForm);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var OrganizationType = _OrganizationType.GetOrganizationType(test3.Id);
                var CurrentUser = await userManager.GetUserAsync(User);

                OrganizationType.ModifiedDate = DateTime.Now;
                OrganizationType.ModifierId = CurrentUser.Id;
                _OrganizationType.UpdateOrganizationType(OrganizationType);

                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var OrganizationTypeLanguage = _OrganizationTypeLanguage.GetOrganizationTypeLanguage(test3.ObjectLanguageId);
                OrganizationTypeLanguage.Name = test3.Name;
                OrganizationTypeLanguage.Description = test3.Description;
                OrganizationTypeLanguage.MouseOver = test3.MouseOver;
                OrganizationTypeLanguage.ModifiedDate = DateTime.Now;
                OrganizationTypeLanguage.ModifierId = CurrentUser.Id;
                _OrganizationTypeLanguage.UpdateOrganizationTypeLanguage(OrganizationTypeLanguage);

            }
            return RedirectToAction("Index");



        }


        public async Task<IActionResult> LanguageIndex(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("OrganizationTypeLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);


        }

        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _OrganizationTypeLanguage.GetAllOrganizationTypeLanguages()
                                where c.OrganizationTypeId == Id
                                select c.LanguageId).ToList();


            var SuLanguage = (from l in _language.GetAllLanguages()
                              where !LanguagesAlready.Contains(l.Id)
                              && l.Active
                              select new SelectListItem
                              {
                                  Value = l.Id.ToString()
                              ,
                                  Text = l.LanguageName
                              }).ToList();

            if (SuLanguage.Count() == 0)
            {
                return RedirectToAction("LanguageIndex", new { Id = Id });
            }
            SuObjectVM SuObject = new SuObjectVM();
            SuObject.ObjectId = Id;
            ViewBag.Id = Id.ToString();
            var OrganizationTypeAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(OrganizationTypeAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {

                var OrganizationTypeLanguage = new SuOrganizationTypeLanguageModel();
                OrganizationTypeLanguage.Name = test3.SuObject.Name;
                OrganizationTypeLanguage.Description = test3.SuObject.Description;
                OrganizationTypeLanguage.MouseOver = test3.SuObject.MouseOver;
                OrganizationTypeLanguage.OrganizationTypeId = test3.SuObject.ObjectId;
                OrganizationTypeLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewOrganizationTypeLanguage = _OrganizationTypeLanguage.AddOrganizationTypeLanguage(OrganizationTypeLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {

            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@Id", Id);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("OrganizationTypeLanguageEditGet @Id", parameter).First();
            return View(ObjectLanguage);

        }

        [HttpPost]
        public async Task<IActionResult> LanguageEdit(SuObjectLanguageEditGetModel FromForm)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
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

                _context.Database.ExecuteSqlCommand("OrganizationTypeLanguageEditPost " +
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
        public IActionResult LanguageDelete(int Id)
        {
            var OrganizationTypeLanguage = _OrganizationTypeLanguage.DeleteOrganizationTypeLanguage(Id);
            var a = new SuObjectVM();
            a.Id = OrganizationTypeLanguage.Id;
            a.Name = OrganizationTypeLanguage.Name;
            a.Description = OrganizationTypeLanguage.Description;
            a.MouseOver = OrganizationTypeLanguage.MouseOver;
            a.LanguageId = OrganizationTypeLanguage.LanguageId;
            a.ObjectId = OrganizationTypeLanguage.OrganizationTypeId;
            return View(a);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectVM a)
        {
            if (ModelState.IsValid)
            {

                _OrganizationTypeLanguage.DeleteOrganizationTypeLanguage(a.Id);
                return RedirectToAction("LanguageIndex", new { Id = a.ObjectId });
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@Id", Id)
                };

            var OrganizationType = _context.DbOrganizationTypeDeleteGet.FromSql("OrganizationTypeDeleteGet @LanguageId, @Id" , parameters).First();

            return View(OrganizationType);
        }
        [HttpPost]
        public IActionResult Delete(SuOrganizationTypeDeleteGetModel FromForm)
        {
            var b = _context.Database.ExecuteSqlCommand($"OrganizationTypeDeletePost {FromForm.Id}");

            return RedirectToAction("Index");

        }

    }
}
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
    public class OrganizationController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IOrganizationLanguageRepository _OrganizationLanguage;
        private readonly IOrganizationRepository _Organization;
        private readonly ILanguageRepository _language;
        private readonly IOrganizationStatusRepository _OrganizationStatus;
        private readonly IOrganizationTypeRepository _organizationType;
        private readonly IOrganizationTypeLanguageRepository _organizationTypeLanguage;
        private readonly SuDbContext _context;
        private readonly IGetOrganizationStructureRepository _organizationStructure;

        public OrganizationController(UserManager<SuUserModel> userManager
            , IOrganizationLanguageRepository OrganizationLanguage
            , IOrganizationRepository Organization
            , ILanguageRepository language
            , IOrganizationStatusRepository OrganizationStatus
            , IOrganizationTypeRepository organizationType
            , IOrganizationTypeLanguageRepository organizationTypeLanguage
            , IGetOrganizationStructureRepository OrganizationStructure
            , SuDbContext context)
        {
            this.userManager = userManager;
            _OrganizationLanguage = OrganizationLanguage;
            _Organization = Organization;
            _language = language;
            _OrganizationStatus = OrganizationStatus;
            _organizationType = organizationType;
            _organizationTypeLanguage = organizationTypeLanguage;
            _context = context;
            _organizationStructure = OrganizationStructure;
        }

        //PETER probably can be deleted
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray( this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID) ;

            var parameter = new SqlParameter("@LanguageID", DefaultLanguageID);

            var OrgStructure = _context.ZdbOrganizationIndexGet.FromSql("OrganizationIndexGet @LanguageID", parameter).ToList();

            int maxLevel = 0;
            foreach (var Org in OrgStructure)
            {
                if (Org.Level > maxLevel)
                {
                    maxLevel = Org.Level;
                }
            }

            var OrgStructureWithDepth = new OrgStructureWithDepth { MaxLevel = maxLevel, OrgStructure = OrgStructure };
            return View(OrgStructureWithDepth);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var ParentOrganization = _Organization.GetOrganization(Id);

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);


            var StatusList = new List<SelectListItem>();

            foreach (var StatusFromDb in _OrganizationStatus.GetAllOrganizationStatus())
            {
                StatusList.Add(new SelectListItem
                {
                    Text = StatusFromDb.Name,
                    Value = StatusFromDb.Id.ToString()
                });
            }

            var ToForm = (from o in _organizationType.GetAllOrganizationTypes()
                         join l in _organizationTypeLanguage.GetAllOrganizationTypeLanguages()
                         on o.Id equals l.OrganizationTypeId
                         where l.LanguageId == DefaultLanguageID
                         select new SuObjectVM
                         {
                             Id = o.Id
                            ,
                             Name = l.Name
                         }).ToList();

            var TypeList = new List<SelectListItem>();
            foreach (var TypeFromDb in ToForm)
            {
                TypeList.Add(new SelectListItem
                {
                    Text = TypeFromDb.Name,
                    Value = TypeFromDb.Id.ToString()
                });
            }
            //wwwwwwwwwwwwwwwwwwwwwwww

            SuObjectVM Parent = new SuObjectVM()
            {
                NullId = ParentOrganization == null ? 0 : ParentOrganization.Id
            };
            var OrganizationAndStatus = new SuObjectAndStatusViewModel { SuObject = Parent, SomeKindINumSelectListItem = StatusList, ProbablyTypeListItem = TypeList };
            return View(OrganizationAndStatus);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var Organization = new SuOrganizationModel();
                Organization.ModifiedDate = DateTime.Now;
                Organization.CreatedDate = DateTime.Now;
                Organization.OrganizationStatusId = FromForm.SuObject.Status;
                Organization.OrganizationTypeId = FromForm.SuObject.Type;
                if (FromForm.SuObject.NullId != 0)
                { Organization.ParentOrganizationId = FromForm.SuObject.NullId; }
                var NewOrganization = _Organization.AddOrganization(Organization);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var OrganizationLanguage = new SuOrganizationLanguageModel();

                OrganizationLanguage.Name = FromForm.SuObject.Name;
                OrganizationLanguage.Description = FromForm.SuObject.Description;
                OrganizationLanguage.MouseOver = FromForm.SuObject.MouseOver;
                OrganizationLanguage.OrganizationId = NewOrganization.Id;
                OrganizationLanguage.LanguageId = DefaultLanguageID;
                _OrganizationLanguage.AddOrganizationLanguage(OrganizationLanguage);

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


            var ToForm = (from s in _Organization.GetAllOrganizations()
                         join t in _OrganizationLanguage.GetAllOrganizationLanguages()
                         on s.Id equals t.OrganizationId
                         where t.LanguageId == DefaultLanguageID && s.Id == Id
                         select new SuObjectVM
                         {
                             Id = s.Id
                            ,
                             Name = t.Name
                            ,
                             Status = s.OrganizationStatusId
                            ,
                             ObjectLanguageId = t.Id
                            ,
                             Description = t.Description
                            ,
                             MouseOver = t.MouseOver
                         }).First();

            var OrganizationList = new List<SelectListItem>();

            foreach (var OrganizationFromDb in _OrganizationStatus.GetAllOrganizationStatus())
            {
                OrganizationList.Add(new SelectListItem
                {
                    Text = OrganizationFromDb.Name,
                    Value = OrganizationFromDb.Id.ToString()
                });
            }
            var OrganizationAndStatus = new SuObjectAndStatusViewModel { SuObject = ToForm, SomeKindINumSelectListItem = OrganizationList };
            return View(OrganizationAndStatus);




        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var Organization = _Organization.GetOrganization(test3.Id);
                var CurrentUser = await userManager.GetUserAsync(User);

                Organization.ModifiedDate = DateTime.Now;
                Organization.ModifierId = new Guid(CurrentUser.Id);
                _Organization.UpdateOrganization(Organization);

                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var OrganizationLanguage = _OrganizationLanguage.GetOrganizationLanguage(test3.ObjectLanguageId);
                OrganizationLanguage.Name = test3.Name;
                OrganizationLanguage.Description = test3.Description;
                OrganizationLanguage.MouseOver = test3.MouseOver;
                OrganizationLanguage.ModifiedDate = DateTime.Now;
                OrganizationLanguage.ModifierId = new Guid(CurrentUser.Id);
                _OrganizationLanguage.UpdateOrganizationLanguage(OrganizationLanguage);

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

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("OrganizationLanguageIndexGet @OId", parameter).ToList();
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
            LanguagesAlready = (from c in _OrganizationLanguage.GetAllOrganizationLanguages()
                                where c.OrganizationId == Id
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
            var OrganizationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(OrganizationAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var OrganizationLanguage = new SuOrganizationLanguageModel();
                OrganizationLanguage.Name = test3.SuObject.Name;
                OrganizationLanguage.Description = test3.SuObject.Description;
                OrganizationLanguage.MouseOver = test3.SuObject.MouseOver;
                OrganizationLanguage.OrganizationId = test3.SuObject.ObjectId;
                OrganizationLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewOrganizationLanguage = _OrganizationLanguage.AddOrganizationLanguage(OrganizationLanguage);


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

            SqlParameter[] parameters =
    {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@Id", Id)
                };

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("OrganizationEditGet @LanguageId, @Id", parameters).First();
            return View(ObjectLanguage);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectVM test3)
        {
            if (ModelState.IsValid)
            {
                var OrganizationLanguage = _OrganizationLanguage.GetOrganizationLanguage(test3.Id);
                OrganizationLanguage.Name = test3.Name;
                OrganizationLanguage.Description = test3.Description;
                OrganizationLanguage.MouseOver = test3.MouseOver;
                _OrganizationLanguage.UpdateOrganizationLanguage(OrganizationLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Organization.OrganizationId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = test3.ObjectId.ToString() });
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

            var Classification = _context.DbOrganizationDeleteGet.FromSql("OrganizationDeleteGet @LanguageId, @Id", parameters).First();

            return View(Classification);
        }
        [HttpPost]
        public IActionResult Delete(SuContentTypeDeleteGetModel FromForm)
        {
            var b = _context.Database.ExecuteSqlCommand($"OrganizationDeletePost {FromForm.Id}");

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> LanguageDelete(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameter = new SqlParameter("@Id", Id);

            var OrganizationLanguage = _context.ZdbObjectLanguageEditGet.FromSql("OrganizationLanguageEditGet @Id", parameter).First();


            return View(OrganizationLanguage);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectLanguageEditGetModel FromForm)
        {
            if (ModelState.IsValid)
            {

                _OrganizationLanguage.DeleteOrganizationLanguage(FromForm.LId);
                return RedirectToAction("LanguageIndex", new { Id = FromForm.OId });
            }
            return RedirectToAction("LanguageIndex");

        }

    }
}
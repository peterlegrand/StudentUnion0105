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
    public class OrganizationController : PortalController
    {
        private readonly IOrganizationLanguageRepository _OrganizationLanguage;
        private readonly IOrganizationRepository _Organization;
        private readonly IOrganizationStatusRepository _OrganizationStatus;
        private readonly IOrganizationTypeRepository _organizationType;
        private readonly IOrganizationTypeLanguageRepository _organizationTypeLanguage;
        private readonly IGetOrganizationStructureRepository _organizationStructure;
                private readonly SuDbContext _context;

        public OrganizationController(UserManager<SuUserModel> userManager
            , IOrganizationLanguageRepository OrganizationLanguage
            , IOrganizationRepository Organization
            , ILanguageRepository language
            , IOrganizationStatusRepository OrganizationStatus
            , IOrganizationTypeRepository organizationType
            , IOrganizationTypeLanguageRepository organizationTypeLanguage
            , IGetOrganizationStructureRepository OrganizationStructure
            , SuDbContext context) : base(userManager, language)
        {
            _OrganizationLanguage = OrganizationLanguage;
            _Organization = Organization;
            _OrganizationStatus = OrganizationStatus;
            _organizationType = organizationType;
            _organizationTypeLanguage = organizationTypeLanguage;
            _organizationStructure = OrganizationStructure;
                    _context = context;
}

        //PETER probably can be deleted
        public async Task<IActionResult> Index()
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


         
            var parameter = new SqlParameter("@LanguageID", CurrentUser.DefaultLanguageId);

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

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var ParentOrganization = _Organization.GetOrganization(Id);




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
                         where l.LanguageId == CurrentUser.DefaultLanguageId
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
                var Organization = new SuOrganizationModel
                {
                    ModifiedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    OrganizationStatusId = FromForm.SuObject.Status,
                    OrganizationTypeId = FromForm.SuObject.Type
                };
                if (FromForm.SuObject.NullId != 0)
                { Organization.ParentOrganizationId = FromForm.SuObject.NullId; }
                var NewOrganization = _Organization.AddOrganization(Organization);


                var CurrentUser = await _userManager.GetUserAsync(User);

                SuOrganizationLanguageModel OrganizationLanguage = new SuOrganizationLanguageModel
                {
                    Name = FromForm.SuObject.Name,
                    Description = FromForm.SuObject.Description,
                    MouseOver = FromForm.SuObject.MouseOver,
                    OrganizationId = NewOrganization.Id,
                    LanguageId = CurrentUser.DefaultLanguageId
                };
                _OrganizationLanguage.AddOrganizationLanguage(OrganizationLanguage);

            }
            return RedirectToAction("Index");



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


            //LISTS
            var StatusList = new List<SelectListItem>();

            foreach (var StatusFromDb in _OrganizationStatus.GetAllOrganizationStatus())
            {
                StatusList.Add(new SelectListItem
                {
                    Text = StatusFromDb.Name,
                    Value = StatusFromDb.Id.ToString()
                });
            }

            //wwwwwwwwwwwwwwwwwwwwwwwwww
            var ToForm = (from o in _organizationType.GetAllOrganizationTypes()
                          join l in _organizationTypeLanguage.GetAllOrganizationTypeLanguages()
                          on o.Id equals l.OrganizationTypeId
                          where l.LanguageId == CurrentUser.DefaultLanguageId
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
            //LISTS


            SqlParameter[] parameters =
    {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@Id", Id)
                };

            SuOrganizationEditGetModel Organization = _context.ZdbOrganizationEditGet.FromSql("OrganizationEditGet @LanguageId, @Id", parameters).First();
            SuOrganizationEditGetWithListModel OrganizationWithList = new SuOrganizationEditGetWithListModel
            {
                StatusList = StatusList,
                TypeList = TypeList,
                Organization = Organization
            };

            return View(OrganizationWithList);


            //var ToForm = (from s in _Organization.GetAllOrganizations()
            //             join t in _OrganizationLanguage.GetAllOrganizationLanguages()
            //             on s.Id equals t.OrganizationId
            //             where t.LanguageId == DefaultLanguageID && s.Id == Id
            //             select new SuObjectVM
            //             {
            //                 Id = s.Id
            //                ,
            //                 Name = t.Name
            //                ,
            //                 Status = s.OrganizationStatusId
            //                ,
            //                 ObjectLanguageId = t.Id
            //                ,
            //                 Description = t.Description
            //                ,
            //                 MouseOver = t.MouseOver
            //             }).First();

            //var OrganizationList = new List<SelectListItem>();

            //foreach (var OrganizationFromDb in _OrganizationStatus.GetAllOrganizationStatus())
            //{
            //    OrganizationList.Add(new SelectListItem
            //    {
            //        Text = OrganizationFromDb.Name,
            //        Value = OrganizationFromDb.Id.ToString()
            //    });
            //}
            //var OrganizationAndStatus = new SuObjectAndStatusViewModel { SuObject = ToForm, SomeKindINumSelectListItem = OrganizationList };
            //return View(OrganizationAndStatus);




        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuOrganizationEditGetWithListModel FromForm)
        {
                SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@OId", FromForm.Organization.OId),
                    new SqlParameter("@StatusId", FromForm.Organization.OrganizationStatusId),
                    new SqlParameter("@TypeId", FromForm.Organization.OrganizationTypeId),
                    new SqlParameter("@LId", FromForm.Organization.LId),
                    new SqlParameter("@LanguageId", FromForm.Organization.LanguageId),
                    new SqlParameter("@Name", FromForm.Organization.Name ?? ""),
                    new SqlParameter("@Description", FromForm.Organization.Description ?? ""),
                    new SqlParameter("@MouseOver", FromForm.Organization.MouseOver ?? ""),
                    new SqlParameter("@MenuName", FromForm.Organization.MenuName ?? ""),
                    new SqlParameter("@ModifierId", CurrentUser.Id)
                    };
                _context.Database.ExecuteSqlCommand("OrganizationEditPost " +
                            "@OId" +
                            ", @StatusId" +
                            ", @TypeId" +
                            ", @LId" +
                            ", @LanguageId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName" + 
                            ", @ModifierId" , parameters);
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

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("OrganizationLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);


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

            var parameter = new SqlParameter("@Id", Id);

            var LanguageList = _context.ZdbLanguageCreateGetLanguageList.FromSql("OrganizationLanguageCreateGetLanguageList @Id", parameter).ToList();

            List<SelectListItem> LList = new List<SelectListItem>();
            foreach (var Language in LanguageList)
            {
                LList.Add(new SelectListItem { Value = Language.Value, Text = Language.Text });
            }

            if (LList.Count() == 0)
            {
                return RedirectToAction("LanguageIndex", new { Id });
            }
            SuObjectLanguageEditGetModel Organization = new SuObjectLanguageEditGetModel
            {
                OId = Id
            };
            ViewBag.Id = Id.ToString();
            var OrganizationAndStatus = new SuObjectLanguageEditGetWitLanguageListModel
            {
                SuObject = Organization
                ,
                LanguageList = LList
            };
            return View(OrganizationAndStatus);



            //List<int> LanguagesAlready = new List<int>();
            //LanguagesAlready = (from c in _OrganizationLanguage.GetAllOrganizationLanguages()
            //                    where c.OrganizationId == Id
            //                    select c.LanguageId).ToList();


            //var SuLanguage = (from l in _language.GetAllLanguages()
            //                  where !LanguagesAlready.Contains(l.Id)
            //                  && l.Active
            //                  select new SelectListItem
            //                  {
            //                      Value = l.Id.ToString()
            //                  ,
            //                      Text = l.LanguageName
            //                  }).ToList();

            //if (SuLanguage.Count() == 0)
            //{
            //    return RedirectToAction("LanguageIndex", new { Id });
            //}
            //SuObjectVM SuObject = new SuObjectVM
            //{
            //    ObjectId = Id
            //};
            //ViewBag.Id = Id.ToString();
            //var OrganizationAndStatus = new SuObjectAndStatusViewModel
            //{
            //    SuObject = SuObject
            //    ,
            //    SomeKindINumSelectListItem = SuLanguage
            //};
            //return View(OrganizationAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                SuOrganizationLanguageModel OrganizationLanguage = new SuOrganizationLanguageModel
                {
                    Name = test3.SuObject.Name,
                    Description = test3.SuObject.Description,
                    MouseOver = test3.SuObject.MouseOver,
                    OrganizationId = test3.SuObject.ObjectId,
                    LanguageId = test3.SuObject.LanguageId
                };

                _OrganizationLanguage.AddOrganizationLanguage(OrganizationLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



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


            SqlParameter[] parameters =
    {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
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

            var Classification = _context.DbOrganizationDeleteGet.FromSql("OrganizationDeleteGet @LanguageId, @Id", parameters).First();

            return View(Classification);
        }
        [HttpPost]
        public IActionResult Delete(SuOrganizationDeleteGetModel FromForm)
        {
            _context.Database.ExecuteSqlCommand($"OrganizationDeletePost {FromForm.Id}");

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> LanguageDelete(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

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
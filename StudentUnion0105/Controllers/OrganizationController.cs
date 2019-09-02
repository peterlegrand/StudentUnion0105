using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly IOrganizationLanguageRepository _OrganizationLanguage;
        private readonly IOrganizationRepository _Organization;
        private readonly ILanguageRepository _language;
        private readonly IOrganizationStatusRepository _OrganizationStatus;
        private readonly IOrganizationTypeRepository _organizationType;
        private readonly IOrganizationTypeLanguageRepository _organizationTypeLanguage;
        private readonly SuDbContext _context;
        //      private readonly IGetOrganizationStructureRepository _organizationStructure;

        public OrganizationController(UserManager<SuUser> userManager
            , IOrganizationLanguageRepository OrganizationLanguage
            , IOrganizationRepository Organization
            , ILanguageRepository language
            , IOrganizationStatusRepository OrganizationStatus
            , IOrganizationTypeRepository organizationType
            , IOrganizationTypeLanguageRepository organizationTypeLanguage
            //, IGetOrganizationStructureRepository OrganizationStructure
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
            //            _organizationStructure = OrganizationStructure;
        }

        //PETER probably can be deleted
        //public async Task<IActionResult> OrgStructure2()
        //{
        //    var CurrentUser = await userManager.GetUserAsync(User);
        //    var DefaultLanguageID = CurrentUser.DefaultLangauge;
        //    var a = _context.dbGetOrganizationStructure.FromSql($"OrganizationStructure {DefaultLanguageID}").ToList();

        //    return View(a);
        //}
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;

            var a1 = (from o in _Organization.GetAllOrganizations()
                      join l in _OrganizationLanguage.GetAllOrganizationLanguages()
                      on o.Id equals l.OrganizationId
                      where l.LanguageId == DefaultLanguageID
                      && o.ParentOrganizationId == null
                      select new SuObjectVM()
                      {
                          Id = o.Id
                           ,
                          Name = l.Name
                      });
            var a2 = (from o in _Organization.GetAllOrganizations()
                      join l in _OrganizationLanguage.GetAllOrganizationLanguages()
                      on o.Id equals l.OrganizationId
                      where l.LanguageId == DefaultLanguageID
                      && o.ParentOrganizationId != null
                      select new SuObjectVM()
                      {
                          Id = o.Id
                           ,
                          Name = l.Name

,
                          NullId = o.ParentOrganizationId

                      }).ToList();

            ObjectsOf5LevelsViewModel a = new ObjectsOf5LevelsViewModel { SuObject1 = a1, SuObject2 = a2, SuObject3 = a2, SuObject4 = a2, SuObject5 = a2 };

            return View(a);
        }
        public async Task<IActionResult> Index2()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var Organizations = (

                from l in _OrganizationLanguage.GetAllOrganizationLanguages()

                where l.LanguageId == DefaultLanguageID
                select new SuObjectVM


                {
                    Id = l.OrganizationId
                             ,
                    Name = l.Name
                }).ToList();
            return View(Organizations);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var ParentOrganization = _Organization.GetOrganization(Id);

var StatusList = new List<SelectListItem>();

            foreach (var StatusFromDb in _OrganizationStatus.GetAllOrganizationStatus())
            {
                StatusList.Add(new SelectListItem
                {
                    Text = StatusFromDb.OrganizationStatusName,
                    Value = StatusFromDb.Id.ToString()
                });
            }

            //wwwwwwwwwwwwwwwwwwwwwwwwww
            var test1 = (from o in _organizationType.GetAllOrganizationTypes()
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
            foreach (var TypeFromDb in test1)
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
                NullId = ParentOrganization == null ? 0:ParentOrganization.Id
            };
            var OrganizationAndStatus = new SuObjectAndStatusViewModel { SuObject=  Parent , SomeKindINumSelectListItem = StatusList, ProbablyTypeListItem = TypeList };
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
                if(FromForm.SuObject.NullId != 0)
                { Organization.ParentOrganizationId = FromForm.SuObject.NullId; }
                var NewOrganization = _Organization.AddOrganization(Organization);


                var CurrentUser = await userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
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
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var test1 = (from s in _Organization.GetAllOrganizations()
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
                    Text = OrganizationFromDb.OrganizationStatusName,
                    Value = OrganizationFromDb.Id.ToString()
                });
            }
            var OrganizationAndStatus = new SuObjectAndStatusViewModel { SuObject = test1, SomeKindINumSelectListItem = OrganizationList };
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

                var DefaultLanguageID = CurrentUser.DefaultLangauge;
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


        public IActionResult LanguageIndex(int Id)
        {

            var ContentLanguage = (from c in _OrganizationLanguage.GetAllOrganizationLanguages()
                                   join l in _language.GetAllLanguages()
                  on c.LanguageId equals l.Id
                                   where c.OrganizationId == Id
                                   select new SuObjectVM
                                   {
                                       Id = c.Id
                                   ,
                                       Name = c.Name
                                   ,
                                       Language = l.LanguageName
                                   ,
                                       Description = c.Description
                                   ,
                                       MouseOver = c.MouseOver
                                   ,
                                       ObjectId = c.OrganizationId
                                   }).ToList();
            ViewBag.Id = Id;

            return View(ContentLanguage);
        }

        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
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
        public IActionResult LanguageEdit(int Id)
        {
            var test1 = (from c in _OrganizationLanguage.GetAllOrganizationLanguages()
                         join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                         where c.Id == Id
                         select new SuObjectVM
                         {
                             Id = c.Id
                            ,
                             Name = c.Name
                            ,
                             Description = c.Description
                            ,
                             MouseOver = c.MouseOver
                            ,
                             Language = l.LanguageName
                            ,
                             ObjectId = c.OrganizationId

                         }).First();

            var OrganizationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = test1 //, a = OrganizationList
            };
            return View(test1);


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

    }
}
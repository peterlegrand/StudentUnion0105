using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class ClassificationPageSectionController : PortalController
    {
        private readonly IClassificationPageSectionLanguageRepository _classificationPageSectionLanguage;
        
        public ClassificationPageSectionController(UserManager<SuUserModel> userManager
            , IClassificationPageSectionLanguageRepository classificationPageSectionLanguage
            , ILanguageRepository language
            , SuDbContext context
            ) : base(userManager, language, context)
        {
            _classificationPageSectionLanguage = classificationPageSectionLanguage;
        }

        public async Task<IActionResult> Index(int Id)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            

            base.Initializing();

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@Id", Id)
                };
            var ClassificationPage = _context.ZdbObjectIndexGet.FromSql("ClassificationPageSectionIndexGet @Id, @LanguageId", parameters).ToList();
           //PETER Why do I need this viewbag
            ViewBag.PId = Id;
            return View(ClassificationPage);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            

            base.Initializing();

            SqlParameter[] parameters =
    {
                            new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                            , new SqlParameter("@OId", Id)
                        };

            SuClassificationPageSectionEditGetModel ClassificationPageSectionEditGet = _context.ZdbClassificationPageSectionEditGet.FromSql("ClassificationPageSectionEditGet @LanguageId, @OId", parameters).First();

            var ContentTypeList = new List<SelectListItem>();
            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);
            var ContentTypesFromDb = _context.ZDbTypeList.FromSql("ContentTypeSelectAllForLanguage @LanguageId", parameter).ToList();
            foreach (var ContentTypeFromDb in ContentTypesFromDb)
            {
                ContentTypeList.Add(new SelectListItem
                {
                    Text = ContentTypeFromDb.Name,
                    Value = ContentTypeFromDb.Id.ToString()
                });
            }

            var PageSectionTypeList = new List<SelectListItem>();
            var PageSectionTypesFromDb = _context.ZDbStatusList.FromSql("PageSectionTypeSelectAllForLanguage @LanguageId", parameter).ToList();
            foreach (var PageSectionTypeFromDb in PageSectionTypesFromDb)
            {
                PageSectionTypeList.Add(new SelectListItem
                {
                    Text = PageSectionTypeFromDb.Name,
                    Value = PageSectionTypeFromDb.Id.ToString()
                });
            }

            SuClassificationPageSectionEditGetWithListModel ClassificationPageSectionWithList = new SuClassificationPageSectionEditGetWithListModel
            {
                ClassificationPageSection = ClassificationPageSectionEditGet
                , ContentTypeList = ContentTypeList
                , SectionTypeList = PageSectionTypeList
            };
            return View(ClassificationPageSectionWithList);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuClassificationPageSectionEditGetWithListModel FromForm)
        {
                SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
                SqlParameter[] parameters =
                    {
                        new SqlParameter("@OId", FromForm.ClassificationPageSection.OId),
                        new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId),
                        new SqlParameter("@Sequence", FromForm.ClassificationPageSection.Sequence),
                        new SqlParameter("@SectionTypeId", FromForm.ClassificationPageSection.SectionTypeId),
                        new SqlParameter("@ShowSectionTitleName", FromForm.ClassificationPageSection.ShowSectionTitleName),
                        new SqlParameter("@ShowSectionTitleDescription", FromForm.ClassificationPageSection.ShowSectionTitleDescription),
                        new SqlParameter("@ShowContentTypeTitleName", FromForm.ClassificationPageSection.ShowContentTypeTitleName),
                        new SqlParameter("@ShowContentTypeTitleDescription", FromForm.ClassificationPageSection.ShowContentTypeTitleDescription),
                        new SqlParameter("@OneTwoColumns", FromForm.ClassificationPageSection.OneTwoColumns),
                        new SqlParameter("@ContentTypeId", FromForm.ClassificationPageSection.ContentTypeId),
                        new SqlParameter("@SortById", FromForm.ClassificationPageSection.SortById),
                        new SqlParameter("@MaxContent", FromForm.ClassificationPageSection.MaxContent),
                        new SqlParameter("@HasPaging", FromForm.ClassificationPageSection.HasPaging),
                        new SqlParameter("@ModifierId", CurrentUser.Id),
                        new SqlParameter("@Name", FromForm.ClassificationPageSection.Name),
                        new SqlParameter("@Description", FromForm.ClassificationPageSection.Description),
                        new SqlParameter("@MouseOver", FromForm.ClassificationPageSection.MouseOver),
                        new SqlParameter("@MenuName", FromForm.ClassificationPageSection.MenuName),
                        new SqlParameter("@TitleName", FromForm.ClassificationPageSection.TitleName),
                        new SqlParameter("@TitleDescription", FromForm.ClassificationPageSection.TitleDescription)
                        };
                _context.Database.ExecuteSqlCommand("ClassificationPageSectionEditPost " +
                            "@OId" +
                            ", @LanguageId" +
                            ", @Sequence" +
                            ", @SectionTypeId" +
                            ", @ShowSectionTitleName" +
                            ", @ShowSectionTitleDescription" +
                            ", @ShowContentTypeTitleName" +
                            ", @ShowContentTypeTitleDescription" +
                            ", @OneTwoColumns" +
                            ", @ContentTypeId" +
                            ", @SortById" +
                            ", @MaxContent" +
                            ", @HasPaging" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName" +
                            ", @TitleName" +
                            ", @TitleDescription", parameters);
            return RedirectToAction("Index", new { Id = FromForm.ClassificationPageSection.PId });
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            

            base.Initializing();

            var ContentTypeList = new List<SelectListItem>();
            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);
            var ContentTypesFromDb = _context.ZDbTypeList.FromSql("ContentTypeSelectAllForLanguage @LanguageId", parameter).ToList();
            foreach (var ContentTypeFromDb in ContentTypesFromDb)
            {
                ContentTypeList.Add(new SelectListItem
                {
                    Text = ContentTypeFromDb.Name,
                    Value = ContentTypeFromDb.Id.ToString()
                });
            }

            var PageSectionTypeList = new List<SelectListItem>();
            var PageSectionTypesFromDb = _context.ZDbStatusList.FromSql("PageSectionTypeSelectAllForLanguage @LanguageId", parameter).ToList();
            foreach (var PageSectionTypeFromDb in PageSectionTypesFromDb)
            {
                PageSectionTypeList.Add(new SelectListItem
                {
                    Text = PageSectionTypeFromDb.Name,
                    Value = PageSectionTypeFromDb.Id.ToString()
                });
            }

            SuClassificationPageSectionEditGetModel ClassificationPageSection = new SuClassificationPageSectionEditGetModel
            {
                PId = Id
            };
            SuClassificationPageSectionEditGetWithListModel ClassificationPageSectionWithStatusList = new SuClassificationPageSectionEditGetWithListModel {  ClassificationPageSection = ClassificationPageSection
                ,
                ContentTypeList = ContentTypeList
                ,
                SectionTypeList = PageSectionTypeList
            };
            return View(ClassificationPageSectionWithStatusList);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuClassificationPageSectionEditGetWithListModel FromForm)
        {
                var CurrentUser = await _userManager.GetUserAsync(User);
    

                SqlParameter[] parameters =
                    {
                        new SqlParameter("@PId", FromForm.ClassificationPageSection.PId)
                        , new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                        , new SqlParameter("@Sequence", FromForm.ClassificationPageSection.Sequence)
                        , new SqlParameter("@SectionTypeId", FromForm.ClassificationPageSection.SectionTypeId)
                        , new SqlParameter("@ShowSectionTitleName", FromForm.ClassificationPageSection.ShowSectionTitleName)
                        , new SqlParameter("@ShowSectionTitleDescription", FromForm.ClassificationPageSection.ShowSectionTitleDescription)
                        , new SqlParameter("@ShowContentTypeTitleName", FromForm.ClassificationPageSection.ShowContentTypeTitleName)
                        , new SqlParameter("@ShowContentTypeTitleDescription", FromForm.ClassificationPageSection.ShowContentTypeTitleDescription)
                        , new SqlParameter("@OneTwoColumns", FromForm.ClassificationPageSection.OneTwoColumns)
                        , new SqlParameter("@ContentTypeId", FromForm.ClassificationPageSection.ContentTypeId)
                        , new SqlParameter("@SortById", FromForm.ClassificationPageSection.SortById)
                        , new SqlParameter("@MaxContent", FromForm.ClassificationPageSection.MaxContent)
                        , new SqlParameter("@HasPaging", FromForm.ClassificationPageSection.HasPaging)
                        , new SqlParameter("@ModifierId", CurrentUser.Id)
                        , new SqlParameter("@Name", FromForm.ClassificationPageSection.Name)
                        , new SqlParameter("@Description", FromForm.ClassificationPageSection.Description)
                        , new SqlParameter("@MouseOver", FromForm.ClassificationPageSection.MouseOver)
                        , new SqlParameter("@MenuName", FromForm.ClassificationPageSection.MenuName)
                        , new SqlParameter("@TitleName", FromForm.ClassificationPageSection.TitleName)
                        , new SqlParameter("@TitleDescription", FromForm.ClassificationPageSection.TitleDescription)
                        };

                _context.Database.ExecuteSqlCommand("ClassificationPageSectionCreatePost " +
                           "@PId" +
                           ", @LanguageId" +
                           ", @Sequence" +
                           ", @SectionTypeId" +
                           ", @ShowSectionTitleName" +
                           ", @ShowSectionTitleDescription" +
                           ", @ShowContentTypeTitleName" +
                           ", @ShowContentTypeTitleDescription" +
                           ", @OneTwoColumns" +
                           ", @ContentTypeId" +
                           ", @SortById" +
                           ", @MaxContent" +
                           ", @HasPaging" +
                           ", @ModifierId" +
                           ", @Name" +
                           ", @Description" +
                           ", @MouseOver" +
                           ", @MenuName" +
                           ", @TitleName" +
                           ", @TitleDescription", parameters);
            return RedirectToAction("Index", new { Id = FromForm.ClassificationPageSection.PId.ToString() });
        }

        public IActionResult LanguageIndex(int Id)
        {
            
            base.Initializing();

            SqlParameter parameter = new SqlParameter("@OId", Id);

            List<SuObjectLanguageIndexGetModel> LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ClassificationPageSectionLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);
        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
          
            base.Initializing();

            SqlParameter parameter = new SqlParameter("@LId", Id);

            SuClassificationPageSectionLanguageEditGetModel ObjectLanguage = _context.ZdbClassificationPageSectionLanguageEditGet.FromSql("ClassificationPageSectionLanguageEditGet @LId", parameter).First();
            return View(ObjectLanguage);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageEdit(SuClassificationPageLanguageEditGetModel FromForm)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            

            base.Initializing();
         
            SqlParameter[] parameters =
                    {
                        new SqlParameter("@LId", FromForm.LId),
                        new SqlParameter("@ModifierId", CurrentUser.Id),
                        new SqlParameter("@Name", FromForm.Name),
                        new SqlParameter("@Description", FromForm.Description),
                        new SqlParameter("@MouseOver", FromForm.MouseOver),
                        new SqlParameter("@MenuName", FromForm.MenuName),
                        new SqlParameter("@TitleName", FromForm.TitleName),
                        new SqlParameter("@titleDescription", FromForm.TitleDescription)
                        };

                _context.Database.ExecuteSqlCommand("ClassificationPageSectionLanguageEditPost " +
                           "@LId" +
                           ", @ModifierId" +
                           ", @Name" +
                           ", @Description" +
                           ", @MouseOver" +
                           ", @MenuName" +
                           ", @TitleName" +
                           ", @TitleDescription", parameters);
                return RedirectToAction("LanguageIndex", new { Id = FromForm.OId.ToString() });
        }

        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
          
            base.Initializing();

            AvailableObjectLanguages AvailableLanguages = new AvailableObjectLanguages(_context);
            var SuLanguage = AvailableLanguages.ReturnFreeLanguages(this.ControllerContext.RouteData.Values["controller"].ToString(), Id);
            Int32 NoOfLanguages = SuLanguage.Count();
            if (NoOfLanguages == 0)
            { return RedirectToAction("LanguageIndex", new { Id }); }
            SuClassificationPageSectionLanguageCreateGetModel SuObject = new SuClassificationPageSectionLanguageCreateGetModel
            {
                OId = Id
            };
            ViewBag.Id = Id.ToString();
            SuClassificationPageSectionLanguageCreateGetWithListModel ClassificationPageSectionAndLanguages = new SuClassificationPageSectionLanguageCreateGetWithListModel
            {
                ObjectLanguage = SuObject
                ,
                LanguageList = SuLanguage
            };
            return View(ClassificationPageSectionAndLanguages);
        }

        [HttpPost]
        public async Task<IActionResult> LanguageCreate(SuClassificationPageLanguageCreateGetWithListModel FromForm)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);


            SqlParameter[] parameters =
                {
                        new SqlParameter("@OId", FromForm.ObjectLanguage.OId),
                        new SqlParameter("@LanguageId", FromForm.ObjectLanguage.LanguageId),
                        new SqlParameter("@Name", FromForm.ObjectLanguage.Name ?? ""),
                        new SqlParameter("@Description", FromForm.ObjectLanguage.Description ?? ""),
                        new SqlParameter("@MouseOver", FromForm.ObjectLanguage.MouseOver ?? ""),
                        new SqlParameter("@MenuName", FromForm.ObjectLanguage.MenuName ?? ""),
                        new SqlParameter("@TitleName", FromForm.ObjectLanguage.TitleName ?? ""),
                        new SqlParameter("@TitleDescription", FromForm.ObjectLanguage.TitleDescription ?? ""),
                        new SqlParameter("@ModifierId", CurrentUser.Id)
                        };

            _context.Database.ExecuteSqlCommand("ClassificationPageSectionLanguageCreatePost " +
                       "@OId" +
                       ", @LanguageId" +
                       ", @Name" +
                       ", @Description" +
                       ", @MouseOver" +
                       ", @MenuName" +
                       ", @TitleName" +
                       ", @TitleDescription" +
                       ", @ModifierId", parameters);
            return RedirectToAction("LanguageIndex", new { Id = FromForm.ObjectLanguage.OId.ToString() });
        }

        [HttpGet]
        public IActionResult LanguageDelete(int Id)
        {
             base.Initializing();

            SqlParameter parameter = new SqlParameter("@LId", Id);
            SuClassificationPageSectionLanguageEditGetModel ClassificationPageSectionLanguage = _context.ZdbClassificationPageSectionLanguageEditGet.FromSql("ClassificationPageSectionLanguageEditGet @LId", parameter).First();

            return View(ClassificationPageSectionLanguage);
        }

        [HttpPost]
        public IActionResult LanguageDelete(SuObjectLanguageEditGetModel FromForm)
        {
            _classificationPageSectionLanguage.DeleteClassificationPageSectionLanguage(FromForm.LId);
            return RedirectToAction("LanguageIndex", new { Id = FromForm.OId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            SuUserModel CurrentUser = await _userManager.GetUserAsync(User);
            

            base.Initializing();

            SqlParameter[] parameters =
                {
                            new SqlParameter("@OId", Id)
                            , new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                        };

            SuClassificationPageSectionDeleteGetModel ClassificationPageSection = _context.ZdbClassificationPageSectionDeleteGet.FromSql("ClassificationPageSectionDeleteGet @OId, @LanguageId", parameters).First();

            return View(ClassificationPageSection);
        }

        [HttpPost]
        public IActionResult Delete(SuClassificationPageDeleteGetModel FromForm)
        {

            var parameter = new SqlParameter("@OId", FromForm.OId);
            _context.Database.ExecuteSqlCommand("ClassificationPageSectionDeletePost @OId", parameter);

            return RedirectToAction("Index", new { Id = FromForm.PId });
        }

    }

}
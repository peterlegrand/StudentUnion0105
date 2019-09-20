using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Models.ViewModels;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;


namespace StudentUnion0105.Controllers
{
    public class ContentController : Controller
    {
        // private readonly SuContentModel _contentModel;
        private readonly UserManager<SuUser> _userManager;
        private readonly IContentStatusRepository _contentStatus;
        private SuDbContext _context;
        private readonly IClassificationRepository _classification;

        //      private readonly SuContentModel _content;

        public ContentController(
            //SuContentModel contentModel
            //, 
            UserManager<SuUser> userManager
            , IContentStatusRepository contentStatus
           , SuDbContext context
            , IClassificationRepository classification
            //            , SuContentModel content
            )//, IContentTypeLanguageRepository)
        {
            //  _contentModel = contentModel;
            _userManager = userManager;
            _contentStatus = contentStatus;
            _context = context;
            _classification = classification;
            //        _content = content;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var StatusList = new List<SelectListItem>();
            var TypeList = new List<SelectListItem>();
            var OrganizationList = new List<SelectListItem>();
            var ProjectList = new List<SelectListItem>();
            var SecurityLevelList = new List<SelectListItem>();
            var LanguageList = new List<SelectListItem>();
            int NoOfClassifications = _classification.GetAllClassifcations().Count();

            List<SelectListItem>[] ClassificationValueSets = new List<SelectListItem>[NoOfClassifications];
            DbSet<SuValueList>[] dbValueList = new DbSet<SuValueList>[NoOfClassifications];
            int y = 0;

            foreach (var ClassificationfromDb in _classification.GetAllClassifcations())
            {
                List<SuValueList> ValuesFromDb = new List<SuValueList>();
                // dbValueList[y] = new DbSet<SuValueList>();
                //ValuesFromDb.Add(new SuValueList { ClassificationValueId = 1, ClassificationValueName = "a" });
                //ValuesFromDb.Add(new SuValueList { ClassificationValueId = 2, ClassificationValueName = "b" });
                //                _context.dbValueList[0] = new DbSet<SuValueList>;
                ValuesFromDb = _context.dbValueList.FromSql($"ClassificationValueStructureValues  {DefaultLanguageID}, {ClassificationfromDb.Id}").ToList();
                ClassificationValueSets[y] = new List<SelectListItem>();
                ClassificationValueSets[y].Add(new SelectListItem

                {
                    Text = "-- no selection --",
                    Value = "0"
                });
                foreach (var ValueFromDb in ValuesFromDb)
                {

                    ClassificationValueSets[y].Add(new SelectListItem

                    {
                        Text = ValueFromDb.ClassificationValueName,
                        Value = ValueFromDb.ClassificationValueId.ToString()
                    });
                }
                y++;
            }

            var ContentStatusFromDb = _context.dbStatusList.FromSql($"GetContentStatus").ToList();


            foreach (var StatusFromDb in ContentStatusFromDb)
            {
                StatusList.Add(new SelectListItem
                {
                    Text = StatusFromDb.Name,
                    Value = StatusFromDb.Id.ToString()
                });
            }
            var ContentTypesFromDb = _context.dbTypeList.FromSql($"GetContentType {DefaultLanguageID}").ToList();

            foreach (var TypeFromDb in ContentTypesFromDb)
            {
                TypeList.Add(new SelectListItem
                {
                    Text = TypeFromDb.Name,
                    Value = TypeFromDb.Id.ToString()
                });
            }

            var OrganizationsFromDb = _context.dbGetOrganizationStructure.FromSql($"OrgStructure {DefaultLanguageID}").ToList();

            foreach (var OrganizationFromDb in OrganizationsFromDb)
            {
                OrganizationList.Add(new SelectListItem
                {
                    Text = OrganizationFromDb.Name,
                    Value = OrganizationFromDb.Id.ToString()
                });
            }

            var ProjectsFromDb = _context.dbGetProjectStructure.FromSql($"ProjStructure {DefaultLanguageID}").ToList();

            ProjectList.Add(new SelectListItem { Value = "0", Text = "No project" });
            foreach (var ProjectFromDb in ProjectsFromDb)
            {
                ProjectList.Add(new SelectListItem
                {
                    Text = ProjectFromDb.Name,
                    Value = ProjectFromDb.Id.ToString()
                });
            }


            var SecurityLevelsFromDb = _context.dbSecurityLevelList.FromSql($"GetSecurityLevel").ToList();

            foreach (var SecurityLevelFromDb in SecurityLevelsFromDb)
            {
                SecurityLevelList.Add(new SelectListItem
                {
                    Text = SecurityLevelFromDb.Name,
                    Value = SecurityLevelFromDb.Id.ToString()
                });
            }

            var LanguagesFromDb = _context.dbLanguageList.FromSql($"GetLanguage").ToList();

            foreach (var LanguageFromDb in LanguagesFromDb)
            {
                LanguageList.Add(new SelectListItem
                {
                    Text = LanguageFromDb.Name,
                    Value = LanguageFromDb.Id.ToString()
                });
            }


            SuContentModel content = new SuContentModel();
            content.LanguageId = DefaultLanguageID;
            int?[] SelectedValues = new int?[NoOfClassifications];
            SuCreateContentModel ContentWithDropDowns = new SuCreateContentModel
            {
                Content = content
                ,
                ContentType = TypeList
                ,
                ContentStatus = StatusList
                ,
                SecurityLevel = SecurityLevelList
                ,
                Langauge = LanguageList
                ,
                Organization = OrganizationList
                ,
                Project = ProjectList
                ,
                Values = ClassificationValueSets
                ,
                NoOfClassifications = NoOfClassifications
                ,
                SelectedValues = SelectedValues
            };
            return View(ContentWithDropDowns);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SuCreateContentModel FromForm)
        {

            var ProjectId = FromForm.Content.ProjectId == null ? 0 : FromForm.Content.ProjectId;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ContentTypeId", FromForm.Content.ContentTypeId),
                new SqlParameter("@ContentStatusId", FromForm.Content.ContentStatusId),
                new SqlParameter("@LangaugeId", FromForm.Content.LanguageId),
                new SqlParameter("@Title", FromForm.Content.Title),
                new SqlParameter("@Description", FromForm.Content.Description),
                new SqlParameter("@SecurityLevel", FromForm.Content.SecurityLevel),
                new SqlParameter("@OrganizationId", FromForm.Content.OrganizationId),
                new SqlParameter("@ProjectId", ProjectId),
                new SqlParameter
                {
                    ParameterName = "@new_identity",
                    SqlDbType = SqlDbType.Int
                    , Direction = ParameterDirection.Output
                }
            };

            var b = _context.Database.ExecuteSqlCommand("ContentCreate @ContentTypeId, @ContentStatusId, @LangaugeId, @Title, @Description, @SecurityLevel, @OrganizationId, @ProjectId, @new_identity OUTPUT", parameters);

            if (FromForm.NoOfClassifications != null)
            {

                //    
                foreach (var x in FromForm.SelectedValues)
                {
                    //                    SqlParameter[] parameters2 = new SqlParameter[2];
                    if (x.Value != 0)
                    {
                        SqlParameter[] parameters2 =
                    {
                new SqlParameter("@ContentId", parameters[8].Value),
                new SqlParameter("@ClassificationValueId", x.Value)
                        };
            var c = _context.Database.ExecuteSqlCommand("ContentValueCreate @ContentId, @ClassificationValueId", parameters2);

                    }
                }
            }



            return RedirectToRoute(new
            {
                controller = "Home",
                action = "Index"
            });

        }
    }
}
using Microsoft.AspNetCore.Authorization;
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
    public class FrontProcessController : Controller
    {
        private readonly UserManager<SuUserModel> userManager;
        private readonly IClassificationStatusRepository _classificationStatus;
        private readonly IClassificationRepository _classification;
        private readonly IClassificationLanguageRepository _classificationLanguage;
        private readonly ILanguageRepository _language;
        private readonly SuDbContext _context;


        public FrontProcessController(UserManager<SuUserModel> userManager
                                                , IClassificationStatusRepository classificationStatus
                                                , IClassificationRepository classification
                                                , IClassificationLanguageRepository classificationLanguage
                                                , ILanguageRepository language
                                                , SuDbContext context
            )
        {
            this.userManager = userManager;
            _classificationStatus = classificationStatus;
            _classification = classification;
            _classificationLanguage = classificationLanguage;
            _language = language;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameterPage = new SqlParameter("@LanguageId", DefaultLanguageID);


            List<SuFrontProcessIndexGetTemplateGroupModel> FrontProcessTemplateGroups = _context.ZdbFrontProcessIndexGetTemplateGroup.FromSql("FrontProcessIndexGetTemplateGroup @LanguageId", parameterPage).ToList();
            
                foreach( var ProcessTemplateGroup in FrontProcessTemplateGroups)
            { 
            SqlParameter[] parameterTemplate =
                {
                    new SqlParameter("@LanguageId", DefaultLanguageID.ToString())
                    , new SqlParameter("@PId", ProcessTemplateGroup.OId.ToString())
                };
                List<SuFrontProcessIndexGetTemplateModel> FrontProcessTemplates = 
                        _context.ZdbFrontProcessIndexGetTemplate.FromSql("FrontProcessIndexGetTemplate " +
                        "@LanguageId" +
                        ", @PId" 
                        , parameterTemplate).ToList();
                List<SuFrontProcessIndexGetTemplateModel> TemplatesWithRights = new List<SuFrontProcessIndexGetTemplateModel>();

                foreach (var template in FrontProcessTemplates)
                {
                    var parameterFlow = new SqlParameter("@PId", template.OId.ToString());
                    List<SuFrontProcessIndexGetTemplateFlowConditionModel> FrontProcessTemplateFlowConditions =
                            _context.ZdbFrontProcessIndexGetTemplateFlowCondition.FromSql("FrontProcessIndexGetTemplateFlowCondition @PId"
                            , parameterFlow).ToList();

                    List<SqlParameter> parameterList = new List<SqlParameter>();
                    string DynamicSQL;
                    if (FrontProcessTemplateFlowConditions.Count > 0 )
                    { 
                    DynamicSQL = "SELECT COUNT(*) Id, 'Name' Name FROM AspNetUsers Users LEFT JOIN AspNetUserRoles ON Users.Id = AspNetUserRoles.UserId LEFT JOIN AspNetRoles ON AspNetRoles.Id = AspNetUserRoles.RoleId WHERE Users.Id = '" + CurrentUser.Id + "' AND ";
                    }
                    else
                    {
                        DynamicSQL = "SELECT COUNT(*) Id, 'Name' Name FROM AspNetUsers Users LEFT JOIN AspNetUserRoles ON Users.Id = AspNetUserRoles.UserId LEFT JOIN AspNetRoles ON AspNetRoles.Id = AspNetUserRoles.RoleId WHERE 1=2 ";
                    
                    }
                    foreach (var FrontProcessTemplateFlowCondition in FrontProcessTemplateFlowConditions)
                    {
                        switch (FrontProcessTemplateFlowCondition.ConditionTypeId)
                        {
                            case 3:  //Security level user
                                DynamicSQL += " Users.SecurityLevel ";
                                parameterList.Add(new SqlParameter("@P" + FrontProcessTemplateFlowCondition.OId.ToString(), FrontProcessTemplateFlowCondition.ConditionInt.ToString()));
                                    switch (FrontProcessTemplateFlowCondition.ComparisonOperatorId)
                                {
                                    case 1: //Equal
                                        DynamicSQL += "= ";
                                        break;

                                    case 2: //Larger
                                        DynamicSQL += "> ";
                                        break;

                                    case 3: //Smaller
                                        DynamicSQL += "< ";
                                        break;

                                    case 4: //Larger or equal
                                        DynamicSQL += ">= ";
                                        break;

                                    case 5: //Smaller or equal
                                        DynamicSQL += "<= ";
                                        break;

                                    case 6: //Not equal
                                        DynamicSQL += "!= ";
                                        break;
                                }
                                DynamicSQL = DynamicSQL + "@P" + FrontProcessTemplateFlowCondition.OId.ToString() + " ";
                                break;
                            case 4:  //Role user
                                DynamicSQL += " AspNetRoles.Name ";
                                parameterList.Add(new SqlParameter("@P" + FrontProcessTemplateFlowCondition.OId.ToString(), FrontProcessTemplateFlowCondition.ConditionString));
                                switch (FrontProcessTemplateFlowCondition.ComparisonOperatorId)
                                {
                                    case 1: //Equal
                                        DynamicSQL += "= ";
                                        break;
                                }
                                DynamicSQL = DynamicSQL + "@P" + FrontProcessTemplateFlowCondition.OId.ToString() + " ";
                                break;
                            case 9:  //open bracket
                                DynamicSQL += " ( ";
                                break;
                            case 10:  //AND
                                DynamicSQL += " AND ";
                                break;
                            case 11:  //OR
                                DynamicSQL += " OR ";
                                break;
                            case 12:  //Closed bracket
                                DynamicSQL += " ) ";
                                break;
                        }

                    }
                    try
                    { 
                    SuStatusList HasRights = _context.DbStatusList.FromSql(DynamicSQL, parameterList.ToArray()).First();
                        if (HasRights.Id != 0)
                        {
                            TemplatesWithRights.Add(template);

                        }
                    }
                    catch (SqlException e)
                    {
                        return View(FrontProcessTemplateGroups);

                    }

                }

                ProcessTemplateGroup.FrontProcessTemplates = TemplatesWithRights;

            }
            return View(FrontProcessTemplateGroups);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            var parameterPage = new SqlParameter("@LanguageId", DefaultLanguageID);


            SuFrontProcessCreateGetModel FrontProcess = _context.ZdbFrontProcessCreateGet.FromSql("FrontProcessCreateGet @LanguageId", parameterPage).First();

            SqlParameter[] FieldParameter =
                {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@PId", Id)
                };


            List<SuFrontProcessCreateGetFieldModel> FrontProcessFields = _context.ZdbFrontProcessCreateGetField.FromSql("FrontProcessCreateGetField @LanguageId, @PId", FieldParameter).ToList();

            FrontProcess.ProcessFields = FrontProcessFields;

            return View(FrontProcess);
        }

        public ActionResult CountryDD()
        {
            var CountryList = new List<SelectListItem>();

            var CountriesFromDb = _context.DbStatusList.FromSql($"CountryDD").ToList();


            foreach (var CountryFromDb in CountriesFromDb)
            {
                CountryList.Add(new SelectListItem
                {
                    Text = CountryFromDb.Name,
                    Value = CountryFromDb.Id.ToString()
                });
            }
            return View();

        }

    }
}

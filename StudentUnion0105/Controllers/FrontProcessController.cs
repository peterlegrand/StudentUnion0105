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
    public class FrontProcessController : PortalController
    {
        private readonly SuDbContext _context;

        public FrontProcessController(UserManager<SuUserModel> userManager
                                                , ILanguageRepository language
                                                , SuDbContext context
            ) : base(userManager, language)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            // MenusEtc.Initializing();

            var parameterPage = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);


            List<SuFrontProcessIndexGetTemplateGroupModel> FrontProcessTemplateGroups = _context.ZdbFrontProcessIndexGetTemplateGroup.FromSql("FrontProcessIndexGetTemplateGroup @LanguageId", parameterPage).ToList();
            
                foreach( var ProcessTemplateGroup in FrontProcessTemplateGroups)
            { 
            SqlParameter[] parameterTemplate =
                {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@PId", ProcessTemplateGroup.OId)
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
                    SuStatusList HasRights = _context.ZDbStatusList.FromSql(DynamicSQL, parameterList.ToArray()).First();
                        if (HasRights.Id != 0)
                        {
                            TemplatesWithRights.Add(template);

                        }
                    }
                    catch (SqlException )
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
            var CurrentUser = await _userManager.GetUserAsync(User);



            // MenusEtc.Initializing();

            var parameterPage = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);


            SuFrontProcessCreateGetModel FrontProcess = _context.ZdbFrontProcessCreateGet.FromSql("FrontProcessCreateGet @LanguageId", parameterPage).First();

            SqlParameter[] FieldParameter =
                {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@PId", Id)
                };


            List<SuFrontProcessCreateGetFieldModel> FrontProcessFields = _context.ZdbFrontProcessCreateGetField.FromSql("FrontProcessCreateGetField @LanguageId, @PId", FieldParameter).ToList();

            FrontProcess.ProcessFields = FrontProcessFields;

            return View(FrontProcess);
        }

       

    }
}

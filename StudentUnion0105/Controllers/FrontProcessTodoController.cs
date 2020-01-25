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
    public class FrontProcessTodoController : PortalController
    {
        public FrontProcessTodoController(UserManager<SuUserModel> userManager
                                                , ILanguageRepository language
                                                , SuDbContext context
            ) : base(userManager, language, context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@CurrentUser", CurrentUser.Id)
                };

            var ToDo = _context.ZdbSuFrontProcessTodoIndexGet.FromSql("FrontProcessToDoIndexGet @LanguageId, @CurrentUser", parameters).ToList();
            return View(ToDo);
        }

        //PETER this should get the whole condition structure.
        [HttpGet]
        public async Task<IActionResult> Index2()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();

            var FlowIds = _context.ZdbInt.FromSql("FrontProcessToDoIndex2GetFlowId").ToList();
            var AndOrList = _context.ZdbFrontProcessToDoIndex2GetForAndOr.FromSql("FrontProcessToDoIndex2GetForAndOr").ToList();
//            int OldFlowId = 0;
            string FromStringStart = "SELECT DbProcess.Id , DbProcessTemplateLanguage.Name , dbprocess.CreatedDate " +
                " FROM DbProcess " +
                "JOIN DbProcessTemplateFlow " +
                "   ON DbProcess.ProcessTemplateId = DbProcessTemplateFlow.ProcessTemplateId " +
                "   AND DbProcess.StepId = DbProcessTemplateFlow.ProcessTemplateFromStepId " +
                "JOIN DbProcessTemplateFlowCondition " +
                "   ON DbProcessTemplateFlow.Id = DbProcessTemplateFlowCondition.ProcessTemplateFlowId " +
                "LEFT JOIN DbComparison " +
                "   ON DbProcessTemplateFlowCondition.ComparisonOperatorId = DbComparison.Id " +
                "JOIN DbProcessTemplateLanguage " +
                "   ON DbProcess.ProcessTemplateId = DbProcessTemplateLanguage.ProcessTemplateId ";

            string WhereStringStart = " WHERE StepId <> 0 AND ";
            string WhereString = "";
            string FromString = "";
            //string FullSQLFrom = "";
            //string FullSQLWhere = "";
            string FullSQL = "";
            bool FirstRecord = true;

            foreach (var FlowId in FlowIds)
            {

                FromString = FromStringStart;
                WhereString = WhereStringStart + " DbProcessTemplateFlow.ID = " + FlowId.intValue;// + " AND ";

                if (AndOrList.Where(AndOr => AndOr.FlowId == FlowId.intValue).Count() > 0)
                    WhereString += " AND ";

                foreach (var AndOr in AndOrList.Where(AndOr => AndOr.FlowId == FlowId.intValue))
            {
                switch (AndOr.ConditionTypeId)
                {
                    case 1:
                        WhereString = WhereString + " DbProcessTemplateField AS TemplateField" + AndOr.ConditionId.ToString() + ".Id = " + AndOr.ConditionFieldId.ToString();

                        FromString = FromString + " JOIN DbProcessTemplateField TemplateField" + AndOr.ConditionId.ToString() + " ON DbProcessTemplateFlow.ProcessTemplateId = TemplateField" + AndOr.ConditionId.ToString() + ".ProcessTemplateId ";
                        FromString = FromString + " JOIN DbProcessField Field" + AndOr.ConditionId.ToString() + " ON Field" + AndOr.ConditionId.ToString() + ".ProcessTemplateFieldId = TemplateField" + AndOr.ConditionId.ToString() + ".Id";
                        FromString = FromString + " AND Field" + AndOr.ConditionId.ToString() + ".ProcessId = DbProcess.Id";
                        break;
                    case 2:
                        WhereString = WhereString + " DbProcess.CreatorId = '" + CurrentUser.Id.ToString() + "' " ;
                        break;
                    case 3:
                        FromString = FromString + " JOIN DbProcessTemplateField TemplateField" + AndOr.ConditionId.ToString() + " ON DbProcessTemplateFlow.ProcessTemplateId = TemplateField" + AndOr.ConditionId.ToString() + ".ProcessTemplateId ";
                        FromString = FromString + " JOIN DbProcessField Field" + AndOr.ConditionId.ToString() + " ON Field" + AndOr.ConditionId.ToString() + ".ProcessTemplateFieldId = TemplateField" + AndOr.ConditionId.ToString() + ".Id";
                        FromString = FromString + " AND Field" + AndOr.ConditionId.ToString() + ".ProcessId = DbProcess.Id ";
                        FromString = FromString + " JOIN AspNetUsers User" + AndOr.ConditionId.ToString() + " ON User" + AndOr.ConditionId.ToString() + ".Id = Field" + AndOr.ConditionId.ToString() + ".StringValue ";

                        WhereString = WhereString + " DbProcessTemplateFlowCondition.ProcessTemplateFlowConditionInt <= " + CurrentUser.SecurityLevel.ToString() + " ";
                        break;
                    case 4:

                        FromString = FromString + " JOIN DbProcessTemplateField TemplateField" + AndOr.ConditionId.ToString() + " ON DbProcessTemplateFlow.ProcessTemplateId = TemplateField" + AndOr.ConditionId.ToString() + ".ProcessTemplateId ";
                        FromString = FromString + " JOIN DbProcessField Field" + AndOr.ConditionId.ToString() + " ON Field" + AndOr.ConditionId.ToString() + ".ProcessTemplateFieldId = TemplateField" + AndOr.ConditionId.ToString() + ".Id ";
                        FromString = FromString + " AND Field" + AndOr.ConditionId.ToString() + ".ProcessId = DbProcess.Id";
                        FromString = FromString + " JOIN AspNetUserRoles Role" + AndOr.ConditionId.ToString() + " ON Role" + AndOr.ConditionId.ToString() + ".RoleId = Field" + AndOr.ConditionId.ToString() + ".StringValue ";

                        WhereString = WhereString + " Role" + AndOr.ConditionId.ToString() + ".UserId ='" + CurrentUser.Id.ToString() + "' ";
                        break;
                    case 5:

                        FromString = FromString + " JOIN DbProcessTemplateField TemplateField" + AndOr.ConditionId.ToString() + " ON DbProcessTemplateFlow.ProcessTemplateId = TemplateField" + AndOr.ConditionId.ToString() + ".ProcessTemplateId ";
                        FromString = FromString + " JOIN DbProcessField Field1 ON Field" + AndOr.ConditionId.ToString() + ".ProcessTemplateFieldId = TemplateField" + AndOr.ConditionId.ToString() + ".Id ";
                        FromString = FromString + " AND Field" + AndOr.ConditionId.ToString() + ".ProcessId = DbProcess.Id ";
                        FromString = FromString + " JOIN dbUserRelation Relation" + AndOr.ConditionId.ToString() + " ON Relation" + AndOr.ConditionId.ToString() + ".FromUserId = Field" + AndOr.ConditionId.ToString() + ".StringValue ";

                        WhereString = WhereString + " Relation" + AndOr.ConditionId.ToString() + ".ToUserId ='" + CurrentUser.Id.ToString() + "' ";
                        WhereString = WhereString + " AND DbProcessTemplateField AS TemplateField" + AndOr.ConditionId.ToString() + ".ProcessTemplateFieldTypeId = 11" + AndOr.ConditionFieldId.ToString();
                        WhereString = WhereString + " AND DbProcessField AS Field" + AndOr.ConditionId.ToString() + ".StringValue = Relation" + AndOr.ConditionId.ToString() + ".FromUserId ";
                        break;
                    case 6:
                        WhereString = WhereString + " DbProcessTemplateField AS TemplateField" + AndOr.ConditionId.ToString() + ".ProcessTemplateFieldTypeId = 13" + AndOr.ConditionFieldId.ToString();
                        WhereString = WhereString + " AND DbProcessField AS Field" + AndOr.ConditionId.ToString() + ".StringValue = DbUserOrganization.OrganizationId ";
                        WhereString = WhereString + " AND DbUserOrganization AS UserOrganization" + AndOr.ConditionId.ToString() + ".UserId = '" + CurrentUser.Id + "' ";
                        break;
                    case 9:
                        WhereString += " ( ";
                        break;
                    case 10:
                        WhereString += " AND ";
                        break;
                    case 11:
                        WhereString += " OR ";
                        break;
                    case 12:
                        WhereString += " ) ";
                        break;
                    case 13:
                        FromString = FromString + " JOIN DbProcessTemplateField TemplateField" + AndOr.ConditionId.ToString() + " ON DbProcessTemplateFlow.ProcessTemplateId = TemplateField" + AndOr.ConditionId.ToString() + ".ProcessTemplateId ";
                        FromString = FromString + " JOIN DbProcessField Field1 ON Field" + AndOr.ConditionId.ToString() + ".ProcessTemplateFieldId = TemplateField" + AndOr.ConditionId.ToString() + ".Id ";
                        FromString = FromString + " AND Field" + AndOr.ConditionId.ToString() + ".ProcessId = DbProcess.Id ";
                        break;
                    case 14:

                        FromString = FromString + " JOIN dbUserRelation Relation" + AndOr.ConditionId.ToString() + " ON Relation" + AndOr.ConditionId.ToString() + ".FromUserId = dbProcess.CreatorId ";

                        WhereString = WhereString + " DbProcess.CreatorId = Relation" + AndOr.ConditionId.ToString() + ".FromUserId ";// + CurrentUser.Id.ToString() + "' ";
                        WhereString = WhereString + " AND Relation" + AndOr.ConditionId.ToString() + ".ToUserId ='" + CurrentUser.Id.ToString() + "' ";
                        break;
                    case 15:
                        FromString = FromString + " JOIN AspNetUsers User" + AndOr.ConditionId.ToString() + " ON User" + AndOr.ConditionId.ToString() + ".Id = dbProcess.CreatorId ";
                        break;

                }

                }
                if (FirstRecord)
                {
                    FullSQL = FullSQL + FromString + WhereString;

                }
                else
                {
                    FullSQL = FullSQL + " UNION ALL " + FromString + WhereString;
                }
                FirstRecord = false;

                //  FullSQL = FullSQL + FromStringStart + FromString + WhereString;

                //if (AndOr.FlowId != OldFlowId )
                //{
                //    WhereString = WhereString + ")) ";
                //}

                // OldFlowId = AndOr.FlowId;

            }
            //            WhereString = WhereString + " ) )";
            var ToDo = _context.ZdbFrontProcessToDoIndex2Get.FromSql(FullSQL).ToList();
            return View(ToDo);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@PId",Id)
                };

            List< SuFrontProcessTodoEditGetModel> ToDo = _context.ZdbSuFrontProcessTodoEditGet.FromSql("FrontProcessToDoEditGet @LanguageId, @PId", parameters).ToList();

            return View(ToDo);
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(SuFrontProcessTodoEditGetModel FromForm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var CurrentUser = await _userManager.GetUserAsync(User);
        //        var DefaultLanguageID = CurrentUser.DefaultLanguageId;
        //        SqlParameter[] parameters =
        //            {
        //            new SqlParameter("@Id", FromForm.Classification.Id),
        //            new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId),
        //            new SqlParameter("@ClassificationStatusId", FromForm.Classification.ClassificationStatusId),
        //            new SqlParameter("@DefaultClassificationPageId", FromForm.Classification.DefaultClassificationPageId),
        //            new SqlParameter("@HasDropDown", FromForm.Classification.HasDropDown),
        //            new SqlParameter("@DropDownSequence", FromForm.Classification.DropDownSequence),
        //            new SqlParameter("@ModifierId", CurrentUser.Id),
        //            new SqlParameter("@Name", FromForm.Classification.Name),
        //            new SqlParameter("@Description", FromForm.Classification.Description),
        //            new SqlParameter("@MouseOver", FromForm.Classification.MouseOver),
        //            new SqlParameter("@MenuName", FromForm.Classification.MenuName)
        //            };
        //        _context.Database.ExecuteSqlCommand("ClassificationEditPost " +
        //                    "@Id" +
        //                    ", @LanguageId" +
        //                    ", @ClassificationStatusId" +
        //                    ", @DefaultClassificationPageId" +
        //                    ", @HasDropDown" +
        //                    ", @DropDownSequence" +
        //                    ", @ModifierId" +
        //                    ", @Name" +
        //                    ", @Description" +
        //                    ", @MouseOver" +
        //                    ", @MenuName", parameters);
        //    }
        //    return RedirectToAction("Index");
        //}


    }
}

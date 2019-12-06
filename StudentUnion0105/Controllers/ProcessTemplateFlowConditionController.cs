using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;

namespace StudentUnion0105.Controllers
{
    public class ProcessTemplateFlowConditionController : Controller
    {
        private readonly UserManager<SuUserModel> _userManager;
        private readonly IProcessTemplateFlowConditionRepository _processTemplateFlowCondition;
        private readonly IProcessTemplateFlowConditionLanguageRepository _processTemplateFlowConditionLanguageRepository;
        private readonly ILanguageRepository _language;
        private readonly IPageSectionTypeRepository _pageSectionType;
        private readonly SuDbContext _context;

        public ProcessTemplateFlowConditionController(UserManager<SuUserModel> userManager
            , IProcessTemplateFlowConditionRepository processTemplateFlowCondition
            , IProcessTemplateFlowConditionLanguageRepository templateFlowConditionLanguageRepository
            , ILanguageRepository language
            , IPageSectionTypeRepository pageSectionType
            , SuDbContext context)
        {
            _userManager = userManager;
            _processTemplateFlowCondition = processTemplateFlowCondition;
            _processTemplateFlowConditionLanguageRepository = templateFlowConditionLanguageRepository;
            _language = language;
            _pageSectionType = pageSectionType;
            _context = context;
        }
        public async Task<IActionResult> Index(int Id)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@PId", Id)
                };


            var Condition = _context.ZdbObjectIndexGet.FromSql("ProcessTemplateFlowConditionIndexGet @LanguageId, @PId", parameters).ToList();
            return View(Condition);
        }
    [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            SqlParameter[] parameters =
                {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@Id", Id)
                };

            var ProcessTemplateFlowConditionEditGet = _context.ZdbProcessTemplateFlowConditionEditGet.FromSql("ProcessTemplateFlowConditionEditGet @LanguageId, @Id", parameters).First();

            var ProcessTemplateFlowConditionTypesFromDb = _context.ZDbTypeList.FromSql($"ProcessTemplateFlowConditionCreateGetType").ToList();

            var ProcessTemplateFlowConditionTypeList = new List<SelectListItem>(); 

            foreach (var ProcessTemplateFlowConditionTypeFromDb in ProcessTemplateFlowConditionTypesFromDb)
            {
                ProcessTemplateFlowConditionTypeList.Add(new SelectListItem
                {
                    Text = ProcessTemplateFlowConditionTypeFromDb.Name,
                    Value = ProcessTemplateFlowConditionTypeFromDb.Id.ToString()
                });
            }


            var ProcessTemplateFlowFieldsFromDb = _context.ZDbStatusList.FromSql($"ProcessTemplateFlowConditionCreateGetFields @LanguageId, @Id", parameters).ToList();

            var ProcessTemplateFlowFieldList = new List<SelectListItem>();
            ProcessTemplateFlowFieldList.Add(new SelectListItem
            {
                Text = "No field",
                Value = "0"
            });
            foreach (var ProcessTemplateFlowFieldFromDb in ProcessTemplateFlowFieldsFromDb)
            {
                ProcessTemplateFlowFieldList.Add(new SelectListItem
                {
                    Text = ProcessTemplateFlowFieldFromDb.Name,
                    Value = ProcessTemplateFlowFieldFromDb.Id.ToString()
                });
            }

            var ComparisonsFromDb = _context.ZDbLanguageList.FromSql($"ProcessTemplateFlowConditionCreateGetComparison").ToList();

            var ComparisonList = new List<SelectListItem>();

            foreach (var ComparisonFromDb in ComparisonsFromDb)
            {
                ComparisonList.Add(new SelectListItem
                {
                    Text = ComparisonFromDb.Name,
                    Value = ComparisonFromDb.Id.ToString()
                });
            }


            var DataTypesFromDb = _context.DbSecurityLevelList.FromSql($"DataTypeSelectAll").ToList();

            var DataTypeList = new List<SelectListItem>();

            foreach (var DataTypeFromDb in DataTypesFromDb)
            {
                DataTypeList.Add(new SelectListItem
                {
                    Text = DataTypeFromDb.Name,
                    Value = DataTypeFromDb.Id.ToString()
                });
            }



            var ConditionWithLists = new SuProcessTemplateFlowConditionEditGetWithListModel { 
                    Condition = ProcessTemplateFlowConditionEditGet
                    , ConditionTypeList = ProcessTemplateFlowConditionTypeList
                    , FieldList = ProcessTemplateFlowFieldList
                    , ComparisonList = ComparisonList
                    , DataTypeList = DataTypeList
            };
            return View(ConditionWithLists);
            

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuProcessTemplateFlowConditionEditGetWithListModel FromForm)
        {

//            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                //                var FieldId 

                SqlParameter[] parameters =
               {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@OId", FromForm.Condition.OId)
                    , new SqlParameter("@Name", FromForm.Condition.Name ?? "")
                    , new SqlParameter("@Description", FromForm.Condition.Description ?? "")
                    , new SqlParameter("@MouseOver", FromForm.Condition.MouseOver ?? "")
                    , new SqlParameter("@MenuName", FromForm.Condition.MenuName ?? "")
                    , new SqlParameter("@ConditionTypeId", FromForm.Condition.ProcessTemplateConditionTypeId)
                    , new SqlParameter("@FieldId", FromForm.Condition.ProcessTemplateFieldId)
                    , new SqlParameter("@String", FromForm.Condition.ProcessTemplateFlowConditionString ?? "")
                    , new SqlParameter("@Int", FromForm.Condition.ProcessTemplateFlowConditionInt ?? 0)
                    , new SqlParameter("@Date", FromForm.Condition.ProcessTemplateFlowConditionDate )
                    , new SqlParameter("@ComparisonOperatorId", FromForm.Condition.ComparisonOperatorId)
                    , new SqlParameter("@DataTypeId", FromForm.Condition.DataTypeId)
                };

                var a = _context.Database.ExecuteSqlCommand("ProcessTemplateFlowConditionEditPost " +
                    "@LanguageId, @OId, @Name, @Description, @MouseOver, @MenuName, @ConditionTypeId, @FieldId, " +
                    "@String, @Int, @Date, @ComparisonOperatorId, @DataTypeId",
                    parameters);

             
            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("Index", new { Id = FromForm.Condition.OId.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            SuObjectVMPageSection ToForm = new SuObjectVMPageSection();
            ToForm.Id = Id;

            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);

            ToForm.LanguageId= DefaultLanguageID;
            var ProcessTemplateFlowConditionTypesFromDb = _context.ZDbTypeList.FromSql($"ProcessTemplateFlowConditionCreateGetType").ToList();

            var ProcessTemplateFlowConditionTypeList = new List<SelectListItem>();

            foreach (var ProcessTemplateFlowConditionTypeFromDb in ProcessTemplateFlowConditionTypesFromDb)
            {
                ProcessTemplateFlowConditionTypeList.Add(new SelectListItem
                {
                    Text = ProcessTemplateFlowConditionTypeFromDb.Name,
                    Value = ProcessTemplateFlowConditionTypeFromDb.Id.ToString()
                });
            }

            SqlParameter[] parameters =
    {
                    new SqlParameter("@LanguageId", DefaultLanguageID)
                    , new SqlParameter("@Id", Id)
                };


            var ProcessTemplateFlowFieldsFromDb = _context.ZDbStatusList.FromSql("GetProcessTemplateFlowConditionCreateGetFields @LanguageId, @Id", parameters).ToList();

            var ProcessTemplateFlowFieldList = new List<SelectListItem>();
            ProcessTemplateFlowFieldList.Add(new SelectListItem
            {
                Text = "No field",
                Value = "0"
            });
            foreach (var ProcessTemplateFlowFieldFromDb in ProcessTemplateFlowFieldsFromDb)
            {
                ProcessTemplateFlowFieldList.Add(new SelectListItem
                {
                    Text = ProcessTemplateFlowFieldFromDb.Name,
                    Value = ProcessTemplateFlowFieldFromDb.Id.ToString()
                });
            }


            var ComparisonOperator = new List<SelectListItem>();
            ComparisonOperator.Add(new SelectListItem() { Text = "Equal", Value = "EQ" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Larger", Value = "LA" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Smaller", Value = "SM" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Larger or equal", Value = "LQ" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Smaller or equal", Value = "SQ" });
            ComparisonOperator.Add(new SelectListItem() { Text = "Not equal", Value = "NQ" });

            var ClassificationAndStatus = new PageSectionAndStatusViewModel { SuObject = ToForm, SomeKindINumSelectListItem = ComparisonOperator, ProbablyTypeListItem = ProcessTemplateFlowConditionTypeList, ProbablyTypeListItem2 = ProcessTemplateFlowFieldList };
            return View(ClassificationAndStatus);


        }

        [HttpPost]
        public async Task<IActionResult> Create(PageSectionAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                //                var FieldId 
                var a = _context.Database.ExecuteSqlCommand("ProcessTemplateFlowConditionCreate @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, " +
                    "@p8, @p9, @p10",
                    parameters: new[] { FromForm.SuObject.Id.ToString()           //0
                                        ,FromForm.SuObject.LanguageId.ToString()    //1
                    , FromForm.SuObject.Name                  //2
                    , FromForm.SuObject.Description                      //3
                    , FromForm.SuObject.MouseOver                     //4
                    , FromForm.SuObject.Type.ToString()                  //5
                    , FromForm.SuObject.NullId.ToString()                           //6
                    , FromForm.SuObject.Description2           //7
                    , FromForm.SuObject.NullId2.ToString() //8
                    , FromForm.SuObject.DateFrom.ToString()           //9
                   , FromForm.SuObject.HeaderDescription

                    });


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("Index", new { Id = FromForm.SuObject.Id.ToString() });


        }

    }
}
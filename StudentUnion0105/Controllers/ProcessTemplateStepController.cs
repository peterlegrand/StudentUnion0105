using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;   

namespace StudentUnion0105.Controllers
{
    public class ProcessTemplateStepController : PortalController
    {
        private readonly IProcessTemplateRepository _processTemplate;
        private readonly IProcessTemplateLanguageRepository _processTemplateLanguage;
        private readonly IProcessTemplateStepRepository _processTemplateStep;
        private readonly IProcessTemplateStepLanguageRepository _processTemplateStepLanguage;
        private readonly IMasterListRepository _masterList;
        private readonly IDataTypeRepository _dataType;

        public ProcessTemplateStepController(UserManager<SuUserModel> userManager
            , IProcessTemplateRepository processTemplate
            , IProcessTemplateLanguageRepository processTemplateLanguage
            , ILanguageRepository language
            , IProcessTemplateStepRepository processTemplateStep
            , IProcessTemplateStepLanguageRepository processTemplateStepLanguage
            //, IProcessTemplateStepTypeRepository processTemplateStepType
            //, IProcessTemplateStepTypeLanguageRepository processTemplateStepTypeLanguage
            , SuDbContext context
            , IMasterListRepository masterList
            , IDataTypeRepository dataType) : base(userManager, language, context)
        {
            _processTemplate = processTemplate;
            _processTemplateLanguage = processTemplateLanguage;
            _processTemplateStep = processTemplateStep;
            _processTemplateStepLanguage = processTemplateStepLanguage;
            _masterList = masterList;
            _dataType = dataType;
        }

        public SuDbContext Context { get; }

        public async Task<IActionResult> Index(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();


            var ProcessTemplateStep = (from c in  _processTemplateStep.GetAllProcessTemplateSteps()
                               join l in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                      on c.Id equals l.StepId
                               where c.ProcessTemplateId== Id
                               && l.LanguageId == CurrentUser.DefaultLanguageId
                                       orderby l.Name
                               select new SuObjectVM
                               {
                                   Id = c.Id
                               ,
                                   Name = l.Name
                               ,
                                   ObjectId = c.ProcessTemplateId
                               }).ToList();
            ViewBag.ObjectId = Id.ToString();


            return View(ProcessTemplateStep);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();

            var ProcessTemplateStep = (from c in _processTemplateStep.GetAllProcessTemplateSteps()
                                        join l in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                                        on c.Id equals l.StepId
                                        where c.Id == Id && l.LanguageId == CurrentUser.DefaultLanguageId
                                       orderby l.Name
                                        select new SuObjectVM
                                        {
                                            Id = c.ProcessTemplateId
                                            ,
                                            ObjectId = c.Id
                                            ,
                                            LanguageId = l.LanguageId
                                            ,
                                            ObjectLanguageId = l.Id
                                            ,
                                            Name = l.Name
                                            ,
                                            Description = l.Description
                                            ,
                                            MouseOver = l.MouseOver
                                        }).First();

            //DataTypes
            var DataTypeList = new List<SelectListItem>();

            var DataTypesFromDb = _context.ZDbStatusList.FromSql($"DataTypeSelectAll").ToList();


            foreach (var DataTypeFromDb in DataTypesFromDb)
            {
                DataTypeList.Add(new SelectListItem
                {
                    Text = DataTypeFromDb.Name,
                    Value = DataTypeFromDb.Id.ToString()
                });
            }

            //ContentType


            //MasterList
            var MasterListList = new List<SelectListItem>();

            var MasterListsFromDb = _context.ZDbStatusList.FromSql($"GetMasterList").ToList();


            foreach (var MasterListFromDb in MasterListsFromDb)
            {
                MasterListList.Add(new SelectListItem
                {
                    Text = MasterListFromDb.Name,
                    Value = MasterListFromDb.Id.ToString()
                });
            }

            //MasterList

//            var StepsAndDropDowns = new SuProcessTemplateStepWith2DropDown { Step = ProcessTemplateStep, DataTypes = DataTypeList, MasterList = MasterListList } ;


            return View(ProcessTemplateStep);
           

        }

        [HttpPost]
        public IActionResult Edit(SuObjectVM FromForm)
        {

            if (ModelState.IsValid)
            {
    
                _context.Database.ExecuteSqlCommand("ProcessTemplateStepUpdate @p0, @p1, @p2, @p3, @p4, @p5, @p6 " 
                    ,
                    parameters: new[] { FromForm.ObjectId.ToString()           //0
                                        , FromForm.ObjectLanguageId.ToString()
                                        , FromForm.Name
                                        , FromForm.Description
                                        , FromForm.MouseOver

                    });
            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("Index", new { Id = FromForm.Id.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();

            var ProcessTemplateStep = new SuObjectVM
            {
                Id = Id
                                            ,
                LanguageId = CurrentUser.DefaultLanguageId
            };

            //DataTypes


            return View(ProcessTemplateStep);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
    

                SqlParameter[] parameters =
    {
                    new SqlParameter("@ProcessTemplateId", FromForm.Id)
                    , new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@Name", FromForm.Name)
                    , new SqlParameter("@Description", FromForm.Description)
                    , new SqlParameter("@MouseOver", FromForm.MouseOver)
                };


                _context.Database.ExecuteSqlCommand("ProcessTemplateStepCreate @ProcessTemplateId, @LanguageId, @Name, @Description, @MouseOver", parameters);

            }
            return RedirectToAction("Index", new { Id = FromForm.Id.ToString() });

        }


        public IActionResult LanguageIndex(int Id)
        {

            base.Initializing();

            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ProcessTemplateStepLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            base.Initializing();

            var parameter = new SqlParameter("@Id", Id);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ProcessTemplateStepLanguageEditGet @Id", parameter).First();
            return View(ObjectLanguage);

        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateStepLanguage = _processTemplateStepLanguage.GetProcessTemplateStepLanguage(FromForm.SuObject.Id);
                ProcessTemplateStepLanguage.Name = FromForm.SuObject.Name;
                ProcessTemplateStepLanguage.Description = FromForm.SuObject.Description;

                ProcessTemplateStepLanguage.MouseOver = FromForm.SuObject.MouseOver;
                _processTemplateStepLanguage.UpdateProcessTemplateStepLanguage(ProcessTemplateStepLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+test3.Classification.ClassificationId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);



            base.Initializing();

            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                                where c.StepId == Id
                                select c.LanguageId).ToList();


            var SuLanguage = (from l in _language.GetAllLanguages()
                              where !LanguagesAlready.Contains(l.Id)
                              && l.Active == true
                              select new SelectListItem
                              {
                                  Value = l.Id.ToString()
                              ,
                                  Text = l.LanguageName
                              }).ToList();

            if (SuLanguage.Count() == 0)
            {
                return RedirectToAction("LanguageIndex", new { Id });
            }
            SuObjectVM SuObject = new SuObjectVM
            {
                ObjectId = Id
            };
            ViewBag.Id = Id.ToString();
            var ClassificationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(ClassificationAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel test3)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateStepLanguage = new SuProcessTemplateStepLanguageModel
                {
                    Name = test3.SuObject.Name,
                    Description = test3.SuObject.Description,
                    MouseOver = test3.SuObject.MouseOver,
                    StepId = test3.SuObject.ObjectId,
                    LanguageId = test3.SuObject.LanguageId
                };

                _processTemplateStepLanguage.AddProcessTemplateStepLanguage(ProcessTemplateStepLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }


    }
}
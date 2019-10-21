using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;   

namespace StudentUnion0105.Controllers
{
    public class ProcessTemplateStepController : Controller
    {
        private readonly UserManager<SuUserModel> _userManager;
        private readonly IProcessTemplateRepository _processTemplate;
        private readonly IProcessTemplateLanguageRepository _processTemplateLanguage;
        private readonly ILanguageRepository _language;
        private readonly IProcessTemplateStepRepository _processTemplateStep;
        private readonly IProcessTemplateStepLanguageRepository _processTemplateStepLanguage;
        //private readonly IProcessTemplateStepTypeRepository _processTemplateStepType;
        //private readonly IProcessTemplateStepTypeLanguageRepository _processTemplateStepTypeLanguage;
        private readonly SuDbContext _context;
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
            , IDataTypeRepository dataType)
        {
            _userManager = userManager;
            _processTemplate = processTemplate;
            _processTemplateLanguage = processTemplateLanguage;
            _language = language;
            _processTemplateStep = processTemplateStep;
            _processTemplateStepLanguage = processTemplateStepLanguage;
            //_processTemplateStepType = processTemplateStepType;
            //_processTemplateStepTypeLanguage = processTemplateStepTypeLanguage;
            _context = context;
            _masterList = masterList;
            _dataType = dataType;
        }

        public SuDbContext Context { get; }

        public async Task<IActionResult> Index(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var ProcessTemplateStep = (from c in  _processTemplateStep.GetAllProcessTemplateSteps()
                               join l in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                      on c.Id equals l.StepId
                               where c.ProcessTemplateId== Id
                               && l.LanguageId == DefaultLanguageID
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
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var ProcessTemplateStep = (from c in _processTemplateStep.GetAllProcessTemplateSteps()
                                        join l in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                                        on c.Id equals l.StepId
                                        where c.Id == Id && l.LanguageId == DefaultLanguageID
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

            var DataTypesFromDb = _context.dbStatusList.FromSql($"DataTypeSelectAll").ToList();


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

            var MasterListsFromDb = _context.dbStatusList.FromSql($"GetMasterList").ToList();


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
        public async Task<IActionResult> Edit(SuObjectVM FromForm)
        {

            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;
                var a = _context.Database.ExecuteSqlCommand("ProcessTemplateStepUpdate @p0, @p1, @p2, @p3, @p4, @p5, @p6 " 
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
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;
            var ProcessTemplateStep = new SuObjectVM
            {
                Id = Id
                                            ,
                LanguageId = DefaultLanguageID
            };

            //DataTypes
            var DataTypeList = new List<SelectListItem>();

            var DataTypesFromDb = _context.dbStatusList.FromSql($"DataTypeSelectAll").ToList();


            //foreach (var DataTypeFromDb in DataTypesFromDb)
            //{
            //    DataTypeList.Add(new SelectListItem
            //    {
            //        Text = DataTypeFromDb.Name,
            //        Value = DataTypeFromDb.Id.ToString()
            //    });
            //}

            //ContentType


            //MasterList
            //var MasterListList = new List<SelectListItem>();

            //var MasterListsFromDb = _context.dbTypeList.FromSql($"GetMasterList").ToList();


            //foreach (var MasterListFromDb in MasterListsFromDb)
            //{
            //    MasterListList.Add(new SelectListItem
            //    {
            //        Text = MasterListFromDb.Name,
            //        Value = MasterListFromDb.Id.ToString()
            //    });
            //}

            //MasterList

            //var StepsAndDropDowns = new SuObjectVM { Step = ProcessTemplateStep, DataTypes = DataTypeList, MasterList = MasterListList };


            return View(ProcessTemplateStep);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuObjectVM FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLanguageId;

                var a = _context.Database.ExecuteSqlCommand("ProcessTemplateStepCreate @p0, @p1, @p2, @p3, @p4, @p5, @p6  ",
                    parameters: new[] { FromForm.Id.ToString()           //0
                                           , FromForm.LanguageId.ToString()
                                           , FromForm.Name
                                           , FromForm.Description
                                           , FromForm.MouseOver


                    });

            }
            return RedirectToAction("Index", new { Id = FromForm.Id.ToString() });

        }


        public IActionResult LanguageIndex(int Id)
        {

            var 
                ProcessTemplateStepLanguage = (from c in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
                                          join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                                          where c.StepId == Id
                                          select new SuObjectVM
                                          {
                                              Id = c.Id
                                          ,
                                              Name = c.Name
                                          ,
                                              Language = l.LanguageName
                                          ,
                                              MouseOver = c.MouseOver
                                          ,
                                              ObjectId = c.StepId
                                          }).ToList();
            ViewBag.Id = Id;

            return View(ProcessTemplateStepLanguage);
        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var StepLanguage = (from c in _processTemplateStepLanguage.GetAllProcessTemplateStepLanguages()
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
                             ObjectId = c.StepId

                         }).First();

            var ClassificationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = StepLanguage //, a = ClassificationList
            };
            return View(ClassificationAndStatus);
            //return View(StepLanguage);


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
        public IActionResult LanguageCreate(int Id)
        {
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
                return RedirectToAction("LanguageIndex", new { Id = Id });
            }
            SuObjectVM SuObject = new SuObjectVM();
            SuObject.ObjectId = Id;
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
                var ProcessTemplateStepLanguage = new SuProcessTemplateStepLanguageModel();
                ProcessTemplateStepLanguage.Name = test3.SuObject.Name;
                ProcessTemplateStepLanguage.Description = test3.SuObject.Description;
                ProcessTemplateStepLanguage.MouseOver = test3.SuObject.MouseOver;
                ProcessTemplateStepLanguage.StepId = test3.SuObject.ObjectId;
                ProcessTemplateStepLanguage.LanguageId = test3.SuObject.LanguageId;

                var NewProcessTemplateStep = _processTemplateStepLanguage.AddProcessTemplateStepLanguage(ProcessTemplateStepLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = test3.SuObject.ObjectId.ToString() });



        }


    }
}